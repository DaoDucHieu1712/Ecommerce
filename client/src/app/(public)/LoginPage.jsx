import {
  Button,
  Card,
  Checkbox,
  Input,
  Typography,
} from "@material-tailwind/react";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ErrorText from "../../shared/components/text/ErrorText";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";
import CookieService from "../../shared/helpers/CookieHelper";
import dayjs from "dayjs";

const schema = yup.object({
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
});

const LoginPage = () => {
  const [term, setTerm] = useState(false);
  const [error, setError] = useState();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    mode: "onChange",
  });

  const LoginHandler = async (data) => {
    AuthService.Login(data)
      .then((res) => {
        CookieService.saveCookie(
          "eco_v1_username",
          res.userName,
          dayjs().add(7, "day").toDate()
        );
        CookieService.saveCookie(
          process.env.REACT_APP_ECO_TOKEN,
          res.token,
          dayjs().add(7, "day").toDate()
        );
        toast.success("Đăng nhập thành công !!");
        window.location.href = res.redirectUrl;
      })
      .catch((err) => {
        setError(err.response.data);
      });
  };

  return (
    <div className="flex items-center justify-center">
      <Card color="transparent" shadow={false} className="shadow-lg p-10">
        <Typography variant="h4" color="blue-gray">
          Đăng nhập
        </Typography>
        <Typography color="gray" className="mt-1 font-normal">
          Chào bạn đến với Degrey Shop !!
        </Typography>
        <p className="text-red-500 text-sm">{error && error}</p>
        <form
          className="mt-8 mb-2 w-80 max-w-screen-lg sm:w-96"
          onSubmit={handleSubmit(LoginHandler)}
        >
          <div className="mb-1 flex flex-col gap-3">
            <div className="mb-1 flex flex-col gap-6">
              <Typography variant="h6" color="blue-gray" className="-mb-3">
                Email của bạn
              </Typography>
              <Input
                size="lg"
                placeholder="name@mail.com"
                className=" !border-t-blue-gray-200 focus:!border-t-gray-900"
                labelProps={{
                  className: "before:content-none after:content-none",
                }}
                {...register("email")}
              />
              {errors.email && <ErrorText text={errors.email.message} />}
            </div>
            <div className="mb-1 flex flex-col gap-6">
              <Typography variant="h6" color="blue-gray" className="-mb-3">
                Mật khẩu
              </Typography>
              <Input
                type="password"
                size="lg"
                placeholder="********"
                className=" !border-t-blue-gray-200 focus:!border-t-gray-900"
                labelProps={{
                  className: "before:content-none after:content-none",
                }}
                {...register("password")}
              />
              {errors.password && <ErrorText text={errors.password.message} />}
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
          <Button type="submit" className="mt-6" disabled={!term} fullWidth>
            Đăng nhập
          </Button>
          <Typography color="gray" className="mt-4 text-center font-normal">
            Bạn chưa có tài khoản ?{" "}
            <a href="/register" className="font-medium text-blue-500">
              Đăng ký
            </a>
          </Typography>
          <Typography color="gray" className="mt-4 text-center font-normal">
            Bạn không nhớ mật khẩu ?{" "}
            <a href="/forgot-password" className="font-medium text-blue-500">
              Quên mật khẩu
            </a>
          </Typography>
        </form>
      </Card>
    </div>
  );
};

export default LoginPage;
