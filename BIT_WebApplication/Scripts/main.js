'Use strict'


const pass_field = document.querySelector('.pass-key');
const showBtn = document.querySelector('.show');

/***** Check password input and toggle state when button clicked *****/
showBtn.addEventListener('click', function () {
    if (pass_field.type === "password") {
        pass_field.type = "text";
        showBtn.textContent = "HIDE";
        showBtn.style.color = "#3498db";
    } else {
        pass_field.type = "password";
        showBtn.textContent = "SHOW";
        showBtn.style.color = "#222";
    }
}
);


/* STRETCH BACKGROUND IMAGE FOR CONTRACTOR, ADMIN & CLIENT PAGES */





