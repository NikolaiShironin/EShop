//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShop.Classes
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersGoods
    {
        public int id { get; set; }
        public Nullable<int> OrdersID { get; set; }
        public Nullable<int> GoodsID { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual Orders Orders { get; set; }
    }
}
