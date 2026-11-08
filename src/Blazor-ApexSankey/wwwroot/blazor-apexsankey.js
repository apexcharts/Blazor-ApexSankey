/**
 * Blazor-ApexSankey JavaScript Interop Module
 *
 * provides the bridge between Blazor and the ApexSankey library
 */

// store for chart instances keyed by element id
const chartInstances = new Map();

// cached ApexSankey constructor
let ApexSankeyClass = null;

/**
 * gets the ApexSankey constructor, trying multiple approaches
 */
async function getApexSankeyConstructor() {
  // return cached if available
  if (ApexSankeyClass) {
    return ApexSankeyClass;
  }

  // check global window object first
  if (typeof window.ApexSankey !== "undefined") {
    ApexSankeyClass = window.ApexSankey;
    return ApexSankeyClass;
  }

  // try dynamic import as ES module
  try {
    const module = await import(
      "./_content/Blazor-ApexSankey/apexsankey.min.js"
    );
    ApexSankeyClass = module.default || module.ApexSankey;
    if (ApexSankeyClass) {
      return ApexSankeyClass;
    }
  } catch (e) {
    console.log("ES module import failed, trying alternate path...", e);
  }

  // try alternate import path
  try {
    const module = await import("./apexsankey.min.js");
    ApexSankeyClass = module.default || module.ApexSankey;
    if (ApexSankeyClass) {
      return ApexSankeyClass;
    }
  } catch (e) {
    console.log("Alternate ES module import failed", e);
  }

  throw new Error(
    "ApexSankey library not loaded. Make sure apexsankey.min.js (or apexsankey.es.min.js) is included and properly exported."
  );
}

/**
 * sets the license key for ApexSankey
 * @param {string} licenseKey - the license key
 * @returns {boolean} - true if successful
 */
export async function setLicense(licenseKey) {
  try {
    const ctor = await getApexSankeyConstructor();
    if (ctor.setLicense) {
      ctor.setLicense(licenseKey);
      return true;
    } else {
      console.error("ApexSankey setLicense method not available");
      return false;
    }
  } catch (error) {
    console.error("failed to set ApexSankey license:", error);
    return false;
  }
}

// pending or settled load of the Ignite UI add-on (loaded at most once)
let igniteUILoad = null;

/**
 * loads the Ignite UI add-on, which registers the Ignite UI adapter on the
 * family-wide registry so diagrams read the page's --ig-* tokens. resolves to
 * false (with a console error) when the file cannot be loaded, so a missing
 * add-on never blocks a render.
 * @returns {Promise<boolean>} - true once the add-on is loaded
 */
export function loadIgniteUI() {
  if (!igniteUILoad) {
    igniteUILoad = import("./apexsankey.ignite-ui.es.min.js").then(
      () => true,
      (error) => {
        console.error("failed to load the ApexSankey Ignite UI add-on:", error);
        return false;
      }
    );
  }
  return igniteUILoad;
}

/**
 * re-reads the theme (the --apex-sankey-* variables, the --apx-* tokens, the
 * named or registered theme and the page's design system) and repaints the
 * diagram. call it after a stylesheet swap, such as an Ignite UI light/dark switch.
 * @param {string} elementId - the container element id
 */
export function refreshTokens(elementId) {
  const chartData = chartInstances.get(elementId);
  if (!chartData) {
    return;
  }

  if (typeof chartData.instance.refreshTokens === "function") {
    chartData.instance.refreshTokens();
  } else {
    console.warn("refreshTokens method not available on chart instance");
  }
}

/**
 * creates a new sankey chart instance
 * @param {string} elementId - the container element id
 * @param {object} options - chart options
 * @param {object} data - chart data (nodes, edges, options)
 * @param {object} dotNetRef - reference to .NET object for callbacks
 */
export async function create(elementId, options, data, dotNetRef) {
  try {
    const element = document.getElementById(elementId);
    if (!element) {
      throw new Error(`Element with id '${elementId}' not found`);
    }

    // destroy existing instance if present
    if (chartInstances.has(elementId)) {
      destroy(elementId);
    }

    // get the ApexSankey constructor
    const ApexSankey = await getApexSankeyConstructor();

    // separate the Blazor-only `plugins` config from the core chart options
    const { plugins, ...coreOptions } = options || {};

    // merge options with node click callback
    const mergedOptions = {
      ...coreOptions,
      onNodeClick: (node) => {
        if (dotNetRef) {
          dotNetRef.invokeMethodAsync("OnNodeClickCallback", {
            id: node.id,
            title: node.title,
            color: node.color || null,
          });
        }
      },
    };

    // template options arrive as function-source strings; turn them back into functions
    for (const key of ["tooltipTemplate", "nodeTooltipTemplate"]) {
      if (coreOptions[key] && typeof coreOptions[key] === "string") {
        try {
          mergedOptions[key] = eval(`(${coreOptions[key]})`);
        } catch (e) {
          console.error(`failed to parse ${key}:`, e);
        }
      }
    }

    // create the chart instance
    const sankey = new ApexSankey(element, mergedOptions);
    sankey.render(data);

    // install any configured built-in plugins (path tracing, time playback, drill-down)
    if (plugins && ApexSankey.plugins) {
      if (plugins.pathTrace) {
        sankey.use(ApexSankey.plugins.pathTrace(plugins.pathTrace));
      }
      if (plugins.timePlayback) {
        sankey.use(ApexSankey.plugins.timePlayback(plugins.timePlayback));
      }
      if (plugins.drillDown) {
        sankey.use(ApexSankey.plugins.drillDown(plugins.drillDown));
      }
    }

    // store reference
    chartInstances.set(elementId, {
      instance: sankey,
      dotNetRef: dotNetRef,
    });

    // fire render callback
    if (dotNetRef) {
      dotNetRef.invokeMethodAsync("OnRenderCallback");
    }
  } catch (error) {
    console.error("failed to create ApexSankey chart:", error);
    throw error;
  }
}

/**
 * updates an existing chart with new data
 * @param {string} elementId - the container element id
 * @param {object} data - new chart data
 */
export function update(elementId, data) {
  try {
    const chartData = chartInstances.get(elementId);
    if (!chartData) {
      throw new Error(`No chart instance found for element '${elementId}'`);
    }

    // re-render with new data
    chartData.instance.render(data);

    // fire render callback
    if (chartData.dotNetRef) {
      chartData.dotNetRef.invokeMethodAsync("OnRenderCallback");
    }
  } catch (error) {
    console.error("failed to update ApexSankey chart:", error);
    throw error;
  }
}

/**
 * destroys a chart instance and cleans up resources
 * @param {string} elementId - the container element id
 */
export function destroy(elementId) {
  try {
    const chartData = chartInstances.get(elementId);
    if (chartData) {
      // run the library teardown first (plugin teardowns, event handlers, and
      // the injected tooltip DOM), then clear the container as a fallback
      if (
        chartData.instance &&
        typeof chartData.instance.destroy === "function"
      ) {
        try {
          chartData.instance.destroy();
        } catch (e) {
          console.error("error during ApexSankey instance destroy:", e);
        }
      }

      // clear the container
      const element = document.getElementById(elementId);
      if (element) {
        element.innerHTML = "";
      }

      chartInstances.delete(elementId);
    }
  } catch (error) {
    console.error("failed to destroy ApexSankey chart:", error);
  }
}

/**
 * exports the chart as SVG
 * @param {string} elementId - the container element id
 */
export function exportToSvg(elementId) {
  try {
    const chartData = chartInstances.get(elementId);
    if (!chartData) {
      throw new Error(`No chart instance found for element '${elementId}'`);
    }

    if (chartData.instance.exportToSvg) {
      chartData.instance.exportToSvg();
    } else {
      console.warn("exportToSvg method not available on chart instance");
    }
  } catch (error) {
    console.error("failed to export ApexSankey chart:", error);
    throw error;
  }
}
