import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { SessionService } from "./services/session.service";

@Injectable({
    providedIn: "root",
})
export class repartidorGuard implements CanActivate {
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
        const isRepartidor = this.sessionService.hasRole("REPARTIDOR");
        this.redirect(isRepartidor);
        return isRepartidor;
    }
}
