import { useQuery } from "@tanstack/react-query";
import React from "react";
import DiscountService from "../../shared/services/DiscountService";
import { Button, Card, Spinner, Typography } from "@material-tailwind/react";
import AddDiscount from "./shared/components/discount/AddDiscount";
import UpdateDiscount from "./shared/components/discount/UpdateDiscount";
import DeleteDiscount from "./shared/components/discount/DeleteDiscount";

const TABLE_HEAD = [
  "ID",
  "Code",
  "Giảm giá",
  "Số Lượng",
  "Hạn sử dụng",
  "Trạng thái",
  "",
];

const DiscountManagerPage = () => {
  const discountQuery = useQuery({
    queryKey: ["discount-manager"],
    queryFn: async () => {
      return await DiscountService.GetAll();
    },
  });

  return (
    <>
      <div className="my-6">
        <h1 className="uppercase text-lg font-medium">Quản lý mã giảm giá</h1>
      </div>
      <div className="mb-6">
        <AddDiscount reload={discountQuery.refetch} />
      </div>
      {discountQuery.isLoading ? (
        <Spinner />
      ) : (
        <Card className="h-full w-full">
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
              {discountQuery.data.length === 0 ? (
                <p className="text p-3 mt-3 font-semibold">
                  Chưa có tồn kho nào cạ !!!
                </p>
              ) : (
                discountQuery.data?.map((item) => (
                  <tr key={item.id} className="even:bg-blue-gray-50/50">
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        #{item.id}
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.code}
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.percent} %
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.quantity}
                      </Typography>
                    </td>
                    <td className="p-4 flex gap-x-1">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.expire.replace("T", " ")}
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.isPublic ? "Công khai" : "Không công khai"}
                      </Typography>
                    </td>
                    <td className="p-4 flex gap-x-3">
                      <UpdateDiscount
                        item={item}
                        reload={discountQuery.refetch}
                      />
                      <DeleteDiscount
                        item={item}
                        reload={discountQuery.refetch}
                      />
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </Card>
      )}
    </>
  );
};

export default DiscountManagerPage;
