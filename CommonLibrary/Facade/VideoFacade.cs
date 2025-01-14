using System.IO;

namespace CommonLibrary.Facade
{
    public class VideoFacade
    {
        public string UploadVideoAndGetUrl(Stream file)
        {
            var compressor = new VideoCompressionCodec();
            var compressedSteam = compressor.CompressFile(file);
            var audio = new AudioMixer();
            var canEnhance = audio.CanEnhancement(compressedSteam);
            if (canEnhance)
            {
                compressedSteam = audio.EnhanceAudio(compressedSteam);
            }
            var uploader = new FileUploader();
            var videoId = uploader.UploadVideo(compressedSteam);
            var url = uploader.GetVideoUrlById(videoId);
            return url;
        }
    }
}
