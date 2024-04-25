let img = document.querySelectorAll("img");
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
    fetch(apiURL, {
      method: "POST",
      body: JSON.stringify({ selectedEvent, ratingId }),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      });
    //   TODO: Vis feedback, fjern efter X antal sekunder - eksempel:
    setTimeout(() => {
      // Sker instant:
      console.log("Feedback vises");
    }, 2000);
    // Sker efter 2 sekunder:
    console.log("Fjerner feedback.");
  });
});