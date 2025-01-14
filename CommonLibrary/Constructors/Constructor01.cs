namespace CommonLibrary.Constructors
{
    //Copy Constructor
    public class Constructor01
    {
        //Constructor       

        private string month;
        private int year;

        // declaring Copy constructor
        public Constructor01(Constructor01 s)
        {
            month = s.month;
            year = s.year;
        }

        // Instance constructor
        public Constructor01(string month, int year)
        {
            this.month = month;
            this.year = year;
        }
        // Get details of Constructor01
        public string Details
        {
            get
            {
                return "Month: " + month.ToString() +
                         "\nYear: " + year.ToString();
            }
        }

    }
}
