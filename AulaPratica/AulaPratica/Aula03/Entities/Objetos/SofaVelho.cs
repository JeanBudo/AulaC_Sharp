using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaPratica.Aula03.Entities
{
    public class SofaVelho : Preco
    {
        public string objectName = "Sofá velho";
        string objectMaterial = "courino e madeira";
        string objectDescription = "um sofá velho de dois lugares";
        public SofaVelho(double price, double percentageDiscount) {
            this.price = price;
            this.percentageDiscount = percentageDiscount;
        }

        public override void Description()
        {
            Console.WriteLine("Você ve uma " + objectName + " feita de " + objectMaterial + " " + objectDescription + " custando: " + GetPriceAsString());
        }
        public void Hello() { }

    }
}
