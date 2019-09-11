using System;
using System.Collections.Generic;

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
        public string Name { get; private set; }
        public IReadOnlyList<PayEntry> PayScale { get; private set; }

        public Family(string name, IReadOnlyList<PayEntry> payScale) {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.PayScale = payScale ?? throw new ArgumentNullException(nameof(payScale));

            if (payScale.Count == 0) throw new ArgumentException("Scale must have at least one entry.", nameof(payScale));
        }

        //TODO This is better abstracted out into a data store
        public static List<Family> GetFamilies() => throw new NotImplementedException();
        public static Family GetTestFamily() => throw new NotImplementedException();
    }
}
