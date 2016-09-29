
function AddToCart(offerId) {
    var addToCartPreview = $("#AddToCartPreview");

    AddOfferByIdToCart(offerId);

}

function AddOfferByIdToCart(offerId) {
    var addToCartPreview = $("#AddToCartPreview");
    addToCartPreview.dialog({
        bgiframe: true,
        position: { my: "center", at: "top+300", of: window },
        autoOpen: false,
        height: 400,
        width: 800,
        modal: true,
        open: function () {
            $(this).load("/Cart/_AddToCart");
        },
        buttons: {
            'Cuntinua cumparaturile': function () {
                $(this).dialog("close");
            },
            'Vezi cos': function () {
                $(this).dialog("close");
            }
        }
    });

    $(document).ready(function () {
        $.ajax({
            url: "/Cart/AsyncAddToCart",
            type: "POST",
            data: { offerId: (offerId) },
            success: function (xhr) {
                addToCartPreview.dialog('open');
            }
        });


    });
}
