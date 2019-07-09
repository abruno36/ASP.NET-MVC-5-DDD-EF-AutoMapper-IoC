using System;
using ProjetoModeloDDD.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using ProjetoModeloDDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        //Necessário nesta camanda (Infra.Data) instalara o Entity Framework) através do Nuget - Package Manager Console 
        //Install-Package Entityframework 
        //Todas as convensões de contexto abaixo são digitadas

        //base("ProjetoModeloDDD"): name da string de conexão que está no web-config do projeto MVC
        public ProjetoModeloContext() : base ("ProjetoModeloDDD")
        {
                
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        //Método de convensões no banco de dados
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Desabilitar convensões
            //pluralização - quando criar uma tabela vai colocar o nome da tabela no plural, esta convensão desabilitar
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Não deletar em cascata OneToMany ou ManyToMany - perigoso
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Quando tiver uma propriedade alguma coisa + Id no final, diga que é a chave primaria da tabela
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Criar sempre como formato string como varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Formato string varchar (string) vai criar no tamanho máximo 150
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            //Use a configuração abaixo - segue o que está escrito nas classes abaixo
            modelBuilder.Configurations.Add(new ClienteConfiguration());

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        
        public override int SaveChanges()
        {
            //O método abaixo inicializa quando é um create na DateCreated - quando tiver adicionando é DateTime.Now
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateCreated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateCreated").IsModified = false;
                }
            }

            //O método abaixo atualiza quando é um create ou update na DateUpdated - DateTime.Now
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateUpdated") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateUpdated").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateUpdated").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }


    }
}
