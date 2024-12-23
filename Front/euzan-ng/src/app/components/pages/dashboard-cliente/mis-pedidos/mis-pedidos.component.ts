import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Order } from "src/app/interfaces/ordenes";
import { OrdenesService } from "src/app/services/ordenes.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-mis-pedidos",
    templateUrl: "./mis-pedidos.component.html",
    styleUrl: "./mis-pedidos.component.scss",
})
export class MisPedidosComponent {
    ordenes: Order[] = [];
    objeto: Order;

    constructor(
        private service: OrdenesService,
        private cookieService: CookieService,
        private router: Router
    ) {
        this.service
            .getSelectedList(
                "byClient" + "/" + this.cookieService.get("cookieCLIENTE")
            )
            .subscribe({
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

    // iniciarOrden(obj: Order) {
    //     Swal.fire({
    //         title: "¿Quieres empezar con esta entrega?",
    //         showCancelButton: true,
    //         confirmButtonColor: "#3085d6",
    //         cancelButtonColor: "#d33",
    //         confirmButtonText: "Aceptar",
    //     }).then((result) => {
    //         if (result.isConfirmed) {
    //             this.objeto = obj;
    //             this.objeto.State = "En Camino";
    //             this.gestionarSolicitud();
    //         }
    //     });
    // }

    // terminarOrden(obj: Order) {
    //     Swal.fire({
    //         title: "¿Quieres terminar con esta entrega?",
    //         showCancelButton: true,
    //         confirmButtonColor: "#3085d6",
    //         cancelButtonColor: "#d33",
    //         confirmButtonText: "Aceptar",
    //     }).then((result) => {
    //         if (result.isConfirmed) {
    //             this.objeto = obj;
    //             this.objeto.State = "Terminada";
    //             this.gestionarSolicitud();
    //         }
    //     });
    // }

    // gestionarSolicitud() {
    //     this.service.update(this.objeto.IdOrder, this.objeto).subscribe({
    //         next: (data) => {
    //             Swal.fire({
    //                 title: this.objeto.State + "!",
    //                 text: "Solicitud Gestionada exitosamente",
    //                 icon: "success",
    //                 didClose: () => {
    //                     window.location.reload();
    //                 },
    //             });
    //         },
    //         error: (err) => {
    //             console.log(err);
    //         },
    //     });
    // }
}
