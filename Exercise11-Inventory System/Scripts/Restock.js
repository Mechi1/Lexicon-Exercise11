$(document).ready(function ()
{
    $(".restock-edit").on("focusout", OnFocusOut);
});

function OnFocusOut()
{
    var id = $(this).attr("data-item-id");

    if ($(this).val() != $(this).attr("data-prev-value"))
    {
        $(this).css("background-color", "White");
        $.ajax(
            {
                url: $(this).attr("data-ajax-url"),
                type: "post",
                data:
                    {
                        id: id, count: $(this).val(),
                        __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val()
                    },
                context: this,
                beforeSend: function () { $("#RestockStatus" + id).text("Saving"); },
                success: function ()
                {
                    $("#RestockStatus" + id).text("Saved");
                    $(this).attr("data-prev-value", $(this).val());
                },
                error: function ()
                {
                    $("#RestockStatus" + id).text("FAILED");
                    $(this).css("background-color", "Red");
                }
            });
    }
}
