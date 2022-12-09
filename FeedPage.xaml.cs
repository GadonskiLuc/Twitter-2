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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Twitter_2
{
    /// <summary>
    /// Interação lógica para FeedPage.xam
    /// </summary>
    public partial class FeedPage : Page
    {
        Dados dados;
        public FeedPage(Dados dados)
        {
            InitializeComponent();
            this.dados = dados;
        }

        private void lu_Loaded(object sender, RoutedEventArgs e)
        {
            lu.Content = this.dados.Contas[this.dados.posConta].name;
        }
    }
}