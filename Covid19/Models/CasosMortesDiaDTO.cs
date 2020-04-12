using System;

namespace Covid19.Models
{
    public class CasosMortesDiaDTO : CovidDTO
    {
        public DateTime? Data { get; set; }
        public string Label { get; set; }
        public int? Casos { get; set; }
        public int? Mortes { get; set; }

        public CasosMortesDiaDTO(int Casos, int Mortes, string Label = null)
        {
            this.Casos = Casos;
            this.Mortes = Mortes;
            this.Label = Label;
        }

        public CasosMortesDiaDTO(DateTime? Data, int Casos, int Mortes, string Label = null)
        {
            this.Data = Data;
            this.Label = Label;
            this.Casos = Casos;
            this.Mortes = Mortes;
        }

    }
}