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
    
    public partial class Order
    {
        public int Id { get; set; }
        public double FinalPrice { get; set; }
        public System.DateTime DateOfOrder { get; set; }
        public bool IsOpen { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Table Table { get; set; }
        public virtual Client Client { get; set; }
    }
}
