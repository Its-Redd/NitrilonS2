// Variables
let img = document.querySelectorAll("section img");
let apiURL = "https://localhost:7056/api/Event"; 
let ratingId;
let allEvents = [];
let selectedEvent = -1;

// Setup events when the page loads - fetches all events so the
// user can choose what event guests are rating
async function SetupEvents() {
  await fetch(apiURL)
    .then((response) => response.json())
    .then((data) => {
      allEvents = data;
    });

  DisplayEvents();
}

// Display all events in a list so the user can choose 
// what event guests are rating

// TODO: only display events that are in the future or in the past 3 days
function DisplayEvents() {
    let setupPage = document.querySelector("#setup");
    let ul = document.querySelector("#eventList");
    allEvents.forEach((event) => {
        let li = document.createElement("li");
        let name = document.createElement("h2");
        let date = document.createElement("h3");
        let desc = document.createElement("h3");
        let cutDate = event.date.split("T")[0];
        
        name.textContent = event.name;
        date.textContent = cutDate;
        desc.textContent = event.description;
        
        li.appendChild(name);
        li.appendChild(date);
        li.appendChild(desc);
        
        ul.appendChild(li);

        li.addEventListener("click", function () {
            selectedEvent = event.id;
            setupPage.style.display = "none";
        });
    });
}

SetupEvents();

// Loop through the images and add an event listener
// to each one then check which
// image was clicked
img.forEach((element) => {
  element.addEventListener("click", function () {
    let ratingId = element.getAttribute("id");
    fetch(`https://localhost:7056/api/EventRatings?eventId=${selectedEvent}&ratingId=${ratingId}`, {
      method: "POST",
      body: JSON.stringify({ selectedEvent, ratingId }),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        console.log("Data added to database");
      });
      let confirmation = document.querySelector("#confirmation");

    setTimeout(() => {
        confirmation.style.visibility = "hidden";
    }, 2500);
    confirmation.style.visibility = "visible";
    
  });
});