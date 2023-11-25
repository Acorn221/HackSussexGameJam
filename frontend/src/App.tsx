import { useAuth0 } from '@auth0/auth0-react';
import LoginButton from './auth/LoginButton';
import '@/index.css';

const App = () => {
  const { user, isAuthenticated, isLoading } = useAuth0();

  return (
    <div className="flex justify-center align-middle h-screen">
      <div className="bg-white text-black m-auto p-10 rounded-xl w-3/4 md:w-1/2 text-center flex flex-col">
        <div className="flex-auto flex align-middle">
          <div className="flex-1" />
          <div className="flex gap-4 justify-cemter align-middle">
            {
          (!isLoading && !isAuthenticated) && (
          <>
            <p className="m-auto">Please login to continue</p>
            <LoginButton />
          </>
          ) || user && isAuthenticated && (
            <>
              <h2 className="m-auto">
                Hi
                {' '}
                {user.name}
              </h2>
              <img className="rounded-full h-12 w-12" src={user.picture} alt={user.name} />
            </>
          )
        }
          </div>
        </div>
        <div className="underline text-5xl">Retro Rubiks</div>
        <div className="flex-1 flex justify-center align-middle flex-col min-h-[30em]">
          <div className="m-auto text-3xl">
            INSERT GAME HERE
          </div>
        </div>
      </div>
    </div>
  );
};

export default App;
