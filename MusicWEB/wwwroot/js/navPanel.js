document.addEventListener('DOMContentLoaded', function () {
    const links = document.querySelectorAll('.nav-link');
    let activeLink = document.querySelector('.nav-link.active');
    var navbar = document.querySelector('nav.main-navbar');
    var ul = document.querySelector('.navbar-ul');
    var lastScrollTop = 0;
    var isScrollingUp = false;

    function setActiveLink() {
        if (activeLink) {
            activeLink.classList.remove('active');
        }
        this.classList.add('active');
        activeLink = this;
    }

    function handleMouseEnter() {
        this.classList.add('hover');
        if (activeLink) {
            activeLink.classList.remove('active');
        }
    }

    function handleMouseLeave() {
        this.classList.remove('hover');
        if (activeLink) {
            activeLink.classList.add('active');
        }
    }

    links.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            setActiveLink.call(this);
            const url = this.getAttribute('href');
            history.pushState({ path: url }, '', url);
            loadContent(url);
        });

        link.addEventListener('mouseenter', handleMouseEnter);
        link.addEventListener('mouseleave', handleMouseLeave);
    });

    window.addEventListener('scroll', function () {
        var currentScroll = window.pageYOffset || document.documentElement.scrollTop;

        // Проверка направления прокрутки
        if (currentScroll > lastScrollTop) {
            // Скролл вниз
            isScrollingUp = false;
        } else {
            // Скролл вверх
            isScrollingUp = true;
        }
        lastScrollTop = currentScroll <= 0 ? 0 : currentScroll;

        // Добавление/удаление классов в зависимости от направления прокрутки
        if (currentScroll > 50) {
            if (isScrollingUp) {
                navbar.classList.add('navbar-show');
                navbar.classList.remove('navbar-hide');
                
            } else {
                navbar.classList.add('navbar-hide');
                navbar.classList.remove('navbar-show');
            }
            navbar.classList.add('navbar-scrolled');
        } else {
            // Когда экран в самом верху, навбар должен отображаться
            navbar.classList.remove('navbar-scrolled', 'navbar-hide');
            navbar.classList.add('navbar-show');
        }
    });
}); 