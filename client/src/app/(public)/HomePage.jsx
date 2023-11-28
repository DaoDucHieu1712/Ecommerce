import { Carousel } from "@material-tailwind/react";
import React from "react";

const HomePage = () => {
  return (
    <>
      <Carousel
        className="rounded-xl"
        transition={{ duration: 1 }}
        autoplay={true}
      >
        <img
          src="https://file.hstatic.net/1000281824/file/mkh12127_copy_240c3a7f482344cfae6cdabdf0e99811.jpg"
          alt="image 1"
          className="h-full w-full object-cover"
        />
        <img
          src="https://file.hstatic.net/1000281824/file/z4515045070084_0909283f3004b66af6ddc3e79eb60d57_43c2ea07ec0e4eee91c132648bdf8454.jpg"
          alt="image 1"
          className="h-full w-full object-cover"
        />
        <img
          src="https://file.hstatic.net/1000281824/file/bia_page_4a61b1732c6e49579cef1110c4396b9b.jpg"
          alt="image 2"
          className="h-full w-full object-cover"
        />
        <img
          src="https://file.hstatic.net/1000281824/file/ee400e442f6df233ab7c1_eba88f00fdbe433280b9b76ab933c391.jpg"
          alt="image 3"
          className="h-full w-full object-cover"
        />
      </Carousel>
    </>
  );
};

export default HomePage;
