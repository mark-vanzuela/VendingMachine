using System;
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
    }
}
