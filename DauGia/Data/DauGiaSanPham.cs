//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DauGia.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class DauGiaSanPham
    {
        public int MaNguoiDung { get; set; }
        public int MaSanPham { get; set; }
        public Nullable<bool> ThangCuoc { get; set; }
        public Nullable<bool> KichNguoiDung { get; set; }
        public System.DateTime NgayHienTai { get; set; }
        public Nullable<bool> GiuGiaCaoNhat { get; set; }
        public Nullable<decimal> DauGiaNguoiDung { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}