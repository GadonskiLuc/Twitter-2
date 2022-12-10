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
            homePage();
            this.dados = dados;

            labelNome.Content = this.dados.Contas[this.dados.posConta].name;
            labelUser.Content = $"@{this.dados.Contas[this.dados.posConta].username}";
            profileBio.Text= this.dados.Contas[this.dados.posConta].bio;

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

        private void botaoPerfil_Click(object sender, RoutedEventArgs e)
        {
            perfilPage();

        }

        private void perfilPage()
        {
            labelNome.Visibility = Visibility.Visible;
            labelUser.Visibility = Visibility.Visible;
            profileBio.Visibility = Visibility.Visible;
            profileWallpaper.Visibility = Visibility.Visible;
            userImage.Visibility = Visibility.Visible;

            botaoEditar.Visibility = Visibility.Visible;
            botaoEditar.IsEnabled= true;
        }
        private void homePage()
        {
            labelNome.Visibility = Visibility.Hidden;
            labelUser.Visibility = Visibility.Hidden;
            profileBio.Visibility = Visibility.Hidden;
            profileWallpaper.Visibility = Visibility.Hidden;
            userImage.Visibility = Visibility.Hidden;

            botaoEditar.Visibility = Visibility.Hidden;
            botaoEditar.IsEnabled = false;
        }

        private void botaoHome_Click(object sender, RoutedEventArgs e)
        {
            homePage();
        }

        private void profileBio_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.dados.Contas[this.dados.posConta].bio == "")
            {
                profileBio.Text = "Você não tem Bio :(";
            }
        }
    }
}
