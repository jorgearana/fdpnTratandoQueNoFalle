$(document).ready(function () {
    $(".js-FeaturedAthletes").load("/Ranking/FeaturedAthlete/");
    $(".js-TopRankings").load("/Ranking/TopRankings/", function () {
        $('.js-slider-rankings').owlCarousel({
            items: 1,
            loop: false,
            URLhashListener: true,
            autoplayHoverPause: true,
            startPosition: 'URLHash'
        });
    });
    $(".js-WorldRecords").load("/WorldRecord/Index/", function () {
        $('.js-slider-worldrecords').owlCarousel({
            items: 1,
            loop: false,
            URLhashListener: true,
            autoplayHoverPause: true,
            startPosition: 'URLHash'
        });
    });
});