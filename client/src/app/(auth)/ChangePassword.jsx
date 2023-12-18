import React, { useState } from "react";
import { set, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ErrorText from "../../shared/components/text/ErrorText";
import { Button, Input } from "@material-tailwind/react";
import { useNavigate } from "react-router-dom";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";
import CookieService from "../../shared/helpers/CookieHelper";

const schema = yup.object({
  email: yup
    .string()
    .email("Email không hợp lệ !")
    .required("Email không thể để trống !"),
  oldPassword: yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Mật khẩu phải chứa ít nhất 1 chữ thường , 1 chữ hoa và 1 ký tự đặc biệt"
    )
    .required("Vui lòng điền mật khẩu cũ !"),
  newPassword: yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Mật khẩu phải chứa ít nhất 1 chữ thường , 1 chữ hoa và 1 ký tự đặc biệt"
    )
    .required("Vui lòng điền mật khẩu mới !"),
  confirmPassword: yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Mật khẩu phải chứa ít nhất 1 chữ thường , 1 chữ hoa và 1 ký tự đặc biệt"
    )
    .required("Vui lòng điền xác nhận mật khẩu !"),
});

const ChangePassword = () => {
  const navigate = useNavigate();
  const [error, setError] = useState();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const ChangePasswordHandler = async (data) => {
    await AuthService.ChangePassword(data)
      .then((res) => {
        toast.success("Đổi mật khẩu thành công !");
        CookieService.removeCookie(process.env.REACT_APP_ECO_TOKEN);
        CookieService.removeCookie("eco_v1_username");
        navigate("/login");
      })
      .catch((err) => {
        setError(err.response.data);
      });
  };

  return (
    <>
      <div className="bg-gray-50">
        <div className="p-2">
          <div className="max-w-md w-full mx-auto mt-8 p-8 bg-white shadow-md rounded-lg">
            <h2 className="mt-6 text-center text-3xl text-gray-600">
              Đổi mật khẩu
            </h2>
            <p className="text-sm text-red-500">{error}</p>
            <form
              className="mt-8 space-y-6"
              onSubmit={handleSubmit(ChangePasswordHandler)}
            >
              <div className="flex flex-col gap-y-6">
                <div className="w-90">
                  <Input size="lg" label="Email" {...register("email")} />
                  {errors.email && <ErrorText text={errors.email.message} />}
                </div>
                <div className="w-90">
                  <Input
                    size="lg"
                    type="password"
                    label="Mật khẩu cũ"
                    {...register("oldPassword")}
                  />
                  {errors.oldPassword && (
                    <ErrorText text={errors.oldPassword.message} />
                  )}
                </div>
                <div className="w-90">
                  <Input
                    size="lg"
                    type="password"
                    label="Mật khẩu mới"
                    {...register("newPassword")}
                  />
                  {errors.newPassword && (
                    <ErrorText text={errors.newPassword.message} />
                  )}
                </div>
                <div className="w-90">
                  <Input
                    size="lg"
                    type="password"
                    label="Xác nhận mật khẩu mới"
                    {...register("confirmPassword")}
                  />
                  {errors.confirmPassword && (
                    <ErrorText text={errors.confirmPassword.message} />
                  )}
                </div>
              </div>
              <div>
                <Button className="w-full" type="submit">
                  Đổi mật khẩu
                </Button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </>
  );
};

export default ChangePassword;
