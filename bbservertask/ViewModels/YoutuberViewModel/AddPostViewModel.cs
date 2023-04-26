using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbservertask.ViewModels.YoutuberViewModel
{
    public class AddPostViewModel : BaseViewModel
    {
        public RelayCommand ChooseImageCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public RelayCommand ShareCommand { get; set; }

        private string confirmImage;

        public string ConfirmImage
        {
            get { return confirmImage; }
            set { confirmImage = value; OnPropertyChanged(); }
        }


        private string selectedImage;

        public string SelectedImage
        {
            get { return selectedImage; }
            set { selectedImage = value; OnPropertyChanged(); }
        }


        private Post post;

        public Post Post
        {
            get { return post; }
            set { post = value; OnPropertyChanged(); }
        }




        public AddPostViewModel()
        {
            ConfirmImage = $"/Images/cross.png";
            ChooseImageCommand = new RelayCommand(c =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    var file = openFileDialog.FileName;
                    if (file.EndsWith(".jpg") || file.EndsWith(".png"))
                    {
                        Post = new Post();
                        Post.ImagePath = file;
                        SelectedImage = file;
                    }
                    else
                    {
                        MessageBox.Show("Picture in wrong format - .jpg or .png", "Info", System.Windows.MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
            });

            ShareCommand = new RelayCommand(c =>
            {
                App.Youtuber.NotifyAllUsers(Post);
                ConfirmImage = $"/Images/tick.png";
                FileHelper.WriteSubscribers(App.Youtuber.Subscribers, "subscribers");
                MessageBox.Show("Shared Successfully");
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

        }
    }
}
