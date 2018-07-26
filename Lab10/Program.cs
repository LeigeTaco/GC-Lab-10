using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab10
{

    class Circle
    {

        private double radius;

        public Circle(double radius)
        {

            this.radius = radius;

        }

        public double CalculateCircumference()
        {

            return radius * 2 * System.Math.PI;

        }

        public string CalculateFormattedCircumference()
        {

            return $"{"Circumference:", -1}{ FormatNumber(CalculateCircumference())}";

        }

        public double CalculateArea()
        {

            return radius * radius * System.Math.PI;

        }

        public string CalculateFormattedArea()
        {

            return $"{"Area:", -10}{ FormatNumber(CalculateArea())}";

        }

        private string FormatNumber(double x)
        {

            return x.ToString();

        }

    }

    class Program
    {

        static bool MoreCircles()
        {

            string check = "";

            do
            {

                Console.WriteLine("Would you like to continue creating circles? (Y/N)");
                string temp = Console.ReadLine();
                check = temp.Substring(0, 1);

                if(Regex.IsMatch(check, "^[Yy]$"))
                {

                    return true;

                }
                else if(Regex.IsMatch(check, "^[Nn]$"))
                {

                    return false;

                }
                else
                {

                    Console.WriteLine("Listen, you only have to get the first letter right.");

                }

            } while (true);

        }

        static double ValidRadius()
        {

            Console.WriteLine("Please enter a radius. Must be greater than 0");
            double output = 0.0;

            while (true)
            {

                try
                {

                    output = double.Parse(Console.ReadLine());
                    if(output > 0)
                    {

                        return output;

                    }
                    else
                    {

                        Console.WriteLine("Entered number was either negative or dumb. Don't do that again.");

                    }

                }
                catch(FormatException)
                {

                    Console.WriteLine("Error: Format exception! Try not being a monkey!");

                }
                catch(NullReferenceException)
                {

                    Console.WriteLine("CTRL+Z isn't cool anymore.");

                }
                catch(OverflowException)
                {

                    Console.WriteLine("Error: Overflow exception! Data exceeded allocated bounds.");

                }

            }

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Circle Tester!");            
            List<Circle> userCircles = new List<Circle>();
            int counter = 0;

            do
            {

                userCircles.Add(new Circle(ValidRadius()));
                Console.WriteLine(userCircles[counter].CalculateFormattedCircumference());
                Console.WriteLine(userCircles[counter].CalculateFormattedArea());
                counter++;

            } while (MoreCircles());

            Console.WriteLine($"It was fun while it lasted, you made {counter} Circle Object(s)!");
            Console.WriteLine("See ya next time...");

        }

    }

}
