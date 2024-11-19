import { NgIf } from "@angular/common";
import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { CredentialResponse, PromptMomentNotification } from "google-one-tap";
import { jwtDecode } from "jwt-decode";
import { CookieService } from "ngx-cookie-service";
import { Role } from "src/app/interfaces/role";
import { TempPass } from "src/app/interfaces/temp_pass";
import { UsersService } from "src/app/services/cliente.service";
import { TempPassService } from "src/app/services/temp-pass.service";
import Swal from "sweetalert2";
import { SessionService } from "src/app/services/session.service";
import { Router } from "@angular/router";

@Component({
    selector: "app-ingresar",
    standalone: true,
    imports: [FormsModule, NgIf],
    templateUrl: "./ingresar.component.html",
    styleUrl: "./ingresar.component.scss",
})
export class IngresarComponent {
    usuario: string = "";
    pass: string = "";
    rol: Role = new Role();
    error: boolean = false;

    unregistered = true;
    errorMessage: string = "";
    temp: TempPass = new TempPass();

    constructor(
        private service: UsersService,
        private cookieService: CookieService,
        private tempService: TempPassService,
        private SessionService: SessionService,
        private router: Router
    ) {
        if (SessionService.hasRole("ADMIN")) {
            this.redirigir("/dashboard-admin");
        } else if (SessionService.hasRole("CLIENTE")) {
            this.redirigir("/dashboard-cliente");
        } else if (SessionService.hasRole("EMPRENDIMIENTO")) {
            this.redirigir("/dashboard-emprendimiento");
        } else if (SessionService.hasRole("REPARTIDOR")) {
            this.redirigir("/dashboard-repartidor");
        }
    }

    redirigir(url: string) {
        this.router.navigate([url]);
    }

    eliminarTemp(username) {
        this.tempService.delete(username).subscribe({
            next: (data) => {
                this.tempService.successMessage(
                    "Solicitud cancelada",
                    "/ingresar"
                );
            },
            error: (err) => {
                this.tempService.errorMessage(err.error.Message);
            },
        });
    }

    Ingresar() {
        if (this.usuario != "" && this.pass != "") {
            this.service.login(this.usuario, this.pass).subscribe({
                next: (data) => {
                    this.error = false;
                    this.SessionService.login(data.token, data.roles);
                    this.service.successMessage(
                        "¡Bienvenido a tu cuenta!",
                        "/ingresar"
                    );
                },
                error: (err) => {
                    this.error = true;
                    this.errorMessage = err.error.Message;
                },
            });
        }
        this.error = true;
        this.errorMessage = "Completa los espacios en blanco";
    }

    async recuperar() {
        // Pedir el nombre de usuario
        const { value: username } = await Swal.fire({
            title: "Ingrese su nombre de usuario",
            input: "text",
            inputPlaceholder: "Nombre de usuario",
            showCancelButton: true,
            confirmButtonText: "Siguiente",
            cancelButtonText: "Cancelar",
            inputValidator: (value) => {
                return new Promise((resolve) => {
                    if (!value) {
                        resolve("¡Necesitas escribir algo!");
                    } else {
                        this.temp.Username = value;
                        this.tempService.add(this.temp).subscribe({
                            next: (data) => {
                                this.temp = {
                                    Username: "",
                                    Email: "",
                                    Pin: 0,
                                    NewPass: "",
                                    State: "",
                                };
                                this.service.successMessage(
                                    "Se ha enviado su nueva contraseña al correo",
                                    "/ingresar"
                                ),
                                    resolve();
                            },
                            error: (err) => {
                                console.log(err);
                                resolve(`
                  ${err.error.Message}
                  <br>
                  <button id="cancel-request" class="swal2-cancel swal2-styled" style="display: inline-block; margin-top: 10px;">
                    ¿Cancelar la solicitud?
                  </button>
                `);

                                // Añadir el evento al botón después de que el Swal se haya mostrado
                                setTimeout(() => {
                                    const cancelButton =
                                        document.getElementById(
                                            "cancel-request"
                                        );
                                    if (cancelButton) {
                                        cancelButton.addEventListener(
                                            "click",
                                            () => {
                                                this.eliminarTemp(
                                                    this.temp.Username
                                                );
                                                Swal.close();
                                            }
                                        );
                                    }
                                }, 0);
                            },
                        });
                    }
                });
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

    ngOnInit(): void {
        // @ts-ignore
        window.onGoogleLibraryLoad = () => {
            // @ts-ignore
            google.accounts.id.initialize({
                client_id:
                    "112167849332-2e52g3r0sljruhhv7o1s6mpesce9uvbs.apps.googleusercontent.com",
                callback: this.handleCredentialResponse.bind(this),
                auto_select: false,
                cancel_on_tap_outside: true,
            });
            // @ts-ignore
            google.accounts.id.renderButton(
                document.getElementById("buttonDiv"),
                { theme: "outline", size: "large", width: 100 }
            );
            // @ts-ignore
            google.accounts.id.prompt(
                (notification: PromptMomentNotification) => {}
            );
        };
    }

    async handleCredentialResponse(response: CredentialResponse) {
        console.log(response.credential);
        this.decodeJWT(response.credential);
    }

    decodeJWT(token) {
        // Decodificar el payload
        const decoded = jwtDecode(token);

        // Mostrar el payload completo
        console.log("Payload Decoded:", decoded);

        // Buscar valores específicos
        const email = this.findValueByKey(decoded, "email");
        const family_name = this.findValueByKey(decoded, "family_name");
        const given_name = this.findValueByKey(decoded, "given_name");

        const user = email.split("@")[0].replace(/\./g, "");

        this.service.get("Google", user).subscribe({
            next: (data) => {
                this.error = false;
                // this.rol = data;
                console.log(this.rol);
                this.cookieService.set(
                    "cookie" + this.rol.Type,
                    this.rol.Username
                );
                this.service.successMessage(
                    "¡Bienvenido a tu cuenta!",
                    "/ingresar"
                );
            },
            error: (err) => {
                console.log(err);
                console.log(err.error.Message);
                this.service.errorMessage("Cuenta de Google no registrada");
            },
        });
    }

    findValueByKey(obj, keyToFind) {
        let result = "No value found";

        for (const key in obj) {
            if (key.toLowerCase() === keyToFind.toLowerCase()) {
                result = obj[key];
                break;
            } else if (typeof obj[key] === "object") {
                result = this.findValueByKey(obj[key], keyToFind);
                if (result !== "No value found") {
                    break;
                }
            }
        }

        return result;
    }
}
