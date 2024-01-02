import axiosConfig from "./AxiosConfig";

const SizeService = {
  async GetAll() {
    const url = "/api/Size/GetAll";
    return axiosConfig.get(url);
  },
  async GetAllByAdmin() {
    const url = "/api/Size/GetAll";
    return axiosConfig.get(url);
  },
  async Create(data) {
    const url = "/api/Size/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = "/api/Size/Update/" + id;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = "/api/Size/Remove/" + id;
    return axiosConfig.put(url);
  },
};

export default SizeService;
