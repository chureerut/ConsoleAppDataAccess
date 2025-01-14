namespace CommonLibrary.Builder
{
    public class HouseDirector
    {
        private IHouseBuilder builder;

        public HouseDirector(IHouseBuilder builder)
            => this.builder = builder;

        public void BuildHouse()
        {
            builder.BuildWalls();
            builder.BuildDoors();
        }

        public void BuildHouseWithSwimmingPool()
        {
            builder.BuildWalls();
            builder.BuildDoors();
            builder.BuildSwimmingPool();
        }
    }
}
