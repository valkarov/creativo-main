import { Component } from "@angular/core";
import Swal from "sweetalert2";
import { Order } from "../interfaces/ordenes";
import { OrdenesService } from "../services/ordenes.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: "app-ver-ordenes-emprendedor",
    templateUrl: "./ver-ordenes-emprendedor.component.html",
    styleUrl: "./ver-ordenes-emprendedor.component.scss",
})
export class VerOrdenesEmprendedorComponent {
    ordenes: Order[] = [];

    constructor(
        private service: OrdenesService,
        private router: Router,
        private route: ActivatedRoute
    ) {
        service
            .getByEntrepeneur(route.snapshot.params.entrepeneurshipId)
            .subscribe((data) => {
                this.ordenes = data;
            });
    }
    reload() {
        this.service
            .getByEntrepeneur(this.route.snapshot.params.entrepeneurshipId)
            .subscribe((data) => {
                this.ordenes = data;
            });
    }

    verProductos(Order: Order) {
        Swal.fire({
            title: `Productos de la orden ${Order.Id}`,
            html: `<ul style="list-style-type: none;"> 
                        ${Order.OrderProducts.map(
                            (producto) =>
                                `<li>${producto.Product} : ${producto.Quantity}</li>`
                        ).join("")}
                    </ul>`,
            confirmButtonText: "Cerrar",
        });
    }
    devolverOrdenConfirm(Order: Order) {
        this.service
            .changeStatus(Order.Id, "Listo Para Devolucion")
            .subscribe(() => {
                this.reload();
            });
    }
    redirigir(url: string) {
        this.router.navigate([url]);
    }
}
