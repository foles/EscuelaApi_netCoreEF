
SET IDENTITY_INSERT [dbo].[escuela] ON

INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (1, N'a', N'LA PAZsa', N'ROMERO PAMPAsda', N'UNIDAD EDUCATIVAasd')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (31, N'Adventista Salomon', N'La PAz', N'AV. Civica', N'Escuela')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (32, N'Mejillones', N'La Paz', N'Av. Policia', N'Colegio')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (33, N'San Tomas', N'BENI', N'AV. Redencion', N'Escuela')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (34, N'Amerinst', N'Potosi', N'Av. Los Andes', N'Colegio')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (35, N'Bolivir', N'Santa Cruz', N'Av. Los Olivos', N'Colegio')
INSERT [dbo].[escuela]
    ([id], [nombre], [dpto], [direccion], [tipo])
VALUES
    (36, N'Antofagasta', N'Cochabamba', N'Av. Polomillo', N'Unidad Educativa')
SET IDENTITY_INSERT [dbo].[escuela] OFF
GO
SET IDENTITY_INSERT [dbo].[estudiante] ON

INSERT [dbo].[estudiante]
    ([id], [nombre], [apellido], [fechanac], [correo], [foto], [escuelaId])
VALUES
    (1, N'Marco', N'Fernandez', CAST(N'1980-03-14' AS Date), N'marco@gmail.com', N'https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=94', 1)
INSERT [dbo].[estudiante]
    ([id], [nombre], [apellido], [fechanac], [correo], [foto], [escuelaId])
VALUES
    (2, N'Maria', N'Dolores', CAST(N'1980-03-14' AS Date), N'maria@gmail.com', N'https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=94', 1)
SET IDENTITY_INSERT [dbo].[estudiante] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[profesor] ON

INSERT [dbo].[profesor]
    ([id], [nombre], [apellido], [fechanac], [correo], [foto], [escuelaId])
VALUES
    (1, N'Jose', N'Apaza', CAST(N'1980-03-14' AS Date), N'jose@gmail.com', N'https://cdn.pixabay.com/photo/2016/03/27/17/42/man-1283235_960_720.jpg', 1)
INSERT [dbo].[profesor]
    ([id], [nombre], [apellido], [fechanac], [correo], [foto], [escuelaId])
VALUES
    (2, N'Andres', N'Lopez', CAST(N'1980-03-14' AS Date), N'andres@gmail.com', N'https://cdn.pixabay.com/photo/2015/01/08/18/29/entrepreneur-593358_960_720.jpg', 1)
SET IDENTITY_INSERT [dbo].[profesor] OFF
GO

SET IDENTITY_INSERT [dbo].[materia] ON

INSERT [dbo].[materia]
    ([id], [nombre], [descripcion], [logo], [profesorId])
VALUES
    (1, N'Matematica', N'Materia Matematica - Turno Tarde', N'null', 1)
INSERT [dbo].[materia]
    ([id], [nombre], [descripcion], [logo], [profesorId])
VALUES
    (2, N'Lenguaje', N'Materia Lenguaje - Turno Tarde', N'null', 1)
SET IDENTITY_INSERT [dbo].[materia] OFF

SET IDENTITY_INSERT [dbo].[trabajo] ON

INSERT [dbo].[trabajo]
    ([id], [descripcion], [tipo], [nota], [fechaent], [estudianteId])
VALUES
    (1, N'Laboratorio 1', N'Examen', 70, N'2020-10-01', 1)
INSERT [dbo].[trabajo]
    ([id], [descripcion], [tipo], [nota], [fechaent], [estudianteId])
VALUES
    (2, N'Informe 1', N'Trabajo', 70, N'2020-10-01', 1)
INSERT [dbo].[trabajo]
    ([id], [descripcion], [tipo], [nota], [fechaent], [estudianteId])
VALUES
    (3, N'Informe 2', N'Trabajo', 100, N'2020-10-01', 1)
INSERT [dbo].[trabajo]
    ([id], [descripcion], [tipo], [nota], [fechaent], [estudianteId])
VALUES
    (4, N'Primer Parcial', N'Examen', 99, N'2020-10-01', 1)
SET IDENTITY_INSERT [dbo].[trabajo] OFF
GO
ALTER TABLE [dbo].[estudiante]  WITH CHECK ADD  CONSTRAINT [FK_estudiante_escuela] FOREIGN KEY([escuelaId])
REFERENCES [dbo].[escuela] ([id])
GO
ALTER TABLE [dbo].[estudiante] CHECK CONSTRAINT [FK_estudiante_escuela]
GO
ALTER TABLE [dbo].[materia]  WITH CHECK ADD  CONSTRAINT [FK_materia_profesor] FOREIGN KEY([profesorId])
REFERENCES [dbo].[profesor] ([id])
GO
ALTER TABLE [dbo].[materia] CHECK CONSTRAINT [FK_materia_profesor]
GO
ALTER TABLE [dbo].[profesor]  WITH CHECK ADD  CONSTRAINT [FK_profesor_escuela] FOREIGN KEY([escuelaId])
REFERENCES [dbo].[escuela] ([id])
GO
ALTER TABLE [dbo].[profesor] CHECK CONSTRAINT [FK_profesor_escuela]
GO
ALTER TABLE [dbo].[trabajo]  WITH CHECK ADD  CONSTRAINT [FK_trabajo_estudiante] FOREIGN KEY([estudianteId])
REFERENCES [dbo].[estudiante] ([id])
GO
ALTER TABLE [dbo].[trabajo] CHECK CONSTRAINT [FK_trabajo_estudiante]
GO
