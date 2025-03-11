using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArch.DOMAIN.Concretes;

namespace OnionArch.PERSISTENCE.Configurations
{
    public class OrderDetailConfiguration:BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.HasIndex(p=>new {p.OrderID,p.ProductID}).IsUnique();
            // OrderID ve ProductID alanları üzerinde bileşik bir indeks oluşturulur. 
            // Aynı ürünü tekrar eklemeye çalıştığında, bu bileşik indeks sayesinde hata alır. Bunun Yerine Adet Artırabilir
            // Gereksiz veri tekrarını engeller ve veri bütünlüğünü korur ayrıca ilgili sorguların performansını artırır.
        }
    }
}
