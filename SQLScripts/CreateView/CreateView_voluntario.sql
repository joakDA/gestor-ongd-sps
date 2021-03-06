USE [gestor_ongd_sps_prod]
GO

/****** Object:  View [dbo].[voluntario]    Script Date: 15/08/2017 11:40:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[voluntario]
WITH  VIEW_METADATA
AS
SELECT        dbo.personas.id, dbo.personas.nombre, dbo.personas.apellidos, dbo.personas.direccionPostal, dbo.personas.codigoPostal, dbo.personas.localidad, dbo.personas.provincia, dbo.personas.pais, 
                         dbo.personas.telefono1, dbo.personas.telefono2, dbo.personas.email, dbo.personas.fechaNacimiento, dbo.voluntarios.fechaAlta, dbo.perfiles.nombre AS Perfiles, dbo.sede_delegacion.nombre AS Sede
FROM            dbo.perfiles INNER JOIN
                         dbo.personas INNER JOIN
                         dbo.personas_perfiles ON dbo.personas.id = dbo.personas_perfiles.idPersona ON dbo.perfiles.id = dbo.personas_perfiles.idPerfil INNER JOIN
                         dbo.voluntarios ON dbo.personas.id = dbo.voluntarios.idVoluntario INNER JOIN
                         dbo.sede_delegacion ON dbo.voluntarios.sede = dbo.sede_delegacion.id
WHERE        (dbo.perfiles.nombre = N'Voluntario')
WITH CHECK OPTION

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
         Begin Table = "personas_perfiles"
            Begin Extent = 
               Top = 6
               Left = 464
               Bottom = 119
               Right = 634
            End
            DisplayFlags = 344
            TopColumn = 0
         End
         Begin Table = "sede_delegacion"
            Begin Extent = 
               Top = 124
               Left = 599
               Bottom = 254
               Right = 781
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "personas"
            Begin Extent = 
               Top = 101
               Left = 295
               Bottom = 231
               Right = 475
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "voluntarios"
            Begin Extent = 
               Top = 6
               Left = 892
               Bottom = 136
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
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Widt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'h = 1500
         Width = 2670
         Width = 1500
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
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'voluntario'
GO


