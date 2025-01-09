using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Factory
{
    public abstract class Logistics
    {
        public string PlanDelivery()
        {
            var product = CreateTransport();
            return $"Logistics: The same creator's code has just worked with {product.Deliver()}";
        }

        public abstract ITransport CreateTransport();
    }
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Truck();
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport() => new Ship();
    }
}
