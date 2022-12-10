using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        //aqui é onde a mágica acontece, ou aconteceria. aqui você poderá ver
        //editar e excluir sua conta se quiser
        //tweets serão habilitados numa atualização futura ;) (juro.)

        Dados dados;

        string name;
        
        string bio;

        string tweet;

        ImageBrush avatar;

        ImageBrush wallpaper;

        public FeedPage(Dados dados)
        {
            InitializeComponent();
            this.dados = dados;
            homePage();
        }
        //sai da feedPage e te leva para a pagina de login
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

        //isso aqui da até preguiça de explicar
        private void perfilPage()
        {
            //primeiro ele desabilita os botoes da homepage
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
            comingSoon.Visibility = Visibility.Hidden;
            comingSoon_Copy.Visibility = Visibility.Hidden;
            //poucos grazadeus

            homeAvatar.Visibility = Visibility.Hidden;
            homeLabel.Visibility = Visibility.Hidden;
            entradaTweet.Visibility = Visibility.Hidden;
            botaoTweet.Visibility = Visibility.Hidden;
            divisor.Visibility = Visibility.Hidden;

            botaoSalvar.Visibility = Visibility.Hidden;
            botaoSalvar.IsEnabled = false;
            botaoCancelar.Visibility = Visibility.Hidden;
            botaoCancelar.IsEnabled = false;
            botaoTweetar.Visibility = Visibility.Hidden;

            //depois ele habilita os da profilePage (quem diria)

            botaoEditar.IsEnabled = true;
            botaoHome.IsEnabled = true;
            botaoPerfil.IsEnabled = true;
            botaoSair.IsEnabled = true;
            botaoExcluir.Visibility = Visibility.Visible;

            //aqui ele define os dados de perfil que serão exibidos

            labelNome.Content = this.dados.Contas[this.dados.posConta].name;//nome
            labelUser.Content = $"@{this.dados.Contas[this.dados.posConta].username}";//username

            //foto de perfil, se não tiver, você será presenteado com uma bela
            //foto do professor Heisenberg
            if (this.dados.Contas[this.dados.posConta].avatar != null)
            {
                userImage.Fill = this.dados.Contas[this.dados.posConta].avatar;
            }
            //wallpaper, se não tiver, você será presenteado com um belo
            //wallpapor do shrek
            if (this.dados.Contas[this.dados.posConta].wallpaper != null)
            {
                profileWallpaper.Fill = this.dados.Contas[this.dados.posConta].wallpaper;
            }
            //biografia, se você não tiver, o app irá avisá-lo
            if (this.dados.Contas[this.dados.posConta].bio == "")
            {
                profileBio.Text = "Você não tem Bio :(";
            }
            else
            {
                profileBio.Text = this.dados.Contas[this.dados.posConta].bio;
            }
        }
        //mesma coisa só que ao contrário
        private void homePage()
        {
            //desativa os botões da profilePage
            labelNome.Visibility = Visibility.Hidden;
            labelUser.Visibility = Visibility.Hidden;
            profileBio.Visibility = Visibility.Hidden;
            profileWallpaper.Visibility = Visibility.Hidden;
            userImage.Visibility = Visibility.Hidden;
            botaoExcluir.Visibility = Visibility.Hidden;
            botaoEditar.Visibility = Visibility.Hidden;
            botaoEditar.IsEnabled = false;
            //ativa os da homePage
            comingSoon.Visibility = Visibility.Visible;
            comingSoon_Copy.Visibility = Visibility.Visible;
            homeAvatar.Visibility = Visibility.Visible;
            homeLabel.Visibility = Visibility.Visible;
            entradaTweet.Visibility= Visibility.Visible;
            divisor.Visibility = Visibility.Visible;
            botaoTweet.Visibility = Visibility.Visible;
            botaoTweetar.Visibility = Visibility.Visible;
            botaoTweetar.IsEnabled = true;

            //define o avatar da home
            if(this.dados.Contas[this.dados.posConta].avatar != null)
            {
                homeAvatar.Fill = this.dados.Contas[this.dados.posConta].avatar;
            }
        }
        //aqui ele abre a janelinha de édição de perfil
        private void editarPerfil()
        {
            //ativa todos os componentes de edição
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
            botaoSalvar.Visibility = Visibility.Visible;
            botaoSalvar.IsEnabled = true;
            botaoCancelar.Visibility = Visibility.Visible;
            botaoCancelar.IsEnabled = true;

            //desativa os botões laterais por motivos de segurança :)
            botaoEditar.IsEnabled = false;
            botaoHome.IsEnabled = false;
            botaoPerfil.IsEnabled = false;
            botaoSair.IsEnabled = false;
            botaoTweetar.IsEnabled = false;

            //define os dados que aparecerão nos inputs

            entradaNome.Text = this.dados.Contas[this.dados.posConta].name;//nome
            entradaBio.Text = this.dados.Contas[this.dados.posConta].bio;//bio

            //foto de perfil
            if (this.dados.Contas[this.dados.posConta].avatar != null)
            {
                userImage_Editing.Fill = this.dados.Contas[this.dados.posConta].avatar;
            }
            //wallpaper
            if (this.dados.Contas[this.dados.posConta].wallpaper != null)
            {
                profileWallpaper_Editing.Fill = this.dados.Contas[this.dados.posConta].wallpaper;
            }
        }
        //botão pra mudar a foto de perfil
        private void botaoAvatar_Click(object sender, RoutedEventArgs e)
        {
            //abre uma janela de explorador de arquivos
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.png;*.jpg;*.jpeg";
            openDialog.FilterIndex = 1;
            ImageBrush brush = new ImageBrush();

            //define a foto selecionada como avatar
            if(openDialog.ShowDialog() == true)
            {
                brush.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
                userImage_Editing.Fill = brush;
                this.avatar = brush;
            }
        }
        //mesma coisa só que para o wallpaper
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

        //salva todas as alterações no perfil
        private void botaoSalvar_Click(object sender, RoutedEventArgs e)
        {
            //gera uma caixa de mensagem
            string mensagem = "Tem Certeza?";
            string titulo = "Confirmação";
            MessageBoxButton botao = MessageBoxButton.YesNo;
            MessageBoxResult resultado;
            resultado = MessageBox.Show(mensagem, titulo, botao, MessageBoxImage.None, MessageBoxResult.No);
            
            //checa a resposta
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

                //volta para a pagina de perfil
                perfilPage();
            }
        }
        //método de tweet, mas não faz nada pois não consegui acher um jeito de 
        //mostrar os tweets na tela a tempo
        private void botaoTweet_Click(object sender, RoutedEventArgs e)
        {
            if (entradaTweet.Text != "")
            {
                this.tweet = entradaTweet.Text;
                this.dados.Contas[this.dados.posConta].tweets.Add(new Tweet(this.tweet, DateTime.Now));
            }
            else
            {   //se o input estiver vazio ele avisa
                string mensagem = "Entrada vazia ou inválida!";
                string titulo = "Tweet";
                MessageBoxButton botao = MessageBoxButton.OK;
                MessageBox.Show(mensagem, titulo, botao);
            }
        }
        //botão que exclui sua conta :,(
        private void botaoExcluir_Click(object sender, RoutedEventArgs e)
        {
            //cria uma caixa de dialogo para confirmar a exclusão
            string mensagem = "Tem Certeza?";
            string titulo = "Confirmação";
            MessageBoxButton botao = MessageBoxButton.YesNo;
            MessageBoxResult resultado;
            resultado = MessageBox.Show(mensagem, titulo, botao, MessageBoxImage.None, MessageBoxResult.No);

            //se confirmada, ele exclui sua conta e te leva pra pagina de Login
            if (resultado == MessageBoxResult.Yes)
            {
                this.dados.Contas.RemoveAt(this.dados.posConta);
                this.NavigationService.Navigate(new LoginPage(this.dados));
            }
        }

        private void botaoHome_Click(object sender, RoutedEventArgs e)
        {
            homePage();
        }
        private void botaoPerfil_Click(object sender, RoutedEventArgs e)
        {
            perfilPage();

        }

        private void botaoEditar_Click(object sender, RoutedEventArgs e)
        {
            editarPerfil();
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

        private void botaoAvatar_MouseEnter(object sender, MouseEventArgs e)
        {
            botaoAvatar.Opacity = 0.5;
        }

        private void botaoTweetar_Click(object sender, RoutedEventArgs e)
        {
            entradaTweet.Focus();
        }

        private void entradaNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if(entradaNome.Text == "")
            {
                entradaNome.Text = this.dados.Contas[this.dados.posConta].name;
            }
        }

        private void entradaTweet_GotFocus(object sender, RoutedEventArgs e)
        {
            if(entradaTweet.Text == "O que ta rolando?")
            {
                entradaTweet.Text = "";
            }
        }

        private void entradaTweet_LostFocus(object sender, RoutedEventArgs e)
        {
            if (entradaTweet.Text == "")
            {
                entradaTweet.Text = "O que ta rolando?";
            }
        }
    }
}
