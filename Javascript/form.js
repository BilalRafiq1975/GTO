
document.getElementById("Form").addEventListener("submit", function(event){
    event.preventDefault();

    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let email = document.getElementById("email").value;
    let address = document.getElementById("address").value;
    let age = document.getElementById("age").value;
    let gender = document.querySelector('input[name="gender"]:checked')?.value || "Not specified";
    
    
    let hobbies = [];
    document.querySelectorAll('input[name="hobbies"]:checked').forEach((checkbox) => {
        hobbies.push(checkbox.value);
    });

    document.getElementById("cardName").textContent = `${firstName} ${lastName}`;
    document.getElementById("cardEmail").textContent = email;
    document.getElementById("cardAddress").textContent = address;
    document.getElementById("cardAge").textContent = age;
    document.getElementById("cardGender").textContent = gender;
    document.getElementById("cardHobbies").textContent = hobbies.length > 0 ? hobbies.join(", ") : "None";
});