using System.Collections.Generic;

namespace Server.Models;

public class Tier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nature { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}
