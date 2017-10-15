$(function () {
    var chat = $.connection.chatHub;

    chat.client.addMessage = function (name, message, time) {
        $(".message-box").append('<div><b>' + name + '</b ><small>' + time + '</small><br /><p>' + message + '</p></div >');
        $(".message-box div").addClass("message");
    };

    $('.send-box textarea').first().bind("keydown", function (e) {
        
        if (e.key === "Enter") {
            e.preventDefault();   
            if (e.ctrlKey === true) {
                $(this).val($(this).val() + "\n");
                console.log(e.key + "   |" + $(this).val().trim() + "|");
            }

            if ($(this).val().trim() !== "" && e.ctrlKey === false) {
                
                $('#send button').trigger("click");
            }
        }
    });

    $.connection.hub.start().done(function () {
        $('.btn-default').click(function () {
            chat.server.send($('textarea').first().val().replace(/\n/g, "<br/>"));
            $('textarea').val('');
        });
    });
});