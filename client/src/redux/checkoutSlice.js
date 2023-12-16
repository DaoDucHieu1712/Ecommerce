import { createSlice } from "@reduxjs/toolkit";

const checkout_foody_system = "aqoewqweqwefriqwrqmwrqwqfjqwnefq";

const checkoutLocal = JSON.parse(
  localStorage.getItem(checkout_foody_system) || "{}"
);

const CheckoutSlice = createSlice({
  name: "checkout",
  initialState: { info: checkoutLocal },
  reducers: {
    SetInfo: (state, action) => {
      state.info = action.payload;
      localStorage.setItem(checkout_foody_system, JSON.stringify(state.info));
    },
  },
});

export const checkoutActions = CheckoutSlice.actions;
export const checkoutSelector = (state) => state.chat;
export const checkoutReducer = CheckoutSlice.reducer;
export default checkoutReducer;
