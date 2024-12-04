using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterWinForms.Models
{
    public class Warrior : GameCharacter
    {
        public int Armor { get; private set; } = 10;
        private Random random = new Random();

        public Warrior(string name, int level, int health, int strength)
            : base(name, level, health, 0, strength, 0)
        {
        }

        public override void Attack()
        {
            int baseDamage = Strength * 2;
            bool isCritical = random.Next(100) < 20;
            int finalDamage = isCritical ? baseDamage * 2 : baseDamage;

            Console.WriteLine($"{Name} attacks for {finalDamage} damage" +
                             (isCritical ? " (Critical Hit!)" : ""));
        }

        public override void Defend()
        {
            int damageReduction = Armor / 2;
            bool blocked = random.Next(100) < 15;

            if (blocked)
                Console.WriteLine($"{Name} blocks the attack completely!");
            else
                Console.WriteLine($"{Name} reduces incoming damage by {damageReduction}");
        }

        public override void LevelUp()
        {
            Level++;
            Strength += 5;
            Health += 20;
            Armor += 2;

            Console.WriteLine($"{Name} reached level {Level}! " +
                             "Strength, Health, and Armor increased!");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nArmor: {Armor}";
        }
    }

}