import "core-js";
import "zone.js";

import { Component } from "@angular/core";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";

import { StepOne } from "./StepOne";
import { StepTwo } from "./StepTwo";

import "./Wizard.scss"; // Comment out if building for runtime module loading!

@Component({
    selector: "wizard",
    template: `
        <div class="wizard">
            <nav>
                <a routerLink="/step1">Step 1</a>
                <a routerLink="/step2">Step 2</a>
            </nav>
            <router-outlet></router-outlet>
        </div>`
})
export class Wizard { }

@NgModule({
    imports: [
        BrowserModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "/step1", pathMatch: "full" },
            { path: "step1", component: StepOne },
            { path: "step2", component: StepTwo }
        ])
    ],
    declarations: [
        Wizard,
        StepOne,
        StepTwo
    ],
    bootstrap: [Wizard]
})
export class WizardModule { }

platformBrowserDynamic().bootstrapModule(WizardModule);