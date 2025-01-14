using System.IO;

namespace CommonLibrary.Facade
{
    public class FileUploader
    {
        public string UploadVideo(Stream file)
        {
            // Upload it to the server
            return "UC6fBbrBB4dF7WznwLmfbOnQ";
        }

        public string GetVideoUrlById(string id)
        {
            // Search the video from its id
            return $"https://www.youtube.com/channel/{id}";
        }
    }
}
