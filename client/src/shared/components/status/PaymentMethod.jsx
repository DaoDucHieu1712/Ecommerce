import propTypes from "prop-types";

let statusName = "";

const PaymentMethod = ({ method }) => {
  if (method === 1) {
    statusName = "Thanh toán khi nhận hàng";
  }
  if (method === 2) {
    statusName = "Chuyển khoản";
  }

  return <span className={` text-xs rounded-lg  ${method}`}>{statusName}</span>;
};

PaymentMethod.propTypes = {
  status: propTypes.any.isRequired,
};

export default PaymentMethod;
