import axiosConfig from "./AxiosConfig";

const DiscountService = {
  async GetAll() {
    const url = "/api/Discount/GetAll";
    return axiosConfig.get(url);
  },
  async Create(data) {
    const url = "/api/Discount/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = `/api/Discount/Update/${id}`;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = `/api/Discount/Delete/${id}`;
    return axiosConfig.put(url);
  },
  async Check(code) {
    const url = `/api/Discount/CheckDiscount/${code}`;
    return axiosConfig.get(url);
  },
  async UseDiscount(code) {
    const url = `/api/Discount/UseDiscount/${code}`;
    return axiosConfig.get(url);
  },
};

export default DiscountService;
