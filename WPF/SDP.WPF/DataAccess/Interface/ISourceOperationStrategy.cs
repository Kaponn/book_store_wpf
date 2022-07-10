using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP.WPF.DataAccess.Interface
{
    public interface ISourceOperationStrategy
    {
        ISourceReader GetReader(string fileName);
        ISourceWriter GetWriter(string fileName);
    }
}
