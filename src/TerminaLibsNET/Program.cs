using System;
using System.Collections;
using System.Collections.Generic;

namespace Madlibs
{
    public class Program : List<string>
    {
        public static void Main(string[] args)
        {
            //                  Credit to Timo for inspiring me to make good code
            //                  and for teaching me that array lists are a thing.
            //                  He saved my ass big time on performance.
            //                  Check him out at https://github.com/gotimo2
            // -Gabriel

            Console.WriteLine("Welcome to TerminaLibs!");
            // Removed thread.sleep since .NET framework 4.7 doesn't support it natively
            Console.WriteLine("\nSelect an option: \n'r' for random \n's' for select \n'n' for new\n ");
            string answer = Console.ReadLine();
            while (answer != "r" && answer != "s" && answer != "n")
            {
                Console.WriteLine($"\n'{answer}' is not r, s or n. Try again: ");
                Console.WriteLine("\nDo you want a random one? y/n ");
                answer = Console.ReadLine();
            }
            if (answer == "r")
            {
                NewLib();
            }
            else if (answer == "s")
            {
                Console.WriteLine("\nWhich one do you want? 0-4");
                string answerS = Console.ReadLine();
                try
                {
                    int answerI = Int32.Parse(answerS);
                    while (answerI > 4)
                    {
                        Console.WriteLine("\nThat's over 4, relaunch program and try again");
                        System.Environment.Exit(1);
                    }
                    NewLib(10, answerI); //I give 10 since there is not lib 10 and I only need to pass the answer
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nUnable to parse '{answerS}'. Please make sure to enter a number next time.");
                    System.Environment.Exit(1);
                }

            }
            else if (answer == "n")
            {
                createNewLib();
            }
        }

        public static void NewLib(int prevNumber = 10, int? _choice = null)
        {
            int num = 0; //initialize variable as 0 since there isn't a plain ELSE statement that returns a 'num' value
            if (_choice != null) //if choice was given as input, assign it to num
            {
                num = _choice.Value;
            }
            else if (_choice == null) //otherwise generate random number
            {
                Random rnd = new Random();
                num = rnd.Next(5);
            }

            if (num != prevNumber)
            {
                Console.WriteLine($"\nTaking path {num}.");
                switch (num)
                {
                    case 0:
                        string[] requiredInput = { "adjective", "adjective", "type of bird", "room in a house", "verb in past tense", "verb", "relative's name", "noun", "liquid", "verb ending in -ing", "part of body, plural", "plural noun", "verb ending in -ing", "noun" };
                        List<string> inputs = askInput(requiredInput);
                        Console.WriteLine($"\nIt was a {inputs[0]}, cold November day. I woke up to the {inputs[1]} smell of {inputs[2]} roasting in the {inputs[3]} downstairs. I {inputs[4]} down the stairs to see if I could help {inputs[5]} the dinner. My mom said, 'See if needs a fresh {inputs[6]}'. So I carried a tray of glasses full of {inputs[7]} into the {inputs[8]} room. When I got there, I couldn't beliebe my {inputs[9]}! There were {inputs[10]} {inputs[11]} on the {inputs[12]}!");
                        askNewLib(num);
                        break;
                    case 1:
                        requiredInput = new string[] { "noun", "plural noun", "present tense", "present tense", "part of the body, plural", "adjective", "plural noun", "adjective" };
                        inputs = askInput(requiredInput);
                        Console.WriteLine($"\nToday, every student has a computer small enough to fit into his {inputs[0]}. He can solve any math problem by simply pushing the computer's little {inputs[1]}. Computers can add, multiply, divide and {inputs[2]}. They can also {inputs[3]} better than a human. Some computers are {inputs[4]}. Others have a/an {inputs[5]} screen that shows all kinds of {inputs[6]} and {inputs[7]} figures");
                        askNewLib(num);
                        break;
                    case 2:
                        Console.WriteLine("\nThis is a short one!");
                        requiredInput = new string[] { "noun", "adjective", "noun" };
                        inputs = askInput(requiredInput);
                        Console.WriteLine($"\nAfter hiding the painting in his {inputs[0]} for two years, he grew {inputs[1]} and tried to sell it to a /an {inputs[2]} in Florence, but was caught.");
                        askNewLib(num);
                        break;
                    case 3:
                        requiredInput = new string[] { "silly word", "last name", "illness", "plural noun", "adjective", "adjective", "silly word", "place", "number", "adjective" };
                        inputs = askInput(requiredInput);
                        Console.WriteLine($"\nDear School nurse: {inputs[0]} {inputs[1]} will not be attending school today. He/she has come down with a case of the {inputs[2]} and has horrible {inputs[3]} and a/an {inputs[4]} fever. We have made an appointment with the {inputs[5]} Dr. {inputs[6]}, who studied for many years in {inputs[7]} and has {inputs[8]} degrees in pediatrics. He will send you all the information you need. Thank you! Sincerely, Mrs. {inputs[9]}");
                        askNewLib(num);
                        break;
                    case 4:
                        requiredInput = new string[] { "verb", "adverb", "verb", "adjective", "noun", "verb" };
                        inputs = askInput(requiredInput);
                        Console.WriteLine($"I {inputs[0]} {inputs[1]} through the shadowsm, letting them {inputs[2]} me. But nothing seems {inputs[3]}. There's no sign of any kind of {inputs[4]}, no disruption of the needles on the ground. I've stopped for just am oment when I hear it. I have to {inputs[5]} my head around to the side to be sure, but there it is again.");
                        askNewLib(num);
                        break;
                    default:
                        Console.WriteLine("Not sure how this happened, but the program broke.");
                        System.Environment.Exit(1);
                        break;
                }
            }

            else
            {
                Console.WriteLine("\nSame number appeared, making a new lib...");
                NewLib();
            }
        }

        public static void createNewLib()
        {
            Console.WriteLine("\nHow many inputs do you want there to be? (of type adjective, verb, noun etc.)");
            string amount = Console.ReadLine(); //amount = amount of inputs
            int amountI = Int32.Parse(amount); //amount integer
            while (amountI > 8) //if amount is over 8, close program
            {
                Console.WriteLine("\nThat's over 8, relaunch program and try again");
                System.Environment.Exit(1);
            }
            string[] words = new string[amountI];  //words = INPUT TYPES
            for (int i = 0; i < amountI; i++)
            {
                Console.WriteLine("\nEnter input: ");
                words[i] = Console.ReadLine(); //writes to words at index 'i'
            }
            Console.WriteLine("\nNow write the mad lib text (type INPUT wherever there should be an input, in the order you specified earlier) \n(remember, the max is what you specified earlier) \n(INPUT should always be separated by a space before and after the word):");
            string lib = Console.ReadLine(); //string required inputs
            string[] libA = lib.Split(' '); //array required inputs, split at space
            int c = 0; //counter
            int ic = 0; //input counter
            List<string> inputs = askInput(words);  //list of inputs asked by method (works as of now)
            foreach (string input in libA)
            {
                if (input == "INPUT") //if the word is = "INPUT", ic +1 and lib position counter is replaced with inputs position input counter
                {
                    libA[c] = inputs[ic]; //lib at loop position updates string with input at 'INPUT' location in libA
                    ic++;
                }
                c++;
            }
            Console.WriteLine("\n"); //separate 
            for (int bald = 0; bald < libA.Length; bald++)  //i keep the variable like this as a sign of accomplishment
            {
                Console.Write(libA[bald] + " "); //output at a single line and space after every word
            }
            Console.WriteLine("\n"); //separate
        }
        public static List<string> askInput(string[] inputArray)
        {
            List<string> output = new List<string>();
            foreach (string requiredInput in inputArray)
            {
                if (requiredInput == "adjective" || requiredInput == "illness")
                {
                    Console.WriteLine("\nEnter an " + requiredInput);
                    output.Add(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("\nEnter a " + requiredInput);
                    output.Add(Console.ReadLine());
                }
            }
            return output;
        }

        public static void askNewLib(int prevNum)
        {
            Console.WriteLine("\nWanna go again? y/n ");
            string answer = Console.ReadLine();
            while (answer != "y" && answer != "n")
            {
                Console.WriteLine($"\n'{answer}' is not y or n. Try again: ");
                Console.WriteLine("\nWanna go again? y/n ");
                answer = Console.ReadLine();
            }
            if (answer == "y")
            {
                Console.WriteLine("\nDo you want a random one? y/n ");
                string answerNew = Console.ReadLine();
                while (answerNew != "y" && answerNew != "n")
                {
                    Console.WriteLine($"\n'{answerNew}' is not y or n. Try again: ");
                    Console.WriteLine("\nDo you want a random one? y/n ");
                    answerNew = Console.ReadLine();
                }
                if (answerNew == "y") //generate random number without dupes
                {
                    Console.WriteLine("\nPrevious number: " + prevNum);
                    NewLib(prevNum);
                }
                else if (answerNew == "n")
                {
                    Console.WriteLine("\nWhich one do you want? 1-5");
                    string answerS = Console.ReadLine();
                    try  //in case parse fails
                    {
                        int answerI = Int32.Parse(answerS);
                        while (answerI > 5) //might make 5 a global variable for the amount of libs in the future
                        {
                            Console.WriteLine("\nThat's over 5, relaunch program and try again"); //same goes here, might become $"that's over {libCount} etc"
                            System.Environment.Exit(1); //1 = error
                        }
                        NewLib(10, answerI); //pass lastnum 10 because there is no lib 10 and i only need to pass answer, like in main
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"\nUnable to parse '{answerS}'. Please make sure to enter a number next time.");
                    }


                }
            }
            else if (answer == "n")
            {
                Console.WriteLine("\nGoodbye!");
            }
        }
    }
}