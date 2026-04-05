using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class RecordService
    {
        private readonly AppDbContext _context;

        public RecordService(AppDbContext context)
        {
            _context = context;
        }

        public List<FinancialRecord> GetAll()
        {
            return _context.FinancialRecords.ToList();
        }

        public FinancialRecord Add(FinancialRecord record)
        {
            record.CreatedBy = 1; 

            _context.FinancialRecords.Add(record);
            _context.SaveChanges();
            return record;
        }

        public FinancialRecord Update(int id, FinancialRecord record)
        {
            var existing = _context.FinancialRecords.Find(id);

            if (existing == null)
            {
                return null;
            }

            existing.Amount = record.Amount;
            existing.Type = record.Type;
            existing.Category = record.Category;
            existing.Date = record.Date;
            existing.Note = record.Note;

            _context.SaveChanges();

            return existing;
        }

        public void Delete(int id)
        {
            var data = _context.FinancialRecords.Find(id);
            if (data != null)
            {
                _context.FinancialRecords.Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
