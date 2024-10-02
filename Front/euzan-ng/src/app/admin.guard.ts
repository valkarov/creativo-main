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

    canActivate(): boolean {
        const isAdmin = this.sessionService.isAdmin();
        this.redirect(isAdmin);
        return isAdmin;
    }
}
