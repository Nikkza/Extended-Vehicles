using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiecles
{
    public static class Vehiecles
    {
        /// <summary>
        /// this is where we hold our our list and we kept them Public and maid the Class static and all the list static
        /// </summary>
        public static List<IVehiecle> listMotorcycle = new List<IVehiecle>();
        public static List<IVehiecle> listBoat = new List<IVehiecle>();
        public static List<IVehiecle> listCar = new List<IVehiecle>();
    }
}
