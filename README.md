# ClientSideAppDemos

This repo contains all the sample code from the Orchard Harvest 2017 talk "Building JavaScript-based apps and components for Orchard websites" which you can watch here:

https://www.youtube.com/watch?v=hvVukPqg2kY

This sample code is not intended to be self-explanatory; it is meant to complement the video recording of the talk mentioned above, and/or the upcoming blog posts where I will go into some more details on things I didn't have time to cover in the talk.

This repo needs to be cloned and copied into the context of an Orchard site to be compiled and executed. It contains two modules, `DemoApi` and `DemoModule`, both of which should be copied into the `Orchard.Web/Modules` folder of your local Orchard website.

Additionally, you need to add the following to the bottom of the `Package.json` file in your Orchard solution root:

``` js
"@types/jquery": "2.0.40",
"@types/handlebars": "4.0.31",
"handlebars": "4.0.6",
"browserify": "14.0.0",
"tsify": "3.0.1",
"hbsfy": "2.7.0",
"scssify": "2.2.1",
"vinyl-source-stream": "1.1.0",
"vinyl-buffer": "1.0.0",

"@types/systemjs": "0.20.0",
"core-js": "2.4.1",
"zone.js": "0.7.6",
"rxjs": "5.0.3",
"@angular/common": "2.4.7",
"@angular/compiler": "2.4.7",
"@angular/core": "2.4.7",
"@angular/forms": "2.4.7",
"@angular/http": "2.4.7",
"@angular/platform-browser": "2.4.7",
"@angular/platform-browser-dynamic": "2.4.7",
"@angular/router": "3.4.7"
```

And the following to the bottom of the `Gulpfile.js` file in your Orchard solution root:

``` js
/*
**
** StockInfo component
**
**
*/

var browserify = require("browserify");
var tsify = require("tsify");
var hbsfy = require("hbsfy");
var scssify = require("scssify");
var source = require("vinyl-source-stream");
var buffer = require("vinyl-buffer");

gulp.task("DemoModule.StockInfo", function ()
{
    return browserify("Orchard.Web/Modules/DemoModule/Assets/StockInfo/StockInfo.ts")
        .transform(hbsfy)
        .transform(scssify)
        .plugin(tsify, {
            noImplicitAny: true,
            lib: ["es2015", "dom"],
        })
        .bundle()
        .pipe(source("StockInfo.js"))
        .pipe(gulp.dest("Orchard.Web/Modules/DemoModule/Scripts"))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(rename({
            suffix: ".min"
        }))
        .pipe(gulp.dest("Orchard.Web/Modules/DemoModule/Scripts"));
});

/*
**
** Wizard component
**
**
*/

gulp.task("DemoModule.Wizard", function ()
{
    return browserify("Orchard.Web/Modules/DemoModule/Assets/Wizard/Wizard.ts")
        .transform(scssify)
        .plugin(tsify, {
            target: "es5",
            module: "commonjs",
            moduleResolution: "node",
            sourceMap: true,
            emitDecoratorMetadata: true,
            experimentalDecorators: true,
            lib: ["es2015", "dom"],
            noImplicitAny: true
        })
        .bundle()
        .pipe(source("Wizard.js"))
        .pipe(gulp.dest("Orchard.Web/Modules/DemoModule/Scripts"))
        .pipe(buffer())
        .pipe(uglify())
        .pipe(rename({
            suffix: ".min"
        }))
        .pipe(gulp.dest("Orchard.Web/Modules/DemoModule/Scripts"));
});
```
