using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Trvaversal.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string fileName = Guid.NewGuid() + ".pdf";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);

                PdfWriter.GetInstance(document,stream);

                document.Open();
                Paragraph paragraph = new("<h1 style='color:red'>Traversal Rezervasyon Pdf Raporu</h1>");

                document.Add(paragraph);

                document.Close();
            }
                return File("/PdfReport/"+ fileName, "application/pdf","dosya1.pdf"); 
        }
    }
}
