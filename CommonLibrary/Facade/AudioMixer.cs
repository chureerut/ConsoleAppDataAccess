using System.IO;

namespace CommonLibrary.Facade
{
    public class AudioMixer
    {
        public bool CanEnhancement(Stream file)
        {
            // Check the video
            return true;
        }
        public Stream EnhanceAudio(Stream file)
        {
            // Compress file
            return file;
        }
    }
}
