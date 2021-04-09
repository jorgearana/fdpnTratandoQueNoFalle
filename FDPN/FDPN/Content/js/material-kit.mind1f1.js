var big_image;

function debounce(a, r, i) {
    var n;
    return function () {
        var e = this,
            t = arguments;
        clearTimeout(n), n = setTimeout(function () {
            n = null, i || a.apply(e, t)
        }, r), i && !n && a.apply(e, t)
    }
}
materialKit = {
    misc: {
        navbar_menu_visible: 0,
        window_width: 0,
        transparent: !0,
        colored_shadows: !0,
        fixedTop: !1,
        navbar_initialized: !1,
        isWindow: document.documentMode || /Edge/.test(navigator.userAgent)
    },
    checkScrollForParallax: function () {
        oVal = $(window).scrollTop() / 3, big_image.css({
            transform: "translate3d(0," + oVal + "px,0)",
            "-webkit-transform": "translate3d(0," + oVal + "px,0)",
            "-ms-transform": "translate3d(0," + oVal + "px,0)",
            "-o-transform": "translate3d(0," + oVal + "px,0)"
        })
    },
    initFormExtendedDatetimepickers: function () {
        $(".datetimepicker").datetimepicker({
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: "fa fa-chevron-left",
                next: "fa fa-chevron-right",
                today: "fa fa-screenshot",
                clear: "fa fa-trash",
                close: "fa fa-remove"
            }
        }), $(".datepicker").datetimepicker({
            format: "MM/DD/YYYY",
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: "fa fa-chevron-left",
                next: "fa fa-chevron-right",
                today: "fa fa-screenshot",
                clear: "fa fa-trash",
                close: "fa fa-remove"
            }
        }), $(".timepicker").datetimepicker({
            format: "h:mm A",
            icons: {
                time: "fa fa-clock-o",
                date: "fa fa-calendar",
                up: "fa fa-chevron-up",
                down: "fa fa-chevron-down",
                previous: "fa fa-chevron-left",
                next: "fa fa-chevron-right",
                today: "fa fa-screenshot",
                clear: "fa fa-trash",
                close: "fa fa-remove"
            }
        })
    },
    initSliders: function () {
        var e = document.getElementById("sliderRegular");
        noUiSlider.create(e, {
            start: 40,
            connect: [!0, !1],
            range: {
                min: 0,
                max: 100
            }
        });
        var t = document.getElementById("sliderDouble");
        noUiSlider.create(t, {
            start: [20, 60],
            connect: !0,
            range: {
                min: 0,
                max: 100
            }
        })
    },
    initColoredShadows: function () {
        1 == materialKit.misc.colored_shadows && ("Explorer" == BrowserDetect.browser && BrowserDetect.version <= 12 || $('.card:not([data-colored-shadow="false"]) .card-header-image').each(function () {
            if ($card_img = $(this), is_on_dark_screen = $(this).closest(".section-dark, .section-image").length, 0 == is_on_dark_screen) {
                var e = $card_img.find("img").attr("src"),
                    t = 1 == $card_img.closest(".card-rotate").length,
                    a = $card_img,
                    r = $('<div class="colored-shadow"/>');
                if (t) {
                    var i = $card_img.height(),
                        n = $card_img.width();
                    $(this).find(".back").css({
                        height: i + "px",
                        width: n + "px"
                    }), a = $card_img.find(".front")
                }
                r.css({
                    "background-image": "url(" + e + ")"
                }).appendTo(a), 700 < $card_img.width() && r.addClass("colored-shadow-big"), setTimeout(function () {
                    r.css("opacity", 1)
                }, 200)
            }
        }))
    },
    initRotateCard: debounce(function () {
        $(".rotating-card-container .card-rotate").each(function () {
            var e = $(this),
                t = $(this).parent().width();
            $(this).find(".front .card-body").outerHeight();
            e.parent().css({
                "margin-bottom": "30px"
            }), e.find(".front").css({
                width: t + "px"
            }), e.find(".back").css({
                width: t + "px"
            })
        })
    }, 50),
    checkScrollForTransparentNavbar: debounce(function () {
        $(document).scrollTop() > scroll_distance ? materialKit.misc.transparent && (materialKit.misc.transparent = !1, $(".navbar-color-on-scroll").removeClass("navbar-transparent")) : materialKit.misc.transparent || (materialKit.misc.transparent = !0, $(".navbar-color-on-scroll").addClass("navbar-transparent"))
    }, 17)
}, $(document).ready(function () {
    BrowserDetect.init(), $("body").bootstrapMaterialDesign(), window_width = $(window).width(), $navbar = $(".navbar[color-on-scroll]"), scroll_distance = $navbar.attr("color-on-scroll") || 500, $navbar_collapse = $(".navbar").find(".navbar-collapse"), $(".dropdown-menu a.dropdown-toggle").on("click", function (e) {
        var t = $(this),
            a = $(this).offsetParent(".dropdown-menu");
        return $(this).next().hasClass("show") || $(this).parents(".dropdown-menu").first().find(".show").removeClass("show"), $(this).next(".dropdown-menu").toggleClass("show"), $(this).closest("a").toggleClass("open"), $(this).parents("a.dropdown-item.dropdown.show").on("hidden.bs.dropdown", function (e) {
            $(".dropdown-menu .show").removeClass("show")
        }), a.parent().hasClass("navbar-nav") || t.next().css({
            top: t[0].offsetTop,
            left: a.outerWidth() - 4
        }), !1
    }), $('[data-toggle="tooltip"], [rel="tooltip"]').tooltip(), $(".form-file-simple .inputFileVisible").click(function () {
        $(this).siblings(".inputFileHidden").trigger("click")
    }), $(".form-file-simple .inputFileHidden").change(function () {
        var e = $(this).val().replace(/C:\\fakepath\\/i, "");
        $(this).siblings(".inputFileVisible").val(e)
    }), $(".form-file-multiple .inputFileVisible, .form-file-multiple .input-group-btn").click(function () {
        $(this).parent().parent().find(".inputFileHidden").trigger("click"), $(this).parent().parent().addClass("is-focused")
    }), $(".form-file-multiple .inputFileHidden").change(function () {
        for (var e = "", t = 0; t < $(this).get(0).files.length; ++t) t < $(this).get(0).files.length - 1 ? e += $(this).get(0).files.item(t).name + "," : e += $(this).get(0).files.item(t).name;
        $(this).siblings(".input-group").find(".inputFileVisible").val(e)
    }), $(".form-file-multiple .btn").on("focus", function () {
        $(this).parent().siblings().trigger("focus")
    }), $(".form-file-multiple .btn").on("focusout", function () {
        $(this).parent().siblings().trigger("focusout")
    }), 0 != $(".selectpicker").length && $(".selectpicker").selectpicker(), $('[data-toggle="popover"]').popover(), $(".carousel").carousel();
    var e = $(".tagsinput").data("color");
    0 != $(".tagsinput").length && $(".tagsinput").tagsinput(), $(".bootstrap-tagsinput").addClass(e + "-badge"), 0 != $(".navbar-color-on-scroll").length && $(window).on("scroll", materialKit.checkScrollForTransparentNavbar), materialKit.checkScrollForTransparentNavbar(), 768 <= window_width && 0 != (big_image = $('.page-header[data-parallax="true"]')).length && $(window).on("scroll", materialKit.checkScrollForParallax), materialKit.initRotateCard(), materialKit.initColoredShadows()
}), $(window).on("resize", function () {
    materialKit.initRotateCard()
}), $(document).on("click", ".card-rotate .btn-rotate", function () {
    var e = $(this).closest(".rotating-card-container");
    e.hasClass("hover") ? e.removeClass("hover") : e.addClass("hover")
}), $(document).on("click", ".navbar-toggler", function () {
    $toggle = $(this), 1 == materialKit.misc.navbar_menu_visible ? ($("html").removeClass("nav-open"), materialKit.misc.navbar_menu_visible = 0, $("#bodyClick").remove(), setTimeout(function () {
        $toggle.removeClass("toggled")
    }, 550), $("html").removeClass("nav-open-absolute")) : (setTimeout(function () {
        $toggle.addClass("toggled")
    }, 580), div = '<div id="bodyClick"></div>', $(div).appendTo("body").click(function () {
        $("html").removeClass("nav-open"), $("nav").hasClass("navbar-absolute") && $("html").removeClass("nav-open-absolute"), materialKit.misc.navbar_menu_visible = 0, $("#bodyClick").remove(), setTimeout(function () {
            $toggle.removeClass("toggled")
        }, 550)
    }), $("nav").hasClass("navbar-absolute") && $("html").addClass("nav-open-absolute"), $("html").addClass("nav-open"), materialKit.misc.navbar_menu_visible = 1)
});
var BrowserDetect = {
    init: function () {
        this.browser = this.searchString(this.dataBrowser) || "Other", this.version = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown"
    },
    searchString: function (e) {
        for (var t = 0; t < e.length; t++) {
            var a = e[t].string;
            if (this.versionSearchString = e[t].subString, -1 !== a.indexOf(e[t].subString)) return e[t].identity
        }
    },
    searchVersion: function (e) {
        var t = e.indexOf(this.versionSearchString);
        if (-1 !== t) {
            var a = e.indexOf("rv:");
            return "Trident" === this.versionSearchString && -1 !== a ? parseFloat(e.substring(a + 3)) : parseFloat(e.substring(t + this.versionSearchString.length + 1))
        }
    },
    dataBrowser: [{
        string: navigator.userAgent,
        subString: "Chrome",
        identity: "Chrome"
    }, {
        string: navigator.userAgent,
        subString: "MSIE",
        identity: "Explorer"
    }, {
        string: navigator.userAgent,
        subString: "Trident",
        identity: "Explorer"
    }, {
        string: navigator.userAgent,
        subString: "Firefox",
        identity: "Firefox"
    }, {
        string: navigator.userAgent,
        subString: "Safari",
        identity: "Safari"
    }, {
        string: navigator.userAgent,
        subString: "Opera",
        identity: "Opera"
    }]
},
    better_browser = '<div class="container"><div class="better-browser row"><div class="col-md-2"></div><div class="col-md-8"><h3>We are sorry but it looks like your Browser doesn\'t support our website Features. In order to get the full experience please download a new version of your favourite browser.</h3></div><div class="col-md-2"></div><br><div class="col-md-4"><a href="https://www.mozilla.org/ro/firefox/new/" class="btn btn-warning">Mozilla</a><br></div><div class="col-md-4"><a href="https://www.google.com/chrome/browser/desktop/index.html" class="btn ">Chrome</a><br></div><div class="col-md-4"><a href="http://windows.microsoft.com/en-us/internet-explorer/ie-11-worldwide-languages" class="btn">Internet Explorer</a><br></div><br><br><h4>Thank you!</h4></div></div>';
//# sourceMappingURL=_site_kit_pro/assets/js/kit-pro.js.map