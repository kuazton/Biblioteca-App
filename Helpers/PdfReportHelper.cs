using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

namespace CRUD.Helpers
{
    public class PdfReportHelper
    {
        public static void CrearEjemploPDF(string rutaArchivo)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Header().Text("Reporte de Libros").FontSize(20).Bold();
                    page.Content().Column(col =>
                    {
                        col.Item().Text("Este es un PDF generado con QuestPDF.");
                        col.Item().Text("Puedes personalizar el contenido aquí.");
                    });
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            })
            .GeneratePdf(rutaArchivo);
        }
    }
}
