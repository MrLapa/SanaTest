//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SanaTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sana_ProductCategorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sana_ProductCategorie()
        {
            this.Sana_CategorieAndProduct = new HashSet<Sana_CategorieAndProduct>();
        }
    
        public long idProductCategorie { get; set; }
        public string name { get; set; }
        public System.DateTime creationDate { get; set; }
        public Nullable<System.DateTime> modificationDate { get; set; }
        public Nullable<bool> enable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sana_CategorieAndProduct> Sana_CategorieAndProduct { get; set; }
    }
}
