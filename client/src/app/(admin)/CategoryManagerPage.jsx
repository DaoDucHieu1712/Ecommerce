import { Card, Spinner, Typography } from "@material-tailwind/react";
import { useQuery } from "@tanstack/react-query";
import React from "react";
import CategoryService from "../../shared/services/CategoryService";
import AddCategory from "./shared/components/category/AddCategory";
import UpdateCategory from "./shared/components/category/UpdateCategory";
import DeleteCategory from "./shared/components/category/DeleteCategory";

const TABLE_HEAD = ["ID", "Tên", "Mô tả", ""];

const CategoryManagerPage = () => {
  const categoryQuery = useQuery({
    queryKey: ["category-admin-list"],
    queryFn: async () => {
      return CategoryService.GetAllByAdmin();
    },
  });

  return (
    <>
      <div className="my-6">
        <h1 className="uppercase text-lg font-medium">Quản lý danh mục</h1>
      </div>
      <div className="mb-6">
        <AddCategory reload={categoryQuery.refetch} />
      </div>
      {categoryQuery.isLoading ? (
        <Spinner />
      ) : (
        <Card className="h-full w-full">
          <table className="w-full min-w-max table-auto text-left">
            <thead>
              <tr>
                {TABLE_HEAD.map((head) => (
                  <th
                    key={head}
                    className="border-b border-blue-gray-100 bg-blue-gray-50 p-4"
                  >
                    <Typography
                      variant="small"
                      color="blue-gray"
                      className="font-normal leading-none opacity-70"
                    >
                      {head}
                    </Typography>
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              {categoryQuery.data?.map((item) => (
                <tr key={item.id} className="even:bg-blue-gray-50/50">
                  <td className="p-4">
                    <Typography
                      variant="small"
                      color="blue-gray"
                      className="font-normal"
                    >
                      {item.id}
                    </Typography>
                  </td>
                  <td className="p-4">
                    <Typography
                      variant="small"
                      color="blue-gray"
                      className="font-normal"
                    >
                      {item.name}
                    </Typography>
                  </td>
                  <td className="p-4">
                    <Typography
                      variant="small"
                      color="blue-gray"
                      className="font-normal"
                    >
                      {item.description}
                    </Typography>
                  </td>
                  <td className="p-4 flex gap-x-3">
                    <UpdateCategory
                      item={item}
                      reload={categoryQuery.refetch}
                    />
                    <DeleteCategory
                      item={item}
                      reload={categoryQuery.refetch}
                    />
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </Card>
      )}
    </>
  );
};

export default CategoryManagerPage;
