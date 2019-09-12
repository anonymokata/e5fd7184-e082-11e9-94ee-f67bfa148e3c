using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKata.Tests {
    [TestClass]
    public class CorrectPay {
        private readonly Babysitter sitter;

        public CorrectPay() => this.sitter = new Babysitter(Babysitter.DefaultStartTime, Babysitter.DefaultEndTime);

        [TestMethod]
        public void FamilyAPay() {
            var family = Family.GetFamily("A");

            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0)), 45);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(18, 0, 0), new TimeSpan(22, 0, 0)), 60);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(19, 0, 0), new TimeSpan(25, 0, 0)), 100);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(26, 0, 0), new TimeSpan(27, 0, 0)), 20);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(25, 0, 0), new TimeSpan(28, 0, 0)), 60);
        }

        [TestMethod]
        public void FamilyBPay() {
            var family = Family.GetFamily("B");

            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0)), 36);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(18, 0, 0), new TimeSpan(22, 0, 0)), 48);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(19, 0, 0), new TimeSpan(25, 0, 0)), 68);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(26, 0, 0), new TimeSpan(27, 0, 0)), 16);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(25, 0, 0), new TimeSpan(28, 0, 0)), 48);
        }

        [TestMethod]
        public void FamilyCPay() {
            var family = Family.GetFamily("C");

            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(17, 0, 0), new TimeSpan(20, 0, 0)), 63);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(18, 0, 0), new TimeSpan(22, 0, 0)), 78);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(19, 0, 0), new TimeSpan(25, 0, 0)), 102);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(26, 0, 0), new TimeSpan(27, 0, 0)), 15);
            Assert.AreEqual(this.sitter.CalculatePay(family, new TimeSpan(25, 0, 0), new TimeSpan(28, 0, 0)), 45);
        }
    }
}
