import { Component } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { Taller } from "src/app/interfaces/talleres";
import { EmprendimientoService } from "src/app/services/emprendimiento.service";
import {
    TallerClientesService,
    TalleresService,
    TalleresPagoService,
} from "src/app/services/talleres.service";
import jsPDF from "jspdf";
import autoTable from "jspdf-autotable";
import { UsersService } from "src/app/services/cliente.service";

@Component({
    selector: "app-entradas",
    templateUrl: "./entradas.component.html",
    styleUrl: "./entradas.component.scss",
})
export class EntradasComponent {
    talleres: Taller[] = [];

    constructor(
        private suscripcionService: TallerClientesService,
        private service: TalleresService,
        private cookieService: CookieService,
        private emService: EmprendimientoService,
        private clientService: UsersService
    ) {
        this.service
            .getSelectedList(
                "byClient/" + this.cookieService.get("cookieCLIENTE")
            )
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

    downloadPdf(taller: Taller) {
        this.emService
            .get("User", taller.IdEntrepreneurship.toString())
            .subscribe({
                next: (data) => {
                    const emprendimiento = data;
                    console.log(data);
                    console.log("hizo empren");

                    this.clientService
                        .get("User", this.cookieService.get("cookieCLIENTE"))
                        .subscribe({
                            next: (data) => {
                                console.log(data);
                                console.log("hizo cliente");
                                const cliente = data;

                                const doc = new jsPDF();
                                const margins = {
                                    top: 20,
                                    left: 20,
                                    bottom: 20,
                                    right: 20,
                                };
                                const headerHeight = 10;

                                // Agregar título
                                doc.setFontSize(22);
                                doc.setTextColor(0, 0, 255); // Color azul
                                doc.text("Factura", margins.left, margins.top);

                                // Agregar Cliente
                                doc.setFontSize(16);
                                doc.setTextColor(0, 0, 0); // Color negro
                                doc.text(
                                    "Cliente:",
                                    margins.left,
                                    margins.top + 20
                                );

                                let currentY = margins.top + 30;

                                autoTable(doc, {
                                    startY: currentY,
                                    head: [["Campo", "Valor"]],
                                    body: [
                                        [
                                            "ID Cliente",
                                            cliente.IdClient.toString(),
                                        ],
                                        ["Username", cliente.Username],
                                        ["Email", cliente.Email],
                                        [
                                            "Nombre",
                                            `${cliente.FirstName} ${cliente.LastName}`,
                                        ],
                                        ["Teléfono", cliente.Phone],
                                        ["Provincia", cliente.Province],
                                        ["Cantón", cliente.Canton],
                                        ["Distrito", cliente.District],
                                    ],
                                    theme: "grid",
                                    headStyles: { fillColor: [0, 0, 255] }, // Azul para el encabezado
                                    styles: { fontSize: 12 },
                                    didDrawPage: (data) => {
                                        // Actualizar la posición Y después de cada tabla
                                        currentY = data.cursor.y;
                                    },
                                });

                                // Agregar Taller
                                doc.setFontSize(16);
                                doc.text(
                                    "Taller:",
                                    margins.left,
                                    currentY + 10
                                );

                                autoTable(doc, {
                                    startY: currentY + 20,
                                    head: [["Campo", "Valor"]],
                                    body: [
                                        [
                                            "ID Taller",
                                            taller.IdWorkshop.toString(),
                                        ],
                                        ["Nombre", taller.Name],
                                        ["Precio", taller.Price.toFixed(2)],
                                        ["Descripción", taller.Description],
                                        ["Enlace", taller.Link],
                                        ["Tipo", taller.Type],
                                    ],
                                    theme: "grid",
                                    headStyles: { fillColor: [0, 123, 255] }, // Azul para el encabezado
                                    styles: { fontSize: 12 },
                                    didDrawPage: (data) => {
                                        // Actualizar la posición Y después de cada tabla
                                        currentY = data.cursor.y;
                                    },
                                });

                                // Agregar Emprendimiento
                                doc.setFontSize(16);
                                doc.text(
                                    "Emprendimiento:",
                                    margins.left,
                                    currentY + 10
                                );

                                autoTable(doc, {
                                    startY: currentY + 20,
                                    head: [["Campo", "Valor"]],
                                    body: [
                                        [
                                            "ID Emprendimiento",
                                            emprendimiento.IdEntrepreneurship.toString(),
                                        ],
                                        ["Username", emprendimiento.Username],
                                        ["Nombre", emprendimiento.Name],
                                        ["Email", emprendimiento.Email],
                                        ["SINPE", emprendimiento.Sinpe],
                                        ["Teléfono", emprendimiento.Phone],
                                        ["Provincia", emprendimiento.Province],
                                        ["Cantón", emprendimiento.Canton],
                                        ["Distrito", emprendimiento.District],
                                    ],
                                    theme: "grid",
                                    headStyles: { fillColor: [0, 123, 255] }, // Azul para el encabezado
                                    styles: { fontSize: 12 },
                                    didDrawPage: (data) => {
                                        // Actualizar la posición Y después de cada tabla
                                        currentY = data.cursor.y;
                                    },
                                });

                                // Guardar el PDF
                                doc.save("factura.pdf");
                            },
                        });
                },
            });
    }
}
