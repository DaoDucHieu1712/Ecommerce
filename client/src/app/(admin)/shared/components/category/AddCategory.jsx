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

const AddCategory = ({ reload }) => {
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
    await CategoryService.Create(data)
      .then(() => {
        toast.success("Thêm mới danh mục thành công !!");
        reload();
        reset();
      })
      .catch(() => {
        toast.error("Thêm mới danh mục thất bại !!");
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
          <DialogHeader>Thêm mới danh mục</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Input label="Tên danh mục" {...register("name")} />
              {errors.name && <ErrorText text={errors.name.message} />}
            </div>
            <div className="w-full">
              <Input label="Mô tả" {...register("description")} />
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

export default AddCategory;
