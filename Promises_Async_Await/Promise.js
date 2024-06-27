/**
*
* Assume we are fetching the data from a rest endpoint in the get data function.
* we can simulate the same by replacing the setTimeout with fetch api and executing the same in a browser.
*
*/

function getData(uId) {
    return new Promise(function (resolve, reject) {
        setTimeout(() => {
            console.log("Fetched the data!");
            resolve("skc@gmail.com");
        }, 4000);
    })
}

console.log("start");

let promise = getData("skc");
promise.then(
    email => { console.log("Email id of the user id is: " + email); console.log("end"); }
);