import { configureStore } from "@reduxjs/toolkit";
import checkoutReducer from "./checkoutSlice";

const store = configureStore({
  reducer: {
    checkout: checkoutReducer,
  },
});

export default store;
