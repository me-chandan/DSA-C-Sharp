namespace Problem3Sum
{
    public class ThreeSum
    {
        public IList<IList<int>> GetThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                //skip duplicates and fix one element
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                var twoSum = TwoSum(nums, -nums[i], i + 1);

                if (twoSum.Count > 0)
                {
                    foreach (var item in twoSum)
                    {
                        item.Insert(0, nums[i]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        private IList<IList<int>> TwoSum(int[] nums, int target, int start)
        {
            int i = start, j = nums.Length - 1;
            IList<IList<int>> result = new List<IList<int>>();
            while (i < j)
            {
                int sum = nums[i] + nums[j];

                if (sum == target)
                {
                    result.Add(new List<int> { nums[i], nums[j] });
                    //skip duplicates
                    while (i < j && nums[i] == nums[i + 1])
                    {
                        i++;
                    }
                    while (i < j && nums[j] == nums[j - 1])
                    {
                        j--;
                    }
                    i++;
                    j--;
                }
                else if (sum > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return result;
        }
    }
}
