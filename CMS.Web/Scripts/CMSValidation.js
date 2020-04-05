$(document).ready(function () {

    var regExForEmail = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
    var regExForMobileNo = /^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/;
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
    $('#addNewRowButton').click(function (e) {
        e.preventDefault();
        
        var validEmail = regExForEmail.test($('#eMailId').val());
        var validMobileNo = regExForMobileNo.test($('#mobileNo').val());

        if ($('#fName').val().length < 1 && $('#lName').val().length < 1 && $('#eMailId').val().length < 1 && $('#mobileNo').val().length < 1) {
            $('#fName').css('border-color', 'red');
            $('#lName').css('border-color', 'red');
            $('#eMailId').css('border-color', 'red');
            $('#mobileNo').css('border-color', 'red');
            alert('Please fill all the fields...!');
            return false;
        }
        else {
            if ($('#fName').val().length > 1) {
                $('#fName').removeAttr('style');
            }
            else if ($('#fName').val().length < 1) {
                $('#fName').css('border-color', 'red');
            }

            if ($('#lName').val().length > 1) {
                $('#lName').removeAttr('style');
            }
            else if ($('#lName').val().length < 1) {
                $('#lName').css('border-color', 'red');
            }

            if ($('#eMailId').val().length < 1) {
                $('#eMailId').css('border-color', 'red');
            }

            if ($('#mobileNo').val().length < 1) {
                $('#mobileNo').css('border-color', 'red');
            }

            if (!validEmail && !validMobileNo && $('#eMailId').val().length > 1 && $('#mobileNo').val().length > 1) {
                alert('Please Enter Valid Input for E-Mail and Mobile No....!');
            }
            else {
                if (validEmail && $('#eMailId').val().length > 1) {
                    $('#eMailId').removeAttr('style');
                }
                else if (!validEmail && $('#eMailId').val().length > 1) {
                    alert("Please Enter Valid Email Address...!");
                }
                if (validMobileNo && $('#mobileNo').val().length > 1) {
                    $('#mobileNo').removeAttr('style');
                }
                else if (!validMobileNo && $('#mobileNo').val().length > 1) {
                    alert("Please Enter Valid Mobile No...!");
                }
            }
        }
    });

    $('#firstName').on('input', function () {
        var inputText = this.value;
        if (!(regExForText.test(inputText)))
        {
            alert('First Name Should contain only text Value...!');
            $('#fName').css('border-color', 'red');
        }
        else {
            $('#fName').removeAttr('style');
        }
    });

    $('#lastName').on('input', function () {
        var inputText = this.value;
        if (!(regExForText.test(inputText))) {
            alert('Last Name Should contain only text Value...!');
            $('#lName').css('border-color', 'red');
        }
        else {
            $('#lName').removeAttr('style');
        }
    });
});