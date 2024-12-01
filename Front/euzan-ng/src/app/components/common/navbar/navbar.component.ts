import { Component, OnInit, HostListener } from "@angular/core";
import { ViewportScroller } from "@angular/common";

import { Role } from "src/app/interfaces/role";
import Swal from "sweetalert2";
import { SessionService } from "src/app/services/session.service";
import { Router } from "@angular/router";

@Component({
    selector: "app-navbar",
    templateUrl: "./navbar.component.html",
    styleUrls: ["./navbar.component.scss"],
})
export class NavbarComponent implements OnInit {
    unregistered = false;
    logo: string = "assets/img/Club Creativo Logo Blanco.png";
    isAdmin: boolean = false;
    isCliente: boolean = false;
    isEmprendedor: boolean = false;
    isRepartidor: boolean = false;
    constructor(
        private viewportScroller: ViewportScroller,
        private sessionService: SessionService,
        private router: Router
    ) {
        this.sessionService.getSessionChanges().subscribe(() => {
            this.isCliente = this.sessionService.hasRole("CLIENTE");
            this.isAdmin = this.sessionService.hasRole("ADMIN");
            this.isEmprendedor = this.sessionService.hasRole("EMPRENDIMIENTO");
            this.isRepartidor = this.sessionService.hasRole("REPARTIDOR");
            this.unregistered = !this.sessionService.isAuthenticated();
        });
    }
    public onClick(mainpage: string, elementId: string): void {
        const currentPath = window.location.pathname;
        if (currentPath != mainpage) {
            this.redirigir(mainpage);
        }
        this.viewportScroller.scrollToAnchor(elementId);
    }

    ngOnInit() {}

    classApplied = false;
    toggleClass() {
        this.classApplied = !this.classApplied;
    }

    volverCuenta() {
        Swal.fire({
            title: "¿Quieres cambiar a tu cuenta de Cliente?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Cambiar de cuenta!",
        }).then((result) => {
            if (result.isConfirmed) {
                this.redirigir("/dashboard-cliente");
            }
        });
    }

    logOut() {
        Swal.fire({
            title: "¿Quieres salir de tu cuenta en Club Creativo?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Salir",
        }).then((result) => {
            if (result.isConfirmed) {
                this.sessionService.logout();
                this.redirigir("/inicio");
            }
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    // Navbar Sticky
    isSticky: boolean = false;
    @HostListener("window:scroll", ["$event"])
    checkScroll() {
        const scrollPosition =
            window.pageYOffset ||
            document.documentElement.scrollTop ||
            document.body.scrollTop ||
            0;
        if (scrollPosition >= 50) {
            this.isSticky = true;
        } else {
            this.isSticky = false;
        }
    }
}
