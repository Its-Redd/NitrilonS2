let img = document.querySelectorAll("img");
let apiURL = "https://localhost:7056/api/Event";
let ratingId;
let allEvents = [];
let selectedEvent = 1; // ! SKAL VÆRE EVENT ID'ET



// Setup events when the page loads - fetches all events so the
// user can choose what event guests are rating
function SetupEvents() {
  fetch(apiURL)
    .then((response) => response.json())
    .then((data) => {
      console.log(data);
      allEvents = data;
    });
}


/* Loop through the events and create an li element for each one
 in the ul element with the id "eventsList" in the HTML
 The LI element should have an event listener that sets the
 selectedEvent variable to the event id.
 The event Li should show the name, date and description of the event
*/





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