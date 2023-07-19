import { TrashIcon } from "@heroicons/react/20/solid";
import { CgDanger } from "react-icons/cg";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";

export default function DeleteModal({ api, id, title }) {
  const navigate = useNavigate();
  const [deleteData, { isLoading }] = api();

  const onSubmitClick = async (event) => {
    event.preventDefault();
    await deleteData({ id })
      .then((res) => {
        res.error && toast.error(res.error?.data?.message);
        if (res.data) {
          res.data && toast.success("Deleted Successfully.");
          navigate("/");
        }
      })
      .catch((err) => toast.error("Data Not Saved"));
  };

  return (
    <div>
      <button
        className="flex btn btn-error w-full mx-auto items-center"
        onClick={() => window.deleteModal.showModal()}
      >
        DELETE <TrashIcon className="h-5 w-5" />
      </button>
      <dialog id="deleteModal" className="modal">
        <form
          method="dialog"
          className="modal-box shadow-2xl align-middle bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-70"
        >
          <CgDanger className="h-10 w-10 text-error mx-auto mb-2" />
          <p className="py-2 text-center">
            Are you sure you want to delete {title ? `"${title}"` : "this post"}
            ?
          </p>
          <div className="modal-action">
            <button
              disabled={isLoading}
              className="btn btn-error"
              onClick={onSubmitClick}
            >
              Yes
            </button>
            <button className="btn btn-active btn-ghost">No</button>
          </div>
        </form>
      </dialog>
    </div>
  );
}
