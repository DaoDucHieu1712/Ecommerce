import { lazy } from "react";
import { Route, Routes } from "react-router-dom";
import Layout from "./app/shared/Layout";
import DashboardLayout from "./app/shared/DashboardLayout";
import LoginPage from "./app/(public)/LoginPage";
import RegisterPage from "./app/(public)/RegisterPage";
import ProductDetail from "./app/(public)/ProductDetail";
import CartPage from "./app/(auth)/CartPage";
import Checkout from "./app/(auth)/Checkout";
import DiscountManagerPage from "./app/(admin)/DiscountManagerPage";
import OrderManagerPage from "./app/(admin)/OrderManagerPage";
import OrderDetailPage from "./app/(admin)/OrderDetailPage";
import MyOrder from "./app/(auth)/MyOrder";
import MyOrderDetail from "./app/(auth)/MyOrderDetail";
const NotFoundPage = lazy(() => import("./app/(public)/NotFoundPage"));
const AccessDeniedPage = lazy(() => import("./app/(public)/AccessDeniedPage"));
const HomePage = lazy(() => import("./app/(public)/HomePage"));
const CategoryManagerPage = lazy(() =>
  import("./app/(admin)/CategoryManagerPage")
);
const ProductManagerPage = lazy(() =>
  import("./app/(admin)/ProductManagerPage")
);
const InventoryManagerPage = lazy(() =>
  import("./app/(admin)/InventoryManagerPage")
);
const ShopPage = lazy(() => import("./app/(public)/ShopPage"));

function App() {
  return (
    <>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
          <Route path="/shop" element={<ShopPage />} />
          <Route path="/shop/product/:id" element={<ProductDetail />} />
          <Route path="/cart" element={<CartPage />} />
          <Route path="/checkout" element={<Checkout />} />
          <Route path="/my-order" element={<MyOrder />} />
          <Route path="/my-order/:id" element={<MyOrderDetail />} />
        </Route>
        <Route element={<DashboardLayout />}>
          <Route path="/admin/category" element={<CategoryManagerPage />} />
          <Route path="/admin/product" element={<ProductManagerPage />} />
          <Route path="/admin/discount" element={<DiscountManagerPage />} />
          <Route path="/admin/order" element={<OrderManagerPage />} />
          <Route path="/admin/order/:id" element={<OrderDetailPage />} />
          <Route
            path="/admin/product/inventory/:id"
            element={<InventoryManagerPage />}
          />
        </Route>
        <Route path="*" element={<NotFoundPage />} />
        <Route path="/access-denied" element={<AccessDeniedPage />} />
      </Routes>
    </>
  );
}
export default App;
