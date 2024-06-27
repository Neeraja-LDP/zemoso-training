// Define a function that will be used as a parameter
function greet(name) {
    return `Hello, ${name}!`;
}

// Define another function that takes a function and a value as parameters
function processGreeting(func, value) {
    // Call the passed-in function with the value and return the result
    return func(value);
}

// Call the processGreeting function with the greet function and a name as arguments
let message = processGreeting(greet, 'Neeraja');

// Log the result to the console
console.log(message); // Output: Hello, Neeraja!