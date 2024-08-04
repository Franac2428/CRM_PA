using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesRecibo> DetallesRecibos { get; set; }

    public virtual DbSet<InfoEmpresa> InfoEmpresas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PagosGenerado> PagosGenerados { get; set; }

    public virtual DbSet<Recibo> Recibos { get; set; }

    public virtual DbSet<Saldo> Saldos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<TipoEstadoMovimiento> TipoEstadoMovimientos { get; set; }

    public virtual DbSet<TipoEstadoPago> TipoEstadoPagos { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }

    public virtual DbSet<TipoMonedum> TipoMoneda { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

    public virtual DbSet<TipoPlan> TipoPlans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=CRM;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D59466421ECA979F");

            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.IdUsuarioModificacion).HasMaxLength(450);
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(256);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_Clientes_Servicio");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .HasConstraintName("FK_TipoIdentificacion_Clientes");

            entity.HasOne(d => d.IdTipoPlanNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoPlan)
                .HasConstraintName("FK_Clientes_TipoPlan");
        });

        modelBuilder.Entity<DetallesRecibo>(entity =>
        {
            entity.HasKey(e => e.IdDetalleRecibo).HasName("PK__Detalles__BDA44BBE553BC43C");

            entity.ToTable("DetallesRecibo");

            entity.Property(e => e.MontoLinea).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallesRecibos)
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK_DetallesRecibo_Pagos");

            entity.HasOne(d => d.IdReciboNavigation).WithMany(p => p.DetallesRecibos)
                .HasForeignKey(d => d.IdRecibo)
                .HasConstraintName("FK_DetallesRecibo_Recibos");
        });

        modelBuilder.Entity<InfoEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdInfoEmpresa).HasName("PK__InfoEmpr__82FCF9920748C553");

            entity.ToTable("InfoEmpresa");

            entity.Property(e => e.Actividad).HasMaxLength(256);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(256);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.InfoEmpresas)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .HasConstraintName("FK_InfoEmpresa_TipoIdentificacion");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PK__Movimien__881A6AE0612E3FB7");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.IdUsuarioModificacion).HasMaxLength(450);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdEstadoMovimientoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdEstadoMovimiento)
                .HasConstraintName("FK_Movimientos_TipoEstadoMovimiento");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .HasConstraintName("FK_TipoMovimiento_Movimiento");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__FC851A3A34735C52");

            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.IdUsuarioModificacion).HasMaxLength(450);
            entity.Property(e => e.MontoPago).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroComprobannte).HasMaxLength(256);

            entity.HasOne(d => d.IdEstadoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdEstadoPago)
                .HasConstraintName("FK_Pagos_TipoEstadoPago");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_Pagos_Servicios");
        });

        modelBuilder.Entity<PagosGenerado>(entity =>
        {
            entity.HasKey(e => e.IdPagoGenerado).HasName("PK__PagosGen__750D42F45E87DB25");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.IdUsuarioModificacion).HasMaxLength(450);
            entity.Property(e => e.MontoPago).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.PagosGenerados)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_PagosGenerados_Cliente");

            entity.HasOne(d => d.IdEstadoPagoNavigation).WithMany(p => p.PagosGenerados)
                .HasForeignKey(d => d.IdEstadoPago)
                .HasConstraintName("FK_PagosGenerados_TipoEstadoPago");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.PagosGenerados)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK_PagosGenerados_Servicio");
        });

        modelBuilder.Entity<Recibo>(entity =>
        {
            entity.HasKey(e => e.IdRecibo).HasName("PK__Recibos__2FEC4731C2682EDE");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Recibos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Recibos_Cliente");
        });

        modelBuilder.Entity<Saldo>(entity =>
        {
            entity.HasKey(e => e.IdSaldo).HasName("PK__Saldos__0EAE8D651999F7D4");

            entity.Property(e => e.MontoSaldo).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Saldos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Saldos_Cliente");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Saldos)
                .HasForeignKey(d => d.IdMoneda)
                .HasConstraintName("FK_TipoMoneda_Saldos");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A2B630BE6B");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.IdUsuarioCreacion).HasMaxLength(450);
            entity.Property(e => e.IdUsuarioModificacion).HasMaxLength(450);
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(256);

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdMoneda)
                .HasConstraintName("FK_TipoMoneda_Servicios");

            entity.HasOne(d => d.IdUsuarioCreacionNavigation).WithMany(p => p.ServicioIdUsuarioCreacionNavigations)
                .HasForeignKey(d => d.IdUsuarioCreacion)
                .HasConstraintName("FK_Servicios_AspNetUsers_Creacion");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.ServicioIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK_Servicios_AspNetUsers_Modificacion");
        });

        modelBuilder.Entity<TipoEstadoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdEstadoMovimiento).HasName("PK__EstadoMo__78A55A748502BE44");

            entity.ToTable("TipoEstadoMovimiento");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoEstadoPago>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPago).HasName("PK__EstadoPa__540F03E980D908BC");

            entity.ToTable("TipoEstadoPago");

            entity.Property(e => e.Nombre).HasMaxLength(256);
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoIdentificacion).HasName("PK__TipoIden__F521C6A80A365A6A");

            entity.ToTable("TipoIdentificacion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoMonedum>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK__Moneda__AA690671DFEE7819");

            entity.Property(e => e.Nombre).HasMaxLength(256);
        });

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento).HasName("PK__TipoMovi__820D7FC276ED60AF");

            entity.ToTable("TipoMovimiento");

            entity.Property(e => e.Nombre).HasMaxLength(20);
        });

        modelBuilder.Entity<TipoPlan>(entity =>
        {
            entity.HasKey(e => e.IdTipoPlan).HasName("PK__TipoPlan__EED4109D238DEC70");

            entity.ToTable("TipoPlan");

            entity.Property(e => e.Nombre).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
