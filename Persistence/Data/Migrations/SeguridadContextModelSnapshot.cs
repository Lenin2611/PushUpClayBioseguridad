﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(SeguridadContext))]
    partial class SeguridadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int")
                        .HasColumnName("idDepartamentoFk");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique();

                    b.HasIndex(new[] { "IdDepartamentoFk" }, "idDepartamentoFk");

                    b.HasIndex(new[] { "Nombre" }, "nombre")
                        .IsUnique();

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido");

                    b.Property<int?>("IdDescripcionPersonaFk")
                        .HasColumnType("int")
                        .HasColumnName("idDescripcionPersonaFk");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id1");

                    b.HasIndex(new[] { "IdDescripcionPersonaFk" }, "idDescripcionPersonaFk");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdTipoContactoFk")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("IdTipoContactoFk");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id2");

                    b.ToTable("contacto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateOnly?>("FechaContrato")
                        .HasColumnType("date")
                        .HasColumnName("fechaContrato");

                    b.Property<DateOnly?>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("fechaFin");

                    b.Property<int?>("IdClienteFk")
                        .HasColumnType("int")
                        .HasColumnName("idClienteFk");

                    b.Property<int?>("IdEmpleadoFk")
                        .HasColumnType("int")
                        .HasColumnName("idEmpleadoFk");

                    b.Property<int?>("IdEstadoFk")
                        .HasColumnType("int")
                        .HasColumnName("idEstadoFk");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id3");

                    b.HasIndex(new[] { "IdClienteFk" }, "idClienteFk");

                    b.HasIndex(new[] { "IdEmpleadoFk" }, "idEmpleadoFk");

                    b.HasIndex(new[] { "IdEstadoFk" }, "idEstadoFk");

                    b.ToTable("contrato", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int")
                        .HasColumnName("idPaisFk");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id4");

                    b.HasIndex(new[] { "IdPaisFk" }, "idPaisFk");

                    b.HasIndex(new[] { "Nombre" }, "nombre")
                        .IsUnique()
                        .HasDatabaseName("nombre1");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Descripcionpersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateOnly?>("FechaRegistro")
                        .HasColumnType("date")
                        .HasColumnName("fechaRegistro");

                    b.Property<int>("IdContactoFk")
                        .HasColumnType("int");

                    b.Property<int?>("IdDireccionFk")
                        .HasColumnType("int")
                        .HasColumnName("idDireccionFk");

                    b.Property<int?>("IdPersona")
                        .HasColumnType("int")
                        .HasColumnName("idPersona");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("IdContactoFk");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id5");

                    b.HasIndex(new[] { "IdDireccionFk" }, "idDireccionFk");

                    b.HasIndex(new[] { "IdPersona" }, "idPersona")
                        .IsUnique();

                    b.ToTable("descripcionpersona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Bis")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("bis")
                        .IsFixedLength();

                    b.Property<string>("CardinalPrimario")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("cardinal_primario")
                        .IsFixedLength();

                    b.Property<string>("CardinalSecundario")
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("cardinal_secundario")
                        .IsFixedLength();

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("complemento");

                    b.Property<int?>("IdCiudadFk")
                        .HasColumnType("int")
                        .HasColumnName("idCiudadFk");

                    b.Property<string>("LetraPrincipal")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)")
                        .HasColumnName("letra_principal")
                        .IsFixedLength();

                    b.Property<string>("LetraSecundaria")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)")
                        .HasColumnName("letra_secundaria")
                        .IsFixedLength();

                    b.Property<short>("NumeroPrincipal")
                        .HasColumnType("smallint")
                        .HasColumnName("numero_principal");

                    b.Property<short>("NumeroSecundario")
                        .HasColumnType("smallint")
                        .HasColumnName("numero_secundario");

                    b.Property<string>("TipoVia")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo_via");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id6");

                    b.HasIndex(new[] { "IdCiudadFk" }, "idCiudadFk");

                    b.ToTable("direccion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido");

                    b.Property<int?>("IdDescripcionPersonaFk")
                        .HasColumnType("int")
                        .HasColumnName("idDescripcionPersonaFk");

                    b.Property<int?>("IdPuestoFk")
                        .HasColumnType("int")
                        .HasColumnName("idPuestoFk");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id7");

                    b.HasIndex(new[] { "IdDescripcionPersonaFk" }, "idDescripcionPersonaFk")
                        .HasDatabaseName("idDescripcionPersonaFk1");

                    b.HasIndex(new[] { "IdPuestoFk" }, "idPuestoFk");

                    b.ToTable("empleado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id8");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id9");

                    b.HasIndex(new[] { "Nombre" }, "nombre")
                        .IsUnique()
                        .HasDatabaseName("nombre2");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("IdContratoFk")
                        .HasColumnType("int")
                        .HasColumnName("idContratoFk");

                    b.Property<int?>("IdEmpleadoFk")
                        .HasColumnType("int")
                        .HasColumnName("idEmpleadoFk");

                    b.Property<int?>("IdTurnoFk")
                        .HasColumnType("int")
                        .HasColumnName("idTurnoFk");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id10");

                    b.HasIndex(new[] { "IdContratoFk" }, "idContratoFk");

                    b.HasIndex(new[] { "IdEmpleadoFk" }, "idEmpleadoFk")
                        .HasDatabaseName("idEmpleadoFk1");

                    b.HasIndex(new[] { "IdTurnoFk" }, "idTurnoFk");

                    b.ToTable("programacion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id11");

                    b.ToTable("puesto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id12");

                    b.HasIndex(new[] { "Nombre" }, "nombre")
                        .IsUnique()
                        .HasDatabaseName("nombre3");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id13");

                    b.ToTable("tipocontacto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<TimeOnly?>("HoraFinal")
                        .HasColumnType("time")
                        .HasColumnName("horaFinal");

                    b.Property<TimeOnly?>("HoraInicio")
                        .HasColumnType("time")
                        .HasColumnName("horaInicio");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id14");

                    b.ToTable("turno", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "email")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique()
                        .HasDatabaseName("id15");

                    b.HasIndex(new[] { "Password" }, "password")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "username")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Userrol", b =>
                {
                    b.Property<int>("IdUserFk")
                        .HasColumnType("int")
                        .HasColumnName("idUserFk");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int")
                        .HasColumnName("idRolFk");

                    b.HasKey("IdUserFk", "IdRolFk")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "IdRolFk" }, "idRolFk");

                    b.ToTable("userrol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "IdDepartamentoFkNavigation")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFk")
                        .IsRequired()
                        .HasConstraintName("ciudad_ibfk_1");

                    b.Navigation("IdDepartamentoFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Descripcionpersona", "IdDescripcionPersonaFkNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("IdDescripcionPersonaFk")
                        .HasConstraintName("cliente_ibfk_1");

                    b.Navigation("IdDescripcionPersonaFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Contacto", b =>
                {
                    b.HasOne("Domain.Entities.TipoContacto", "TipoContacto")
                        .WithMany("Contactos")
                        .HasForeignKey("IdTipoContactoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoContacto");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "IdClienteFkNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdClienteFk")
                        .HasConstraintName("contrato_ibfk_1");

                    b.HasOne("Domain.Entities.Empleado", "IdEmpleadoFkNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEmpleadoFk")
                        .HasConstraintName("contrato_ibfk_3");

                    b.HasOne("Domain.Entities.Estado", "IdEstadoFkNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstadoFk")
                        .HasConstraintName("contrato_ibfk_2");

                    b.Navigation("IdClienteFkNavigation");

                    b.Navigation("IdEmpleadoFkNavigation");

                    b.Navigation("IdEstadoFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "IdPaisFkNavigation")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .IsRequired()
                        .HasConstraintName("departamento_ibfk_1");

                    b.Navigation("IdPaisFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Descripcionpersona", b =>
                {
                    b.HasOne("Domain.Entities.Contacto", "Contacto")
                        .WithMany("Descripcionpersonas")
                        .HasForeignKey("IdContactoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Direccion", "IdDireccionFkNavigation")
                        .WithMany("Descripcionpersonas")
                        .HasForeignKey("IdDireccionFk")
                        .HasConstraintName("descripcionpersona_ibfk_1");

                    b.Navigation("Contacto");

                    b.Navigation("IdDireccionFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.HasOne("Domain.Entities.Ciudad", "IdCiudadFkNavigation")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdCiudadFk")
                        .HasConstraintName("direccion_ibfk_1");

                    b.Navigation("IdCiudadFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Descripcionpersona", "IdDescripcionPersonaFkNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdDescripcionPersonaFk")
                        .HasConstraintName("empleado_ibfk_2");

                    b.HasOne("Domain.Entities.Puesto", "IdPuestoFkNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("IdPuestoFk")
                        .HasConstraintName("empleado_ibfk_1");

                    b.Navigation("IdDescripcionPersonaFkNavigation");

                    b.Navigation("IdPuestoFkNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.HasOne("Domain.Entities.Contrato", "IdContratoFkNavigation")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdContratoFk")
                        .HasConstraintName("programacion_ibfk_1");

                    b.HasOne("Domain.Entities.Empleado", "IdEmpleadoFkNavigation")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdEmpleadoFk")
                        .HasConstraintName("programacion_ibfk_3");

                    b.HasOne("Domain.Entities.Turno", "IdTurnoFkNavigation")
                        .WithMany("Programaciones")
                        .HasForeignKey("IdTurnoFk")
                        .HasConstraintName("programacion_ibfk_2");

                    b.Navigation("IdContratoFkNavigation");

                    b.Navigation("IdEmpleadoFkNavigation");

                    b.Navigation("IdTurnoFkNavigation");
                });

            modelBuilder.Entity("Userrol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", null)
                        .WithMany()
                        .HasForeignKey("IdRolFk")
                        .IsRequired()
                        .HasConstraintName("userrol_ibfk_2");

                    b.HasOne("Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("IdUserFk")
                        .IsRequired()
                        .HasConstraintName("userrol_ibfk_1");
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Contacto", b =>
                {
                    b.Navigation("Descripcionpersonas");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Domain.Entities.Descripcionpersona", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Navigation("Descripcionpersonas");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("Contratos");

                    b.Navigation("Programaciones");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Domain.Entities.Puesto", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.TipoContacto", b =>
                {
                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Navigation("Programaciones");
                });
#pragma warning restore 612, 618
        }
    }
}