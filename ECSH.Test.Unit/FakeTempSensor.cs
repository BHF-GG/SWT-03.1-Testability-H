using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECSH;

namespace ECSH.Test.Unit
{
    class FakeTempSensor : ITempSensor
    {
        public int temp = 0;
        public bool SelfTest = false;
        public int GetTemp()
        {
            return temp;
        }

        public bool RunSelfTest()
        {
            return SelfTest;
        }
    }
}
