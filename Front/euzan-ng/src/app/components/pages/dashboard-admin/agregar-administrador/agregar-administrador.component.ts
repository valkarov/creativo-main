import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Administrador } from "src/app/interfaces/administrador";
import { AdministradorService } from "src/app/services/administrador.service";
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
        private service: AdministradorService,
        private route: Router,
        private rou: ActivatedRoute,
        private cookieService: CookieService
    ) {
        const currentUrl = this.route.url;
        if (currentUrl.includes("editar")) {
            this.editMode = true;

            const user = this.cookieService.get("cookieADMIN");
            // this.service.get("User", user).subscribe({
            //     next: (data) => {
            //         this.objeto = data;
            //     },
            //     error: (err) => {
            //         console.log(err);
            //     },
            // });
        }
    }

    confirm = "";

    guardar() {
        if (this.editMode) {
            Swal.fire({
                title: "¿Quieres modificar tu cuenta?",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Aceptar",
            }).then((result) => {
                if (result.isConfirmed) {
                    if (this.confirm === this.objeto.Password) {
                        this.service
                            .update(this.objeto.IdAdmin, this.objeto)
                            .subscribe({
                                next: (data) => {
                                    this.service.successMessage(
                                        "Guardado Exitosamente",
                                        "/editar-administrador"
                                    );
                                },
                                error: (err) => {
                                    console.log(err);
                                    this.service.errorMessage(
                                        err.error.Message
                                    );
                                },
                            });
                    } else {
                        this.service.errorMessage(
                            "Las contraseñas no coinciden"
                        );
                    }
                }
            });
        } else {
            Swal.fire({
                title: "¿Quieres añadir este Administrador?",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Aceptar",
            }).then((result) => {
                if (result.isConfirmed) {
                    if (this.confirm === this.objeto.Password) {
                        this.service.add(this.objeto).subscribe({
                            next: (data) => {
                                this.service.successMessage(
                                    "Guardado Exitosamente",
                                    "/dashboard-admin"
                                );
                            },
                            error: (err) => {
                                console.log(err);
                                this.service.errorMessage(err.error.Message);
                            },
                        });
                    } else {
                        this.service.errorMessage(
                            "Las contraseñas no coinciden"
                        );
                    }
                }
            });
        }
    }

    redirigir(url: string) {
        Swal.fire({
            title: "¿Quieres dejar de editar?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Salir",
        }).then((result) => {
            if (result.isConfirmed) {
                window.location.href = url;
            }
        });
    }
}
