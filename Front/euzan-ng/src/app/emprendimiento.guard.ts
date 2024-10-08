import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { SessionService } from "./services/session.service";

@Injectable({
    providedIn: "root",
})
export class emprendimientoGuard implements CanActivate {
    constructor(
        private sessionService: SessionService,
        private router: Router
    ) {}

    redirect(flag: boolean): any {
        if (!flag) {
            this.router.navigate(["/", "dashboard-cliente"]);
        }
    }

    async canActivate(): Promise<boolean> {
        const isEmprendimiento = await this.sessionService.hasRole(
            "EMPRENDIMIENTO"
        );
        this.redirect(isEmprendimiento);
        return isEmprendimiento;
    }
}
