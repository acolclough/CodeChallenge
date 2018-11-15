using CodeChallenge.Classes;
using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    public class DataModule : NancyModule
    {
        public DataModule() : base("/api")
        {
            Get["/GetData"] = _ =>
            {
                var returnObject = new BirthDeathReturn();
                //This downloads the CSV file and passes it into a custom fromCSV function.
                List<BirthDeath> values = File.ReadAllLines("Assets/dataset.csv")
                                          .Skip(1)
                                          .Select(v => BirthDeath.FromCsv(v))
                                          .ToList();
                returnObject.BirthDeaths = values;

                //This initalises an array that allows 1900-2000 to fit inside.
                int[] yearOccurences = new int[101];

                //This foreach iterates over each person in the CSV file and then iterates between every year they are born to the year they die. Then the number that placed in that location in 'yearOccurences' is incremented by one each time.
                foreach (var person in values)
                {
                    var birth = Convert.ToInt32(person.Birth);
                    var death = Convert.ToInt32(person.Death);
                    for (var i = birth - 1900; i <= death - 1900; i++)
                    {
                        yearOccurences[i]++;
                    }
                }
                //This linq statement is what figures out the most common year for people to be alive during. Just doing yearOccurences.Max() is enough if there is only one, but the extra steps must be taken to ensure that the result is multiple.
                var year = yearOccurences.Select((item, i) => new { Item = item, Index = i })
                    .Where(v => v.Item.Equals(yearOccurences.Max()))
                    .Select(v => v.Index + 1900)
                    .ToList();

                returnObject.PopularYears = year;
                returnObject.DataSet = yearOccurences.ToList();

                for(var uniqueYear = 0; uniqueYear < yearOccurences.Length; uniqueYear++)
                {
                    returnObject.Years.Add(uniqueYear + 1900);
                }
                return Response.AsJson(returnObject);
            };

        }
    }
}
