using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeApp.Service.CheckNumbers
{
    public interface ICheckNumbers
    {
        bool IsDefect(string productNumber, List<string> defectedProductNumbers);
    }
}