using System.Collections.Generic;

namespace CommonLibrary.Builder
{
    public interface IHouseBuilder
    {
        void BuildWalls();
        void BuildDoors();
        void BuildSwimmingPool();
        IProduct GetHouse();
    }
    public class WoodenHouseBuilder : IHouseBuilder
    {
        private House house = new House { Parts = new List<string>() };

        public void BuildWalls()
            => house.Parts.Add("Created wooden walls");
        public void BuildDoors()
            => house.Parts.Add("Created wooden doors");
        public void BuildSwimmingPool()
            => house.Parts.Add("Created wooden swimming pool");
        public IProduct GetHouse()
            => house;
    }
    public class BrickHouseBuilder : IHouseBuilder
    {
        private House house = new House { Parts = new List<string>() };

        public void BuildWalls()
            => house.Parts.Add("Created brick walls");
        public void BuildDoors()
            => house.Parts.Add("Created brick doors");
        public void BuildSwimmingPool()
            => house.Parts.Add("Created brick swimming pool");
        public IProduct GetHouse()
            => house;
    }
}
