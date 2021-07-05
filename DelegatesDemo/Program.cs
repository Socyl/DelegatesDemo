using System;

namespace DelegatesDemo
{
    class Program
    {
        delegate void DispStrDelegate(string param);
        //cap a string
        static void Capitalize(string text)
        {
            Console.WriteLine("Your input capitalized --> " + text.ToUpper());
        }

        //LC a string
        static void LowerCased(string text)
        {
            Console.WriteLine("Your input lower cased -->" + text.ToLower());
        }

        static void RunMyDelegate(DispStrDelegate del, string textParam)
        {
            del(textParam);
        }

        static void Main(string[] args)
        {
            ////get line to convert
            //Console.Write("Please enter some text: ");
            //string text = Console.ReadLine();

            //instantiate 3 delegate objects
            DispStrDelegate saying1 = new DispStrDelegate(Capitalize);
            DispStrDelegate saying2 = new DispStrDelegate(LowerCased);
            DispStrDelegate saying3 = new DispStrDelegate(Console.WriteLine);

            ////call them
            //saying1(text);
            //saying2(text);
            //saying3(text);

            //get another text line
            Console.Write("Please enter some text: ");
            string text = Console.ReadLine();
            
            //concatenate delegates
            DispStrDelegate sayings = new DispStrDelegate(Capitalize);
            sayings += saying2;
            sayings += saying3;

            //call one delegate, run all three 
            Console.WriteLine("\nRunning multi cast directly");
            sayings(text);

            //pass delegate as method argument
            Console.WriteLine("\nRunning by passing delegate as argument");
            RunMyDelegate(sayings, text);


            //lambda expression

            Console.WriteLine("\nPlaying with lambda expressions");
            RunMyDelegate((string t) => { Console.WriteLine("lambda: " + t); }, text);

            //lambda without type

            Console.WriteLine("\nLambda without type");
            RunMyDelegate((t) => { Console.WriteLine("Lambda: " + t); }, text);


            //remove parenthesis
            Console.WriteLine("\nLambda without type/parentheses");
            RunMyDelegate(t => { Console.WriteLine("Lambda: " + t); }, text);

            sayings += t => { Console.WriteLine("Lambda3: " + t); };
            RunMyDelegate(sayings, text);
        
        }

     
    }
}
