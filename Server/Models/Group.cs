using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Server.Models;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SqlTableName { get; set; } = string.Empty;
    

    // Cardinality: "1:1", "1:N", "N:N"
    public string Cardinality { get; set; } = "1:1";
    public string Description { get; set; } = string.Empty;
    public bool IsCore { get; set; } = false;

    public int TierId { get; set; }
    
    [JsonIgnore]
    public Tier? Tier { get; set; }

    public ICollection<SchemaAttribute>? Attributes { get; set; } = new List<SchemaAttribute>();
    
    public int? ParentGroupId { get; set; }
    
    [JsonIgnore]
    public Group? ParentGroup { get; set; }
    
    public ICollection<Group> SubGroups { get; set; } = new List<Group>();
}
