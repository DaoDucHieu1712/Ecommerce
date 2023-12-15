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
import React, { useEffect } from "react";
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
  sizeId: yup.number(),
  colorId: yup.number(),
  quantity: yup.number().required("Số lượng không thể để trống"),
  unitPrice: yup.number().required("Giá tiền không thể để trống"),
});

const AddInventory = ({ reload }) => {
  const { id } = useParams();

  const colorQuery = useQuery({
    queryKey: ["color-select"],
    queryFn: async () => {
      return ColorService.GetAll();
    },
  });

  const sizeQuery = useQuery({
    queryKey: ["size-select"],
    queryFn: async () => {
      return SizeService.GetAll();
    },
  });

  const {
    reset,
    setValue,
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const onSubmitHandler = async (data) => {
    data.ProductId = id;
    await InventoryService.Create(data)
      .then(() => {
        toast.success("Thêm tồn kho thành công !!");
        reload();
        reset();
      })
      .catch((err) => {
        toast.error(err.response.data);
      });
    setOpen(!open);
  };

  return (
    <>
      <Button size="sm" onClick={handleOpen} variant="gradient">
        Thêm mới
      </Button>
      <Dialog open={open} handler={handleOpen}>
        <form className="form" onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogHeader>Thêm Mới Tồn Kho</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Select
                label="Kích cỡ"
                {...register("sizeId")}
                onChange={(e) => setValue("sizeId", e)}
              >
                {sizeQuery.data?.map((size) => (
                  <Option key={size.id} value={size.id}>
                    {size.sizeName}
                  </Option>
                ))}
              </Select>
              {errors.sizeId && <ErrorText text={errors.sizeId.message} />}
            </div>
            <div className="w-full">
              <Select
                label="Màu sắc"
                {...register("colorId")}
                onChange={(e) => setValue("colorId", e)}
              >
                {colorQuery.data?.map((color) => (
                  <Option key={color.id} value={color.id}>
                    {color.colorName}
                  </Option>
                ))}
              </Select>
              {errors.colorId && <ErrorText text={errors.colorId.message} />}
            </div>
            <div className="w-full">
              <Input type="number" label="Số lượng" {...register("quantity")} />
              {errors.quantity && <ErrorText text={errors.quantity.message} />}
            </div>
            <div className="w-full">
              <Input
                type="number"
                label="Giá tiền"
                {...register("unitPrice")}
              />
              {errors.unitPrice && (
                <ErrorText text={errors.unitPrice.message} />
              )}
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

export default AddInventory;
