import React, { useEffect, useState } from "react";
import { MagnifyingGlassIcon } from "@heroicons/react/24/outline";
import ProductCard from "./shared/ProductCard";
import { Input, Option, Select } from "@material-tailwind/react";
import ShopBanner from "./shared/ShopBanner";
import CategoryService from "../../shared/services/CategoryService";
import { useQuery } from "@tanstack/react-query";
import ProductService from "../../shared/services/ProductService";

const ShopPage = () => {
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
      name,
      toPrice,
      fromPrice,
      categoryId,
      sortType,
    ],
    queryFn: async (context) => {
      return ProductService.GetShop(context);
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
  };

  return (
    <>
      <ShopBanner />
      <div className="mt-10">
        <div className=" flex flex-col items-center justify-between gap-4 md:flex-row mb-10">
          <div className="w-full">
            <Select label="Danh mục" onChange={(e) => setCategoryId(e)}>
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
            <Select label="Sắp xếp" onChange={(e) => setSortType(e)}>
              <Option value="">Mặc định</Option>
              <Option value="name-asc">Tên: A - Z</Option>
              <Option value="name-desc">Tên: Z - A</Option>
              <Option value="price-asc">Giá: Tăng dần</Option>
              <Option value="price-desc">Giá: Giảm dần</Option>
              <Option value="new">Mới nhất</Option>
              <Option value="old">Cũ nhất</Option>
              <Option value="order">Bán chạy nhất</Option>
              <Option value="inventory">Tồn kho giảm dần</Option>
            </Select>
          </div>
          <div className="w-full">
            <Input
              label="Search"
              onChange={(e) => setName(e.target.value)}
              icon={<MagnifyingGlassIcon className="h-5 w-5" />}
            />
          </div>
        </div>
      </div>
      <div className="list">
        <div className="grid grid-cols-4 gap-3">
          {productQuery.data?.length === 0 ? (
            <p className="text p-3 mt-3 font-semibold">
              Không tìm thấy sản phẩm nào cạ !!
            </p>
          ) : (
            productQuery.data?.map((item) => {
              return <ProductCard key={item.id} item={item} />;
            })
          )}
        </div>
      </div>
    </>
  );
};

export default ShopPage;
