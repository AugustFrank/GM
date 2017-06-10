// Wait for the DOM to be ready
$(function () {
    $('#register-form').validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 6,
                maxlength: 100
            },
            password_again: {
                required: true,
                equalTo: "#password"
            }
        },
        messages: {
            email: {
                required: 'Please write your email!',
                email: 'This is not a valid email!'
            },
            password: {
                minlength: 'The password must at least be 6 characters long',
                maxlength: 'The password cannot be more than 100 characters long',
                required: 'I am a required field...'
            },
            password_again: {
                minlength: 'The password must at least be 6 characters long',
                maxlength: 'The password cannot be more than 100 characters long',
                required: 'I am a required field...'
            }

        }
    });
});

$(function () {
    $('#login-form').validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 6,
                maxlength: 100
            }
        },

        messages: {
            email: {
                required: 'Please write your email!',
                email: 'This is not a valid email!'
            },
            password: {
                minlength: 'The password must at least be 6 characters long',
                maxlength: 'The password cannot be more than 100 characters long',
                required: 'Please write the password that is associated with your email...'
            }
        }
    });
});

$(function () {
    $('#carscreate-form').validate({
        rules: {
            regno: {
                required: true,
                minlength: 5,
                maxlength: 25
            },
            year: {
                required: true,
                minlength: 4,
                maxlength: 4
            },
            fuel: {
                required: true,
            },
            fuelconsumption: {
                required: true,
            },
            transmission: {
                required: true,
            },

            password: {
                required: true,

            }
        },

        messages: {
            regno: {
                minlength: 'The Reg No must at least be 5 characters long',
                maxlength: 'The Reg No must max be 25 characters long',
                required: 'I am a required field...'
            },
            year: {
                minlength: 'The Year No must be 4 numbers long',
                maxlength: 'The Reg No must max be 25 characters long',
                required: 'I am a required field...'
            },
            fuel: {
                required: 'Please state whether the fuel is Diesel or Petrol'
            },
            fuelconsumption: {
                required: 'Please state how much fuel the vehicle consumes'
            },
            transmission: {
                required: 'Please state whether the transmission is Manual or Automatic'
            }

        }
    });
});


$(function () {
    $('#ordercreate-form').validate({
        rules: {
            carid: {
                required: true
            },
            orderdate: {
                required: true,
                minlength: 6,
                maxlength: 8
            },
            dateout: {
                required: true,
                minlength: 6,
                maxlength: 8
            },
            datein: {
                required: true,
                minlength: 6,
                maxlength: 8
            },
            orderstatus: {
                required: true,
            },
            description: {
                required: true,
            }

        },

        messages: {
            carid: {
                required: 'I am a required field...'
            },
            orderdate: {
                minlength: 'The date order must be at least 6 numbers long',
                maxlength: 'The date order must maximum be 10 numbers long',
                required: 'I am a required field...'
            },
            dateout: {
                minlength: 'The date out must be at least 6 numbers long',
                maxlength: 'The date out must maximum be 10 numbers long',
                required: 'I am a required field...'
            },
            datein: {
                minlength: 'The date in must be at least 6 numbers long',
                maxlength: 'The date in must maximum be 10 numbers long',
                required: 'I am a required field...'
            },
            orderstatus: {
                required: 'Please state the status of the order'
            },
            description: {
                required: 'Please describe the order'
            }

        }
    });
});

$(function () {
    $('#cartypescreate-form').validate({
        rules: {
            make: {
                required: true
            },
            model: {
                required: true

            },
            type: {
                required: true

            },
            unitprice: {
                required: true

            },
            imagepath: {
                required: true
            }


        },

        messages: {
            make: {
                required: 'I am a required field...'
            },
            model: {
                required: 'Please state the model of the car'
            },
            type: {
                required: 'Please state the type of the car'
            },
            unitprice: {
                required: 'Please state the price of the unit'
            },
            imagepath: {
                required: 'Please select an image for the car'
            },


        }
    });
});