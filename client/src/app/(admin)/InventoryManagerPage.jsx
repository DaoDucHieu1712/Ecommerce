import { Button, Card, Spinner, Typography } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React from "react";
import { useParams } from "react-router-dom";
import InventoryService from "../../shared/services/InventoryService";
import AddInventory from "./shared/components/inventory/AddInventory";
import UpdateInventory from "./shared/components/inventory/UpdateInventory";
import AddQuantity from "./shared/components/inventory/AddQuantity";

const TABLE_HEAD = [
  "ID",
  "Tên Sản Phẩm",
  "Size",
  "Màu Sắc",
  "Số Lượng",
  "Giá Tiền",
  "",
];

const InventoryManagerPage = () => {
  const { id } = useParams();

  const inventoryQuery = useQuery({
    queryKey: ["inventory-manager"],
    queryFn: async () => {
      return InventoryService.GetAllByProductIdByAdmin(id);
    },
  });

  return (
    <>
      <div className="my-6">
        <h1 className="uppercase text-lg font-medium">Tồn kho</h1>
      </div>
      <div className="mb-6">
        <AddInventory reload={inventoryQuery.refetch} />
      </div>
      {inventoryQuery.isLoading ? (
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
              {inventoryQuery.data.length === 0 ? (
                <p className="text p-3 mt-3 font-semibold">
                  Chưa có tồn kho nào cạ !!!
                </p>
              ) : (
                inventoryQuery.data?.map((item) => (
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
                        {item.productName}
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.sizeName}
                      </Typography>
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.colorName}
                      </Typography>
                    </td>
                    <td className="p-4 flex gap-x-1">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.quantity}
                      </Typography>
                      <AddQuantity
                        item={item}
                        reload={inventoryQuery.refetch}
                      />
                    </td>
                    <td className="p-4">
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="font-normal"
                      >
                        {item.unitPrice} đ
                      </Typography>
                    </td>
                    <td className="p-4 flex gap-x-3">
                      <UpdateInventory
                        item={item}
                        reload={inventoryQuery.refetch}
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

export default InventoryManagerPage;
