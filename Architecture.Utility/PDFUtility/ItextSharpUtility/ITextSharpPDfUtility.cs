using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Architecture.Utility.PDFUtility.ItextSharpUtility
{
    public class ITextSharpPDfUtility
    {
        /// <summary>
        /// CREATE PDF from HTML Using ITextSharp PDF. 
        /// Makesure that all HTML Tags are Closed and <br />. As If tag is missing or not closed in the HTMl content then it will give error. 
        /// </summary>
        /// <param name="HTMLContent">HTML Content</param>
        /// <param name="css"></param>
        /// <returns></returns>
        public byte[] createPdf(string HTMLContent, string css = "")
        {
            Byte[] bytes;
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {
                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {
                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        //Open the document for writing
                        doc.Open();
                        doc.NewPage();
                        //Our sample HTML and CSS
                        using (var srHtml = new StringReader(HTMLContent))
                        {
                            //Parse the HTML
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        }
                        doc.Close();
                    }
                }
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
                return bytes;
            }
        }

    }
}
