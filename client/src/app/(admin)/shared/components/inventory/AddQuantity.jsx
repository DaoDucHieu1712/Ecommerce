import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
  Input,
  Option,
  Select,
} from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import ErrorText from "../../../../../shared/components/text/ErrorText";
import { toast } from "react-toastify";
import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import ColorService from "../../../../../shared/services/ColorService";
import SizeService from "../../../../../shared/services/SizeService";
import InventoryService from "../../../../../shared/services/InventoryService";

const schema = yup.object({
  sizeId: yup.number().required("Kích cỡ không thể để trống !"),
  colorId: yup.number().required("Màu sắc không thể để trống !"),
  quantity: yup.number().required("Số lượng không thể để trống"),
  unitPrice: yup.number().required("Giá tiền không thể để trống"),
});
const AddQuantity = ({ item, reload }) => {
  const [open, setOpen] = React.useState(false);
  const [quantity, setQuantity] = useState();
  const handleOpen = () => setOpen(!open);
  const handlerUpdateQuantity = async () => {
    await InventoryService.AddQuantity(item.id, quantity)
      .then(() => {
        toast.success("Thêm số lượng thành công !!");
        reload();
      })
      .catch((err) => {
        toast.error(err.response.data);
      });
    setOpen(!open);
  };
  return (
    <>
      <span
        className="text-blue-500 text-xs cursor-pointer"
        onClick={handleOpen}
      >
        nhập kho
      </span>
      <Dialog open={open} handler={handleOpen}>
        <DialogHeader>Thêm số lượng</DialogHeader>
        <DialogBody className="flex flex-col gap-y-3">
          <Input
            min="1"
            type="number"
            label="Nhập số lượng cần thêm .."
            onChange={(e) => setQuantity(e.target.value)}
          />
        </DialogBody>
        <DialogFooter>
          <Button
            variant="text"
            color="red"
            onClick={handleOpen}
            className="mr-1"
          >
            <span>Hủy</span>
          </Button>
          <Button
            type="submit"
            variant="gradient"
            onClick={handlerUpdateQuantity}
          >
            <span>Xác nhận</span>
          </Button>
        </DialogFooter>
      </Dialog>
    </>
  );
};

export default AddQuantity;
