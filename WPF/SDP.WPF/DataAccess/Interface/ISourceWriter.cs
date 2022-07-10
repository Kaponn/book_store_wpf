using SDP.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess.Interface
{
    public interface ISourceWriter
    {
        void WriteBooks(string filePath, List<Book> books);
    }
}
