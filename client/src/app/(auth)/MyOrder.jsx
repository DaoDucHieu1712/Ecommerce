import React, { useState } from "react";
import {
  Button,
  IconButton,
  Input,
  Option,
  Select,
  Typography,
} from "@material-tailwind/react";
import OrderStatus from "../../shared/components/status/OrderStatus";
import PaymentMethod from "../../shared/components/status/PaymentMethod";
import PaymentStatus from "../../shared/components/status/PaymentStatus";
import { Link } from "react-router-dom";
import { MagnifyingGlassIcon } from "@heroicons/react/24/solid";
import OrderService from "../../shared/services/OrderService";
import { useQuery } from "@tanstack/react-query";
const TABLE_HEAD = [
  "Mã Đơn hàng",
  "Khách hàng",
  "Ngày đặt",
  "Địa điểm",
  "Số điện thoại",
  "Trạng thái",
  "Tổng tiền",
  "Chi tiết",
];
const MyOrder = () => {
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(7);
  const [customer, setCustomer] = useState("");
  const [startDate, setStartDate] = useState("");
  const [endDate, setEndDate] = useState("");
  const [sortType, setSortType] = useState("");
  const [status, setStatus] = useState("");
  const [orderId, setOrderId] = useState("");

  const ordersQuery = useQuery({
    queryKey: [
      "order-manager",
      page,
      pageSize,
      orderId,
      customer,
      startDate,
      endDate,
      status,
      sortType,
    ],
    queryFn: async (context) => {
      return OrderService.MyOrder(context);
    },
  });

  return (
    <>
      <div className="mb-8 flex items-center justify-between gap-8">
        <div>
          <Typography
            variant="h5"
            color="blue-gray"
            className="uppercase font-semibold"
          >
            Đơn hàng của tui
          </Typography>
          <Typography color="gray" className="mt-1 text-sm font-normal">
            Tất cả thông tin về đơn hàng của bạn
          </Typography>
        </div>
      </div>
      <div className="w-[60%] flex flex-col items-center justify-between gap-4 md:flex-row">
        <div className="w-full">
          <Input
            label="Từ ngày"
            type="date"
            onChange={(e) => setStartDate(e.target.value)}
          />
        </div>
        <div className="w-full">
          <Input
            label="Đến ngày"
            type="date"
            onChange={(e) => setEndDate(e.target.value)}
          />
        </div>
        <div className="w-full">
          <Select label="Sắp xếp" onChange={(e) => setSortType(e)}>
            <Option value="">Mặc định</Option>
            <Option value="date-desc">Mới nhất</Option>
            <Option value="date-asc">Cũ nhất</Option>
            <Option value="price-asc">Giá: Tăng dần</Option>
            <Option value="price-desc">Giá: Giảm dần</Option>
          </Select>
        </div>
        <div className="w-full">
          <Select label="Trạng thái" onChange={(e) => setStatus(e)}>
            <Option value="">Tất cả</Option>
            <Option value="1">Đang chờ</Option>
            <Option value="2">Đang giao</Option>
            <Option value="3">Đã giao hàng</Option>
            <Option value="4">Đã hủy</Option>
          </Select>
        </div>

        <div className="w-full">
          <Input
            label="Mã đơn hàng"
            type="number"
            onChange={(e) => setOrderId(e.target.value)}
            icon={<MagnifyingGlassIcon className="h-5 w-5" />}
          />
        </div>
      </div>
      <div className="mt-12">
        <table className="w-full min-w-max table-auto text-left">
          <thead>
            <tr>
              {TABLE_HEAD.map((head) => (
                <th
                  key={head}
                  className="border-y border-blue-gray-100 bg-blue-gray-50/50 p-4"
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
            {ordersQuery.data?.list?.map((item, index) => {
              const isLast = index === ordersQuery.data?.list?.length - 1;
              const classes = isLast
                ? "p-4 text-sm"
                : "p-4 border-b border-blue-gray-50 text-sm";
              return (
                <tr key={item.id}>
                  <td className={classes}>#{item.id}</td>
                  <td className={classes}>{item.customerName}</td>
                  <td className={classes}>
                    <span>
                      {item.createdAt.toString().replace("T", " ").slice(0, 19)}
                    </span>
                  </td>
                  <td className={classes}>
                    <p className="w-[120px] text-ellipsis">
                      {item.shipAddress}
                    </p>
                  </td>
                  <td className={classes}>{item.phoneNumber}</td>
                  <td className={classes}>
                    <OrderStatus status={item.orderStatus}></OrderStatus>
                  </td>
                  <td className={`${classes} flex flex-col`}>
                    <p>{item.totalPrice} VND</p>
                    <PaymentMethod method={item.paymentMethod} />
                    <PaymentStatus status={item.paymentStatus} />
                  </td>
                  <td className={classes}>
                    <div className="flex gap-x-3">
                      <Link
                        to={`/my-order/${item.id}`}
                        className="px-6 py-2 text-light-blue-500 font-medium rounded-lg cursor-pointer"
                      >
                        chi tiết đơn hàng
                      </Link>
                    </div>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        {/* paging */}
        <div className="flex items-center justify-between border-t border-blue-gray-50 p-4">
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={!ordersQuery.data?.hasPrevious}
            onClick={() => setPage(page - 1)}
          >
            Previous
          </Button>
          <div className="flex items-center gap-2">
            {(() => {
              let rows = [];
              for (let i = 1; i <= ordersQuery.data?.total; i++) {
                rows.push(
                  <IconButton
                    key={i}
                    variant="outlined"
                    color="blue-gray"
                    size="sm"
                    className={page === i ? "bg-blue-gray-500 text-white" : ""}
                    onClick={() => setPage(i)}
                  >
                    {i}
                  </IconButton>
                );
              }
              return rows;
            })()}
          </div>
          <Button
            variant="outlined"
            color="blue-gray"
            size="sm"
            disabled={!ordersQuery.data?.hasNext}
            onClick={() => setPage(page + 1)}
          >
            Next
          </Button>
        </div>
      </div>
    </>
  );
};

export default MyOrder;
