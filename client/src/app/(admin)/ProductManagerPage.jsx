import { MagnifyingGlassIcon } from "@heroicons/react/24/outline";
import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Input,
  Option,
  Select,
  Spinner,
  Typography,
} from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React, { useEffect, useState } from "react";
import ProductService from "../../shared/services/ProductService";
import AddProduct from "./shared/components/product/AddProduct";
import UpdateProduct from "./shared/components/product/UpdateProduct";
import CategoryService from "../../shared/services/CategoryService";
import DeleteProduct from "./shared/components/product/DeleteProduct";
import { Link } from "react-router-dom";

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
  const [categories, setCategories] = useState([]);

  const loadCategories = async () => {
    await CategoryService.GetAll().then((res) => {
      console.log(res);
      setCategories(res);
    });
  };

  useEffect(() => {
    loadCategories();
  }, []);

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

  const categoryQuery = useQuery({
    queryKey: ["category-select"],
    queryFn: async () => {
      return CategoryService.GetAllByAdmin();
    },
  });

  const SelectPriceHandler = (e) => {
    if (e.length === 0) {
      setToPrice("");
      setFromPrice("");
    }
    if (e === "100000") {
      setToPrice("");
      setFromPrice(100000);
    }
    if (e === "100000-250000") {
      setToPrice(100000);
      setFromPrice(250000);
    }
    if (e === "250000-500000") {
      setToPrice(250000);
      setFromPrice(500000);
    }
    if (e === "500000-800000") {
      setToPrice(500000);
      setFromPrice(800000);
    }
    if (e === "800000") {
      setToPrice(800000);
      setFromPrice("");
    }
    setPage(1);
  };

  return (
    <>
      <>
        <Card className="h-full w-full p-3">
          {/* <CardHeader floated={false} shadow={false} className="rounded-none"> */}
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
          <div className="w-[60%] flex flex-col items-center justify-between gap-4 md:flex-row">
            <div className="w-full">
              <Select
                label="Danh mục"
                onChange={(e) => {
                  setCategoryId(e);
                  setPage(1);
                }}
              >
                <Option value="" defaultChecked>
                  Tất cả
                </Option>
                {categories.map((item) => {
                  return (
                    <Option key={item.id} value={item.id}>
                      {item.name}
                    </Option>
                  );
                })}
              </Select>
            </div>
            <div className="w-full">
              <Select label="Giá tiền" onChange={(e) => SelectPriceHandler(e)}>
                <Option value="">Tất cả</Option>
                <Option value="100000">Dưới 100.000đ</Option>
                <Option value="100000-250000">100.000đ - 250.000đ</Option>
                <Option value="250000-500000">250.000đ - 500.000đ</Option>
                <Option value="500000-800000">500.000đ - 800.000đ</Option>
                <Option value="800000">Trên 800.000đ</Option>
              </Select>
            </div>
            <div className="w-full">
              <Select
                label="Sắp xếp"
                onChange={(e) => {
                  setSortType(e);
                  setPage(1);
                }}
              >
                <Option value="">Mặc định</Option>
                <Option value="name-asc">Tên: A - Z</Option>
                <Option value="name-desc">Tên: Z - A</Option>
                <Option value="price-asc">Giá: Tăng dần</Option>
                <Option value="price-desc">Giá: Giảm dần</Option>
                <Option value="">Mới nhất</Option>
                <Option value="">Cũ nhất</Option>
                <Option value="">Bán chạy nhất</Option>
                <Option value="">Tồn kho giảm dần</Option>
              </Select>
            </div>
            <div className="w-full">
              <Input
                label="Search"
                icon={<MagnifyingGlassIcon className="h-5 w-5" />}
                onChange={(e) => setName(e.target.value)}
              />
            </div>
          </div>
          {/* </CardHeader> */}
          {/* <CardBody className="px-0"> */}
          {productQuery.isLoading ? (
            <Spinner />
          ) : (
            <table className="mt-4 w-full min-w-max table-auto text-left">
              <thead>
                <tr>
                  {TABLE_HEAD.map((head) => (
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
                {productQuery.data?.list?.length === 0 ? (
                  <p className="text p-3 mt-3 font-semibold">
                    Không tìm thấy sản phẩm nào cạ !!
                  </p>
                ) : (
                  productQuery.data?.list?.map((item, index) => {
                    const isLast =
                      index === productQuery.data?.list?.length - 1;
                    const classes = isLast
                      ? "p-4"
                      : "p-4 border-b border-blue-gray-50";

                    return (
                      <tr key={item.id}>
                        <td className={classes}>
                          <span>#{item.id}</span>
                        </td>
                        <td className={classes}>
                          <img
                            src={item.imageUrl}
                            className="w-[75px] h-[75px] object-cover"
                            alt="img-product"
                          />
                        </td>
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
                          <div className="flex gap-x-3">
                            <UpdateProduct
                              item={item}
                              reload={productQuery.refetch}
                            />
                            <DeleteProduct
                              item={item}
                              reload={productQuery.refetch}
                            />
                            <Link to={`/admin/product/inventory/${item.id}`}>
                              <Button size="sm" variant="outlined">
                                tồn kho
                              </Button>
                            </Link>
                          </div>
                        </td>
                      </tr>
                    );
                  })
                )}
              </tbody>
            </table>
          )}
          {/* </CardBody> */}
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
