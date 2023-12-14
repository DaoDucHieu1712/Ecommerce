import React, { useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import CookieService from "../../shared/helpers/CookieHelper";

const UserNav = () => {
  const [showTooltip, setShowTooltip] = useState(false);

  // Inline styles for the tooltip and triangle
  const tooltipStyle = {
    position: "absolute",
    top: "134%",
    left: "-110%",
    transform: "translateX(-50%)",
    width: "300px",
    backgroundColor: "#fff",
    border: "0px solid #ccc",
    borderRadius: "2px",
    boxShadow: "0 2px 4px rgba(0, 0, 0, 0.2)",
    zIndex: "1",
    opacity: showTooltip ? "1" : "0",
    transition: "opacity 0.2s ease-in-out",
  };

  const triangleStyle = {
    content: "",
    position: "absolute",
    top: "-18px",
    left: "82%",
    transform: "translateX(-50%)",
    borderWidth: "10px",
    borderStyle: "solid",
    borderColor: `transparent transparent #fff transparent`,
  };
  //

  const tooltipRef = useRef(null);
  const toggleTooltip = () => {
    setShowTooltip(!showTooltip);
  };

  const LogoutHandler = () => {
    CookieService.removeCookie(process.env.REACT_APP_ECO_TOKEN);
    CookieService.removeCookie("eco_v1_username");
    window.location.href = "/";
  };

  return (
    <div
      className="relative inline-block text-left cursor-pointer"
      ref={tooltipRef}
    >
      <div onClick={toggleTooltip}>
        <img
          className="w-8 h-8 rounded-full"
          src="https://e7.pngegg.com/pngimages/416/62/png-clipart-anonymous-person-login-google-account-computer-icons-user-activity-miscellaneous-computer.png"
          alt="Avatar"
        />
      </div>
      {showTooltip && (
        <div
          style={tooltipStyle}
          className="divide-y divide-gray-100 rounded-lg shadow"
        >
          <div style={triangleStyle} />
          <div className="px-4 py-2 text-sm text-gray-900 dark:text-white w-full">
            <p className="">
              <span className="text-sm text-gray-500"> Chào, </span>{" "}
              {CookieService.getCookie("eco_v1_username")}
            </p>
          </div>
          <ul className="py-2 text-sm text-gray-700 dark:text-gray-200">
            <li>
              <a
                href={`/profile`}
                className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white cursor-pointer"
              >
                Trang cá nhân
              </a>
            </li>
            <li>
              <a
                href="/my-order"
                className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white cursor-pointer"
              >
                Đơn mua của tôi
              </a>
            </li>
            <li>
              <a
                href="/change-password"
                className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white cursor-pointer"
              >
                Đổi mật khẩu
              </a>
            </li>
            <li>
              <a
                onClick={LogoutHandler}
                className="block px-4 py-2 hover:bg-gray-100 dark:hover:bg-gray-600 dark:hover:text-white cursor-pointer"
              >
                Đăng Xuất
              </a>
            </li>
          </ul>
        </div>
      )}
    </div>
  );
};

export default UserNav;
