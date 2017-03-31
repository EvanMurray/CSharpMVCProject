
$(document).ready(function () {
    window.onbeforeunload = function (e) {
        var dialogText = "If you leave, all game progress will be lost.";
        e.returnValue = dialogText;
        return dialogText;
    };

});
