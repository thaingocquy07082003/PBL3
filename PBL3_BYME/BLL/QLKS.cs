using System.Collections.Generic;

namespace PBL3_BYME.BLL
{
    internal class QLKS
    {
        internal IEnumerable<object> ChiTietThuePhongs;

        public QLKS()
        {
        }

        public IEnumerable<object> ChiTietSuDungDichVus { get; internal set; }
    }
}