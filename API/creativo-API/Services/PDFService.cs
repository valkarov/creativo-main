using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
namespace creativo_API.Services
{
    public class PDFService
    {
        public void createPDF(string filename, string text)
        {
            string filePath = $"C:\\Users\\metal\\OneDrive\\Documentos\\github\\creativo-main\\pdf\\{filename}.pdf";

            // Crear un escritor de PDF
            PdfWriter writer = new PdfWriter(filePath);

            // Crear un PDFDocument
            PdfDocument pdf = new PdfDocument(writer);

            // Crear un documento
            Document document = new Document(pdf);

            // Añadir contenido al documento
            document.Add(new Paragraph(text));

            // Cerrar el documento
            document.Close();
        }
    }
}