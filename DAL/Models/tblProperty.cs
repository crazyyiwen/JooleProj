//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProperty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProperty()
        {
            this.tblPropertyValues = new HashSet<tblPropertyValue>();
            this.tblTechSpecFilters = new HashSet<tblTechSpecFilter>();
            this.tblTypeFilters = new HashSet<tblTypeFilter>();
        }
    
        public int Property_ID { get; set; }
        public string Property_Name { get; set; }
        public Nullable<bool> IsType { get; set; }
        public Nullable<bool> IsTechSpec { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPropertyValue> tblPropertyValues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTechSpecFilter> tblTechSpecFilters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTypeFilter> tblTypeFilters { get; set; }
    }
}
