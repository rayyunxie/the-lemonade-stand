using tls.api.ProductReferences;

namespace tls.api.Products
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Entity = ProductReferenceEntity;
    public class ProductReferenceConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasData(
                new Entity
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Lemonade",
                    ImageUrl = "https://tlsfilestorage.blob.core.windows.net/assets/lemon.svg",
                },
                new Entity
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Pink Lemonade",
                    ImageUrl = "https://tlsfilestorage.blob.core.windows.net/assets/lemon.svg"
                }
            );
        }
    }
}
