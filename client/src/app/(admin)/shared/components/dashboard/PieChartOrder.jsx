import React, { useEffect, useState } from "react";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Pie } from "react-chartjs-2";
import DashboardService from "../../../../../shared/services/DashboardService";

ChartJS.register(ArcElement, Tooltip, Legend);

const PieChartOrder = () => {
  const [chart, setChart] = useState();

  const GetStatictisHandler = async () => {
    await DashboardService.GetOrderStatictis().then((res) => setChart(res));
  };

  useEffect(() => {
    GetStatictisHandler();
  }, []);

  if (!chart) {
    return <div>Loading...</div>; // or some other loading state
  }

  const data = {
    labels: chart.map((item) => item.status),
    datasets: [
      {
        label: "Báo cáo đơn hàng",
        data: chart.map((item) => `${item.percent}`),
        backgroundColor: ["blue", "orange", "green", "red"],
        borderColor: ["blue", "orange", "green", "red"],
        borderWidth: 1,
      },
    ],
  };

  return (
    <>
      <div className="w-[350px] shadow-md flex flex-col justify-center items-center">
        <div className="flex item-center justify-center">
          <div className="my-3 font-medium">Báo cáo đơn hàng theo tỉ lệ %</div>
        </div>
        <div className="p-3">
          <Pie data={data} />
        </div>
      </div>
    </>
  );
};

export default PieChartOrder;
