import { Component } from "@angular/core";
import { Order } from "../interfaces/ordenes";
import { OrdenesService } from "../services/ordenes.service";
import { Router } from "@angular/router";
import Swal from "sweetalert2";

@Component({
    selector: "app-ordenes",
    templateUrl: "./ordenes.component.html",
    styleUrl: "./ordenes.component.scss",
})
export class OrdenesComponent {
    ordenes: Order[] = [];

    constructor(private service: OrdenesService, private router: Router) {
        service.getList().subscribe((data) => {
            this.ordenes = data;
        });
    }
    cancelarOrden(id: number) {
        this.service.cancelarOrden(id).subscribe(() => {
            this.ordenes = this.ordenes.filter((orden) => orden.Id !== id);
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

    redirigir(url: string) {
        this.router.navigate([url]);
    }
}
