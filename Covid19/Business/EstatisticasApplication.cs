using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid19.Business
{
    public class EstatisticasApplication
    {
        private List<Registro> registros;
        private string[] Regioes;
        private string[] Estados;
        private bool InicioSurto;

        private bool ArrayTemValor(string[] Array)
        {
            if(Array != null)
                if(Array.Any())
                    return true;
            return false;
        }

        public EstatisticasApplication(List<Registro> registros, string regiao = null, string uf = null, bool inicioSurto = false)
        {
            this.registros = registros;
            Estados = string.IsNullOrEmpty(uf) ? null : uf.ToLower().Split(',');
            Regioes = string.IsNullOrEmpty(regiao) ? null : regiao.ToLower().Split(',');
            InicioSurto = inicioSurto;
        }

        private IEnumerable<Registro> FiltrarPorRegiaoEstadoInicioSurto()
        {
            DateTime inicioSurto = FiltrarPorRegiaoEstado()
                                    .Where(r => r.CasosDoDia > 0)
                                    .OrderBy(r => r.Data)
                                    .Select(r => r.Data)
                                    .FirstOrDefault();

            return FiltrarPorRegiaoEstado()
                    .Where(u => InicioSurto ? u.Data >= inicioSurto : true);
            
        }
        private IEnumerable<Registro> FiltrarPorRegiaoEstado()
        {
            return registros.Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true)
                            .Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true);
        }

        public CasosMortesDiaDTO TotalAcumulado()
        {
            return new CasosMortesDiaDTO(FiltrarPorRegiaoEstadoInicioSurto().Sum(r => r.CasosDoDia), FiltrarPorRegiaoEstadoInicioSurto().Sum(r => r.MortesDoDia));
        }

        public List<CasosMortesDiaDTO> AcumuladoPorDiaRegiao()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => new { r.Data, r.Regiao })
                    .Select(r => new CasosMortesDiaDTO(r.Key.Data, r.Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true).Sum(item => item.CasosAcumulados), r.Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true).Sum(item => item.MortesAcumuladas), r.Key.Regiao))
                    .OrderBy(r => r.Label)
                    .ThenBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> AcumuladoPorDiaEstado()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => new { r.Data, r.Estado })
                    .Select(r => new CasosMortesDiaDTO(r.Key.Data, r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosAcumulados), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesAcumuladas), r.Key.Estado))
                    .OrderBy(r => r.Label)
                    .ThenBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> AcumuladoPorDia()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => r.Data)
                    .Select(r => new CasosMortesDiaDTO(r.Key, r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosAcumulados), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesAcumuladas)))
                    .OrderBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> IsoladoPorDia()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => r.Data)
                    .Select(r => new CasosMortesDiaDTO(r.Key, r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosDoDia), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesDoDia)))
                    .OrderBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> IsoladoPorDiaRegiao()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => new { r.Data, r.Regiao })
                    .Select(r => new CasosMortesDiaDTO(r.Key.Data, r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosDoDia), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesDoDia), r.Key.Regiao))
                    .OrderBy(r => r.Label)
                    .ThenBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> IsoladoPorDiaEstado()
        {
            return FiltrarPorRegiaoEstadoInicioSurto()
                    .GroupBy(r => new { r.Data, r.Estado })
                    .Select(r => new CasosMortesDiaDTO(r.Key.Data, r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosDoDia), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesDoDia), r.Key.Estado))
                    .OrderBy(r => r.Label)
                    .ThenBy(r => r.Data)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> TotalAcumuladoPorRegiao()
        {
            return registros
                    .Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true)
                    .GroupBy(r => r.Regiao)
                    .Select(r => new CasosMortesDiaDTO(r.Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true).Sum(item => item.CasosDoDia), r.Where(u => ArrayTemValor(Regioes) ? Regioes.Contains(u.Regiao.ToLower()) : true).Sum(item => item.MortesDoDia), r.Key))
                    .OrderBy(r => r.Label)
                    .ToList();
        }

        public List<CasosMortesDiaDTO> TotalAcumuladoPorEstado()
        {
            return registros
                    .Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true)
                    .GroupBy(r => r.Estado)
                    .Select(r => new CasosMortesDiaDTO(r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.CasosDoDia), r.Where(u => ArrayTemValor(Estados) ? Estados.Contains(u.Estado.ToLower()) : true).Sum(item => item.MortesDoDia), r.Key))
                    .OrderBy(r => r.Label)
                    .ThenBy(r => r.Data)
                    .ToList();
        }
    }
}