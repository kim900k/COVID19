using System;
using System.Collections.Generic;
using System.Linq;

namespace Covid19.Models
{
    public class HighchartModel
    {
        public Chart chart { get; set; }
        public Title title { get; set; }
        public SubTitle subtitle { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public PlotOptions plotOptions { get; set; }
        public HighChartSerie[] series { get; set; }

        public void Default(string titulo, List<DateTime> eixoX, HighChartSerie[] series)
        {
            title = new Title(titulo);
            this.series = series;
            xAxis = new XAxis(eixoX.Select(x => x.ToString("dd/MM/yyyy")).ToArray());
            chart = new Chart();
            subtitle = new SubTitle("Fonte: https://covid.saude.gov.br/");
            yAxis = new YAxis();
            plotOptions = new PlotOptions();
        }
        public HighchartModel(string titulo, List<CasosMortesDiaDTO> lista)
        {
            List<HighChartSerie> series = new List<HighChartSerie>();
            string[] categories = lista.Select(x => x.Label).Distinct().ToArray();
            series.AddRange(categories
                            .Select(x => new HighChartSerie(x, lista.Where(e => e.Label == x).Select(e => e.Casos.Value).ToArray())
                                   )
                           );

            Default(titulo,
                    lista.Select(x => x.Data.Value).ToList(),
                    series.ToArray()
                    );
        }


        public HighchartModel(List<CasosMortesDiaDTO> lista, string titulo)
        {
            List<HighChartSerie> series = new List<HighChartSerie>();
            string[] categories = new[] { "Confirmados", "Óbitos" };
            series.Add(new HighChartSerie("Confirmados", lista.Select(e => e.Casos.Value).ToArray()));
            series.Add(new HighChartSerie("Óbitos", lista.Select(e => e.Mortes.Value).ToArray()));

            Default(titulo,
                    lista.Select(x => x.Data.Value).ToList(),
                    series.ToArray()
                    );
        }


    }

    public class Chart
    {
        public string type { get; set; }
        public string zoomType { get; set; }
        public Chart()
        {
            type = "line";
            zoomType = "x";
        }
    }
    public class Title
    {
        public string text { get; set; }
        public Title(string text)
        {
            this.text = text;
        }
    }
    public class SubTitle
    {
        public string text { get; set; }
        public SubTitle(string text)
        {
            this.text = text;
        }
    }
    public class XAxis
    {
        public string[] categories { get; set; }
        public XAxis(string[] categories)
        {
            this.categories = categories;
        }
    }
    public class YAxis
    {
        public Title title { get; set; }
        public YAxis()
        {
            title = new Title("Quantidade");
        }
    }

    public class PlotOptions
    {
        public Line line { get; set; }
        public PlotOptions()
        {
            line = new Line();
        }
    }
    public class Line
    {
        public bool enableMouseTracking { get; set; }
        public DataLabels dataLabels { get; set; }
        public Line()
        {
            enableMouseTracking = false;
            dataLabels = new DataLabels();
        }
    }
    public class DataLabels
    {
        public bool enabled { get; set; }
        public DataLabels()
        {
            enabled = true;
        }
    }

    
}