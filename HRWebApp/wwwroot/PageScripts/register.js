jQuery.validator.addMethod("noSpace", function(value, element) {
    return value == '' || value.trim().length != 0;
}, "No space please and don't leave it empty");

$('input[name="companyNumber"]').keyup(function(e)
                                {
  if (/\D/g.test(this.value))
  {
    // Filter non-digits from input value.
    this.value = this.value.replace(/\D/g, '');
  }
});
jQuery.validator.addMethod("customEmail", function(value, element) {
  return this.optional( element ) || /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/.test( value );
}, "Please enter valid email address!");
$.validator.addMethod( "alphanumeric", function( value, element ) {
return this.optional( element ) || /^\w+$/i.test( value );
}, "Letters, numbers, and underscores only please" );
var $registrationForm = $('#registration');
if($registrationForm.length){
  $registrationForm.validate({
      rules:{

        firstName: {
            required: true,
            noSpace: true,
            minlength: 3
        },
        lastName: {
            required: true,
            noSpace: true,
            minlength: 3

        },
        companyNumber: {
            required: true,
            maxlength: 11,
            minlength:11
        },
        email: {
            required: true,
            customEmail: true
        },
        companyName: {
            required: true,
            noSpace: true,
            minlength: 3
        },
        password: {
            required: true,
            alphanumeric: true,
            minlength: 8
        },
      },
      messages:{

        firstName: {
              required: 'Please enter first name!',
              minlength: 'Please write more then 3 chars'
        },
        lastName: {
            required: 'Please enter last name!',
            minlength: 'Please write more then 3 chars'
        },

        companyNumber: {
            required: 'Please enter company number!',
            minlength: 'Please write more then 11 chars',
            maxlength: 'You cannot write more than 11 chars'
        },
        email: {
            required: 'Please enter email!',
            email: 'Please enter valid email!'
        },

        companyName: {
            required: 'Please enter company name!',
            minlength: 'Please write more then 3 chars'
        },

        password: {
            required: 'Please enter password!'
        },
      },
  });
}
