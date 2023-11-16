namespace DUONGNGOCHAI_2121110109
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        [Key]
        [StringLength(4)]
        public string MASP { get; set; }

        [StringLength(4)]
        public string MALOAI { get; set; }

        [StringLength(200)]
        public string TENSP { get; set; }

        [StringLength(20)]
        public string TACGIA { get; set; }

        public int? NAMXB { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }

        public virtual LOAISP LOAISP { get; set; }
    }
}
