import { lazy } from "react";
import { Route, Routes } from "react-router-dom";
import Layout from "./app/shared/Layout";
import DashboardLayout from "./app/shared/DashboardLayout";
import LoginPage from "./app/(public)/LoginPage";
import RegisterPage from "./app/(public)/RegisterPage";
import ProductDetail from "./app/(public)/ProductDetail";
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

        </Route>
        <Route element={<DashboardLayout />}>
          <Route path="/admin/category" element={<CategoryManagerPage />} />
          <Route path="/admin/product" element={<ProductManagerPage />} />
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
