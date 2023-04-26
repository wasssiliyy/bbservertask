using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbservertask.Models
{
    public class Youtuber
    {
        public bool IsFirstTime { get; set; }
        public List<Post> Posts { get; set; }

        public List<ISubscriber> Subscribers { get; set; }

        public Youtuber()
        {
            Subscribers = new List<ISubscriber>();
        }

        public void NotifyAllUsers(Post post)
        {
            foreach (var subscriber in Subscribers)
            {
                if (subscriber is YoutubeSubscriber sB)
                {
                    sB.Posts.Add(post);
                }
            }
        }
    }
}
