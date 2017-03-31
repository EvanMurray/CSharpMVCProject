using Common;
using MvcRpg.DAL;
using MvcRpg.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace MvcRpg.Controllers
{
    public class MonsterController : HomeController
    {
        public ActionResult AddMonster(string monsterName, int monsterStrength, int monsterHealth, int monsterMana, int monsterExp)
        {
            Monster monster = new Monster();
            monster.Name = monsterName;
            monster.stats = new Stats(monsterHealth, monsterMana, monsterStrength);
            monster.Exp = monsterExp;
            try
            {
                using (context = new RpgContext())
                {
                    context.Monsters.AddOrUpdate(monster);
                    context.SaveChanges();
                }

            }
            catch (Exception e)
            {
                var message = e.InnerException;

            }

            return RedirectToAction("MonsterManager");
        }


        public ActionResult DeleteMonster(int id)
        {
            using (context = new RpgContext())
            {
                var monster = context.Monsters.Find(id);
                if (context.Monsters.Count() > 1)
                {
                    context.Monsters.Remove(monster);
                    context.SaveChanges();
                }

            }
            return RedirectToAction("MonsterManager");
        }


        public ActionResult EditMonster(int id)
        {
            Monster monster = context.Monsters.Find(id);
            if (monster == null)
            {
                return HttpNotFound();
            }
            _model.Monster = (MonsterModels)monster;
            return View(_model.Monster);
        }

        [HttpPost]
        public ActionResult EditMonster(Monster monster)
        {
            if (ModelState.IsValid)
            {
                using (context = new RpgContext())
                {
                    context.Entry(monster).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("MonsterManager");
            }
            _model.Monster = (MonsterModels)monster;
            return View(_model.Monster);
        }

    }
}