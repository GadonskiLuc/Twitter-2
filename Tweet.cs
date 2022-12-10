using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter_2
{
    public class Tweet
    {
        //bem autoexplicativo mas n consegui fazer funcionar a tempo
        string tweet;

        DateTime data;

        public Tweet(string tweet, DateTime data)
        {
            this.tweet = tweet;
            this.data = data;
        }
    }
}
