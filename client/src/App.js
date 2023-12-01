import { lazy } from "react";
import { Route, Routes } from "react-router-dom";
import Layout from "./app/shared/Layout";
import DashboardLayout from "./app/shared/DashboardLayout";
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
function App() {
  return (
    <>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<HomePage />} />
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
        <Route
          path="/upload-img"
          element={
            <>
              <img
                src={
                  "C:\\Users\\ADMIN\\OneDrive\\Desktop\\Git\\Ecommerce\\ECO\\ECO.WebApi\\wwwroot\\uploads\\images\\eb7ccf0a-8a02-4ea5-a05f-3c0a13d06f6d.jpg"
                }
                alt="anh"
              />
            </>
          }
        />
      </Routes>
    </>
  );
}
export default App;
