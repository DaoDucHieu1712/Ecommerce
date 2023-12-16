import { useEffect, useState } from "react";
import CartService from "../services/CartService";

export default function useCart() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState();
  const [cart, setCart] = useState();

  useEffect(() => {
    fetchCart();
  }, []);

  const fetchCart = async () => {
    setLoading(true);
    await CartService.GetCart()
      .then((res) => {
        setCart(res);
        setLoading(false);
      })
      .catch((err) => setError(err));
  };

  return { cart, loading, error, fetchCart };
}
