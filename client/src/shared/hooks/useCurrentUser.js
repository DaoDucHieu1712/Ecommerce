import { useEffect, useState } from "react";
import AuthService from "../services/AuthService";

export default function useCurrentUser() {
  const [user, setUser] = useState();

  const GetCurrentUserHandler = async () => {
    await AuthService.GetCurrentUser().then((res) => {
      setUser(res);
    });
  };
  useEffect(() => {
    GetCurrentUserHandler();
  }, []);

  return user;
}
