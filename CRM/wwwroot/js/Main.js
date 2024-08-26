try {
    const savedTheme = localStorage.getItem('theme');

    $(document).ready(function () {
        console.info("Ready Main.js..")

        $("#toggleSidebarMobile").click(function () {
            $("#sidebar").toggleClass("hidden");
        });

        $('#preloaderChangeTheme').hide();

        if (savedTheme === 'dark') {
            $('html').addClass('dark');
            $('#themeButton').html('<i class="far fa-sun"></i>');

        }
        else {
            $('html').removeClass('dark');
            $('#themeButton').html('<i class="fas fa-moon"></i>');

        }

    });

    MenuSeleccionado(savedTheme);
    function MenuSeleccionado(theme) {

        var url = window.location.href;
        var bgMenu = theme == 'dark' ? 'bg-gray-400' : 'bg-gray-200'

        $('ul.space-y-2 a').removeClass('bg-gray-400').removeClass("bg-gray-200");
        $('ul.space-y-2 li button').attr('aria-expanded', 'false');
        $('ul.space-y-2 li ul').addClass('hidden');



        $('ul.space-y-2 a').filter(function () {
            return this.href === url;
        }).addClass(bgMenu).closest('ul').removeClass('hidden').siblings('button').attr('aria-expanded', 'true');

    }
    function CambiarTemaColor() {
        const htmlElement = $('html');
        const themeButton = $('#themeButton');
        const darkIcon = $('#theme-toggle-dark-icon');
        const lightIcon = $('#theme-toggle-light-icon');


        const isDarkTheme = htmlElement.hasClass('dark');

        if (isDarkTheme) {
            htmlElement.removeClass('dark');
            themeButton.html('<i class="fas fa-moon"></i>');

            darkIcon.removeClass('hidden').addClass('block');
            lightIcon.removeClass('block').addClass('hidden');

            localStorage.setItem('theme', 'light');
            theme = "light";
        }
        else {
            htmlElement.addClass('dark');
            themeButton.html('<i class="far fa-sun"></i>');

            lightIcon.removeClass('hidden').addClass('block');
            darkIcon.removeClass('block').addClass('hidden');

            localStorage.setItem('theme', 'dark');
            theme = "dark";
        }

        location.reload();
    }
    
}

catch (error) {
    console.error("Error on Main.js: " + error);
}

