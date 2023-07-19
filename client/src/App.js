import "./App.css";
import BlogList from "./pages/Blogs/BlogList";
import CreateBlog from "./pages/Blogs/CreateBlog";
import BlogDetail from "./pages/Blogs/BlogDetail";
import NavBar from "./components/layouts/NavBar";
import Box from "@mui/material/Box";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <div className="bg-[url(../public/imgs/blob.svg)] bg-no-repeat bg-fixed bg-cover min-h-screen text-white">
        <NavBar />
        <Box
          component="main"
          sx={{
            flexGrow: 1,
            p: 5,
            paddingTop: 6,
          }}
        >
          <ToastContainer theme="dark" />
          <Routes>
            <Route index element={<BlogList />} />

            <Route path="/new" element={<CreateBlog />} />

            <Route path="/blogs/:id" element={<BlogDetail />} />
          </Routes>
        </Box>
      </div>
    </BrowserRouter>
  );
}

export default App;
