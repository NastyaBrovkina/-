using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection=new List<CartLine>();

        public void AddItem(Tovar tovar, int quantity){
            CartLine line = lineCollection.Where(g => g.Tovar.idTovara ==tovar.idTovara).FirstOrDefault();
            if(line ==null){
                lineCollection.Add(new CartLine{ Tovar=tovar, Quantity = quantity});
            }
            else{
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Tovar tovar){
            lineCollection.RemoveAll(l => l.Tovar.idTovara == tovar.idTovara);
        }
        public decimal ComputeTotalValue(){

            return lineCollection.Sum(e => e.Tovar.price*e.Quantity);
        }
        public void Clear(){
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines{
            get{return lineCollection;}
        }
    }
    public class CartLine{
        public Tovar Tovar{get;set;}
        public int Quantity{get;set;}
    }
}