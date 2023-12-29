import { useQuery } from "@tanstack/react-query";
import React from "react";
import DashboardService from "../../../../../shared/services/DashboardService";
import FeatureData from "./FeatureData";

const DashboardCountData = () => {
  const dashboard = useQuery({
    queryKey: ["dashboard-total"],
    queryFn: async () => {
      return DashboardService.StatictisCount();
    },
  });
  return (
    <>
      <div className="grid grid-cols-4 gap-x-4">
        <FeatureData name="Sản phẩm" total={dashboard.data?.productCount} />
        <FeatureData name="Đơn hàng" total={dashboard.data?.orderCount} />
        <FeatureData name="Danh mục" total={dashboard.data?.categoryCount} />
        <FeatureData name="Kho" total={dashboard.data?.inventoryCount} />
      </div>
    </>
  );
};

export default DashboardCountData;
