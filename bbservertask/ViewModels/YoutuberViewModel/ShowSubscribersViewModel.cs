using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbservertask.ViewModels.YoutuberViewModel
{
    public class ShowSubscribersViewModel : BaseViewModel
    {

        private string subscriberCount;

        public string SubscriberCount
        {
            get { return subscriberCount; }
            set { subscriberCount = value; }
        }

        public List<ISubscriber> Subscribers { get; set; }

        public ObservableCollection<YoutubeSubscriber> YoutubeSubscribers { get; set; }

        public RelayCommand BackCommand { get; set; }
        public ShowSubscribersViewModel()
        {
            BackPage = App.MyGrid.Children[0];

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });
        }

        public void InitializeProperties()
        {
            YoutubeSubscribers = new ObservableCollection<YoutubeSubscriber>();
            foreach (var item in Subscribers)
            {
                if (item is YoutubeSubscriber yS)
                {
                    YoutubeSubscribers.Add(yS);
                }
            }
            SubscriberCount = YoutubeSubscribers.Count.ToString() + " subscribers";
        }
    }
}
