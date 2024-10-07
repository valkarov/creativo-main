import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Taller } from "src/app/interfaces/talleres";
import { TalleresService } from "src/app/services/talleres.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-talleres",
    templateUrl: "./gestion-talleres.component.html",
    styleUrl: "./gestion-talleres.component.scss",
})
export class GestionTalleresComponent {
    talleres: Taller[] = [];
    entrepeneurshipId: number = 0;
    nuevotallerUrl = "/nuevo-taller";
    constructor(
        private service: TalleresService,
        private router: Router,
        private rou: ActivatedRoute
    ) {
        this.entrepeneurshipId = this.rou.snapshot.params["entrepeneurshipId"];
        this.nuevotallerUrl = "/nuevo-taller/" + this.entrepeneurshipId;
        this.service
            .getSelectedList("byEntre" + "/" + this.entrepeneurshipId)
            .subscribe({
                next: (data) => {
                    this.talleres = data;
                    console.log(this.talleres);
                },
                error: (err) => {
                    console.log(err);
                },
            });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    eliminarTaller(id: number) {
        Swal.fire({
            title: "¿Quieres eliminar este Taller?",
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
                            "El taller se ha eliminado con éxito",
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
