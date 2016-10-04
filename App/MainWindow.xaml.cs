using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Controls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTuber {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent(); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Task getList = new Task(Run);
            getList.Start();

        }

        private void Print(List<List<string>> list) {
            foreach (List<string> category in list) {
                foreach (string item in category) {
                    txtConsole.AppendText(item + Environment.NewLine);
                }
            }
        }

        private void Print(List<string> list) {
            foreach (string item in list) {
                txtConsole.AppendText(item + Environment.NewLine);
            }
        }

        private void Print(string str) {
            txtConsole.AppendText(str + Environment.NewLine);
        }

        private async void Run() {
            YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer() {
                ApiKey = "AIzaSyBYRyFkV_PD8ux_9idSwys6dD7Okmsiups",
                ApplicationName = GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "Pewdiepie"; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();
            List<string> channels = new List<string>();
            List<string> playlists = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items) {
                switch (searchResult.Id.Kind) {
                    case "youtube#video":
                        videos.Add($"{searchResult.Snippet.Title} ({searchResult.Id.VideoId})");
                        break;

                    case "youtube#channel":
                        channels.Add($"{searchResult.Snippet.Title} ({searchResult.Id.ChannelId})");
                        break;

                    case "youtube#playlist":
                        playlists.Add($"{searchResult.Snippet.Title} ({searchResult.Id.PlaylistId})");
                        break;
                }
            }

            List<List<string>> result = new List<List<string>>{ videos, channels, playlists };

            Print(result);
        }
    }
}
