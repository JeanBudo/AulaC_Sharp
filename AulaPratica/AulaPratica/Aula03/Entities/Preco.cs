using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaPratica.Aula03.Entities
{
    public abstract class Preco
    {
        public double price;
        public double percentageDiscount;


        public string GetPriceAsString()
        {
            double _price = price - (price * percentageDiscount) / 100;
            return _price.ToString() + "R$";
        }
        public virtual void Description()
        {
            throw new Exception();
        }
    }
}
