import axiosConfig from "./AxiosConfig";

const InventoryService = {
  async GetAll() {
    const url = "/api/Inventory/GetAll";
    return axiosConfig.get(url);
  },
  async Create(data) {
    const url = "/api/Inventory/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = "/api/Inventory/Update/" + id;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = "/api/Inventory/Remove/" + id;
    return axiosConfig.put(url);
  },
  async GetAllByProductId(id) {
    const url = "/api/Inventory/GetAllByProductId/" + id;
    return axiosConfig.get(url);
  },
  async AddQuantity(id, quantity) {
    const url = `/api/Inventory/AddQuantity/${id}?quantity=${quantity}`;
    return axiosConfig.get(url);
  },
};

export default InventoryService;
