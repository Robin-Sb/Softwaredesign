namespace timetable {
    public sealed class NumberGenerator {
        private static NumberGenerator generator = null;
        private static readonly object padlock = new object();

        int number = 0;

        private NumberGenerator() {}

        public static NumberGenerator Generator {
            get {
                lock (padlock)
                {
                    if (generator==null)
                    {
                        generator = new NumberGenerator();
                    }
                    return generator;
                }
            }
        }

        public int GetNumber() 
        {
            number++;
            return number;
        }
    
    }
}