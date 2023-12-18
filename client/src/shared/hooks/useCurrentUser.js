import { useEffect, useState } from "react";
import AuthService from "../services/AuthService";

export default function useCurrentUser() {
  const [user, setUser] = useState();
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState();

  const GetCurrentUserHandler = async () => {
    setLoading(true);
    await AuthService.GetCurrentUser()
      .then((res) => {
        setUser(res);
        setLoading(false);
      })
      .catch((err) => setError(err.response.data));
  };
  useEffect(() => {
    GetCurrentUserHandler();
  }, []);

  return { user, loading, error };
}
