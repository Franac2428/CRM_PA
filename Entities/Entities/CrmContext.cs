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

    public virtual DbSet<TipoMoneda> TipoMoneda { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CRM;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D59466421ECA979F");

            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(256);
            entity.Property(e => e.Identificacion).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(256);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .HasConstraintName("FK_TipoIdentificacion_Clientes");
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

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
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

            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
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

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
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

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
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

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(256);

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdMoneda)
                .HasConstraintName("FK_TipoMoneda_Servicios");
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

        modelBuilder.Entity<TipoMoneda>(entity =>
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
