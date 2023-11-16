namespace DUONGNGOCHAI_2121110109
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(4)]
        public string MAKH { get; set; }

        [StringLength(40)]
        public string HOTEN { get; set; }

        [StringLength(50)]
        public string DCHI { get; set; }

        [StringLength(20)]
        public string SODT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGDK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGSINH { get; set; }

        [Column(TypeName = "money")]
        public decimal? DOANHSO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
