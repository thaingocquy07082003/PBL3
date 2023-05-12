using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.DTO
{
    public class CBBItemPhong
    {
        public string Value { get; set; }  // id
        public string Text { get; set; }   // Ten Phong
        public override string ToString()
        {
            return Text;
        }
    }
}
