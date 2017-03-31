using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace MvcRpg.Models
{
    public class PlayerModels
    {
        public int Id;
        public string Name { get; set; }
        public Profession Prof { get; set; }
        public int? Exp { get; set; }
        public int? Level { get; set; } 
        public Stats MyStats { get; set; }
        public List<Item> Inventory { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public bool HasWeaponEquipped { get; set; }
        public int RunAwayCount { get; set; }

        public PlayerModels()
        {
           
        }

        public void LevelUp()
        {
            while (Exp >= 100)
            {
                Level++;
                MyStats.Health += 10;
                Exp -= 100;

            }
        }

        public void AddItem(string s)
        {
            Item item = new Item();
            item.Name = s;
            Inventory.Add(item);
        }
        public static explicit operator PlayerModels(Player player)
        {
            return new PlayerModels() { Name = player.Name, MyStats = player.MyStats, Exp = player.Exp, Level = player.Level };
        }

        /*public static int Clamp( int value, int min, int max )
          {
            return (value < min) ? min : (value > max) ? max : value;
          }*/
    }  
}
 