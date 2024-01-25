IF EXISTS (SELECT * FROM sysobjects WHERE name='SPObtenerFidelizadosPorCentroVenta') 
BEGIN
    DROP PROCEDURE [dbo].[SPObtenerFidelizadosPorCentroVenta]
END
GO
CREATE PROCEDURE [dbo].[SPObtenerFidelizadosPorCentroVenta]
    @CentroVentaId  int = NULL,
    @Filtro VARCHAR(MAX)
AS
BEGIN
    SELECT TOP (50) [Fidelizado].[Id]
        , [Fidelizado].[Documento]
        ,[Fidelizado].[TipoDocumentoId]
        ,[Fidelizado].[Nombre]
        ,[Fidelizado].[Puntos]
        ,[Fidelizado].[PorcentajePuntos]
        ,[Fidelizado].[PuntosReservados]
        ,[Fidelizado].[EstadoId]
        ,[InformacionAdicional].[Telefono]
        ,[InformacionAdicional].[Celular]
        ,[InformacionAdicional].[Direccion]
        ,[InformacionAdicional].[Estrato]
        ,[InformacionAdicional].[NumeroHijos]
        ,[InformacionAdicional].[SexoId]
        ,[InformacionAdicional].[CiudadId]
        ,[InformacionAdicional].[ProfesionId]
        ,[Ciudad].[Nombre] AS 'NombreCiudad'
    FROM [dbo].[Fidelizado]
    LEFT JOIN [dbo].[InformacionAdicional] ON [dbo].[InformacionAdicional].[FidelizadoId] = [dbo].[Fidelizado].[Id]
    INNER JOIN [dbo].[Ciudad] ON [dbo].[Ciudad].[Id] = [dbo].[InformacionAdicional].[CiudadId]
    WHERE [Fidelizado].[EstadoId] = 1 AND [Fidelizado].[CentroVentaId] = @CentroVentaId 
        AND ([Fidelizado].[Documento] LIKE '%'+@Filtro+'%' OR [Fidelizado].[Nombre] LIKE '%'+@Filtro+'%' 
        OR [Ciudad].[Nombre] LIKE '%'+@Filtro+'%')
END


