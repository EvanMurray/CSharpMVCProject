using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRpg.Models;
using Common;
using MvcRpg.DAL;

namespace MvcRpg.Data
{
    public class MonsterRepository
    {
        public List<Monster> Monsters;
        
        public Monster monster { get; set; }

        public MonsterRepository()
        {
            if ((new object[] { monster, Monsters }).Any(v => v == null))
            {
                monster = new Monster();
                Monsters = new List<Monster>();
            }
        }

        public void PopulateMonsters()
        {
            RpgContext c = new RpgContext();
            Monsters = new List<Monster>();
            foreach (var mon in c.Monsters)
            {
                
                
                    Monsters.Add(mon);
                
            }
        }

        public Monster GetMonster()
        {
           
           
            return monster;

        }

        public Monster GetRandomMonster()
        {
            RpgContext c = new RpgContext();
            var RandomMonster = c.Monsters.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
            monster = RandomMonster;
            return monster;
            
        }

    }
}
