fetch("https://localhost:7056/api/Member")
  .then((response) => response.json())
  .then((data) => {
    // Get the <section> element
    let memberList = document.querySelector("#memberList");

    console.log(data);

    // Loop through the events and create <li> elements
    data.forEach((Member) => {
      let li = document.createElement("li");

      memberList.appendChild(li);
    });
  })
  .catch((error) => {
    console.error("Error fetching Members:", error);
  });

  // Create a new member
    function createMember(membershipId, name, joinDate, phonenumber, emailadress ) {
        let member = {
            membershipId: membershipId,
            name: name,
            joinDate: joinDate,
            phonenumber: phonenumber,
            emailadress: emailadress
        };
            
        
