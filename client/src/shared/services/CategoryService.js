import axiosConfig from "./AxiosConfig";

const CategoryService = {
  async GetAll() {
    const url = "/api/Category/GetAll";
    return axiosConfig.get(url);
  },
  async GetAllByAdmin() {
    const url = "/api/Category/GetAllByAdmin";
    return axiosConfig.get(url);
  },
  async Create(data) {
    const url = "/api/Category/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = "/api/Category/Update/" + id;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = "/api/Category/Remove/" + id;
    return axiosConfig.put(url);
  },
};

export default CategoryService;
