using System;

namespace CommonLibrary.Adapter
{
    public class YoutubeProfile
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class YoutubeAPI
    {
        public YoutubeProfile GetProfile()
        {
            return new YoutubeProfile
            {
                Username = "saladpuk",
                DisplayName = "Mr.SaladPuk",
                BirthDate = new DateTime(2000, 1, 1),
            };
        }
    }


}
