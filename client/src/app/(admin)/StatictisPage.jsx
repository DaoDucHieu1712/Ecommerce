import React, { useEffect, useState } from "react";
import {
  BarElement,
  CategoryScale,
  Chart as ChartJS,
  Legend,
  LinearScale,
  Title,
  Tooltip,
} from "chart.js";
import DashboardService from "../../shared/services/DashboardService";
import { Bar } from "react-chartjs-2";
import { Option, Select } from "@material-tailwind/react";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);
const StatictisPage = () => {
  const [chart, setChart] = useState();
  const [year, setYear] = useState(2023);
  useEffect(() => {
    fetchData();
  }, [year]);
  const fetchData = async () => {
    await DashboardService.GetChart(year)
      .then((res) => {
        setChart(res);
      })
      .catch((err) => {
        console.log(err.response.data);
      });
  };

  if (!chart || chart.length === 0) {
    return <div>Loading...</div>; // or some other loading state
  }

  var data = {
    labels: chart.map((entry) => entry.month),
    datasets: [
      {
        label: `Doanh thu`,
        data: chart.map((entry) => entry.revenue.toString()),
        backgroundColor: "rgba(255, 159, 64, 0.5)",
        borderColor: "rgba(255, 159, 64, 1)",
        borderWidth: 1,
      },
    ],
  };

  var options = {
    maintainAspectRatio: false,
    scales: {
      y: {
        suggestedMax: Math.max(...chart.map((entry) => entry.revenue)) + 300000, // Adjust the value as needed
        title: {
          display: true,
          text: "(VND)",
          font: {
            size: 12,
            style: "normal",
            lineHeight: 1.2,
          },
          padding: { top: 0, left: 30, right: 0, bottom: 0 },
          position: "left", // Display the title to the left of the y-axis labels
        },
      },
    },
    legend: {
      labels: {
        fontSize: 25,
      },
    },
  };

  return (
    <>
      <div className="flex items-center justify-center p-3 my-9">
        <div className="w-10">
          <Select label="Năm" onChange={(e) => setYear(e)}>
            <Option value="2023">2023</Option>
            <Option value="2024">2024</Option>
            <Option value="2025">2025</Option>
            <Option value="2026">2026</Option>
            <Option value="20237">2027</Option>
          </Select>
        </div>
      </div>
      <div className="h-[700px] p-3">
        <Bar data={data} height={400} options={options} />
      </div>
    </>
  );
};

export default StatictisPage;
