using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BabysitterKata.Tests {
    [TestClass]
    public class OutOfRangeHours {
        private readonly Family family;
        private readonly Babysitter sitter;

        public OutOfRangeHours() {
            this.family = Family.GetTestFamily();
            this.sitter = new Babysitter(Babysitter.DefaultStartTime, Babysitter.DefaultEndTime);
        }

        [TestMethod]
        public void StartHourOutOfRangeThrows() {
            var end = new TimeSpan(27, 0, 0);
            var data = new List<TimeSpan> {
                new TimeSpan(6, 0, 0),
                new TimeSpan(12, 0, 0),
                new TimeSpan(16, 0, 0),
            };

            foreach (var d in data)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(this.family, d, end), $"Start time of {d} is outside the allowed range, yet passed.");
        }

        [TestMethod]
        public void EndHourOutOfRangeThrows() {
            var start = new TimeSpan(17, 0, 0);
            var data = new List<TimeSpan> {
                new TimeSpan(29, 0, 0),
                new TimeSpan(31, 0, 0),
                new TimeSpan(50, 0, 0),
            };

            foreach (var d in data)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(this.family, start, d), $"End time of {d} is outside the allowed range, yet passed.");
        }

        [TestMethod]
        public void StartAndEndOutOfRangeThrows() {
            var start = new List<TimeSpan> {
                new TimeSpan(6, 0, 0),
                new TimeSpan(14, 0, 0),
            };

            var end = new List<TimeSpan> {
                new TimeSpan(29, 0, 0),
                new TimeSpan(45, 0, 0),
            };

            foreach (var s in start)
                foreach (var e in end)
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(this.family, s, e), $"Start time of {s} and end time of {e} are outside the allowed range, yet passed.");
        }
    }
}
