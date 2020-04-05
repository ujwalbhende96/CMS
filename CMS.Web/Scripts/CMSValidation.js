$(document).ready(function () {

    var regExForEmail = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    var regExForMobileNo = /^[0-9]*$/;
    var regExForText = /^[a-zA-Z]+$/;

    function validateData() {
        if ($('#firstName').val().length < 1 && $('#lastName').val().length < 1 && $('#eMailAddress').val().length < 1 && $('#mobileNo').val().length < 1) {
            $('#firstName').css('border-color', 'red');
            $('#lastName').css('border-color', 'red');
            $('#eMailAddress').css('border-color', 'red');
            $('#mobileNo').css('border-color', 'red');
            alert('Please fill all the fields...!');
            return false;
        }
    }

    $('#firstName').on('input', function () {
        var inputText = this.value;
        if (!(regExForText.test(inputText))) {
            alert('First Name Should contain only text Value...!');
            $('#firstName').css('border-color', 'red');
            $('#firstName').val('');
        }
        else {
            $('#firstName').removeAttr('style');
        }
    });

    $('#lastName').on('input', function () {
        var inputText = this.value;
        if (!(regExForText.test(inputText))) {
            alert('Last Name Should contain only text Value...!');
            $('#lastName').css('border-color', 'red');
            $('#lastName').val('');
        }
        else {
            $('#lastName').removeAttr('style');
        }
    });

    $('#eMailAddress').on('change', function () {
        var inputText = this.value;
        if (!(regExForEmail.test(inputText))) {
            alert('Please Enter Valid E-Mail Address...!');
            $('#eMailAddress').css('border-color', 'red');
        }
        else {
            $('#eMailAddress').removeAttr('style');
        }
    });

    $('#mobileNo').on('input', function () {
        var inputText = this.value;
        if (!(regExForMobileNo.test(inputText))) {
            alert('Please Enter Numeric Mobile No...!');
            $('#mobileNo').css('border-color', 'red');
            $('#mobileNo').val('');
        }
        else {
            $('#mobileNo').removeAttr('style');
        }
    });

    $('#mobileNo').on('change', function () {
        var inputText = this.value;
        if ($('#mobileNo').val().length != 10) {
            alert('Please Enter Valid Mobile No...!');
            $('#mobileNo').css('border-color', 'red');
        }
        else {
            $('#mobileNo').removeAttr('style');
        }
    });
});