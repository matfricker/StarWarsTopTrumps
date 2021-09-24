using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StarWarsTopTrumps.Tests
{
    public class TestValues
    {
        [Fact]
        public void HandleRange()
        {
            // 30-165
            string value = "30-165";
            int max = 0;
            int min =0;
            if (value.Contains('-'))
            {
                var range = value.Split('-');
                List<int> values = new();
                foreach (var item in range)
                {
                    values.Add(int.Parse(item));
                }

                max = values.Max();
                min = values.Min();
            }

            Assert.IsType<int>(max);
            Assert.IsType<int>(min);
            Assert.True(max > min);
        }
    }
}