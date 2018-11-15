using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes
{
    public class BirthDeathReturn
    {
        public List<BirthDeath> BirthDeaths { get; set; }
        public List<int> PopularYears { get; set; }
        public List<int> DataSet { get; set; }
        public List<int> Years { get; set; } = new List<int>();
    }
   public class BirthDeath
    {
        public string Birth { get; set; }
        public string Death { get; set; }

        public static BirthDeath FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            BirthDeath birthDeath = new BirthDeath
            {
                Birth = values[0],
                Death = values[1]
            };

            return birthDeath;
        }
    }
}
