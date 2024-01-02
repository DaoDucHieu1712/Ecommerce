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
  async ForgetPassword(email) {
    const url = `/api/User/ForgetPassword/${email}`;
    return axiosConfig.get(url);
  },
  async ResetPassword(data) {
    const url = `/api/User/ResetPassword`;
    return axiosConfig.post(url, data);
  },
  async ChangePassword(data) {
    const url = `/api/User/ChangePassword`;
    return axiosConfig.post(url, data);
  },
  async ConfirmEmail(userId, code) {
    const url = `/api/User/ConfirmEmail?userId=${userId}&code=${code}`;
    return axiosConfig.get(url);
  },
  async CheckRole() {
    const url = "/api/User/CheckRole";
    return axiosConfig.get(url);
  },
};

export default AuthService;
