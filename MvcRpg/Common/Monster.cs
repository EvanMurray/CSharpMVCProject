using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Exp { get; set; }
        public Stats stats { get; set; }
        
        public string toText()
        {
            string text = $"{Name}  HP:{stats.Health} | MP:{stats.Mana} | STR:{stats.Strength} | EXP: {Exp}";
            return text;
        }
    }
}
