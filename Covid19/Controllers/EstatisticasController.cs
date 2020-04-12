using Covid19.Business;
using Covid19.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Covid19.Controllers
{
    public class EstatisticasController : MasterApiController
    {
        #region valores
        [HttpGet]
        [Route(RotaApi + "/Estatisticas/TotalAcumulado")]
        public IHttpActionResult TotalAcumulado(string regiao = null, string uf = null, bool inicioSurto = false)
        {
            try
            {
                return Ok(new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).TotalAcumulado());
            } catch(Exception e) { return InternalServerError(e); }
        }
        #endregion

        #region tabelas
        [HttpGet]
        [Route(RotaApi + "/Estatisticas/TotalAcumuladoPorEstado")]
        public IHttpActionResult TotalAcumuladoPorEstado(string uf = null, bool inicioSurto = false)
        {
            try
            {
                return Ok(new EstatisticasApplication(Interpretar(), null, uf, inicioSurto).TotalAcumuladoPorEstado());
            } catch(Exception e) { return InternalServerError(e); }
        }

        [HttpGet]
        [Route(RotaApi + "/Estatisticas/TotalAcumuladoPorRegiao")]
        public IHttpActionResult TotalAcumuladoPorRegiao(string regiao = null, bool inicioSurto = false)
        {
            try
            {
                return Ok(new EstatisticasApplication(Interpretar(), regiao, null, inicioSurto).TotalAcumuladoPorRegiao());
            } catch(Exception e) { return InternalServerError(e); }
        }
        #endregion

        #region charts

        #region acumulado
        [HttpGet]
        [Route(RotaApi + "/Estatisticas/AcumuladoPorDiaRegiao")]
        public IHttpActionResult AcumuladoPorDiaRegiao(string uf = null, string regiao = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).AcumuladoPorDiaRegiao();

                return Ok(chartMode ? new HighchartModel("Casos acumulados por região", lista) as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }

        [HttpGet]
        [Route(RotaApi + "/Estatisticas/AcumuladoPorDiaEstado")]
        public IHttpActionResult AcumuladoPorDiaEstado(string uf = null, string regiao = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).AcumuladoPorDiaEstado();

                return Ok(chartMode ? new HighchartModel("Casos acumulados por estado", lista) as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }

        [HttpGet]
        [Route(RotaApi + "/Estatisticas/AcumuladoPorDia")]
        public IHttpActionResult AcumuladoPorDia(string regiao = null, string uf = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).AcumuladoPorDia();

                return Ok(chartMode ? new HighchartModel(lista, "Casos acumulados") as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }
        #endregion

        #region isolados
        [HttpGet]
        [Route(RotaApi + "/Estatisticas/IsoladoPorDia")]
        public IHttpActionResult IsoladoPorDia(string regiao = null, string uf = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).IsoladoPorDia();

                return Ok(chartMode ? new HighchartModel(lista, "Casos novos por dia") as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }

        [HttpGet]
        [Route(RotaApi + "/Estatisticas/IsoladoPorDiaRegiao")]
        public IHttpActionResult IsoladoPorDiaRegiao(string uf = null, string regiao = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).IsoladoPorDiaRegiao();

                return Ok(chartMode ? new HighchartModel("Casos novos por região", lista) as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }

        [HttpGet]
        [Route(RotaApi + "/Estatisticas/IsoladoPorDiaEstado")]
        public IHttpActionResult IsoladoPorDiaEstado(string uf = null, string regiao = null, bool chartMode = false, bool inicioSurto = false)
        {
            try
            {
                List<CasosMortesDiaDTO> lista = new EstatisticasApplication(Interpretar(), regiao, uf, inicioSurto).IsoladoPorDiaEstado();

                return Ok(chartMode ? new HighchartModel("Casos novos por estado", lista) as object : lista);
            } catch(Exception e) { return InternalServerError(e); }
        }
        #endregion

        #endregion
    }
}
