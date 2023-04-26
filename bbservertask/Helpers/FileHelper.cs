using bbservertask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace bbservertask.Helpers
{
    public class FileHelper
    {
        public static void WriteSubscribers(List<ISubscriber> subscribers, string fileName)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("subscribers.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, subscribers);
                }
            }
        }

        public static ObservableCollection<ISubscriber> ReadSubscribers(string fileName)
        {
            ObservableCollection<YoutubeSubscriber> subscribers = null;
            var base_subscribers = new ObservableCollection<ISubscriber>();
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{fileName}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    subscribers = serializer.Deserialize<ObservableCollection<YoutubeSubscriber>>(jr);
                }
            }

            foreach (var item in subscribers)
            {
                if (item is ISubscriber)
                {
                    base_subscribers.Add(item);
                }
            }

            return base_subscribers; ;
        }
    }
}
