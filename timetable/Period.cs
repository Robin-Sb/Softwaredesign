using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace timetable {
    public class Period {
        [JsonConstructor]
        public Period(string startTime, string endTime, string weekday, int number) 
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.weekday = weekday;
            this.number = number;
        }
        public Period () 
        {
            switch(increment) {
                case 0: startTime = "7:45";
                        endTime = "9:15";
                        weekday = "monday";
                break;
                case 1: startTime = "9:30";
                        endTime = "11:00";
                        weekday = "monday";
                break;
                case 2: startTime = "11:15";
                        endTime = "12:45";
                        weekday = "monday";
                break;
                case 15: startTime = "14:00";
                        endTime = "15:30";
                        weekday = "monday";
                break;
                case 16: startTime = "15:45";
                        endTime = "17:15";
                        weekday = "monday";
                break;
                case 3: startTime = "7:45";
                        endTime = "9:15";
                        weekday = "tuesday";
                break;
                case 4: startTime = "9:30";
                        endTime = "11:00";
                        weekday = "tuesday";
                break;
                case 5: startTime = "11:15";
                        endTime = "12:45";
                        weekday = "tuesday";
                break;
                case 17: startTime = "14:00";
                        endTime = "15:30";
                        weekday = "tuesday";
                break;
                case 18: startTime = "15:45";
                        endTime = "17:15";
                        weekday = "tuesday";
                break;
                case 6: startTime = "7:45";
                        endTime = "9:15";
                        weekday = "wednesday";
                break;
                case 7: startTime = "9:30";
                        endTime = "11:00";
                        weekday = "wednesday";
                break;
                case 8: startTime = "11:15";
                        endTime = "12:45";
                        weekday = "wednesday";
                break;
                case 19: startTime = "14:00";
                        endTime = "15:30";
                        weekday = "wednesday";
                break;
                case 20: startTime = "15:45";
                        endTime = "17:15";
                        weekday = "wednesday";
                break;
                case 9: startTime = "7:45";
                        endTime = "9:15";
                        weekday = "thursday";
                break;
                case 10: startTime = "9:30";
                        endTime = "11:00";
                        weekday = "thursday";
                break;
                case 11: startTime = "11:15";
                        endTime = "12:45";
                        weekday = "thursday";
                break;
                case 21: startTime = "14:00";
                        endTime = "15:30";
                        weekday = "thursday";
                break;
                case 22: startTime = "15:45";
                        endTime = "17:15";
                        weekday = "thursday";
                break;
                case 12: startTime = "7:45";
                        endTime = "9:15";
                        weekday = "friday";
                break;
                case 13: startTime = "9:30";
                        endTime = "11:00";
                        weekday = "friday";
                break;
                case 14: startTime = "11:15";
                        endTime = "12:45";
                        weekday = "friday";
                break;
                case 23: startTime = "14:00";
                        endTime = "15:30";
                        weekday = "friday";
                break;
                case 24: startTime = "15:45";
                        endTime = "17:15";
                        weekday = "friday";
                break;
            }
            number = increment;
            increment++;
        }
        string startTime;
        public string StartTime 
        {
            get {
                return startTime;
            }
        }
        string endTime;
        public string EndTime 
        {
            get {
                return endTime;
            }
        }

        string weekday;
        public string Weekday 
        {
            get {
                return weekday;
            }
        }
        static int increment = 0;
        int number;
        public int Number 
        {
            get {
                return number;
            }
        }
        private List<SchedulableElement> elements;
        public List<SchedulableElement> Elements
        {
            get {
                return elements;
            }
            set {
                elements = value;
            }
        }

        private List<int> removedElements = new List<int>();
        [JsonIgnore]
        public List<int> RemovedElements
        {
            get {
                return removedElements;
            }
            set {
                removedElements = value;
            }
        }

    }
}
