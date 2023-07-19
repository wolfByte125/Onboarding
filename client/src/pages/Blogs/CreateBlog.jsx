import { Grid, TextField } from "@mui/material";
import { TrashIcon, BookmarkSquareIcon } from "@heroicons/react/20/solid";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { useCreateBlogMutation } from "../../features/api/apiSlice";
import { toast } from "react-toastify";

export default function CreateBlog() {
  const navigate = useNavigate();

  const [createBlog] = useCreateBlogMutation();

  const [formState, setFormState] = useState({
    id: -1,
    title: "",
    body: "",
    author: "",
  });

  const handleChange = async (event) => {
    event.persist();
    setFormState((prevState) => ({
      ...prevState,
      [event.target.name]: event.target.value,
    }));
  };

  const onSubmitClick = async (event) => {
    event.preventDefault();

    if (!formState.title || !formState.author || !formState.body) {
      toast.error("Please fill required fields");
      return;
    }

    const data = {
      title: formState.title,
      author: formState.author,
      body: formState.body,
    };

    await createBlog(data)
      .then((res) => {
        res.data && toast.success("Blog Published.");
        setFormState((prevState) => ({
          title: "",
          author: "",
          body: "",
        }));
      })
      .catch((err) => toast.error("Data Not Saved"));
  };

  const onDiscardClick = () => {
    setFormState((prevState) => ({
      title: "",
      author: "",
      body: "",
    }));
    navigate("/");
  };

  return (
    <div>
      <div className="w-3/5 mx-auto my-10">
        <Grid container spacing={2} className="px-6 py-3 my-5">
          <Grid
            item
            xs={12}
            md={12}
            className="rounded pt-6 pb-3 px-3 shadow-2xl align-middle bg-neutral-200 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-50 text-neutral-300"
          >
            <div className="my-5 text-2xl text-neutral-900 font-bold text-center">
              New Post
            </div>
            <div className="mb-2">
              <TextField
                type="text"
                label="Title"
                name="title"
                value={formState.title}
                onChange={handleChange}
                fullWidth={true}
                size="small"
                required
              />
            </div>
            <div className="mb-2 flex">
              <TextField
                type="text"
                label="Author"
                name="author"
                value={formState.author}
                onChange={handleChange}
                fullWidth={true}
                size="small"
                required
              />
            </div>
            <div className="mb-2">
              <TextField
                minRows={10}
                multiline={true}
                type="text"
                label="Body"
                name="body"
                value={formState.body}
                onChange={handleChange}
                fullWidth={true}
                size="small"
                required
              />
            </div>
            <div className="mb-2 flex space-x-2">
              <div className="w-1/2">
                <button
                  className="flex btn w-full mx-auto items-center"
                  onClick={onSubmitClick}
                >
                  SAVE <BookmarkSquareIcon className="h-5 w-5" />
                </button>
              </div>
              <div className="w-1/2">
                <button
                  className="flex btn w-full mx-auto items-center"
                  onClick={onDiscardClick}
                >
                  DISCARD <TrashIcon className="h-5 w-5" />
                </button>
              </div>
            </div>
          </Grid>
        </Grid>
      </div>
    </div>
  );
}
