using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaPratica.Aula03.Entities
{
    public class CdPlayStation : Preco
    {
        public string objectName = "Desconhecido";
        string gameName = "desconhecido";
        string description = "Você ve um CD do jogo ";

       public CdPlayStation(string nameOfGame, double price, double percentageDiscount)
        {
            this.gameName = nameOfGame;
            this.price = price;
            this.percentageDiscount = percentageDiscount;
        }

        public override void Description()
        {
            Console.WriteLine(description + " " + gameName + " custando: " + GetPriceAsString());
        }
        public void Hello() { }



    }
}
