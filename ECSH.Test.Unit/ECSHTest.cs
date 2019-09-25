using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace ECSH.Test.Unit
{
    [TestFixture]
    public class ECSHTest
    {
        private ECSH.ECS uut;
        private ECSH.ECS uuts;
        private FakeTempSensor fTempSensor;
        private FakeHeater fHeater;
        private FakeWindow fWindow;
        private ITempSensor sTempSensor;
        private IHeater sHeater;
        private IWindow sWindow;

        [SetUp]
        public void SetUp()
        {
            fTempSensor = new FakeTempSensor();
            fHeater = new FakeHeater();
            fWindow = new FakeWindow();
            uut = new ECSH.ECS(28, fTempSensor, fHeater, fWindow);


            sTempSensor = Substitute.For<ITempSensor>();
            sHeater = Substitute.For<IHeater>();
            sWindow = Substitute.For<IWindow>();
            uuts = new ECSH.ECS(28,sTempSensor,sHeater,sWindow);
        }

        #region SubstituteTests

        [TestCase(5)]
        [TestCase(-2)]
        [TestCase(0)]
        public void GetCurTemp_Returns_Correct(int tempValue)
        {
            sTempSensor.GetTemp().Returns(tempValue);
            Assert.That(uuts.GetCurTemp(), Is.EqualTo(tempValue));
        }

        [TestCase(1, true, 0)]
        [TestCase(32, false, 0)]
        public void Regulate_windowStayClosed(int tempValue, bool heaterRunning, int windowOpened)
        {
            sTempSensor.GetTemp().Returns(tempValue);
            uuts.Regulate();
            sWindow.Received(windowOpened).Open();
        }

        #endregion



        #region FakeTests

        [TestCase(10)]
        [TestCase(-5)]
        public void GetCurTempt_Returns_a(int a)
        {
            fTempSensor.temp = a;
            Assert.That(uut.GetCurTemp(), Is.EqualTo(a));
        }

        [TestCase(1, true)]
        [TestCase(29, false)]
        public void Regulate_Without_WindowFunction_GetTemp_ís_A_Function_Return_B(int a, bool b)
        {
            fTempSensor.temp = a;
            uut.Regulate();
            Assert.That(fHeater.HeaterRunning, Is.EqualTo(b));
        }

        [TestCase(1, true, false)]
        [TestCase(32, false, false)]
        [TestCase(33, false, true)]
        public void Regulate_WithWindowFunction(int a, bool b, bool c)
        {
            fTempSensor.temp = a;
            uut.Regulate();
            Assert.That(fHeater.HeaterRunning, Is.EqualTo(b));
            Assert.That(fWindow.IsOpen, Is.EqualTo(c));
        }

        [TestCase(true, true, true)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        public void RunSelfTest_Should_Return_C(bool a, bool b, bool c)
        {
            fTempSensor.SelfTest = a;
            fHeater.SelfTest = b;
            Assert.That(uut.RunSelfTest(), Is.EqualTo(c));
        }

        #endregion



    }
}
