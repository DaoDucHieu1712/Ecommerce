import axiosConfig from "./AxiosConfig";

const ProductService = {
  async GetAll() {
    const url = "/api/Product/GetAll";
    return axiosConfig.get(url);
  },

  async Create(data) {
    const url = "/api/Product/Create";
    return axiosConfig.post(url, data);
  },
  async Update(id, data) {
    const url = "/api/Product/Update/" + id;
    return axiosConfig.put(url, data);
  },
  async Delete(id) {
    const url = "/api/Product/Remove/" + id;
    return axiosConfig.put(url);
  },
  async FindById(id) {
    const url = "/api/Product/FindById/" + id;
    return axiosConfig.get(url);
  },
  async GetProductRecommend(id) {
    const url = "/api/Product/GetProductRecommend/" + id;
    return axiosConfig.get(url);
  },
  async Filter(ctx) {
    const url =
      `/api/Product/Filter?` +
      `PageIndex=${ctx.queryKey[1]}&` +
      `Name=${ctx.queryKey[2]}&` +
      `ToPrice=${ctx.queryKey[3]}&` +
      `FromPrice=${ctx.queryKey[4]}&` +
      `CategoryId=${ctx.queryKey[5]}&` +
      `SortType=${ctx.queryKey[6]}` +
      ``;
    return axiosConfig.get(url);
  },
  async GetShop(ctx) {
    const url =
      "/api/Product/Shop?" +
      `Name=${ctx.queryKey[1]}&` +
      `ToPrice=${ctx.queryKey[2]}&` +
      `FromPrice=${ctx.queryKey[3]}&` +
      `CategoryId=${ctx.queryKey[4]}&` +
      `SortType=${ctx.queryKey[5]}` +
      ``;
    return axiosConfig.get(url);
  },
};

export default ProductService;
