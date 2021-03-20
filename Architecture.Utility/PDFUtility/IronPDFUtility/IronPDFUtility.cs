using System;

namespace Architecture.Utility.PDFUtility.IronPDFUtility
{
    /// <summary>
    /// Utility class to handle PDF operations
    /// </summary>
    public static class IronPDFHelper
    {
        /// <summary>
        /// Generates the PDF at given path.
        /// </summary>
        /// <param name="filePath">Location for the PDF to be saved.</param>
        /// <param name="HtmlContent">HTML content to be generated as a PDF.</param>
        /// <returns></returns>
        public static string CreatePDF(string filePath, string HtmlContent)
        {
            var Renderer = new IronPdf.HtmlToPdf();

            Renderer.PrintOptions.SetCustomPaperSizeInInches(4, 6);
            Renderer.PrintOptions.FitToPaperWidth = true;
            Renderer.PrintOptions.MarginTop = 0;  //millimeters
            Renderer.PrintOptions.MarginLeft = 0;  //millimeters
            Renderer.PrintOptions.MarginRight = 0;  //millimeters
            Renderer.PrintOptions.MarginBottom = 0;  //millimeters

            try
            {
                IronPdf.PdfDocument result = Renderer.RenderHtmlAsPdf(HtmlContent);
                result.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return filePath;
        }
    }
}
