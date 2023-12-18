import { yupResolver } from "@hookform/resolvers/yup";
import {
  Button,
  Card,
  Input,
  Radio,
  Typography,
} from "@material-tailwind/react";
import React from "react";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import ErrorText from "../../shared/components/text/ErrorText";
import useCurrentUser from "../../shared/hooks/useCurrentUser";

const schema = yup.object({
  firstName: yup.string().required("Họ không thể để trống !!"),
  lastName: yup.string().required("Tên không thể để trống !!"),
  phoneNumber: yup.string().required("Số điện thoại không thể để trống !"),
  birthDay: yup.date().required("Ngày sinh không thể để trống !!"),
  gender: yup.boolean().required("Giới tính không thể để trống !"),
});

const ProfilePage = () => {
  const { user } = useCurrentUser();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const UpdateProfileHandler = async () => {};

  return (
    <div className="flex items-center justify-center">
      <Card color="transparent" shadow={false} className="p-10">
        <Typography variant="h4" color="blue-gray">
          Trang cá nhân
        </Typography>
        <Typography color="gray" className="mt-1 font-normal">
          Thông tin của tôi
        </Typography>
        {/* <p className="text-sm text-red-500">{error && error}</p> */}
        <form
          className="mt-8 mb-2"
          onSubmit={handleSubmit(UpdateProfileHandler)}
        >
          <div className="mb-1 flex flex-col gap-6">
            <div className="flex gap-x-2">
              <div className="div">
                <Input
                  size="md"
                  label="Họ"
                  defaultValue={user?.firstName}
                  {...register("firstName")}
                />
                {errors.firstName && (
                  <ErrorText text={errors.firstName.message} />
                )}
              </div>
              <div className="">
                <Input
                  size="md"
                  label="Tên"
                  defaultValue={user?.lastName}
                  {...register("lastName")}
                />
                {errors.lastName && (
                  <ErrorText text={errors.lastName.message} />
                )}
              </div>
            </div>
            <div className="flex gap-10">
              <Radio
                name="type"
                label="Nam"
                value={true}
                defaultChecked={user?.gender === true}
                {...register("gender")}
              />
              <Radio
                name="type"
                label="Nữ"
                value={false}
                defaultChecked={user?.gender === false}
                {...register("gender")}
              />
              {errors.gender && <ErrorText text={errors.gender.message} />}
            </div>
            <div className="div">
              <Input
                type="date"
                size="md"
                label="Ngày sinh"
                defaultValue={user?.birthDay}
                {...register("birthDay")}
              />
              {errors.birthDay && <ErrorText text={errors.birthDay.message} />}
            </div>
            <div className="div">
              <Input
                type="text"
                size="md"
                label="Số điện thoại"
                className=""
                {...register("phoneNumber")}
                defaultValue={user?.phoneNumber}
              />
              {errors.phoneNumber && (
                <ErrorText text={errors.phoneNumber.message} />
              )}
            </div>
          </div>
          <Button type="submit" className="mt-6" fullWidth>
            Cập nhật
          </Button>
        </form>
      </Card>
    </div>
  );
};

export default ProfilePage;
