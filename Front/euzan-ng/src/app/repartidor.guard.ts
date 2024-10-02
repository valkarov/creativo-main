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

    canActivate(): boolean {
        const isRepartidor = this.sessionService.isRepartidor();
        this.redirect(isRepartidor);
        return isRepartidor;
    }
}
