using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
