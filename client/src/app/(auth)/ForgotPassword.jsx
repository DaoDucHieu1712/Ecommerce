import { Button, Input } from "@material-tailwind/react";
import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";
import ErrorText from "../../shared/components/text/ErrorText";
const schema = yup.object({
  email: yup
    .string()
    .email("Email không hợp lệ !")
    .required("Email không thể để trống !"),
});
const ForgotPassword = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const ForgotPasswordHandler = async (data) => {
    await AuthService.ForgetPassword(data.email)
      .then((res) => {
        toast.success("Link đặt lại mật khẩu đã được gửi về email của bạn !");
      })
      .catch((err) => toast.error(err.response.data));
  };

  return (
    <>
      <div className="bg-gray-50">
        <div className="p-2">
          <div className="max-w-md w-full mx-auto mt-8 p-8 bg-white shadow-md rounded-lg">
            <h2 className="mt-6 text-center text-3xl text-gray-600">
              Quên mật khẩu
            </h2>
            <p className="mt-2 text-center text-sm text-gray-400">
              Nhập email để đặt lại mật khẩu
            </p>
            <form
              className="mt-8 space-y-6"
              onSubmit={handleSubmit(ForgotPasswordHandler)}
            >
              <div>
                <div className="w-90">
                  <Input size="lg" label="Email" {...register("email")} />
                  {errors.email && <ErrorText text={errors.email.message} />}
                </div>
              </div>
              <div>
                <Button className="w-full" type="submit">
                  Gửi mã
                </Button>
              </div>
            </form>
            <div className="mt-4 text-center">
              <p className="text-sm text-gray-600">
                Đã có tài khoản?{" "}
                <a href="/login" className="text-blue-600">
                  Đăng nhập
                </a>
              </p>
              <p className="text-sm text-gray-600">
                Chưa có tài khoản?{" "}
                <a href="/register" className="text-blue-600">
                  Đăng ký
                </a>
              </p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default ForgotPassword;
