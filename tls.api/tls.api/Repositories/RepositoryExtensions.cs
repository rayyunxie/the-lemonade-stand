namespace tls.api.Repositories
{
    using System.Linq.Dynamic.Core;
    using System.Text;

    public static class RepositoryExtensions
    {
        public static IQueryable<T>? OrderBy<T>(this IQueryable<T> entities,
            string? orderByQueryString, string[] supportedOrderByFields)
        {
            if (!string.IsNullOrWhiteSpace(orderByQueryString))
            {
                var orderParams = orderByQueryString.Trim().Split(',');
                var orderQueryBuilder = new StringBuilder();
                foreach (var param in orderParams)
                {
                    if (string.IsNullOrWhiteSpace(param))
                    {
                        continue;
                    }

                    var fieldName = param.Split(" ")[0];
                    var supportedFieldName = supportedOrderByFields.FirstOrDefault(x =>
                        x.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
                    if (supportedFieldName == null)
                    {
                        continue;
                    }

                    var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                    orderQueryBuilder.Append($"{supportedFieldName} {direction}, ");
                }

                var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
                if (!string.IsNullOrWhiteSpace(orderQuery))
                {
                    return entities.OrderBy(orderQuery);
                }
            }

            return null;
        }
    }
}