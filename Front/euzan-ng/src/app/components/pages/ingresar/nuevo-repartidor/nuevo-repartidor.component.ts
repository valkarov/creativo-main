import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { CookieService } from "ngx-cookie-service";
import { Province, Canton, Distrito } from "src/app/interfaces/lugares";
import { Repartidor } from "src/app/interfaces/repartidor";
import { TempPass } from "src/app/interfaces/temp_pass";
import {
    ProvinciaService,
    CantonService,
    DistritoService,
} from "src/app/services/lugares.service";
import { RepartidorService } from "src/app/services/repartidor.service";
import { TempPassService } from "src/app/services/temp-pass.service";
import Swal from "sweetalert2";

@Component({
    selector: "app-nuevo-repartidor",
    templateUrl: "./nuevo-repartidor.component.html",
    styleUrl: "./nuevo-repartidor.component.scss",
})
export class NuevoRepartidorComponent {
    objeto = new Repartidor();
    editMode = false;

    constructor(
        private service: RepartidorService,
        private provinciaService: ProvinciaService,
        private cantonService: CantonService,
        private distritoService: DistritoService,
        private route: Router,
        private rou: ActivatedRoute,

        private cookieService: CookieService,
        private tempService: TempPassService
    ) {
        this.getProvincias();
        if (this.rou.snapshot.params["tipo"] == "repartidor") {
            this.editMode = true;

            const user = this.cookieService.get("cookieREPARTIDOR");
            this.service.get("User", user).subscribe({
                next: (data) => {
                    const temp: Repartidor = data;
                    this.getProvincias();
                    this.objeto.Province = temp.Province;
                    this.getCantones();
                    this.objeto.Canton = temp.Canton;
                    this.getDistritos();
                    this.objeto = data;
                },
                error: (err) => {
                    console.log(err);
                },
            });
        }
    }

    provincias: Province[] = [];
    cantones: Canton[] = [];
    distritos: Distrito[] = [];
    confirm = "";

    mensajeId: string = "";
    mensajeUser: string = "";
    mensajeEmail: string = "";
    temp: TempPass = new TempPass();

    guardar() {
        if (this.editMode) {
            Swal.fire({
                title: "¿Quieres actualizar tu perfil en Club Creativo como Repartidor?",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Aceptar",
            }).then((result) => {
                if (result.isConfirmed) {
                    this.service
                        .update(this.objeto.IdDeliveryPerson, this.objeto)
                        .subscribe({
                            next: (data) => {
                                this.service.successMessage(
                                    "Correctamente actualizado",
                                    "/editar-perfil"
                                );
                            },
                            error: (err) => {
                                console.log(err);
                                this.service.errorMessage(err.error.Message);
                            },
                        });
                }
            });
        } else {
            Swal.fire({
                title: "¿Quieres registrarte en Club Creativo como Repartidor?",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Aceptar",
            }).then((result) => {
                if (result.isConfirmed) {
                    if (this.confirm === this.objeto.Password) {
                        console.log(this.objeto);
                        this.objeto.State = "Disponible";
                        this.service.add(this.objeto).subscribe({
                            next: (data) => {
                                this.service.successMessage(
                                    "Registro exitoso",
                                    "/ingresar"
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

    selected() {
        this.getCantones();
        this.objeto.District = "";
    }

    selectedcant() {
        this.getDistritos();
    }

    getProvincias() {
        this.provinciaService.getList().subscribe({
            next: (data) => {
                this.provincias = data;
            },
        });
    }

    getCantones() {
        this.cantonService.getSelectedList(this.objeto.Province).subscribe({
            next: (data) => {
                this.cantones = data;
            },
        });
    }

    getDistritos() {
        this.distritoService.getSelectedList(this.objeto.Canton).subscribe({
            next: (data) => {
                this.distritos = data;
            },
        });
    }

    redirigir(url: string) {
        this.route.navigate([url]);
    }

    checkAvailabilityId() {
        if (this.objeto.IdDeliveryPerson == null) {
            this.mensajeId = "";
        } else {
            this.service.get("byId", this.objeto.IdDeliveryPerson).subscribe(
                () => {
                    this.mensajeId = "No disponible";
                },
                () => {
                    this.mensajeId = "Disponible";
                }
            );
        }
    }
    esCorreoValido(correo: string): boolean {
        const patron = /^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,6}$/;
        return patron.test(correo);
    }

    checkAvailabilityEmail() {
        if (this.objeto.Email == "") {
            this.mensajeEmail = "";
        } else if (!this.esCorreoValido(this.objeto.Email)) {
            this.mensajeEmail = "No disponible";
        } else {
            this.service
                .get("byEmail", this.objeto.Email.replace(/\./g, ""))
                .subscribe(
                    () => {
                        this.mensajeEmail = "No disponible";
                    },
                    () => {
                        this.mensajeEmail = "Disponible";
                    }
                );
        }
    }
    checkAvailabilityUser() {
        if (this.objeto.Username == "") {
            this.mensajeUser = "";
        } else {
            this.service.get("byUser", this.objeto.Username).subscribe(
                () => {
                    this.mensajeUser = "No disponible";
                },
                () => {
                    this.mensajeUser = "Disponible";
                }
            );
        }
    }

    formatoNumeros(event, cantidad) {
        const input = event.target.value;
        const formatted = input.replace(/[^0-9-]/g, "").slice(0, cantidad);
        event.target.value = formatted;
    }

    async recuperar() {
        this.temp.Username = this.objeto.Username;
        this.tempService.add(this.temp).subscribe({
            next: (data) => {
                this.temp = data;
                this.continuarRecuperacion();
            },
            error: (err) => {
                console.log(err);
                Swal.fire({
                    icon: "error",
                    title: "Error",
                    html: `
                      ${err.error.Message}
                      <br>
                      <button id="cancel-request" class="swal2-cancel swal2-styled" style="display: inline-block; margin-top: 10px;">
                          ¿Cancelar la solicitud?
                      </button>
                  `,
                });

                // Añadir el evento al botón después de que el Swal se haya mostrado
                setTimeout(() => {
                    const cancelButton =
                        document.getElementById("cancel-request");
                    if (cancelButton) {
                        cancelButton.addEventListener("click", () => {
                            this.eliminarTemp(this.temp.Username);
                            Swal.close();
                        });
                    }
                }, 0);
            },
        });
    }

    async continuarRecuperacion() {
        // Pedir el PIN
        const hiddenEmail = this.getObfuscatedEmail(this.temp.Email);
        const { value: pin } = await Swal.fire({
            title: "Ingrese su PIN",
            input: "number",
            inputPlaceholder: "PIN",
            showCancelButton: true,
            confirmButtonText: "Siguiente",
            cancelButtonText: "Cancelar",
            html: `<p>Hemos enviado el PIN al correo: ${hiddenEmail}</p>`,
            inputValidator: (value) => {
                return new Promise((resolve) => {
                    if (!value) {
                        resolve("¡Necesitas ingresar un PIN!");
                    } else if (parseInt(value) !== this.temp.Pin) {
                        resolve("PIN incorrecto.");
                    } else {
                        console.log("PIN correcto.");
                        resolve();
                    }
                });
            },
        });

        // Continuar si el PIN es válido
        if (pin) {
            // Pedir nueva contraseña
            const { value: newPassword } = await Swal.fire({
                title: "Ingrese su nueva contraseña",
                input: "password",
                inputPlaceholder: "Nueva contraseña",
                showCancelButton: true,
                confirmButtonText: "Guardar",
                cancelButtonText: "Cancelar",
                inputValidator: (value) => {
                    if (!value) {
                        return "¡Necesitas ingresar una nueva contraseña!";
                    } else {
                        this.temp.NewPass = value;
                        this.temp.State = "Autorizado";
                        console.log("Nueva contraseña guardada:", value);
                        this.tempService
                            .update(this.temp.Username, this.temp)
                            .subscribe({
                                next: (data) =>
                                    this.service.successMessage(
                                        "Contraseña Cambiada con éxito",
                                        "/ingresar"
                                    ),
                                error: (data) =>
                                    this.service.errorMessage(
                                        "Algo ha salido mal, intenta de nuevo en unos minutos"
                                    ),
                            });
                    }
                },
            });
        }
    }

    eliminarTemp(username) {
        this.tempService.delete(username).subscribe({
            next: (data) => {
                this.tempService.successMessage(
                    "Solicitud cancelada",
                    "/editar-perfil"
                );
            },
            error: (err) => {
                this.tempService.errorMessage(err.error.Message);
            },
        });
    }

    getObfuscatedEmail(email) {
        const atIndex = email.indexOf("@");
        const localPart = email.substring(0, atIndex);
        const domain = email.substring(atIndex);
        const obfuscatedLocalPart =
            localPart.substring(0, 2) + "*".repeat(localPart.length - 2);
        return obfuscatedLocalPart + domain;
    }
}
