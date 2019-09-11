using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BabysitterKata.Tests {
    [TestClass]
    public class OutOfRangeHours {
        private readonly Babysitter sitter;

        public OutOfRangeHours() => this.sitter = new Babysitter(Babysitter.DefaultStartTime, Babysitter.DefaultEndTime);

        [TestMethod]
        public void StartHourOutOfRangeThrows() {
            var end = new TimeSpan(3, 0, 0);
            var data = new List<TimeSpan> {
                new TimeSpan(6, 0, 0),
                new TimeSpan(12, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(15, 0, 0),
                new TimeSpan(7, 0, 0),
            };

            foreach (var d in data)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(d, end), $"Start time of {d} is outside the allowed range, yet passed.");
        }

        [TestMethod]
        public void EndHourOutOfRangeThrows() {
            var start = new TimeSpan(3, 0, 0);
            var data = new List<TimeSpan> {
                new TimeSpan(5, 0, 0),
                new TimeSpan(12, 0, 0),
                new TimeSpan(13, 0, 0),
                new TimeSpan(11, 0, 0),
                new TimeSpan(10, 0, 0),
            };

            foreach (var d in data)
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(start, d), $"End time of {d} is outside the allowed range, yet passed.");
        }

        [TestMethod]
        public void StartAndEndOutOfRangeThrows() {
            var start = new List<TimeSpan> {
                new TimeSpan(6, 0, 0),
                new TimeSpan(12, 0, 0),
                new TimeSpan(16, 0, 0),
            };

            var end = new List<TimeSpan> {
                new TimeSpan(5, 0, 0),
                new TimeSpan(12, 0, 0),
                new TimeSpan(13, 0, 0),
            };

            foreach (var s in start)
                foreach (var e in end)
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(s, e), $"Start time of {s} and end time of {e} are outside the allowed range, yet passed.");
        }
    }
}
