namespace Server.Utility
{
    public class UtiString
    {
        /// <summary>
        /// 过滤字符串留下数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long SampleParse(string str)
        {
            var ret = 0;
            var l = 1;
            foreach (var c in str)
            {
                if (c == '-')
                {
                    l = -l;
                    continue;
                }
                if (c < '0' || c > '9')
                {
                    break;
                }
                ret = ret * 10 + c - '0';
            }
            if (l == -1) return -ret;
            return ret;
        }
    }
}
