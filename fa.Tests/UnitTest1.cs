using System;
using System.Collections.Generic;
using System.Linq;

namespace NET
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA1()
        {
            a.Transitions['0'] = c;
            a.Transitions['1'] = c;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = c;
            c.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA2()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = a;
            b.Transitions['0'] = a;
            b.Transitions['1'] = b;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA3()
        {
            a.Transitions['0'] = b;
            a.Transitions['1'] = c;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = b;
            c.Transitions['1'] = a;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "1"; // true
            string s2 = "0101"; // false
            string s3 = "011"; // true

            FA1 fa1 = new FA1();
            FA2 fa2 = new FA2();
            FA3 fa3 = new FA3();

            Console.WriteLine("FA1 result: " + fa1.Run(s1)?.ToString());
            Console.WriteLine("FA2 result: " + fa2.Run(s2)?.ToString());
            Console.WriteLine("FA3 result: " + fa3.Run(s3)?.ToString());

            Console.ReadLine();
        }
    }
}
