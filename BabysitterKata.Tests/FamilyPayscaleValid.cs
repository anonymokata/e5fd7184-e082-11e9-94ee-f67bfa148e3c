using BabysitterKata.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BabysitterKata.Tests {
    [TestClass]
    public class FamilyPayscaleValid {
        private readonly List<Family> families;

        public FamilyPayscaleValid() => this.families = Family.GetFamilies();

        [TestMethod]
        public void StartHourInScaleMatches() {
            foreach (var f in this.families)
                Assert.AreEqual(f.PayScale.FirstOrDefault()?.StartTime, Babysitter.DefaultStartTime, $"Payscale start time for family {f.Name} does not match the default {Babysitter.DefaultStartTime}");
        }

        [TestMethod]
        public void ScaleNotEmpty() {
            foreach (var f in this.families)
                Assert.IsTrue(f.PayScale.Any(), $"Family {f.Name} has no payscale.");
        }

        [TestMethod]
        public void PayIsPositive() {
            foreach (var d in this.families)
                foreach (var p in d.PayScale)
                Assert.IsTrue(p.Pay > 0, $"Family {f.Name} has no payscale.");
        }
    }
}
