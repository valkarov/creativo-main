import { ViewportScroller } from "@angular/common";
import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: "app-sobre-nosotros-banner",
    templateUrl: "./sobre-nosotros-banner.component.html",
    styleUrl: "./sobre-nosotros-banner.component.scss",
})
export class SobreNosotrosBannerComponent {
    constructor(
        private viewportScroller: ViewportScroller,
        private router: Router
    ) {}

    public onClick(mainpage: string, elementId: string): void {
        const currentPath = window.location.pathname;
        if (currentPath != mainpage) {
            this.redirigir(mainpage);
        }
        this.viewportScroller.scrollToAnchor(elementId);
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }
}
