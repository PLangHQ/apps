using PLang.Modules;
using System.ComponentModel;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Writer;
using System.Text;

namespace PdfModule2
{
    [Description("It should be able to read pdf and get text out of it, get page count, read specific page, get form data from pdf, create pdf")]
    public class Program : BaseProgram
    {
        private readonly IPLangFileSystem fileSystem;
        private readonly ILogger logger;

        public Program(IPLangFileSystem fileSystem, ISettings settings, ILogger logger) : base()
        {
            this.fileSystem = fileSystem;
            this.logger = logger;
        }

        /*
         * plang: - read file.pdf into %content%
         */
        public async Task<string> ReadPdfContent(string path)
        {
            var absolutePath = GetPath(path);

            if (!fileSystem.File.Exists(absolutePath))
            {
                return new ProgramError("File not found", goalStep, function, "Ensure the file path is correct.", "https://github.com/UglyToad/PdfPig").ToString();
            }

            using (var document = PdfDocument.Open(absolutePath))
            {
                StringBuilder content = new StringBuilder();
                foreach (var page in document.GetPages())
                {
                    content.AppendLine(page.Text);
                }
                return content.ToString();
            }
        }

        /*
         * plang: - read page 1 from file.pdf, write into %page%
         */
        public async Task<string> ReadPdfPage(string path, int pageNumber)
        {
            var absolutePath = GetPath(path);

            if (!fileSystem.File.Exists(absolutePath))
            {
                return new ProgramError("File not found", goalStep, function, "Ensure the file path is correct.", "https://github.com/UglyToad/PdfPig").ToString();
            }

            using (var document = PdfDocument.Open(absolutePath))
            {
                var page = document.GetPage(pageNumber);
                return page.Text;
            }
        }

        /*
         * plang: - read form data from file.pdf, write into %formData%
         */
        public async Task<string> ReadPdfFormData(string path)
        {
            var absolutePath = GetPath(path);

            if (!fileSystem.File.Exists(absolutePath))
            {
                return new ProgramError("File not found", goalStep, function, "Ensure the file path is correct.", "https://github.com/UglyToad/PdfPig").ToString();
            }

            using (var document = PdfDocument.Open(absolutePath))
            {
                if (document.TryGetForm(out var form))
                {
                    StringBuilder formData = new StringBuilder();
                    foreach (var field in form.Fields)
                    {
                        formData.AppendLine($"{field.Name}: {field.Value}");
                    }
                    return formData.ToString();
                }
                else
                {
                    return "No form data found.";
                }
            }
        }

        /*
         * plang: - get page count from file.pdf, write to %pageCount%
         */
        public async Task<int> GetPdfPageCount(string path)
        {
            var absolutePath = GetPath(path);

            if (!fileSystem.File.Exists(absolutePath))
            {
                return new ProgramError("File not found", goalStep, function, "Ensure the file path is correct.", "https://github.com/UglyToad/PdfPig").ToString();
            }

            using (var document = PdfDocument.Open(absolutePath))
            {
                return document.NumberOfPages;
            }
        }

        /*
         * plang: - create pdf with content %content%, save to %path%
         */
        public async Task CreatePdf(string content, string path)
        {
            var absolutePath = GetPath(path);
            var dirPath = fileSystem.Path.GetDirectoryName(absolutePath);
            if (!fileSystem.Directory.Exists(dirPath))
            {
                fileSystem.Directory.CreateDirectory(dirPath);
            }

            var builder = new PdfDocumentBuilder();
            var page = builder.AddPage(PageSize.A4);
            var font = builder.AddStandard14Font(Standard14Font.Helvetica);
            page.AddText(content, 12, new PdfPoint(25, 700), font);

            var documentBytes = builder.Build();
            await fileSystem.File.WriteAllBytesAsync(absolutePath, documentBytes);
        }
    }
}
