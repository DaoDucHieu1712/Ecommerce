import React from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import ErrorText from "../../../../../shared/components/text/ErrorText";
import DiscountService from "../../../../../shared/services/DiscountService";
import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
  Input,
} from "@material-tailwind/react";
import { toast } from "react-toastify";

const schema = yup.object({
  code: yup.string().required("Mã giảm giá không thể để trống !"),
  quantity: yup.number().required("Số lượng không thể để trống !"),
  percent: yup.number().required("Phần trăm giảm giá không thể để trống !"),
  expire: yup.date().required("Hạn sử dụng không thể để trống !"),
});

const UpdateDiscount = ({ item, reload }) => {
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(!open);

  const {
    reset,
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const onSubmitHandler = async (data) => {
    data.isPublic = true;
    await DiscountService.Update(item.id, data)
      .then(() => {
        reload();
        reset();
        toast.success("Chỉnh sửa thành công !!");
        setOpen(!open);
      })
      .catch((err) => toast.error(err.response.data));
  };

  return (
    <>
      <Button size="sm" onClick={handleOpen} variant="gradient">
        sửa
      </Button>
      <Dialog open={open} handler={handleOpen}>
        <form className="form" onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogHeader>Chỉnh sửa mã giảm giá</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Input
                label="Mã giảm giá"
                {...register("code")}
                defaultValue={item.code}
              />
              {errors.code && <ErrorText text={errors.code.message} />}
            </div>
            <div className="w-full">
              <Input
                label="Số lượng"
                type="number"
                {...register("quantity")}
                defaultValue={item.quantity}
              />
              {errors.quantity && <ErrorText text={errors.quantity.message} />}
            </div>
            <div className="w-full">
              <Input
                label="Phần trăm giảm giá"
                type="number"
                defaultValue={item.percent}
                {...register("percent")}
              />
              {errors.percent && <ErrorText text={errors.percent.message} />}
            </div>
            <div className="w-full">
              <Input
                label="Ngày hết hạn"
                type="datetime-local"
                defaultValue={item.expire}
                {...register("expire")}
              />
              {errors.expire && <ErrorText text={errors.expire.message} />}
            </div>
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
            <Button type="submit" variant="gradient">
              <span>Xác nhận</span>
            </Button>
          </DialogFooter>
        </form>
      </Dialog>
    </>
  );
};

export default UpdateDiscount;
