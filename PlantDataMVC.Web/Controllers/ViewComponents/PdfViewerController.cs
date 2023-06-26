using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Syncfusion.EJ2.PdfViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PlantDataMVC.Web.Controllers.ViewComponents
{
    public class PdfViewerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _cache;

        public PdfViewerController(IWebHostEnvironment webHostEnvironment, IMemoryCache cache)
        {
            _webHostEnvironment = webHostEnvironment;
            _cache = cache;
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/Load")]
        [HttpPost]
        //[Consumes("application/json")]
        public IActionResult Load([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            // get model state for testing
            var modelState = this.ModelState;

            PdfRenderer pdfviewer = new(_cache);
            MemoryStream stream = new();

            if (jsonDict != null && jsonDict.ContainsKey("document"))
            {
                if (bool.Parse(jsonDict["isFileName"]))
                {
                    string documentPath = GetDocumentPath(jsonDict["document"]);

                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                        stream = new MemoryStream(bytes);
                    }
                    else
                    {
                        return this.Content(jsonDict["document"] + " is not found");
                    }
                }
                else
                {
                    byte[] bytes = Convert.FromBase64String(jsonDict["document"]);
                    stream = new MemoryStream(bytes);
                }
            }

            object jsonResult = pdfviewer.Load(stream, jsonDict);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [HttpPost]
        public IActionResult ExportAnnotations([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);
            PdfRenderer pdfviewer = new(_cache);
            string jsonResult = pdfviewer.ExportAnnotation(jsonDict);
            return Content(jsonResult);
        }

        [HttpPost]
        public IActionResult ImportAnnotations([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            string jsonResult = string.Empty;

            if (jsonDict != null)
            {
                if (jsonDict.ContainsKey("fileName"))
                {
                    string documentPath = GetDocumentPath(jsonDict["fileName"]);
                    if (!string.IsNullOrEmpty(documentPath))
                    {
                        jsonResult = System.IO.File.ReadAllText(documentPath);
                    }
                    else
                    {
                        return this.Content(jsonDict["document"] + " is not found");
                    }
                }
                else
                {
                    object objJsonResult;
                    string extension = Path.GetExtension(jsonDict["importedData"]);

                    if (extension != ".xfdf")
                    {
                        objJsonResult = pdfviewer.ImportAnnotation(jsonDict);
                        return Content(JsonConvert.SerializeObject(objJsonResult));
                    }
                    else
                    {
                        string documentPath = GetDocumentPath(jsonDict["importedData"]);
                        if (!string.IsNullOrEmpty(documentPath))
                        {
                            byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                            jsonDict["importedData"] = Convert.ToBase64String(bytes);
                            objJsonResult = pdfviewer.ImportAnnotation(jsonDict);
                            return Content(JsonConvert.SerializeObject(objJsonResult));
                        }
                        else
                        {
                            return this.Content(jsonDict["document"] + " is not found");
                        }
                    }
                }
            }
            return Content(jsonResult);
        }

        [HttpPost]
        public IActionResult ImportFormFields([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);
            PdfRenderer pdfviewer = new(_cache);
            object jsonResult = pdfviewer.ImportFormFields(jsonDict);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [HttpPost]
        public IActionResult ExportFormFields([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);
            PdfRenderer pdfviewer = new(_cache);
            string jsonResult = pdfviewer.ExportFormFields(jsonDict);
            return Content(jsonResult);
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/RenderPdfPages")]
        [HttpPost]
        public IActionResult RenderPdfPages([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            object jsonResult = pdfviewer.GetPage(jsonDict);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [HttpPost]
        public IActionResult RenderPdfTexts([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);
            PdfRenderer pdfviewer = new(_cache);
            object result = pdfviewer.GetDocumentText(jsonDict);
            return Content(JsonConvert.SerializeObject(result));
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/Unload")]
        [HttpPost]
        public IActionResult Unload([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            pdfviewer.ClearCache(jsonDict);
            return this.Content("Document cache is cleared");
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/RenderThumbnailImages")]
        [HttpPost]
        public IActionResult RenderThumbnailImages([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            object result = pdfviewer.GetThumbnailImages(jsonDict);
            return Content(JsonConvert.SerializeObject(result));
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/Bookmarks")]
        [HttpPost]
        public IActionResult Bookmarks([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            object jsonResult = pdfviewer.GetBookmarks(jsonDict);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/RenderAnnotationComments")]
        [HttpPost]
        public IActionResult RenderAnnotationComments([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            object jsonResult = pdfviewer.GetAnnotationComments(jsonDict);
            return Content(JsonConvert.SerializeObject(jsonResult));
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/Download")]
        [HttpPost]
        public IActionResult Download([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            string documentBase = pdfviewer.GetDocumentAsBase64(jsonDict);
            return Content(documentBase);
        }

        [AcceptVerbs("Post")]
        [Route("[controller]/PrintImages")]
        [HttpPost]
        public IActionResult PrintImages([FromBody] SyncfusionPdfJsonObject jsonObject)
        {
            var jsonDict = GetDictionaryFromObject(jsonObject);

            PdfRenderer pdfviewer = new(_cache);
            object pageImage = pdfviewer.GetPrintImage(jsonDict);
            return Content(JsonConvert.SerializeObject(pageImage));
        }

        private string GetDocumentPath(string document)
        {
            string documentPath = string.Empty;
            if (!System.IO.File.Exists(document))
            {
                string basePath = _webHostEnvironment.WebRootPath;
                string dataPath = basePath + @"/Data/";
                if (System.IO.File.Exists(dataPath + (document)))
                    documentPath = dataPath + document;
            }
            else
            {
                documentPath = document;
            }
            return documentPath;
        }

        public Dictionary<string, string> GetDictionaryFromObject(SyncfusionPdfJsonObject jsonObject)
        {
            // HACK: force isFilename to false so that load works
            jsonObject.isFileName = false.ToString().ToLower();

            Dictionary<string, object> resultObjects = new();

            resultObjects = jsonObject.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(jsonObject, null));


            var nonEmptyObjects = (from kv in resultObjects
                                where kv.Value != null
                                select kv).ToDictionary(kv => kv.Key, kv => kv.Value);

            nonEmptyObjects = resultObjects.Where(o => o.Value != null).ToDictionary(k => k.Key, k => k.Value);

            Dictionary<string, string> jsonResult = nonEmptyObjects.ToDictionary(k => k.Key, k => k.Value.ToString() ?? string.Empty);

            return jsonResult;
        }

    }

    public class SyncfusionPdfJsonObject
    {
        public string document { get; set; }
        public string password { get; set; }
        public string zoomFactor { get; set; }
        public string isFileName { get; set; }
        public string xCoordinate { get; set; }
        public string yCoordinate { get; set; }
        public string pageNumber { get; set; }
        public string documentId { get; set; }
        public string hashId { get; set; }
        public string sizeX { get; set; }
        public string sizeY { get; set; }
        public string startPage { get; set; }
        public string endPage { get; set; }
        public string stampAnnotations { get; set; }
        public string textMarkupAnnotations { get; set; }
        public string stickyNotesAnnotation { get; set; }
        public string shapeAnnotations { get; set; }
        public string measureShapeAnnotations { get; set; }
        public string action { get; set; }
        public string pageStartIndex { get; set; }
        public string pageEndIndex { get; set; }
        public string fileName { get; set; }
        public string elementId { get; set; }
        public string pdfAnnotation { get; set; }
        public string importPageList { get; set; }
        public string uniqueId { get; set; }
        public string data { get; set; }
        public string viwePortWidth { get; set; }
        public string viewPortHeight { get; set; }
        public string tilecount { get; set; }
        public string documentName { get; set; }

        public bool hideEmptyDigitalSignatureFields { get; set; }
        public bool showDigitalSignatureAppearance { get; set; }
    }
}
