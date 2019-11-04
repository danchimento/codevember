// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    let $form = $("form");
    let $dopeShit = $("[name=dopeShit");

    $form.submit((e) => {
        e.preventDefault();

        $.post("/home/add", { dopeShit: $dopeShit.val() }, () => window.location.reload());

        return false;
    })
})()