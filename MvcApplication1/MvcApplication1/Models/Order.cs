//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public System.DateTime data { get; set; }
        public decimal sum { get; set; }
        public string Sender { get; set; }
        public int OperationId { get; set; }
        public decimal Amount { get; set; }
        public decimal WithdrawAmount { get; set; }
        public int UserId { get; set; }
    }
}
