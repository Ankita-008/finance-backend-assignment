using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public IActionResult GetSummary()
        {
            var records = _context.FinancialRecords.ToList();

            var income = records
                .Where(x => x.Type == "Income")
                .Sum(x => x.Amount);

            var expense = records
                .Where(x => x.Type == "Expense")
                .Sum(x => x.Amount);

            var categoryWise = records
                .GroupBy(x => x.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(x => x.Amount)
                })
                .ToList();

            var recent = records
                .OrderByDescending(x => x.Date)
                .Take(5)
                .ToList();

            var monthlyTrends = records
                .GroupBy(x => new { x.Date.Year, x.Date.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalIncome = g.Where(x => x.Type == "Income").Sum(x => x.Amount),
                    TotalExpense = g.Where(x => x.Type == "Expense").Sum(x => x.Amount)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            var weeklyTrends = records
                .GroupBy(x => System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    x.Date,
                    System.Globalization.CalendarWeekRule.FirstDay,
                    DayOfWeek.Monday))
                .Select(g => new
                {
                    Week = g.Key,
                    TotalIncome = g.Where(x => x.Type == "Income").Sum(x => x.Amount),
                    TotalExpense = g.Where(x => x.Type == "Expense").Sum(x => x.Amount)
                })
                .OrderBy(x => x.Week)
                .ToList();

            return Ok(new
            {
                TotalIncome = income,
                TotalExpense = expense,
                Balance = income - expense,
                CategoryWise = categoryWise,
                Recent = recent,
                MonthlyTrends = monthlyTrends,
                WeeklyTrends = weeklyTrends
            });
        }
    }
}