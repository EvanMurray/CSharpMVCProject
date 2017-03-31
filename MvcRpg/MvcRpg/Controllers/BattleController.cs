using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRpg.DAL;
using Common;
using MvcRpg.Data;
using MvcRpg.Models;

namespace MvcRpg.Controllers
{
    public class BattleController : HomeController
    {
        MonsterModels Monster;
        PlayerModels Player;

        public BattleController()
        {
            if (Monster == null)
            {
                Monster = _model.Monster;
            }
            if (Player == null)
            {
                Player = _model.Player;
            }
        }

        string message = "";
        bool isDefeated = false;

        public JsonResult Attack()
        {

            PlayerAttack();
            isMonsterDefeated();
            MonsterAttack();
            isPlayerDefeated();

            var result = Json( new { Message = message, Monster = Monster, Player = Player, Defeated  = isDefeated } );
            return result;
        }

        
        public ActionResult Run()
        {
            string message = "You ran!";
            ResetMonster();
            ResetPlayer();

            return Json(new { Message = message, Player = Player, Monster = Monster });
        } 

        
        public void MonsterAttack()
        {
            message += $"<br>The {Monster.Name} attacked you for {Monster.stats.Strength} damage!";
            Player.MyStats.Health -= Monster.stats.Strength;
        }

        public void PlayerAttack()
        {
            message += $"You attacked the {Monster.Name} for {Player.MyStats.Strength} damage!";
            Monster.stats.Health -= Player.MyStats.Strength;
        }

        public void isMonsterDefeated()
        {
            if (Monster.stats.Health <= 0)
            {
                message += $"<br>You have defeated the {Monster.Name}";
               
                Player.Exp += Monster.Exp;
                ResetMonster();
                bool lCheck = LevelUpCheck();
                if (lCheck)
                {
                    message += $"<br><strong>You have leveled up to level {Player.Level}!<strong>";

                }
            }
        }


        public void isPlayerDefeated()
        {
            if (Player.MyStats.Health <= 0)
            {
                ResetPlayer();
                ResetMonster();
                isDefeated = true;
            }
        }


        public void ResetMonster()
        {
            _activeMonster = null;
            RenderMonster();
            Monster = _model.Monster;
        }

        public void ResetPlayer()
        {
            _activePlayer = null;
            RenderPlayer();
            Player = _model.Player;
        }

        public bool LevelUpCheck()
        {
            bool c = false;
            if(Player.Exp >= 100)
            {
                Player.LevelUp();
                c = true;
            }
            return c;
        }
    }
}