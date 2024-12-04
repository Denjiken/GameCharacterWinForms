using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCharacterWinForms.Models
{
        public abstract class GameCharacter
        {
            public string Name { get; protected set; }
            public int Level { get; protected set; }
            public int Health { get; protected set; }
            public int Mana { get; protected set; }
            public int Strength { get; protected set; }
            public int Intelligence { get; protected set; }

            protected GameCharacter(string name, int level, int health, int mana, int strength, int intelligence)
            {
                Name = name;
                Level = level;
                Health = health;
                Mana = mana;
                Strength = strength;
                Intelligence = intelligence;
            }

            public abstract void Attack();
            public abstract void Defend();
            public abstract void LevelUp();

            public override string ToString()
            {
                return $"{Name} (Level {Level})\n" +
                       $"Health: {Health}\n" +
                       $"Mana: {Mana}\n" +
                       $"Strength: {Strength}\n" +
                       $"Intelligence: {Intelligence}";
            }
        }
}
