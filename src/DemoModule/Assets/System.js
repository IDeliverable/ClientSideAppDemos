/// <reference path="../../../../node_modules/@types/jquery/index.d.ts" />
/// <reference path="../../../../node_modules/@types/systemjs/index.d.ts" />
var scriptsPath = $(document.currentScript).data("scripts-path");
var isDebug = $(document.currentScript).data("is-debug").toLowerCase() === "true";
System.config({
    map: {
        "wizard": scriptsPath + "/Wizard",
        "core-js": "https://unpkg.com/core-js/client/shim.min.js",
        "zone.js": "https://unpkg.com/zone.js/dist/zone.min.js",
        "rxjs": "https://unpkg.com/rxjs",
        "@angular": "https://unpkg.com/@angular",
    },
    packages: {
        "wizard": {
            main: isDebug ? "Wizard.js" : "Wizard.min.js",
            defaultExtension: isDebug ? "js" : "min.js"
        }
    }
});
