import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { SessionService } from "../services/session.service";

@Injectable({
    providedIn: "root",
})
export class combinedGuard implements CanActivate {
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
        const isLoggedIn = await this.sessionService.isAuthenticated();
        this.redirect(isLoggedIn);
        return isLoggedIn;
    }
}
