import { MagnifyingGlassIcon } from "@heroicons/react/24/outline";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Input,
  Typography,
} from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React, { useState } from "react";
import ProductService from "../../shared/services/ProductService";
import AddProduct from "./shared/components/product/AddProduct";

const TABLE_HEAD = [
  "Id",
  "Ảnh",
  "Tên sản phẩm",
  "Mô tả",
  "Giá tiền",
  "Danh mục",
  "",
];

const ProductManagerPage = () => {
  const [page, setPage] = useState(1);
  const [name, setName] = useState("");
  const [toPrice, setToPrice] = useState("");
  const [fromPrice, setFromPrice] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const [sortType, setSortType] = useState("");

  const productQuery = useQuery({
    queryKey: [
      "product-manager",
      page,
      name,
      toPrice,
      fromPrice,
      categoryId,
      sortType,
    ],
    queryFn: async (context) => {
      return ProductService.Filter(context);
    },
  });

  return (
    <>
      <>
        <Card className="h-full w-full">
          <CardHeader floated={false} shadow={false} className="rounded-none">
            <div className="mb-8 flex items-center justify-between gap-8">
              <div>
                <Typography
                  variant="h5"
                  color="blue-gray"
                  className="uppercase font-semibold"
                >
                  Quản lý sản phẩm
                </Typography>
                <Typography color="gray" className="mt-1 text-sm font-normal">
                  Tất cả thông tin của sản phẩm
                </Typography>
              </div>
              <div className="flex shrink-0 flex-col gap-2 sm:flex-row">
                <AddProduct onReload={productQuery.refetch} />
              </div>
            </div>
            <div className="flex flex-col items-center justify-between gap-4 md:flex-row">
              <div className="w-full md:w-72">
                <Input
                  label="Search"
                  icon={<MagnifyingGlassIcon className="h-5 w-5" />}
                  onChange={(e) => setName(e.target.value)}
                />
              </div>
            </div>
          </CardHeader>
          <CardBody className="px-0">
            <table className="mt-4 w-full min-w-max table-auto text-left">
              <thead>
                <tr>
                  {TABLE_HEAD.map((head, index) => (
                    <th
                      key={head}
                      className="cursor-pointer border-y border-blue-gray-100 bg-blue-gray-50/50 p-4 transition-colors hover:bg-blue-gray-50"
                    >
                      <Typography
                        variant="small"
                        color="blue-gray"
                        className="flex items-center justify-between gap-2 font-normal leading-none opacity-70"
                      >
                        {head}
                      </Typography>
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {productQuery.data?.list?.map((item, index) => {
                  const isLast = index === productQuery.data?.list?.length - 1;
                  const classes = isLast
                    ? "p-4"
                    : "p-4 border-b border-blue-gray-50";

                  return (
                    <tr key={item.id}>
                      <td className={classes}>
                        <span>#{item.id}</span>
                      </td>
                      <td className={classes}>{item.imageUrl}</td>
                      <td className={classes}>{item.name}</td>
                      <td className={classes}>
                        <Typography
                          variant="small"
                          color="blue-gray"
                          className="font-normal"
                        >
                          {item.description}
                        </Typography>
                      </td>
                      <td className={classes}>{item.price} đ</td>
                      <td className={classes}>{item.categoryName}</td>
                      <td className={`${classes}`}>
                        <div className="flex gap-x-3 text-blue-500">
                          <span>sửa</span>
                          <span>xóa</span>
                          <span>tồn kho</span>
                        </div>
                      </td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </CardBody>
          <CardFooter className="flex items-center justify-between border-t border-blue-gray-50 p-4">
            <Typography
              variant="small"
              color="blue-gray"
              className="font-normal"
            >
              Page {productQuery.data?.pageIndex} of{" "}
              {productQuery.data?.totalPages}
            </Typography>
            <div className="flex gap-2">
              <Button
                variant="outlined"
                size="sm"
                disabled={!productQuery.data?.hasPrevious}
                onClick={() => setPage(page - 1)}
              >
                Previous
              </Button>
              <Button
                variant="outlined"
                size="sm"
                disabled={!productQuery.data?.hasNext}
                onClick={() => setPage(page + 1)}
              >
                Next
              </Button>
            </div>
          </CardFooter>
        </Card>
      </>
    </>
  );
};

export default ProductManagerPage;
