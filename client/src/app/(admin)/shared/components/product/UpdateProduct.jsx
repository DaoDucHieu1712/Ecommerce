import React, { useEffect } from "react";
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
import { useQuery } from "@tanstack/react-query";
import UploadFile from "../../../../../shared/components/form/UploadFile";
import UpdateFile from "../../../../../shared/components/form/UpdateFile";
import ProductService from "../../../../../shared/services/ProductService";

const schema = yup.object({
  name: yup.string().required("Tên không thể để trống !"),
  description: yup.string().required("Mô tả không thể để trống !"),
  price: yup.number().required("Giá tiền không thế để trống !"),
  imageUrl: yup.string().required("Ảnh sản phẩm không thể để trống !"),
  categoryId: yup.number().required("Danh mục không thể để trống !"),
});

const UpdateProduct = ({ item, reload }) => {
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

  useEffect(() => {
    setValue("categoryId", item.categoryId);
  }, []);
  const categoryQuery = useQuery({
    queryKey: ["category-select"],
    queryFn: async () => {
      return CategoryService.GetAll();
    },
  });

  const [open, setOpen] = React.useState(false);

  const handleOpen = () => setOpen(!open);

  const onSubmitHandler = async (data) => {
    if (!data) return;
    await ProductService.Update(item.id, data)
      .then((res) => {
        setOpen(!open);
        toast.success("Chỉnh sửa thành công !!!");
        reset();
        reload();
      })
      .catch((err) => {
        toast.error("Đã có lỗi xảy ra, chỉnh sửa thất bại !!");
      });
  };

  return (
    <>
      <Button
        size="sm"
        onClick={handleOpen}
        variant="outlined"
        className="flex items-center gap-3"
      >
        sửa
      </Button>
      <Dialog open={open} handler={handleOpen}>
        <form className="form" onSubmit={handleSubmit(onSubmitHandler)}>
          <DialogHeader>Chỉnh sửa sản phẩm</DialogHeader>
          <DialogBody className="flex flex-col gap-y-3">
            <div className="w-full">
              <Input
                label="Tên sản phẩm"
                {...register("name")}
                defaultValue={item.name}
              />
              {errors.name && <ErrorText text={errors.name.message} />}
            </div>
            <div className="w-full">
              <Textarea
                label="Mô tả"
                {...register("description")}
                defaultValue={item.description}
              />
              {errors.description && (
                <ErrorText text={errors.description.message} />
              )}
            </div>
            <div className="w-full">
              <UpdateFile
                name="imageUrl"
                setValue={setValue}
                rootUrl={item.imageUrl}
              />
              {errors.imageUrl && <ErrorText text={errors.imageUrl.message} />}
            </div>
            <div className="w-full">
              <Input
                type="number"
                label="Giá tiền"
                {...register("price")}
                defaultValue={item.price}
              />
              {errors.price && <ErrorText text={errors.price.message} />}
            </div>
            <div className="w-full">
              <Select
                label="Danh mục"
                {...register("categoryId")}
                onChange={(e) => setValue("categoryId", e)}
                value={item.categoryId}
              >
                {categoryQuery.data?.map((category) => {
                  return (
                    <Option key={category.id} value={category.id}>
                      {category.name}
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

export default UpdateProduct;
