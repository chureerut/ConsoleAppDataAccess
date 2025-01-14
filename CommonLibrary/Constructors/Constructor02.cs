namespace CommonLibrary.Constructors
{
    //Private Constructor
    public class Constructor02
    {
        // declare private Constructor
        private Constructor02()
        {
        }

        // declare static variable field
        public static int count_geeks { get; set; }

        // declare static method
        public static int geeks_Count()
        {
            return ++count_geeks;
        }
    }
}
