function validateEmail() 
{
  const emailInput = document.getElementById('email');
  const emailError = document.getElementById('emailError');

  // Regular expression for email validation
  const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

  if (!emailRegex.test(emailInput.value)) 
 {
    // Showing the error message if the email is invalid
    emailError.style.display = 'block';
    emailInput.classList.add('invalid');
  } 
else
 {
    // Hide the error message if the email is valid
    emailError.style.display = 'none';
    emailInput.classList.remove('invalid');
  }
}
//--------------------------------------------------------------------------------------------------------------
function validateMobileNumber() {
  const mobileNumberInput = document.getElementById('mobileNumber');
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
  const usernameInput = document.getElementById('username');
  const usernameError = document.getElementById('usernameError');
  const username = usernameInput.value.trim();
  const disallowedCharsPattern = /[^\w-.]/;
  if (username === '') 
  {
    usernameError.textContent = 'Username cannot be empty.';
  } 
  else if (username.length < 4)
 {
    usernameError.textContent = 'Username must be at least 4 characters long.';
  }
  else if(disallowedCharsPattern.test(username))
 {
   usernameError.textContent = 'Username contains disallowed characters, only alphabets,numbers and underscore allowed!';
 }
  else
 {
    usernameError.textContent = '';
  }
}

//--------------------------------------------------------------------------------------------------------------
function validatePassword() {
  const passwordInput = document.getElementById('password');
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
function validateFirstName() {
  const firstNameInput = document.getElementById('firstName');
  const firstNameError = document.getElementById('firstNameError');
  const firstName = firstNameInput.value.trim();

  if (firstName === '') {
    firstNameError.textContent = 'First Name cannot be empty.';
  } else {
    firstNameError.textContent = '';
  }
}
//--------------------------------------------------------------------------------------------------------------
function validateLastName() {
  const lastNameInput = document.getElementById('lastName');
  const lastNameError = document.getElementById('lastNameError');
  const lastName = lastNameInput.value.trim();

  if (lastName === '') {
    lastNameError.textContent = 'Last Name cannot be empty.';
  } else {
    lastNameError.textContent = '';
  }
}
//--------------------------------------------------------------------------------------------------------------
function validatePasswordMatch() {
  const passwordInput = document.getElementById('password');
  const confirmPasswordInput = document.getElementById('confirmPassword');
  const passwordError = document.getElementById('passwordError');

  const password = passwordInput.value;
  const confirmPassword = confirmPasswordInput.value;

 if (password !== confirmPassword) {
    passwordError.textContent = 'Passwords do not match.';
  } else {
    passwordError.textContent = '';
  }
}

function validateForm(event) {
  event.preventDefault(); // Prevent form submission for now

  // Check password match
  validatePasswordMatch();

  // If there are no errors, submit the form
  if (passwordError.textContent === '') {
    event.target.submit();
  }
}

const form = document.querySelector('form');
const passwordInput = document.getElementById('password');
const confirmPasswordInput = document.getElementById('confirmPassword');

// Validate on input change
passwordInput.addEventListener('input', validatePasswordMatch);
confirmPasswordInput.addEventListener('input', validatePasswordMatch);

// Validate on form submit
form.addEventListener('submit', validateForm);

//--------------------------------------------------------------------------------------------------------------

