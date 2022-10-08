namespace tls.api.Products
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Entity = ProductEntity;
    public class ProductConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasData(
                new Entity
                {
                    Id = new Guid("24625f9e-0e4a-49c7-835c-fd54d4e07971"),
                    ProductReferenceId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    SizeName = ProductSize.Regular.ToString(),
                    SizeValue = ProductSize.Regular,
                    Price = 1.00,
                },
                new Entity
                {
                    Id = new Guid("c9bf56b2-7154-478d-8cf2-cb9d11de7694"),
                    ProductReferenceId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    SizeName = ProductSize.Large.ToString(),
                    SizeValue = ProductSize.Large,
                    Price = 1.50,
                },
                new Entity
                {
                    Id = new Guid("2332aa04-9621-40e5-b383-4c0763f486ed"),
                    ProductReferenceId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    SizeName = ProductSize.Regular.ToString(),
                    SizeValue = ProductSize.Regular,
                    Price = 1.00,
                },
                new Entity
                {
                    Id = new Guid("d31373c2-902e-441d-9d9f-c0fb987f929d"),
                    ProductReferenceId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    SizeName = ProductSize.Large.ToString(),
                    SizeValue = ProductSize.Large,
                    Price = 1.50,
                }
            );
        }
    }
}
