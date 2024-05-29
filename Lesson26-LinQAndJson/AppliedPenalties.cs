using Newtonsoft.Json;

namespace Lesson26_LinQAndJson
{
    public class AppliedPenalties
    {
        [JsonProperty("penalidades_aplicadas")]
        public List<Penalty> appliedPenaltys { get; set; }

        public static void PrintData(List<Penalty> lst)
        {
            foreach (var p in lst)
                Console.WriteLine(p + "\n");
        }
    }
}