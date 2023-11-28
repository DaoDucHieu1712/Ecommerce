import React from "react";
import {
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  DialogFooter,
} from "@material-tailwind/react";
import CategoryService from "../../../../../shared/services/CategoryService";
import { toast } from "react-toastify";

const DeleteCategory = ({ item, reload }) => {
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const DeleteCategoryHandler = async () => {
    await CategoryService.Delete(item.id).then((res) => {
      toast.success(`Xóa danh mục ${item.name} thành công !!`);
      reload();
    });
    setOpen(!open);
  };

  return (
    <div>
      <span onClick={handleOpen} className="text-blue-500 cursor-pointer">
        xóa
      </span>
      <Dialog open={open} handler={handleOpen}>
        <DialogHeader>Xóa danh mục</DialogHeader>
        <DialogBody>
          Bạn có xác nhận xóa danh mục{" "}
          <span className="text-lg font-medium">{item.name}</span>
        </DialogBody>
        <DialogFooter>
          <Button
            variant="text"
            color="red"
            onClick={handleOpen}
            className="mr-1"
          >
            <span>Huỷ</span>
          </Button>
          <Button variant="gradient" onClick={DeleteCategoryHandler}>
            <span>Xác nhận</span>
          </Button>
        </DialogFooter>
      </Dialog>
    </div>
  );
};

export default DeleteCategory;
