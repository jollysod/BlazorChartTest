using System.ComponentModel.DataAnnotations;

namespace DataAccessCore.Models
{
  public class PageSumChartQueryModel
	{
    [Required]
    public string GRP_ID { get; set; }
    [Required]
    public string COMPANY_ID { get; set; }
    [Required]
    public int Mono_Totals { get; set; }
    [Required]
    public int Colour_Totals { get; set; }
  }
}
