USE [gestor_ongd_sps_prod]
GO

/****** Object:  View [dbo].[vistaColaboradores]    Script Date: 30/07/2017 20:45:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vistaColaboradores]
AS
SELECT        dbo.personas.id, dbo.personas.nombre, dbo.personas.apellidos, dbo.personas.direccionPostal, dbo.personas.codigoPostal, dbo.personas.localidad, dbo.personas.provincia, dbo.personas.pais, 
                         dbo.personas.telefono1, dbo.personas.telefono2, dbo.personas.email, dbo.personas.fechaNacimiento, dbo.colaboradores.CIF_NIF, dbo.colaboradores.CuentaBancaria, dbo.perfiles.nombre AS Perfiles, 
                         dbo.donaciones.cantidad, dbo.donaciones.fechaAlta, dbo.periodicidades.nombre AS Periodicidad
FROM            dbo.colaboradores INNER JOIN
                         dbo.personas ON dbo.colaboradores.idColaborador = dbo.personas.id INNER JOIN
                         dbo.personas_perfiles ON dbo.personas.id = dbo.personas_perfiles.idPersona INNER JOIN
                         dbo.perfiles ON dbo.personas_perfiles.idPerfil = dbo.perfiles.id INNER JOIN
                         dbo.donaciones ON dbo.colaboradores.idColaborador = dbo.donaciones.idColaborador INNER JOIN
                         dbo.periodicidades ON dbo.donaciones.idPeriodicidad = dbo.periodicidades.id
WHERE        (dbo.perfiles.nombre = N'Colaborador')
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "colaboradores"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "personas"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 136
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "personas_perfiles"
            Begin Extent = 
               Top = 6
               Left = 466
               Bottom = 119
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "perfiles"
            Begin Extent = 
               Top = 6
               Left = 674
               Bottom = 102
               Right = 844
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "donaciones"
            Begin Extent = 
               Top = 6
               Left = 882
               Bottom = 136
               Right = 1052
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "periodicidades"
            Begin Extent = 
               Top = 6
               Left = 1090
               Bottom = 102
               Right = 1260
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Colum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaColaboradores'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'n = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaColaboradores'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vistaColaboradores'
GO


