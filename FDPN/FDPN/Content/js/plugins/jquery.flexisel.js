!function (e) { e.fn.flexisel = function (t) { var n, i, l, a, o = e.extend({ visibleItems: 4, itemsToScroll: 3, animationSpeed: 400, infinite: !0, navigationTargetSelector: null, autoPlay: { enable: !1, interval: 5e3, pauseOnHover: !0 }, responsiveBreakpoints: { portrait: { changePoint: 480, visibleItems: 1, itemsToScroll: 1 }, landscape: { changePoint: 640, visibleItems: 2, itemsToScroll: 2 }, tablet: { changePoint: 768, visibleItems: 3, itemsToScroll: 3 } } }, t), s = e(this), r = e.extend(o, t), c = !0, f = r.visibleItems, d = r.itemsToScroll, u = [], v = { init: function () { return this.each(function () { v.appendHTML(), v.setEventHandlers(), v.initializeItems() }) }, initializeItems: function () { var t = r.responsiveBreakpoints; for (var l in t) u.push(t[l]); u.sort(function (e, t) { return e.changePoint - t.changePoint }); var a = s.children(); n = v.getCurrentItemWidth(), i = a.length, a.width(n), s.css({ left: -n * (f + 1) }), s.fadeIn(), e(window).trigger("resize") }, appendHTML: function () { if (s.addClass("nbs-flexisel-ul"), s.wrap("<div class='nbs-flexisel-container'><div class='nbs-flexisel-inner'></div></div>"), s.find("li").addClass("nbs-flexisel-item"), r.navigationTargetSelector && e(r.navigationTargetSelector).length > 0 ? e("<div class='nbs-flexisel-nav-left'><i class='material-icons'>chevron_left</i></div><div class='nbs-flexisel-nav-right'><i class='material-icons'>chevron_right</i></div>").appendTo(r.navigationTargetSelector) : (r.navigationTargetSelector = s.parent(), e("<div class='nbs-flexisel-nav-left'><i class='material-icons'>chevron_left</i></div><div class='nbs-flexisel-nav-right'><i class='material-icons'>chevron_right</i></div>").insertAfter(s)), r.infinite) { var t = s.children(), n = t.clone(), i = t.clone(); s.prepend(n), s.append(i) } }, setEventHandlers: function () { var t = s.children(); e(window).on("resize", function (i) { clearTimeout(l), l = setTimeout(function () { v.calculateDisplay(), n = v.getCurrentItemWidth(), t.width(n), r.infinite ? s.css({ left: -n * Math.floor(t.length / 2) }) : (v.clearDisabled(), e(r.navigationTargetSelector).find(".nbs-flexisel-nav-left").addClass("disabled"), s.css({ left: 0 })) }, 100) }), e(r.navigationTargetSelector).find(".nbs-flexisel-nav-left").on("click", function (e) { v.scroll(!0) }), e(r.navigationTargetSelector).find(".nbs-flexisel-nav-right").on("click", function (e) { v.scroll(!1) }), r.autoPlay.enable && (v.setAutoplayInterval(), !0 === r.autoPlay.pauseOnHover && s.on({ mouseenter: function () { c = !1 }, mouseleave: function () { c = !0 } })), s[0].addEventListener("touchstart", v.touchHandler.handleTouchStart, !1), s[0].addEventListener("touchmove", v.touchHandler.handleTouchMove, !1) }, calculateDisplay: function () { var t = e("html").width(), n = u[u.length - 1].changePoint; for (var i in u) { if (t >= n) { f = r.visibleItems, d = r.itemsToScroll; break } if (t < u[i].changePoint) { f = u[i].visibleItems, d = u[i].itemsToScroll; break } } }, scroll: function (e) { if (void 0 === e && (e = !0), 1 == c) { if (c = !1, n = v.getCurrentItemWidth(), r.autoPlay.enable && clearInterval(a), r.infinite) s.animate({ left: e ? "+=" + n * d : "-=" + n * d }, r.animationSpeed, function () { c = !0, e ? v.offsetItemsToBeginning(d) : v.offsetItemsToEnd(d), v.offsetSliderPosition(e) }); else { var t = n * d; e ? s.animate({ left: v.calculateNonInfiniteLeftScroll(t) }, r.animationSpeed, function () { c = !0 }) : s.animate({ left: v.calculateNonInfiniteRightScroll(t) }, r.animationSpeed, function () { c = !0 }) } r.autoPlay.enable && v.setAutoplayInterval() } }, touchHandler: { xDown: null, yDown: null, handleTouchStart: function (e) { this.xDown = e.touches[0].clientX, this.yDown = e.touches[0].clientY }, handleTouchMove: function (e) { if (this.xDown && this.yDown) { var t = e.touches[0].clientX, n = e.touches[0].clientY, i = this.xDown - t; this.yDown; Math.abs(i) > 0 && (i > 0 ? v.scroll(!1) : v.scroll(!0)), this.xDown = null, this.yDown = null, c = !0 } } }, getCurrentItemWidth: function () { return s.parent().width() / f }, offsetItemsToBeginning: function (e) { void 0 === e && (e = 1); for (var t = 0; t < e; t++)s.children().last().insertBefore(s.children().first()) }, offsetItemsToEnd: function (e) { void 0 === e && (e = 1); for (var t = 0; t < e; t++)s.children().first().insertAfter(s.children().last()) }, offsetSliderPosition: function (e) { var t = parseInt(s.css("left").replace("px", "")); e ? t -= n * d : t += n * d, s.css({ left: t }) }, getOffsetPosition: function () { return parseInt(s.css("left").replace("px", "")) }, calculateNonInfiniteLeftScroll: function (t) { return v.clearDisabled(), v.getOffsetPosition() + t >= 0 ? (e(r.navigationTargetSelector).find(".nbs-flexisel-nav-left").addClass("disabled"), 0) : v.getOffsetPosition() + t }, calculateNonInfiniteRightScroll: function (t) { v.clearDisabled(); var l = i * n - f * n; return v.getOffsetPosition() - t <= -l ? (e(r.navigationTargetSelector).find(".nbs-flexisel-nav-right").addClass("disabled"), -l) : v.getOffsetPosition() - t }, setAutoplayInterval: function () { a = setInterval(function () { c && v.scroll(!1) }, r.autoPlay.interval) }, clearDisabled: function () { var t = e(r.navigationTargetSelector); t.find(".nbs-flexisel-nav-left").removeClass("disabled"), t.find(".nbs-flexisel-nav-right").removeClass("disabled") } }; return v[t] ? v[t].apply(this, Array.prototype.slice.call(arguments, 1)) : "object" != typeof t && t ? void e.error('Method "' + method + '" does not exist in flexisel plugin!') : v.init.apply(this) } }(jQuery);