using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BabysitterKata.Tests {
    [TestClass]
    public class OutOfRangeHours {
        private readonly BabySitter sitter;

        public OutOfRangeHours() => this.sitter = BabySitter.GetDefault();

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
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(d, end), $"Start time of {d} is outside the allowed range.");
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
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => this.sitter.CalculatePay(start, d), $"End time of {d} is outside the allowed range.");
        }
    }
}
