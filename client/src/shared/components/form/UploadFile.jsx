import React, { useRef, useState } from "react";
import FileService from "../../services/FileService";
import GetPathId from "../../helpers/PathHelper";

const UploadFile = ({ name, setValue }) => {
  const inputRef = useRef(null);
  const [img, setImg] = useState("");
  const [resource, setResource] = useState();
  const [url, setUrl] = useState("");

  const handleImageClick = () => {
    inputRef.current.click();
  };

  const handleImageChange = async (event) => {
    if (url.length !== 0) {
      await FileService.RemoveFile(resource.pathId);
    }
    const file = event.target.files[0];
    setImg(file);
    const formdata = new FormData();
    formdata.append("fileImage", file);
    await FileService.UploadFile(formdata).then((res) => {
      setResource(res.data);
      setUrl(res.data.url);
      setValue(name, res.data.url);
    });
  };

  return (
    <div className="flex flex-col gap-y-3">
      {img ? (
        <img
          src={URL.createObjectURL(img)}
          className="w-[400px] h-[300px] object-cover"
          alt=""
        />
      ) : (
        <div className="w-[50%] rounded-lg h-[200px] p-3 border border-gray-400"></div>
      )}
      <input type="file" ref={inputRef} onChange={handleImageChange} />
    </div>
  );
};

export default UploadFile;
