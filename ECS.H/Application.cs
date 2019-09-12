using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSH
{
    class Application
    {public static void Main(string[] args)
        {
            var ecs = new ECS(28, new TempSensor(), new Heater(), new Window());

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
