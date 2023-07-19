import { useNavigate } from "react-router-dom";

export default function NavBar() {
  const navigate = useNavigate();
  return (
    <div className="py-3 px-10 z-50 flex justify-between shadow-2xl items-center bg-neutral-800 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-70 text-neutral-300 fixed min-w-full">
      <div
        className="text-2xl flex font-mono cursor-pointer"
        onClick={() => navigate("/")}
      >
        <div>blogger</div>
        <div className="animate-pulse">|</div>
      </div>
    </div>
  );
}
