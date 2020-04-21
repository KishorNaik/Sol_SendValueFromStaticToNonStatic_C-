using System;

namespace Sol_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Demo demo = new Demo();
            Demo.OnExecute();
            Console.WriteLine(demo.FullName);

        }
    }

    public class Demo
    {
        #region Constructor
        public Demo()
        {
            // Call Action Delegate and get value from Delegate parameter and bind to non static Property.
            OnGetValue = (value) => FullName = value;
        }
        #endregion 


        #region Non Static Property
        public String FullName { get; set; }

        #endregion

        #region Static Property
        private static Action<String> OnGetValue { get; set; }
        #endregion 

        #region Static Method
        public static void OnExecute()
        {
            var fullName = "Kishor Naik"; // Now i want to bind this value on Non Static property i.e FullName
            // Here we cant Access Non Static Property in static Method
            // So how can we set above said value in Non Static property
            // Answer is Delegate
            OnGetValue?.Invoke(fullName); // Invoke Delegate and Pass Value as parameter.
        }
        #endregion 
    }
}
