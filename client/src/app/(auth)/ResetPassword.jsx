import { Button, Input } from "@material-tailwind/react";
import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ErrorText from "../../shared/components/text/ErrorText";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";
const schema = yup.object({
  password: yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Mật khẩu phải chứa ít nhất 1 chữ thường , 1 chữ hoa và 1 ký tự đặc biệt"
    )
    .required("Vui lòng điền mật khẩu !"),
  confirmPassword: yup
    .string()
    .matches(
      /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Mật khẩu phải chứa ít nhất 1 chữ thường , 1 chữ hoa và 1 ký tự đặc biệt"
    )
    .required("Vui lòng điền mật khẩu !"),
});
const ResetPassword = () => {
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const token = searchParams.get("token");
  const email = searchParams.get("email");
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const ResetPasswordHandler = async (data) => {
    data.email = email;
    data.token = token;
    await AuthService.ResetPassword(data)
      .then((res) => {
        toast.success("Đặt lại mật khẩu thành công !");
        navigate("/login");
      })
      .catch((err) => toast.error(err.response.data));
  };

  return (
    <>
      <div className="bg-gray-50">
        <div className="p-2">
          <div className="max-w-md w-full mx-auto mt-8 p-8 bg-white shadow-md rounded-lg">
            <h2 className="mt-6 text-center text-3xl text-gray-600">
              Đặt lại mật khẩu
            </h2>
            <p className="mt-2 text-center text-sm text-gray-400">
              Đặt lại mật khẩu cho tài khoản
            </p>

            <form
              className="mt-8 space-y-6"
              onSubmit={handleSubmit(ResetPasswordHandler)}
            >
              <div>
                <div className="relative w-90">
                  <Input
                    type="password"
                    size="lg"
                    label="Mật khẩu mới"
                    {...register("password")}
                  />
                </div>
              </div>
              <div>
                <div className="relative w-90">
                  <Input
                    type="password"
                    size="lg"
                    label="Nhập lại mật khẩu"
                    {...register("confirmPassword")}
                  />
                </div>
              </div>
              <div>
                <Button type="submit" className="w-full">
                  Đặt Lại Mật Khẩu
                </Button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </>
  );
};

export default ResetPassword;
