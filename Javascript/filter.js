const person = [
    {id:1, name: "Bilal", email : "Bilal.q@dplit.com", age : 23},
    {id:2, name: "Ali", email : "Ali.q@dplit.com", age : 20},
    {id:3, name: "Ahmed", email : "Ahmed.q@dplit.com", age : 25},
    {id:4, name: "Rafiq", email : "Rafiq.q@dplit.com", age : 53},
    {id:5, name: "Usama", email : "Usama.q@dplit.com", age : 28}
    ];
    
    const FindPerson = person.filter(getPerson => getPerson.name === "Bilal");
    const findMultiplePerson = () => {
        const searchName = prompt("Enter name to search:");
        const foundPersons = person.filter(getPerson => getPerson.name.toLowerCase().includes(searchName.toLowerCase()));
        return foundPersons;
    };

    // Get search results from user input
    FindPerson = findMultiplePerson();
    if(FindPerson.length > 0){
        console.log(FindPerson);
    } 
    else{
        console.log("Not found");
    }
    





