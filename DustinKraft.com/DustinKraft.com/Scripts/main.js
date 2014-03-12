$(document).ready(function () {
    //center the content
    centerContent('.content', '#container', '#content-wrapper');

    //Handle tab events
    $('.tab').click(function () {
        clearTabs();
        loadTab($(this));
    });

    // Handle contact form submit
    $('#container').on('submit', 'form', function (event) {
        //prevent normal form behavior
        event.preventDefault();

        var x = $.post("/home/contact/", $("form").serialize());
        x.done(function (data) {
            $('#content-wrapper').html(data);
        });
    });

    //Handle switchView logic (its a thing i made up just for this)
    $('#container').on('click', '.selector', function () {
        $('.selector').removeClass('on');
        $(this).addClass('on');

        //fade out all the views
        //$('.view').removeClass('on');
        $('#switchView>div').fadeOut('fast');

        //fade in the selected view
        var view = '#' + $(this).attr('data-view');
        //$(view).addClass('on');
        $(view).fadeIn('fast');
        centerContent(view, '#switchView', view);
    });

    //HTML5 History
    //window.addEventListener("popstate", function (e) {
    //    //this is ugly, i'll fix it
    //    var loadThis = location.pathname.split("/").reverse()[0];
    //    if (loadThis === null) { loadThis = "dustin";}
    //    loadTab($("#" + loadThis));
    //});
});

var loadTab = function (tab) {
    //remove class from current on
    $('.on').removeClass('on');
    //remove classes from container
    $('#container').removeClass('dev inst gent dustin contact');

    //change tab class
    tab.addClass("on");

    //select container
    var container = $('#container');
    container.addClass(tab.attr('id'));

    //select content
    var content = $('#content-wrapper');
    content.fadeOut('fast');
    //wait .5 seconds, ajax load data, fade text in
    setTimeout(function () {
        $.get("/home/" + tab.attr('id'), function (data) {
            content.html(data);
        }).done(function () {
            //Do stuff after load
            //center the content
            centerContent('.content', '#container', '#content-wrapper');
            //fade in new content
            content.fadeIn('slow');
        });
    }, 600);

    ////Add to history
    //if (tab.attr('id') !== 'dustin') {
    //    history.pushState(null, null, "/home/" + tab.attr('id'));
    //}
};

var clearTabs = function () {
    $('.on').removeClass('on');
    $('#container').removeClass('dev inst gent dustin contact');
};

//var centerContent2 = function () {
//    //get height of container, get height of content
//    var cH = $('#container').first().height();
//    var cC = $('#content-wrapper').first().height();

//    //set the margin-top to 1/2 of the difference in heights from the container and the content in it
//    $('.content').css({
//        'margin-top': (cH - cC) / 2
//    });

//};

var centerContent = function (selectorToPad, outsideSelector, insideSelector) {
    selectorToPad = $(selectorToPad).first();
    $(selectorToPad).css({
        'padding-top': 0
    });
    console.log("sel: " + selectorToPad + "   out: " + outsideSelector + "    IN: " + insideSelector);
    var outside = $(outsideSelector).height();
    var inside = $(insideSelector).height();

    console.log("outside: " + outside + "   inside: " + inside);
    console.log("diff: " + (outside - inside));
    if (outside - inside < 450) {
        //
        //set the margin-top to 1/2 of the difference in heights from the container and the content in it
        console.log($(selectorToPad).height());
        $(selectorToPad).css({
            'padding-top': (outside - inside) / 2
        });
        console.log("padded: " + ((outside - inside) / 2) + "    " + $(selectorToPad).height());
    }
    
};


