import React, { useEffect, useRef, useState } from "react";
import FileService from "../../services/FileService";
import GetPathId from "../../helpers/PathHelper";

const UpdateFile = ({ name, setValue, rootUrl = "" }) => {
  const inputRef = useRef(null);
  const [img, setImg] = useState("");
  const [resource, setResource] = useState();
  const [url, setUrl] = useState("");

  const handleImageClick = () => {
    inputRef.current.click();
  };

  useEffect(() => {
    setValue(name, rootUrl);
  }, []);

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
    <>
      <div className="flex flex-col gap-y-3 items-center justify-center">
        {img ? (
          <img
            src={URL.createObjectURL(img)}
            className="w-[300px] h-[250px] object-cover"
            alt=""
          />
        ) : (
          <img
            src={rootUrl}
            alt=""
            className="w-[300px] h-[250px] object-cover"
          />
        )}
        <input type="file" ref={inputRef} onChange={handleImageChange} />
      </div>
    </>
  );
};

export default UpdateFile;
