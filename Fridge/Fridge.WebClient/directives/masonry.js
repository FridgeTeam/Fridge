angular.module('app')
.directive("ngMasonry", function () {
    var NGREPEAT_SOURCE_RE = '<!-- ngRepeat: ((.*) in ((.*?)( track by (.*))?)) -->';
    return {
        controller: ['$scope', function ($scope) {
            function init() {
                var setTimeoutId;
                $(function () {
                    //when all DOM is render adjust masonry element 
                    setTimeout(function () {
                        $(".grid").masonry();
                    }, 200);

                    //on screen resize adjust masonry element
                    $(window).resize(function () {
                        clearTimeout(setTimeoutId);
                        setTimeoutId = setTimeout(function () {
                            $(".grid").masonry();
                            console.log("asd");
                        }, 1000);
                    });

                })
            }

            init();

        }],
        compile: function (element, attrs) {
            // auto add animation to brick element
            var animation = attrs.ngAnimate || "'masonry'";
            var $brick = element.children();
            $brick.attr("ng-animate", animation);

            // generate item selector (exclude leaving items)
            var type = $brick.prop('tagName');
            var itemSelector = type + ":not([class$='-leave-active'])";

            return function (scope, element, attrs) {
                var options = angular.extend({
                    itemSelector: itemSelector
                }, scope.$eval(attrs.masonry));

                // try to infer model from ngRepeat
                if (!options.model) {
                    var ngRepeatMatch = element.html().match(NGREPEAT_SOURCE_RE);
                    if (ngRepeatMatch) {
                        options.model = ngRepeatMatch[4];
                    }
                }

                // initial animation
                element.addClass('masonry');

                // Wait inside directives to render
                setTimeout(function () {
                    element.masonry(options);

                    element.on("$destroy", function () {
                        element.masonry('destroy')
                    });

                    if (options.model) {
                        scope.$apply(function () {
                            scope.$watchCollection(options.model, function (_new, _old) {
                                if (_new == _old) return;

                                // Wait inside directives to render
                                setTimeout(function () {
                                    element.masonry("reload");
                                });
                            });
                        });
                    }
                });
            };
        }
    };
})