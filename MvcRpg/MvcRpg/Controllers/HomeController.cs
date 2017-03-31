using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRpg.Models;
using MvcRpg.Data;
using System.Data.Entity;
using MvcRpg.DAL;
using Common;
using System.Data.Entity.Migrations;

namespace MvcRpg.Controllers
{
    public class HomeController : Controller
    {
        protected static ViewModels _model;
        protected static PlayerRepository _playerRepo;
        protected static MonsterRepository _monsterRepo;
        protected static GameRepository _gameRepo;
        protected static RpgContext context;
        protected static MonsterModels _activeMonster = null;
        protected static PlayerModels _activePlayer = null;

        public HomeController()
        {

            if (_playerRepo == null)
            {
                _playerRepo = new PlayerRepository();
            }
            if (_monsterRepo == null)
            {
                _monsterRepo = new MonsterRepository();
            }
            if (_gameRepo == null)
            {
                _gameRepo = new GameRepository();
            }
            if (_model == null)
            {
                _model = new ViewModels();
            }
                context = new RpgContext();   
        }

        public ActionResult Index()
        { 
            return View(_model);
        }
        

        public ActionResult About()
        {     
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult MonsterManager()
        {
            _monsterRepo.PopulateMonsters();
            _model.Monster.Monsters = _monsterRepo.Monsters;
            return View(_model);
        }


        
        public PartialViewResult RenderPlayer()
        {
            if (_activePlayer == null)
            {
               _activePlayer = (PlayerModels)_playerRepo.CreatePlayer();
               _model.Player = _activePlayer;
            }
            
            return PartialView(_model);
        }

        
        public PartialViewResult RenderMonster()
        {
            if (_activeMonster == null)
            {
                _activeMonster = (MonsterModels)_monsterRepo.GetRandomMonster();
                _model.Monster = _activeMonster;
            }
            else
            {
                _model.Monster = (MonsterModels)_monsterRepo.GetMonster();
            }
            
            return PartialView(_model);
        }
      
        public PartialViewResult RenderGame()
        {
            _model.Game = _gameRepo.GetGame();
            return PartialView(_model);
        }
              
    }
}