using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRpg.Models;

namespace MvcRpg.Data
{
    public class GameRepository
    {
        public GameModels GetGame()
        {
            GameModels model = new GameModels();

            model.Difficulty = 1;
            return model;
        }

    }
}