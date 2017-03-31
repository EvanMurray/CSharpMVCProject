"use strict";

function executePost(uri) {
    $.post(uri, function (data) {
        
            $("#GameText ul").append("<li>" + data.Message + "</li>");
            RenderMonster(data);
            RenderPlayer(data);
            if (data.Defeated) {
                alert("You have been defeated!");
                
                $("#GameText ul").empty();
            }
    });

    if ($("#GameText ul").children().length > 6) {
        $("#GameText ul li").first().remove();
    }

    
}


function RenderPlayer(data) {
    $("#RenderPlayer #pLevel").html("Level: " + data.Player.Level);
    $("#RenderPlayer #pHealth").html("Health: " + data.Player.MyStats.Health);
}
function RenderMonster(data) {
    $("#RenderMonster #mName").html(data.Monster.Name);
    $("#RenderMonster #mHealth").html("Health: " + data.Monster.stats.Health);
    $("#RenderMonster #mMana").html("Mana: " + data.Monster.stats.Mana);
    $("#RenderMonster #mStrength").html("Strength: " + data.Monster.stats.Strength);
}

$(document).on("ready", function ()
{
  
    $(document).on("click", "#AttackButton", function () {
      
        executePost("/Battle/Attack");
    });

    $(document).on("click", "#RunButton", function () {
        
        executePost("/Battle/Run");
        
    });

});

