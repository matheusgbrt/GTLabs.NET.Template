using Gtlabs.Persistence.CustomDbContext;
using Gtlabs.Persistence.DataFilters;
using Gtlabs.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace GTLabs.NET.Template.Infrastructure.Contexts;

public class TemplateDbcontext : GtLabsDbContext
{
    public TemplateDbcontext(
        DbContextOptions<TemplateDbcontext> options) : base(options)
    {
    }
    
    public class IdentityDbContextFactory : GtLabsDbContextFactory<TemplateDbcontext>
    {
    }
}
