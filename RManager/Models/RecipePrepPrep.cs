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
    
    public partial class RecipePrepPrep
    {
        public int Id { get; set; }
        public int Volume { get; set; }
        public string Description { get; set; }
    
        public virtual Prepack Prepack { get; set; }
        public virtual Prepack Result { get; set; }
    }
}
