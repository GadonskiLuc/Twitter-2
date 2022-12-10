using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Twitter_2
{
    public class User
    {
        //classe que guardará os dados de cada usuário
        public string username { get; set; } = "";
        public string name { get; set; } = "";
        public string password { get; set; } = "";
        public string bio { get; set; } = "";
        public ImageBrush wallpaper { get; set; }
        public ImageBrush avatar { get; set; }

        public List<Tweet> tweets = new List<Tweet>();
    }
}
