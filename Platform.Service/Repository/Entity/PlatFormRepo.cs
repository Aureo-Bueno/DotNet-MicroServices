using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Service.Models;
using System.Threading.Tasks;

namespace Platform.Service.Data
{
    public class PlatFormRepo : IPlatFormRepo
    {
        private readonly AppDbContext _context;

        public PlatFormRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlatForm(PlatForm platForm)
        {
            if (platForm == null)
            {
                throw new ArgumentException(nameof(platForm));
            }

            _context.Platforms.Add(platForm);
        }

        public IEnumerable<PlatForm> GetAllPlatForms()
        {
            return _context.Platforms.ToList();
        }

        public PlatForm GetPlatFormId(int id)
        {
            return _context.Platforms.FirstOrDefault(f => f.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
