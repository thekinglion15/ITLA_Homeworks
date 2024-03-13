
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/29/2024 15:51:17
-- Generated from EDMX file: C:\Users\The King Lion\OneDrive\University\ITLA\C# .NET Intermedio\Homeworks\Programas\ProyectoVentas2\Sales.ConceptualModel\SalesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sales];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__DetalleVe__IdVen__6EF57B66]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVenta] DROP CONSTRAINT [FK__DetalleVe__IdVen__6EF57B66];
GO
IF OBJECT_ID(N'[dbo].[FK__Menu__IdMenuPadr__6FE99F9F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menu] DROP CONSTRAINT [FK__Menu__IdMenuPadr__6FE99F9F];
GO
IF OBJECT_ID(N'[dbo].[FK__Producto__IdCate__70DDC3D8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK__Producto__IdCate__70DDC3D8];
GO
IF OBJECT_ID(N'[dbo].[FK__RolMenu__IdMenu__71D1E811]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolMenu] DROP CONSTRAINT [FK__RolMenu__IdMenu__71D1E811];
GO
IF OBJECT_ID(N'[dbo].[FK__RolMenu__IdRol__72C60C4A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolMenu] DROP CONSTRAINT [FK__RolMenu__IdRol__72C60C4A];
GO
IF OBJECT_ID(N'[dbo].[FK__Usuario__IdRol__73BA3083]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuario] DROP CONSTRAINT [FK__Usuario__IdRol__73BA3083];
GO
IF OBJECT_ID(N'[dbo].[FK__Venta__IdTipoDoc__74AE54BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Venta] DROP CONSTRAINT [FK__Venta__IdTipoDoc__74AE54BC];
GO
IF OBJECT_ID(N'[dbo].[FK__Venta__IdUsuario__75A278F5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Venta] DROP CONSTRAINT [FK__Venta__IdUsuario__75A278F5];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[Configuracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Configuracion];
GO
IF OBJECT_ID(N'[dbo].[DetalleVenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleVenta];
GO
IF OBJECT_ID(N'[dbo].[Menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menu];
GO
IF OBJECT_ID(N'[dbo].[Negocio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Negocio];
GO
IF OBJECT_ID(N'[dbo].[NumeroCorrelativo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NumeroCorrelativo];
GO
IF OBJECT_ID(N'[dbo].[Producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto];
GO
IF OBJECT_ID(N'[dbo].[Rol]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rol];
GO
IF OBJECT_ID(N'[dbo].[RolMenu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolMenu];
GO
IF OBJECT_ID(N'[dbo].[TipoDocumentoVenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDocumentoVenta];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO
IF OBJECT_ID(N'[dbo].[Venta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Venta];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Configuracions'
CREATE TABLE [dbo].[Configuracions] (
    [Id] smallint IDENTITY(1,1) NOT NULL,
    [Recurso] varchar(50)  NULL,
    [Propiedad] varchar(50)  NULL,
    [Valor] varchar(60)  NULL
);
GO

-- Creating table 'DetalleVentas'
CREATE TABLE [dbo].[DetalleVentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdVenta] int  NULL,
    [IdProducto] int  NULL,
    [MarcaProducto] varchar(100)  NULL,
    [DescripcionProducto] varchar(100)  NULL,
    [CategoriaProducto] varchar(100)  NULL,
    [Cantidad] int  NULL,
    [Precio] decimal(10,2)  NULL,
    [Total] decimal(10,2)  NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(30)  NULL,
    [IdMenuPadre] int  NULL,
    [Icono] varchar(30)  NULL,
    [Controlador] varchar(30)  NULL,
    [PaginaAccion] varchar(30)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Negocios'
CREATE TABLE [dbo].[Negocios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UrlLogo] varchar(500)  NULL,
    [NombreLogo] varchar(100)  NULL,
    [NumeroDocumento] varchar(50)  NULL,
    [Nombre] varchar(50)  NULL,
    [Correo] varchar(50)  NULL,
    [Direccion] varchar(50)  NULL,
    [Telefono] varchar(50)  NULL,
    [PorcentajeImpuesto] decimal(10,2)  NULL,
    [SimboloMoneda] varchar(5)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'NumeroCorrelativoes'
CREATE TABLE [dbo].[NumeroCorrelativoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UltimoNumero] int  NULL,
    [CantidadDigitos] int  NULL,
    [Gestion] varchar(100)  NULL,
    [FechaActualizacion] datetime  NULL
);
GO

-- Creating table 'Productoes'
CREATE TABLE [dbo].[Productoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodigoBarra] varchar(50)  NULL,
    [Marca] varchar(50)  NULL,
    [Descripcion] varchar(100)  NULL,
    [IdCategoria] int  NULL,
    [Stock] int  NULL,
    [UrlImagen] varchar(500)  NULL,
    [NombreImagen] varchar(100)  NULL,
    [Precio] decimal(10,2)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Rols'
CREATE TABLE [dbo].[Rols] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(30)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'RolMenus'
CREATE TABLE [dbo].[RolMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdRol] int  NULL,
    [IdMenu] int  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'TipoDocumentoVentas'
CREATE TABLE [dbo].[TipoDocumentoVentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(50)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Correo] varchar(50)  NULL,
    [Telefono] varchar(50)  NULL,
    [IdRol] int  NULL,
    [UrlFoto] varchar(500)  NULL,
    [NombreFoto] varchar(100)  NULL,
    [Clave] varchar(100)  NULL,
    [EsActivo] bit  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL,
    [FechaMod] datetime  NULL,
    [IdUsuarioMod] int  NULL,
    [IdUsuarioElimino] int  NULL,
    [FechaElimino] datetime  NULL,
    [Eliminado] bit  NOT NULL
);
GO

-- Creating table 'Ventas'
CREATE TABLE [dbo].[Ventas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumeroVenta] varchar(6)  NULL,
    [IdTipoDocumentoVenta] int  NULL,
    [IdUsuario] int  NULL,
    [CocumentoCliente] varchar(10)  NULL,
    [NombreCliente] varchar(20)  NULL,
    [SubTotal] decimal(10,2)  NULL,
    [ImpuestoTotal] decimal(10,2)  NULL,
    [Total] decimal(10,2)  NULL,
    [FechaRegistro] datetime  NOT NULL,
    [IdUsuarioCreacion] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Configuracions'
ALTER TABLE [dbo].[Configuracions]
ADD CONSTRAINT [PK_Configuracions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [PK_DetalleVentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Negocios'
ALTER TABLE [dbo].[Negocios]
ADD CONSTRAINT [PK_Negocios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NumeroCorrelativoes'
ALTER TABLE [dbo].[NumeroCorrelativoes]
ADD CONSTRAINT [PK_NumeroCorrelativoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [PK_Productoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rols'
ALTER TABLE [dbo].[Rols]
ADD CONSTRAINT [PK_Rols]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RolMenus'
ALTER TABLE [dbo].[RolMenus]
ADD CONSTRAINT [PK_RolMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoDocumentoVentas'
ALTER TABLE [dbo].[TipoDocumentoVentas]
ADD CONSTRAINT [PK_TipoDocumentoVentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [PK_Ventas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCategoria] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [FK__Producto__IdCate__70DDC3D8]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Producto__IdCate__70DDC3D8'
CREATE INDEX [IX_FK__Producto__IdCate__70DDC3D8]
ON [dbo].[Productoes]
    ([IdCategoria]);
GO

-- Creating foreign key on [IdVenta] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [FK__DetalleVe__IdVen__6EF57B66]
    FOREIGN KEY ([IdVenta])
    REFERENCES [dbo].[Ventas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DetalleVe__IdVen__6EF57B66'
CREATE INDEX [IX_FK__DetalleVe__IdVen__6EF57B66]
ON [dbo].[DetalleVentas]
    ([IdVenta]);
GO

-- Creating foreign key on [IdMenuPadre] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK__Menu__IdMenuPadr__6FE99F9F]
    FOREIGN KEY ([IdMenuPadre])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Menu__IdMenuPadr__6FE99F9F'
CREATE INDEX [IX_FK__Menu__IdMenuPadr__6FE99F9F]
ON [dbo].[Menus]
    ([IdMenuPadre]);
GO

-- Creating foreign key on [IdMenu] in table 'RolMenus'
ALTER TABLE [dbo].[RolMenus]
ADD CONSTRAINT [FK__RolMenu__IdMenu__71D1E811]
    FOREIGN KEY ([IdMenu])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RolMenu__IdMenu__71D1E811'
CREATE INDEX [IX_FK__RolMenu__IdMenu__71D1E811]
ON [dbo].[RolMenus]
    ([IdMenu]);
GO

-- Creating foreign key on [IdRol] in table 'RolMenus'
ALTER TABLE [dbo].[RolMenus]
ADD CONSTRAINT [FK__RolMenu__IdRol__72C60C4A]
    FOREIGN KEY ([IdRol])
    REFERENCES [dbo].[Rols]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__RolMenu__IdRol__72C60C4A'
CREATE INDEX [IX_FK__RolMenu__IdRol__72C60C4A]
ON [dbo].[RolMenus]
    ([IdRol]);
GO

-- Creating foreign key on [IdRol] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK__Usuario__IdRol__73BA3083]
    FOREIGN KEY ([IdRol])
    REFERENCES [dbo].[Rols]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Usuario__IdRol__73BA3083'
CREATE INDEX [IX_FK__Usuario__IdRol__73BA3083]
ON [dbo].[Usuarios]
    ([IdRol]);
GO

-- Creating foreign key on [IdTipoDocumentoVenta] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [FK__Venta__IdTipoDoc__74AE54BC]
    FOREIGN KEY ([IdTipoDocumentoVenta])
    REFERENCES [dbo].[TipoDocumentoVentas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Venta__IdTipoDoc__74AE54BC'
CREATE INDEX [IX_FK__Venta__IdTipoDoc__74AE54BC]
ON [dbo].[Ventas]
    ([IdTipoDocumentoVenta]);
GO

-- Creating foreign key on [IdUsuario] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [FK__Venta__IdUsuario__75A278F5]
    FOREIGN KEY ([IdUsuario])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Venta__IdUsuario__75A278F5'
CREATE INDEX [IX_FK__Venta__IdUsuario__75A278F5]
ON [dbo].[Ventas]
    ([IdUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------