﻿using System;
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
using System.Windows.Shapes;
using M120_SimpleBank.ViewModel;

namespace M120_SimpleBank.View
{
    /// <summary>
    /// Interaction logic for createCustomer.xaml
    /// </summary>
    public partial class CreateCustomerView : Window
    {
        public CreateCustomerView()
        {
            InitializeComponent();
            var viewModel = new CreateCustomerViewModel();
            DataContext = viewModel;
            if (viewModel.CloseEvent == null) {
                viewModel.CloseEvent = this.Close;
            }
        }
    }
}
