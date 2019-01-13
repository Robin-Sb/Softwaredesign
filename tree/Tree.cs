using System;
using System.Collections.Generic;

namespace tree
{
    public class Tree <T>
    {
        public Tree() {}
        public Tree (T type) {
            this.type = type;
        }
        public T type;
        public T parent;
        public List<Tree<T>> children = new List<Tree<T>>();
        public static bool calledFirstTime = true; 
        public Tree<T> CreateNode(T element) 
        {
            Tree<T> node = new Tree<T>(element);
            return node;
        }
        public void AppendChild(Tree<T> child)
        {
            child.parent = this.type;
            children.Add(child);    
        }
        public void RemoveChild(Tree<T> child)
        {
            children.Remove(child);
        }

        public void PrintTree(int generation = 0) 
        {
            if (calledFirstTime)
            {
                Console.WriteLine(this.ToString());
            }

            calledFirstTime = false;
            generation++;
            for (int i = 0; i < children.Count; i++)
            {
                Console.WriteLine(ToStars(generation) + children[i].ToString());
                children[i].PrintTree(generation);
            }
        }

        public void ForEachNode(Action<string> function) 
        {
            if (calledFirstTime)
            {
                Console.Write(this.ToString()  + " | ");
            }

            calledFirstTime = false;

            for (int i = 0; i < children.Count; i++) 
            {
                function(children[i].ToString());
                children[i].ForEachNode(function);
            }
        }

        public void SetFirstTime() {
            calledFirstTime = true;
        }

        public override string ToString() 
        {
            return this.type.ToString();
        }

        private static string ToStars(int generation)
        {
            string stars = "";
            for (int i = 0; i < generation; i++)
            {
                stars += "*";
            }
            return stars;
        }
    }
}