using Microsoft.EntityFrameworkCore;

public class ConsultorioContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=consultorio;UserId=postgres;Password=password;Timeout=10;")
            .UseSnakeCaseNamingConvention();
    }
}
