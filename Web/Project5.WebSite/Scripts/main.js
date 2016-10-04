﻿function addSearchTerm(searchTerm) {
    document.getElementById("mainSearchTxt").value = searchTerm;
    $("#SearchPreviewInnerDiv").fadeOut("slow");
}

//function addSearchCountiesTerm(searchTerm) {
//    document.getElementById("mainSearchCounties").value = searchTerm;
//    $("#SearchCountiesPreviewInnerDiv").fadeOut("slow");
//}



$(document).ready(function () {


    $('#mainSearchTxt').keyup(function (e) {
        var mainSearchElem = $('#mainSearchTxt');
        mainSearch(mainSearchElem);
    });

    //$('#mainSearchCounties').keyup(function (e) {
    //    var mainSearchCountiesElem = $('#mainSearchCounties');
    //    mainSearchCounties(mainSearchCountiesElem);
    //});


});


function mainSearch(mainSearchElem) {
    var previewDiv = $('#MainSearchPreview');

    $.ajax({
        url: "/Resource/AsyncFindSearch",
        type: "POST",
        data: { textSearch: (mainSearchElem.val()) }
    })
         .done(function (partialViewResult) {
             previewDiv.html(partialViewResult);
         });
}


//function mainSearchCounties(mainSearchCountiesElem) {
//    var mainSearchCountiesPreview = $('#MainSearchCountiesPreview');

//    $.ajax({
//        url: "/Resource/AsyncFindCountiesSearch",
//        type: "POST",
//        data: { textSearch: (mainSearchCountiesElem.val()) }
//    })
//         .done(function (partialViewResult) {
//             mainSearchCountiesPreview.html(partialViewResult);
//         });
//}