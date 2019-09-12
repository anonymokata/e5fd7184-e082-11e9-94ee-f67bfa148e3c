using System;

namespace BabysitterKata.Core {
    public class Babysitter {
        private readonly TimeSpan startTime;
        private readonly TimeSpan endTime;

        //TODO These are better stored in a data store
        public static TimeSpan DefaultStartTime { get; } = new TimeSpan(17, 0, 0);
        public static TimeSpan DefaultEndTime { get; } = new TimeSpan(4, 0, 0);

        public Babysitter(TimeSpan startTime, TimeSpan endtime) {
            this.startTime = startTime;
            this.endTime = endtime;
        }

        public int CalculatePay(Family family, TimeSpan startTime, TimeSpan endtime) {
            return 0;
        }
    }
}
