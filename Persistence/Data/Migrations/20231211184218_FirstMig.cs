using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "puesto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipocontacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    horaInicio = table.Column<TimeOnly>(type: "time", nullable: true),
                    horaFinal = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "departamento_ibfk_1",
                        column: x => x.idPaisFk,
                        principalTable: "pais",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoContactoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacto_tipocontacto_IdTipoContactoFk",
                        column: x => x.IdTipoContactoFk,
                        principalTable: "tipocontacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userrol",
                columns: table => new
                {
                    idUserFk = table.Column<int>(type: "int", nullable: false),
                    idRolFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.idUserFk, x.idRolFk })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "userrol_ibfk_1",
                        column: x => x.idUserFk,
                        principalTable: "user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "userrol_ibfk_2",
                        column: x => x.idRolFk,
                        principalTable: "rol",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "ciudad_ibfk_1",
                        column: x => x.idDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipo_via = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero_principal = table.Column<short>(type: "smallint", nullable: false),
                    letra_principal = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bis = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letra_secundaria = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cardinal_primario = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero_secundario = table.Column<short>(type: "smallint", nullable: false),
                    cardinal_secundario = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCiudadFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "direccion_ibfk_1",
                        column: x => x.idCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "descripcionpersona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idPersona = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaRegistro = table.Column<DateOnly>(type: "date", nullable: true),
                    idDireccionFk = table.Column<int>(type: "int", nullable: true),
                    IdContactoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_descripcionpersona_contacto_IdContactoFk",
                        column: x => x.IdContactoFk,
                        principalTable: "contacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "descripcionpersona_ibfk_1",
                        column: x => x.idDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idDescripcionPersonaFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "cliente_ibfk_1",
                        column: x => x.idDescripcionPersonaFk,
                        principalTable: "descripcionpersona",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idPuestoFk = table.Column<int>(type: "int", nullable: true),
                    idDescripcionPersonaFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "empleado_ibfk_1",
                        column: x => x.idPuestoFk,
                        principalTable: "puesto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "empleado_ibfk_2",
                        column: x => x.idDescripcionPersonaFk,
                        principalTable: "descripcionpersona",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fechaContrato = table.Column<DateOnly>(type: "date", nullable: true),
                    fechaFin = table.Column<DateOnly>(type: "date", nullable: true),
                    idClienteFk = table.Column<int>(type: "int", nullable: true),
                    idEstadoFk = table.Column<int>(type: "int", nullable: true),
                    idEmpleadoFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "contrato_ibfk_1",
                        column: x => x.idClienteFk,
                        principalTable: "cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contrato_ibfk_2",
                        column: x => x.idEstadoFk,
                        principalTable: "estado",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contrato_ibfk_3",
                        column: x => x.idEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idContratoFk = table.Column<int>(type: "int", nullable: true),
                    idTurnoFk = table.Column<int>(type: "int", nullable: true),
                    idEmpleadoFk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "programacion_ibfk_1",
                        column: x => x.idContratoFk,
                        principalTable: "contrato",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "programacion_ibfk_2",
                        column: x => x.idTurnoFk,
                        principalTable: "turno",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "programacion_ibfk_3",
                        column: x => x.idEmpleadoFk,
                        principalTable: "empleado",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "id",
                table: "ciudad",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idDepartamentoFk",
                table: "ciudad",
                column: "idDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "nombre",
                table: "ciudad",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id1",
                table: "cliente",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idDescripcionPersonaFk",
                table: "cliente",
                column: "idDescripcionPersonaFk");

            migrationBuilder.CreateIndex(
                name: "IX_contacto_IdTipoContactoFk",
                table: "contacto",
                column: "IdTipoContactoFk");

            migrationBuilder.CreateIndex(
                name: "id2",
                table: "contacto",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id3",
                table: "contrato",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idClienteFk",
                table: "contrato",
                column: "idClienteFk");

            migrationBuilder.CreateIndex(
                name: "idEmpleadoFk",
                table: "contrato",
                column: "idEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "idEstadoFk",
                table: "contrato",
                column: "idEstadoFk");

            migrationBuilder.CreateIndex(
                name: "id4",
                table: "departamento",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idPaisFk",
                table: "departamento",
                column: "idPaisFk");

            migrationBuilder.CreateIndex(
                name: "nombre1",
                table: "departamento",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_descripcionpersona_IdContactoFk",
                table: "descripcionpersona",
                column: "IdContactoFk");

            migrationBuilder.CreateIndex(
                name: "id5",
                table: "descripcionpersona",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idDireccionFk",
                table: "descripcionpersona",
                column: "idDireccionFk");

            migrationBuilder.CreateIndex(
                name: "idPersona",
                table: "descripcionpersona",
                column: "idPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id6",
                table: "direccion",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idCiudadFk",
                table: "direccion",
                column: "idCiudadFk");

            migrationBuilder.CreateIndex(
                name: "id7",
                table: "empleado",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idDescripcionPersonaFk1",
                table: "empleado",
                column: "idDescripcionPersonaFk");

            migrationBuilder.CreateIndex(
                name: "idPuestoFk",
                table: "empleado",
                column: "idPuestoFk");

            migrationBuilder.CreateIndex(
                name: "id8",
                table: "estado",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id9",
                table: "pais",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "nombre2",
                table: "pais",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id10",
                table: "programacion",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idContratoFk",
                table: "programacion",
                column: "idContratoFk");

            migrationBuilder.CreateIndex(
                name: "idEmpleadoFk1",
                table: "programacion",
                column: "idEmpleadoFk");

            migrationBuilder.CreateIndex(
                name: "idTurnoFk",
                table: "programacion",
                column: "idTurnoFk");

            migrationBuilder.CreateIndex(
                name: "id11",
                table: "puesto",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id12",
                table: "rol",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "nombre3",
                table: "rol",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id13",
                table: "tipocontacto",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id14",
                table: "turno",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id15",
                table: "user",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "password",
                table: "user",
                column: "password",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "username",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idRolFk",
                table: "userrol",
                column: "idRolFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "programacion");

            migrationBuilder.DropTable(
                name: "userrol");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "turno");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "puesto");

            migrationBuilder.DropTable(
                name: "descripcionpersona");

            migrationBuilder.DropTable(
                name: "contacto");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "tipocontacto");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
