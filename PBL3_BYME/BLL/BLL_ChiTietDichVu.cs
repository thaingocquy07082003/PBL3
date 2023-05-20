using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class BLL_ChiTietDichVu
    {
        QLKSEntities db = new QLKSEntities();

        // Lay ra cac Dich vu 
        public List<DichVu> GetAllDichVu()
        {
            List<DichVu> data = new List<DichVu>();
            foreach(DichVu i in db.DichVus.ToList())
            {
                data.Add(i);
            }
            return data;
        }

        // 
    }
}
