namespace tls.api.Orders
{
    using tls.api.Repositories;
    using Entity = OrderEntity;
    public static class OrderRepositoryExtensions
    {
        private static readonly string[] SupportedOrderByFields = new[] { "Name" };

        public static IQueryable<Entity> Sort(this IQueryable<Entity> entities, string? orderByQueryString) =>
            // try to order by the specified orderByQueryString first, if not successful, use a default ordering
            entities.OrderBy(orderByQueryString, SupportedOrderByFields) ?? entities.OrderBy(e => e.Name);

        public static IQueryable<Entity> Filter(this IQueryable<Entity> entities, string? name, string? contact) =>
            entities.SearchByName(name).SearchByContact(contact);

        private static IQueryable<Entity> SearchByName(this IQueryable<Entity> entities, string? searchTerm) =>
             string.IsNullOrWhiteSpace(searchTerm) ? entities :
                entities.Where(e => e.Name!.ToLower().Contains(searchTerm.Trim().ToLower()));

        private static IQueryable<Entity> SearchByContact(this IQueryable<Entity> entities, string? searchTerm) =>
             string.IsNullOrWhiteSpace(searchTerm) ? entities :
                entities.Where(e => e.Contact!.ToLower().Contains(searchTerm.Trim().ToLower()));
    }
}