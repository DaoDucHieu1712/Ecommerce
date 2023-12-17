import axiosConfig from "./AxiosConfig";

const OrderService = {
  async CreateOrder(data) {
    const url = "/api/Order/CreateOrder";
    return axiosConfig.post(url, data);
  },
  async FindById(id) {
    const url = "/api/Order/FindById/" + id;
    return axiosConfig.get(url);
  },
  async UpdateStatus(id, status) {
    const url = `/api/Order/UpdateStatus/${id}?status=${status}`;
    return axiosConfig.put(url);
  },
  async UpdatePayment(id, status) {
    const url = `/api/Order/UpdatePaymentStatus/${id}?status=${status}`;
    return axiosConfig.put(url);
  },
  async GetAllOrder(ctx) {
    const url =
      `/api/Order/GetAllOrder?` +
      `PageIndex=${ctx.queryKey[1]}&` +
      `PageSize=${ctx.queryKey[2]}&` +
      `OrderId=${ctx.queryKey[3]}&` +
      `CustomerName=${ctx.queryKey[4]}&` +
      `StartDate=${ctx.queryKey[5]}&` +
      `EndDate=${ctx.queryKey[6]}&` +
      `Status=${ctx.queryKey[7]}&` +
      `SortType=${ctx.queryKey[8]}` +
      ``;
    return axiosConfig.get(url);
  },
  async MyOrder(ctx) {
    const url =
      `/api/Order/MyOrder?` +
      `PageIndex=${ctx.queryKey[1]}&` +
      `PageSize=${ctx.queryKey[2]}&` +
      `OrderId=${ctx.queryKey[3]}&` +
      `CustomerName=${ctx.queryKey[4]}&` +
      `StartDate=${ctx.queryKey[5]}&` +
      `EndDate=${ctx.queryKey[6]}&` +
      `Status=${ctx.queryKey[7]}&` +
      `SortType=${ctx.queryKey[8]}` +
      ``;
    return axiosConfig.get(url);
  },
};

export default OrderService;
