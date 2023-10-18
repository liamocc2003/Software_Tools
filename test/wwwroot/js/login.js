//Login to Page LoginTag
let send = document.getElementById('btn');

let enterFunc = function () {
    let username = document.getElementById('username');
    let password = document.getElementById('password');

    total = username.value + password.value;
    window.alert(total);
}

send.addEventListener('click', enterFunc);