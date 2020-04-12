using System.Linq;

namespace Covid19.Models
{
    public class HighChartSerie
    {
        public string name { get; set; }
        public decimal[] data { get; set; }

        public HighChartSerie(string name, int[] data)
        {
            this.name = name;
            this.data = data.Select(x => (decimal)x).ToArray();
        }
        public HighChartSerie()
        {

        }
    }
}