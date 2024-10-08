import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Taller } from "src/app/interfaces/talleres";
import { TalleresService } from "src/app/services/talleres.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-agregar-taller",
    templateUrl: "./agregar-taller.component.html",
    styleUrl: "./agregar-taller.component.scss",
})
export class AgregarTallerComponent {
    objeto: Taller = new Taller();
    editMode: boolean = true;

    constructor(
        private service: TalleresService,
        private route: Router,
        private rou: ActivatedRoute
    ) {
        if (this.rou.snapshot.params["id"] == undefined) {
            this.objeto.IdEntrepreneurship = parseInt(
                this.rou.snapshot.params["entrepeneurshipId"]
            );
            this.editMode = false;
        } else {
            // this.objeto.IdEntrepreneurship =
            //     this.rou.snapshot.params["entrepeneurshipId"];
            this.service.get(this.rou.snapshot.params["id"]).subscribe({
                next: (data) => {
                    this.objeto = data;
                },
                error: (err) => {
                    console.log(err);
                },
            });
        }
    }

    redirigir(url: string) {
        Swal.fire({
            title: "¿Quieres dejar de editar?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Salir",
        }).then((result) => {
            if (result.isConfirmed) {
                this.route.navigate([url]);
            }
        });
    }

    guardar() {
        Swal.fire({
            title: "¿Quieres añadir este Taller?",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Aceptar",
        }).then((result) => {
            if (result.isConfirmed) {
                console.log(this.objeto);
                if (this.editMode) {
                    this.service
                        .update(this.objeto.IdWorkshop, this.objeto)
                        .subscribe({
                            next: (data) => {
                                this.service.successMessage(
                                    "Taller correctamente modificado",
                                    "/dashboard-emprendimiento"
                                );
                            },
                            error: (err) => {
                                this.service.errorMessage(err.error.Message);
                            },
                        });
                } else {
                    this.objeto.IdEntrepreneurship =
                        this.rou.snapshot.params["entrepeneurshipId"];
                    this.objeto.IdWorkshop = 1;
                    this.service.add(this.objeto).subscribe({
                        next: (data) => {
                            this.service.successMessage(
                                "Taller correctamente añadido",
                                "/dashboard-emprendimiento"
                            );
                        },
                        error: (err) => {
                            console.log(err);
                            this.service.errorMessage(err.error.Message);
                        },
                    });
                }
            }
        });
    }
}
