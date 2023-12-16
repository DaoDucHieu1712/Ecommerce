import { Button, Card, Radio, Typography } from "@material-tailwind/react";
import React, { useState } from "react";
import { useSelector } from "react-redux";
import useCart from "../../shared/hooks/useCart";
import OrderService from "../../shared/services/OrderService";
import CartService from "../../shared/services/CartService";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
const TABLE_HEAD = [
  "SẢN PHẨM",
  "KIỂU LOẠI",
  "ĐƠN GIÁ",
  "SỐ LƯỢNG",
  "THÀNH TIỀN",
];

const Checkout = () => {
  const checkoutSelector = useSelector((state) => state.checkout);
  const navigate = useNavigate();
  const { cart, fetchCart } = useCart();

  const [paymentType, setPaymentType] = useState();

  const CreateOrderHandler = async () => {
    const data = {
      totalPrice: cart?.totalPrice,
      shipAddress: checkoutSelector.info.location,
      phoneNumber: checkoutSelector.info.phone,
      cancelReason: "",
      note: checkoutSelector.info.phone,
      orderStatus: 1,
      payment: {
        amount: cart?.totalPrice,
        method: 1,
        status: 1,
      },
      orderDetails: cart?.items.map((item) => {
        return {
          productId: item.productId,
          inventoryId: item.inventoryId,
          quantity: item.quantity,
          unitPrice: item.unitPrice,
        };
      }),
    };
    await OrderService.CreateOrder(data)
      .then(async (res) => {
        toast.success("Đặt hàng thành công !");
        await CartService.ClearCart();
        navigate("/");
      })
      .catch((err) => {
        toast.error(err.response.data);
      });
  };

  return (
    <>
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
              {cart?.items.map((item, index) => {
                const isLast = index === cart?.items.length - 1;
                const classes = isLast
                  ? "p-4"
                  : "p-4 border-b border-blue-gray-50";

                return (
                  <tr key={item.foodId}>
                    <td className="p-4 border-b border-blue-gray-50 flex items-center gap-x-2">
                      <img
                        src={item.productImage}
                        alt=""
                        className="w-[70px]"
                      />
                      <span>{item.productName}</span>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      {item.unitPrice} đ
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      <div className="flex items-center justify-between border p-2">
                        <span>x</span>
                        <p>{item.quantity}</p>
                      </div>
                    </td>
                    <td className="p-4 border-b border-blue-gray-50">
                      {item.quantity * item.unitPrice} đ
                    </td>
                  </tr>
                );
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
              <p>
                <span>Địa chỉ :</span> {checkoutSelector.info.location}
              </p>
              <p>
                <span>phone :</span> {checkoutSelector.info.phone}
              </p>
              <p>
                <span>note :</span> {checkoutSelector.info.note}
              </p>
            </div>
          </div>
          <div className="border-borderpri border pb-5 rounded-lg">
            <div className="heading">
              <h1 className="text-2xl p-3">Thanh toán giỏ hàng</h1>
            </div>
            <div className="mt-3 p-3 pb-10 border-b border-borderpri">
              <div className="flex justify-between">
                <p className="font-medium text-lg text-gray-500">
                  Tổng đơn hàng
                </p>
                <span>{cart?.totalPrice} VND</span>
              </div>
              <div className="flex justify-between">
                <p className="font-medium text-lg text-gray-500">Giảm giá</p>

                <span>Chưa có thông tin</span>
              </div>
            </div>
            <div className="p-3 flex justify-between">
              <p className="font-medium text-lg ">Tổng</p>
              <span>{cart?.totalPrice} VND</span>
            </div>
            <div className="p-3 w-full">
              <div className="mb-6">
                <Radio
                  name="type"
                  label="Chuyển khoản"
                  onChange={() => setPaymentType("Chuyển khoản")}
                />
                <Radio
                  name="type"
                  label="Thanh toán khi nhận hàng"
                  defaultChecked
                  onChange={() => setPaymentType("Thanh toán khi nhận hàng")}
                />
              </div>
              <Button className="w-full" onClick={CreateOrderHandler}>
                Thanh toán
              </Button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Checkout;
