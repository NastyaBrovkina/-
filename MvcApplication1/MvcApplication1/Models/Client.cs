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
    
    public partial class Client
    {
        public Client()
        {
            this.ListSales = new HashSet<ListSale>();
        }
    
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Otchestvo { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string E_mail { get; set; }
        public Nullable<int> Telefone { get; set; }
    
        public virtual ICollection<ListSale> ListSales { get; set; }
    }
}
