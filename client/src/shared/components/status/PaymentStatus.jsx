import propTypes from "prop-types";

let classes = "";
let statusName = "";

const PaymentStatus = ({ status }) => {
  if (status == null) {
    classes = "";
    statusName = "";
  }
  if (status === 1) {
    classes = "text-orange-500";
    statusName = "Chưa thanh toán";
  }
  if (status === 2) {
    classes = "text-green-500";
    statusName = "Đã Thanh toán";
  }
  if (status === 3) {
    classes = "text-red-600";
    statusName = "Đã hủy";
  }

  return (
    <span className={`font-semibold text-xs rounded-lg ${classes} ${status}`}>
      {statusName}
    </span>
  );
};

PaymentStatus.propTypes = {
  status: propTypes.any.isRequired,
};

export default PaymentStatus;
