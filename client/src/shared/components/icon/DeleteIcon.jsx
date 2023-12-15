import React from "react";

const DeleteIcon = () => {
  return (
    <div className="cursor-pointer">
      <svg
        width="24"
        height="25"
        viewBox="0 0 24 25"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M12 21.5C16.9706 21.5 21 17.4706 21 12.5C21 7.52944 16.9706 3.5 12 3.5C7.02944 3.5 3 7.52944 3 12.5C3 17.4706 7.02944 21.5 12 21.5Z"
          stroke="#EE5858"
          strokeWidth="1.5"
          strokeMiterlimit="10"
        />
        <path
          d="M15 9.5L9 15.5"
          stroke="#EE5858"
          strokeWidth="1.5"
          strokeLinecap="round"
          strokeLinejoin="round"
        />
        <path
          d="M15 15.5L9 9.5"
          stroke="#EE5858"
          strokeWidth="1.5"
          strokeLinecap="round"
          strokeLinejoin="round"
        />
      </svg>
    </div>
  );
};

export default DeleteIcon;
