import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Emprendimiento } from "src/app/interfaces/emprendimiento";
import { Taller, TallerClient, TallerPago } from "src/app/interfaces/talleres";
import { EmprendimientoService } from "src/app/services/emprendimiento.service";
import {
    TallerClientesService,
    TalleresPagoService,
    TalleresService,
} from "src/app/services/talleres.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-ver-talleres",
    templateUrl: "./ver-talleres.component.html",
    styleUrl: "./ver-talleres.component.scss",
})
export class VerTalleresComponent {
    talleres: Taller[] = [];
    suscripcion: TallerClient = new TallerClient();

    constructor(
        private suscripcionService: TallerClientesService,
        private service: TalleresService,
        private cookieService: CookieService,
        private emService: EmprendimientoService,
        private pagoService: TalleresPagoService,
        private router: Router
    ) {
        this.service.getList().subscribe({
            next: (data) => {
                this.talleres = data;
            },
            error: (err) => {
                console.log(err);
            },
        });
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    suscribirse(id: number) {
        Swal.fire({
            title: "¿Quieres suscribirte a este taller?",
            text: "¡No lo vas a poder revertir!",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Suscribirme",
        }).then((result) => {
            if (result.isConfirmed) {
                this.suscripcion.IdWorkshop = id;
                this.suscripcion.IdClient =
                    this.cookieService.get("cookieCLIENTE");

                console.log(this.suscripcion);

                this.suscripcionService.add(this.suscripcion).subscribe({
                    next: (data) => {
                        this.mensajeSuscripcion(id);
                    },
                    error: (err) => {
                        this.service.errorMessage(err.error.Message);
                    },
                });
            }
        });
    }

    registrarPago(taller: Taller) {
        this.emService.get(taller.IdEntrepreneurship.toString()).subscribe({
            next: (data) => {
                console.log(data);
                const temp: Emprendimiento = data;

                Swal.fire({
                    title: "Registra tu pago",
                    html: `
            <p>Realiza una transacción SINPE al número <strong>${temp.Sinpe}</strong> a nombre de <strong>${temp.Name}</strong> por <strong>₡${taller.Price}</p>
            
            <label for="input1">Escribe los últimos 4 dígitos de la transacción registrada</label>
            <input type="number" id="input1" class="swal2-input" placeholder="XXXX" min="0" max="9999" style="margin-top: 10px;" oninput="this.value = this.value.slice(0, 4);">
            <p>---</p>
            <label for="input2" style="margin-top: 15px; display: block;">Escribe el Nombre del Propietario de la Cuenta</label>
            <input type="text" id="input2" class="swal2-input" placeholder="Inés Rodríguez">
          `,
                    focusConfirm: false,
                    showCancelButton: true,
                    confirmButtonText: "Registrar Pago",
                    cancelButtonText: "Cancelar",
                    confirmButtonColor: "#3085d6", // Color del botón de confirmar
                    cancelButtonColor: "#d33", // Color del botón de cancelar
                    preConfirm: () => {
                        const input1 = (
                            document.getElementById(
                                "input1"
                            ) as HTMLInputElement
                        ).value;
                        const input2 = (
                            document.getElementById(
                                "input2"
                            ) as HTMLInputElement
                        ).value;

                        // Validar que input1 tenga exactamente 4 dígitos
                        if (!/^\d{4}$/.test(input1)) {
                            Swal.showValidationMessage(
                                "Debe ingresar exactamente 4 dígitos numéricos"
                            );
                            return false;
                        }

                        return {
                            input1: input1,
                            input2: input2,
                        };
                    },
                }).then((result) => {
                    if (result.isConfirmed) {
                        console.log(
                            "Dígitos Transacción:",
                            result.value?.input1
                        );
                        console.log(
                            "Nombre Propietario:",
                            result.value?.input2
                        );

                        const pago: TallerPago = new TallerPago();
                        pago.Id = 0;
                        pago.IdClient = this.cookieService.get("cookieCLIENTE");
                        pago.IdWorkshop = taller.IdWorkshop;
                        pago.LastDigits = result.value?.input1;
                        pago.Owner = result.value?.input2;
                        pago.Price = taller.Price;
                        pago.State = "Pendiente";

                        this.pagoService.add(pago).subscribe({
                            next: (data) => {
                                console.log(data);
                                this.service.successMessage(
                                    "Te has suscrito al Taller, en cuanto el emprendimiento verifique tu pago, llegarán las entradas a tu correo",
                                    "/ver-talleres"
                                );
                            },
                            error: (err) => {
                                console.log(err);
                            },
                        });
                    } else if (result.isDismissed) {
                        console.log("Acción cancelada");
                    }
                });
            },
        });
    }

    mensajeSuscripcion(id: number) {
        if (
            this.talleres.find((taller) => taller.IdWorkshop === id)?.Type ==
            "Virtual"
        ) {
            this.service.subMessage(
                "Te has suscrito al taller con éxito",
                "Pronto un repartidor se pondrá en contacto contigo mediante tu número de teléfono para entregarte un paquete con los materiales necesarios para este taller. ¡Mantente atentx!",
                "/dashboard-cliente"
            );
        } else {
            this.service.subMessage(
                "Te has suscrito al taller con éxito",
                "Los materiales necesarios para este taller estarán esperando por ti en Club Creativo presencialmente.",
                "/dashboard-cliente"
            );
        }
    }
}
