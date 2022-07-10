using Newtonsoft.Json;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess.Implementation
{
    class JsonBookReader : ISourceReader
    {
        public List<Book> ReadBooks(string path)
        {
            string books = File.ReadAllText(path);
            List<Book> BookList = JsonConvert.DeserializeObject<List<Book>>(books);
            return BookList;
        }
    }

}
