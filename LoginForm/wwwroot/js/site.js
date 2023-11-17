// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to set a cookie
function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

// Function to get a cookie
function getCookie(name) {
    var nameEQ = name + "=";
    var cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        while (cookie.charAt(0) == ' ') {
            cookie = cookie.substring(1, cookie.length);
        }
        if (cookie.indexOf(nameEQ) == 0) {
            return cookie.substring(nameEQ.length, cookie.length);
        }
    }
    return null;
}
// Apply user's selection from the stored cookie
function applyUserSelection() {
    var userSelection = getCookie('userSelection');

    if (userSelection === 'dog') {
        document.body.style.backgroundImage = "url('https://vitapet.com/media/kczlgn0r/dog-breed-temperaments-1240x640.jpg?anchor=center&mode=crop&width=1240&rnd=133155369200630000')";
    } else if (userSelection === 'cat') {
        document.body.style.backgroundImage = "url('https://images.contentful.com/e43mbx7oxv8s/dTeQVZbR72uiYkEAYKyUS/bd3825a93aace2c7b368a7a742b1000f/000122_ZV_SCSW_HeroImages_1900x1024_D1.jpg')";
    } else if (userSelection === 'dog_cat') {
        document.body.style.backgroundImage = "url('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiWcfKeoPHOOsNUI8u4xbqB6_k4OKRRCkSWA&usqp=CAU')";
    } else if (userSelection === 'plain') {
        document.body.style.backgroundImage = "url('https://i.pinimg.com/originals/b7/80/80/b78080b4fc1da5331dabf8113087b6e1.jpg')";
    }
}

// Apply user's selection on page load
applyUserSelection();

// Event listeners to change the background and set the user's selection in a cookie
catDogSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiWcfKeoPHOOsNUI8u4xbqB6_k4OKRRCkSWA&usqp=CAU')";
    setCookie('userSelection', 'dog_cat', 30);
});

dogSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://vitapet.com/media/kczlgn0r/dog-breed-temperaments-1240x640.jpg?anchor=center&mode=crop&width=1240&rnd=133155369200630000')";
    setCookie('userSelection', 'dog', 30);
});

catSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://images.contentful.com/e43mbx7oxv8s/dTeQVZbR72uiYkEAYKyUS/bd3825a93aace2c7b368a7a742b1000f/000122_ZV_SCSW_HeroImages_1900x1024_D1.jpg')";
    setCookie('userSelection', 'cat', 30);
});

defaultSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://i.pinimg.com/originals/b7/80/80/b78080b4fc1da5331dabf8113087b6e1.jpg')";
    setCookie('userSelection', 'plain', 30);
});


//const dogSelect = document.querySelector("#dogSelect");
//const catSelect = document.querySelector("#catSelect");
//const catDogSelect = document.querySelector("#catDogSelect");

// Create cookie here

//dogSelect.addEventListener("click", () => {
//    document.body.style.backgroundImage = "url('https://vitapet.com/media/kczlgn0r/dog-breed-temperaments-1240x640.jpg?anchor=center&mode=crop&width=1240&rnd=133155369200630000')"


//});
//catSelect.addEventListener("click", () => {
  //  document.body.style.backgroundImage = "url('https://images.contentful.com/e43mbx7oxv8s/dTeQVZbR72uiYkEAYKyUS/bd3825a93aace2c7b368a7a742b1000f/000122_ZV_SCSW_HeroImages_1900x1024_D1.jpg')"

//});
//catDogSelect.addEventListener("click", () => {
//    document.body.style.backgroundImage = "url('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiWcfKeoPHOOsNUI8u4xbqB6_k4OKRRCkSWA&usqp=CAU')"

//});