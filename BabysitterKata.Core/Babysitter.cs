using System;

namespace BabysitterKata.Core {
    public class Babysitter {
        private readonly TimeSpan startTime;
        private readonly TimeSpan endTime;

        //TODO These are better stored in a data store
        public static TimeSpan DefaultStartTime { get; } = new TimeSpan(17, 0, 0);
        public static TimeSpan DefaultEndTime { get; } = new TimeSpan(28, 0, 0);

        public Babysitter(TimeSpan startTime, TimeSpan endtime) {
            this.startTime = startTime;
            this.endTime = endtime;
        }

        public int CalculatePay(Family family, TimeSpan startTime, TimeSpan endtime) {
            if (family == null) throw new ArgumentNullException(nameof(family));
            if (startTime.TotalMinutes % 60 != 0) throw new ArgumentException("Fractional hours not allowed", nameof(startTime));
            if (endtime.TotalMinutes % 60 != 0) throw new ArgumentException("Fractional hours not allowed", nameof(endtime));

            if (startTime < this.startTime) throw new ArgumentOutOfRangeException(nameof(startTime));
            if (endtime > this.endTime) throw new ArgumentOutOfRangeException(nameof(endtime));

            if (endtime < startTime) throw new ArgumentException("End is before start");

            var pay = 0;
            for (var current = startTime.TotalHours + 1; current <= endtime.TotalHours; current++)
                pay += family.FindPayEntryAtTime(TimeSpan.FromHours(current)).Pay;

            return pay;
        }
    }
}
