﻿using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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

            var f = new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(19, 0, 0), 1),
                new PayEntry(new TimeSpan(25, 0, 0), 1),
            });

            Assert.IsTrue(f.Name == "A" && f.PayScale.Count == 2, "Correct payscale fails to construct properly");
        }

        [TestMethod]
        public void NegativePayscaleThrows() {
            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(-1, 0, 0), 1),
                new PayEntry(new TimeSpan(19, 0, 0), 1),
            }), "Negative payscale does not throw");

            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(-2, 0, 0), 1),
                new PayEntry(new TimeSpan(-1, 0, 0), 1),
            }), "Negative payscale does not throw");
        }

        [TestMethod]
        public void UnsortedPayscaleThrows() {
            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(20, 0, 0), 1),
                new PayEntry(new TimeSpan(22, 0, 0), 1),
                new PayEntry(new TimeSpan(21, 0, 0), 1),
                new PayEntry(new TimeSpan(25, 0, 0), 1),
            }), "Unsorted payscale does not throw");

            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(20, 0, 0), 1),
                new PayEntry(new TimeSpan(22, 0, 0), 1),
                new PayEntry(new TimeSpan(25, 0, 0), 1),
                new PayEntry(new TimeSpan(24, 0, 0), 1),
            }), "Unsorted payscale does not throw");

            Assert.ThrowsException<ArgumentException>(() => new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(20, 0, 0), 1),
                new PayEntry(new TimeSpan(19, 0, 0), 1),
            }), "Unsorted payscale does not throw");
        }
    }
}
