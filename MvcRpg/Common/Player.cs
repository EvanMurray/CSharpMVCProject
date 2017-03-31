using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Player
    {
        public int Id;
        public string Name { get; set; }
        public Profession Prof { get; set; }
        public int Exp { get; set; }
        public int Level { get; set; }
        public Stats MyStats { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public bool HasWeaponEquipped { get; set; }
        public int RunAwayCount { get; set; }

        public void LevelUp()
        {
            while (Exp >= 100)
            {
                Level++;
                MyStats.Health += 10;
                Exp -= 100;

            }
        }
    }


}
