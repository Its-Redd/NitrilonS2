fetch("https://localhost:7056/api/Member")
  .then((response) => response.json())
  .then((data) => {
    // Get the <section> element
    let memberList = document.querySelector("#memberList");

    // Loop through the events and create <li> elements
    data.forEach((event) => {
      let li = document.createElement("li");

      memberList.appendChild(li);
    });
  })
  .catch((error) => {
    console.error("Error fetching Members:", error);
  });