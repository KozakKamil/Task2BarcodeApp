using BarcodeApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarcodeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BarcodeView : Window
    {
        private BarcodeViewModel? viewModel;

        public BarcodeView()
        {
            InitializeComponent();
            viewModel = StartUp.ServiceProvider?.GetService<BarcodeViewModel>();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            inputBorder.Opacity = 1;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            inputBorder.Opacity = 0.5;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewModel == null)
            {
                return;
            }

            if (e.Key == Key.Enter)
            {
                viewModel.Input = ((TextBox)sender).Text;
                viewModel.CheckNumber();
            }
        }
    }
}