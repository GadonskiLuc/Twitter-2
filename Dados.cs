using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_2
{
    public class Dados
    {
        public string user;
        public string password;
        public string name;
        public string bio;
        public int posConta = 0;

        public List<User> Contas = new List<User>();
    }
}
