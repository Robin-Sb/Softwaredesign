using Newtonsoft.Json;
using System.Collections.Generic;

namespace timetable {
     public class Room {
        public Room (string name, List<Equipment> equipment, int size)
        {
            this.name = name;
            this.equipment = equipment;
            this.size = size;
        }
        string name;
        public string Name 
        {
            get {
                return name;
            } 
            set {
                name = value;
            }
        }
        List<Equipment> equipment = new List<Equipment>();
        public List<Equipment> Equipment 
        {
            get {
                return equipment;
            }
        }
        
        int size;
        public int Size
        {
            get {
                return size;
            } 
            set {
                size = value;
            }
        }
        bool[] occupied = new bool[25];
        [JsonIgnore]
        public bool[] Occupied
        {
            get  {
                return occupied;
            }
        }
    }
}
