using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

[Authorize]
[ApiController]
[Route("api/records")]
public class RecordsController : ControllerBase
{
    private readonly RecordService _service;

    public RecordsController(RecordService service)
    {
        _service = service;
    }

    [HttpGet] //Filter
    public IActionResult Get(string? type, string? category, DateTime? startDate, DateTime? endDate)
    {
        var data = _service.GetAll().AsQueryable();

        if (!string.IsNullOrEmpty(type))
        {
            data = data.Where(x => x.Type == type);
        }

        if (!string.IsNullOrEmpty(category))
        {
            data = data.Where(x => x.Category == category);
        }

        if (startDate.HasValue && endDate.HasValue)
        {
            data = data.Where(x => x.Date >= startDate && x.Date <= endDate.Value);
        }

        return Ok(data.ToList());
    }

    [HttpPost]
    public IActionResult Post(FinancialRecord record)
    {

        record.CreatedBy = 1;
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_service.Add(record));
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, FinancialRecord record)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updated = _service.Update(id, record);

        if (updated == null)
        {
            return NotFound("Record not found");
        }

        return Ok(updated);
    }


}