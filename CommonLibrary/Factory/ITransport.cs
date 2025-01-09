using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Factory
{
    public interface ITransport
    {
        string Deliver();
    }

    public class Truck : ITransport
    {
        public string Deliver() => "Trucks deliver cargo by land.";
    }
    public class Ship : ITransport
    {
        public string Deliver() => "Ships deliver cargo by sea.";
    }
}
