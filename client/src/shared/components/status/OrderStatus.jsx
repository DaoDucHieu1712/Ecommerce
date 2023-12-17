import propTypes from "prop-types";

let classes = "";
let statusName = "";

const OrderStatus = ({ status }) => {
  if (status === 1) {
    classes = "bg-blue-500";
    statusName = "Đang chờ";
  }
  if (status === 2) {
    classes = "bg-yellow-900";
    statusName = "Đang giao";
  }
  if (status === 3) {
    classes = "bg-green-600";
    statusName = "Đã Giao hàng";
  }
  if (status === 4) {
    classes = "bg-red-500";
    statusName = "Đã hủy";
  }

  return (
    <span
      className={`font-semibold text-xs text-white rounded-lg px-2 py-1 ${classes} ${status}`}
    >
      {statusName}
    </span>
  );
};

OrderStatus.propTypes = {
  status: propTypes.any.isRequired,
};

export default OrderStatus;
