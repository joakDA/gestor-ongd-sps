USE [gestor_ongd_sps_prod]
GO

/****** Object:  View [dbo].[voluntario]    Script Date: 09/06/2017 18:53:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[voluntario]
AS
SELECT        TOP (100) PERCENT dbo.personas.id, dbo.personas.nombre, dbo.personas.apellidos, dbo.personas.direccionPostal, dbo.personas.codigoPostal, dbo.personas.localidad, dbo.personas.provincia, 
                         dbo.personas.pais, dbo.personas.telefono1, dbo.personas.telefono2, dbo.personas.email, dbo.personas.fechaNacimiento, dbo.voluntarios.fechaAlta, dbo.sede_delegacion.nombre AS Sede, 
                         dbo.perfiles.nombre AS Perfiles
FROM            dbo.perfiles INNER JOIN
                         dbo.personas ON dbo.perfiles.id = dbo.personas.id INNER JOIN
                         dbo.personas_perfiles ON dbo.perfiles.id = dbo.personas_perfiles.idPerfil AND dbo.personas.id = dbo.personas_perfiles.idPersona INNER JOIN
                         dbo.sede_delegacion ON dbo.perfiles.id = dbo.sede_delegacion.id INNER JOIN
                         dbo.voluntarios ON dbo.personas.id = dbo.voluntarios.idVoluntario AND dbo.sede_delegacion.id = dbo.voluntarios.sede
ORDER BY dbo.personas.nombre, dbo.personas.apellidos

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
         Begin Table = "perfiles"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "personas"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "personas_perfiles"
            Begin Extent = 
               Top = 6
               Left = 464
               Bottom = 119
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sede_delegacion"
            Begin Extent = 
               Top = 6
               Left = 672
               Bottom = 136
               Right = 854
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "voluntarios"
            Begin Extent = 
               Top = 6
               Left = 892
               Bottom = 119
               Right = 1062
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
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 855
         Or = 1350' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO


