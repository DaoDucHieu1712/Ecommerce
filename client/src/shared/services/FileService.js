import axios from "axios";
import axiosConfig from "./AxiosConfig";

const FileService = {
  async UploadFile(formdata) {
    return await axios({
      method: "post",
      url:
        process.env.REACT_APP_BE_BASE_API_URL_HTTPS + "/api/File/UploadImage",
      data: formdata,
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  },
  async RemoveFile(pathId) {
    const url = "/api/File/DeleteImage/" + pathId;
    return axiosConfig.delete(url);
  },
};

export default FileService;
