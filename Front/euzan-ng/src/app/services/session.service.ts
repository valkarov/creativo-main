import { Injectable } from "@angular/core";
import { UsersService } from "./cliente.service";
import { CookieService } from "ngx-cookie-service";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class SessionService {
    private userSubject = new BehaviorSubject<any>(null);
    private sessionKey = "sessionUser";
    private user: any;

    get userChanges() {
        return this.userSubject.asObservable();
    }

    private setUser(user: any) {
        this.user = user;
        console.log(user);
        this.userSubject.next(user);
    }
    constructor(
        private userService: UsersService,
        private cookieService: CookieService
    ) {
        this.getUserData();
    }
    // Load session data from local storage
    loadSession(): any {
        const sessionData = localStorage.getItem(this.sessionKey);
        return sessionData ? JSON.parse(sessionData) : null;
    }

    // Save session data to local storage
    saveSession(data: any): void {
        this.cookieService.set("XSRF-TOKEN", data.Password);
        localStorage.setItem(this.sessionKey, JSON.stringify(data));
        localStorage.setItem("session", data.Password);
    }

    // Clear session data from local storage
    clearSession(): void {
        localStorage.removeItem(this.sessionKey);
        this.cookieService.delete("XSRF-TOKEN");
        this.setUser(null);
    }
    getSession(): any {
        return this.user;
    }
    isAdmin(): boolean {
        return this.user.UserRoles.some(
            (userRole) => userRole.Role.Name === "ADMIN"
        );
    }
    isCliente(): boolean {
        return this.user.UserRoles.some(
            (userRole) => userRole.Role.Name === "CLIENTE"
        );
    }
    isRepartidor(): boolean {
        return this.user.UserRoles.some(
            (userRole) => userRole.Role.Name === "REPARTIDOR"
        );
    }
    isEmprendimiento(): boolean {
        return this.user.UserRoles.some(
            (userRole) => userRole.Role.Name === "EMPRENDIMIENTO"
        );
    }
    isLoggedIn(): boolean {
        return !!this.user ? true : false;
    }
    // Get basic user data from session
    async getUserData(): Promise<any> {
        const session = this.loadSession();
        if (session) {
            this.setUser(session);
            this.userService.getSession(session.Password).subscribe({
                next: (data) => {
                    this.setUser(data);
                    this.cookieService.set("XSRF-TOKEN", data.Password);
                },
                error: () => {
                    this.clearSession();
                    //TODO: go to login
                },
            });
        }

        return session ? session.userData : null;
    }
}
