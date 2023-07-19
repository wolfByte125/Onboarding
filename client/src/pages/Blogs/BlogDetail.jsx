import { Grid, TextField } from "@mui/material";
import {
  TrashIcon,
  BookmarkSquareIcon,
  PencilSquareIcon,
} from "@heroicons/react/20/solid";
import { useNavigate, useParams } from "react-router-dom";
import {
  useGetBlogByIdQuery,
  useDeleteBlogMutation,
} from "../../features/api/apiSlice";
import { toast } from "react-toastify";
import Loading from "../../components/Loading";
import DeleteModal from "../../components/DeleteModal";
import EditBlogModal from "./fragments/EditBlogModal";

export default function BlogDetail() {
  const navigate = useNavigate();
  const { id } = useParams();

  const { data: blogData, isLoading, isError } = useGetBlogByIdQuery(id);

  if (isLoading) {
    return <Loading />;
  }

  return (
    <div>
      <div className="w-3/5 mx-auto my-10">
        <div container spacing={2} className="px-6 py-3">
          <div
            item
            xs={12}
            md={12}
            className="rounded pt-6 p-10 shadow-2xl align-middle bg-neutral-200 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-50 text-white"
          >
            <div className="mb-2 text-center">
              <h1 className=" text-3xl font-extrabold">{blogData?.title}</h1>
            </div>
            <hr className="w-3/4 my-5 mx-auto" />
            <div className="mb-2 flex">
              <p className="font-medium">By {blogData?.author}</p>
            </div>
            <div className="mb-2">
              <p>{blogData?.body}</p>
            </div>
            <div>
              <p>
                Published On - {new Date(blogData?.createdAt).toDateString()}
              </p>
            </div>
          </div>
        </div>
        <div className="mb-2 px-6 flex space-x-2">
          <div className="w-1/2">
            <EditBlogModal blog={blogData} />
          </div>
          <div className="w-1/2">
            <DeleteModal
              api={useDeleteBlogMutation}
              id={blogData?.id}
              title={blogData?.title}
            />
          </div>
        </div>
      </div>
    </div>
  );
}
