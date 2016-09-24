
function AddToCart(offerId)
{
    //var offerId = $("#offerId").val();

    AddOfferByIdToCart(offerId);
}


function AddOfferByIdToCart(offerId) {

    $.ajax({
        url: "/Cart/AsyncAddToCart",
        type: "POST",
        data: { offerId: (offerId) },
        success: function (xhr) {
            $("#AddToCartPreview").dialog({
                autoOpen: true,
                position: { my: "center", at: "top+300", of: window },
                width: 700,
                context: this,
                resizable: false,
                modal: true,
                open: function () {
                    $(this).load("/Cart/_AddToCart");
                }
            });
        }
    })
  
}