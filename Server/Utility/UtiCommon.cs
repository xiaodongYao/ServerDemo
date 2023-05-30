namespace Server.Utility
{
    public class UtiCommon
    {
        public static bool CheckRepeat(List<int> list, int exceptid)
        {
            var set = new HashSet<int>();
            foreach (var item in list)
            {
                if (item == exceptid)
                {
                    continue;
                }

                if (set.Contains(item)) return false;
                set.Add(item);
            }

            return true;
        }
    }
}
