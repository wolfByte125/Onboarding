import { TextField } from "@mui/material";
import { PencilSquareIcon } from "@heroicons/react/20/solid";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { useUpdateBlogMutation } from "../../../features/api/apiSlice";

export default function EditBlogModal({ blog }) {
  const navigate = useNavigate();

  const [updateBlog, { isLoading }] = useUpdateBlogMutation();

  const [formState, setFormState] = useState({
    id: 0,
    title: "",
    author: "",
    body: "",
  });

  useEffect(() => {
    blog &&
      setFormState({
        id: blog?.id,
        title: blog?.title,
        author: blog?.author,
        body: blog?.body,
      });
  }, [blog]);

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
      ...formState,
    };

    await updateBlog(data)
      .then((res) => {
        res.error && toast.error(res.error?.data?.message);
        if (res.data) {
          res.data && toast.success("Blog Updated.");
          setFormState({
            id: 0,
            title: "",
            author: "",
            body: "",
          });
          navigate("/");
        }
      })
      .catch((err) => toast.error("Data Not Saved"));
  };

  return (
    <div>
      <button
        className="flex btn btn-warning w-full mx-auto items-center"
        onClick={() => window.editBlogModal.showModal()}
      >
        EDIT <PencilSquareIcon className="h-5 w-5" />
      </button>
      <dialog id="editBlogModal" className="modal">
        <form
          method="dialog"
          className="modal-box shadow-2xl align-middle bg-neutral-200 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-50"
        >
          <h1 className="text-xl mb-3 font-bold text-center">UPDATE</h1>
          <div className="mb-2 flex">
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
          <div className="modal-action">
            <button
              disabled={isLoading}
              className="btn btn-warning"
              onClick={onSubmitClick}
            >
              Save
            </button>
            <button className="btn">Cancel</button>
          </div>
        </form>
      </dialog>
    </div>
  );
}
