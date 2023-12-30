import React from "react";

const OrderItem = ({ item }) => {
  return (
    <>
      <div className="w-full cart-item flex justify-between rounded-lg gap-x-3 p-3 border border-gray-200">
        <div className="flex gap-x-3">
          <img
            src={item.productImage}
            alt=""
            className="w-[100px] object-cover"
          />
          <div className="flex flex-col gap-y-1 text-sm">
            <p className="font-bold w-[300px]">{item.productName}</p>
            <p>{item.unitPrice} VND</p>
            <p>Kiểu loại : {item.type}</p>
          </div>
        </div>
        <div className="flex flex-col gap-y-3">
          <p className="text-sm">{item.unitPrice} VND</p>
          <div className="flex items-center justify-center gap-x-1">
            <button className="">x</button>
            <span>{item.quantity}</span>
          </div>
        </div>
      </div>
    </>
  );
};

export default OrderItem;
