using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiecles
{
    class PrintLists
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="speedM"></param>

        public static void PrintSpeedInMetersPerSecond(List<IVehiecle> m, double speedM)
        {
            int countMotorCycle = 0;
            int countCar = 0;
            int countBoats = 0;

            if (m == Vehiecles.listMotorcycle)
            {
                Console.WriteLine($"You have {Vehiecles.listMotorcycle.Count()} Motorcykels in stock");
            }
            else if (m == Vehiecles.listBoat)
            {
                Console.WriteLine($"You have {Vehiecles.listBoat.Count()} Boats in stock");
            }
            else if (m == Vehiecles.listCar)
            {
                Console.WriteLine($"You have {Vehiecles.listCar.Count()} Cars in stock");
            }

            foreach (IVehiecle o in m)
            {
                if (o.GetType().Name == "Motorcycle")
                {
                    Console.WriteLine(o.GetType().Name + " " + countMotorCycle + " speed " + (o.speed * speedM).ToString("#.0") + " m/s");
                    countMotorCycle++;
                }

                else if (o.GetType().Name == "Car")
                {
                    Console.WriteLine(o.GetType().Name + " " + countCar + " speed " + (o.speed * speedM).ToString("#.0") + " m/s");
                    countCar++;
                }
                else if (o.GetType().Name == "Boat")
                {
                    Console.WriteLine(o.GetType().Name + " " + countBoats + " speed " + (o.speed * speedM).ToString("#.0") + " m/s");
                    countBoats++;
                }
            }
        }
    }
}

