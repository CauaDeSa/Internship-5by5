using Newtonsoft.Json;

namespace Lesson26_LinQAndJson
{
    public class Penalty
    {
        public int? Id { get; set; }

        [JsonProperty("razao_social")]
        public string CompanyName { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("nome_motorista")]
        public string DriverName { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigencyDate { get; set; }

        public override string ToString() => $"Id...................: {Id}\nRazão Social.........: {CompanyName}\nCNPJ.................: {Cnpj}\nNome do Motorista....: {DriverName}\nCPF..................: {Cpf}\nVigência do Cadastro.: {VigencyDate:dd/MM/yyyy}";
    }
}