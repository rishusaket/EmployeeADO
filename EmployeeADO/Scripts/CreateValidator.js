$(document).ready(function () {
    $('#createFormID').validate({
        //errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'gender': {
                required: true
            },

            'location': {
                required: true,
                minlength: 6
            }
        },
        messages: {
            'gender': {
                required: 'Please provide a gender'
            },

            'location': {
                required: 'Please provide a location',
                minlength: 'Your location must be at least 6 characters long'
            }
        }
    });
});  