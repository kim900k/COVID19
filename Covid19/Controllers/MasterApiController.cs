using Covid19.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;

namespace Covid19.Controllers
{
    public class MasterApiController : ApiController
    {
        protected const string RotaApi = "Api";
        private string BuscaPath()
        {
            string fileName = $"{DateTime.Now.Date.ToString("dd-MM-yyyy")}.csv";
            return Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data"), Path.GetFileName(fileName));
        }

        protected List<Registro> Interpretar()
        {
            try
            {
                List<Registro> registros = new List<Registro>();
                using(StreamReader reader = new StreamReader(BuscaPath()))
                {
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');
                        if(values[0] == "regiao")
                            continue;

                        registros.Add(new Registro(values[0], values[1], values[2], values[3], values[4], values[5], values[6]));
                    }
                }
                return registros;
            } catch(Exception)
            {
                throw new Exception("Arquivo do dia não encontrado. Faça o upload do arquivo de hoje.");
            }
        }
    }
}
