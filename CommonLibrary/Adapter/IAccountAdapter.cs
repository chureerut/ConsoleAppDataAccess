using System;

namespace CommonLibrary.Adapter
{
    public class AccountInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public interface IAccountAdapter
    {
        AccountInfo GetAccountInfo();
    }
    public class YoutubeAdapter : IAccountAdapter
    {
        private YoutubeAPI adaptee = new YoutubeAPI();
        public AccountInfo GetAccountInfo()
        {
            var profile = adaptee.GetProfile();
            var age = new DateTime() + (DateTime.Now - profile.BirthDate);
            return new AccountInfo
            {
                Id = profile.Username,
                Name = profile.DisplayName,
                Age = age.Year,
            };
        }
    }
}
