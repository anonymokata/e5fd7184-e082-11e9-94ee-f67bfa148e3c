using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKata.Tests {
    [TestClass]
    public class PayInvalidFamily {
        private readonly Family family;
        private readonly Babysitter sitter;

        public PayInvalidFamily() {
            this.family = Family.GetTestFamily();
            this.sitter = new Babysitter(Babysitter.DefaultStartTime, Babysitter.DefaultEndTime);
        }

        [TestMethod]
        public void NullFamilyThrows() {
            Assert.ThrowsException<ArgumentNullException>(() => this.sitter.CalculatePay(null, Babysitter.DefaultStartTime, Babysitter.DefaultEndTime), "Null family does not throw");
        }

        [TestMethod]
        public void InvalidArgumentsThrows() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PayEntry(new TimeSpan(20, 0, 0), 0), "Pay of 0 does not throw");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PayEntry(new TimeSpan(20, 0, 0), -1), "Pay of -1 does not throw");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PayEntry(new TimeSpan(20, 0, 0), int.MinValue), "Pay of int.MinValue does not throw");

            Assert.ThrowsException<ArgumentNullException>(() => new Family("A", null), "Null payscale does not throw");
            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry>()), "Empty payscale does not throw");
        }
    }
}
