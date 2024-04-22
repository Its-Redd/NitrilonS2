let img = document.querySelectorAll('img');
let apiURL = "https://localhost:6969/api/Event"
let ratingId;

/* Fetch the events from the API where the date
is greater than or equal to the current date using sql queries
*/

// Loop through the images and add an event listener
// to each one then check which 
// image was clicked
img.forEach(element => {
    element.addEventListener('click', function() {
        let ratingId = element.getAttribute('id');
        switch(ratingId) {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;               
                default:
                    alert('There has been an error');
                    console.error('Error in ratingId switch statement');
        }
    });
});