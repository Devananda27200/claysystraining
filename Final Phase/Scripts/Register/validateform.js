function validateEmail() {
    const emailInput = document.getElementById('email');
    const emailError = document.getElementById('emailError');

    // Regular expression for email validation
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (!emailRegex.test(emailInput.value)) {
        // Showing the error message if the email is invalid
        emailError.style.display = 'block';
        emailInput.classList.add('invalid');
    }
    else {
        // Hide the error message if the email is valid
        emailError.style.display = 'none';
        emailInput.classList.remove('invalid');
    }
}
//--------------------------------------------------------------------------------------------------------------
function validateMobileNumber() {
    const mobileNumberInput = document.getElementById('jmobileNumber');
    const mobileNumberError = document.getElementById('mobileNumberError');
    const mobileNumberRegex = /^\d{10}$/;

    if (!mobileNumberRegex.test(mobileNumberInput.value)) {
        mobileNumberError.textContent = 'Please enter a valid 10-digit mobile number.';
        mobileNumberError.style.display = 'block';
        mobileNumberInput.classList.add('invalid');
    } else {
        mobileNumberError.style.display = 'none';
        mobileNumberInput.classList.remove('invalid');
    }
}
//--------------------------------------------------------------------------------------------------------------
function validateUsername() {
    const usernameInput = document.getElementById('username1');
    const usernameError = document.getElementById('usernameError');
    const username = usernameInput.value.trim();
    const disallowedCharsPattern = /[^\w-.]/;
    if (username === '') {
        usernameError.textContent = 'Username cannot be empty.';
    }
    else if (username.length < 4) {
        usernameError.textContent = 'Username must be at least 4 characters long.';
    }
    else if (disallowedCharsPattern.test(username)) {
        usernameError.textContent = 'Username contains disallowed characters, only alphabets,numbers and underscore allowed!';
    }
    else {
        usernameError.textContent = '';
    }
}
//--------------------------------------------------------------------------------------------------------------
function validatePassword() {
    const passwordInput = document.getElementById('password1');
    const passwordError = document.getElementById('passwordError');
    const password = passwordInput.value.trim();

    if (password === '') {
        passwordError.textContent = 'Password cannot be empty.';
    } else if (password.length < 8) {
        passwordError.textContent = 'Password must be at least 8 characters long.';
    } else {
        passwordError.textContent = '';
    }
}
//--------------------------------------------------------------------------------------------------------------
function Validatefield() {
    var isValid = true;
    var alertMessage = "";

    var firstName = document.getElementById("jfirstname").value.trim();
    if (firstName === "") {
        alertMessage += "Please enter your first name.\n";
        isValid = false;
    }

    var lastName = document.getElementById("jlastname").value.trim();
    if (lastName === "") {
        alertMessage += "Please enter your last name.\n";
        isValid = false;
    }
}

//--------------------------------------------------------------------------------------------------------------
/*<script>*/
    // Calculate age based on selected date of birth
document.getElementById("jdateofbirth").addEventListener("change", function () {
    var dob = new Date(this.value);
    var currentDate = new Date();
    var age = currentDate.getFullYear() - dob.getFullYear();

    if (currentDate.getMonth() < dob.getMonth() || (currentDate.getMonth() === dob.getMonth() && currentDate.getDate() < dob.getDate())) {
        age--;
    }

    document.getElementById("jage").value = age;

    // Validate if age is 18 or above
    if (age < 18) {
        alert("You must be 18 years or older to register.");
        this.value = ""; // Clear the selected date
        document.getElementById("jage").value = ""; // Clear the age input
    }/*</script>*/
//--------------------------------------------------------------------------------------------------------------
