using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid19.Models
{
    public class Registro
    {
        public string Regiao { get; set; }
        public string Estado { get; set; }
        public DateTime Data { get; set; }
        public int CasosAcumulados { get; set; }
        public int CasosDoDia { get; set; }
        public int MortesAcumuladas { get; set; }
        public int MortesDoDia { get; set; }

        public Registro()
        {

        }

        public Registro(string Regiao, string Estado, string Data, string CasosDoDia, string CasosAcumulados, string MortesDoDia, string MortesAcumuladas)
        {
            string[] dataSplitted = Data.Split('/');

            Configurar(Regiao,
                       Estado,
                       new DateTime(Convert.ToInt32(dataSplitted[2]), Convert.ToInt32(dataSplitted[1]), Convert.ToInt32(dataSplitted[0])),
                       Convert.ToInt32(CasosAcumulados),
                       Convert.ToInt32(CasosDoDia),
                       Convert.ToInt32(MortesAcumuladas),
                       Convert.ToInt32(MortesDoDia)
                       );
        }

        private void Configurar(string Regiao, string Estado, DateTime Data, int CasosAcumulados, int CasosDoDia, int MortesAcumuladas, int MortesDoDia)
        {
            this.Regiao = Regiao;
            this.Estado = Estado;
            this.Data = Data;
            this.CasosAcumulados = CasosAcumulados;
            this.CasosDoDia = CasosDoDia;
            this.MortesAcumuladas = MortesAcumuladas;
            this.MortesDoDia = MortesDoDia;
        }
    }
}