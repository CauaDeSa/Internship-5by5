using System.Xml.Linq;

namespace Lesson26_LinQAndJson
{
    public class TestFilters
    {
        public static int GetCountRecords(List<Penalty> lst) => lst.Count;

        public static string GenerateXML(List<Penalty> lst)
        {
            if (lst.Count == 0)
                return "There are no registers.";
            
            return new XElement("Root", from data in lst
                                        select new XElement("motorista",
                                        new XElement("razao_social", data.CompanyName),
                                        new XElement("cnpj", data.Cnpj),
                                        new XElement("nome_motorista", data.DriverName),
                                        new XElement("cpf", data.Cpf),
                                        new XElement("vigencia_cadastro", data.VigencyDate)
                                        )).ToString();
        }

        public static List<Penalty> GetPenaltiesByCPF(List<Penalty> lst, string cpf) => lst.Where(x => x.Cpf.StartsWith(cpf)).ToList();

        public static List<Penalty> GetPenaltiesByCompanyName(List<Penalty> lst, string name) => lst.Where(x => x.CompanyName.Contains(name)).ToList();

        public static List<Penalty> GetPenaltiesByVigencyYear(List<Penalty> lst, int year) => lst.Where(x => x.VigencyDate.Year == year).ToList();

        public static List<Penalty> OrderedByCompanyName(List<Penalty> lst) => lst.OrderBy(x => x.CompanyName).ToList();
    }
}