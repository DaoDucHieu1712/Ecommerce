import axiosConfig from "./AxiosConfig";

const DashboardService = {
  async StatictisCount() {
    const url = "/api/Dashboard/StatictisCount";
    return axiosConfig.get(url);
  },
  async GetChart(year) {
    const url = "/api/Dashboard/GetChartPrice/" + year;
    return axiosConfig.get(url);
  },
};

export default DashboardService;
