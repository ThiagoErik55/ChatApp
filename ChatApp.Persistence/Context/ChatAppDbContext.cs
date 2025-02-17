using ChatApp.Model.Users;
using ChatApp.Model.Messages;
using ChatApp.Model.Conversations;
using Microsoft.EntityFrameworkCore;

public class ChatAppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Mensagem> Mensagens { get; set; }
    public DbSet<Conversa> Conversas { get; set; }

    // configuração SQLite
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=chatapp.db");
    }

    // config. modelos e relacionamentos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
        modelBuilder.Entity<Mensagem>().HasKey(m => m.Id);
        modelBuilder.Entity<Conversa>().HasKey(c => c.ConversaId);

        //relaciomento entre usuarios e conversas (N:N)
        modelBuilder.Entity<Conversa>()
            .HasMany(c => c.Participantes)
            .WithMany();

        //relacionamentto entre mensagens e conversas (1:N)
        modelBuilder.Entity<Mensagem>()
            .HasOne<Conversa>()
            .WithMany(c => c.Mensagens)
            .HasForeignKey("ConversaId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}