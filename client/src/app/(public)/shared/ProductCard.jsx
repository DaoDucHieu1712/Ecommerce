import {
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Typography,
} from "@material-tailwind/react";
import React from "react";
import { Link } from "react-router-dom";

const ProductCard = ({ item }) => {
  return (
    <>
      <Card>
        <CardHeader shadow={false} floated={false} className="h-80">
          <img
            src={item.imageUrl}
            alt="card-image"
            className="h-full w-full object-cover"
          />
        </CardHeader>
        <CardBody>
          <div className="mb-2 flex items-center justify-between">
            <Typography color="blue-gray" className="font-medium">
              {item.name}
            </Typography>
            <Typography color="blue-gray" className="font-medium">
              {item.price} VND
            </Typography>
          </div>
          <Typography
            variant="small"
            color="gray"
            className="font-normal opacity-75"
          >
            {item.description}
          </Typography>
        </CardBody>
        <CardFooter className="pt-0">
          <a href={`/shop/product/${item.id}`}>
            <Button
              ripple={false}
              fullWidth={true}
              className="bg-blue-gray-900/10 text-blue-gray-900 shadow-none hover:scale-105 hover:shadow-none focus:scale-105 focus:shadow-none active:scale-100"
            >
              Xem
            </Button>
          </a>
        </CardFooter>
      </Card>
    </>
  );
};

export default ProductCard;
