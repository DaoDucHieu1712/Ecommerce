import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import AuthService from "../../shared/services/AuthService";
import { toast } from "react-toastify";

const ConfirmEmail = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const searchParams = new URLSearchParams(location.search);
  const userId = searchParams.get("userId");
  const token = searchParams.get("token");

  const handleConfirmEmail = async () => {
    AuthService.ConfirmEmail(userId, token)
      .then((res) => {
        toast.success("Xác nhận email thành công !");
      })
      .catch((err) => toast.error(err.response.data));
  };

  return (
    <div className="my-10">
      <h1 className="uppercase text-lg">Xác nhận email</h1>
      <p className="text-blue-500 cursor-pointer" onClick={handleConfirmEmail}>
        click here !
      </p>
    </div>
  );
};

export default ConfirmEmail;
