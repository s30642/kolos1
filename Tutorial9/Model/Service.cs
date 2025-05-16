using System.ComponentModel.DataAnnotations;

namespace Tutorial9.Model;

public class Service
{
    public int service_id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
   
    public decimal base_fee { get; set; }
}