// Scroll
document.addEventListener('DOMContentLoaded', function () {   
    var elements = document.querySelectorAll('.animated-element');
    elements.forEach(function (element) {
        var elementTop = element.getBoundingClientRect().top;
        var windowHeight = window.innerHeight;

        if (elementTop < windowHeight - 200) {
            element.classList.add('appear');
        }
    });
});

document.addEventListener('scroll', function () {
    var scrollTop = window.scrollY;
    var windowHeight = window.innerHeight;
    var elements = document.querySelectorAll('.animated-element');

    elements.forEach(function (element) {
        var elementTop = element.getBoundingClientRect().top;
        var elementBottom = element.getBoundingClientRect().bottom;

        if (elementTop < windowHeight - 200 && elementBottom > 0) {
            element.classList.add('appear');
        } else {
            element.classList.remove('appear');
        }
    });
});

// Searcch
document.addEventListener('DOMContentLoaded', function () {
    const searchContainer = document.querySelector('.search');
    const searchInput = searchContainer.querySelector('input');
    const searchButton = searchContainer.querySelector('button');

    searchButton.addEventListener('click', function () {
        searchContainer.classList.add('active');
        searchInput.focus();
    });

    document.addEventListener('click', function (event) {
        if (!searchContainer.contains(event.target)) {
            searchContainer.classList.remove('active');
            searchInput.blur();
        }
    });
});
