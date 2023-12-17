import React from "react";
import {
  Button,
  Dialog,
  DialogHeader,
  DialogBody,
  DialogFooter,
} from "@material-tailwind/react";
import DiscountService from "../../../../../shared/services/CategoryService";
import { toast } from "react-toastify";

const DeleteDiscount = ({ item, reload }) => {
  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const DeleteDiscountHandler = async () => {
    await DiscountService.Delete(item.id).then((res) => {
      toast.success(`Xóa mã ${item.code} thành công !!`);
      reload();
    });
    setOpen(!open);
  };

  return (
    <div>
      <Button onClick={handleOpen}>xóa</Button>
      <Dialog open={open} handler={handleOpen}>
        <DialogHeader>Xóa mã giảm giá</DialogHeader>
        <DialogBody>
          Bạn có xác nhận xóa mã{" "}
          <span className="text-lg font-medium">{item.code}</span>
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
          <Button variant="gradient" onClick={DeleteDiscountHandler}>
            <span>Xác nhận</span>
          </Button>
        </DialogFooter>
      </Dialog>
    </div>
  );
};

export default DeleteDiscount;
