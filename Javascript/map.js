const person = [
    {id:1, name: "Bilal", email : "Bilal.q@dplit.com", age : 23},
    {id:2, name: "Ali", email : "Ali.q@dplit.com", age : 18},
    {id:3, name: "Ahmed", email : "Ahmed.q@dplit.com", age : 25},
    {id:4, name: "Rafiq", email : "Rafiq.q@dplit.com", age : 53},
    {id:5, name: "Usama", email : "Usama.q@dplit.com", age : 6}
    ];

//    const MuliplyAge = person.map(person => person.age * 2);
    
  //      console.log(MuliplyAge);



const addCategory = person.map(person => ({
    ...person,
    category: person.age === 18 ? "adult" :
    person.age < 18 ? "child" :
    person.age > 50 ? "aged" : "adult"
}));
    
console.log(addCategory);
    





