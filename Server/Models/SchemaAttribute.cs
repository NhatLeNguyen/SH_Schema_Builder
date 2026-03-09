namespace Server.Models;
using System.Text.Json.Serialization;

public class SchemaAttribute
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SqlColumnName { get; set; } = string.Empty;
    
    // VARCHAR, INT, DECIMAL, DATE, DATETIME, BIT, TEXT, JSON, ENUM, FILE, REF/FK
    public string DataType { get; set; } = string.Empty;
    
    // 1:1, 1:N, N:N
    public string Cardinality { get; set; } = "1:1";
    
    public bool IsRequired { get; set; }
    public string? DefaultValue { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? FkTarget { get; set; } // e.g. "bnt5_hecoquan(Id)"
    
    public bool IsHidden { get; set; }
    public bool HasPermission { get; set; }
    public string Scope { get; set; } = "System"; // System, Admin, User
    public bool IsCore { get; set; } = false;
    
    public int GroupId { get; set; }
    
    [JsonIgnore]
    public Group? Group { get; set; }
}
