import React from "react";
import DeleteIcon from "../../../../../shared/components/icon/DeleteIcon";

const CartItem = () => {
  return (
    <>
      <tr>
        <td className="p-4 border-b border-blue-gray-50 flex items-center gap-x-2">
          <div>
            <DeleteIcon></DeleteIcon>
          </div>

          <img
            src="https://source.unsplash.com/random"
            alt=""
            className="w-[70px] h-16"
          />
          <span>Product Test</span>
        </td>
        <td className="p-4 border-b border-blue-gray-50">xl</td>
        <td className="p-4 border-b border-blue-gray-50">300000 VND</td>
        <td className="p-4 border-b border-blue-gray-50">
          <div className="flex items-center justify-between border p-2">
            <span className="text-gray-500 text-3xl font-medium cursor-pointer">
              -
            </span>
            <p>3</p>
            <span className="text-3xl font-medium cursor-pointer">+</span>
          </div>
        </td>
        <td className="p-4 border-b border-blue-gray-50">300000 VND</td>
      </tr>
    </>
  );
};

export default CartItem;
