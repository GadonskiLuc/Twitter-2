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
        public int posConta = 0;

        string pWord;

        public string user;

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
            feed = new FeedPage(this.dados);
        }

        private void entradaUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.user = entradaUsuario.Text;

        }
        private void entradaSenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.pWord = entradaSenha.Text;
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
            if (entradaSenha.Text == "Senha")
            {
                entradaSenha.Text = "";
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
                    dados.posConta = x;
                    break;
                }
            }

            if (achou)
            {
                this.dados.user = this.user;
                this.dados.password = pWord;
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
    }
}
