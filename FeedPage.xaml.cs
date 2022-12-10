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
using Microsoft.Win32;

namespace Twitter_2
{
    /// <summary>
    /// Interação lógica para FeedPage.xam
    /// </summary>
    public partial class FeedPage : Page
    {
        Dados dados;

        string name;
        
        string bio;

        ImageBrush avatar;

        ImageBrush wallpaper;

        public FeedPage(Dados dados)
        {
            InitializeComponent();
            homePage();
            this.dados = dados;

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
                this.NavigationService.Navigate(new LoginPage(this.dados));
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

            editBox.Visibility = Visibility.Hidden;
            entradaNome.Visibility = Visibility.Hidden;
            nameEditing.Visibility = Visibility.Hidden;
            entradaBio.Visibility = Visibility.Hidden;
            bioEditing.Visibility = Visibility.Hidden;
            profileWallpaper_Editing.Visibility = Visibility.Hidden;
            userImage_Editing.Visibility = Visibility.Hidden;
            botaoAvatar.Visibility = Visibility.Hidden;
            botaoAvatar.IsEnabled = false;
            botaoWallpaper.Visibility = Visibility.Hidden;
            botaoWallpaper.IsEnabled = false;

            botaoSalvar.Visibility = Visibility.Hidden;
            botaoSalvar.IsEnabled = false;
            botaoCancelar.Visibility = Visibility.Hidden;
            botaoCancelar.IsEnabled = false;

            botaoEditar.IsEnabled = true;
            botaoHome.IsEnabled = true;
            botaoPerfil.IsEnabled = true;
            botaoSair.IsEnabled = true;
            botaoTweet.IsEnabled= true;

            labelNome.Content = this.dados.Contas[this.dados.posConta].name;
            labelUser.Content = $"@{this.dados.Contas[this.dados.posConta].username}";
            
            if(this.dados.Contas[this.dados.posConta].avatar != null)
            {
                userImage.Fill = this.dados.Contas[this.dados.posConta].avatar;
            }

            if (this.dados.Contas[this.dados.posConta].wallpaper != null)
            {
                profileWallpaper.Fill = this.dados.Contas[this.dados.posConta].wallpaper;
            }

            if (this.dados.Contas[this.dados.posConta].bio == "")
            {
                profileBio.Text = "Você não tem Bio :(";
            }
            else
            {
                profileBio.Text = this.dados.Contas[this.dados.posConta].bio;
            }
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

        private void botaoEditar_Click(object sender, RoutedEventArgs e)
        {
            editarPerfil();
        }

        private void editarPerfil()
        {
            editBox.Visibility = Visibility.Visible;
            entradaNome.Visibility = Visibility.Visible;
            nameEditing.Visibility = Visibility.Visible;
            entradaBio.Visibility = Visibility.Visible;
            bioEditing.Visibility = Visibility.Visible;
            profileWallpaper_Editing.Visibility = Visibility.Visible;
            userImage_Editing.Visibility = Visibility.Visible;
            botaoAvatar.Visibility = Visibility.Visible;
            botaoAvatar.IsEnabled = true;
            botaoWallpaper.Visibility= Visibility.Visible;
            botaoWallpaper.IsEnabled= true;

            botaoEditar.IsEnabled = false;
            botaoHome.IsEnabled = false;
            botaoPerfil.IsEnabled = false;
            botaoSair.IsEnabled = false;
            botaoTweet.IsEnabled = false;


            botaoSalvar.Visibility = Visibility.Visible;
            botaoSalvar.IsEnabled = true;
            botaoCancelar.Visibility = Visibility.Visible;
            botaoCancelar.IsEnabled = true;

            entradaNome.Text = this.dados.Contas[this.dados.posConta].name;
            entradaBio.Text = this.dados.Contas[this.dados.posConta].bio;

            if (this.dados.Contas[this.dados.posConta].avatar != null)
            {
                userImage_Editing.Fill = this.dados.Contas[this.dados.posConta].avatar;
            }

            if (this.dados.Contas[this.dados.posConta].wallpaper != null)
            {
                profileWallpaper_Editing.Fill = this.dados.Contas[this.dados.posConta].wallpaper;
            }
        }

        private void entradaBio_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.bio = entradaBio.Text;
        }

        private void entradaUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.name = entradaNome.Text;
        }

        private void botaoCancelar_Click(object sender, RoutedEventArgs e)
        {
            perfilPage();
        }
        private void botaoAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.png;*.jpg;*.jpeg";
            openDialog.FilterIndex = 1;
            ImageBrush brush = new ImageBrush();

            if(openDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
                userImage_Editing.Fill = brush;
                this.avatar = brush;
            }
        }

        private void botaoSalvar_Click(object sender, RoutedEventArgs e)
        {
            string mensagem = "Tem Certeza?";
            string titulo = "Confirmação";
            MessageBoxButton botao = MessageBoxButton.YesNo;
            MessageBoxResult resultado;
            resultado = MessageBox.Show(mensagem, titulo, botao, MessageBoxImage.None, MessageBoxResult.No);
            
            if(resultado == MessageBoxResult.Yes)
            {
                this.dados.Contas[this.dados.posConta].name = this.name;
                this.dados.Contas[this.dados.posConta].bio = this.bio;

                if (this.avatar != null)
                {
                    this.dados.Contas[this.dados.posConta].avatar = this.avatar;
                    userImage.Fill = this.avatar;
                }

                if (this.wallpaper != null)
                {
                    this.dados.Contas[this.dados.posConta].wallpaper = this.wallpaper;
                    profileWallpaper.Fill = this.wallpaper;
                }

                labelNome.Content = this.name;
                profileBio.Text = this.bio;

                perfilPage();
            }
        }

        private void botaoAvatar_MouseEnter(object sender, MouseEventArgs e)
        {
            botaoAvatar.Opacity = 0.5;
        }

        private void botaoWallpaper_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.png;*.jpg;*.jpeg";
            openDialog.FilterIndex = 1;
            ImageBrush brush = new ImageBrush();

            if (openDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
                profileWallpaper_Editing.Fill = brush;
                this.wallpaper = brush;
            }
        }
    }
}
