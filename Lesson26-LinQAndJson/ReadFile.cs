using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lesson26_LinQAndJson
{
    public class ReadFile
    {
        public static List<Penalty>? GetData(string path)
        {
            StreamReader file = new(path);

            string jsonString = file.ReadToEnd();

            var lst = JsonConvert.DeserializeObject<AppliedPenalties>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            return lst?.appliedPenaltys;
        }
    }
}