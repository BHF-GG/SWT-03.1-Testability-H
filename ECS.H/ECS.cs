using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSH
{
    public class ECS
    {
        private int _threshold;
        private int _maxTemp = 32;
        private readonly IWindow _window;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;


        public ECS(int thr, ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thr);
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();

            if (t > _maxTemp)
                _window.Open();
            else
                _window.Close();

            if (_window.IsOpen())
                _heater.TurnOff();
            
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
