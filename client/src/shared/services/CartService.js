import axiosConfig from "./AxiosConfig";

const AuthService = {
  async GetCart() {
    const url = "/api/Cart/GetCart";
    return axiosConfig.get(url);
  },
  async AddToCart(data) {
    const url = "/api/Cart/AddToCart";
    return axiosConfig.post(url, data);
  },
  async IncreaseQuantity(id) {
    const url = "/api/Cart/IncreaseQuantityCartItem/" + id;
    return axiosConfig.get(url);
  },
  async DescreaseQuantity(id) {
    const url = "/api/Cart/DecreseaQuantityCartItem/" + id;
    return axiosConfig.get(url);
  },
  async RemoveCartItem(id) {
    const url = `/api/Cart/RemoveCartItem/${id}`;
    return axiosConfig.delete(url);
  },
  async ClearCart(){
    
  }
};

export default AuthService;
