using System.Text;

namespace CountAndSayLeetCode
{
    public class Solution
    {
        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";

            string previous = CountAndSay(n - 1);
            return GetCurrentSequence(previous);
        }
        private string GetCurrentSequence2(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in str)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch]++;
                }
                else map.Add(ch, 1);
            }
            StringBuilder result = new StringBuilder();
            foreach (var kv in map)
            {
                result.Append(kv.Value);
                result.Append(kv.Key);
            }

            return result.ToString();
        }
        private string GetCurrentSequence(string str)
        {
            StringBuilder result = new StringBuilder();
            int count = 1;
            char ch = str[0];

            for (int i = 0; i < str.Length-1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    count++;
                }
                else
                {
                    result.Append(count);
                    result.Append(ch);
                    count = 1;
                    ch = str[i+1];
                }
            }
            result.Append(count);
            result.Append(ch);

            return result.ToString();
        }
    }
}
