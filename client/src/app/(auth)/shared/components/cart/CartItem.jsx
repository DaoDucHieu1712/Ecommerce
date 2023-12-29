import React from "react";
import DeleteIcon from "../../../../../shared/components/icon/DeleteIcon";
import CartService from "../../../../../shared/services/CartService";
import { toast } from "react-toastify";

const CartItem = ({ item, reload }) => {
  const InscreaseQuantityHandler = async () => {
    await CartService.IncreaseQuantity(item.id)
      .then((res) => {
        reload();
      })
      .catch((err) => toast.error(err.response.data));
  };

  const DescreaseQuantityHandler = async () => {
    await CartService.DescreaseQuantity(item.id).then((res) => {
      reload();
    });
  };

  const RemoveCartItem = async () => {
    await CartService.RemoveCartItem(item.id).then((res) => {
      reload();
    });
  };

  return (
    <>
      <tr>
        <td className="p-4 border-b border-blue-gray-50 flex items-center gap-x-2">
          <div onClick={RemoveCartItem}>
            <DeleteIcon></DeleteIcon>
          </div>

          <img src={item.productImage} alt="" className="w-[70px] h-16" />
          <span>{item.productName}</span>
        </td>
        <td className="p-4 border-b border-blue-gray-50">{item.type}</td>
        <td className="p-4 border-b border-blue-gray-50">
          {item.unitPrice} VND
        </td>
        <td className="p-4 border-b border-blue-gray-50">
          <div className="flex items-center justify-between border p-2">
            <span
              className="text-gray-500 text-3xl font-medium cursor-pointer"
              onClick={DescreaseQuantityHandler}
            >
              -
            </span>
            <p>{item.quantity}</p>
            <span
              className="text-3xl font-medium cursor-pointer"
              onClick={InscreaseQuantityHandler}
            >
              +
            </span>
          </div>
        </td>
        <td className="p-4 border-b border-blue-gray-50">
          {item.unitPrice * item.quantity} VND
        </td>
      </tr>
    </>
  );
};

export default CartItem;
