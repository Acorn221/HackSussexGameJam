/* eslint-disable jsx-a11y/no-noninteractive-element-interactions */
import { useAuth0 } from '@auth0/auth0-react';
import LoginButton from './auth/LoginButton';
import Logo from '../assets/chair v2_scaled_32x_pngcrushed.png';
import '@/index.css';

const App = () => {
  const {
    user, isAuthenticated, isLoading, logout,
  } = useAuth0();

  return (
    <div className="flex justify-center align-middle h-screen">
      <div className="bg-white text-black m-auto p-10 rounded-xl w-3/4 md:w-1/2 text-center flex flex-col">
        <div className="underline text-5xl flex justify-center align-middle">
          <div className="flex m-auto">
            <img src={Logo} alt="logo" className="h-24 w-24" />
          </div>
          <div className="flex-1 m-auto">
            Rubiks Racer
          </div>
          <div className="flex gap-4 justify-cemter align-middle">
            {
            user && isAuthenticated && (
            <>
              <h2 className="m-auto text-xl">
                {user.name}
              </h2>
              <img
                className="rounded-full h-12 w-12 m-auto"
                src={user.picture}
                alt={user.name}
                onClick={() => logout({ logoutParams: { returnTo: window.location.origin } })}
              />
            </>
            )
        }
          </div>
        </div>
        <div className="flex-1 flex justify-center align-middle flex-col min-h-[30em]">
          {(!isLoading && !isAuthenticated) ? (
            <>
              <p className="m-auto">Please login to continue</p>
              <LoginButton />
            </>
          ) : (
            <div className="m-auto text-3xl">
              INSERT GAME HERE
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default App;
