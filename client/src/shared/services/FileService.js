import axios from "axios";

const FileService = {
  async UploadFile(formdata) {
    return await axios({
      method: "post",
      url: "http://103.184.112.229:1000/api/File/UploadImage",
      data: formdata,
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  },
  async RemoveFile(pathId) {
    // const url = "/api/File/DeleteImage/" + pathId;
    return await axios({
      method: "delete",
      url: `http://103.184.112.229:1000/api/File/UploadImage/${pathId}`,
      headers: {
        "Content-Type": "application/json",
      },
    });
  },
};

export default FileService;
