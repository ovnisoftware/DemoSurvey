$(document).ready(function () {
    $('#buttonQ1').click(function () {
        $('#question1').slideUp(500);
        $('#question2').slideDown(500);
        $('#buttonQ2').hide();
    });

    $('#buttonQ2').click(function () {
        $('#question2').slideUp(500);
        $('#question3').slideDown(500);
        $('#buttonQ3').hide();
    });

    $('#buttonQ3').click(function () {
        $('#question3').slideUp(500);
        $('#endOfSurvey').show();
    });

    $('#ButtonStart').click(function () {
        $('#survey').show();
        $('#ButtonStart').hide();
        $('#startup').dialog('close');
    });

    $("input[type=radio]").change(function () {
        $('#buttonQ1').show();
        $('#buttonQ2').show();
        $('#buttonQ3').show();
    });
    $('#survey').draggable();
});

window.onload = function () {
    $('#startup').dialog({
        title: 'Demo Microsoft Survey',
        width: 300,
        height: 200,
        resizable: false,
        buttons: {
            Close:
                function () {
                    $(this).dialog('close');
                }
        }
    });
}