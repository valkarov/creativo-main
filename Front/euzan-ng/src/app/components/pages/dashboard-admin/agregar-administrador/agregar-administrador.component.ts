import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Administrador } from "src/app/interfaces/administrador";
import { AdministradorService } from "src/app/services/administrador.service";
import { UsersService } from "src/app/services/cliente.service";
import { SessionService } from "src/app/services/session.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-agregar-administrador",
    templateUrl: "./agregar-administrador.component.html",
    styleUrl: "./agregar-administrador.component.scss",
})
export class AgregarAdministradorComponent {
    objeto: Administrador = new Administrador();
    editMode: boolean = false;
    constructor(
        private service: UsersService,
        private route: Router,
        private sessionService: SessionService
    ) {
        const currentUrl = this.route.url;
        if (currentUrl.includes("editar")) {
            this.editMode = true;

            this.sessionService.userChanges.subscribe({
                next: (data) => {
                    this.service.get("User", data.Id);
                },
                error: (err) => {
                    console.log(err);
                },
            });
        } else {
            this.editMode = false;
        }
    }
}
