using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRpg.Models;
using Common;

namespace MvcRpg.Data
{
    public class PlayerRepository
    {
        Player player { get; set; }


        public PlayerRepository()
        {
            
            
        }

        public Player CreatePlayer()
        {
            player = new Player();
            player.Name = "Player";
            player.MyStats = new Stats(25, 10, 5);
            player.Exp = 0;
            player.Level = 1;
            return player;
        }
        public Player GetPlayer()
        {
            
            return player;
        }

    }
}