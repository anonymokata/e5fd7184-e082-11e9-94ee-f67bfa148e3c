using System;

namespace BabysitterKata.Core {
    public class Babysitter {
        public static TimeSpan DefaultStartTime { get; } = new TimeSpan(17, 0, 0);
        public static TimeSpan DefaultEndTime { get; } = new TimeSpan(4, 0, 0);

        public Babysitter(TimeSpan startTime, TimeSpan endtime) {

        }

        public int CalculatePay(TimeSpan startTime, TimeSpan endtime) {
            return 0;
        }
    }
}
