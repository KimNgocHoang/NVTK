//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyChungCu
{
    using System;
    using System.Collections.Generic;
    
    public partial class hogiadinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hogiadinh()
        {
            this.canhoes = new HashSet<canho>();
            this.hopdongs = new HashSet<hopdong>();
        }
    
        public int maho { get; set; }
        public string tenchuho { get; set; }
        public Nullable<int> sothanhvien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<canho> canhoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hopdong> hopdongs { get; set; }
    }
}
