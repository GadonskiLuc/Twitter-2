using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Twitter_2
{
    public class Dados
    {
        //simula um banco de dados pq eu n consegui aprender a fazer o app
        //se comunicar com um banco real kkkj (tristeza)
        public string user { get; set; } = "";
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string bio { get; set; } = "";
        public ImageBrush wallpaper { get; set; }
        public ImageBrush avatar { get; set; }  

        public int posConta = 0;

        public List<User> Contas = new List<User>();
    }
}
