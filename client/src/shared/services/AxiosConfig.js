import axios from "axios";
import CookieService from "../helpers/CookieHelper";

const AccessToken = process.env.REACT_APP_ECO_TOKEN;

const instance = axios.create({
  baseURL: process.env.REACT_APP_BE_BASE_API_URL_HTTPS,
  headers: {
    "Content-Type": "application/json",
  },
});

//set Authorization when logged in
instance.interceptors.request.use(function (config) {
  const token = CookieService.getCookie(AccessToken);
  if (token === undefined) {
    config.headers.Authorization = "";
  } else {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Add a response interceptor
instance.interceptors.response.use(
  async function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return response.data;
  },
  async function (error) {
    const prevRequest = error.config;
    // anthentication
    if (error?.response?.status === 401 && !prevRequest.sent) {
      window.location.href = "/login";
    }

    if (error?.response?.status === 403 && !prevRequest.sent) {
      window.location.href = "/access-denied";
    }

    if (error?.response?.status === 404 && !prevRequest.sent) {
      window.location.href = "/not-found";
    }
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    return Promise.reject(error);
  }
);

export default instance;
