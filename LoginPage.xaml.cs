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

namespace Twitter_2
{
    /// <summary>
    /// Interação lógica para LoginPage.xam
    /// </summary>
    public partial class LoginPage : Page
    {
        int posConta = 0;

        string pWord;

        string user;

        string name;

        public FeedPage feed;

        Dados dados;
        public LoginPage(Dados dados)
        {
            InitializeComponent();
            this.dados = dados;
            this.dados.Contas.Add(new User()
            {
                username = "lucas",
                name = "Lucas",
                password = "123",
                bio = ""
            });
            
        }

        private void entradaUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.user = entradaUsuario.Text;

        }
        private void entradaSenha_TextChanged(object sender, RoutedEventArgs e)
        {
            this.pWord = entradaSenha.Password;
        }

        private void zerarInput1(object sender, MouseButtonEventArgs e)
        {
            if (entradaUsuario.Text == "Usuário")
            {
                entradaUsuario.Text = "";
            }
        }

        private void zerarInput2(object sender, MouseButtonEventArgs e)
        {
            if (entradaSenha.Password == "Senha")
            {
                entradaSenha.Password = "";
            }
        }

        private void botaoEntrar_Click(object sender, RoutedEventArgs e)
        {
            bool achou = false;
            for (int x = 0; x < this.dados.Contas.Count; x++)
            {
                if (this.dados.Contas[x].username == user && this.dados.Contas[x].password == pWord)
                {
                    achou = true;
                    this.dados.posConta = x;
                    break;
                }
            }

            if (achou)
            {
                this.dados.user = this.user;
                this.dados.password = pWord;

                entradaUsuario.Text = "Usuário";
                entradaSenha.Password = "Senha";

                feed = new FeedPage(this.dados);
                this.NavigationService.Navigate(feed);
            }
            else
            {
                string mensagem = "Conta Inexistente";
                string titulo = "Login";
                MessageBoxButton botao = MessageBoxButton.OK;
                MessageBox.Show(mensagem, titulo, botao);
            }
        }

        private void zerarInput1(object sender, RoutedEventArgs e)
        {
            if (entradaUsuario.Text == "Usuário")
            {
                entradaUsuario.Text = "";
            }
        }

        private void zerarInput2(object sender, RoutedEventArgs e)
        {
            if (entradaSenha.Password == "Senha")
            {
                entradaSenha.Password = "";
            }
        }

        private void entradaUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (entradaUsuario.Text == "")
            {
                entradaUsuario.Text = "Usuário";
            }
        }

        private void entradaSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (entradaSenha.Password == "")
            {
                entradaSenha.Password = "Senha";
            }
        }

        private void criarConta_MouseEnter(object sender, MouseEventArgs e)
        {
            criarConta.Opacity = 0.5;
        }

        private void criarConta_MouseLeave(object sender, MouseEventArgs e)
        {
            criarConta.Opacity = 1;
        }
        private void entradaNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.name = entradaNome.Text;
        }

        private void criarConta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            entradaNome.IsEnabled= true;
            entradaNome.Visibility= Visibility.Visible;
            botaoEntrar.IsEnabled= false;
            botaoEntrar.Visibility= Visibility.Hidden;

            botaoCadastrar.IsEnabled= true;
            botaoCadastrar.Visibility=Visibility.Visible;
        }

        private void zerarInput3(object sender, RoutedEventArgs e)
        {
            if (entradaNome.Text == "Nome")
            {
                entradaNome.Text = "";
            }
        }

        private void entradaNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (entradaNome.Text == "")
            {
                entradaNome.Text = "Nome";
            }
        }

        private void botaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if(entradaNome.Text == "" || entradaUsuario.Text == "" || entradaSenha.Password == "" || entradaNome.Text == "Nome" || entradaUsuario.Text == "Usuário" || entradaSenha.Password == "Senha")
            {
                string msg = "Campos Vazios!!";
                string title = "Login";
                MessageBoxButton btn = MessageBoxButton.OK;
                MessageBoxImage icn = MessageBoxImage.Exclamation;
                MessageBox.Show(msg, title, btn, icn, MessageBoxResult.OK);
            }
            else
            {
                bool achou = false;
                for(int x = 0; x < this.dados.Contas.Count; x++)
                {
                    if (this.dados.Contas[x].username == this.user)
                    {
                        achou = true;
                        break;
                    }
                }

                if (achou)
                {
                    string msg = "Conta já existente!";
                    string title = "Cadastro";
                    MessageBoxButton btn = MessageBoxButton.OK;
                    MessageBoxImage icn = MessageBoxImage.Exclamation;
                    MessageBox.Show(msg, title, btn, icn, MessageBoxResult.OK);
                }
                else
                {
                    string mensagem = "Desejas criar essa conta?";
                    string titulo = "Login";
                    MessageBoxButton botao = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    MessageBoxResult result;
                    result = MessageBox.Show(mensagem, titulo, botao, icon, MessageBoxResult.Yes);
                    
                    if (result == MessageBoxResult.Yes)
                    {   
                        this.dados.Contas.Add(new User { 
                            name= this.name,
                            username=this.user,
                            password=this.pWord
                        });

                        entradaNome.IsEnabled = false;
                        entradaNome.Visibility = Visibility.Hidden;
                        botaoEntrar.IsEnabled = true;
                        botaoEntrar.Visibility = Visibility.Visible;

                        botaoCadastrar.IsEnabled = false;
                        botaoCadastrar.Visibility = Visibility.Hidden;

                        entradaUsuario.Text = "Usuário";
                        entradaSenha.Password = "Senha";
                        entradaNome.Text = "Nome";
                    }
                    else
                    {
                        entradaNome.IsEnabled = false;
                        entradaNome.Visibility = Visibility.Hidden;
                        botaoEntrar.IsEnabled = true;
                        botaoEntrar.Visibility = Visibility.Visible;

                        botaoCadastrar.IsEnabled = false;
                        botaoCadastrar.Visibility = Visibility.Hidden;

                        entradaUsuario.Text= "Usuário";
                        entradaSenha.Password= "Senha";
                        entradaNome.Text= "Nome";
                    }
                }
            }
        }

        private void entradaSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(botaoEntrar.IsEnabled == true)
                {
                    botaoEntrar.Focus();
                }else if(botaoCadastrar.IsEnabled == true) {
                    botaoCadastrar.Focus();
                }
            }
        }
    }
}
