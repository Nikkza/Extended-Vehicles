using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Vehiecles
{
    public class Car : IVehiecle
    {
        //Fields 
        public int speed { get; set; }

        public Car(int _speed = 0)
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

        //method
        public static void PrintCar()
        {
            try
            {
                string input = null;
                string tempInput = null;
                Car car = new Car();
                int Changespeed = 0;
                int count = -1;

                if (Vehiecles.listCar.Count == 0)
                {
                    ifstart:
                    foreach (IVehiecle t in Vehiecles.listCar)
                    {
                        Console.WriteLine($"Car : {Vehiecles.listCar.IndexOf(t)}  Speed : {t.speed} Mph ");
                    }
                    Console.WriteLine("No car in stock ! Please press + to add new car !");
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
                            Vehiecles.listCar.Add(new Car(car.speed = Changespeed));

                            foreach (IVehiecle Vehiecle in Vehiecles.listCar)
                            {
                                count++;
                                Console.WriteLine("The Car is  : " + count + " The speed is : " + Vehiecle.speed + " Mph");
                            }
                        }
                        else if (tempInput == "r")
                        {
                            Random rnd = new Random();
                            int random = rnd.Next(10, 100);
                            Car m = new Car();
                            m.speed = random;
                            Vehiecles.listCar.Add(m);
                            Console.WriteLine("The Car is  : " + (Vehiecles.listCar.Count() - 1) + " New speed is : " + m.speed + " Mph ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input !!! ");
                        goto ifstart;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Car changed, Press enter to go back to menu !");
                    Console.WriteLine();
                    Console.ReadKey();
                    Menu.Printmeny();
                }
                else
                {
                    foreach (IVehiecle t in Vehiecles.listCar)
                    {
                        Console.WriteLine($"Car : {Vehiecles.listCar.IndexOf(t)}  Speed : {t.speed} Mph ");
                    }
                    Console.Write("\nChoose a Car from  0-" + (Vehiecles.listCar.Count - 1) + "to change speed or press + to add a new Car : ");

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
                                Vehiecles.listCar.Add(new Car(car.speed = Changespeed));

                                foreach (IVehiecle Vehiecle in Vehiecles.listCar)
                                {
                                    count++;
                                    Console.WriteLine("The Car is  : " + count + " The speed is : " + Vehiecle.speed + " Mph");
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
                            Car m = new Car();
                            m.speed = random;
                            Vehiecles.listCar.Add(m);
                            Console.WriteLine("The Car is  : " + (Vehiecles.listCar.Count() - 1) + " New speed is : " + m.speed + " Mph ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Car speed changed, Press enter to go back to menu !");
                        Console.WriteLine();
                        Console.ReadKey();
                        Menu.Printmeny();
                    }
                    else if (int.Parse(input) <= Vehiecles.listCar.Count())
                    {
                        int chooseCarFromIndex = Convert.ToInt32(input);
                        Console.WriteLine("\nCar  {0}  Speed : {1} Mph ", chooseCarFromIndex, Vehiecles.listCar[chooseCarFromIndex].speed);
                        Console.Write("Enter new speed between (10 - 100) - to remove the Car : ");
                        edit:
                        string newinput = Console.ReadLine();

                        if (newinput == "-")
                        {
                            Vehiecles.listCar.RemoveAt(chooseCarFromIndex);
                            int test = 0;
                            foreach (IVehiecle t in Vehiecles.listCar)
                            {
                                Console.WriteLine("Car  " + test + " speed " + t.speed + " Mph");
                                test++;
                            }
                            Console.WriteLine("Car removed, Press enter to go back to menu !");
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
                                Console.WriteLine("Car " + chooseCarFromIndex + " New speed is " + Changespeed + " Mph");
                                Console.WriteLine();
                                Vehiecles.listCar[chooseCarFromIndex].speed = Changespeed;
                                Console.WriteLine("Press enter to go to menu");
                                Console.ReadKey();
                                Menu.Printmeny();
                            }
                            else if (int.Parse(input) < Vehiecles.listCar.Count())
                            {
                                Console.WriteLine("Wrong input press enter to try again");
                                Console.ReadKey();
                                PrintCar();
                            }
                            Console.WriteLine("Car speed changed, Press enter to go back to menu!");
                            Console.WriteLine();
                            Console.ReadKey();
                            Menu.Printmeny();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input press enter to try again");
                        Console.ReadKey();
                        PrintCar();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Wrong input press any key to try again ");
                Console.ReadKey();
                Console.WriteLine(" ");
                PrintCar();
            }
        }
    }
}
