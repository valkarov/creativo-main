import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { Administrador } from "src/app/interfaces/administrador";
import { AdministradorService } from "src/app/services/administrador.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-administradores",
    templateUrl: "./gestion-administradores.component.html",
    styleUrl: "./gestion-administradores.component.scss",
})
export class GestionAdministradoresComponent {
    admins: Administrador[] = [];
    objeto: Administrador = new Administrador();

    constructor(private service: AdministradorService, private router: Router) {
        this.service.getList().subscribe({
            next: (data) => {
                this.admins = data;
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    eliminarAdministrador(id: number) {
        Swal.fire({
            title: "¿Quieres eliminar este Administrador?",
            text: "¡No lo vas a poder revertir!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Eliminar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.service.delete(id).subscribe({
                    next: (data) => {
                        this.service.successMessage(
                            "El administrador se ha eliminado correctamente",
                            "/dashboard-admin"
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
