using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
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

        [Test]
        public void WhenVendingMachineStarts_ThenSelectedProductIsEmpty()
        {
            var machine = new VendingMachine();

            Assert.IsEmpty(machine.GetSelectedProduct());
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

        [TestCase("Coke")]
        [TestCase("Pepsi")]
        [TestCase("Soda")]
        [TestCase("ChocolateBar")]
        [TestCase("ChewingGum")]
        [TestCase("BottledWater")]
        public void WhenSelectingProduct_ThenItCanOnlySelect_Coke_Pepsi_Soda_ChocolateBar_ChewingGum_BottledWater(string expected)
        {
            var machine = new VendingMachine();

            machine.SelectProduct(expected);

            Assert.AreEqual(expected, machine.GetSelectedProduct());
        }

        [TestCase("Sprite")]
        [TestCase("Royal")]
        [TestCase("NatureSpring")]
        [TestCase("JuicyFruit")]
        public void WhenAddingInvalidCashAmount_ThenItShouldThrowException(string expected)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var machine = new VendingMachine();
                machine.SelectProduct(expected);
            });
        }

        [Test]
        public void WhenUserCancelledRequest_ThenItShouldReturnRefundAndResetMachine()
        {
            var machine = new VendingMachine();
            var amount = 100.0M;
            machine.AddCash(amount);

            var result = machine.Refund();

            Assert.AreEqual(amount, result);
            Assert.AreEqual(0, machine.GetBalance());
            Assert.IsEmpty(machine.GetSelectedProduct());
        }

        [TestCase("Coke", 10, 20, 5)]
        [TestCase("Pepsi", 20, 20, 5)]
        [TestCase("Soda", 100, 20, 75)]
        [TestCase("ChocolateBar", 20, 0.25, 0)]
        [TestCase("ChewingGum", 20, 0.50, 10)]
        [TestCase("BottledWater", 10, 10, 5)]
        public void WhenUserPurchases_ThenItShouldReturnTheProductAndChange(string product, decimal cash1, decimal cash2,  decimal change)
        {
            var machine = new  VendingMachine();
            machine.AddCash(cash1);
            machine.AddCash(cash2);
            machine.SelectProduct(product);
            var totalCash = cash1 + cash2;

            var result = machine.Purchase();

            Assert.AreEqual(change, result.Item2);
            Assert.AreEqual(product, result.Item1);
            Assert.AreEqual(0, machine.GetBalance());
            Assert.IsEmpty(machine.GetSelectedProduct());
        }

        [Test]
        public void WhenUserPurchasesWithInsufficientAmount_ThenThrowAnExceptionWithAMessage()
        {
            var machine = new VendingMachine();
            machine.AddCash(10);
            machine.SelectProduct("Coke");

            Assert.Throws<InvalidOperationException>(() =>
            {
                var result = machine.Purchase();
            })
                ;
           
        }
    }
}
