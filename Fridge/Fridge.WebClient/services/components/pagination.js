angular.module('app')

.factory('pagination', function () {
    var pagination = {
        bigTotalItems: 0,
        bigCurrentPage: 1,  //setup for Pagination (ui.bootstrap.pagination)
        maxSize: 10, //setup for Pagination (ui.bootstrap.pagination)
        setPage: function (pageNo) {  //setup for Pagination (ui.bootstrap.pagination)
            pagination.bigCurrentPage = pageNo;
        },
        pageChanged: function (requestFunc) {  //setup for Pagination (ui.bootstrap.pagination)
            requestFunc();
        }
    }

    return pagination
})