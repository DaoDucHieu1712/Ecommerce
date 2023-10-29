using System.Linq.Expressions;

namespace ECO.DataTable
{
    public static class DatatableExtensions
    {
        /// <summary>
        /// Hàm chuyển đổi kết quả từ IQueryable thành DataResult để phục vụ cho DataTables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static DataResult<T> ToDataResult<T>(this IQueryable<T> query, DataRequest request) where T : class
        {

            var result = new DataResult<T>();

            // Xác định thuộc tính khóa chính của kiểu T
            //var key = typeof(T).GetProperties().FirstOrDefault(a => a.CustomAttributes.Any(b => b.AttributeType == typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
            result.RecordsTotal = result.RecordsFiltered = query.Count();

            foreach (var item in request.Filters)
            {
                // Lấy biểu thức tương ứng với điều kiện tìm kiếm
                var exp = GetExpression<T>((Operand)item.Operand, item.Field, item.Value);
                if (exp != null) query = query.Where(exp);
            }

            if (!string.IsNullOrEmpty(request.Search?.Value))
            {
                Expression<Func<T, bool>>? exp = null;
                var listExp = new List<FilterDefinition>();

                foreach (var item in request.Columns.Where(a => a.Searchable))
                {
                    // Tạo biểu thức tương ứng với từng cột có thể tìm kiếm
                    ParameterExpression param = Expression.Parameter(typeof(T), "t");
                    item.Field = GetPropertyByField<T>(item.Field);
                    MemberExpression member = Expression.Property(param, item.Field);
                    var operand = member.Type == typeof(string) ? Operand.Contains : Operand.Equal;
                    listExp.Add(new FilterDefinition { Operand = operand, Field = item.Field, Value = request.Search.Value });
                }

                // Kết hợp các biểu thức tìm kiếm theo chuỗi hoặc
                exp = ExpressionBuilder.GetExpression<T>(listExp);
                if (exp != null) query = query.Where(exp);
            }

            if (!string.IsNullOrEmpty(request.Search?.Value) || request.Filters.Any())
            {
                result.RecordsFiltered = query.Count();
            }

            if (!request.Orders.Any())
            {
                //query = query.OrderBy(request.Columns[0].Field);
            }
            else
            {
                foreach (var item in request.Orders)
                {
                    if (item.Dir == "asc")
                    {
                        query = query.OrderBy(item.Field);
                    }
                    else
                    {
                        query = query.OrderByDescending(item.Field);
                    }
                }
            }

            query = query.Skip(request.Start).Take(request.Length);

            result.Data = query.ToList();
            return result;

        }

        /// <summary>
        /// Lấy ra property chuẩn của kiểu T dựa trên tên field (upper case, lower case)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetPropertyByField<T>(string field)
        {
            return typeof(T).GetProperties().FirstOrDefault(a => a.Name.ToLower() == field.ToLower())?.Name ?? field;
        }

        /// <summary>
        /// Hàm chuyển đổi kết quả từ IQueryable thành CustomDataResult để phục vụ cho DataTables với tính năng tùy chỉnh
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static CustomDataResult<T> ToDataResultCustom<T>(this IQueryable<T> query, CustomDataRequest request) where T : class
        {

            var result = new CustomDataResult<T>();

            try
            {
                result.RecordsTotal = result.RecordsFiltered = query.Count();

                foreach (var item in request.Filters)
                {
                    // Lấy biểu thức tương ứng với điều kiện tìm kiếm
                    var exp = GetExpression<T>((Operand)item.Operand, item.Field, item.Value);
                    if (exp != null) query = query.Where(exp);
                }

                if (!string.IsNullOrEmpty(request.Search?.Value))
                {
                    Expression<Func<T, bool>>? exp = null;
                    var listExp = new List<FilterDefinition>();

                    foreach (var item in request.Columns.Where(a => a.Searchable))
                    {
                        // Tạo biểu thức tương ứng với từng cột có thể tìm kiếm
                        ParameterExpression param = Expression.Parameter(typeof(T), "t");
                        MemberExpression member = Expression.Property(param, item.Field);
                        var operand = member.Type == typeof(string) ? Operand.Contains : Operand.Equal;
                        listExp.Add(new FilterDefinition { Operand = operand, Field = item.Field, Value = request.Search.Value });
                    }

                    // Kết hợp các biểu thức tìm kiếm theo chuỗi hoặc
                    exp = ExpressionBuilder.GetExpression<T>(listExp);
                    if (exp != null) query = query.Where(exp);
                }

                if (!string.IsNullOrEmpty(request.Search?.Value) || request.Filters.Any())
                {
                    result.RecordsFiltered = query.Count();
                }

                // Tính tổng của thuộc tính tùy chỉnh
                if (!string.IsNullOrEmpty(request.GrandTotalProperty))
                {
                    result.GrandTotal = query.SumCreate(request.GrandTotalProperty);
                }

                if (!request.Orders.Any())
                {
                    query = query.OrderBy(request.Columns[0].Field);
                }
                else
                {
                    foreach (var item in request.Orders)
                    {
                        if (item.Dir == "asc")
                        {
                            query = query.OrderBy(item.Field);
                        }
                        else
                        {
                            query = query.OrderByDescending(item.Field);
                        }
                    }
                }

                query = query.Skip(request.Start).Take(request.Length);

                result.Data = query.ToList();
                return result;
            }
            catch
            {
                result.Data = new List<T>();
                return result;
            }
        }

        /// <summary>
        /// Hàm tạo biểu thức cho điều kiện tìm kiếm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operand"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Expression<Func<T, bool>>? GetExpression<T>(Operand operand, string field, string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            field = GetPropertyByField<T>(field);
            return ExpressionBuilder.GetExpression<T>(new FilterDefinition
            {
                Operand = operand,
                Field = field,
                Value = value
            });
        }

        /// <summary>
        /// Hàm sắp xếp theo tên thuộc tính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string memberName)
        {
            return OrderByCreate(query, memberName, "OrderBy");
        }

        /// <summary>
        /// Hàm sắp xếp theo tên thuộc tính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        private static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string memberName)
        {
            return OrderByCreate(query, memberName, "OrderByDescending");
        }

        /// <summary>
        /// Hàm tạo biểu thức sắp xếp dựa trên tên thuộc tính và hướng sắp xếp
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="memberName"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private static IOrderedQueryable<T> OrderByCreate<T>(this IQueryable<T> query, string memberName, string direction)
        {
            memberName = GetPropertyByField<T>(memberName);
            var typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };
            var pi = typeof(T).GetProperty(memberName);

            return (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(typeof(Queryable),
                direction,
                new Type[] { typeof(T), pi.PropertyType },
                query.Expression,
                Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams)));
        }

        /// <summary>
        /// Hàm tính tổng của thuộc tính tùy chỉnh
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        private static decimal SumCreate<T>(this IQueryable<T> query, string memberName)
        {
            var typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };
            var pi = typeof(T).GetProperty(GetPropertyByField<T>(memberName));


            var sumProperty = Expression.Lambda<Func<T, decimal>>(Expression.Property(typeParams[0], pi), typeParams);

            return query.Sum(sumProperty);
        }
    }
}
