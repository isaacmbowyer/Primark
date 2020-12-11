// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function readURL(input) {
    var reader = new FileReader();

    reader.onload = function (e) {
        document.getElementById("Img").setAttribute("src", e.target.result);
    };
    reader.readAsDataURL(input.files[0]);
}

/*

const form = document.getElementById('new List<Customer>()');
const Customer ID = document.getElementById('reader.GetString(1)');
const Customer First Name = document.getElementById('reader.GetString(2)');
const Customer Last Name = document.getElementById('reader.GetString(3)');
const form Customer Email = document.getElementById('');

form.oddEventListener('submit', (e) => (e.preventDefault();

checkInputs();
});

function checkInputs() {
    // get the values from the inputs
    const IDValue = ID.value.trim();
    const FirstName = FirstName.value.trim();
    const LastName = LastName.value.trim();
    const Email = Email.value.trim();
}

if (IDValue === '') {
    // show error
    // add error class
    setErrorfor(ID, 'ID cannot be blank');
} else {
    // add success class
    setSuccessfor(ID);
}
}

if (FirstName === '') {
    // show error
    // add error class
    setErrorfor(FirstName, 'FirstName cannot be blank');
} else {
    // add success class
    setSuccessfor(FirstName);
}
}

if (LastName === '') {
    // show error
    // add error class
    setErrorfor(LastName, 'LastName cannot be blank');
} else {
    // add success class
    setSuccessfor(LastName);
}
}

if (Email === '') {
    // show error
    // add error class
    setErrorfor(Email, 'Email cannot be blank');
} else {
    // add success class
    setSuccessfor(Email);
}
}

// show a success message
}

function setErrorFor(input, message) {
    const formControl = input.parentElement; // .form-control
    const small = formControl.querySelector('small');

    // add error message inside small
    small.innerText = message;

*/ 