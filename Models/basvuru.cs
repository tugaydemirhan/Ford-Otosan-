//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace baslangic1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class basvuru
    {
        public int basvuruid { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> JobId { get; set; }
        public byte[] cv { get; set; }
        public Nullable<int> soru1 { get; set; }
        public Nullable<int> soru2 { get; set; }
        public Nullable<int> soru3 { get; set; }
        public Nullable<int> soru4 { get; set; }
        public Nullable<int> soru5 { get; set; }
        public byte[] cevap1 { get; set; }
        public string cevap2 { get; set; }
        public string cevap3 { get; set; }
        public string cevap4 { get; set; }
        public string cevap5 { get; set; }
        public Nullable<int> cd_creater { get; set; }
        public Nullable<System.DateTime> dt_created { get; set; }
        public Nullable<int> cd_modifier { get; set; }
        public Nullable<System.DateTime> dt_modified { get; set; }
        public Nullable<int> Kayit_sonlandir { get; set; }

        public virtual Sorular Sorular { get; set; }
        public virtual Sorular Sorular1 { get; set; }
        public virtual Sorular Sorular2 { get; set; }
        public virtual Sorular Sorular3 { get; set; }
        public virtual Sorular Sorular4 { get; set; }
        public virtual User User { get; set; }
        public virtual Job Job { get; set; }
    }
}