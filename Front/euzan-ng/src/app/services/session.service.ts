import { Injectable } from "@angular/core";

@Injectable({
    providedIn: "root",
})
export class SessionService {
    private sessionKey = "userSession";

    private Roles = [];

    constructor() {
        this.getUserData();
    }

    // Load session data from local storage
    loadSession(): any {
        const sessionData = localStorage.getItem(this.sessionKey);
        return sessionData ? JSON.parse(sessionData) : null;
    }

    // Save session data to local storage
    saveSession(data: any): void {
        localStorage.setItem(this.sessionKey, JSON.stringify(data));
    }

    // Clear session data from local storage
    clearSession(): void {
        localStorage.removeItem(this.sessionKey);
    }

    // Get basic user data from session
    getUserData(): any {
        const session = this.loadSession();
        return session ? session.userData : null;
    }
}
