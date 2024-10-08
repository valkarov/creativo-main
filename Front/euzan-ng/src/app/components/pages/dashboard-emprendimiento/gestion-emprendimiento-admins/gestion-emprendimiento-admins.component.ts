import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { EmprendimientoAdmin } from "src/app/interfaces/emprendimiento";
import { EmprendimientoAdminService } from "src/app/services/emprendimiento.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-emprendimiento-admins",
    templateUrl: "./gestion-emprendimiento-admins.component.html",
    styleUrl: "./gestion-emprendimiento-admins.component.scss",
})
export class GestionEmprendimientoAdminsComponent {
    admins: EmprendimientoAdmin[] = [];
    admin: EmprendimientoAdmin = new EmprendimientoAdmin();
    adminNuevo: string = "";
    entrepeneurshipId: string = "";
    constructor(
        private service: EmprendimientoAdminService,
        private cookieService: CookieService,
        private rou: ActivatedRoute,
        private router: Router
    ) {
        this.rou.params.subscribe({
            next: (data) => {
                this.entrepeneurshipId = data.id;
                this.service
                    .getSelectedList("byEntre" + "/" + data.id)
                    .subscribe({
                        next: (data) => {
                            this.admins = data;
                        },
                        error: (err) => {
                            console.log(err);
                        },
                    });
            },
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    enviarSolicitud() {
        Swal.fire({
            title: "¿Quieres enviar la solicitud de administración para este emprendimiento?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Enviar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.admin.IdClient = this.adminNuevo;
                this.admin.IdEntrepreneurship = this.cookieService.get(
                    "cookieEMPRENDIMIENTO"
                );
                this.admin.state = "Pendiente";
                console.log(this.admin);
                this.admin.IdEntrepreneurship = this.entrepeneurshipId;
                this.service.add(this.admin).subscribe({
                    next: (data) => {
                        this.service.successMessage(
                            "Solucitud Enviada",
                            "/dashboard-emprendimiento"
                        );
                    },
                    error: (err) => {
                        this.service.errorMessage(err.error.Message);
                    },
                });
            }
        });
    }

    quitarAcceso(user: string) {
        Swal.fire({
            title: "¿Quieres remover a este usuario de la administración para este emprendimiento?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Quitar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.admin.IdClient = user;
                this.admin.IdEntrepreneurship = this.cookieService.get(
                    "cookieEMPRENDIMIENTO"
                );
                this.admin.state = "Rechazado";
                console.log(this.admin);
                this.service
                    .update(this.admin.IdEntrepreneurship, this.admin)
                    .subscribe({
                        next: (data) => {
                            this.service.successMessage(
                                "Administrador Removido",
                                "/dashboard-emprendimiento"
                            );
                        },
                        error: (err) => {
                            this.service.errorMessage(err.error.Message);
                        },
                    });
            }
        });
    }

    ReenviarSolicitud(user: string) {
        Swal.fire({
            title: "¿Quieres reenviar la solicitud de administración para este emprendimiento?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Reenviar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.admin.IdClient = user;
                this.admin.IdEntrepreneurship = this.cookieService.get(
                    "cookieEMPRENDIMIENTO"
                );
                this.admin.state = "Pendiente";
                console.log(this.admin);
                this.service
                    .update(this.admin.IdEntrepreneurship, this.admin)
                    .subscribe({
                        next: (data) => {
                            this.service.successMessage(
                                "Solucitud Reenviada",
                                "/dashboard-emprendimiento"
                            );
                        },
                        error: (err) => {
                            this.service.errorMessage(err.error.Message);
                        },
                    });
            }
        });
    }
}
