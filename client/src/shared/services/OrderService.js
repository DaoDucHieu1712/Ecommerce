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
  async FindByIdByAdmin(id) {
    const url = "/api/Order/FindByIdByAdmin/" + id;
    return axiosConfig.get(url);
  },
  async UpdateStatus(id, status, reason) {
    const url = `/api/Order/UpdateStatus/${id}?status=${status}&reason=${reason}`;
    return axiosConfig.put(url);
  },
  async UpdatePayment(id, method, status) {
    const url = `/api/Order/UpdatePayment/${id}?method=${method}&status=${status}`;
    return axiosConfig.put(url);
  },
  async CreatePayment(data) {
    const url = `/api/Order/GetUrlPayment`;
    return axiosConfig.post(url, data);
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
