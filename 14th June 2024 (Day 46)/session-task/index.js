const form = document.getElementById("js-register-form");
const dobInput = document.getElementById("dob");
const ageInput = document.getElementById("age");
const nameInput = document.getElementById("name");
const phoneInput = document.getElementById("phone");
const emailInput = document.getElementById("email");
const passwordInput = document.getElementById("password");
const professionInput = document.getElementById("profession");
const submitButton = document.getElementById("submit-button");
const validationContainer = document.getElementById("validation-container");
const genderOption = document.getElementsByName("gender");
// Calculate the age
function calculateAge(dob) {
  const today = new Date();
  const birthDate = new Date(dob);

  let age = today.getFullYear() - birthDate.getFullYear();

  const monthDifference = today.getMonth() - birthDate.getMonth();
  const dayDifference = today.getDate() - birthDate.getDate();

  if (monthDifference < 0 || (monthDifference === 0 && dayDifference < 0)) {
    age--;
  }

  return age;
}

// validate individual fields
function validateDobField() {
  const dob = dobInput.value;
  if (dob === "") {
    dob.parentElement.classList.add("field-error");
  }
}

// validate form function
function validateForm() {
  const dob = dobInput.value;
  const age = ageInput.value;
  const name = nameInput.value;
  const email = emailInput.value;
  const password = passwordInput.value;
  const profession = professionInput.value;
  const phone = phoneInput.value;

  // add individual field error messages
  if (dob === "") {
    dobInput.parentElement.classList.add("field-error");
  }

  if (name === "") {
    nameInput.parentElement.classList.add("field-error");
  }

  if (email === "") {
    emailInput.parentElement.classList.add("field-error");
  }

  if (password === "") {
    passwordInput.parentElement.classList.add("field-error");
  }

  if (profession === "") {
    professionInput.parentElement.classList.add("field-error");
  }

  if (phone === "") {
    phoneInput.parentElement.classList.add("field-error");
  }

  if (genderOption[0].checked === false && genderOption[1].checked === false) {
    genderOption[0].parentElement.parentElement.classList.add("field-error");
  } else {
    genderOption[0].parentElement.parentElement.classList.remove("field-error");
  }

  if (
    dob === "" ||
    age === "" ||
    name === "" ||
    email === "" ||
    password === "" ||
    profession === ""
  ) {
    return "All fields are required";
  }
}

// event listeners
dobInput.addEventListener("change", function (e) {
  const dob = e.target.value;
  const age = calculateAge(dob);
  ageInput.value = age;
});

dobInput.addEventListener("blur", function () {
  if (dobInput.value === "") {
    dobInput.parentElement.classList.add("field-error");
    return;
  }

  dobInput.parentElement.classList.remove("field-error");
  ageInput.parentElement.classList.remove("field-error");
});

nameInput.addEventListener("blur", function () {
  if (nameInput.value === "") {
    nameInput.parentElement.classList.add("field-error");
    return;
  }

  nameInput.parentElement.classList.remove("field-error");
});

emailInput.addEventListener("blur", function () {
  if (emailInput.value === "") {
    emailInput.parentElement.classList.add("field-error");
    return;
  }

  emailInput.parentElement.classList.remove("field-error");
});

passwordInput.addEventListener("blur", function () {
  if (passwordInput.value === "") {
    passwordInput.parentElement.classList.add("field-error");
    return;
  }

  passwordInput.parentElement.classList.remove("field-error");
});

phoneInput.addEventListener("blur", function () {
  if (phoneInput.value === "") {
    phoneInput.parentElement.classList.add("field-error");
    return;
  }

  phoneInput.parentElement.classList.remove("field-error");
});

professionInput.addEventListener("blur", function () {
  if (professionInput.value === "") {
    professionInput.parentElement.classList.add("field-error");
    return;
  }

  professionInput.parentElement.classList.remove("field-error");
});

ageInput.addEventListener("blur", function () {
  if (ageInput.value === "") {
    ageInput.parentElement.classList.add("field-error");
    return;
  }

  ageInput.parentElement.classList.remove("field-error");
});

// validate the form
form.addEventListener("submit", function (e) {
  e.preventDefault();

  const error = validateForm();

  if (error) {
    validationContainer.innerText = error;
  } else {
    validationContainer.innerText = "";
    alert("Form submitted successfully");
  }
});
