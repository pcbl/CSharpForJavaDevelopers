using System.IO;

namespace demo.officeDay.getSet
{
    /// <summary>
    /// Get and Set exists on C# since Day 0
    /// </summary>
    public class Person
    {
        private string name;

        //Constants
        public const string ConstInitiatilized="";
        //Readonly Variables, Like constants... But can be initialized on Constructor
        private readonly string ConstructorInitialized;

        public Person()
        {
            ConstructorInitialized = "Wow";
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value; 
                //Here you could log the new Value, for example
            }
        }

        //Same as Name, but way shorter
        public string LastName { get; set; }

   
        public string FullName
        {
            get
            {
                //return string.Format("{0} {1}", Name, LastName);
                //Let us use string interpolation
                return $"{Name} {FullName}";
            }
        }
    }
}
