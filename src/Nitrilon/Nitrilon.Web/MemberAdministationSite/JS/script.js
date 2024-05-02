fetch("https://localhost:7056/api/Member")
  .then((response) => response.json())
  .then((data) => {
    // Get the <section> element
    let memberList = document.querySelector("#memberList");

    console.log(data);

    // Loop through the events and create <li> elements
    data.forEach((Member) => {
      let li = document.createElement("li");
      let h2 = document.createElement("h2");
        let p = document.createElement("p");
        let p2 = document.createElement("p");
        let p3 = document.createElement("p");
        let p4 = document.createElement("p");
        let del = document.createElement("button");
        let edit = document.createElement("button");

        h2.textContent = Member.name;

        if(Member.membershipId == 1){
            p.textContent = "Aktivt Medlem";
        } else if(Member.membershipId == 2){
            p.textContent = "Passivt Medlem";
        };

        let date = Member.joinDate.split("T")[0];
        p2.textContent = date;
        p2.id = "date";

        p3.textContent = Member.phoneNumber;
        p4.textContent = Member.emailAdress; 
        p4.id = "email";


        del.textContent = "Delete";
        del.id = "delete";
        del.addEventListener("click", function() {
            fetch("https://localhost:7056/api/Member/" + Member.id, {
                method: "DELETE"
            })
            .then((response) => {
                if(response.ok){
                    li.remove();
                }
            })
            .catch((error) => {
                console.error("Error deleting member:", error);
            });
        });

        edit.textContent = "Edit";
        edit.id = "edit";
        edit.addEventListener("click", function() {
            let name = prompt("Name", Member.name);
            let membershipId = prompt("MembershipId", Member.membershipId);
            let joinDate = prompt("JoinDate", Member.joinDate);
            let phoneNumber = prompt("PhoneNumber", Member.phoneNumber);
            let emailAdress = prompt("EmailAdress", Member.emailAdress);

            let member = {
                name: name,
                membershipId: membershipId,
                joinDate: joinDate,
                phoneNumber: phoneNumber,
                emailAdress: emailAdress
            };

            fetch("https://localhost:7056/api/Member/" + Member.id, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(member)
            })
            .then((response) => {
                if(response.ok){
                    h2.textContent = name;
                    p.textContent = membershipId;
                    p2.textContent = joinDate;
                    p3.textContent = phoneNumber;
                    p4.textContent = emailAdress;
                }
            })
            .catch((error) => {
                console.error("Error updating member:", error);
            });
        });
    



        li.appendChild(h2);
        li.appendChild(p);
        li.appendChild(p2);
        li.appendChild(p3);
        li.appendChild(p4);



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

    }
            
        
