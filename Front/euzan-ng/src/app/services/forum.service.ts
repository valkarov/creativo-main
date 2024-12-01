import { Injectable } from "@angular/core";
import { InventoryItemsInterface } from "../interfaces/ordenes";
import { ConexionService } from "./conexion.service";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Forum } from "../interfaces/forum";

@Injectable({
    providedIn: "root",
})
export class ForumService extends ConexionService<Forum> {
    getResourceURL(): string {
        return "/forum";
    }
    getHomePage(): string {
        return "";
    }
    getNombre(): string {
        return "";
    }
    crearComentario(id: number, comentario: string) {
        return this.httpClient.post(`${this.getRuta()}/${id}/comment`, {
            comment: comentario,
        });
    }
    deleteComment(id: number) {
        return this.httpClient.delete(`${this.getRuta()}/comment/${id}`);
    }
    constructor(
        protected override httpClient: HttpClient,
        protected override route: Router
    ) {
        super(httpClient, route);
    }
}
