using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.parser;
using iTextSharp.text;
using System.Drawing.Imaging;

namespace Ornate
{
    class PDFConverter
    {

        private Document outputDoc;
        private FileStream fs;
        private PdfWriter writer;
        public PDFConverter()
        {
            createPDF();
        }

        public void createPDF()
        {
            if (fs == null)
            {
                try
                {
                    fs = new FileStream(@"C:\Ornate\Ornate\data\out\a.pdf", FileMode.Create);
                    Console.WriteLine("New Output Document Was Created");
                    if (outputDoc == null)
                    {
                        outputDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                        Console.WriteLine("New Output Document Was Created");
                        writer = PdfWriter.GetInstance(outputDoc, fs);

                        outputDoc.AddAuthor("Ornate System");

                        outputDoc.AddCreator("Ornate System");

                        outputDoc.AddKeywords("Automated Notes");

                        outputDoc.AddSubject("Automated Notes");

                        outputDoc.AddTitle("Ornate System Automated Notes");

                        outputDoc.Open();

                        outputDoc.Add(new Paragraph("Automated Information Security Notes" + "\r\n")); //update contents of the last page
                        outputDoc.Close();
                        fs.Close();

                    }
                    else
                    {
                        Console.WriteLine("The output document has been created already");
                    }
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("Could not open the filestream" + e.HelpLink);

                }

            }

        }
        public void AddTextToPdf()
        {

            Random r = new Random();
            using (var reader = new PdfReader(System.IO.File.ReadAllBytes(@"C:\Ornate\Ornate\data\out\GeneratedNotes.pdf")))
            {
                using (var fileStream = new FileStream(@"C:\Ornate\Ornate\data\out\" + r.Next(100) + ".pdf", FileMode.Create, FileAccess.Write))
                {
                    var document = new Document(reader.GetPageSizeWithRotation(1));
                    var writer = PdfWriter.GetInstance(document, fileStream);

                    document.Open();

                    List<Page> list = new List<Page>();
                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        document.NewPage();

                        var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        var importedPage = writer.GetImportedPage(reader, i);

                        var contentByte = writer.DirectContent;
                        contentByte.BeginText();
                        contentByte.SetFontAndSize(baseFont, 12);

                        StringWriter output = new StringWriter();
                        list.Add(new Page(i, PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy())));

                        var multiLineString = "Hello,\r\nWorld!".Split('\n');
                        foreach (var line in multiLineString)
                        {
                            contentByte.ShowTextAligned(PdfContentByte.ALIGN_LEFT, line, 200, 200, 0);
                        }

                        contentByte.EndText();
                        contentByte.AddTemplate(importedPage, 0, 0);
                    }

                    document.Close();
                    writer.Close();
                }
            }
        }
        public void writeParagraph(String paragraph)
        {
            Random r = new Random();
            List<Page> list = new List<Page>();
            using (var reader = new PdfReader(System.IO.File.ReadAllBytes(@"C:\Ornate\Ornate\data\out\a.pdf")))
            {
                using (var fileStream = new FileStream(@"C:\Ornate\Ornate\data\out\" + r.Next(100) + ".pdf", FileMode.Create, FileAccess.Write))
                {
                    var document = new Document(reader.GetPageSizeWithRotation(1));
                    var writer = PdfWriter.GetInstance(document, fileStream);

                    document.Open();

                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        list.Add(new Page(i, PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy())));

                    }

                    document.Add(new Paragraph(list[0]._content + "\r\n")); //update contents of the last page
                    document.Add(new Paragraph(paragraph));
                    document.Close();
                    fileStream.Close();

                }
            }
            //List<Page> pages = GetTextFromAllPages(@"C:\Ornate\Ornate\data\out\GeneratedNotes.pdf");
            //Page lastPage = pages.ElementAt(pages.Count());
            //lastPage._content += paragraph;

        }

        public static List<Page> GetTextFromAllPages(String pdfPath)
        {
            List<Page> list = new List<Page>();
            PdfReader reader = new PdfReader(pdfPath);
            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                list.Add(new Page(i, PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy())));
            }
            return list;
        }

        public static string getTextFromPage(int pageNum, String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);
            StringWriter output = new StringWriter();
            output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, pageNum, new SimpleTextExtractionStrategy()));
            return output.ToString();
        }
        //Reference: https://stackoverflow.com/questions/1799402/how-to-grab-pdf-image-elements-using-c-sharp
        #region ExtractImagesFromPDF
        public static void ExtractImagesFromPDF(string sourcePdf, string outputPath)
        {
            // NOTE:  This will only get the first image it finds per page.
            PdfReader pdf = new PdfReader(sourcePdf);
            RandomAccessFileOrArray raf = new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf);

            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);
                    PdfDictionary res =
                      (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                    PdfDictionary xobj =
                      (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                    if (xobj != null)
                    {
                        foreach (PdfName name in xobj.Keys)
                        {
                            PdfObject obj = xobj.Get(name);
                            if (obj.IsIndirect())
                            {
                                PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                                PdfName type =
                                  (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));
                                if (PdfName.IMAGE.Equals(type))
                                {

                                    int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                    PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                    PdfStream pdfStrem = (PdfStream)pdfObj;
                                    byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                    if ((bytes != null))
                                    {
                                        using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
                                        {
                                            memStream.Position = 0;
                                            System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                                            // must save the file while stream is open.
                                            if (!Directory.Exists(outputPath))
                                                Directory.CreateDirectory(outputPath);

                                            string path = System.IO.Path.Combine(outputPath, String.Format(@"{0}.jpg", pageNumber));
                                            System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                                            parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                                            // GetImageEncoder is found below this method
                                            System.Drawing.Imaging.ImageCodecInfo jpegEncoder = GetImageEncoder("JPEG");
                                            img.Save(path, jpegEncoder, parms);
                                            break;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            catch
            {
                throw;
            }
            finally
            {
                pdf.Close();
            }


        }
        #endregion

        #region GetImageEncoder
        public static System.Drawing.Imaging.ImageCodecInfo GetImageEncoder(string imageType)
        {
            imageType = imageType.ToUpperInvariant();



            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
            {
                if (info.FormatDescription == imageType)
                {
                    return info;
                }
            }

            return null;
        }
        #endregion


    }
}
