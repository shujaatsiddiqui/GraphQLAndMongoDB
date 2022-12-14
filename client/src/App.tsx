import { useState } from "react";
import "./App.css";
import gql from "graphql-tag";
import { useQuery, useSubscription, useMutation } from "@apollo/react-hooks";
import CreateUserInput from "./models/CreateUserInput";
import LoginInput from "./models/LoginInput";
const GET_USERS = gql`
  query {
    users {
      nodes {
        bio
        id
        emailAddress
      }
    }
  }
`;
const CREATE_USERS = gql`
  mutation createUser($input: CreateUserInput!) {
    createUser(createUserInput: $input) {
      user {
        userName
        bio
        profileImageUrl
        profileBannerUrl
        emailAddress
        id
      }
    }
  }
`;
const LOGIN = gql`
  mutation login($input: LoginInput!) {
    login(loginInput: $input) {
      message
      accessToken
      refreshToken
    }
  }
`;
const USER_SUBSCRIPTION = gql`
  subscription {
    subscribeUser {
      id
      userName
      password
      bio
      profileImageUrl
    }
  }
`;
function App() {
  const [bio, setBio] = useState("");
  const [password, setPassword] = useState("");
  const [userName, setUserName] = useState("");
  const [profileBannerUrl, setProfileBannerUrl] = useState("");
  const [emailAddress, setEmailAddress] = useState("");
  const [profileImageUrl, setProfileImageUrl] = useState("");
  const [walletAddress, setWalletAddress] = useState("");
  const [walletType, setWalletType] = useState("");
  const [loginUserName, setloginUserName] = useState("");
  const [loginPassword, setloginPassword] = useState("");

  //const { data } = useQuery(GET_USERS);

  const [adduser, { loading, error }] = useMutation(CREATE_USERS, {
    onCompleted: () => console.log("Add user seccessfully"),
  });
  const [login] = useMutation(LOGIN, {
    onCompleted: (data) => {      
    debugger;
      localStorage.setItem("token", data.login.accessToken);
    },
  });

  const handleLoginUserName = (event: any) => {
    setloginUserName(event.target.value);
  };
  const handleLoginPassword = (event: any) => {
    setloginPassword(event.target.value);
  };
  const handleBio = (event: any) => {
    setBio(event.target.value);
  };
  const handlePassword = (event: any) => {
    setPassword(event.target.value);
  };
  const handleUserName = (event: any) => {
    setUserName(event.target.value);
  };
  const handleProfileBannerUrl = (event: any) => {
    setProfileBannerUrl(event.target.value);
  };
  const handleEmailAddress = (event: any) => {
    setEmailAddress(event.target.value);
  };
  const handleProfileImageUrl = (event: any) => {
    setProfileImageUrl(event.target.value);
  };
  const handleWalletAddress = (event: any) => {
    setWalletAddress(event.target.value);
  };
  const handleWalletType = (event: any) => {
    setWalletType(event.target.value);
  };
  // where id comes from route params -> /post/:id
  function SubscribeUser() {
    debugger;
    const { loading, error, data } = useSubscription(USER_SUBSCRIPTION)

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error!</div>;
    
    console.log(data.subscribeUser.id)

    return (
      <div>
        <h1>{data.subscribeUser.id}</h1>
      </div>
    );
  }
  function handleAddUser() {
    let userInput: CreateUserInput = {
      bio: bio,
      password: password,
      userName: userName,
      profileBannerUrl: profileBannerUrl,
      emailAddress: emailAddress,
      profileImageUrl: profileImageUrl,
      walletAddress: walletAddress,
      walletType: walletType,
    };
    adduser({ variables: { input: userInput } });
  }
  function handleLogin() {
    let loginInput: LoginInput = {
      userName: loginUserName,
      password: loginPassword,
    };
    login({ variables: { input: loginInput } });
  }

  return (
    <>
      <div className="container">
        {
          SubscribeUser()
        }
        <div className="row">
          <div className="col">
            <br></br>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="loginUserName"
                aria-label="loginUserName"
                aria-describedby="basic-addon1"
                onChange={handleLoginUserName}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="loginPassword"
                aria-label="loginPassword"
                aria-describedby="basic-addon1"
                onChange={handleLoginPassword}
              ></input>
            </div>
            <div className="input-group mb-3">
              <button
                type="button"
                className="btn btn-primary form-control"
                onClick={handleLogin}
              >
                Add User
              </button>
            </div>
          </div>
          <div className="col"></div>
          <div className="col">
            <br></br>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="bio"
                aria-label="bio"
                aria-describedby="basic-addon1"
                onChange={handleBio}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="password"
                aria-label="password"
                aria-describedby="basic-addon1"
                onChange={handlePassword}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="userName"
                aria-label="userName"
                aria-describedby="basic-addon1"
                onChange={handleUserName}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="profileBannerUrl"
                aria-label="profileBannerUrl"
                aria-describedby="basic-addon1"
                onChange={handleProfileBannerUrl}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="profileImageUrl"
                aria-label="profileImageUrl"
                aria-describedby="basic-addon1"
                onChange={handleProfileImageUrl}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="emailAddress"
                aria-label="emailAddress"
                aria-describedby="basic-addon1"
                onChange={handleEmailAddress}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="walletAddress"
                aria-label="walletAddress"
                aria-describedby="basic-addon1"
                onChange={handleWalletAddress}
              ></input>
            </div>
            <div className="input-group mb-3">
              <input
                type="text"
                className="form-control"
                placeholder="walletType"
                aria-label="walletType"
                aria-describedby="basic-addon1"
                onChange={handleWalletType}
              ></input>
            </div>
            <div className="input-group mb-3">
              <button
                type="button"
                className="btn btn-primary form-control"
                onClick={handleAddUser}
              >
                Add User
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
export default App;
