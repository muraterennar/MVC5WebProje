var a_parent = document.querySelectorAll(".a_parent");
var dd_menu_a = document.querySelectorAll(".dd_menu_a");

a_parent.forEach(function (aitem) {
    aitem.addEventListener("mouseenter", function () {
        a_parent.forEach(function (aitem) {
            aitem.classList.remove("active");
        });
        dd_menu_a.forEach(function (dd_menu_item) {
            dd_menu_item.classList.remove("active");
        });

        aitem.classList.add("active");
    });
});

dd_menu_a.forEach(function (dd_menu_item) {
    dd_menu_item.addEventListener("mouseenter", function () {
        dd_menu_a.forEach(function (dd_menu_item) {
            dd_menu_item.classList.remove("active");
        });
        dd_menu_item.classList.add("active");
    });
});


let listVideo = document.querySelectorAll(".video-list .vid");
let mainVideo = document.querySelector(".main-video video");
let title = document.querySelector(".main-video .title");

listVideo.forEach((video) => {
    video.onclick = () => {
        listVideo.forEach((vid) => vid.classList.remove("active"));
        video.classList.add("active");
        if (video.classList.contains('active')) {
            let src = video.children[0].getAttribute('src');
            mainVideo.src = src;

            let text = video.children[1].innerHTML;
            title.innerHTML = text;
        };
    };
});