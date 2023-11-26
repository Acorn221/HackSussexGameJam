import { useAuth0 } from '@auth0/auth0-react';

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0();

  return <button className="btn bg-purple-700 text-white text-2xl hover:bg-purple-800 hover:scale-105" onClick={() => loginWithRedirect()}>Log In</button>;
};

export default LoginButton;
