namespace timetable 
{
    public class OptionalCourse : Course
    {
        public OptionalCourse(Lecturer lecturer, string name, int atPeriod) 
        {
            this.Lecturer = lecturer;
            this.Name = name;
            this.atPeriod = atPeriod;
                            
            switch(atPeriod) {
                case 0: sortingOrder = 1;
                break;
                case 1: sortingOrder = 2;
                break;
                case 2: sortingOrder = 3;
                break;
                case 15: sortingOrder = 4;
                break;
                case 16: sortingOrder = 5;
                break;
                case 3: sortingOrder = 6;
                break;
                case 4: sortingOrder = 7;
                break;
                case 5: sortingOrder = 8;
                break;
                case 17: sortingOrder = 9;
                break;
                case 18: sortingOrder = 10;
                break;
                case 6: sortingOrder = 11;
                break;
                case 7: sortingOrder = 12;
                break;
                case 8: sortingOrder = 13;
                break;
                case 19: sortingOrder = 14;
                break;
                case 20: sortingOrder = 15;
                break;
                case 9: sortingOrder = 16;
                break;
                case 10: sortingOrder = 17;
                break;
                case 11: sortingOrder = 18;
                break;
                case 21: sortingOrder = 19;
                break;
                case 22: sortingOrder = 20;
                break;
                case 12: sortingOrder = 21;
                break;
                case 13: sortingOrder = 22;
                break;
                case 14: sortingOrder = 23;
                break;
                case 23: sortingOrder = 24;
                break;
                case 24: sortingOrder = 25;
                break;
            }
        }
        private int sortingOrder;
        public int SortingOrder
        {
            get {
                return sortingOrder;
            }
        }
        private int atPeriod;
        public int AtPeriod 
        {
            get {
                return atPeriod;
            }
            set {
                atPeriod = value;
            }
        }
    }
}