import { lazy } from "react";
import { Route, Routes } from "react-router-dom";
const NotFoundPage = lazy(() => import("./app/(public)/NotFoundPage"));
const AccessDeniedPage = lazy(() => import("./app/(public)/AccessDeniedPage"));

function App() {
  console.log(process.env.REACT_APP_ECO_TEST);
  return (
    <>
      <Routes>
        <Route path="*" element={<NotFoundPage />} />
        <Route path="/access-denied" element={<AccessDeniedPage />} />
      </Routes>
    </>
  );
}
export default App;
