import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Observable } from "rxjs";
import { CookieService } from "ngx-cookie-service";
import { SessionService } from "./services/session.service";

@Injectable({
    providedIn: "root",
})
export class clienteGuard implements CanActivate {
    constructor(
        private sessionService: SessionService,
        private router: Router
    ) {}

    redirect(flag: boolean): any {
        if (!flag) {
            this.router.navigate(["/", "ingresar"]);
        }
    }

    async canActivate(): Promise<boolean> {
        const isCliente = await this.sessionService.hasRole("CLIENTE");
        this.redirect(isCliente);
        return isCliente;
    }
}
