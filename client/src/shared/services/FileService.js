import axios from "axios";
import axiosConfig from "./AxiosConfig";

const FileService = {
  async UploadFile(formdata) {
    const res = await axios({
      method: "post",
      url:
        process.env.REACT_APP_BE_BASE_API_URL_HTTPS + "/api/File/UploadImage",
      data: formdata,
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return res.data;
  },
  async RemoveFile(path) {
    const url = "/api/File/DeleteImage/" + path;
    return axiosConfig.delete(url);
  },
};

export default FileService;
