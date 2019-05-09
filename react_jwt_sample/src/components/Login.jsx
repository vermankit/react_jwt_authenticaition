import React, { useState } from 'react';
import '../styles/login.css';

const Login = (props) => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    let HandleSubmit = function (e) {
        e.preventDefault();
        console.log(username + ' ' + password);
    }

    return <div className="login-box">
        <form onSubmit={HandleSubmit}>
            <h2>Sign in</h2>
            <div className="text-box">
                <i className="fa fa-user"></i>
                <input type='text' placeholder="Username" onChange={({ target }) => setUsername(target.value)}></input>
            </div>
            <div className="text-box">
                <i className="fa fa-lock" />
                <input type='password' placeholder="Password" onChange={({ target }) => setPassword(target.value)}></input>
            </div>
            <button className="button" type="submit" >Sign in </button>
        </form>
    </div>

}

export default Login;