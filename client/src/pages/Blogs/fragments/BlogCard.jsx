import { Button } from "@mui/material";
import { PencilSquareIcon, TrashIcon } from "@heroicons/react/20/solid";
import { useNavigate } from "react-router-dom";

export default function BlogCard({ blog }) {
  console.log(blog);
  const { id, title, author, body, updatedAt } = blog;
  const navigate = useNavigate();

  return (
    <div
      onClick={() => navigate(`/blogs/${id}`)}
      className="rounded w-3/4 mx-auto pt-6 pb-3 mb-4 px-3 shadow-2xl align-middle bg-neutral-200 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-50 text-white cursor-pointer"
    >
      <div className="text-xl font-bold">{title}</div>
      <div>
        <div className="py-3">
          {body.length > 150 ? body.substring(0, 150) + "..." : body}
        </div>
        <div className="flex justify-between items-center">
          <div>By {author}</div>
          <div className="font-light text-sm">
            {new Date(updatedAt).toDateString()}
          </div>
        </div>
      </div>
    </div>
  );
}
