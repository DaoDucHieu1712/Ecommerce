import React from "react";
import PieChartOrder from "./shared/components/dashboard/PieChartOrder";
import DashboardCountData from "./shared/components/dashboard/DashboardCountData";

const ReportPage = () => {
  return (
    <>
      <h1 className="font-medium uppercase text-xl">Degrey Shop báo cáo </h1>
      <div className="my-7">
        <DashboardCountData />
      </div>
      <div className="p-3">
        <PieChartOrder />
      </div>
    </>
  );
};

export default ReportPage;
