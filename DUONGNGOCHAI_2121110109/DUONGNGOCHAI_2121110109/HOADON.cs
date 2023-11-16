namespace DUONGNGOCHAI_2121110109
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOHD { get; set; }

        [Column(TypeName = "date")]
        public string NGHD { get; set; }

        [StringLength(4)]
        public string MAKH { get; set; }

        [StringLength(4)]
        public string MANV { get; set; }

        [Column(TypeName = "money")]
        public decimal? TRIGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
