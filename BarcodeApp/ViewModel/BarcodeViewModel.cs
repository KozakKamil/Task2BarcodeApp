using BarcodeApp.Data;
using BarcodeApp.Service;
using BarcodeApp.Service.CheckNumbers;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace BarcodeApp.ViewModel
{
    public partial class BarcodeViewModel : BaseViewModel
    {
        private readonly ICheckNumbers _checkNumbers;
        private readonly IFromXLSX _fromXLSX;

        public ObservableCollection<string> ScannedDefectProduct { get; set; } = new();
        public List<string> DefectProductNumber { get; set; } = new();

        public string? Input { get; set; }

        public BarcodeViewModel(ICheckNumbers checkNumbers, IFromXLSX fromXLSX)
        {
            _checkNumbers = checkNumbers;
            _fromXLSX = fromXLSX;
        }

        //Getting data from excel to list 
        [RelayCommand]
        public void GetDefectSerialNumber()
        {
            DefectProductNumber = _fromXLSX.GetData();
        }

        //Check if given number is defect one and write it down to list 
        [RelayCommand]
        public void CheckNumber()
        {
            if (Input == null)
            {
                MessageBox.Show("No product number to check", "Empty input", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (DefectProductNumber == null || DefectProductNumber.Count == 0)
            {
                MessageBox.Show("First load list of defect product numbers", "Defect product", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var isDefect = _checkNumbers.IsDefect(Input, DefectProductNumber);
            if (isDefect)
            {
                ScannedDefectProduct.Add(Input);
            }
            Input = String.Empty;
            OnPropertyChanged(nameof(Input));
        }
    }
}