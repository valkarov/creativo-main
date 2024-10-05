import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})
export class SessionService {
    private tokenKey = "authToken";
    private rolesKey = "userRoles";
    private sessionSubject = new BehaviorSubject<boolean>(
        this.isAuthenticated()
    );

    constructor(private router: Router) {}

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
