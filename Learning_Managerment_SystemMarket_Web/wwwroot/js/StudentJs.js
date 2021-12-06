"use strict";

function openletModel(data, dis) {

    setTimeout(() => {
        data = JSON.parse(data,)
        var file = data.file


        $("#let-header").html(data.title);
        $("#let-detail").html(dis);
        var extension = file.substr((file.lastIndexOf('.') + 1));

        console.log("filw", 'https://coursearly.com/cursus/public/' + data.file)
        var url = 'https://coursearly.com/cursus/public/' + data.file;
        var video = $('#let-modal video');
        video[0].src = url;
        video[0].type = 'video/' + extension;
        console.log("filw", video[0])
        video[0].play();
        setTimeout(() => {

        }, 500);
    }, 2000);


}
$(function () {


    $('#stars li').on('mouseover', function () {
        var onStar = parseInt($(this).data('value'), 10);


        $(this).parent().children('li.star').each(function (e) {
            if (e < onStar) {
                $(this).addClass('hover');
            } else {
                $(this).removeClass('hover');
            }
        });
    }).on('mouseout', function () {
        $(this).parent().children('li.star').each(function (e) {
            $(this).removeClass('hover');
        });
    });
    $('#stars li').on('click', function () {
        var onStar = parseInt($(this).data('value'), 10);
        var stars = $(this).parent().children('li.star');
        for (let i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }
        for (let i = 0; i < onStar; i++) {
            $(stars[i]).addClass('selected');
        }
        var ratingValue = parseInt($('#stars li.selected').last().data('value'), 10);
        var msg = "";
        if (ratingValue > 1) {
            msg = "Thanks! You rated this " + ratingValue + " stars.";
        } else {
            msg = "We will improve ourselves. You rated this " + ratingValue + " stars.";
        }
        $('#rateinput').val(ratingValue);
    });


});