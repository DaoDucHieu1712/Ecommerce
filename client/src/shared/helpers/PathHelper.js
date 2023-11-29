const GetPathId = (url = "") => {
  return url.split("\\")[url.split("\\").length - 1].split(".")[0];
};

export default GetPathId;
