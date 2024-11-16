import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { InventoryItemsInterface } from "src/app/interfaces/ordenes";
import { InventarioService } from "src/app/services/Inventario.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-inventario",
    templateUrl: "./gestion-inventario.component.html",
    styleUrl: "./gestion-inventario.component.scss",
})
export class GestionInventarioComponent {
    inventoryItems: InventoryItemsInterface[] = [];
    showEdit: boolean = false;
    objeto: InventoryItemsInterface = {
        Id: 0,
        Name: "",
        Quantity: 0,
    };

    constructor(private service: InventarioService, private router: Router) {
        this.service.getList().subscribe({
            next: (data) => {
                this.inventoryItems = data;
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    reload() {
        this.service.getList().subscribe({
            next: (data) => {
                this.inventoryItems = data;
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    eliminar(objeto: InventoryItemsInterface) {
        this.service.delete(objeto.Id).subscribe({
            next: (data) => {
                Swal.fire("Exito", "Se ha eliminado el registro", "success");
                this.reload();
            },
            error: (err) => {
                Swal.fire("Error", "Ha ocurrido un error", "error");
            },
        });
    }

    editar(objeto: InventoryItemsInterface) {
        this.service.update(objeto.Id, objeto).subscribe({
            next: (data) => {
                Swal.fire("Exito", "Se ha editado el registro", "success");
                this.inventoryItems = this.inventoryItems.map((item) =>
                    item.Id === this.objeto.Id ? this.objeto : item
                );
                this.objeto = {
                    Id: 0,
                    Name: "",
                    Quantity: 0,
                };
                this.showEdit = false;
                /*this.objeto = new InventoryItemsInterface();*/
            },
            error: (err) => {
                Swal.fire("Error", "Ha ocurrido un error", "error");
            },
        });
    }
    changeShowEdit() {
        this.showEdit = !this.showEdit;
    }
    add() {
        this.service.add(this.objeto).subscribe({
            next: (data) => {
                Swal.fire("Exito", "Se ha agregado el registro", "success");
                this.reload();
                this.objeto = {
                    Id: 0,
                    Name: "",
                    Quantity: 0,
                };
                this.showEdit = false;
                /*this.objeto = new InventoryItemsInterface();*/
            },
            error: (err) => {
                Swal.fire("Error", "Ha ocurrido un error", "error");
            },
        });
    }
}
