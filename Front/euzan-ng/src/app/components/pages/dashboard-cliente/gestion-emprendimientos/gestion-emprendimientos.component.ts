import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import {
    Emprendimiento,
    EmprendimientoAdmin,
} from "src/app/interfaces/emprendimiento";
import {
    EmprendimientoAdminService,
    EmprendimientoService,
} from "src/app/services/emprendimiento.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-emprendimientos",
    templateUrl: "./gestion-emprendimientos.component.html",
    styleUrl: "./gestion-emprendimientos.component.scss",
})
export class GestionEmprendimientosComponent {
    emprendimientos: Emprendimiento[] = [];
    admin: EmprendimientoAdmin = new EmprendimientoAdmin();

    constructor(
        private service: EmprendimientoService,
        private EmprendimientoService: EmprendimientoService,
        private cookieService: CookieService,
        private router: Router
    ) {
        this.service.getSelectedList("byClient" + "/").subscribe({
            next: (data) => {
                this.emprendimientos = data;
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    esPendiente(id: number): boolean {
        const emprendimiento = this.emprendimientos.find(
            (emp) => emp.IdEntrepreneurship === id
        );
        return emprendimiento ? emprendimiento.State === "Pendiente" : false;
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    ingresarEmprendimeinto(emprendimiento: Emprendimiento) {
        this.redirigir(
            `/editar-emprendimiento/${emprendimiento.IdEntrepreneurship}`
        );
    }
    goAdministradores(emprendimiento: Emprendimiento) {
        this.redirigir(
            `/emprendimiento-admins/${emprendimiento.IdEntrepreneurship}`
        );
    }
    goTalleres(emprendimiento: Emprendimiento) {
        this.redirigir(`talleres/${emprendimiento.IdEntrepreneurship}`);
    }
    aceptarSolicitud(user: string) {
        // Swal.fire({
        //     title: "¿Quieres aceptar la solicitud de administración para este emprendimiento?",
        //     icon: "warning",
        //     showCancelButton: true,
        //     confirmButtonColor: "#3085d6",
        //     cancelButtonColor: "#d33",
        //     confirmButtonText: "Aceptar",
        // }).then((result) => {
        //     if (result.isConfirmed) {
        //         this.admin.IdClient = this.cookieService.get("cookieCLIENTE");
        //         this.admin.IdEntrepreneurship = user;
        //         this.admin.state = "Aceptado";
        //         console.log(this.admin);
        //         this.service
        //             .update(this.admin.IdEntrepreneurship, this.admin)
        //             .subscribe({
        //                 next: (data) => {
        //                     this.service.successMessage(
        //                         "Solucitud Aceptada",
        //                         "/mis-emprendimientos"
        //                     );
        //                 },
        //                 error: (err) => {
        //                     this.service.errorMessage(err.error.Message);
        //                 },
        //             });
        //     }
        // });
    }

    rechazarSolicitud(user: string) {
        Swal.fire({
            title: "¿Quieres recahzar la solicitud de administración para este emprendimiento?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Rechazar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.admin.IdClient = this.cookieService.get("cookieCLIENTE");
                this.admin.IdEntrepreneurship = user;
                this.admin.state = "Rechazado";
                // this.service
                //     .update(this.admin.IdEntrepreneurship, this.admin)
                //     .subscribe({
                //         next: (data) => {
                //             this.service.successMessage(
                //                 "Solucitud Rechazada",
                //                 "/mis-emprendimientos"
                //             );
                //         },
                //         error: (err) => {
                //             this.service.errorMessage(err.error.Message);
                //         },
                //     });
            }
        });
    }

    eliminarSolicitud(user: string) {
        Swal.fire({
            title: "¿Quieres eliminar la solicitud de administración para este emprendimiento?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Eliminar",
        }).then((result) => {
            if (result.isConfirmed) {
                // const e = this.infoEmprendimientos.find(
                //     (emprendimiento) => emprendimiento.Username === user
                // );
                // this.EmprendimientoService.delete(
                //     e.IdEntrepreneurship
                // ).subscribe({
                //     next: (data) => {
                //         this.service.successMessage(
                //             "Solicitud Eliminada",
                //             "/mis-emprendimientos"
                //         );
                //     },
                //     error: (err) => {
                //         this.service.errorMessage(err.error.Message);
                //     },
                // });
            }
        });
    }
}
