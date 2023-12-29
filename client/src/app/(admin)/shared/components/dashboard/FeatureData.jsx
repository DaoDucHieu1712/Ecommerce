import React from "react";

const FeatureData = ({ name, total }) => {
  return (
    <div className="border shadow-lg rounded-lg  p-3 flex flex-col items-center justify-between gap-y-3">
      <p className="text-xl font-bold text center mt-6 uppercase">{name}</p>
      <p className="text-end font-medium mt-4 text-lg">{total}</p>
    </div>
  );
};

export default FeatureData;
