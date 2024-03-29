using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BabysitterKata.Tests {
    [TestClass]
    public class InvalidHours {
        private readonly Family family;
        private readonly Babysitter sitter;

        public InvalidHours() {
            this.family = Family.GetTestFamily();
            this.sitter = new Babysitter(Babysitter.DefaultStartTime, Babysitter.DefaultEndTime);
        }

        [TestMethod]
        public void EndComesBeforeStartThrows() {
            var data = new List<(TimeSpan, TimeSpan)> {
                (new TimeSpan(23, 0, 0), new TimeSpan(22, 0, 0)),
                (new TimeSpan(24, 0, 0), new TimeSpan(22, 0, 0)),
                (new TimeSpan(27, 0, 0), new TimeSpan(26, 0, 0)),
                (new TimeSpan(26, 0, 0), new TimeSpan(22, 0, 0)),
                (new TimeSpan(24, 0, 0), new TimeSpan(22, 0, 0)),
                (new TimeSpan(25, 0, 0), new TimeSpan(24, 0, 0)),
            };

            foreach (var (s, e) in data)
                Assert.ThrowsException<ArgumentException>(() => this.sitter.CalculatePay(this.family, s, e), $"End time of {e} comes before start time of {s}, yet passed");
        }

        [TestMethod]
        public void FractionalHoursThrows() {
            var data = new List<(TimeSpan, TimeSpan)> {
                (new TimeSpan(22, 5, 0), new TimeSpan(25, 23, 0)),
                (new TimeSpan(23, 9, 25), new TimeSpan(26, 45, 33)),
                (new TimeSpan(18, 12, 0), new TimeSpan(22, 0, 0)),
                (new TimeSpan(19, 34, 12), new TimeSpan(23, 0, 0)),
                (new TimeSpan(20, 4, 0), new TimeSpan(24, 5, 0)),
                (new TimeSpan(21, 5, 6), new TimeSpan(23, 56, 34)),
                (new TimeSpan(20, 0, 0), new TimeSpan(24, 5, 0)),
                (new TimeSpan(21, 0, 0), new TimeSpan(23, 56, 34)),
            };

            foreach (var (s, e) in data)
                Assert.ThrowsException<ArgumentException>(() => this.sitter.CalculatePay(this.family, s, e), $"Start time {s} and end time {e} had fractional parts, yet passed");
        }

        [TestMethod]
        public void FractionalEndBeforeStartHourThrows() {
            var data = new List<(TimeSpan, TimeSpan)> {
                (new TimeSpan(22, 12, 0), new TimeSpan(21, 35, 0)),
                (new TimeSpan(23, 33, 12), new TimeSpan(22, 45, 25)),
                (new TimeSpan(18, 25, 0), new TimeSpan(17, 0, 0)),
                (new TimeSpan(19, 45, 45), new TimeSpan(18, 0, 0)),
                (new TimeSpan(20, 16, 0), new TimeSpan(19, 5, 0)),
                (new TimeSpan(21, 59, 6), new TimeSpan(20, 57, 7)),
                (new TimeSpan(20, 0, 0), new TimeSpan(19, 5, 0)),
                (new TimeSpan(21, 0, 0), new TimeSpan(20, 7, 36)),
            };

            foreach (var (s, e) in data)
                Assert.ThrowsException<ArgumentException>(() => this.sitter.CalculatePay(this.family, s, e), $"Start time {s} and end time {e} had fractional parts and were swapped, yet passed");
        }
    }
}
