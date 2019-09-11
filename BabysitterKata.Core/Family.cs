using System;
using System.Collections.Generic;

namespace BabysitterKata.Core {
    public class PayEntry {
        public TimeSpan StartTime { get; private set; }
        public int Pay { get; private set; }

        public PayEntry(TimeSpan startTime, int pay) {
            this.StartTime = startTime;
            this.Pay = pay;
        }
    }

    public class Family {
        public string Name { get; private set; }
        public IReadOnlyList<PayEntry> PayScale { get; private set; }

        private Family(string name, IReadOnlyList<PayEntry> payScale) {
            this.Name = name;
            this.PayScale = payScale;
        }

        //TODO This is better abstracted out into a data store
        public static List<Family> GetFamilies() => throw new NotImplementedException();
    }
}
