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
    
    public partial class Purchase
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Price { get; set; }
        public double Volume { get; set; }
    
        public virtual Company Provider { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
