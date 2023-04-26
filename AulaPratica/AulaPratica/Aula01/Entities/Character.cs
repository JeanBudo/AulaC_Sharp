using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AulaPratica.Aula01.Enums;

namespace AulaPratica.Aula01.Entities
{
    public class Character
    {
        //Personagem principal
        public string charName = "Rodrigo";
        public int level;
        public int constituition;
        public int attack;
        public int charHP;
        public int speed;
        public EnumCharType charType;
        //SuperAtaque
        public int coolDown = 0;

        public Character(string charName, int level, int constituition, int attack, int speed, EnumCharType charType)
        {
            this.charName = charName;
            this.level = level;
            this.constituition = constituition;
            this.attack = attack;
            this.speed = speed;
            this.charType = charType;
            charHP = CalculateHP(this.constituition, this.level);
        }

        int CalculateHP(int constituition, int level)
        {
            return (constituition + level) * 3;
        }
        public void AttackCloserEnemy(List<Character> charList)
        {
            int _damange = attack + level;
            for (int i = 0; i < charList.Count; i++)
            {
                if (charList[i].charHP > 0 && charList[i].charType == EnumCharType.Enemy)
                {
                    charList[i].charHP -= _damange;
                    Console.WriteLine(charName + " atacou " + charList[i].charName + ":  ele recebeu " + _damange + " pontos de dano, ficando com HP= " + charList[i].charHP);
                    if (coolDown > 0) { coolDown--; }
                    return;
                }
            }


        }
        public void SuperAttack(List<Character> charList)
        {
            int _damange = attack + level;
            if (coolDown == 0)
            {
                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i].charHP > 0 && charList[i].charType == EnumCharType.Enemy)
                    {
                        charList[i].charHP -= _damange;
                        Console.WriteLine(charName + " atacou " + charList[i].charName + ":  ele recebeu " + _damange + " pontos de dano, ficando com HP= " + charList[i].charHP);

                    }
                }
                coolDown++;
            }
            else
            {
                AttackCloserEnemy(charList);
            }

        }
        public void AttackPlayer(List<Character> charList)
        {
            if (charHP > 0)
            {
                for (int i = 0; i < charList.Count; i++)
                {
                    if (charList[i].charType == EnumCharType.Player)
                    {
                        int _enemyDamange = attack + level;
                        charList[i].charHP -= _enemyDamange;
                        Console.WriteLine(charName + " atacou " + charList[i].charName + ": ele recebeu " + _enemyDamange + " pontos de dano, ficando com HP= " + charList[i].charHP);
                        Console.WriteLine();
                        return;
                    }

                }
            }


        }
        public void PassTurn()
        {
            Console.WriteLine("Passou o turno!");
            if (coolDown > 0) { coolDown--; }
        }

    }
}
