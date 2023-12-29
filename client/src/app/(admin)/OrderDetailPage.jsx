import { useQuery } from "@tanstack/react-query";
import React from "react";
import { Link, useParams } from "react-router-dom";
import OrderService from "../../shared/services/OrderService";
import { Button, Spinner } from "@material-tailwind/react";
import OrderItem from "./shared/components/order/OrderItem";
import OrderStatus from "../../shared/components/status/OrderStatus";
import { toast } from "react-toastify";
import PaymentStatus from "../../shared/components/status/PaymentStatus";

const OrderDetailPage = () => {
  const { id } = useParams();

  const orderQuery = useQuery({
    queryKey: ["order-detail"],
    queryFn: async () => {
      return await OrderService.FindById(id);
    },
  });

  const OrderPendingHandler = async () => {
    await OrderService.UpdateStatus(id, 2).then((res) => {
      toast.success("Xác nhận đơn hàng thành công !");
      orderQuery.refetch();
    });
  };

  const OrderSuccessHandler = async () => {
    await OrderService.UpdateStatus(id, 3).then((res) => {
      toast.success("Xác nhận đơn hàng đã giao thành công !");
      orderQuery.refetch();
    });
  };

  const OrderRejectHandler = async () => {
    await OrderService.UpdateStatus(id, 4).then((res) => {
      toast.success("Xác nhận hủy đơn hàng thành công !");
      orderQuery.refetch();
    });
  };

  return (
    <div>
      <div className="container m-6 grid grid-cols-3 gap-x-12">
        <div className="col-span-2">
          <h1 className="font-bold text-2xl mb-3">Chi tiết hóa đơn</h1>
          <p>
            Có {orderQuery.data?.orderDetails.length} sản phẩm trong đơn hàng #
            {orderQuery.data?.id}
          </p>
          <>
            <div className="flex flex-col gap-y-5 cart mt-8 border-1 rounded-md border-gray-400">
              {orderQuery.isLoading ? (
                <Spinner />
              ) : (
                orderQuery.data?.orderDetails.map((item) => {
                  return <OrderItem key={item.id} item={item}></OrderItem>;
                })
              )}
            </div>
          </>
        </div>
        <div className="flex flex-col gap-y-4">
          <h1 className="pb-3 border-b font-bold text-2xl border-gray-200">
            Đơn hàng : #{orderQuery.data?.id}
          </h1>
          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Khách hàng :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.customerName}
            </p>
          </div>

          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Tổng tiền :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.totalPrice} VND
            </p>
          </div>
          <div className="flex justify-between items-center border-b pb-3 border-gray-200">
            <p className="font-bold text-lg">Ngày đặt :</p>
            <p className="text-red-500  font-bold text-lg">
              {orderQuery.data?.createdAt.toString().slice(0, 10)} $
            </p>
          </div>
          <div className="my-3 flex justify-between items-center gap-x-3">
            <p className="font-bold text-lg">Trạng thái : </p>
            <OrderStatus status={orderQuery.data?.orderStatus}></OrderStatus>
          </div>
          <ul className="info">
            <div className="flex justify-between gap-y-2 flex-col border-b pb-3 border-gray-200">
              <p className="font-bold text-lg">Địa chỉ :</p>
              <p className="font-medium text-sm">
                {orderQuery.data?.shipAddress}
              </p>
            </div>
          </ul>
          <ul className="info">
            <div className="flex justify-between gap-y-2 flex-col border-b pb-3 border-gray-200">
              <p className="font-bold text-lg">Số điện thoại :</p>
              <p className="font-medium text-sm">
                {orderQuery.data?.phoneNumber}
              </p>
            </div>
          </ul>
          <ul className="info">
            <div className="flex justify-between gap-y-2 flex-col border-b pb-3 border-gray-200">
              <p className="font-bold text-lg">Phương thức thanh toán : </p>
              <p className="font-medium text-sm">
                {orderQuery.data?.paymentMethod === 1
                  ? "Thanh toán khi nhận hàng"
                  : "Chuyển khoản"}
                <div className="">
                  <PaymentStatus status={orderQuery.data?.paymentStatus} />
                </div>
              </p>
            </div>
          </ul>
          <div className="mt-3 border-gray-700  text-black rounded-md">
            <p className="font-bold text-lg">Ghi chú :</p>
            <p>{orderQuery.data?.note}</p>
          </div>
          <div className="flex flex-col gap-y-2 mt-3">
            <Button
              size="sm"
              color="green"
              onClick={OrderSuccessHandler}
              disabled={orderQuery.data?.orderStatus !== 2}
            >
              Xác nhận giao hàng thành công
            </Button>
            <Button
              size="sm"
              color="orange"
              disabled={orderQuery.data?.orderStatus !== 1}
              onClick={OrderPendingHandler}
            >
              Xác nhận đơn hàng
            </Button>
            <Button
              size="sm"
              color="red"
              onClick={OrderRejectHandler}
              disabled={orderQuery.data?.orderStatus !== 2}
            >
              Hủy đơn hàng
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default OrderDetailPage;
