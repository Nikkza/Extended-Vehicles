using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Vehiecles
{
    public class Boat : IVehiecle
    {
        public int speed { get; set; }

        public Boat(int _speed = 0)
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

        public void SetSpeed(int x)

        {
            Console.WriteLine("The new speed is  ", x);
        }

        public static void PrintBoat()
        {
            try
            {
                string input = null;
                string tempInput = null;
                Boat boat = new Boat();
                int Changespeed = 0;
                int count = -1;

                if (Vehiecles.listBoat.Count == 0)
                {
                    ifstart:
                    foreach (IVehiecle t in Vehiecles.listBoat)
                    {
                        Console.WriteLine($"Boat : {Vehiecles.listBoat.IndexOf(t)}  Speed : {t.speed} Knots ");
                    }
                    Console.WriteLine("No Boat in stock ! Please press + to add new Boat !");
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
                            Vehiecles.listBoat.Add(new Boat(boat.speed = Changespeed));
                            foreach (IVehiecle Vehiecle in Vehiecles.listBoat)
                            {
                                count++;
                                Console.WriteLine("The Boat is  : " + count + " The speed is : " + Vehiecle.speed + " Knots");
                            }
                        }
                        else if (tempInput == "r")
                        {
                            Random rnd = new Random();
                            int random = rnd.Next(10, 100);
                            Boat m = new Boat();
                            m.speed = random;
                            Vehiecles.listBoat.Add(m);
                            Console.WriteLine("The Boat is  : " + (Vehiecles.listBoat.Count() - 1) + " New speed is : " + m.speed + " Knots ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input !!! ");
                        goto ifstart;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Boat changed, Press enter to go back to menu !");
                    Console.WriteLine();
                    Console.ReadKey();
                    Menu.Printmeny();

                }
                else
                {
                    foreach (IVehiecle t in Vehiecles.listBoat)
                    {
                        Console.WriteLine($"Boat : {Vehiecles.listBoat.IndexOf(t)}  Speed : {t.speed} Knots ");
                    }

                    Console.Write("\nChoose a Boat from  0-" + (Vehiecles.listBoat.Count - 1) + "to change speed or press + to add a new Boat : ");
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
                                Vehiecles.listBoat.Add(new Boat(boat.speed = Changespeed));
                                foreach (IVehiecle Vehiecle in Vehiecles.listBoat)
                                {
                                    count++;
                                    Console.WriteLine("The Boat is  : " + count + " The speed is : " + Vehiecle.speed + " Knots");
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
                            Boat m = new Boat();
                            m.speed = random;
                            Vehiecles.listBoat.Add(m);
                            Console.WriteLine("The Boat is  : " + (Vehiecles.listBoat.Count() - 1) + " New speed is : " + m.speed + " Knots");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Boat speed changed, Press enter to go back to menu !");
                        Console.WriteLine();
                        Console.ReadKey();
                        Menu.Printmeny();
                    }
                    else if (int.Parse(input) <= Vehiecles.listBoat.Count())
                    {
                        int chooseBoatFromIndex = Convert.ToInt32(input);
                        Console.WriteLine("\nBoat  {0}  Speed : {1} Knots ", chooseBoatFromIndex, Vehiecles.listBoat[chooseBoatFromIndex].speed);
                        Console.Write("Enter new speed between (10 - 100) - to remove the Boat : ");
                        edit:
                        string newinput = Console.ReadLine();

                        if (newinput == "-")
                        {
                            Vehiecles.listBoat.RemoveAt(chooseBoatFromIndex);
                            int test = 0;
                            foreach (IVehiecle t in Vehiecles.listBoat)
                            {
                                Console.WriteLine("Boat  " + test + " speed " + t.speed + " Knots");
                                test++;
                            }
                            Console.WriteLine("Boat removed, Press enter to go back to menu !");
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
                                Console.WriteLine("Boat " + chooseBoatFromIndex + " New speed is " + Changespeed + " Knots");
                                Console.WriteLine();
                                Vehiecles.listBoat[chooseBoatFromIndex].speed = Changespeed;
                                Console.WriteLine("Press enter to go to menu");
                                Console.ReadKey();
                                Menu.Printmeny();
                            }
                            else if (int.Parse(input) < Vehiecles.listBoat.Count())
                            {
                                Console.WriteLine("Wrong input press enter to try again");
                                Console.ReadKey();
                                PrintBoat();
                            }
                            Console.WriteLine("Boat speed changed, Press enter to go back to menu!");
                            Console.WriteLine();
                            Console.ReadKey();
                            Menu.Printmeny();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input press enter to try again");
                        Console.ReadKey();
                        PrintBoat();
                    }

                }
            }
            catch
            {
                Console.WriteLine("Wrong input press any key to try again ");
                Console.ReadKey();
                Console.WriteLine(" ");
                PrintBoat();
            }
        }

    }

}

