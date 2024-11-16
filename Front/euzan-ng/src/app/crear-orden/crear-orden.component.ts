import { ChangeDetectorRef, Component } from "@angular/core";
import { OrdenesService } from "../services/ordenes.service";
import { InventarioService } from "../services/Inventario.service";
import {
    CantonService,
    DistritoService,
    ProvinciaService,
} from "../services/lugares.service";
import { EmprendimientoService } from "../services/emprendimiento.service";
import {
    InventoryItemsInterface,
    Order,
    OrderProduct,
} from "../interfaces/ordenes";
import { EmprendimientoInterface } from "../interfaces/emprendimiento";
import {
    CantonInterface,
    DistritoInterface,
    ProvinciaInterface,
} from "../interfaces/lugares";
import { Router } from "@angular/router";
import Swal from "sweetalert2";

@Component({
    selector: "app-crear-orden",
    templateUrl: "./crear-orden.component.html",
    styleUrl: "./crear-orden.component.scss",
})
export class CrearOrdenComponent {
    provincias: ProvinciaInterface[] = [];
    cantones: CantonInterface[] = [];
    distritos: DistritoInterface[] = [];
    emprendimientos: EmprendimientoInterface[] = [];
    inventario: InventoryItemsInterface[] = [];
    nuevoProducto: Partial<InventoryItemsInterface> = {
        Id: 0,
        Quantity: 0,
    };
    provincia: string = "";
    canton: string = "";
    orden: Order = {
        Id: 0,
        Phone: "",
        Email: "",
        Address: "",
        CityId: 0,
        City: "",
        entrepeneurship: "",
        EntrepeneurshipId: 0,
        //TODO: Cambiar a "Pendiente" cuando se implemente la funcionalidad
        Status: "Entregado",
        Date: new Date(),
        DeliveryDate: new Date(),
        OrderProducts: [],
    };

    constructor(
        private ordenesService: OrdenesService,
        private inventoryService: InventarioService,
        private provinciaService: ProvinciaService,
        private cantonService: CantonService,
        private distritoService: DistritoService,
        private emprendimientosService: EmprendimientoService,
        private router: Router,
        private changeDetectorRef: ChangeDetectorRef
    ) {
        this.provinciaService.getList().subscribe((data) => {
            this.provincias = data;
        });
        this.inventoryService.getList().subscribe((data) => {
            this.inventario = data;
        });
        this.emprendimientosService.getList().subscribe((data) => {
            this.emprendimientos = data;
        });
    }

    getCantones() {
        this.cantonService.getSelectedList(this.provincia).subscribe({
            next: (data) => {
                this.cantones = data;
            },
        });
    }

    getDistritos() {
        this.distritoService.getSelectedList(this.canton).subscribe({
            next: (data) => {
                this.distritos = data;
            },
        });
    }

    getProvincias() {
        this.provinciaService.getList().subscribe((data) => {});
    }

    eliminarProducto(product: OrderProduct) {
        console.log(product);
        let newProducts = [...this.orden.OrderProducts].filter(
            (producto) => producto.ProductId != product.ProductId
        );
        this.orden = { ...this.orden, OrderProducts: newProducts };
    }
    agregarProducto() {
        this.orden.OrderProducts.push({
            ProductId: this.nuevoProducto.Id,
            Product: this.inventario.find(
                (producto) => producto.Id == this.nuevoProducto.Id
            ).Name,
            Quantity: this.nuevoProducto.Quantity,
        });
        this.nuevoProducto = {
            Id: 0,
            Quantity: 0,
        };
    }

    submit() {
        this.ordenesService.add(this.orden).subscribe({
            next: () => {
                this.router.navigate(["/ordenes"]);
            },
            error: (err) => {
                Swal.fire({
                    title: "Error",
                    text: "Ocurrió un error al crear la orden",
                    icon: "error",
                    confirmButtonText: "Cerrar",
                });
            },
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    selected() {
        this.getCantones();
        this.canton = "";
        this.orden.City = "";
    }

    selectedcant() {
        this.getDistritos();
        this.orden.City = "";
    }

    formatoNumeros(event, cantidad) {
        const input = event.target.value;
        const formatted = input.replace(/[^0-9-]/g, "").slice(0, cantidad);
        event.target.value = formatted;
    }
}
