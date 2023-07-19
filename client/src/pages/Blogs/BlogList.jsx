import { AddOutlined } from "@mui/icons-material";
import { Grid } from "@mui/material";
import BlogCard from "./fragments/BlogCard";
import { useNavigate } from "react-router-dom";
import { useGetBlogsQuery } from "../../features/api/apiSlice";

export default function BlogList() {
  const navigate = useNavigate();

  const blogs = useGetBlogsQuery();

  return (
    <div className="px-16 py-5">
      <Grid container spacing={2}>
        <Grid item xs={12} md={12}>
          <button
            className="flex btn w-3/4 mx-auto btn-primary shadow-2xl align-middlebg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-60 border-none"
            onClick={() => navigate("/new")}
          >
            Create Blog <AddOutlined />
          </button>
        </Grid>
        <Grid item xs={12} md={12}>
          {blogs?.data?.map((blog) => (
            <BlogCard key={blog?.id} blog={blog} />
          ))}
        </Grid>
      </Grid>
    </div>
  );
}
