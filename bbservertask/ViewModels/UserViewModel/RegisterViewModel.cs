using bbservertask.Commands;
using bbservertask.Helpers;
using bbservertask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace bbservertask.ViewModels.UserViewModel
{
    public class RegisterViewModel : BaseViewModel
    {

        public PasswordBox PasswordBox { get; set; }
        public RelayCommand BackCommand { get; set; }

        public RelayCommand RegisterCommand { get; set; }

        private YoutubeSubscriber youtubeSubscriber;

        public YoutubeSubscriber Subscriber
        {
            get { return youtubeSubscriber; }
            set { youtubeSubscriber = value; OnPropertyChanged(); }
        }



        public RegisterViewModel()
        {
            Subscriber = new YoutubeSubscriber();
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            RegisterCommand = new RelayCommand(c =>
            {
                var subscribers = new List<ISubscriber>();
                var youtubeSubsribers = new List<YoutubeSubscriber>();
                if (File.Exists("subscribers"))
                {
                    subscribers = FileHelper.ReadSubscribers("subscribers").ToList();
                }
                foreach (var item in subscribers)
                {
                    if (item is YoutubeSubscriber subs)
                    {
                        subs.Posts = new List<Post>();
                        youtubeSubsribers.Add(subs);
                    }
                }
                if (!youtubeSubsribers.Any(d => d.Username == Subscriber.Username))
                {
                    Subscriber.Password = PasswordBox.Password;
                    App.Youtuber.Subscribers.Add(Subscriber);
                    FileHelper.WriteSubscribers(App.Youtuber.Subscribers, "subscribers");

                    MessageBox.Show($"You have successfully registered, {Subscriber.Username}");
                    App.MyGrid.Children.RemoveAt(0);
                    App.MyGrid.Children.Add(BackPage);
                }
                else
                {
                    MessageBox.Show($"{Subscriber.Username} has already been taken\nChoose another one!");
                }
            });
        }
    }
}
