import axiosConfig from "./AxiosConfig";

const AuthService = {
  async Login(data) {
    const url = "/api/User/Login";
    return axiosConfig.post(url, data);
  },
  async Register(data) {
    const url = "/api/User/Register";
    return axiosConfig.post(url, data);
  },
  async GetCurrentUser() {
    const url = "/api/User/GetCurrentUser";
    return axiosConfig.get(url);
  },
};

export default AuthService;
