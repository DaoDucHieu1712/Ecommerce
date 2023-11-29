import React from "react";
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
  Textarea,
} from "@material-tailwind/react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import ErrorText from "../../../../../shared/components/text/ErrorText";
import CategoryService from "../../../../../shared/services/CategoryService";
import { toast } from "react-toastify";
import UploadFile from "../../../../../shared/components/form/UploadFile";
import { useQuery } from "@tanstack/react-query";
import ProductService from "../../../../../shared/services/ProductService";

const schema = yup.object({
  name: yup.string().required("Tên không thể để trống !"),
  description: yup.string().required("Mô tả không thể để trống !"),
  price: yup.number().required("Giá tiền không thế để trống !"),
  imageUrl: yup.string().required("Ảnh sản phẩm không thể để trống !"),
  categoryId: yup.string().required("Danh mục không thể để trống !"),
});

const AddProduct = ({ onReload }) => {
  const {
    reset,
    register,
    setValue,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const categoryQuery = useQuery({
    queryKey: ["category-select"],
    queryFn: async () => {
      return CategoryService.GetAll();
    },
  });

  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const onSubmitHandler = async (data) => {
    await ProductService.Create(data)
      .then((res) => {
        toast.success("Thêm sản phẩm mới thành công !!");
        onReload();
        setOpen(!open);
      })
      .catch((err) => {
        toast.error("Thêm sản phẩm mới thất bại !!");
      });
  };

  return (
    <>
      <Button
        size="sm"
        onClick={handleOpen}
        variant="gradient"
        className="flex items-center gap-3"
      >
        Thêm mới
      </Button>
      <Dialog open={open} handler={handleOpen}>
        <form className="form" onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogHeader>Thêm Mới Sản Phẩm</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Input label="Tên sản phẩm" {...register("name")} />
              {errors.name && <ErrorText text={errors.name.message} />}
            </div>
            <div className="w-full">
              <Textarea label="Mô tả" {...register("description")} />
              {errors.description && (
                <ErrorText text={errors.description.message} />
              )}
            </div>
            <div className="w-full">
              <UploadFile name="imageUrl" setValue={setValue} />
              {errors.imageUrl && <ErrorText text={errors.imageUrl.message} />}
            </div>
            <div className="w-full">
              <Input type="number" label="Giá tiền" {...register("price")} />
              {errors.price && <ErrorText text={errors.price.message} />}
            </div>
            <div className="w-full">
              <Select
                label="Category"
                {...register("categoryId")}
                onChange={(e) => setValue("categoryId", e)}
              >
                {categoryQuery.data?.map((item) => {
                  return (
                    <Option key={item.id} value={item.id}>
                      {item.name}
                    </Option>
                  );
                })}
              </Select>
              {errors.categoryId && (
                <ErrorText text={errors.categoryId.message} />
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

export default AddProduct;
