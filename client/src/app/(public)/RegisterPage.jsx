import {
  Button,
  Card,
  Checkbox,
  Input,
  Radio,
  Typography,
} from "@material-tailwind/react";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ErrorText from "../../shared/components/text/ErrorText";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";

const schema = yup.object({
  firstName: yup.string().required("Họ không thể để trống !!"),
  lastName: yup.string().required("Tên không thể để trống !!"),
  phoneNumber: yup.string().required("Số điện thoại không thể để trống !"),
  birthDay: yup.date().required("Ngày sinh không thể để trống !!"),
  gender: yup.boolean().required("Giới tính không thể để trống !"),
  email: yup
    .string()
    .email("Email không hợp lệ !")
    .required("Email không thể để trống !"),
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
    .required("Vui lòng điền xác nhận mật khẩu !"),
});

const RegisterPage = () => {
  const [error, setError] = useState();
  const [term, setTerm] = useState(false);
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const RegisterHandler = async (data) => {
    AuthService.Register(data)
      .then((res) => {
        navigate("/login");
        toast.success("Đăng ký thành công !!");
      })
      .catch((err) => {
        setError(err.response.data);
        toast.error(err.response.data);
      });
  };

  return (
    <div className="flex items-center justify-center">
      <Card color="transparent" shadow={false} className="shadow-lg p-10">
        <Typography variant="h4" color="blue-gray">
          Đăng ký !
        </Typography>
        <Typography color="gray" className="mt-1 font-normal">
          Chào bạn đến với Degrey Shop !!
        </Typography>
        <p className="text-sm text-red-500">{error && error}</p>
        <form className="mt-8 mb-2" onSubmit={handleSubmit(RegisterHandler)}>
          <div className="mb-1 flex flex-col gap-6">
            <div className="flex gap-x-2">
              <div className="div">
                <Input
                  size="md"
                  label="Họ"
                  className=""
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
                  className=""
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
                {...register("gender")}
                defaultChecked
              />
              <Radio
                name="type"
                label="Nữ"
                value={false}
                {...register("gender")}
              />
              {errors.gender && <ErrorText text={errors.gender.message} />}
            </div>
            <div className="div">
              <Input
                type="date"
                size="md"
                label="Ngày sinh"
                className=""
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
              />
              {errors.phoneNumber && (
                <ErrorText text={errors.phoneNumber.message} />
              )}
            </div>
            <div className="div">
              <Input
                size="md"
                label="Email"
                className=""
                {...register("email")}
              />
              {errors.email && <ErrorText text={errors.email.message} />}
            </div>
            <div className="div">
              <Input
                label="Mật khẩu"
                type="password"
                size="md"
                className=""
                {...register("password")}
              />
              {errors.password && <ErrorText text={errors.password.message} />}
            </div>
            <div className="div">
              <Input
                label="Xác nhận mật khẩu"
                type="password"
                size="md"
                className=""
                {...register("confirmPassword")}
              />
              {errors.confirmPassword && (
                <ErrorText text={errors.confirmPassword.message} />
              )}
            </div>
          </div>
          <Checkbox
            label={
              <Typography
                variant="small"
                color="gray"
                className="flex items-center font-normal"
              >
                Bạn đồng ý
                <p className="font-medium transition-colors hover:text-gray-900">
                  &nbsp;với điều khoản của chúng tôi !
                </p>
              </Typography>
            }
            containerProps={{ className: "-ml-2.5" }}
            onClick={() => setTerm(!term)}
          />
          <Button type="submit" disabled={!term} className="mt-6" fullWidth>
            Đăng ký
          </Button>
          <Typography color="gray" className="mt-4 text-center font-normal">
            Bạn đã có tài khoản ?{" "}
            <a href="/login" className="font-medium text-blue-500">
              Đăng nhập
            </a>
          </Typography>
        </form>
      </Card>
    </div>
  );
};

export default RegisterPage;
