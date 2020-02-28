using System;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;

namespace VendingMachine
{
    [TestFixture]
    public class VendingMachineTest
    {
        [Test]
        public void WhenVendingMachineStarts_ThenBalanceShouldBeZero()
        {
            var machine = new VendingMachine();

            Assert.AreEqual(0, machine.GetBalance());
        }

        [TestCase(100.0)]
        [TestCase(50.0)]
        [TestCase(20.0)]
        [TestCase(10.0)]
        [TestCase(5.0)]
        [TestCase(1.0)]
        [TestCase(0.5)]
        [TestCase(0.25)]
        public void WhenAddingCash_ThenItOnlyAccepts_100_50_20_10_5_1_050_025(decimal expected)
        {
            var machine = new VendingMachine();

            machine.AddCash(expected);

            Assert.AreEqual(expected, machine.GetBalance());

        }

        [TestCase(500.0)]
        [TestCase(25.0)]
        [TestCase(8.0)]
        [TestCase(0.75)]
        public void WhenAddingInvalidCashAmount_ThenItShouldThrowException(decimal expected)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var machine = new VendingMachine();
                machine.AddCash(expected);
            });
        }
    }
}
