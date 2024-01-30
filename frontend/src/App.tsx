/* eslint-disable import/order */
/* eslint-disable jsx-a11y/no-noninteractive-element-interactions */
import LoginButton from "./auth/LoginButton";
import Logo from "../assets/chair v2_scaled_32x_pngcrushed.png";
import "@/index.css";
import React, { useState } from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

const App = () => {
  const [score, setScore] = useState(0);

  const { unityProvider } = useUnityContext({
    loaderUrl: "game/build/myunityapp.loader.js",
    dataUrl: "game/build/myunityapp.data",
    frameworkUrl: "game/build/myunityapp.framework.js",
    codeUrl: "game/build/myunityapp.wasm",
  });

  return (
    <div className="flex justify-center align-middle h-screen">
      <div className="bg-white text-black m-auto p-10 rounded-xl w-2/3 text-center flex flex-col bg-opacity-80 gap-2">
        <div className="underline text-5xl flex justify-center align-middle">
          <div className="flex m-auto">
            <img src={Logo} alt="logo" className="h-24 w-24" />
          </div>
          <div className="flex-1 m-auto">Rubiks Racer</div>
        </div>
        <div className="flex-1 flex justify-center align-middle flex-col min-h-[30em]">
          <iframe
            src="/game/index.html"
            title="game"
            className="flex-1 overflow-hidden"
            scrolling="no"
          />
        </div>
      </div>
    </div>
  );
};

export default App;
