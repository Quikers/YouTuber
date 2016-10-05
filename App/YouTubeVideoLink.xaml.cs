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

namespace YouTuber {
    /// <summary>
    /// Interaction logic for YouTubeVideoLink.xaml
    /// </summary>
    public partial class YouTubeVideoLink : UserControl {
        public Image  Thumbnail   { get; set; }
        public string Title       { get; set; }
        public string Channel     { get; set; }
        public string DateViews   { get; set; }
        public string Description { get; set; }

        public YouTubeVideoLink(Image thumbnail, string title, string channel, string dateViews, string description) {
            Thumbnail = thumbnail;
            Title = title;
            Channel = channel;
            DateViews = dateViews;
            Description = description;

            InitializeComponent();
        }
    }
}
