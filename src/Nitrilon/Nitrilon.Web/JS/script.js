let img = document.querySelectorAll("img");
let apiURL = "https://localhost:7056/api/Event";
let ratingId;
let allEvents = [];
let selectedEvent = 1; // ! SKAL VÆRE EVENT ID'ET

/* Fetch the events from the API where the date
is greater than or equal to the current date using sql queries
*/

fetchEvents();


function fetchEvents() {
  fetch(apiURL)
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      allEvents = data;
    });
}

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
      // ! Måske skal du bruge dem her? - jeg bruger dem ikke.
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
    // ! Husk at brug metoder til at ændre siderne. - og rydde lidt op i din kode
    // ! Jeg havde personligt redirected imellem HTML sider, og så gemt relevant data i sessionStorage.
    // Læs dette link VV
    // https://stackoverflow.com/questions/11609376/share-data-between-html-pages
  });
});