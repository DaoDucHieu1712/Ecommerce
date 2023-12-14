import { Button } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React from "react";
import { useParams } from "react-router-dom";
import ProductService from "../../shared/services/ProductService";
import ProductCard from "./shared/ProductCard";

const ProductDetail = () => {
  const { id } = useParams();

  const productQuery = useQuery({
    queryKey: ["product-detail"],
    queryFn: async () => {
      return ProductService.FindById(id);
    },
  });

  const recommendQuery = useQuery({
    queryKey: ["products-recomment"],
    queryFn: async () => {
      return ProductService.GetProductRecommend(id);
    },
  });

  return (
    <>
      <div className="grid grid-cols-2 gap-10">
        <div className="flex items-center justify-center">
          <img src={productQuery.data?.imageUrl} alt="" className="h-[650px]" />
        </div>
        <div className="flex flex-col gap-y-6">
          <h1 className="text-2xl font-medium uppercase">
            {productQuery.data?.name}
          </h1>
          <p className="text-xl">
            Giá :{" "}
            <span className="text-xl text-red-500 font-medium">
              {productQuery.data?.price} VND
            </span>
          </p>
          <p className="text-xl">
            Tình trạng :{" "}
            {productQuery.data?.quantity > 0 ? (
              <span className="text-green-500 font-medium">còn hàng</span>
            ) : (
              <span className="text-red-500 font-medium">hết hàng</span>
            )}
          </p>
          <p className="text-xl">
            Thông tin :
            <span className="ml-3 text-base text-gray-700">
              {productQuery.data?.description}
            </span>
          </p>
          <div className="border-b pb-6">
            <h1 className="mb-6 text-xl">Phân loại :</h1>
            <div className="flex gap-2 flex-wrap">
              {productQuery.data?.inventories.map((item) => {
                return (
                  <span className="p-2 border border-gray-500 rounded-md">
                    {item.inventoryName}
                  </span>
                );
              })}
            </div>
          </div>
          <div className="mb-2">
            <Button>Thêm vào giỏ hàng</Button>
          </div>
          <div className="flex gap-x-3">
            <div className="p-3 bg-gray-300 shadow-sm">
              Freeship đơn hàng giá trị trên 1 triệu đồng
            </div>
            <div className="p-3 bg-gray-300 shadow-sm">
              Đổi hàng chưa qua sử dụng trong vòng 30 ngày
            </div>
          </div>
        </div>
      </div>
      <div className="mt-16 p-3">
        <h1 className="text-xl font-medium uppercase mb-6">
          Sản phẩm liên quan
        </h1>
        <div className="grid grid-cols-4 gap-4">
          {recommendQuery.data?.length === 0 && (
            <p className="mt-3">Chưa có sản phẩm liên quan !!</p>
          )}
          {recommendQuery.data?.map((item) => {
            return <ProductCard key={item.id} item={item} />;
          })}
        </div>
      </div>
    </>
  );
};

export default ProductDetail;
