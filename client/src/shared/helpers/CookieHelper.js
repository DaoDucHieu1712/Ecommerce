import Cookies from "universal-cookie";

const cookies = new Cookies();

export default class CookieService {
  static saveCookie(name, value, expires) {
    cookies.set(name, value, {
      sameSite: true,
      path: "/",
      expires,
      // domain: import.meta.env.VITE_ENV === "dev" ? "" : import.meta.env.VITE_SUB_DOMAIN,
    });
  }
  static getCookie(name) {
    return cookies.get(name);
  }

  static removeCookie(name) {
    cookies.remove(name, { path: "/" });
  }
}
