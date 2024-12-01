import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Cliente } from "src/app/interfaces/cliente";
import {
    Taller,
    TallerPago,
    TallerPagoInterface,
} from "src/app/interfaces/talleres";
import { UsersService } from "src/app/services/cliente.service";
import {
    TalleresPagoService,
    TalleresService,
} from "src/app/services/talleres.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-gestion-pagos",
    templateUrl: "./gestion-pagos.component.html",
    styleUrl: "./gestion-pagos.component.scss",
})
export class GestionPagosComponent {
    pagos: TallerPago[] = [];
    pagosPorTaller: TallerPago[][] = [];
    nombresDeTalleres: string[] = [];
    objeto: TallerPago;

    constructor(
        private service: TalleresPagoService,
        private tallerService: TalleresService,
        private clientService: UsersService,
        private router: Router,
        private rou: ActivatedRoute
    ) {
        this.service
            .getSelectedList(
                "byEntre" + "/" + this.rou.snapshot.params["entrepeneurshipId"]
            )
            .subscribe({
                next: (data) => {
                    console.log(data);
                    this.pagos = data.filter(
                        (pago: TallerPagoInterface) =>
                            pago.State === "Pendiente"
                    );
                    this.agruparPagosPorTaller();
                },
            });
    }
    agruparPagosPorTaller() {
        // Primero, obtenemos los IDs únicos de los talleres
        const idsUnicos = Array.from(
            new Set(this.pagos.map((pago) => pago.IdWorkshop))
        );

        // Crear un array de promesas para obtener los nombres de los talleres
        const promesasNombres = idsUnicos.map((idWorkshop) =>
            this.tallerService.get(idWorkshop).toPromise()
        );

        // Esperar a que todas las promesas se resuelvan
        Promise.all(promesasNombres)
            .then((talleres) => {
                // Mapear los nombres de los talleres
                this.nombresDeTalleres = talleres.map((taller) => taller.Name);

                // Agrupar los pagos por cada ID de taller
                this.pagosPorTaller = idsUnicos.map((idWorkshop) =>
                    this.pagos.filter((pago) => pago.IdWorkshop === idWorkshop)
                );

                console.log(this.pagosPorTaller);
                console.log(this.nombresDeTalleres);
            })
            .catch((error) => {
                console.error(
                    "Error al obtener los nombres de los talleres",
                    error
                );
            });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    aceptarPago(obj: TallerPago) {
        Swal.fire({
            title: "¿Ya verificaste este pago?",
            text: "¡No lo vas a poder revertir!",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Aceptar",
        }).then((result) => {
            if (result.isConfirmed) {
                this.objeto = obj;
                this.objeto.State = "Aceptado";
                this.gestionarSolicitud();
            }
        });
    }

    rechazarPago(obj: TallerPago) {
        Swal.fire({
            title: "¿Estás seguro de rechazar este pago?",
            text: "¡Asegurate de ponerte en contacto con el cliente primero!",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Rechazar pago",
        }).then((result) => {
            if (result.isConfirmed) {
                this.objeto = obj;
                this.objeto.State = "Rechazado";
                this.gestionarSolicitud();
            }
        });
    }

    gestionarSolicitud() {
        console.log(this.objeto);
        console.log("-----");
        this.service.update(this.objeto.Id, this.objeto).subscribe({
            next: (data) => {
                console.log(data);
                Swal.fire({
                    title: this.objeto.State + "!",
                    text: "Pago Gestionada exitosamente",
                    icon: "success",
                    didClose: () => {
                        window.location.reload();
                    },
                });
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    contactarCliente(pago: TallerPago) {
        this.service.getUser(pago.Id).subscribe({
            next: (data) => {
                // Mostrar SweetAlert con enlaces
                Swal.fire({
                    title: "Contactar Cliente",
                    html: `
            <div style="font-size: 16px; text-align: center;">
              <p><strong>Nombre:</strong> ${data.FirstName}</p>
              <p>
                <strong>Correo:</strong> 
                <a href="mailto:${data.Email}" 
                   style="color: #1a73e8; text-decoration: underline; font-weight: bold;"
                   target="_blank">
                   ${data.Email}
                </a>
              </p>
              <p>
                <strong>WhatsApp:</strong> 
                <a href="https://wa.me/506${data.Phone}" 
                   style="color: #25d366; text-decoration: underline; font-weight: bold;"
                   target="_blank">
                   ${data.Phone}
                </a>
              </p>
            </div>
          `,
                    icon: "info",
                    confirmButtonText: "Cerrar",
                    customClass: {
                        popup: "swal-popup",
                    },
                });
            },
            error: (err) => {
                console.error("Error al contactar al cliente", err);
            },
        });
    }
}
