import axios from "axios";


// Creating an object using literals
//https://www.phpied.com/3-ways-to-define-a-javascript-class/
export const AuthenticateService = {
    authenticate
};

function authenticate(user, pass) {
    let data = {
        username: user,
        password: pass
    };
    let url = `${process.env.REACT_APP_API}`;
    axios.post(`${url}/authenticate`,data)
    .then(function(response){
       console.log(response)
    });
}