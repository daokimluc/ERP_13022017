//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERP.Web.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_TAI_KHOAN_HACH_TOAN
    {
        public DM_TAI_KHOAN_HACH_TOAN()
        {
            this.DM_HANG_HOA = new HashSet<DM_HANG_HOA>();
            this.DM_HANG_HOA1 = new HashSet<DM_HANG_HOA>();
            this.DM_HANG_HOA2 = new HashSet<DM_HANG_HOA>();
            this.DM_TAI_KHOAN_HACH_TOAN1 = new HashSet<DM_TAI_KHOAN_HACH_TOAN>();
        }
    
        public int SO_TK { get; set; }
        public string TEN_TK { get; set; }
        public string TINH_CHAT { get; set; }
        public string TEN_TA { get; set; }
        public Nullable<int> TK_CAP_CHA { get; set; }
        public string DIEN_GIAI { get; set; }
    
        public virtual ICollection<DM_HANG_HOA> DM_HANG_HOA { get; set; }
        public virtual ICollection<DM_HANG_HOA> DM_HANG_HOA1 { get; set; }
        public virtual ICollection<DM_HANG_HOA> DM_HANG_HOA2 { get; set; }
        public virtual ICollection<DM_TAI_KHOAN_HACH_TOAN> DM_TAI_KHOAN_HACH_TOAN1 { get; set; }
        public virtual DM_TAI_KHOAN_HACH_TOAN DM_TAI_KHOAN_HACH_TOAN2 { get; set; }
    }
}