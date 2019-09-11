using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECSH.Test.Unit
{
    class FakeHeater : IHeater
    {
        public bool HeaterRunning { get; private set; }
        public bool SelfTest = false;
        public FakeHeater()
        {
            HeaterRunning = false;
        }
        
        public void TurnOn()
        {
            HeaterRunning = true;
        }

        public void TurnOff()
        {
            HeaterRunning = false;
        }

        public bool RunSelfTest()
        {
            return SelfTest;
        }
    }
}
