using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Vehiecles
{
    public class Motorcycle : IVehiecle
    {
        public int speed { get; set; }

        public Motorcycle(int _speed = 0)
        {
            speed = _speed;
        }

        public int Getspeed()
        {
            return speed;
        }
        public void Setspeed(int x)
        {
            speed = x;
        }

        public static void PrintMotorcycle()
        {
            try
            {
                string input = null;
                string tempInput = null;
                Motorcycle motorcycle = new Motorcycle();
                int Changespeed = 0;
                int count = -1;

                if (Vehiecles.listMotorcycle.Count == 0)
                {
                    ifstart:
                    foreach (IVehiecle t in Vehiecles.listMotorcycle)
                    {
                        Console.WriteLine($"Motorcycle : {Vehiecles.listMotorcycle.IndexOf(t)}  Speed : {t.speed} Km/h ");
                    }
                    Console.WriteLine("No Motorcycle in stock ! Please press + to add new car !");
                    input = Console.ReadLine();
                    if (input == "+")
                    {
                        Console.WriteLine("Enter new speed between (10 - 100) or press ' r ' to enter a random speed : ");
                        tempInput = Console.ReadLine();

                        while (!int.TryParse(tempInput, out Changespeed) && tempInput != "r")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Input!\nEnter new speed between (10 - 100) or press ' r ' to enter a random speed : ");
                            Console.ResetColor();
                            tempInput = Console.ReadLine();
                        }
                        if (Changespeed >= 10 && Changespeed <= 100)
                        {
                            Vehiecles.listMotorcycle.Add(new Motorcycle(motorcycle.speed = Changespeed));

                            foreach (IVehiecle Vehiecle in Vehiecles.listMotorcycle)
                            {
                                count++;
                                Console.WriteLine("The Motorcycle is  : " + count + " The speed is : " + Vehiecle.speed + " Km/h");
                            }
                        }
                        else if (tempInput == "r")
                        {
                            Random rnd = new Random();
                            int random = rnd.Next(10, 100);
                            Motorcycle m = new Motorcycle();
                            m.speed = random;
                            Vehiecles.listMotorcycle.Add(m);
                            Console.WriteLine("The Motorcycle is  : " + (Vehiecles.listMotorcycle.Count() - 1) + " New speed is : " + m.speed + " Km/h ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input !!! ");
                        goto ifstart;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Motorcycle changed, Press enter to go back to menu !");
                    Console.WriteLine();
                    Console.ReadKey();
                    Menu.Printmeny();
                }
                else
                {
                    foreach (IVehiecle t in Vehiecles.listMotorcycle)
                    {
                        Console.WriteLine($"Motorcycle : {Vehiecles.listMotorcycle.IndexOf(t)}  Speed : {t.speed} Km/h ");
                    }
                    Console.Write("\nChoose a Motorcycle from  0-" + (Vehiecles.listMotorcycle.Count - 1) + "to change speed or press + to add a new Motorcycle : ");
                    input = Console.ReadLine();

                    if (input == "+")
                    {
                        edit1:
                        Console.WriteLine("Enter new speed between (10 - 100) or press ' r ' to enter a random speed : ");

                        tempInput = Console.ReadLine();

                        while (!int.TryParse(tempInput, out Changespeed) && tempInput != "r")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong Input!\nEnter new speed between (10 - 100) or press ' r ' to enter a random speed : ");
                            Console.ResetColor();
                            tempInput = Console.ReadLine();
                        }
                        if (int.TryParse(tempInput, out Changespeed))
                        {
                            if (Changespeed >= 10 && Changespeed <= 100)
                            {
                                Vehiecles.listMotorcycle.Add(new Motorcycle(motorcycle.speed = Changespeed));
                                foreach (IVehiecle Vehiecle in Vehiecles.listMotorcycle)
                                {
                                    count++;
                                    Console.WriteLine("The Motorcycle is  : " + count + " The speed is : " + Vehiecle.speed + " Km/h");
                                }
                            }
                            else
                            {
                                goto edit1;
                            }
                        }
                        else if (tempInput == "r")
                        {
                            Random rnd = new Random();
                            int random = rnd.Next(10, 100);
                            Motorcycle m = new Motorcycle();
                            m.speed = random;
                            Vehiecles.listMotorcycle.Add(m);
                            Console.WriteLine("The Motorcycle is  : " + (Vehiecles.listMotorcycle.Count() - 1) + " New speed is : " + m.speed + " Km/h ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Motorcycle speed changed, Press enter to go back to menu !");
                        Console.WriteLine();
                        Console.ReadKey();
                        Menu.Printmeny();
                    }
                    else if (int.Parse(input) <= Vehiecles.listMotorcycle.Count())
                    {
                        int chooseMotorcycleFromIndex = Convert.ToInt32(input);
                        Console.WriteLine("\nMotorcycle  {0}  Speed : {1} Km/h ", chooseMotorcycleFromIndex, Vehiecles.listMotorcycle[chooseMotorcycleFromIndex].speed);
                        Console.Write("Enter new speed between (10 - 100) - to remove the Motorcycle : ");
                        edit:
                        string newinput = Console.ReadLine();

                        if (newinput == "-")
                        {
                            Vehiecles.listMotorcycle.RemoveAt(chooseMotorcycleFromIndex);
                            int test = 0;
                            foreach (IVehiecle t in Vehiecles.listMotorcycle)
                            {
                                Console.WriteLine("Motorcycle  " + test + " speed " + t.speed + " Km/h");
                                test++;
                            }
                            Console.WriteLine("Motorcycle removed, Press enter to go back to menu !");
                            Console.WriteLine();
                            Console.ReadKey();
                            Menu.Printmeny();
                        }
                        else
                        {
                            if (int.TryParse(newinput, out Changespeed))
                            {
                                if (Changespeed >= 101 || Changespeed <= 9)
                                {
                                    Console.WriteLine("Enter a number between 10 and 100! Douche!");
                                    Thread.Sleep(100);
                                    goto edit;
                                }
                                Console.WriteLine("Motorcycle " + chooseMotorcycleFromIndex + " New speed is " + Changespeed + " Km/h");
                                Console.WriteLine();
                                Vehiecles.listMotorcycle[chooseMotorcycleFromIndex].speed = Changespeed;
                                Console.WriteLine("Press enter to go to menu");
                                Console.ReadKey();
                                Menu.Printmeny();
                            }
                            else if (int.Parse(input) < Vehiecles.listMotorcycle.Count())
                            {
                                Console.WriteLine("Wrong input press enter to try again");
                                Console.ReadKey();
                                PrintMotorcycle();
                            }
                            Console.WriteLine("Motorcycle speed changed, Press enter to go back to menu!");
                            Console.WriteLine();
                            Console.ReadKey();
                            Menu.Printmeny();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input press enter to try again");
                        Console.ReadKey();
                        PrintMotorcycle();
                    }

                }
            }
            catch
            {
                Console.WriteLine("Wrong input press any key to try again ");
                Console.ReadKey();
                Console.WriteLine(" ");
                PrintMotorcycle();
            }
        }

    }
}

