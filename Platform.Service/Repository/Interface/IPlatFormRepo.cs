using Platform.Service.Models;
using System.Collections.Generic;

namespace Platform.Service.Data
{
    public interface IPlatFormRepo
    {
        bool SaveChanges();
        IEnumerable<PlatForm> GetAllPlatForms();
        PlatForm GetPlatFormId(int id);
        void CreatePlatForm(PlatForm platForm);
    }
}
