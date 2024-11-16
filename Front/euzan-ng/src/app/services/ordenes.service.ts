import { Injectable } from "@angular/core";
import { Order } from "../interfaces/ordenes";
import { ConexionService } from "./conexion.service";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Injectable({
    providedIn: "root",
})
export class OrdenesService extends ConexionService<Order> {
    getResourceURL(): string {
        return "/ordenes";
    }
    getHomePage(): string {
        return "";
    }
    getNombre(): string {
        return "";
    }
    getByEntrepeneur(id: number) {
        return this.httpClient.get<Order[]>(
            `${this.getRuta()}/byEntrepeneurship/${id}`
        );
    }
    cancelarOrden(id: number) {
        return this.httpClient.delete(`${this.getRuta()}/${id}`);
    }
    changeStatus(id: number, status: string) {
        return this.httpClient.put(`${this.getRuta()}/${id}/status/${status}`, {
            status,
        });
    }
    constructor(
        protected override httpClient: HttpClient,
        protected override route: Router
    ) {
        super(httpClient, route);
    }
}
