using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiecles
{
    class Menu
    {
        public static void Printmeny()
        {
            Console.Clear();
            start:
            Console.WriteLine("-- Please select -- ");
            Console.WriteLine(" 1.Print / Create Cars ");
            Console.WriteLine(" 2.Print / Create Boats ");
            Console.WriteLine(" 3.Print / Create Motorcycles ");
            Console.WriteLine(" 4.Print all vehicles in m/s");
            try
            {
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        {
                            Car.PrintCar();
                            break;
                        }
                    case 2:
                        {
                            Boat.PrintBoat();
                            break;
                        }
                    case 3:
                        {
                            Motorcycle.PrintMotorcycle();
                            break;
                        }
                    case 4:
                        {
                            PrintLists.PrintSpeedInMetersPerSecond(Vehiecles.listMotorcycle, 0.28d);
                            Console.WriteLine();
                            PrintLists.PrintSpeedInMetersPerSecond(Vehiecles.listCar, 0.44d);
                            Console.WriteLine();
                            PrintLists.PrintSpeedInMetersPerSecond(Vehiecles.listBoat, 0.51d);
                            break;
                        }
                    default:
                        Console.WriteLine("Error please select a number 1-4");
                        goto start;     
                }

            }
            catch
            {
                Console.WriteLine("Error please select a number 1-4");
                Console.ReadLine();
                Printmeny();
            }

        }

        public static void StartVehicle()
        {
            // ----------------------------- For Motorcycle ---------------------------------------------------
            motorcycel:
            Console.Write("\nPlease enter how many motorcycle you want : ");
            try
            {
                int numberOfMotorcycleToCreate = Convert.ToInt32(Console.ReadLine());
                while (numberOfMotorcycleToCreate != 0)
                {
                    Vehiecles.listMotorcycle.Add(new Motorcycle());
                    numberOfMotorcycleToCreate--;
                }

                Random rnd = new Random();
                for (int i = 0; i < Vehiecles.listMotorcycle.Count; i++)
                {
                    int random = rnd.Next(10, 100);
                    Vehiecles.listMotorcycle[i].speed = random;
                    Console.WriteLine("Motorcycle {0} - Speed : {1} km/h", i, Vehiecles.listMotorcycle[i].speed);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must add Motorcykel!!");
                Console.ResetColor();
                goto motorcycel;
            }

            //-------------------------------- Cars -----------------------------------
            cars:
            Console.Write("\nPlease enter how many car you want : ");
            try
            {
                int numberOfCarsToCreate = Convert.ToInt32(Console.ReadLine());
                while (numberOfCarsToCreate != 0)
                {
                    Vehiecles.listCar.Add(new Car());
                    numberOfCarsToCreate--;
                }
              
                Random rndc = new Random();
                for (int i = 0; i < Vehiecles.listCar.Count; i++)
                {
                    int random = rndc.Next(10, 100);
                    Vehiecles.listCar[i].speed = random;
                    Console.WriteLine(". Car {0} - Speed : {1} MPH ", i, Vehiecles.listCar[i].speed);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must add car!!");
                Console.ResetColor();
                goto cars;
            }
            //---------------------------------------------- Boat --------------------------------------
            boats:
            Console.Write("\nPlease enter how many boat you want : ");
            try
            {
                int numberOfBoatToCreate = Convert.ToInt32(Console.ReadLine());
                while (numberOfBoatToCreate != 0)
                {
                    Vehiecles.listBoat.Add(new Boat());
                    numberOfBoatToCreate--;
                }
                
                Random rndB = new Random();
                for (int i = 0; i < Vehiecles.listBoat.Count; i++)
                {
                   int random = rndB.Next(10, 100);
                   Vehiecles.listBoat[i].speed = random;
                   Console.WriteLine(". Boat {0} - Speed : {1} Knots ", i, Vehiecles.listBoat[i].speed);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must add Boats!!");
                Console.ResetColor();
                goto boats;
            }
        }
    }
}
