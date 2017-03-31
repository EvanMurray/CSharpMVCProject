using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
namespace MvcRpg.Models
{
    public class ViewModels
    {
        public PlayerModels Player { get; set; }
        public MonsterModels Monster { get; set; }
        public GameModels Game { get; set; }

        public ViewModels()
        {
            this.Player = new PlayerModels();
            this.Monster = new MonsterModels();
            this.Game = new GameModels();
        }
    }
}