document.addEventListener('DOMContentLoaded', function () {
    window.initializeParallax = function () {
        var background1 = document.querySelector('.background1');
        var background2 = document.querySelector('.background2');
        var background3 = document.querySelector('.background3');
        //var background4 = document.querySelector('.background4');

        window.addEventListener('scroll', function () {
            calculateParallax();
        });

        function calculateParallax() {
            var scrolled = window.scrollY;
            var windowHeight = window.innerHeight;

            // Adjust the speed of parallax scrolling by changing the multiplier (e.g., 0.2)
            background1.style.opacity = calculateOpacity(0, windowHeight, scrolled);
            background2.style.opacity = calculateOpacity(1, windowHeight, scrolled);
            background3.style.opacity = calculateOpacity(2, windowHeight, scrolled);
            //background4.style.opacity = calculateOpacity(3, windowHeight, scrolled);
        }

        // Helper function to calculate the opacity based on scroll position
        function calculateOpacity(imageIndex, windowHeight, scrolled) {
            if (imageIndex == 0) {
                return 1;
            }

            if (scrolled > windowHeight * imageIndex) {
                return 1;
            }

            // Set a threshold for visibility (adjust as needed)
            var visibilityThreshold = windowHeight / 2;

            if (scrolled < (windowHeight * imageIndex) - visibilityThreshold) {
                return 0;
            }

            // Calculate the scroll position relative to the visibility threshold
            var scrollPosition = scrolled - ((windowHeight * imageIndex) - visibilityThreshold);

            // Calculate the opacity based on the scroll position relative to the visibility threshold
            var opacity = (scrollPosition / visibilityThreshold);

            return opacity;
        }
    };

    window.initializeParallax(); // Call the function to initialize parallax effect
    calculateParallax();
});