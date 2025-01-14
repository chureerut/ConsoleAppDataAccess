using System.Collections.Generic;

namespace CommonLibrary.Observer
{
    public class SchoolMessager
    {
        private IList<ISubscriber> subscribers;

        public SchoolMessager()
            => subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber newSubscriber)
            => subscribers.Add(newSubscriber);

        public void Unsubscribe(ISubscriber newSubscriber)
            => subscribers.Remove(newSubscriber);

        public void SendMessage(string msg)
        {
            foreach (var it in subscribers)
            {
                it.Update(msg);
            }
        }
    }
}
