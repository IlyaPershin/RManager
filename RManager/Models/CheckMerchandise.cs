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
    
    public partial class CheckMerchandise
    {
        public int Id { get; set; }
        public string IsPaid { get; set; }
        public string AddDateTime { get; set; }
        public string PaidDateTime { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}