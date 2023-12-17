import React, { useEffect, useState } from "react";
import CartItem from "./shared/components/cart/CartItem";
import {
  Button,
  Card,
  Input,
  Option,
  Select,
  Textarea,
  Typography,
} from "@material-tailwind/react";
import useCart from "../../shared/hooks/useCart";
import { useDispatch } from "react-redux";
import { checkoutActions } from "../../redux/checkoutSlice";

const TABLE_HEAD = [
  "SẢN PHẨM",
  "KIỂU LOẠI",
  "ĐƠN GIÁ",
  "SỐ LƯỢNG",
  "THÀNH TIỀN",
];

const TABLE_ROWS = [
  {
    name: "John Michael",
    job: "Manager",
    date: "23/04/18",
  },
  {
    name: "Alexa Liras",
    job: "Developer",
    date: "23/04/18",
  },
  {
    name: "Laurent Perrier",
    job: "Executive",
    date: "19/09/17",
  },
  {
    name: "Michael Levi",
    job: "Developer",
    date: "24/12/08",
  },
  {
    name: "Richard Gran",
    job: "Manager",
    date: "04/10/21",
  },
];

const CartPage = () => {
  const [location, setLocation] = useState();
  const [phone, setPhone] = useState();
  const [note, setNote] = useState();
  const { cart, fetchCart } = useCart();
  const dispatch = useDispatch();

  const CheckoutHandler = async () => {
    dispatch(checkoutActions.SetInfo({ location, phone, note }));
    window.location.href = "/checkout";
  };

  return (
    <div className="grid grid-cols-3 gap-6">
      <Card className="h-full w-full col-span-2">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head) => (
                <th
                  key={head}
                  className="border-b border-blue-gray-100 bg-blue-gray-50 p-4"
                >
                  <Typography
                    variant="small"
                    color="blue-gray"
                    className="font-normal leading-none opacity-70"
                  >
                    {head}
                  </Typography>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {cart?.items.length === 0 && (
              <p className="p-3 my-3 font-medium text-lg">
                Bạn không có đơn hàng nào cả !!!
              </p>
            )}
            {cart?.items.map((item, index) => {
              const isLast = index === TABLE_ROWS.length - 1;
              const classes = isLast
                ? "p-4"
                : "p-4 border-b border-blue-gray-50";

              return <CartItem item={item} reload={fetchCart}></CartItem>;
            })}
          </tbody>
        </table>
      </Card>
      <div className="flex flex-col gap-y-5 shadow-lg">
        <div className="border-borderpri border pb-5 rounded-lg">
          <div className="p-3 border-b border-borderpri">
            <h1 className="font-medium">Thông tin khác</h1>
          </div>
          <div className="p-3 flex flex-col gap-y-3">
            <Input
              label="Số điện thoại"
              type="number"
              onChange={(e) => setPhone(e.target.value)}
            ></Input>
            <Input
              label="Địa chỉ"
              type="text"
              onChange={(e) => setLocation(e.target.value)}
            ></Input>
            <Textarea
              label="Ghi chú"
              className="h-[185px]"
              onChange={(e) => setNote(e.target.value)}
            />
          </div>
        </div>
        <div className="border-borderpri border pb-5 rounded-lg">
          <div className="heading">
            <h1 className="text-2xl p-3">Giỏ hàng của bạn</h1>
          </div>
          <div className="mt-3 p-3 pb-10 border-b border-borderpri">
            <div className="flex justify-between">
              <p className="font-medium text-lg text-gray-500">Tổng đơn hàng</p>
              <span>{cart?.totalPrice} VND</span>
            </div>
            <div className="flex justify-between">
              <p className="font-medium text-lg text-gray-500">Phí ship</p>

              <span>Chưa có thông tin</span>
            </div>
          </div>
          <div className="p-3 flex justify-between">
            <p className="font-medium text-lg ">Tổng</p>
            <span>{cart?.totalPrice} VND</span>
          </div>
          <div className="p-3 w-full">
            <Button className="w-full" onClick={CheckoutHandler}>
              Thanh toán
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartPage;
