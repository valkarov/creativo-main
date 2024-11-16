import { Injectable } from "@angular/core";
import { InventoryItemsInterface } from "../interfaces/ordenes";
import { ConexionService } from "./conexion.service";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable({
    providedIn: "root",
})
export class InventarioService extends ConexionService<InventoryItemsInterface> {
    getResourceURL(): string {
        return "/Inventory";
    }
    getHomePage(): string {
        return "";
    }
    getNombre(): string {
        return "";
    }

    constructor(
        protected override httpClient: HttpClient,
        protected override route: Router
    ) {
        super(httpClient, route);
    }
}
