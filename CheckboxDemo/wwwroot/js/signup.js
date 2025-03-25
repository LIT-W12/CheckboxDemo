$(() => {
    $("input").on('input', function () {
        ensureFormValidity();
    })

    $("#color-select").on('change', function () {
        ensureFormValidity();
    });

    $("#age").on('input', function () {
        const age = Number($("#age").val());
        if (age > 50) {
            $("#signup").prop('checked', true);
            $("#signup").prop('disabled', true);
            $("form").append("<input type='hidden' name='signuptonewsletter' value='true' id='chk-hidden' />");
        }
        else {
            $("#signup").prop('disabled', false);
            $("#chk-hidden").remove();
        }
    });

    function ensureFormValidity() {
        const name = $("#name").val().trim();
        const age = $("#age").val().trim();

        const isNameValid = Boolean(name);
        const ageNumber = Number(age);
        const isAgeValid = Boolean(age) && !isNaN(ageNumber) && ageNumber > 20;

        const colorVal = Number($("#color-select").val());


        const isFormValid = isNameValid && isAgeValid && colorVal !== -1;
        $(".btn-primary").prop('disabled', !isFormValid);
    }
})