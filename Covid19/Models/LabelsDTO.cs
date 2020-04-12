namespace Covid19.Models
{
    public class LabelsDTO
    {
        public string[] Estados { get; set; }
        public string[] Regioes { get; set; }
        public LabelsDTO()
        {
            ConfiguraEstados();
            ConfiguraRegioes();
        }
        private void ConfiguraEstados()
        {
            Estados = new string[] {
                "AC",
                "AL",
                "AM",
                "AP",
                "BA",
                "CE",
                "DF",
                "ES",
                "GO",
                "MA",
                "MG",
                "MS",
                "MT",
                "PA",
                "PB",
                "PE",
                "PI",
                "PR",
                "RJ",
                "RN",
                "RO",
                "RR",
                "RS",
                "SC",
                "SE",
                "SP",
                "TO",
            };
        }

        private void ConfiguraRegioes()
        {
            Regioes = new string[] {
                "Centro-Oeste",
                "Nordeste",
                "Norte",
                "Sudeste",
                "Sul",
            };
        }
    }
}