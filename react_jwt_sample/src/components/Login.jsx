import React ,{useState} from 'react';


const Login = (props) => {
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");

    let HandleSubmit = function(e){
         e.preventDefault();
         console.log(username + ' ' +password);
    }

    return <form>
                <h1>Login Page</h1>
                <div>
                    <label>Username</label>
                    <input type='text' onChange={({target}) => setUsername(target.value)}></input>
                </div>
                <div>
                    <label>Password</label>
                    <input type='password' onChange={({target}) => setPassword(target.value)}></input>
                </div>
                <button type="submit" onClick={HandleSubmit}>sign in </button>
            </form>
}

export default Login;