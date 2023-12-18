import {
  Button,
  Card,
  Input,
  Radio,
  Textarea,
  Typography,
} from "@material-tailwind/react";
import React, { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import useCart from "../../shared/hooks/useCart";
import OrderService from "../../shared/services/OrderService";
import CartService from "../../shared/services/CartService";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import DiscountService from "../../shared/services/DiscountService";
const TABLE_HEAD = [
  "SẢN PHẨM",
  "KIỂU LOẠI",
  "ĐƠN GIÁ",
  "SỐ LƯỢNG",
  "THÀNH TIỀN",
];

const Checkout = () => {
  const { cart } = useCart();
  const [location, setLocation] = useState();
  const [phone, setPhone] = useState();
  const [note, setNote] = useState();
  const [code, setCode] = useState();
  const [totalPrice, setTotalPrice] = useState();
  const navigate = useNavigate();
  const [paymentType, setPaymentType] = useState();

  const CreateOrderHandler = async () => {
    const data = {
      totalPrice: totalPrice,
      shipAddress: location,
      phoneNumber: phone,
      cancelReason: "",
      note: note,
      orderStatus: 1,
      payment: {
        amount: totalPrice,
        method: 1,
        status: 1,
      },
      orderDetails: cart?.items.map((item) => {
        return {
          productId: item.productId,
          inventoryId: item.inventoryId,
          type: item.type,
          quantity: item.quantity,
          unitPrice: item.unitPrice,
        };
      }),
    };
    await OrderService.CreateOrder(data)
      .then(async (res) => {
        toast.success("Đặt hàng thành công !");
        await CartService.ClearCart();
        await DiscountService.UseDiscount(code);
        navigate("/");
      })
      .catch((err) => {
        toast.error(err.response.data);
      });
  };

  useEffect(() => {
    setTotalPrice(cart?.totalPrice);
  }, [cart]);

  const useDiscountHandler = async () => {
    await DiscountService.Check(code)
      .then((res) => {
        setTotalPrice(totalPrice - (totalPrice * res.percent) / 100);
        toast.success("Áp dụng mã giảm giá thành công !");
      })
      .catch((err) => toast.error(err.response.data));
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
              {cart?.items.map((item) => {
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
                      {item.type}
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
              <h1 className="text-2xl p-3">Thanh toán giỏ hàng</h1>
            </div>
            <div className="mt-3 p-3 pb-10 border-b border-borderpri">
              <div className="flex justify-between">
                <p className="font-medium text-lg text-gray-500">
                  Tổng đơn hàng
                </p>
                <span>{totalPrice} VND</span>
              </div>
              <div className="flex justify-between">
                <p className="font-medium text-lg text-gray-500">Giảm giá</p>

                <span>Chưa có thông tin</span>
              </div>
            </div>
            <div className="p-3 flex justify-between">
              <p className="font-medium text-lg ">Tổng</p>
              <span>{totalPrice} VND</span>
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
          <div className="border-borderpri border pb-5 rounded-lg">
            <div className="p-3 border-b border-borderpri">
              <h1 className="font-medium">Mã Giảm giá</h1>
            </div>
            <div className="p-3 flex flex-col gap-y-3">
              <Input
                label="Mã giảm giá"
                onChange={(e) => setCode(e.target.value)}
              ></Input>
              <Button
                className="bg-blue-500 w-full"
                onClick={useDiscountHandler}
              >
                Sử dụng mã giảm giá
              </Button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Checkout;
