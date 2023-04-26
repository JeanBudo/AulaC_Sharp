using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaPratica.Aula03.Entities
{
    public class TelevisaoLed : Preco
    {
        public string objectName = "Televisão";
        string material = "Plástico e vidro";
        string description = "que possui 40 polegadas";

        public TelevisaoLed(double price, double percentageDiscount)
        {
            this.price = price;
            this.percentageDiscount = percentageDiscount;
        }

        public override void Description()
        {
            Console.WriteLine("Você ve uma " + objectName + " feita de " + material + " " + description + " custando: " + GetPriceAsString());
        }

        public void Hello(){ }

    }
}
