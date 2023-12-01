import axiosConfig from "./AxiosConfig";

const ColorService = {
  async GetAll() {
    const url = "/api/Color/GetAll";
    return axiosConfig.get(url);
  },
  async Create(data) {
    const url = "/api/Color/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = "/api/Color/Update/" + id;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = "/api/Color/Remove/" + id;
    return axiosConfig.put(url);
  },
};

export default ColorService;
