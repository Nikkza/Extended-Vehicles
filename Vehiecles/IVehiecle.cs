using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiecles
{
    public interface IVehiecle 
    {
        int speed { get; set; }
        int Getspeed();
        void Setspeed(int x);
  
    }
}
