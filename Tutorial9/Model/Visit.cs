using System.ComponentModel.DataAnnotations;

namespace Tutorial9.Model;

public class Visit
{
    public int visit_id { get; set; }
    public int client_id { get; set; }
    public int mechanic_id { get; set; }
    public DateTime Date { get; set; }
}