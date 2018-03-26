namespace DesignPattern.Singleton
{
    /// <summary>
    /// Ensures a class has only one instance and provides a global point of access to it.
    /// A singleton is a class that only allows a single instance of itself to be created, and usually gives simple access to that instance.
    /// Most commonly, singletons don't allow any parameters to be specified when creating the instance, 
    /// since a second request of an instance with a different parameter could be problematic! 
    /// (If the same instance should be accessed for all requests with the same parameter then the factory pattern is more appropriate.)
    /// A single constructor, that is private and parameterless.
    /// The class is sealed.
    /// A static variable that holds a reference to the single created instance, if any.
    /// A public static means of getting the reference to the single created instance, creating one if necessary.
    /// </summary>
    public sealed class Calculate
    {
        private Calculate() { }
        private static Calculate instance = null;
        public static Calculate Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Calculate();
                }
                return instance;
            }
        }

        public double ValueOne
        {
            get;
            set;
        }
        public double ValueTwo
        {
            get;
            set;
        }

        public double Addition()
        {
            return ValueOne + ValueTwo;
        }

        public double Subtraction()
        {
            return ValueOne - ValueTwo;
        }

        public double Multiplication()
        {
            return ValueOne * ValueTwo;
        }

        public double Division()
        {
            return ValueOne / ValueTwo;
        }
    }
}
