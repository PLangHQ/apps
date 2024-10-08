using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using PLang.Modules;
using System.ComponentModel;
using System.Threading.Tasks;

namespace YoutubeModule
{
    [Description("I want to be able to upload a video to youtube(set name, description, playlist, public/private, etc), get list of my videos, remove a video. Also monitor for change in the upload on a variable")]
    public class Program : BaseProgram
    {
        private readonly YouTubeService _youtubeService;

        public Program(ISettings settings, ILogger logger) : base()
        {
            var credential = GoogleCredential.FromFile(settings.Get<string>("YouTubeCredentialPath", "", "Path to the YouTube API credentials file"))
                .CreateScoped(YouTubeService.Scope.Youtube);

            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YoutubeModule"
            });
        }

        /*
         * plang: - upload file.mp4, "My first video", "I am doing my first video.....", put on "default" playlist, make it public and update %status% on the progress
         */
        public async Task UploadVideo(string filePath, string title, string description, string playlist, string privacyStatus, string statusVariable)
        {
            var video = new Video
            {
                Snippet = new VideoSnippet
                {
                    Title = title,
                    Description = description,
                    Tags = new string[] { "tag1", "tag2" },
                    CategoryId = "22" // See https://developers.google.com/youtube/v3/docs/videoCategories/list
                },
                Status = new VideoStatus
                {
                    PrivacyStatus = privacyStatus // "public", "private" or "unlisted"
                }
            };

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = _youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += (progress) =>
                {
                    settings.Set(statusVariable, progress.Status.ToString());
                };
                await videosInsertRequest.UploadAsync();
            }

            if (!string.IsNullOrEmpty(playlist))
            {
                var newPlaylistItem = new PlaylistItem
                {
                    Snippet = new PlaylistItemSnippet
                    {
                        PlaylistId = playlist,
                        ResourceId = new ResourceId
                        {
                            Kind = "youtube#video",
                            VideoId = video.Id
                        }
                    }
                };
                await _youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();
            }
        }

        /*
         * plang: - get all videos, write to %videos%
         */
        public async Task<string> GetAllVideos()
        {
            var searchListRequest = _youtubeService.Search.List("snippet");
            searchListRequest.MaxResults = 50;
            searchListRequest.ForMine = true;
            searchListRequest.Type = "video";

            var searchListResponse = await searchListRequest.ExecuteAsync();

            var videos = searchListResponse.Items;
            return string.Join(", ", videos.Select(v => v.Snippet.Title));
        }

        /*
         * plang: - get all videos in my "default" playlist
         */
        public async Task<string> GetVideosInPlaylist(string playlistId)
        {
            var playlistItemsListRequest = _youtubeService.PlaylistItems.List("snippet");
            playlistItemsListRequest.PlaylistId = playlistId;
            playlistItemsListRequest.MaxResults = 50;

            var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

            var videos = playlistItemsListResponse.Items;
            return string.Join(", ", videos.Select(v => v.Snippet.Title));
        }
    }
}
