using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using MvcRpg.DAL;

namespace MvcRpg.Models
{
    public class MonsterModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Exp { get; set; }
        public Stats stats { get; set; }
        public List<Monster> Monsters { get; set; }

        public MonsterModels()
        {
            Monsters = new List<Monster>();
        }


       
        public static explicit operator MonsterModels(Monster monster)
        {
            if (monster != null)
            {
                return new MonsterModels() { Name = monster.Name, stats = monster.stats, Id = monster.Id, Exp = monster.Exp };
            }
            return null;
        }

        
        
    }
}