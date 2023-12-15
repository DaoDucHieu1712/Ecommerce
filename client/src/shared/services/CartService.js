import axiosConfig from "./AxiosConfig";

const AuthService = {
  async GetCart() {
    const url = "/api/Cart/GetCart";
    return axiosConfig.get(url);
  },
  async AddToCart(data) {
    const url = "api/Cart/AddToCart";
    return axiosConfig.post(url, data);
  },
};

export default AuthService;
