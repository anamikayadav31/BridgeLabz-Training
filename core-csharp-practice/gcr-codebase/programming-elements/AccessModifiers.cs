using System;
class AccessModifiers{
    internal class Emp
    {
        public string name = "Anamika";         // accessible everywhere
        private int pin = 567;              // only inside this class
        protected double sal = 40000;        // base + derived classes
        internal string city = "Shikohabad";       // same project
        protected internal string comp = "CG"; // project OR child

        // Public method to access private data
        public void ShowPin(){
            Console.WriteLine("Pin: " + pin);
        }
    }
    // Derived class
    class Mgr : Emp
    {
        public void ShowDetails(){
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Salary: " + sal);
            Console.WriteLine("City: " + city);
            Console.WriteLine("Company: " + comp);

            // pin is private → not accessible
        }
    }
    class Program{
        public static void Main(string[] args){
            Emp e = new Emp();
            Console.WriteLine("Name: " + e.name);
            Console.WriteLine("City: " + e.city);
            Console.WriteLine("Company: " + e.comp);
            // Private & protected not accessible here
            // Console.WriteLine(e.pin);
            // Console.WriteLine(e.sal);
            e.ShowPin();
            Mgr m = new Mgr();
            m.ShowDetails();
          
        }
    }
}
