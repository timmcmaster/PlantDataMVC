using System;

namespace PlantDataMvc.Web.Models.ViewModels.Label
{
    public class FileModel
    {
        public string Name { get; set; } = string.Empty;
        public string ContentType { get; set; } = "application/pdf";
        public byte[] Data { get; set; } = Array.Empty<byte>();
        public string DataBase64 { get; set; } = string.Empty;
    }
}
