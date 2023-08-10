using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BarcodeApp.Data
{
    public class FromXLSX : IFromXLSX
    {
        //Loads data from excel file
        public List<string> GetData()
        {
            var list = new List<string>();
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    var filePath = openFileDialog.FileName;

                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1);

                        foreach (var row in worksheet.RowsUsed())
                        {
                            foreach (var cell in row.Cells())
                            {
                                list.Add(cell.Value.ToString());
                            }
                        }
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show("This file is open and busy with another process");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }
    }
}