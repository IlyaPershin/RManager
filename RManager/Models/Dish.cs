//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            this.IsExist = true;
            this.Energy = new EnergyValue();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public Nullable<double> FinalVolume { get; set; }
        public bool IsExist { get; set; }
        public Measure Measure { get; set; }
        public string VendorCode { get; set; }
        public Nullable<System.DateTime> CookStartTime { get; set; }
        public Nullable<System.DateTime> CookEndTime { get; set; }
    
        public EnergyValue Energy { get; set; }
    
        public virtual Room CookingPlace { get; set; }
        public virtual Category Category { get; set; }
    }
}
