fetch("https://localhost:7056/api/Member")
  .then((response) => response.json())
  .then((data) => {
    // Get the <section> element
    let memberList = document.querySelector("#memberList");

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
            p.textContent = "Aktiv";
        } else if(Member.membershipId == 2){
            p.textContent = "Passiv";
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
            // Create a modal element
            let modal = document.createElement("div");
            modal.classList.add("modal");

            // Create form elements for editing member data
            let form = document.createElement("form");

            // Create input elements for editing member data
            let nameLabel = document.createElement("label");
            nameLabel.textContent = "Name:";
            let nameInput = document.createElement("input");
            nameInput.type = "text";
            nameInput.value = Member.name;

            let membershipLabel = document.createElement("label");
            membershipLabel.textContent = "Membership:";
            let membershipSelect = document.createElement("select");
            let activeOption = document.createElement("option");
            activeOption.value = 1;
            activeOption.textContent = "Aktiv";
            let passiveOption = document.createElement("option");
            passiveOption.value = 2;
            passiveOption.textContent = "Passiv";
            membershipSelect.appendChild(activeOption);
            membershipSelect.appendChild(passiveOption);
            membershipSelect.value = Member.membershipId;

            let joinDateLabel = document.createElement("label");
            joinDateLabel.textContent = "Join Date:";
            let joinDateInput = document.createElement("input");
            joinDateInput.type = "date";
            joinDateInput.value = Member.joinDate.split("T")[0];

            let phoneNumberLabel = document.createElement("label");
            phoneNumberLabel.textContent = "Phone Number:";
            let phoneNumberInput = document.createElement("input");
            phoneNumberInput.type = "text";
            phoneNumberInput.value = Member.phoneNumber;

            let emailLabel = document.createElement("label");
            emailLabel.textContent = "Email Address:";
            let emailInput = document.createElement("input");
            emailInput.type = "email";
            emailInput.value = Member.emailAdress;

            let saveButton = document.createElement("button");
            saveButton.textContent = "Save";
            saveButton.addEventListener("click", function() {
                // Update member data
                Member.name = nameInput.value;
                Member.membershipId = parseInt(membershipSelect.value);
                Member.joinDate = joinDateInput.value;
                Member.phoneNumber = phoneNumberInput.value;
                Member.emailAdress = emailInput.value;

                console.log(Member);

                // Update the member in the database
                fetch("https://localhost:7056/api/Member/", {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(Member)
                })

                // Close the modal
                modal.remove();
            });

            let cancelButton = document.createElement("button");
            cancelButton.textContent = "Cancel";
            cancelButton.addEventListener("click", function() {
                // Close the modal without saving changes
                modal.remove();
            });

            // Append input elements to the form
            form.appendChild(nameLabel);
            form.appendChild(nameInput);
            form.appendChild(membershipLabel);
            form.appendChild(membershipSelect);
            form.appendChild(joinDateLabel);
            form.appendChild(joinDateInput);
            form.appendChild(phoneNumberLabel);
            form.appendChild(phoneNumberInput);
            form.appendChild(emailLabel);
            form.appendChild(emailInput);
            form.appendChild(saveButton);
            form.appendChild(cancelButton);

            // Append the form to the modal
            modal.appendChild(form);

            // Append the modal to the document body
            document.body.appendChild(modal);
        });
    



        li.appendChild(h2);
        li.appendChild(p);
        li.appendChild(p2);
        li.appendChild(p3);
        li.appendChild(p4);
        li.appendChild(del);
        li.appendChild(edit);



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
            
        
