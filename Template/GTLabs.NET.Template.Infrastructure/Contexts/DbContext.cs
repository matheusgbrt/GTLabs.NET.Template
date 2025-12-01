using Gtlabs.Api.AmbientData;
using Gtlabs.Persistence.CustomDbContext;
using Microsoft.EntityFrameworkCore;

namespace GTLabs.NET.Template.Infrastructure.Contexts;

public class TemplateDbcontext : GtLabsDbContext
{
    public TemplateDbcontext(DbContextOptions options, IAmbientData ambientData) : base(options, ambientData)
    {
    }
    
    public class IdentityDbContextFactory : GtLabsDbContextFactory<TemplateDbcontext>
    {
    }
}