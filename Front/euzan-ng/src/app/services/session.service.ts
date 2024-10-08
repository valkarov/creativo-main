import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { UsersService } from "./cliente.service";

@Injectable({
    providedIn: "root",
})
export class SessionService {
    private tokenKey = "authToken";
    private rolesKey = "userRoles";
    private sessionSubject = new BehaviorSubject<boolean>(
        this.isAuthenticated()
    );

    constructor(private router: Router, private service: UsersService) {
        const token = this.getToken();
        if (token) {
            this.service.getSession(token).subscribe({
                next: (data) => {
                    console.log("hola");
                    if (!data) {
                        console.log("hola");
                        this.logout();
                    }
                },
                error: (err) => {
                    console.log(err);
                    this.logout();
                },
            });
        }
    }

    login(token: string, roles: string[]): void {
        localStorage.setItem(this.tokenKey, token);
        localStorage.setItem(this.rolesKey, JSON.stringify(roles));
        this.sessionSubject.next(true);
    }

    logout(): void {
        localStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.rolesKey);
        this.sessionSubject.next(false);
        this.router.navigate(["/login"]);
    }

    isAuthenticated(): boolean {
        return !!localStorage.getItem(this.tokenKey);
    }

    getToken(): string | null {
        return localStorage.getItem(this.tokenKey);
    }

    setRoles(roles: string[]): void {
        localStorage.setItem(this.rolesKey, JSON.stringify(roles));
    }

    getRoles(): string[] {
        const roles = localStorage.getItem(this.rolesKey);
        return roles ? JSON.parse(roles) : [];
    }

    hasRole(role: string): boolean {
        const roles = this.getRoles();
        return roles.includes(role);
    }

    getSessionChanges(): Observable<boolean> {
        return this.sessionSubject.asObservable();
    }
}
