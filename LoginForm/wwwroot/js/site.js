// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const dogSelect = document.querySelector("#dogSelect");
const catSelect = document.querySelector("#catSelect");
const catDogSelect = document.querySelector("#catDogSelect");

dogSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://vitapet.com/media/kczlgn0r/dog-breed-temperaments-1240x640.jpg?anchor=center&mode=crop&width=1240&rnd=133155369200630000')"

});
catSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://images.contentful.com/e43mbx7oxv8s/dTeQVZbR72uiYkEAYKyUS/bd3825a93aace2c7b368a7a742b1000f/000122_ZV_SCSW_HeroImages_1900x1024_D1.jpg')"

});
catDogSelect.addEventListener("click", () => {
    document.body.style.backgroundImage = "url('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQiWcfKeoPHOOsNUI8u4xbqB6_k4OKRRCkSWA&usqp=CAU')"

});

