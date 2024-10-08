import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { Observable } from "rxjs";
import { CookieService } from "ngx-cookie-service";
import { SessionService } from "./services/session.service";

@Injectable({
    providedIn: "root",
})
export class adminGuard implements CanActivate {
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
        const isAdmin = await this.sessionService.hasRole("ADMIN");
        this.redirect(isAdmin);
        return isAdmin;
    }
}
