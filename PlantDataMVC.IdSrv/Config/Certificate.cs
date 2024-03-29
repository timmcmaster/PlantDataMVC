﻿using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PlantDataMVC.IdSrv.Config
{
    public static class Certificate
    {
        public static X509Certificate2 Get()
        {
            // Get this assembly
            var assembly = typeof(Certificate).Assembly;

            var names = assembly.GetManifestResourceNames();

            using (var stream = assembly.GetManifestResourceStream("PlantDataMVC.IdSrv.Certificates.idsrv3test.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}