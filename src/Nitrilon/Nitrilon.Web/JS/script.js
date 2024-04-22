let img = document.querySelectorAll('img');
let apiURL = "https://localhost:6969/api/Event"
let ratingId;

// Fetch data from the API
fetch(apiURL)
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        // Process the data here
        console.log(data);
    })
    .catch(error => {
        // Handle errors
        console.error('Error:', error);
        alert('There has been an error');
    });

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