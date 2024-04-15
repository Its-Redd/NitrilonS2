let img = document.querySelectorAll('img');

// Loop through the images and add an event listener to each one then check which 
// image was clicked
img.forEach(element => {
    element.addEventListener('click', function() {
        let imgId = element.getAttribute('id');
        switch(imgId) {
            case "1":
                // TODO: MAKE FUNCTIONALITY FOR THE RED EMOJI
                alert('You clicked on the red emoji'); //! TEMPORARY
                break;
            case "2":
                // TODO: MAKE FUNCTIONALITY FOR THE YELLOW EMOJI
                alert('You clicked on the yellow emoji'); //! TEMPORARY
                break;
            case "3":
                // TODO: MAKE FUNCTIONALITY FOR THE GREEN EMOJI
                alert('You clicked on the green emoji'); //! TEMPORARY
                break;
                default:
                    alert('There has been an error');
        }
    });
});