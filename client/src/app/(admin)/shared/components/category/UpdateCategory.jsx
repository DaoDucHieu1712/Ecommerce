import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
  Input,
} from "@material-tailwind/react";
import React from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import ErrorText from "../../../../../shared/components/text/ErrorText";
import CategoryService from "../../../../../shared/services/CategoryService";
import { toast } from "react-toastify";

const schema = yup.object({
  name: yup.string().required("Tên không thể để trống !"),
  description: yup.string().required("Mô tả không thể để trống !"),
});

const UpdateCategory = ({ item, reload }) => {
  const {
    reset,
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
    console.log(data);
    await CategoryService.Update(item.id, data)
      .then(() => {
        toast.success("Chỉnh sửa danh mục thành công !!");
        reload();
        reset();
      })
      .catch(() => {
        toast.error("Chỉnh sửa danh mục thất bại !!");
      });
    setOpen(!open);
  };

  return (
    <>
      <span
        size="sm"
        onClick={handleOpen}
        className="text-blue-500 cursor-pointer"
      >
        chỉnh sửa
      </span>
      <Dialog open={open} handler={handleOpen}>
        <form className="form" onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogHeader>Chỉnh sửa danh mục</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Input
                label="Tên danh mục"
                {...register("name")}
                defaultValue={item.name}
              />
              {errors.name && <ErrorText text={errors.name.message} />}
            </div>
            <div className="w-full">
              <Input
                label="Mô tả"
                {...register("description")}
                defaultValue={item.description}
              />
              {errors.description && (
                <ErrorText text={errors.description.message} />
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

export default UpdateCategory;
