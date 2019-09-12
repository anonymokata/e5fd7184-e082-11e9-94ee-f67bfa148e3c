using System;
using System.Collections.Generic;
using System.Linq;

namespace BabysitterKata.Core {
    public class PayEntry {
        public TimeSpan StartTime { get; private set; }
        public int Pay { get; private set; }

        public PayEntry(TimeSpan startTime, int pay) {
            if (pay <= 0) throw new ArgumentOutOfRangeException(nameof(pay));

            this.StartTime = startTime;
            this.Pay = pay;
        }
    }

    public class Family {
        private static readonly List<Family> families = new List<Family> {
            new Family("A", new List<PayEntry> {
                new PayEntry(new TimeSpan(5, 0, 0), 15),
                new PayEntry(new TimeSpan(23, 0, 0), 20),
            }),
            new Family("B", new List<PayEntry> {
                new PayEntry(new TimeSpan(5, 0, 0), 12),
                new PayEntry(new TimeSpan(22, 0, 0), 8),
                new PayEntry(new TimeSpan(0, 0, 0), 16),
            }),
            new Family("C", new List<PayEntry> {
                new PayEntry(new TimeSpan(5, 0, 0), 21),
                new PayEntry(new TimeSpan(21, 0, 0), 15),
            }),
        };

        public string Name { get; private set; }
        public IReadOnlyList<PayEntry> PayScale { get; private set; }

        public Family(string name, IReadOnlyList<PayEntry> payScale) {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.PayScale = payScale ?? throw new ArgumentNullException(nameof(payScale));

            if (payScale.Count == 0) throw new ArgumentException("Scale must have at least one entry.", nameof(payScale));

            for (var i = 1; i < payScale.Count; i++)
                if (payScale[i].StartTime <= payScale[i - 1].StartTime)
                    throw new ArgumentException("Scale is not sorted", nameof(payScale));
        }

        //TODO This is better abstracted out into a data store
        public static List<Family> GetFamilies() => Family.families;
        public static Family GetFamily(string name) => Family.GetFamilies().SingleOrDefault(f => f.Name == name);
        public static Family GetTestFamily() => Family.GetFamilies().First();
    }
}
