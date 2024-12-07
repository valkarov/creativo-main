import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { UsersInterface } from "../interfaces/cliente";
import { ConexionService } from "./conexion.service";
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class UsersService extends ConexionService<UsersInterface> {
    getResourceURL(): string {
        return "/Users";
    }
    getHomePage(): string {
        return "cliente-perfil";
    }
    getNombre(): string {
        return "Cliente";
    }
    login(username, password): Observable<any> {
        return this.httpClient.post("https://localhost:44301/api/Users/Login", {
            Username: username,
            Password: password,
        });
    }

    ingresarGoogle(email): Observable<any> {
        return this.httpClient.post(
            "https://localhost:44301/api/Users/Google",
            {
                email: email,
            }
        );
    }

    changePassword(password: string): Observable<any> {
        return this.httpClient.post("https://localhost:44301/api/Users/Pass", {
            password: password,
        });
    }
    getSession(sessionId): Observable<any> {
        return this.httpClient.post(
            "https://localhost:44301/api/Users/Login/Session",
            {
                session: sessionId,
            }
        );
    }
    constructor(
        protected override httpClient: HttpClient,
        protected override route: Router
    ) {
        super(httpClient, route);
    }
}
