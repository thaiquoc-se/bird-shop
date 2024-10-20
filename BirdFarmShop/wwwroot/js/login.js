const warapper = document.querySelector('.warapper');
const loginLink = document.querySelector('.login-link');
const registerLink = document.querySelector('.register-link');

registerLink.addEventListener('click', () => {
    warapper.classList.add('active');
});

loginLink.addEventListener('click', () => {
    warapper.classList.remove('active');
})