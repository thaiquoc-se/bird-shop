document.getElementById('btn_nav').onclick = function () {
    let menu = document.getElementById('menu');
    let blur = document.getElementById('blur');
    menu.style.visibility = 'visible';
    blur.style.display = 'block';
    menu.style.opacity = '1';

    blur.onclick = function () {
        menu.style.visibility = 'hidden';
        menu.style.opacity = '0';
        blur.style.display = 'none';

    }
}   