using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ECSH.Test.Unit
{
    [TestFixture]
    public class ECSHTest
    {
        private ECSH.ECS uut;
        private FakeTempSensor fTempSensor;
        private FakeHeater fHeater;

        [SetUp]
        public void SetUp()
        {
            fTempSensor = new FakeTempSensor();
            fHeater = new FakeHeater();
            uut = new ECSH.ECS(28, fTempSensor, fHeater);
        }

        [TestCase(10)]
        [TestCase(-5)]
        public void GetCurTempt_Returns_a(int a)
        {
            fTempSensor.temp = a;
            Assert.That(uut.GetCurTemp(), Is.EqualTo(a));
        }

        [TestCase(1, true)]
        [TestCase(29, false)]
        public void Regulate_GetTemp_Returns_A_Return_B(int a, bool b)
        {
            fTempSensor.temp = a;
            uut.Regulate();
            Assert.That(fHeater.HeaterRunning, Is.EqualTo(b));
        }

        [TestCase(true,true,true)]
        [TestCase(false,true,false)]
        [TestCase(true,false,false)]
        public void RunSelfTest_Should_Return_C(bool a, bool b, bool c)
        {
            fTempSensor.SelfTest = a;
            fHeater.SelfTest = b;
            Assert.That(uut.RunSelfTest(), Is.EqualTo(c));
        }
    }
}
