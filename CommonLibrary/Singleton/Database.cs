using System;

namespace CommonLibrary.Singleton
{
    public class Database
    {
        private static Database instance;
        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        private Database()
        {
        }

        public void Query(string cmd)
        {
            Console.WriteLine($"Query: {cmd}");
        }
    }
}
