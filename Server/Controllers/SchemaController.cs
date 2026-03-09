using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SchemaController : ControllerBase
{
    private readonly AppDbContext _context;

    public SchemaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("tiers")]
    public async Task<IActionResult> GetTiers()
    {
        var tiers = await _context.Tiers
            .Include(t => t.Groups)
            .ThenInclude(g => g.Attributes)
            .ToListAsync();
        return Ok(tiers);
    }

    [HttpPost("groups")]
    public async Task<IActionResult> CreateGroup([FromBody] Group group)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Cần xóa reference vòng lặp khi tạo mới
        group.Tier = null!;
        _context.Groups.Add(group);
        await _context.SaveChangesAsync();
        return Ok(group);
    }

    [HttpPut("groups/{id}")]
    public async Task<IActionResult> UpdateGroup(int id, [FromBody] Group group)
    {
        if (id != group.Id) return BadRequest("ID mismatch");
        if (group.Tier != null) group.Tier = null!; // Avoid modifying tier
        
        _context.Entry(group).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("groups/{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        var group = await _context.Groups.Include(g => g.Attributes).FirstOrDefaultAsync(g => g.Id == id);
        if (group == null) return NotFound();
        
        if (group.IsCore) return BadRequest(new { message = "Không thể xóa nhóm dữ liệu cốt lõi (Core)." });

        _context.Attributes.RemoveRange(group.Attributes);
        _context.Groups.Remove(group);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("attributes")]
    public async Task<IActionResult> CreateAttribute([FromBody] SchemaAttribute attribute)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        bool exists = await _context.Attributes.AnyAsync(a => a.SqlColumnName == attribute.SqlColumnName);
        if (exists) return BadRequest(new { message = "Cột SQL đã tồn tại, yêu cầu tên duy nhất." });

        if (attribute.Group != null) attribute.Group = null!;

        _context.Attributes.Add(attribute);
        await _context.SaveChangesAsync();
        return Ok(attribute);
    }

    [HttpPut("attributes/{id}")]
    public async Task<IActionResult> UpdateAttribute(int id, [FromBody] SchemaAttribute attribute)
    {
        if (id != attribute.Id) return BadRequest("ID mismatch");

        bool exists = await _context.Attributes.AnyAsync(a => a.SqlColumnName == attribute.SqlColumnName && a.Id != id);
        if (exists) return BadRequest(new { message = "Cột SQL đã tồn tại, yêu cầu tên duy nhất." });

        if (attribute.Group != null) attribute.Group = null!;

        _context.Entry(attribute).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("attributes/{id}")]
    public async Task<IActionResult> DeleteAttribute(int id)
    {
        var attribute = await _context.Attributes.FindAsync(id);
        if (attribute == null) return NotFound();

        if (attribute.IsCore) return BadRequest(new { message = "Không thể xóa thuộc tính cốt lõi (Core)." });

        _context.Attributes.Remove(attribute);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
