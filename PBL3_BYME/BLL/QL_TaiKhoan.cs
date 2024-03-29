﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class QL_TaiKhoan
    {
        private QLKSEntities db = new QLKSEntities();

        // Lay thong tin tat ca cac tai khoan view 
        public List<TaiKhoanView> getAllTaiKhoan()
        {
            List<TaiKhoanView> data = new List<TaiKhoanView>();
            foreach (var i in db.NhanViens.ToList())
            {
                data.Add(GetTaiKhoanView(i));
            }
            return data;
        }


        // Lay Thong tin tai khoan voi input la 1 nhan vien
        public TaiKhoanView GetTaiKhoanView(NhanVien i)
        {
            TaiKhoanView taiKhoanView = new TaiKhoanView();
            taiKhoanView.IdNhanVien = i.IdNhanVien;
            taiKhoanView.TenDangNhap = i.TaiKhoan.TenDangNhap;
            taiKhoanView.ChucVu = i.ChucVu.TenChucVu;
            return taiKhoanView;
        }


        // Check thong tin tai khoan co ton tai hay ko a xu li Add hoac update ?
        public bool Check(string tk, string pass)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            foreach(TaiKhoan t in db.TaiKhoans.ToList())
            {
                if(t.TenDangNhap == tk && t.MatKhau == pass)
                {
                    return true;
                }
            }
            return false;
        }

        // Lay IdChucVu de phan quyen theo tendangnhap
        public string GetChucVu(string tk)
        {
            string s ="";
            foreach(TaiKhoanView t in getAllTaiKhoan())
            {
                if(t.TenDangNhap == tk)
                {
                    s = t.ChucVu;
                    break;
                }
            }
            return s;
        }

        // Lay Danh Sach LichSuDangNhap
        public List<LichSuDangNhap> getAllLichSuByIdNhanVien(string IdNhanVien)
        {
            List<LichSuDangNhap> data = new List<LichSuDangNhap>();
            foreach (LichSuDangNhap i in db.LichSuDangNhaps.Where(x => x.IdNhanVien == IdNhanVien))
            {
                data.Add(i);
            }
            return data;
        }

        // Cap Nhat Trang Thai cho Tai Khoan ( true - Dang online hoac dc dang nhap , false thi nguoc lai )
        public void updateTrangThaiTK(string tenDangNhap)
        {
            foreach (var t in db.TaiKhoans.ToList())
            {
                if (t.TenDangNhap != tenDangNhap)
                {
                    t.TrangThai = false;
                }
                else
                {
                    t.TrangThai = true;
                }
            }
            db.SaveChanges();
        }

        // ADD Tai Khoan
        public void ADD(TaiKhoan tk )
        {
            db.TaiKhoans.Add(tk);
            db.SaveChanges();
        }

        // Delete Tai Khoan
        public void DELETE(TaiKhoan i)
        {
            db.TaiKhoans.Remove(i);
            db.SaveChanges();
        }

        // UPDATE Tai khoan 
        public void UPDATE(TaiKhoan tk)
        {
            try
            {
                TaiKhoan t = db.TaiKhoans.Where(p => p.IdTaiKhoan == tk.IdTaiKhoan).FirstOrDefault();
                t.TenDangNhap = tk.TenDangNhap;
                t.MatKhau = tk.MatKhau;
                t.TrangThai = tk.TrangThai;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Lay thong tin tai khoan theo IdTaiKhoan
        public TaiKhoan GetTaiKhoanById(string id)
        {
            return db.TaiKhoans.Select(p => p).Where(p => p.IdTaiKhoan == id).FirstOrDefault();
        }

        // Mã hóa mật khẩu 
        public string encryptString(string plainText)
        {
            string key = "b14ca5898a4e4133bbce2ea2315a1916";
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        // Giải mã mật khẩu 
        public string decryptString(string cipherText)
        {
            string key = "b14ca5898a4e4133bbce2ea2315a1916";
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        // Lay IdTaiKhoan voi input la 1 IdNhanVien
        public string GetIdTaiKhoan(string idnv)
        {
            string idtk = "";
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                if (i.IdNhanVien == idnv)
                {
                    idtk = i.IdTaiKhoan;
                }
            }
            return idtk;
        }
    }
}
