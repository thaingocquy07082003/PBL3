﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class QL_KhachHang
    {
        private QLKSEntities db = new QLKSEntities();
        // Lay tat ca khach hang trong csdl tra ve 1 list cac KhachHangView
        public List<KhachHangView> getAllKhachHang()
        {
            
            List<KhachHangView> data = new List<KhachHangView>();
            foreach (var i in db.KhachHangs.Select(p => p))
            {
                string gt = "Nam";
                if (i.GioiTinh == false) gt = "Nữ";
                data.Add(new KhachHangView
                {
                    IdKhachHang = i.IdKhachHang,
                    Ten = i.Ten,
                    GioiTinh = gt,
                    CMND = i.CMND,
                    SDT = i.SDT,
                    QuocTich = i.QuocTich,                  

                });
            }
            return data;
        }

        // Lay Khach Hang (KhachHangView) theo IdKhachHang
        public List<KhachHangView> getKhachHangByMaKH(string MaKH)
        {
            List<KhachHangView> data = new List<KhachHangView>();
            foreach (var i in db.KhachHangs.Select(p => p))
            {
                if (i.IdKhachHang == MaKH)
                {
                    string gt = "Nam";
                    if (i.GioiTinh == false) gt = "Nữ";
                    data.Add(new KhachHangView
                    {
                        IdKhachHang = i.IdKhachHang,
                        Ten = i.Ten,
                        GioiTinh = gt,
                        CMND = i.CMND,
                        SDT = i.SDT,
                        QuocTich = i.QuocTich
                    });
                }
            }
            return data;
        }

        // Lay Khach Hang (KhachHangView) theo CCCD
        public List<KhachHangView> getKhachHangByCCCD(string cccd)
        {
            List<KhachHangView> data = new List<KhachHangView>();
            foreach (var i in db.KhachHangs.Select(p => p))
            {
                if (i.CMND == cccd)
                {
                    string gt = "Nam";
                    if (i.GioiTinh == false) gt = "Nữ";
                    data.Add(new KhachHangView
                    {
                        IdKhachHang = i.IdKhachHang,
                        Ten = i.Ten,
                        GioiTinh = gt,
                        CMND = i.CMND,
                        SDT = i.SDT,
                        QuocTich = i.QuocTich
                    });
                }
            }
            return data;
        }

        // tu dong tao moi mot IDKhachHang
        public string getnewIDKhachHang()
        {
            List<string> data = new List<string>();
            foreach (var i in db.KhachHangs.Select(p => p).OrderBy(p => p.IdKhachHang))
            {
                data.Add(i.IdKhachHang.Substring(1));
            }
            int idtt = Convert.ToInt32(data.Select(v => int.Parse(v)).Max()) + 1;
            return "K" + idtt.ToString();
        }

        // Them Khach Hang
        public void ThemKhachHang(string ten, string cmnd, string quoctich, string sdt)
        {
            KhachHang a = new KhachHang
            {
                IdKhachHang = getnewIDKhachHang(),
                Ten = ten,
                CMND = cmnd,
                QuocTich = quoctich,
                SDT = sdt,

            };
            db.KhachHangs.Add(a);
            db.SaveChanges();
        }

        
    }
}
