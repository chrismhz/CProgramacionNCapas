﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CMartinezProgramacionNCapasEntities : DbContext
    {
        public CMartinezProgramacionNCapasEntities()
            : base("name=CMartinezProgramacionNCapasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Colonia> Colonia { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<ProductoSucursal> ProductoSucursal { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<ActualizacionPedidos> ActualizacionPedidos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedido { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Repartidor> Repartidor { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> edad)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var edadParameter = edad.HasValue ?
                new ObjectParameter("Edad", edad) :
                new ObjectParameter("Edad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, edadParameter);
        }
    
        public virtual int UsuarioGetDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioGetDelete", idUsuarioParameter);
        }
    
        public virtual ObjectResult<RolGetAll_Result> RolGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGetAll_Result>("RolGetAll");
        }
    
        public virtual int UsuarioGetUpdate(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string userName, string email, string password, string sexo, string telefono, string celular, string fechaNacimiento, string cURP, Nullable<int> idRol, byte[] imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioGetUpdate", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, userNameParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter, celularParameter, fechaNacimientoParameter, cURPParameter, idRolParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter);
        }
    
        public virtual ObjectResult<EstadoGetAll_Result> EstadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetAll_Result>("EstadoGetAll");
        }
    
        public virtual ObjectResult<ColoniaGetAll_Result> ColoniaGetAll(Nullable<int> idMunicipio)
        {
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("IdMunicipio", idMunicipio) :
                new ObjectParameter("IdMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ColoniaGetAll_Result>("ColoniaGetAll", idMunicipioParameter);
        }
    
        public virtual ObjectResult<MunicipioGetAll_Result> MunicipioGetAll(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MunicipioGetAll_Result>("MunicipioGetAll", idEstadoParameter);
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioInsert(string nombre, string apellidoPaterno, string apellidoMaterno, string userName, string email, string password, string sexo, string telefono, string celular, string fechaNacimiento, string cURP, Nullable<int> idRol, byte[] imagen, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioInsert", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, userNameParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter, celularParameter, fechaNacimientoParameter, cURPParameter, idRolParameter, imagenParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter);
        }
    
        public virtual int CambiarStatus(Nullable<int> idUsuario, Nullable<bool> status)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CambiarStatus", idUsuarioParameter, statusParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idRol)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idRolParameter);
        }
    
        public virtual int UsuarioGetALLBASD(string nombre, string apellidoPaterno, string apellidoMaterno, Nullable<int> idRol)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioGetALLBASD", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, idRolParameter);
        }
    
        public virtual int ProductoGetDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoGetDelete", idProductoParameter);
        }
    
        public virtual int ProductoAdd(string nombre, string descripcion, Nullable<decimal> precio, byte[] imagen, Nullable<int> idSubCategoria)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idSubCategoriaParameter = idSubCategoria.HasValue ?
                new ObjectParameter("IdSubCategoria", idSubCategoria) :
                new ObjectParameter("IdSubCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, descripcionParameter, precioParameter, imagenParameter, idSubCategoriaParameter);
        }
    
        public virtual int ProductoGetUpdate(Nullable<int> idProducto, string nombre, string descripcion, Nullable<decimal> precio, byte[] imagen, Nullable<int> idSubCategoria)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idSubCategoriaParameter = idSubCategoria.HasValue ?
                new ObjectParameter("IdSubCategoria", idSubCategoria) :
                new ObjectParameter("IdSubCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoGetUpdate", idProductoParameter, nombreParameter, descripcionParameter, precioParameter, imagenParameter, idSubCategoriaParameter);
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual ObjectResult<SucursalGetById_Result> SucursalGetById(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetById_Result>("SucursalGetById", idSucursalParameter);
        }
    
        public virtual ObjectResult<ProductoGetAll_Result> ProductoGetAll(Nullable<int> idSubCategoria)
        {
            var idSubCategoriaParameter = idSubCategoria.HasValue ?
                new ObjectParameter("IdSubCategoria", idSubCategoria) :
                new ObjectParameter("IdSubCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetAll_Result>("ProductoGetAll", idSubCategoriaParameter);
        }
    
        public virtual ObjectResult<ProductoSucursalGetById_Result> ProductoSucursalGetById(Nullable<int> idProductoSucursal)
        {
            var idProductoSucursalParameter = idProductoSucursal.HasValue ?
                new ObjectParameter("IdProductoSucursal", idProductoSucursal) :
                new ObjectParameter("IdProductoSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoSucursalGetById_Result>("ProductoSucursalGetById", idProductoSucursalParameter);
        }
    
        public virtual int ProductoSucursalDelete(Nullable<int> idProductoSucursal)
        {
            var idProductoSucursalParameter = idProductoSucursal.HasValue ?
                new ObjectParameter("IdProductoSucursal", idProductoSucursal) :
                new ObjectParameter("IdProductoSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoSucursalDelete", idProductoSucursalParameter);
        }
    
        public virtual int ProductoSucursalUpdate(Nullable<int> idProductoSucursal, Nullable<int> stock)
        {
            var idProductoSucursalParameter = idProductoSucursal.HasValue ?
                new ObjectParameter("IdProductoSucursal", idProductoSucursal) :
                new ObjectParameter("IdProductoSucursal", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoSucursalUpdate", idProductoSucursalParameter, stockParameter);
        }
    
        public virtual ObjectResult<ProductoSucursalGetAll_Result> ProductoSucursalGetAll(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoSucursalGetAll_Result>("ProductoSucursalGetAll", idSucursalParameter);
        }
    
        public virtual int SucursalAdd(string nombre, string latitud, string longitud)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var latitudParameter = latitud != null ?
                new ObjectParameter("Latitud", latitud) :
                new ObjectParameter("Latitud", typeof(string));
    
            var longitudParameter = longitud != null ?
                new ObjectParameter("Longitud", longitud) :
                new ObjectParameter("Longitud", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalAdd", nombreParameter, latitudParameter, longitudParameter);
        }
    
        public virtual int SucursalGetUpdate(Nullable<int> idSucursal, string nombre, string latitud, string longitud)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var latitudParameter = latitud != null ?
                new ObjectParameter("Latitud", latitud) :
                new ObjectParameter("Latitud", typeof(string));
    
            var longitudParameter = longitud != null ?
                new ObjectParameter("Longitud", longitud) :
                new ObjectParameter("Longitud", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalGetUpdate", idSucursalParameter, nombreParameter, latitudParameter, longitudParameter);
        }
    
        public virtual int SucursalGetDelete(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalGetDelete", idSucursalParameter);
        }
    
        public virtual ObjectResult<SucursalGetAll_Result> SucursalGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetAll_Result>("SucursalGetAll");
        }
    
        public virtual ObjectResult<PedidosGetAll_Result> PedidosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PedidosGetAll_Result>("PedidosGetAll");
        }
    
        public virtual ObjectResult<TipoPagoGetAll_Result> TipoPagoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoPagoGetAll_Result>("TipoPagoGetAll");
        }
    
        public virtual ObjectResult<EstadoPedidoGetAll_Result> EstadoPedidoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoPedidoGetAll_Result>("EstadoPedidoGetAll");
        }
    
        public virtual ObjectResult<RepartidorGetAll_Result> RepartidorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RepartidorGetAll_Result>("RepartidorGetAll");
        }
    
        public virtual int RepartidorAdd(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RepartidorAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual ObjectResult<RepartidorGetById_Result> RepartidorGetById(Nullable<int> idRepartidor)
        {
            var idRepartidorParameter = idRepartidor.HasValue ?
                new ObjectParameter("IdRepartidor", idRepartidor) :
                new ObjectParameter("IdRepartidor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RepartidorGetById_Result>("RepartidorGetById", idRepartidorParameter);
        }
    
        public virtual int RepartidorGetDelete(Nullable<int> idRepartidor)
        {
            var idRepartidorParameter = idRepartidor.HasValue ?
                new ObjectParameter("IdRepartidor", idRepartidor) :
                new ObjectParameter("IdRepartidor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RepartidorGetDelete", idRepartidorParameter);
        }
    
        public virtual int RepartidorGetUpdate(Nullable<int> idRepartidor, string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            var idRepartidorParameter = idRepartidor.HasValue ?
                new ObjectParameter("IdRepartidor", idRepartidor) :
                new ObjectParameter("IdRepartidor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RepartidorGetUpdate", idRepartidorParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter);
        }
    
        public virtual ObjectResult<ActualizacionPedidosGetAll_Result> ActualizacionPedidosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ActualizacionPedidosGetAll_Result>("ActualizacionPedidosGetAll");
        }
    }
}
