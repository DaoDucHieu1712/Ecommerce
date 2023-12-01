import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
} from "@material-tailwind/react";
import React from "react";
import ProductService from "../../../../../shared/services/ProductService";
import { toast } from "react-toastify";

const DeleteProduct = ({ item, reload }) => {
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const DeleteProductHandler = async () => {
    setOpen(!open);
    await ProductService.Delete(item.id).then(() => {
      toast.success("Xóa thành công !!");
      reload();
    });
  };
  return (
    <>
      <div>
        <Button
          size="sm"
          onClick={handleOpen}
          variant="outlined"
          className="flex items-center gap-3"
        >
          xóa
        </Button>
        <Dialog open={open} handler={handleOpen}>
          <DialogHeader>Xóa Sản Phẩm</DialogHeader>
          <DialogBody>
            Bạn có xác nhận xóa sản phẩm{" "}
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
            <Button variant="gradient" onClick={DeleteProductHandler}>
              <span>Xác nhận</span>
            </Button>
          </DialogFooter>
        </Dialog>
      </div>
    </>
  );
};

export default DeleteProduct;
