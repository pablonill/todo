using Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityMaps
{
    internal class TodoMap
    {
        public TodoMap(EntityTypeBuilder<Todo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Task).IsRequired();
        }
    }
}
