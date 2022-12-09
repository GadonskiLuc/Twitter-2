using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void botaoSair_Click(object sender, RoutedEventArgs e)
        {
            string mensagem = "Tem Certeza?";
            string titulo = "Confirmação";
            MessageBoxButton botao = MessageBoxButton.YesNo;
            MessageBoxResult resultado;
            resultado = MessageBox.Show(mensagem, titulo, botao,MessageBoxImage.None,MessageBoxResult.No);
            
            if(resultado== MessageBoxResult.Yes)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
