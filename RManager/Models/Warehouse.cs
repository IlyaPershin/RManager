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
    
    public partial class Warehouse
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> InspectionDate { get; set; }
        public Nullable<double> FactualNumber { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
    }
}