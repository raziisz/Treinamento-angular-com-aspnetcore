using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Project.Api.Models;
using Project.Api.Models.ObjetoDeValor;

namespace Project.Api.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// Classes de mapeamento aqui...
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(400);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario);
            
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(400);
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .IsRequired();

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>()
                .Property(p => p.DataPedido)
                .IsRequired();
            modelBuilder.Entity<Pedido>()
                .Property(p => p.DataPrevisaoEntrega)
                .IsRequired();
            modelBuilder.Entity<Pedido>()
                .Property(p => p.DataPrevisaoEntrega)
                .IsRequired();
            modelBuilder.Entity<Pedido>()
                .Property(p => p.CEP)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<Pedido>()
                .Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Pedido>()
                .Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Pedido>()
                .Property(p => p.EnderecoCompleto)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Pedido>()
                .Property(p => p.NumeroEndereco)
                .IsRequired();
            
            modelBuilder.Entity<ItemPedido>().HasKey(i => i.Id);
            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.ProdutoId)
                .IsRequired();
            modelBuilder.Entity<ItemPedido>()
                .Property(i => i.Quantidade)
                .IsRequired();
            
            modelBuilder.Entity<FormaPagamento>().HasKey(f => f.Id);
            modelBuilder.Entity<FormaPagamento>()
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<FormaPagamento>()
                .Property(f => f.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<FormaPagamento>()
                .HasData(new FormaPagamento() { 
                     Id = 1,
                     Nome="Boleto",
                     Descricao = "Forma de Pagamento Boleto"},
                     new FormaPagamento() { 
                     Id = 2,
                     Nome="Cartão de Crédito",
                     Descricao = "Forma de Pagamento Cartão de Crédito"},
                     new FormaPagamento() { 
                     Id = 3,
                     Nome="Deposito",
                     Descricao = "Forma de Pagamento Deposito"});
            
            base.OnModelCreating(modelBuilder);
        }


    }
}