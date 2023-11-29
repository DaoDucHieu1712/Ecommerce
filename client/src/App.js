import { lazy } from "react";
import { Route, Routes } from "react-router-dom";
import Layout from "./app/shared/Layout";
import DashboardLayout from "./app/shared/DashboardLayout";
import CategoryManagerPage from "./app/(admin)/CategoryManagerPage";
import UploadFile from "./shared/components/form/UploadFile";
const ProductManagerPage = lazy(() =>
  import("./app/(admin)/ProductManagerPage")
);
const NotFoundPage = lazy(() => import("./app/(public)/NotFoundPage"));
const AccessDeniedPage = lazy(() => import("./app/(public)/AccessDeniedPage"));
const HomePage = lazy(() => import("./app/(public)/HomePage"));

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
        </Route>
        <Route path="*" element={<NotFoundPage />} />
        <Route path="/access-denied" element={<AccessDeniedPage />} />
        <Route path="/upload-img" element={<UploadFile />} />
      </Routes>
    </>
  );
}
export default App;
