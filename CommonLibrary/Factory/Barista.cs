using System;

namespace CommonLibrary.Factory
{
    public class Barista
    {
        private BeverageFactory _factory = new BeverageFactory();
        public Beverage order(string beverageType)
        {
            Beverage beverage = _factory.createBeverage(beverageType);
            return beverage;
        }
    }
    public class BeverageFactory
    {
        public Beverage createBeverage(string beverageType)
        {
            switch (beverageType.ToLower()) // to handle case sensitivity
            {
                case "coffee":
                    return new Coffee();
                case "greentea":
                    return new Greentea();
                case "cola":
                    return new Cola();
                default:
                    throw new ArgumentException("Unknown beverage type: " + beverageType);
            }
        }
    }

}
