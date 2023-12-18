import { useQuery } from "@tanstack/react-query";
import React, { useState } from "react";
import { useParams } from "react-router-dom";
import OrderService from "../../shared/services/OrderService";
import { toast } from "react-toastify";
import {
  Button,
  Dialog,
  DialogBody,
  DialogFooter,
  DialogHeader,
  Spinner,
  Textarea,
} from "@material-tailwind/react";
import OrderStatus from "../../shared/components/status/OrderStatus";
import OrderItem from "../(admin)/shared/components/order/OrderItem";

const MyOrderDetail = () => {
  const { id } = useParams();
  const [open, setOpen] = useState(false);
  const [reason, setReason] = useState("");
  const handleOpen = () => setOpen(!open);
  const orderQuery = useQuery({
    queryKey: ["order-detail"],
    queryFn: async () => {
      return await OrderService.FindById(id);
    },
  });

  const OrderRejectHandler = async () => {
    await OrderService.UpdateStatus(id, 4, reason).then((res) => {
      toast.success("Xác nhận hủy đơn hàng thành công !");
      orderQuery.refetch();
    });
  };
  return (
    <>
      <div>
        <div className="container m-6 grid grid-cols-3 gap-x-12">
          <div className="col-span-2">
            <h1 className="font-bold text-2xl mb-3">Chi tiết hóa đơn</h1>
            <p>
              Có {orderQuery.data?.orderDetails.length} sản phẩm trong đơn hàng
              #{orderQuery.data?.id}
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
            <div className="mt-3 border-gray-700  text-black rounded-md">
              <p className="font-bold text-lg">Ghi chú :</p>
              <p>{orderQuery.data?.note}</p>
            </div>
            <div className="flex flex-col gap-y-2 mt-3">
              {orderQuery.data?.orderStatus === 1 && (
                <>
                  <Button onClick={handleOpen} className="w-full">
                    Hủy đơn hàng
                  </Button>
                  <Dialog open={open} handler={handleOpen}>
                    <DialogHeader className="text-primary">
                      Hủy đơn hàng
                    </DialogHeader>
                    <DialogBody>
                      <h1 className="mb-3 text-xl uppercase font-semibold">
                        Bạn xác nhận hủy đơn hàng #{orderQuery.data?.id}
                      </h1>
                      <div>
                        <Textarea
                          label="Lí do hủy đơn hàng"
                          className="mt-3"
                          value={reason}
                          onChange={(e) => setReason(e.target.value)}
                        />
                      </div>
                    </DialogBody>
                    <DialogFooter>
                      <Button
                        variant="text"
                        color="red"
                        onClick={handleOpen}
                        className="mr-1"
                      >
                        <span>Hủy</span>
                      </Button>
                      <Button onClick={OrderRejectHandler}>
                        <span>Xác nhận</span>
                      </Button>
                    </DialogFooter>
                  </Dialog>
                </>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default MyOrderDetail;
