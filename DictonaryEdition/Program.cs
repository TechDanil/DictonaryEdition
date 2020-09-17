using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Transactions;

namespace DictonaryEdition
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("Select an action down below");
            Console.WriteLine("1. Do you want to replace a subject?");
            Console.WriteLine("2. Do you wanto to delete everything?");
            Console.WriteLine("3. Do you want to leave everything as it is?");
        }
        public static Dictionary<string, string> schedule;

        public static Dictionary<string, string> actions;

        public static Dictionary<string, Action> execution;

        public static void ChosingAction()
        {
            string answer = Console.ReadLine();
            if (execution.ContainsKey(answer))

            {
                execution[answer].Invoke();
            }
            
        }
        static void Main(string[] args)
        {

            actions = new Dictionary<string, string>
            {
                { "1" ,"replace"},
                { "2" , "delete"},
                { "3" , "nothing"}
            };

            execution = new Dictionary<string, Action>
          {
              {"1", LessonsChange },
              {"2", RemovingEverything },
              {"3", SeeAllElements }
          };
            int count = 0;

            schedule = new Dictionary<string, string>();
            while (count < 5)
            {
                count++;
                Console.WriteLine($"Enter a name of the lesson {count}");
                schedule.Add($"Lesson {count}", Console.ReadLine());
            }
            Console.WriteLine(schedule);


            Console.WriteLine("Here's info that will show up after filling up the graphes");


            foreach (var keyValue in schedule)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);

            }
            Menu();
            ChosingAction();
        }

        public static void LessonsChange()
        {
            bool Agrement = true;
            while (Agrement)
            {
                Console.WriteLine("first choose a number of the lesson that you want to replace ");
               
                    var lessonNumber = int.Parse(Console.ReadLine());
                       
                    Console.WriteLine("Add a new subject");

                    var subjecToChoose = Console.ReadLine();
                    schedule[$"Lesson {lessonNumber}"]= subjecToChoose;

                    foreach (KeyValuePair<string, string> Lessons in schedule)
                    {
                        Console.WriteLine(Lessons.Key + " - " + Lessons.Value);
                    }
                Agrement = UsersAgreement();




            }

        }


















        public static void RemovingEverything()
        {
            bool Agrement = true;
            while (Agrement)
            {
                Console.WriteLine("Everything's been removed from dictionary");
                schedule.Clear();
                Agrement = UsersAgreement();
            }
        }

        public static void SeeAllElements()
        {
            bool Agrement = true;
            while (Agrement)
            {
                Console.WriteLine("These are yout lessons as theyt were before: ");
                foreach (KeyValuePair<string, string> DefaultLessons in schedule)
                {
                    Console.WriteLine(DefaultLessons.Key + " - " + DefaultLessons.Value);
                }
                Agrement = UsersAgreement();
            }
        }

        public static bool UsersAgreement()
        {

            Console.WriteLine("Do you want to continue?");
            string answer = Convert.ToString(Console.ReadLine());
            if (answer != "y")
            {
                Menu();
                ChosingAction();
                return false;
            }
            return true;
        }

        public static void Messsage(string execution)
        {
            Console.WriteLine($"You've chosen {execution} function");
        }



    }
}







