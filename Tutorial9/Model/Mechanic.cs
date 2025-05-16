using System.ComponentModel.DataAnnotations;

namespace Tutorial9.Model;

public class Mechanic
{
    public int mechanic_id { get; set; }
    [MaxLength(100)]
    public string first_name { get; set; }
    [MaxLength(100)]
    public string last_name { get; set; }
    [MaxLenght(14)]
    public string licence_number { get; set; }
}