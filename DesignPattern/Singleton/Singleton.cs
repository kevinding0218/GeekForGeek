using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern.Singleton
{
    public class Singleton1st
    {
        private static Singleton1st _instance;
        private Singleton1st() { }
        // call with Singleton.GetInstance().AnyMethod
        public static Singleton1st GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton1st();
            }
            return _instance;
        }
        // call with Singleton.Instance.AnyMethod
        public static Singleton1st Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton1st();
                }
                return _instance;
            }
        }
    }

    public class Singleton2nd
    {
        private static Singleton2nd _instance = null;
        private static readonly object padlock = new object();
        Singleton2nd() { }
        public static Singleton2nd Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                        _instance = new Singleton2nd();
                    return _instance;
                }
            }
        }
    }
    public sealed class Singleton3rd
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton3rd() { }
        private Singleton3rd() { }
        public static Singleton3rd Instance { get; } = new Singleton3rd();
    }
    public sealed class Singleton4th
    {
        private Singleton4th() { }
        public static Singleton4th Instance { get { return Nested.instance; } }
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() { }

            internal static readonly Singleton4th instance = new Singleton4th();
        }
    }

    public sealed class Singleton5th
    {
        private static readonly Lazy<Singleton5th> lazy = new Lazy<Singleton5th>(() => new Singleton5th());
        public static Singleton5th Instance { get { return lazy.Value; } }
        private Singleton5th() { }
    }
}
