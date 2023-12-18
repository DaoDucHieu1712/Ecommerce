// import React, { useEffect, useState } from "react";
// import { Chart as ChartJS, BarElement } from "chart.js";

// import DashboardService from "../../shared/services/DashboardService";

// ChartJS.register(BarElement);
// const StatictisPage = () => {
//   const [chart, setChart] = useState();
//   const fetchData = async () => {
//     await DashboardService.GetChart(2023).then((res) => {
//       setChart(res);
//     });
//   };
//   useEffect(() => {
//     fetchData();
//   }, []);

//   var data = {
//     labels: chart.map((entry) => entry.month),
//     datasets: [
//       {
//         label: `Doanh thu`,
//         data: chart.map((entry) => entry.revenue),
//         backgroundColor: "rgba(255, 159, 64, 0.5)",
//         borderColor: "rgba(255, 159, 64, 1)",
//         borderWidth: 1,
//       },
//     ],
//   };

//   var options = {
//     maintainAspectRatio: false,
//     scales: {
//       y: {
//         suggestedMax: Math.max(...chart.map((entry) => entry.revenue)) + 300000, // Adjust the value as needed
//         title: {
//           display: true,
//           text: "(VND)",
//           font: {
//             size: 12,
//             style: "normal",
//             lineHeight: 1.2,
//           },
//           padding: { top: 0, left: 30, right: 0, bottom: 0 },
//           position: "left", // Display the title to the left of the y-axis labels
//         },
//       },
//     },
//     legend: {
//       labels: {
//         fontSize: 25,
//       },
//     },
//   };
//   return (
//     <>
//       <div>{/* <Bar data={data} height={400} options={options} /> */}</div>
//     </>
//   );
// };

// export default StatictisPage;
import React from "react";

const StatictisPage = () => {
  return <div></div>;
};

export default StatictisPage;
