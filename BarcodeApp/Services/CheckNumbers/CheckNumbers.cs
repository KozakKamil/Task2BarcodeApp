using BarcodeApp.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace BarcodeApp.Service.CheckNumbers
{
    public class CheckNumbers : ICheckNumbers
    {

        //Check if given string is substring in any of defects provided in list
        public bool IsDefect(string productNumber, List<string> defectedProductNumbers)
        {
            if (defectedProductNumbers.Any() == false)
                return false;
            foreach (var defectedNumber in defectedProductNumbers)
            {
                if (productNumber.Contains(defectedNumber))
                    return true;
            }
            return false;
        }
    }
}