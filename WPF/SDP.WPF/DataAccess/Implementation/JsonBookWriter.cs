using Newtonsoft.Json;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SDP.WPF.DataAccess.Implementation
{
    class JsonBookWriter : ISourceWriter
    {
        public void WriteBooks(string filePath, List<Book> books)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(JsonConvert.SerializeObject(books, Formatting.Indented));
            }
        }
    }
}
