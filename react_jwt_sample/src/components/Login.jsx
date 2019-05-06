import React, { useState } from 'react';


const Login = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    let HandleSubmit = function (e) {
        e.preventDefault();
        console.log(username + ' ' + password);
    }

    return    <div className="container">
                <form onSubmit={HandleSubmit}>
                    <h1>Login Page</h1>
                    <div className="text">
                        <label>Username</label>
                        <input type='text' onChange={({ target }) => setUsername(target.value)}></input>
                    </div>
                    <div className="">
                        <label>Password</label>
                        <input type='password' onChange={({ target }) => setPassword(target.value)}></input>
                    </div>
                    <button className="button"type="submit" >sign in </button>
                </form>
            </div>

}

export default Login;