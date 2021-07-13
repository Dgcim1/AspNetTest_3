// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    //мышь вошла на кнопку
    $("#button-popup").mouseenter(function () {
        $('#popup-registration').removeClass('invise');
    });
    //мышь покинула кнопку
    $("#button-popup").mouseleave(function () {
        $('#popup-registration').addClass('invise');
    });
    //мышь попала на красное
    $("#popup-registration").mouseenter(function () {
        $('#popup-registration').removeClass('invise');
    });
    //мышь покинула красное
    $("#popup-registration").mouseleave(function () {
        $('#popup-registration').addClass('invise');
    });
    //нажатие кнопки подробнее
    $(".button-show-more").click(function () {
        var id = $(this).attr("id").substr(17);
        $('#product-main-'+id).toggleClass('invise');
        $('#product-info-'+id).toggleClass('invise');
    });
    $(".button-unshow-more").click(function () {
        var id = $(this).attr("id").substr(19);
        $('#product-main-' + id).toggleClass('invise');
        $('#product-info-' + id).toggleClass('invise');
    });
});