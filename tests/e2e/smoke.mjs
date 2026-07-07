// Headless browser smoke + interaction test for the Blazor-ApexSankey demo.
//
// Why this exists: a Blazor chart wrapper can build and even serialize its options perfectly yet
// still fail in the browser, because the real contract lives in the JS interop and the core library.
// This test drives the actual WASM app in a real browser and fails CI if any demo page throws,
// shows the Blazor error UI, or renders no diagram. It also checks that the RTL locale option
// actually re-lays-out the diagram (mirrors it), not just that the page survives.
//
// Usage:
//   BASE_URL=http://localhost:5183 node smoke.mjs
//   PW_CHANNEL=chrome node smoke.mjs   # drive an installed Chrome instead of bundled chromium
let chromium;
try {
  ({ chromium } = await import('playwright'));
} catch {
  ({ chromium } = await import('playwright-core'));
}

const BASE = process.env.BASE_URL || 'http://localhost:5183';
const channel = process.env.PW_CHANNEL;

// Chart demo routes. Each must render a Sankey SVG with no console/page errors. The home route ('')
// is a landing page with no diagram, so it is exercised by the boot step below (errors only).
const ROUTES = [
  'basic-sankey', 'custom-fonts', 'alternate-node', 'node-customization',
  'node-overlapping', 'edge-options', 'tooltip', 'animation', 'locale',
];

const failures = [];
const launchOpts = channel ? { channel, headless: true } : { headless: true };
const browser = await chromium.launch(launchOpts);
const page = await browser.newPage({ viewport: { width: 1280, height: 900 } });

let pageErrors = [];
page.on('console', m => { if (m.type() === 'error') pageErrors.push(m.text().slice(0, 200)); });
page.on('pageerror', e => pageErrors.push('PAGEERROR: ' + e.message.slice(0, 200)));

// Boot the home page: warms the WASM runtime and asserts the landing page loads clean.
pageErrors = [];
await page.goto(BASE + '/', { waitUntil: 'domcontentloaded' });
await page.waitForSelector('nav, .sidebar', { timeout: 90000 });
await page.waitForTimeout(3000);
if (pageErrors.length) failures.push(`[(home)] console/page errors: ${JSON.stringify(pageErrors)}`);
console.log(`[(home)] booted errors=${pageErrors.length}`);

async function checkRoute(route) {
  pageErrors = [];
  await page.goto(BASE + '/' + route, { waitUntil: 'domcontentloaded' });
  try { await page.waitForSelector('.chart-container svg', { timeout: 20000 }); } catch { /* asserted below */ }
  await page.waitForTimeout(1500);

  const st = await page.evaluate(() => {
    const eu = document.querySelector('#blazor-error-ui');
    const svg = document.querySelector('.chart-container svg');
    return {
      errUiShown: eu ? getComputedStyle(eu).display !== 'none' : false,
      hasSvg: !!svg,
      shapes: svg ? svg.querySelectorAll('rect, path').length : 0,
    };
  });

  if (pageErrors.length) failures.push(`[${route}] console/page errors: ${JSON.stringify(pageErrors)}`);
  if (st.errUiShown) failures.push(`[${route}] Blazor error UI is visible`);
  if (!st.hasSvg || st.shapes === 0) failures.push(`[${route}] no diagram rendered (svg=${st.hasSvg}, shapes=${st.shapes})`);
  console.log(`[${route}] svg=${st.hasSvg} shapes=${st.shapes} errUi=${st.errUiShown} errors=${pageErrors.length}`);
}

for (const r of ROUTES) await checkRoute(r);

// Interaction: switching Locale to RTL must actually mirror the diagram (leftmost node moves right).
pageErrors = [];
await page.goto(BASE + '/locale', { waitUntil: 'domcontentloaded' });
await page.waitForSelector('.chart-container svg text', { timeout: 20000 });
await page.waitForTimeout(1200);
const firstLabel = async () => page.evaluate(() => {
  const t = document.querySelector('.chart-container svg text');
  return t ? { x: parseFloat(t.getAttribute('x')), anchor: t.getAttribute('text-anchor'), text: t.textContent } : null;
});
const ltr = await firstLabel();
await page.selectOption('select', 'rtl').catch(() => {});
await page.waitForTimeout(1500);
const rtl = await firstLabel();
const mirrored = ltr && rtl && ltr.text === rtl.text && ltr.x !== rtl.x;
if (!mirrored) {
  failures.push(`[locale] RTL did not re-lay-out the diagram: ltr=${JSON.stringify(ltr)} rtl=${JSON.stringify(rtl)}`);
}
if (pageErrors.length) failures.push(`[locale] console/page errors after RTL: ${JSON.stringify(pageErrors)}`);
console.log(`[locale] ltr=${JSON.stringify(ltr)} rtl=${JSON.stringify(rtl)} mirrored=${mirrored}`);

await browser.close();

if (failures.length) {
  console.error('\nE2E SMOKE FAILED:\n' + failures.map(f => '  - ' + f).join('\n'));
  process.exit(1);
}
console.log('\nE2E smoke passed: all routes rendered and the RTL locale mirrored the diagram.');
