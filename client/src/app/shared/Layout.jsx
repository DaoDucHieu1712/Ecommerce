import React from "react";
import { Link, NavLink, Outlet } from "react-router-dom";
import Logo from "../../assets/DegreyLogo.webp";
import CookieService from "../../shared/helpers/CookieHelper";
import UserNav from "./UserNav";
const MenuLink = [
  {
    name: "Trang chủ",
    path: "/",
  },
  {
    name: "Store",
    path: "/shop",
  },
  {
    name: "Giới thiệu",
    path: "/about",
  },
];

const Layout = () => {
  return (
    <>
      <header className="header shadow-md">
        <div className="container mx-auto">
          <div className="grid grid-cols-3">
            <div className="flex items-center justify-between gap-x-3">
              <Link to="/">
                <img src={Logo} alt="logo" className="w-[120px]" />
              </Link>
            </div>
            <div className="flex items-center justify-between">
              {MenuLink.map((item) => {
                return (
                  <NavLink
                    key={item.path}
                    to={item.path}
                    className={({ isActive }) =>
                      `font-medium border-b-2 ${
                        isActive ? "border-blue-gray-900" : "border-none"
                      } py-6`
                    }
                  >
                    {item.name}
                  </NavLink>
                );
              })}
              <NavLink
                to="/cart"
                className={({ isActive }) =>
                  `font-medium border-b-2 ${
                    isActive ? "border-blue-gray-900" : "border-none"
                  } py-6`
                }
              >
                Giỏ hàng(9)
              </NavLink>
            </div>
            <div className="flex justify-end items-center gap-x-3">
              {CookieService.getCookie(process.env.REACT_APP_ECO_TOKEN) ? (
                <UserNav />
              ) : (
                <>
                  <Link to="/login">Đăng nhập</Link>
                  <span>/</span>
                  <Link to="/register">Đăng ký</Link>
                </>
              )}
            </div>
          </div>
        </div>
      </header>
      <section className="container mx-auto my-10">
        <Outlet></Outlet>
      </section>
      <footer className="footer bg-black text-white p-4">
        <div className="container mx-auto py-6">
          <div className="grid grid-cols-4 gap-x-6">
            <div className="flex flex-col gap-y-7">
              <div class="footer-header">
                <h1 className="text-gray-500 uppercase text-xl font-bold">
                  Degrey
                </h1>
              </div>
              <p>
                Cái tên Degrey được tạo ra rất ngẫu hứng, xuất phát từ “Chuỗi
                ngày u buồn về sự nghiệp, tương lai trong quá khứ của chính
                mình” – theo lời chia sẻ của Degrey’s founder.
              </p>
            </div>
            <div className="flex flex-col gap-y-5">
              <h1 className="font-bold">Địa chỉ</h1>
              <div className="flex flex-col gap-y-2">
                <h1 className="font-bold">-Hà Nội:</h1>
                <p>Ở đâu còn lâu mới nói :))</p>
              </div>
              <p>
                <span className="font-bold">Điện thoại: </span> 0916058692
              </p>
              <p>
                <span className="font-bold">Email: </span>{" "}
                daohieu171221@gmail.com
              </p>
            </div>
            <div className="flex flex-col">
              <h1 className="mb-3 text-gray-500 uppercase text-xl font-bold">
                Hỗ trợ khách hàng
              </h1>
              <ul className="flex flex-col gap-y-3">
                <li>
                  <Link to="/">Giới thiệu cửa hàng</Link>
                </li>
                <li>
                  <Link to="/">Hệ thống cửa hàng</Link>
                </li>
                <li>
                  <Link to="/">Hướng dẫn đặt hàng</Link>
                </li>
                <li>
                  <Link to="/">Chính sách và quy định</Link>
                </li>
                <li>
                  <Link to="/">Chính sách bảo mật</Link>
                </li>
                <li>
                  <Link to="/">Thông tin sở hữu</Link>
                </li>
              </ul>
            </div>
            <div className="flex flex-col gap-y-3">
              <div className="flex items-center gap-x-5">
                <h1 className="text-gray-500 uppercase text-xl font-bold">
                  Design by :
                </h1>
                <p>Đào Đức Hiếu</p>
              </div>
              <div className="flex items-center gap-x-5">
                <h1 className="text-gray-500 uppercase text-xl font-bold">
                  Email :
                </h1>
                <p>daohieu171221@gmail.com</p>
              </div>
            </div>
          </div>
        </div>
      </footer>
    </>
  );
};

export default Layout;
