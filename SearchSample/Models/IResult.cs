using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSample.Models
{
    public interface IResult
    {
        string WrapperType { get; set; }

        string Kind { get; set; }
    }
}
