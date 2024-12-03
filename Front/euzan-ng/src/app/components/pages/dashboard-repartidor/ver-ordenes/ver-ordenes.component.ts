import { Component } from "@angular/core";
import { DomSanitizer, SafeResourceUrl } from "@angular/platform-browser";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Emprendimiento } from "src/app/interfaces/emprendimiento";
import { Order } from "src/app/interfaces/ordenes";
import { OrdenesService } from "src/app/services/ordenes.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-ver-ordenes",
    templateUrl: "./ver-ordenes.component.html",
    styleUrl: "./ver-ordenes.component.scss",
})
export class VerOrdenesComponent {
    ordenes: Order[] = [];
    constructor(
        private service: OrdenesService,
        private cookieService: CookieService,
        private router: Router,
        private sanitizer: DomSanitizer
    ) {
        this.service.getSelectedList("byDelivery").subscribe({
            next: (data) => {
                this.ordenes = data;
                console.log(this.ordenes);
            },
            error: (err) => {
                console.log(err);
            },
        });
    }
    reload() {
        this.service.getSelectedList("byDelivery").subscribe({
            next: (data) => {
                this.ordenes = data;
                console.log(this.ordenes);
            },
            error: (err) => {
                console.log(err);
            },
        });
    }
    redirigir(url: string) {
        this.router.navigate([url]);
    }

    iniciarEnvio(obj: Order) {
        Swal.fire({
            title: "¿Quieres empezar con esta entrega?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Aceptar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.service.changeStatus(obj.Id, "En camino").subscribe(() => {
                    this.reload();
                });
            }
        });
    }
    getMapUrl(obj: Order): SafeResourceUrl {
        const address = encodeURIComponent(`${obj.Address} ${obj.City}`);
        const url = `https://maps.google.com/maps?width=100%25&height=200&hl=en&q=${address}&t=&z=14&ie=UTF8&iwloc=B&output=embed`;
        return this.sanitizer.bypassSecurityTrustResourceUrl(url);
    }
    terminarEntrega(obj: Order) {
        Swal.fire({
            title: "¿Quieres terminar con esta entrega?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Aceptar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.service.changeStatus(obj.Id, "Entregado").subscribe(() => {
                    this.reload();
                });
            }
        });
    }
    GestionarDevolucion(obj: Order) {
        Swal.fire({
            title: "¿Quieres terminar con esta entrega?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Aceptar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.service.changeStatus(obj.Id, "Devuelto").subscribe(() => {
                    this.reload();
                });
            }
        });
    }
}
