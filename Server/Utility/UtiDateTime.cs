namespace Server.Utility
{
    public class UtiDateTime
    {
        private static uint _WeekBegin = UnixStamp(new DateTime(2018, 1, 1));

        /// <summary>
        /// TimeStamp to DateTime
        /// </summary>
        /// <param name="timeStamp">timeStamp</param>
        /// <returns></returns>
        public static DateTime UnixStampToDateTime(uint timeStamp)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0);
            return dt.AddSeconds(timeStamp);
        }

        /// <summary>
        /// 1970.1.1 0:0:0 到现在的时间戳
        /// </summary>
        /// <returns></returns>
        public static uint UnixStamp()
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0);
            var timeSpan = DateTime.Now - dt;
            return Convert.ToUInt32(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// 1970.1.1 0:0:0 到指定时间的时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>

        public static uint UnixStamp(DateTime dateTime)
        {
            var dt = new DateTime(1970, 1, 1, 0, 0, 0);
            var timeSpan = dateTime - dt;
            return Convert.ToUInt32(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// 计算指定时间戳是第几周
        /// _WeekBegin 第一周
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static int CalcWeek(uint timeStamp)
        {
            var openDate = UnixStampToDateTime(_WeekBegin);
            var openWeekDay = openDate.DayOfWeek; //2018/1/1 是周几
            var addDays = openWeekDay == DayOfWeek.Sunday ? -6 : -((int)openWeekDay - 1);

            var openWeekBegin = openDate.AddDays(addDays).Date;//2018/1/1 这周的周一日期

            return (int)((timeStamp - UnixStamp(openWeekBegin)) / (3600 * 24 * 7)) + 1;
        }

        /// <summary>
        /// 指定时间对应是单周还是双周
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static bool IsOddWeek(uint timeStamp) => CalcWeek(timeStamp) % 2 == 1;

        /// <summary>
        /// 求现在是某个刷新周期中的第几天
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <param name="repeat">刷新周期</param>
        /// <returns></returns>
        public static int GetTimeDiffDay(uint timeStamp, int repeat = 0)
        {
            var sub = (int)(UnixStamp() - timeStamp);
            if (repeat > 0) {
                sub %= repeat * 3600 * 24; //刷新周期剩下的时间
            }
            var div = sub / 3600 * 24;
            return div + 1;
        }
    }
}
