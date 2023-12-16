import axiosConfig from "./AxiosConfig";

const OrderService = {
  async CreateOrder(data) {
    const url = "/api/Order/CreateOrder";
    return axiosConfig.post(url, data);
  },
};

export default OrderService;
