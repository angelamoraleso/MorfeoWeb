using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MorfeoWeb.Models;

public partial class MorfeoContext : DbContext
{
    public MorfeoContext()
    {
    }

    public MorfeoContext(DbContextOptions<MorfeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgenciaViaje> AgenciaViajes { get; set; }

    public virtual DbSet<AsignarHabitacion> AsignarHabitacions { get; set; }

    public virtual DbSet<AsignarLimpieza> AsignarLimpiezas { get; set; }

    public virtual DbSet<AsignarTurno> AsignarTurnos { get; set; }

    public virtual DbSet<AtencionReserva> AtencionReservas { get; set; }

    public virtual DbSet<Barrio> Barrios { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<CategoriaEstrella> CategoriaEstrellas { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleServicioReserva> DetalleServicioReservas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoHabitacion> EstadoHabitacions { get; set; }

    public virtual DbSet<EstadoLimpieza> EstadoLimpiezas { get; set; }

    public virtual DbSet<EstadoPago> EstadoPagos { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<HistorialCategoria> HistorialCategorias { get; set; }

    public virtual DbSet<HistorialPago> HistorialPagos { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Huesped> Huespeds { get; set; }

    public virtual DbSet<InformacionHabitacion> InformacionHabitacions { get; set; }

    public virtual DbSet<Localidad> Localidads { get; set; }

    public virtual DbSet<Mascotum> Mascota { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<RecursosHumano> RecursosHumanos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Reserva1> Reservas1 { get; set; }

    public virtual DbSet<ServicioAdicional> ServicioAdicionals { get; set; }


    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoHabitacion> TipoHabitacions { get; set; }

    public virtual DbSet<TipoHuesped> TipoHuespeds { get; set; }

    public virtual DbSet<TipoMascotum> TipoMascota { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<UbicacionHotel> UbicacionHotels { get; set; }
    public virtual DbSet<TelefonoHotel> TelefonoHotels { get; set; }
    public virtual DbSet<TelefonoEmpleado> TelefonoEmpleados { get; set; }
    public virtual DbSet<TelefonoHuesped> TelefonoHuespeds { get; set; }
    public virtual DbSet<TelefonoAgencia> TelefonoAgencias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=Morfeo_DB;User=root;Password=TU_PASSWORD;",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql")
            );
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AgenciaViaje>(entity =>
        {
            entity.HasKey(e => e.IdAgencia).HasName("PRIMARY");

            entity.ToTable("agencia_viajes");

            entity.Property(e => e.IdAgencia).HasColumnName("ID_agencia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AsignarHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PRIMARY");

            entity.ToTable("asignar_habitacion");

            entity.HasIndex(e => e.IdHabitacion, "ID_habitacion");

            entity.HasIndex(e => e.IdHuesped, "ID_huesped");

            entity.HasIndex(e => e.IdReserva, "ID_reserva");

            entity.Property(e => e.IdAsignacion).HasColumnName("ID_asignacion");
            entity.Property(e => e.IdHabitacion).HasColumnName("ID_habitacion");
            entity.Property(e => e.IdHuesped).HasColumnName("ID_huesped");
            entity.Property(e => e.IdReserva).HasColumnName("ID_reserva");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.AsignarHabitacions)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("asignar_habitacion_ibfk_3");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.AsignarHabitacions)
                .HasForeignKey(d => d.IdHuesped)
                .HasConstraintName("asignar_habitacion_ibfk_1");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.AsignarHabitacions)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("asignar_habitacion_ibfk_2");
        });

        modelBuilder.Entity<AsignarLimpieza>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionLimpieza).HasName("PRIMARY");

            entity.ToTable("asignar_limpieza");

            entity.HasIndex(e => e.IdEmpleado, "ID_empleado");

            entity.HasIndex(e => e.IdEstadoLimpieza, "ID_estado_limpieza");

            entity.HasIndex(e => e.IdHabitacion, "ID_habitacion");

            entity.Property(e => e.IdAsignacionLimpieza).HasColumnName("ID_asignacion_limpieza");
            entity.Property(e => e.FechaAsignacion).HasColumnName("fecha_asignacion");
            entity.Property(e => e.FechaRealizada).HasColumnName("fecha_realizada");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.Property(e => e.IdEstadoLimpieza).HasColumnName("ID_estado_limpieza");
            entity.Property(e => e.IdHabitacion).HasColumnName("ID_habitacion");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.AsignarLimpiezas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("asignar_limpieza_ibfk_2");

            entity.HasOne(d => d.IdEstadoLimpiezaNavigation).WithMany(p => p.AsignarLimpiezas)
                .HasForeignKey(d => d.IdEstadoLimpieza)
                .HasConstraintName("asignar_limpieza_ibfk_1");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.AsignarLimpiezas)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("asignar_limpieza_ibfk_3");
        });

        modelBuilder.Entity<AsignarTurno>(entity =>
        {
            entity.HasKey(e => e.IdAsignacionTurno).HasName("PRIMARY");

            entity.ToTable("asignar_turno");

            entity.HasIndex(e => e.IdEmpleado, "ID_empleado");

            entity.HasIndex(e => e.IdTurno, "ID_turno");

            entity.Property(e => e.IdAsignacionTurno).HasColumnName("ID_asignacion_turno");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.Property(e => e.IdTurno).HasColumnName("ID_turno");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.AsignarTurnos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("asignar_turno_ibfk_1");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.AsignarTurnos)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("asignar_turno_ibfk_2");
        });

        modelBuilder.Entity<AtencionReserva>(entity =>
        {
            entity.HasKey(e => e.IdAtencion).HasName("PRIMARY");

            entity.ToTable("atencion_reserva");

            entity.HasIndex(e => e.IdEmpleado, "ID_empleado");

            entity.HasIndex(e => e.IdReserva, "ID_reserva");

            entity.Property(e => e.IdAtencion).HasColumnName("ID_atencion");
            entity.Property(e => e.FechaAtencion).HasColumnName("fecha_atencion");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.Property(e => e.IdReserva).HasColumnName("ID_reserva");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.AtencionReservas)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("atencion_reserva_ibfk_1");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.AtencionReservas)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("atencion_reserva_ibfk_2");
        });

        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.IdBarrio).HasName("PRIMARY");

            entity.ToTable("barrio");

            entity.HasIndex(e => e.IdLocalidad, "ID_localidad");

            entity.Property(e => e.IdBarrio).HasColumnName("ID_barrio");
            entity.Property(e => e.IdLocalidad).HasColumnName("ID_localidad");
            entity.Property(e => e.nombre_barrio)
                .HasMaxLength(100)
                .HasColumnName("nombre_barrio");

            entity.HasOne(d => d.IdLocalidadNavigation).WithMany(p => p.Barrios)
                .HasForeignKey(d => d.IdLocalidad)
                .HasConstraintName("barrio_ibfk_1");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PRIMARY");

            entity.ToTable("cargo");

            entity.Property(e => e.IdCargo).HasColumnName("ID_cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(100)
                .HasColumnName("nombre_cargo");
        });

        modelBuilder.Entity<CategoriaEstrella>(entity =>
        {
            entity.HasKey(e => e.IdEstrellas).HasName("PRIMARY");

            entity.ToTable("categoria_estrellas");

            entity.Property(e => e.IdEstrellas).HasColumnName("ID_estrellas");
            entity.Property(e => e.Nivel)
                .HasMaxLength(50)
                .HasColumnName("nivel");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdPais, "ID_pais");

            entity.Property(e => e.IdCiudad).HasColumnName("ID_ciudad");
            entity.Property(e => e.IdPais).HasColumnName("ID_pais");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .HasColumnName("nombre_ciudad");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("ciudad_ibfk_1");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.IdContrato).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.IdCargo, "ID_cargo");

            entity.HasIndex(e => e.IdDepartamento, "ID_departamento");

            entity.HasIndex(e => e.IdEmpleado, "ID_empleado");

            entity.HasIndex(e => e.IdTipoContrato, "ID_tipo_contrato");

            entity.Property(e => e.IdContrato).HasColumnName("ID_contrato");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCargo).HasColumnName("ID_cargo");
            entity.Property(e => e.IdDepartamento).HasColumnName("ID_departamento");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.Property(e => e.IdTipoContrato).HasColumnName("ID_tipo_contrato");
            entity.Property(e => e.Salario)
                .HasPrecision(18, 2)
                .HasColumnName("salario");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("contrato_ibfk_2");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("contrato_ibfk_3");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("contrato_ibfk_1");

            entity.HasOne(d => d.IdTipoContratoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdTipoContrato)
                .HasConstraintName("contrato_ibfk_4");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.IdHotel, "ID_hotel");

            entity.Property(e => e.IdDepartamento).HasColumnName("ID_departamento");
            entity.Property(e => e.IdHotel).HasColumnName("ID_hotel");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .HasColumnName("nombre_departamento");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("departamento_ibfk_1");
        });

        modelBuilder.Entity<DetalleServicioReserva>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdServicio })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detalle_servicio_reserva");

            entity.HasIndex(e => e.IdServicio, "ID_servicio");

            entity.Property(e => e.IdReserva).HasColumnName("ID_reserva");
            entity.Property(e => e.IdServicio).HasColumnName("ID_servicio");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(18, 2)
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.DetalleServicioReservas)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_servicio_reserva_ibfk_1");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleServicioReservas)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_servicio_reserva_ibfk_2");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.IdBarrio, "ID_barrio");

            entity.HasIndex(e => e.IdHotel, "ID_hotel");

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .HasColumnName("documento");
            entity.Property(e => e.FechaContratacion).HasColumnName("fecha_contratacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdBarrio).HasColumnName("ID_barrio");
            entity.Property(e => e.IdHotel).HasColumnName("ID_hotel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdBarrioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("empleado_ibfk_1");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("empleado_ibfk_2");
        });

        modelBuilder.Entity<EstadoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estado_habitacion");

            entity.Property(e => e.IdEstado).HasColumnName("ID_estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(100)
                .HasColumnName("nombre_estado");
        });

        modelBuilder.Entity<EstadoLimpieza>(entity =>
        {
            entity.HasKey(e => e.IdEstadoLimpieza).HasName("PRIMARY");

            entity.ToTable("estado_limpieza");

            entity.Property(e => e.IdEstadoLimpieza).HasColumnName("ID_estado_limpieza");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadoPago>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPago).HasName("PRIMARY");

            entity.ToTable("estado_pago");

            entity.Property(e => e.IdEstadoPago).HasColumnName("ID_estado_pago");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PRIMARY");

            entity.ToTable("habitacion");

            entity.HasIndex(e => e.IdHotel, "ID_Hotel");

            entity.HasIndex(e => e.IdEstado, "ID_estado");

            entity.HasIndex(e => e.IdTipoHabitacion, "ID_tipoHabitacion");

            entity.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");
            entity.Property(e => e.IdEstado).HasColumnName("ID_estado");
            entity.Property(e => e.IdHotel).HasColumnName("ID_Hotel");
            entity.Property(e => e.IdTipoHabitacion).HasColumnName("ID_tipoHabitacion");
            entity.Property(e => e.PrecioNoche)
                .HasPrecision(18, 2)
                .HasColumnName("Precio_Noche");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("habitacion_ibfk_1");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("habitacion_ibfk_3");

            entity.HasOne(d => d.IdTipoHabitacionNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdTipoHabitacion)
                .HasConstraintName("habitacion_ibfk_2");
        });

        modelBuilder.Entity<HistorialCategoria>(entity =>
        {
            entity.HasKey(e => e.IdHistoriaCategor).HasName("PRIMARY");

            entity.ToTable("historial_categorias");

            entity.HasIndex(e => e.IdEstrellas, "ID_estrellas");

            entity.HasIndex(e => e.IdHotel, "ID_hotel");

            entity.Property(e => e.IdHistoriaCategor).HasColumnName("ID_historia_categor");
            entity.Property(e => e.FechaCambio).HasColumnName("fecha_cambio");
            entity.Property(e => e.IdEstrellas).HasColumnName("ID_estrellas");
            entity.Property(e => e.IdHotel).HasColumnName("ID_hotel");
            entity.Property(e => e.MotivoCambio)
                .HasMaxLength(255)
                .HasColumnName("motivo_cambio");

            entity.HasOne(d => d.IdEstrellasNavigation).WithMany(p => p.HistorialCategoria)
                .HasForeignKey(d => d.IdEstrellas)
                .HasConstraintName("historial_categorias_ibfk_2");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.HistorialCategoria)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("historial_categorias_ibfk_1");
        });

        modelBuilder.Entity<HistorialPago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("historial_pagos");

            entity.HasIndex(e => e.IdEstadoPagado, "ID_estado_pagado");

            entity.HasIndex(e => e.IdMetodoPago, "ID_metodo_pago");

            entity.HasIndex(e => e.IdReserva, "ID_reserva");

            entity.HasIndex(e => e.IdTipoPago, "ID_tipo_pago");

            entity.Property(e => e.IdPago).HasColumnName("ID_pago");
            entity.Property(e => e.FechaPago).HasColumnName("Fecha_pago");
            entity.Property(e => e.IdEstadoPagado).HasColumnName("ID_estado_pagado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("ID_metodo_pago");
            entity.Property(e => e.IdReserva).HasColumnName("ID_reserva");
            entity.Property(e => e.IdTipoPago).HasColumnName("ID_tipo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(18, 2)
                .HasColumnName("monto");

            entity.HasOne(d => d.IdEstadoPagadoNavigation).WithMany(p => p.HistorialPagos)
                .HasForeignKey(d => d.IdEstadoPagado)
                .HasConstraintName("historial_pagos_ibfk_4");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.HistorialPagos)
                .HasForeignKey(d => d.IdMetodoPago)
                .HasConstraintName("historial_pagos_ibfk_3");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.HistorialPagos)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("historial_pagos_ibfk_1");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.HistorialPagos)
                .HasForeignKey(d => d.IdTipoPago)
                .HasConstraintName("historial_pagos_ibfk_2");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PRIMARY");

            entity.ToTable("hotel");

            entity.HasIndex(e => e.IdBarrio, "ID_barrio");

            entity.Property(e => e.IdHotel).HasColumnName("ID_Hotel");
            entity.Property(e => e.AnioInaguracion).HasColumnName("Anio_Inaguracion");
            entity.Property(e => e.IdBarrio).HasColumnName("ID_barrio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdBarrioNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.IdBarrio)
                .HasConstraintName("hotel_ibfk_1");
        });

        modelBuilder.Entity<Huesped>(entity =>
        {
            entity.HasKey(e => e.IdHuesped).HasName("PRIMARY");

            entity.ToTable("huesped");

            entity.HasIndex(e => e.IdPais, "ID_pais");

            entity.HasIndex(e => e.IdTipoHuesped, "ID_tipo_huesped");

            entity.Property(e => e.IdHuesped).HasColumnName("ID_huesped");
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .HasColumnName("documento");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.IdPais).HasColumnName("ID_pais");
            entity.Property(e => e.IdTipoHuesped).HasColumnName("ID_tipo_huesped");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Huespeds)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("huesped_ibfk_2");

            entity.HasOne(d => d.IdTipoHuespedNavigation).WithMany(p => p.Huespeds)
                .HasForeignKey(d => d.IdTipoHuesped)
                .HasConstraintName("huesped_ibfk_1");
        });

        modelBuilder.Entity<InformacionHabitacion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("informacion_habitacion");

            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.IdHabitacion).HasColumnName("ID_Habitacion");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(100)
                .HasColumnName("nombre_estado");
            entity.Property(e => e.PrecioNoche)
                .HasPrecision(18, 2)
                .HasColumnName("Precio_Noche");
        });

        modelBuilder.Entity<Localidad>(entity =>
        {
            entity.HasKey(e => e.IdLocalidad).HasName("PRIMARY");

            entity.ToTable("localidad");

            entity.HasIndex(e => e.IdCiudad, "ID_ciudad");

            entity.Property(e => e.IdLocalidad).HasColumnName("ID_localidad");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(20)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.IdCiudad).HasColumnName("ID_ciudad");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombre_localidad");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Localidads)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("localidad_ibfk_1");
        });

        modelBuilder.Entity<Mascotum>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PRIMARY");

            entity.ToTable("mascota");

            entity.HasIndex(e => e.IdHuesped, "ID_huesped");

            entity.HasIndex(e => e.IdTipo, "ID_tipo");

            entity.Property(e => e.IdMascota).HasColumnName("ID_mascota");
            entity.Property(e => e.IdHuesped).HasColumnName("ID_huesped");
            entity.Property(e => e.IdTipo).HasColumnName("ID_tipo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdHuespedNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdHuesped)
                .HasConstraintName("mascota_ibfk_2");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("mascota_ibfk_1");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PRIMARY");

            entity.ToTable("metodo_pago");

            entity.Property(e => e.IdMetodoPago).HasColumnName("ID_metodo_pago");
            entity.Property(e => e.MetodoPago1)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("pagos");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.IdPago).HasColumnName("ID_pago");
            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasPrecision(18, 2)
                .HasColumnName("monto");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .HasColumnName("tipo_pago");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PRIMARY");

            entity.ToTable("pais");

            entity.Property(e => e.IdPais).HasColumnName("ID_pais");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(100)
                .HasColumnName("nombre_pais");
        });

        modelBuilder.Entity<RecursosHumano>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("recursos_humanos");

            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .HasColumnName("documento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(100)
                .HasColumnName("nombre_cargo");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .HasColumnName("nombre_departamento");
            entity.Property(e => e.Salario)
                .HasPrecision(18, 2)
                .HasColumnName("salario");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PRIMARY");

            entity.ToTable("reserva");

            entity.HasIndex(e => e.IdAgencia, "ID_agencia");

            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.AnticipoPagado)
                .HasPrecision(18, 2)
                .HasColumnName("Anticipo_pagado");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.FechaReserva).HasColumnName("Fecha_Reserva");
            entity.Property(e => e.IdAgencia).HasColumnName("ID_agencia");
            entity.Property(e => e.Total).HasPrecision(18, 2);

            entity.HasOne(d => d.IdAgenciaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdAgencia)
                .HasConstraintName("reserva_ibfk_1");
        });

        modelBuilder.Entity<Reserva1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("reservas");

            entity.Property(e => e.Agencia).HasMaxLength(150);
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.Huesped).HasMaxLength(100);
            entity.Property(e => e.IdReserva).HasColumnName("ID_Reserva");
            entity.Property(e => e.Total).HasPrecision(18, 2);
        });

        modelBuilder.Entity<ServicioAdicional>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.ToTable("servicio_adicional");

            entity.HasIndex(e => e.IdTipoServicio, "ID_tipo_servicio");

            entity.Property(e => e.IdServicio).HasColumnName("ID_servicio");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.IdTipoServicio).HasColumnName("ID_tipo_servicio");
            entity.Property(e => e.Precio).HasPrecision(18, 2);

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.ServicioAdicionals)
                .HasForeignKey(d => d.IdTipoServicio)
                .HasConstraintName("servicio_adicional_ibfk_1");
        });

       // 1. Configuración de la entidad TelefonoHotel
modelBuilder.Entity<TelefonoHotel>(entity =>
{
    entity.HasKey(e => e.IdTelefonoHotel).HasName("PRIMARY");
    entity.ToTable("telefono_hotel");
    entity.Property(e => e.IdTelefonoHotel).HasColumnName("ID_telefono_hotel");
    entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
    entity.Property(e => e.IdHotel).HasColumnName("ID_hotel");

    entity.HasOne(d => d.IdHotelNavigation)
          .WithMany(p => p.TelefonoHotels)
          .HasForeignKey(d => d.IdHotel)
          .HasConstraintName("telefono_hotel_ibfk_1");
});

// 2. Configuración de la entidad TelefonoEmpleado
modelBuilder.Entity<TelefonoEmpleado>(entity =>
{
    entity.HasKey(e => e.IdTelefonoEmpleado).HasName("PRIMARY");
    entity.ToTable("telefono_empleado");
    entity.Property(e => e.IdTelefonoEmpleado).HasColumnName("ID_telefono_empleado");
    entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
    entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");

    entity.HasOne(d => d.IdEmpleadoNavigation)
          .WithMany(p => p.TelefonoEmpleados)
          .HasForeignKey(d => d.IdEmpleado)
          .HasConstraintName("telefono_empleado_ibfk_1");
});

// 3. Configuración de la entidad TelefonoHuesped
modelBuilder.Entity<TelefonoHuesped>(entity =>
{
    entity.HasKey(e => e.IdTelefonoHuesped).HasName("PRIMARY");
    entity.ToTable("telefono_huesped");
    entity.Property(e => e.IdTelefonoHuesped).HasColumnName("ID_telefono_huesped");
    entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
    entity.Property(e => e.IdHuesped).HasColumnName("ID_huesped");

    entity.HasOne(d => d.IdHuespedNavigation)
          .WithMany(p => p.TelefonoHuespeds)
          .HasForeignKey(d => d.IdHuesped)
          .HasConstraintName("telefono_huesped_ibfk_1");
});

// 4. Configuración de la entidad TelefonoAgencia
modelBuilder.Entity<TelefonoAgencia>(entity =>
{
    entity.HasKey(e => e.IdTelefonoAgencia).HasName("PRIMARY");
    entity.ToTable("telefono_agencia");
    entity.Property(e => e.IdTelefonoAgencia).HasColumnName("ID_telefono_agencia");
    entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
    entity.Property(e => e.IdAgencia).HasColumnName("ID_agencia");

    entity.HasOne(d => d.IdAgenciaNavigation)
          .WithMany(p => p.TelefonoAgencias)
          .HasForeignKey(d => d.IdAgencia)
          .HasConstraintName("telefono_agencia_ibfk_1");
});

        modelBuilder.Entity<TipoContrato>(entity =>
        {
            entity.HasKey(e => e.IdTipoContrato).HasName("PRIMARY");

            entity.ToTable("tipo_contrato");

            entity.Property(e => e.IdTipoContrato).HasColumnName("ID_tipo_contrato");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoHabitacion).HasName("PRIMARY");

            entity.ToTable("tipo_habitacion");

            entity.Property(e => e.IdTipoHabitacion).HasColumnName("ID_tipoHabitacion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TipoHuesped>(entity =>
        {
            entity.HasKey(e => e.IdTipoHuesped).HasName("PRIMARY");

            entity.ToTable("tipo_huesped");

            entity.Property(e => e.IdTipoHuesped).HasColumnName("ID_tipo_huesped");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoMascotum>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PRIMARY");

            entity.ToTable("tipo_mascota");

            entity.Property(e => e.IdTipo).HasColumnName("ID_tipo");
            entity.Property(e => e.TipoMascota)
                .HasMaxLength(50)
                .HasColumnName("Tipo_mascota");
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago).HasName("PRIMARY");

            entity.ToTable("tipo_pago");

            entity.Property(e => e.IdTipoPago).HasColumnName("ID_tipo_pago");
            entity.Property(e => e.TipoPago1)
                .HasMaxLength(50)
                .HasColumnName("tipo_pago");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoServicio).HasName("PRIMARY");

            entity.ToTable("tipo_servicio");

            entity.Property(e => e.IdTipoServicio).HasColumnName("ID_tipo_servicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno).HasName("PRIMARY");

            entity.ToTable("turno");

            entity.Property(e => e.IdTurno).HasColumnName("ID_turno");
            entity.Property(e => e.HoraFin)
                .HasColumnType("time")
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.NombreTurno)
                .HasMaxLength(50)
                .HasColumnName("nombre_turno");
        });

        modelBuilder.Entity<UbicacionHotel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ubicacion_hotel");

            entity.Property(e => e.Hotel).HasMaxLength(150);
            entity.Property(e => e.NombreBarrio)
                .HasMaxLength(100)
                .HasColumnName("nombre_barrio");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .HasColumnName("nombre_ciudad");
            entity.Property(e => e.NombreLocalidad)
                .HasMaxLength(100)
                .HasColumnName("nombre_localidad");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(100)
                .HasColumnName("nombre_pais");
        });
        modelBuilder.Entity<TelefonoHotel>(entity =>
        {
            entity.HasKey(e => e.IdTelefonoHotel).HasName("PRIMARY");
            entity.ToTable("telefono_hotel");
            entity.Property(e => e.IdTelefonoHotel).HasColumnName("ID_telefono_hotel");
            entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
            entity.Property(e => e.IdHotel).HasColumnName("ID_hotel");
            entity.HasOne(d => d.IdHotelNavigation)
                  .WithMany(p => p.TelefonoHotels)
                  .HasForeignKey(d => d.IdHotel)
                  .HasConstraintName("telefono_hotel_ibfk_1");
        });

        modelBuilder.Entity<TelefonoEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdTelefonoEmpleado).HasName("PRIMARY");
            entity.ToTable("telefono_empleado");
            entity.Property(e => e.IdTelefonoEmpleado).HasColumnName("ID_telefono_empleado");
            entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_empleado");
            entity.HasOne(d => d.IdEmpleadoNavigation)
                  .WithMany(p => p.TelefonoEmpleados)
                  .HasForeignKey(d => d.IdEmpleado)
                  .HasConstraintName("telefono_empleado_ibfk_1");
        });

        modelBuilder.Entity<TelefonoHuesped>(entity =>
        {
            entity.HasKey(e => e.IdTelefonoHuesped).HasName("PRIMARY");
            entity.ToTable("telefono_huesped");
            entity.Property(e => e.IdTelefonoHuesped).HasColumnName("ID_telefono_huesped");
            entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
            entity.Property(e => e.IdHuesped).HasColumnName("ID_huesped");
            entity.HasOne(d => d.IdHuespedNavigation)
                  .WithMany(p => p.TelefonoHuespeds)
                  .HasForeignKey(d => d.IdHuesped)
                  .HasConstraintName("telefono_huesped_ibfk_1");
        });

        modelBuilder.Entity<TelefonoAgencia>(entity =>
        {
            entity.HasKey(e => e.IdTelefonoAgencia).HasName("PRIMARY");
            entity.ToTable("telefono_agencia");
            entity.Property(e => e.IdTelefonoAgencia).HasColumnName("ID_telefono_agencia");
            entity.Property(e => e.Numero).HasMaxLength(20).HasColumnName("numero");
            entity.Property(e => e.IdAgencia).HasColumnName("ID_agencia");
            entity.HasOne(d => d.IdAgenciaNavigation)
                  .WithMany(p => p.TelefonoAgencias)
                  .HasForeignKey(d => d.IdAgencia)
                  .HasConstraintName("telefono_agencia_ibfk_1");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
