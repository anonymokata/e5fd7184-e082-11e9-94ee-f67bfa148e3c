using System;

namespace BabysitterKata.Core {
    public class Babysitter {
        public static Babysitter GetDefault() {
            return new Babysitter();
        }

        public int CalculatePay(TimeSpan startTime, TimeSpan endtime) {
            return 0;
        }
    }
}
