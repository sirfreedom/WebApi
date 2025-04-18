USE [TestSpain]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdQuestion] [int] NOT NULL,
	[AnswerDescription] [varchar](500) NOT NULL,
	[Valid] [bit] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Dependency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Dependency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FinalTestMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDependency] [int] NOT NULL,
	[Cod] [int] NOT NULL,
	[answersrangemin] [smallint] NOT NULL,
	[answersrangemax] [smallint] NOT NULL,
	[FinalTestMessageDescription] [varchar](500) NOT NULL,
 CONSTRAINT [PK_FinalTestMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [FinalTestMessageQuestionLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFinalTestMessage] [int] NOT NULL,
	[IdQuestionLevel] [int] NOT NULL,
 CONSTRAINT [PK_FinalTestMessageLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImagenTest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageText] [text] NOT NULL,
 CONSTRAINT [PK_ImagenTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDependency] [int] NOT NULL,
	[QuestionDescription] [varchar](500) NOT NULL,
	[Cod] [varchar](50) NOT NULL,
	[IdQuestionLevel] [int] NOT NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [QuestionLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDependency] [int] NOT NULL,
	[Cod] [int] NOT NULL,
	[QuestionLevelDescription] [varchar](50) NOT NULL,
	[Class] [varchar](50) NOT NULL,
 CONSTRAINT [PK_QuestionLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Setting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDependency] [int] NOT NULL,
	[cod] [smallint] NOT NULL,
	[questionperpage] [tinyint] NOT NULL,
	[correctanswers] [tinyint] NOT NULL,
	[tittle] [varchar](250) NOT NULL,
	[subtittle] [varchar](250) NOT NULL,
	[instruction] [varchar](5000) NULL,
	[downloadtittle] [varchar](5000) NULL,
	[downloadlink] [varchar](5000) NULL,
	[preinstructiontittle] [varchar](250) NULL,
	[preinstruction] [varchar](5000) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Answer] ON 

INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (78, 1, N'Una monarquia parlamentaria', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (79, 1, N'Una Republica federal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (80, 1, N'Una Monarquia federal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (81, 2, N'Constitucion', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (82, 2, N'Ley basica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (83, 2, N'Ordenamiento esencial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (84, 3, N'el pueblo español', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (85, 3, N'el gobierno del Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (86, 3, N'el Congreso de los Diputados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (87, 4, N'una institucion Europea', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (88, 4, N'Un organismo Español', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (89, 4, N'una ONG', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (90, 5, N'Ninguna', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (91, 5, N'Una', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (92, 5, N'Dos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (93, 6, N'En toda españa', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (94, 6, N'Solo donde no hay otras lenguas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (95, 6, N'En toda la peninsula Iberica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (96, 7, N'Policia local', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (97, 7, N'Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (98, 7, N'Policia Foral de Navarra', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (99, 8, N'La Policia Foral de Navarra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (100, 8, N'El cuerpo nacional de policia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (101, 8, N'Los Mossos d''Escuadra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (102, 9, N'Judicial', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (103, 9, N'Informativo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (104, 9, N'Politico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (105, 10, N'Solo los dias de fiesta oficial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (106, 10, N'En todos los edificios publicos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (107, 10, N'Solo en los actos del gobierno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (108, 11, N'El Consejo Economico y Social', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (109, 11, N'El Instituto Nacional de Estadistica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (110, 11, N'La Agencia Tributaria', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (111, 12, N'El Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (112, 12, N'Las comunidades autónomas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (113, 12, N'Los ayuntamientos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (114, 13, N'Mariano Rayoy', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (115, 13, N'Adolfo Suarez', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (116, 13, N'Jose Luis Rodriguez Zapatero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (117, 13, N'Ninguno de estos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (118, 14, N'Dependiente', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (119, 14, N'Independiente', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (120, 14, N'Subordinado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (121, 15, N'El Presidente del Gobierno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (122, 15, N'El Rey', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (123, 15, N'El ministro de Asuntos Exteriores, Union Europea y Cooperacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (124, 16, N'En 1986', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (125, 16, N'En 1950', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (126, 16, N'En 2013', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (127, 17, N'17', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (128, 17, N'2', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (129, 17, N'50', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (130, 18, N'Por ley', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (131, 18, N'En referendum', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (132, 18, N'Lo mando el rey', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (133, 19, N'Estatuto de Autonomia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (134, 19, N'Normativa autonomica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (135, 19, N'Ley de la comunidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (136, 20, N'Ayuntamiento', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (137, 20, N'Ministerio de Educacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (138, 20, N'Gobierno federal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (139, 21, N'Los ayuntamientos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (140, 21, N'El Gobierno', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (141, 21, N'Las Cortes Generales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (142, 22, N'Cabildos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (143, 22, N'Consejos insulares', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (144, 22, N'Congresos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (145, 23, N'Sevilla', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (146, 23, N'Barcelona', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (147, 23, N'Zaragoza', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (148, 24, N'Organizacion del tratado del Atlantico Norte (OTAN)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (149, 24, N'Organizacion Internacional de Energia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (150, 24, N'Consejo para el desarrollo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (151, 25, N'Ejecutivo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (152, 25, N'Legislativo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (153, 25, N'Judicial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (154, 26, N'2', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (155, 26, N'3', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (156, 26, N'4', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (157, 27, N'8', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (158, 27, N'17', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (159, 27, N'25', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (160, 28, N'Blanco y Rojo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (161, 28, N'Rojo y Amarillo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (162, 28, N'Amarillo y Blanco', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (163, 29, N'En Madrid', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (164, 29, N'En Barcelona', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (165, 29, N'En Sevilla', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (166, 29, N'Ninguna de estas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (167, 30, N'La Union Europea', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (168, 30, N'La Organizacion de Seguridad y Cooperacion en Europa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (169, 30, N'La Comision de Europa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (170, 31, N'Cuatro años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (171, 31, N'Cinco años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (172, 31, N'Seis años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (173, 32, N'El Bable', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (174, 32, N'El Aragones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (175, 32, N'El Euskera', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (176, 32, N'Todos', 0)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (177, 33, N'Autonomica del Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (178, 33, N'Oficial del Estado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (179, 33, N'Local del Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (180, 33, N'Local de cada ciudad autonoma', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (181, 34, N'El Catalan', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (182, 34, N'El Murciano', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (183, 34, N'El asturleones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (184, 34, N'Ninguna', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (185, 35, N'La diputacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (186, 35, N'El Presidente', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (187, 35, N'El delegado de Gobierno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (188, 36, N'El gallego', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (189, 36, N'El Aragones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (190, 36, N'El murciano', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (191, 36, N'Ninguna', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (192, 37, N'El Instituto Nacional de Administracion Publica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (193, 37, N'El Instituto Nacional de estadistica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (194, 37, N'El Instituto Cervantes', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (195, 38, N'El instituto Ramon Llull', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (196, 38, N'El Instituto Cervantes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (197, 38, N'La Real Academia Española', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (198, 39, N'En el Palacio Real', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (199, 39, N'En el Palacio de la Zarzuela', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (200, 39, N'En el Palacio de la Moncloa', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (201, 40, N'La Policia Foral', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (202, 40, N'La Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (203, 40, N'El Ejercito del Aire', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (204, 41, N'Los Ministros', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (205, 41, N'Los Concejales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (206, 41, N'Los alcaldes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (207, 42, N'Estado social y democratico de Derecho', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (208, 42, N'Estado libre asociado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (209, 42, N'Estado confederado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (210, 43, N'Mariano Rajoy', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (211, 43, N'Jose Luiz Rodriguez Zapatero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (212, 43, N'Pedro Sanchez', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (213, 44, N'Princesa de Asturias', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (214, 44, N'Princesa de Aragon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (215, 44, N'Duquesa de Alba', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (216, 45, N'Con Carlos III', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (217, 45, N'Con Alfonso XIII', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (218, 45, N'Con Juan Carlos I', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (219, 46, N'En 1957', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (220, 46, N'En 1978', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (221, 46, N'En 2001', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (222, 47, N'Ninguna', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (223, 47, N'Todas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (224, 47, N'Las que tienen una lengua co-Oficial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (225, 48, N'Dos veces', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (226, 48, N'Tres veces', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (227, 48, N'Cuatro veces', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (228, 49, N'Ninguna', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (229, 49, N'Una vez', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (230, 49, N'Dos veces', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (231, 50, N'Al Mercado Comun del Sur (Mercosur)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (232, 50, N'A la Organizacion de las Naciones Unidad (ONU)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (233, 50, N'A la Union Economica EuroAsiatica (UEE)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (234, 51, N'estatal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (235, 51, N'regional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (236, 51, N'local', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (237, 52, N'al presidente y los ministros', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (238, 52, N'a los jueces y magistrados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (239, 52, N'a los diputados y senadores', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (240, 53, N'En el palacio de la Moneda', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (241, 53, N'En el Palacio de la Zarzuela', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (242, 53, N'En el Palacio de la Moncloa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (243, 54, N'Cortes Generales', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (244, 54, N'Congreso de los Diputados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (245, 54, N'Senado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (246, 55, N'Consejales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (247, 55, N'Ministros', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (248, 55, N'Gobernadores', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (249, 56, N'Solo los hombres', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (250, 56, N'Solo las mujeres', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (251, 56, N'Tanto los hombres como las mujeres', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (252, 57, N'crear empleo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (253, 57, N'elaborar leyes', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (254, 57, N'elegir alcaldes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (255, 58, N'El Presidente del Senado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (256, 58, N'El ministro de Economia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (257, 58, N'El presidente del Congreso de los Diputados', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (258, 59, N'Gallego', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (259, 59, N'Catalan', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (260, 59, N'Euskera', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (261, 60, N'La justicia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (262, 60, N'La Solidaridad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (263, 60, N'La Fraternidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (264, 61, N'100.000 km^2', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (265, 61, N'500.000 km^2', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (266, 61, N'1.000.000 km^2', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (267, 62, N'35 millones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (268, 62, N'47 millones', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (269, 62, N'62 millones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (270, 63, N'El Parlamento Europeo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (271, 63, N'El Consejo de Estado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (272, 63, N'El Tribunal Constitucional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (273, 64, N'El Rey', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (274, 64, N'El Gobierno', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (275, 64, N'El Congreso de los Diputados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (276, 65, N'el Consejo de Ministros', 0)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (277, 65, N'el Tribunal de Cuentas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (278, 65, N'las Cortes Generales', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (279, 66, N'euskera y la cultura vasca', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (280, 66, N'babley la cultura cantabra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (281, 66, N'gallego y la cultura galaica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (282, 67, N'22 paises de America y Europa', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (283, 67, N'America del Sur y España', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (284, 67, N'Todos los paises donde se habla español', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (285, 68, N'vascas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (286, 68, N'catalanas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (287, 68, N'gallegas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (288, 69, N'Juan Carlos I', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (289, 69, N'Felipe VI', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (290, 69, N'Alfonso XIII', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (291, 70, N'Tribunal Supremo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (292, 70, N'Consejo General del Poder Judicial', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (293, 70, N'Consejo de Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (294, 71, N'Las Cortes Generales', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (295, 71, N'La Junta Electoral Central', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (296, 71, N'El Rey', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (297, 72, N'La ley fundamental', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (298, 72, N'parte de la otra ley', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (299, 72, N'una ley secundaria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (300, 73, N'el Congreso de los Diputados', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (301, 73, N'el Tribunal Supremo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (302, 73, N'el Consejo de Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (303, 74, N'El poder ejecutivo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (304, 74, N'El poder legislativo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (305, 74, N'El poder judicial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (306, 75, N'la Policia Nacional y Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (307, 75, N'las Fuerzas Armadas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (308, 75, N'la Policia Nacional y las Policias Autonomicas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (309, 76, N'Organizacion de Estados IberoAmericanos (OEI)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (310, 76, N'Union Europea Occidental (UEO)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (311, 76, N'Organizacion Naciones Unidas (ONU)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (312, 77, N'La Guardia Civil', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (313, 77, N'La Policia local', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (314, 77, N'La Policia Nacional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (315, 78, N'La Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (316, 78, N'La Policia local', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (317, 78, N'La Policia Nacional', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (318, 79, N'La Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (319, 79, N'La Policia Local', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (320, 79, N'La Policia Nacional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (321, 80, N'Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (322, 80, N'Ertzaintza', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (323, 80, N'Mossos d''Esquadra', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (324, 81, N'Ertzaintza', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (325, 81, N'Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (326, 81, N'Mossos d''Escuadra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (327, 82, N'Desde 1975', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (328, 82, N'Desde 2014', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (329, 82, N'Desde 2020', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (330, 83, N'1992 a 1996', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (331, 83, N'1980 a 1986', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (332, 83, N'1996 a 2004', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (333, 84, N'Jose Maria Aznar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (334, 84, N'Jose Luis Rodriguez Zapatero III', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (335, 84, N'Felipe Gonzalez', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (336, 85, N'Solo los ciudadanos legalmente residentes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (337, 85, N'Solo los españoles mayores de 18 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (338, 85, N'todos los ciudadanos, españoles o extranjeros', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (339, 86, N'un derecho', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (340, 86, N'un deber', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (341, 86, N'una obligacions', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (342, 87, N'Guardia Civil', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (343, 87, N'La Policia Nacional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (344, 87, N'El Ejercito de Tierra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (345, 88, N'El Tribunal de Cuentas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (346, 88, N'La Agencia Tributaria', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (347, 88, N'El Consejo Economico Social', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (348, 89, N'En el boletin del instituto Nacional de Estadistica (INE)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (349, 89, N'En el Portal de la Administracion Electronica (PAE)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (350, 89, N'En el Boletin Oficial del Estado (BOE)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (351, 90, N'Cabildos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (352, 90, N'Consejos Insulares', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (353, 90, N'Diputaciones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (354, 91, N'En el INE (Instituto Nacional de Estadistica)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (355, 91, N'En el BOE (Boletin Oficial del Estado)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (356, 91, N'En el PAE (Portal de la Administracion Electronica)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (357, 92, N'010', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (358, 92, N'060', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (359, 92, N'091', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (360, 93, N'Cantones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (361, 93, N'Comunidades autonomas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (362, 93, N'Estados federales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (363, 94, N'Ninguno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (364, 94, N'Uno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (365, 94, N'Muchos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (366, 95, N'200', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (367, 95, N'8.131', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (368, 95, N'100.000', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (369, 96, N'El Rey', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (370, 96, N'El presidente del Gobierno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (371, 96, N'El ministro de Defensa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (372, 97, N'El presidente de la comunidad autonoma', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (373, 97, N'el delegado del Gobierno', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (374, 97, N'El presidente de la Asamblea autonomica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (375, 98, N'45', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (376, 98, N'50', 1)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (377, 98, N'55', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (378, 99, N'del estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (379, 99, N'de la comunidad autonoma', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (380, 99, N'de la provincia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (381, 100, N'al Gobierno del Estado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (382, 100, N'al Congreso y al Senado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (383, 100, N'a los jueces y magistrados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (384, 101, N'Una', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (385, 101, N'Dos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (386, 101, N'Tres', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (387, 102, N'Los ayuntamientos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (388, 102, N'El Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (389, 102, N'Las comunidades autonomas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (390, 103, N'el Estado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (391, 103, N'las comunidades autonomas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (392, 103, N'los ayuntamientos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (393, 104, N'Ninguna', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (394, 104, N'Una', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (395, 104, N'Dos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (396, 105, N'el estado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (397, 105, N'las comunidades autonomas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (398, 105, N'los ayuntamientos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (399, 106, N'los concejales', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (400, 106, N'los diputados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (401, 106, N'los senadores', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (402, 107, N'el presidente y los ministros', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (403, 107, N'el alcalde y los concejales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (404, 107, N'El presidente y los consejeros', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (405, 108, N'El ayuntamiento', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (406, 108, N'La diputacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (407, 108, N'El Cabildo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (408, 109, N'Cabildos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (409, 109, N'Consejos insulares', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (410, 109, N'Diputaciones', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (411, 110, N'a los jueces y magistrados', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (412, 110, N'al Gobierno del Estado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (413, 110, N'al Congreso y al Senado', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (414, 111, N'aragones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (415, 111, N'castellano', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (416, 111, N'leones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (417, 112, N'A los ministros europeos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (418, 112, N'A los consejos delegados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (419, 112, N'A los eurodiputados', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (420, 113, N'16 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (421, 113, N'18 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (422, 113, N'21 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (423, 114, N'municipales', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (424, 114, N'autonomicas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (425, 114, N'generales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (426, 115, N'El banco de España', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (427, 115, N'La Agencia tributaria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (428, 115, N'El Tribunal de Cuentas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (429, 116, N'A los senadores y diputados', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (430, 116, N'a los eurodiputados', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (431, 116, N'a los concejales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (432, 117, N'300', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (433, 117, N'350', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (434, 117, N'400', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (435, 118, N'Autonomica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (436, 118, N'local', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (437, 118, N'central', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (438, 119, N'Andalucia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (439, 119, N'Cataluña', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (440, 119, N'Castilla y Leon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (441, 120, N'Asociacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (442, 120, N'Partido', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (443, 120, N'Sindicato', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (444, 121, N'Jose Maria Aznar', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (445, 121, N'Manuel Fraga', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (446, 121, N'Dolores Ibarruri', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (447, 122, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (448, 122, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (449, 123, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (450, 123, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (451, 124, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (452, 124, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (453, 125, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (454, 125, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (455, 126, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (456, 126, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (457, 127, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (458, 127, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (459, 128, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (460, 128, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (461, 129, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (462, 129, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (463, 130, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (464, 130, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (465, 131, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (466, 131, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (467, 132, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (468, 132, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (469, 133, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (470, 133, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (471, 134, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (472, 134, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (473, 135, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (474, 135, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (475, 136, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (476, 136, N'Falso', 0)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (477, 137, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (478, 137, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (479, 138, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (480, 138, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (481, 139, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (482, 139, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (483, 140, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (484, 140, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (485, 141, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (486, 141, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (487, 142, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (488, 142, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (489, 143, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (490, 143, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (491, 144, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (492, 144, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (493, 145, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (494, 145, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (495, 146, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (496, 146, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (497, 147, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (498, 147, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (499, 148, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (500, 148, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (501, 149, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (502, 149, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (503, 150, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (504, 150, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (505, 151, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (506, 151, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (507, 152, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (508, 152, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (509, 153, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (510, 153, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (511, 154, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (512, 154, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (513, 155, N'Verdadero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (514, 155, N'Falso', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (515, 156, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (516, 156, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (517, 157, N'Verdadero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (518, 157, N'Falso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (519, 158, N'En el principado de Asturias', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (520, 158, N'En Andalucia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (521, 158, N'En Extramadura', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (522, 159, N'Aviles', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (523, 159, N'Gijon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (524, 159, N'Oviedo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (525, 160, N'En el mar Cantabrico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (526, 160, N'En el Mar Maditerraneo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (527, 160, N'En el oceano Atlantico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (528, 161, N'Marisma', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (529, 161, N'Meseta', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (530, 161, N'Cordillera', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (531, 162, N'El Mulhacen', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (532, 162, N'El Aneto', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (533, 162, N'El Teide', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (534, 163, N'En Castilla y leon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (535, 163, N'En Castilla La Mancha', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (536, 163, N'En Cantabria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (537, 164, N'De Valencia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (538, 164, N'de Cataluña', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (539, 164, N'De Extremadura', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (540, 165, N'En Andalucia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (541, 165, N'En Canarias', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (542, 165, N'En Aragon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (543, 166, N'A Caruña', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (544, 166, N'Vigo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (545, 166, N'Santiago de Compostela', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (546, 167, N'Polar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (547, 167, N'Mediterraneo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (548, 167, N'Tropical', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (549, 168, N'En los Pirineos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (550, 168, N'En el Sistema Central', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (551, 168, N'En Sierra Nevada', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (552, 169, N'Cataluña', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (553, 169, N'Galicia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (554, 169, N'Navarra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (555, 170, N'departamentos y regiones', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (556, 170, N'comunidades y ciudades autonomas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (557, 170, N'regiones autonomas y distritos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (558, 171, N'La Rioja', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (559, 171, N'Aragon', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (560, 171, N'Galicia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (561, 172, N'Almeria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (562, 172, N'Melilla', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (563, 172, N'Cadiz', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (564, 173, N'Asturias', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (565, 173, N'Madrid', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (566, 173, N'Castilla La Mancha', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (567, 174, N'El guadalquivir', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (568, 174, N'El Manzanares', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (569, 174, N'El Jucar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (570, 175, N'Castellon', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (571, 175, N'Burgos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (572, 175, N'Albacete', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (573, 176, N'Continental', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (574, 176, N'Oceanico', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (575, 176, N'Subtropical', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (576, 177, N'Mediterraneo', 0)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (577, 177, N'Oceanico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (578, 177, N'Subtropical', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (579, 178, N'Ebro', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (580, 178, N'Duero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (581, 178, N'Tajo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (582, 179, N'lluviosos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (583, 179, N'montañosos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (584, 179, N'frios', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (585, 180, N'En Caceres', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (586, 180, N'En Murcia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (587, 180, N'En Ciudad Real', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (588, 181, N'Andalucia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (589, 181, N'Cataluña', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (590, 181, N'Asturias', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (591, 182, N'Don Juan', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (592, 182, N'Sancho Panza', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (593, 182, N'Doña Ines', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (594, 183, N'Montserrat Cabelle', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (595, 183, N'Ana Maria Matute', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (596, 183, N'Margarita Salas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (597, 184, N'Siglos de Oro', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (598, 184, N'Siglos de Plata', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (599, 184, N'Siglo de Platino', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (600, 185, N'pintoras', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (601, 185, N'escritoras', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (602, 185, N'deportistas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (603, 186, N'Manuel de Falla', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (604, 186, N'Isaac Albeniz', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (605, 186, N'Joaquin Rodrigo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (606, 187, N'El Flan', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (607, 187, N'El Turron', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (608, 187, N'la Coca', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (609, 188, N'El piano', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (610, 188, N'El Violin', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (611, 188, N'La Guitarra', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (612, 189, N'cantante pop', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (613, 189, N'bailarina clasica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (614, 189, N'directora de cine', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (615, 190, N'Rosalia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (616, 190, N'Marisol', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (617, 190, N'Lola Flores', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (618, 191, N'Santiago de Compostela', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (619, 191, N'Madrid', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (620, 191, N'Cordoba', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (621, 192, N'En Sevilla', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (622, 192, N'En Cordoba', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (623, 192, N'En Granada', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (624, 193, N'En Barcelona', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (625, 193, N'En Granada', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (626, 193, N'En Madrid', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (627, 194, N'pintor', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (628, 194, N'musica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (629, 194, N'escritor', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (630, 195, N'En Enero-Febrero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (631, 195, N'En Marzo-Abril', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (632, 195, N'En Julio-Agosto', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (633, 196, N'Cientifico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (634, 196, N'Guitarrista', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (635, 196, N'Pintor', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (636, 197, N'El flamenco', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (637, 197, N'La Jota', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (638, 197, N'La Sardana', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (639, 198, N'El Dolar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (640, 198, N'La Libra', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (641, 198, N'El Euro', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (642, 199, N'Merida', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (643, 199, N'Buñol', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (644, 199, N'Santiago de Compostela', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (645, 200, N'Invierno', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (646, 200, N'Primavera', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (647, 200, N'Verano', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (648, 201, N'natacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (649, 201, N'atletismo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (650, 201, N'futbol', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (651, 202, N'Maria Zambrano', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (652, 202, N'Pablo Picasso', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (653, 202, N'Vicente Aleixandre', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (654, 203, N'Pedro Sanchez', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (655, 203, N'Adolfo Suarez', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (656, 203, N'Jose Maria Aznar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (657, 204, N'deportistas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (658, 204, N'musicos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (659, 204, N'artistas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (660, 205, N'Lentejas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (661, 205, N'Uvas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (662, 205, N'Aceitunas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (663, 206, N'En Madrid', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (664, 206, N'En Bilbao', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (665, 206, N'En Sevilla', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (666, 207, N'En San Sebastian', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (667, 207, N'En Cuenca', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (668, 207, N'En Vigo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (669, 208, N'Merce Rodoreda', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (670, 208, N'Almudena Grandes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (671, 208, N'Ana Maria Matute', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (672, 209, N'La cristiana, la judia y la musulmana', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (673, 209, N'La fenicia, la judia y la musulmana', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (674, 209, N'La griega, la cristiana y la judia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (675, 210, N'el dia de la Constitucion', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (676, 210, N'la llegada de Colon a America', 0)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (677, 210, N'El dia del libro', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (678, 211, N'En Merida', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (679, 211, N'En Sevilla', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (680, 211, N'En Segovia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (681, 212, N'Republica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (682, 212, N'Dictadura', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (683, 212, N'Imperio', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (684, 213, N'actores', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (685, 213, N'escritores', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (686, 213, N'pintores', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (687, 214, N'el cine', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (688, 214, N'la literatura', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (689, 214, N'la pintura', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (690, 215, N'Los Premios Cervantes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (691, 215, N'Los premios Princesa de Asturias', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (692, 215, N'Los Premios Goya', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (693, 216, N'En 1992', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (694, 216, N'En 1996', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (695, 216, N'En 2004', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (696, 217, N'La Mancha', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (697, 217, N'Madrid', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (698, 217, N'Alcala de Henares', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (699, 218, N'La Policia Nacional', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (700, 218, N'La Guardia Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (701, 218, N'La Policia Local', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (702, 219, N'El certificado de empadronamiento', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (703, 219, N'La partida de nacimiento', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (704, 219, N'El Carne de conducir', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (705, 220, N'A los 14 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (706, 220, N'A los 16 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (707, 220, N'A los 18 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (708, 221, N'16 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (709, 221, N'18 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (710, 221, N'20 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (711, 222, N'La direccion General de trafico (DGT)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (712, 222, N'La policia Nacional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (713, 222, N'El Registro Civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (714, 223, N'un examen teórico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (715, 223, N'un examen práctico', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (716, 223, N'un examen teórico y otro práctico', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (717, 224, N'En el Registro Civil', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (718, 224, N'En la Seguridad Social', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (719, 224, N'En la comisarias de policia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (720, 225, N'Telecinco', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (721, 225, N'Nova', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (722, 225, N'Canal Sur', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (723, 226, N'12 semanas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (724, 226, N'16 semanas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (725, 226, N'22 semanas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (726, 227, N'0,5', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (727, 227, N'0,7', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (728, 227, N'Nada', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (729, 228, N'tienen un precio limitado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (730, 228, N'son para los funcionarios', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (731, 228, N'tienen sistema de vigilancia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (732, 229, N'Cantabria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (733, 229, N'Andalucia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (734, 229, N'La Rioja', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (735, 230, N'Impuesto sobre Bienes Inmueble (IBI) ', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (736, 230, N'Inspeccion Tecnica de Vehiculos (ITV) ', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (737, 230, N'Inspeccion Tecnica de Edificios (ITE) ', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (738, 231, N'bocadillo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (739, 231, N'tapa', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (740, 231, N'primer plato', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (741, 232, N'En la comisaria de policia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (742, 232, N'En el centro de salud', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (743, 232, N'En el ministerio de Sanidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (744, 233, N'Con 1 hijo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (745, 233, N'Con 2 hijos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (746, 233, N'Con 3 hijos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (747, 234, N'solo entre personas del mismo sexo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (748, 234, N'entre personas del mismo y diferente sexo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (749, 234, N'solo entre personas de diferente sexo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (750, 235, N'el Ministerio de justicia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (751, 235, N'la comisaria de policia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (752, 235, N'el ayuntamiento', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (753, 236, N'pimientos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (754, 236, N'patatas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (755, 236, N'tomates', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (756, 237, N'Jose Andres', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (757, 237, N'Rafael Nadal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (758, 237, N'Josep Carreras', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (759, 238, N'Tele5', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (760, 238, N'La 1', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (761, 238, N'Antena 3', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (762, 239, N'abrir la puerta al cartero', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (763, 239, N'no molestar con ruido', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (764, 239, N'limpiar los espacios comunes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (765, 240, N'fruta', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (766, 240, N'té', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (767, 240, N'agua', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (768, 241, N'Asturias', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (769, 241, N'Valencia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (770, 241, N'Canarias', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (771, 242, N'obligatoriamente el de la madre', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (772, 242, N'obligatoriamente el del padre', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (773, 242, N'puede ser el de la madre o el del padre', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (774, 243, N'6 de diciembre', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (775, 243, N'15 de agosto', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (776, 243, N'12 de octubre', 1)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (777, 244, N'de 9:00 a 17:00 h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (778, 244, N'de 10:00 a 22:00 h', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (779, 244, N'de 8:00 a 23:00 h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (780, 245, N'En el registro civil', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (781, 245, N'En una comisaria de policia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (782, 245, N'En el ayuntamiento', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (783, 246, N'separacion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (784, 246, N'discriminacion', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (785, 246, N'solidaridad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (786, 247, N'Ribera de Duero', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (787, 247, N'Pirineos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (788, 247, N'La Vera', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (789, 248, N'por internet', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (790, 248, N'en persona', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (791, 248, N'por telefono', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (792, 249, N'dos horas menos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (793, 249, N'una hora menos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (794, 249, N'una hora mas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (795, 250, N'ESAU', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (796, 250, N'ECAU', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (797, 250, N'EVAU', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (798, 251, N'Petroleo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (799, 251, N'Aceite de oliva', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (800, 251, N'Medicamentos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (801, 252, N'impuestos como IRPF', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (802, 252, N'impuestos indirectos como el IVA', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (803, 252, N'impuestos directos e indirectos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (804, 253, N'18 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (805, 253, N'23 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (806, 253, N'25 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (807, 254, N'En el trasporte publico', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (808, 254, N'En parques y jardines', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (809, 254, N'En instalaciones deportivas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (810, 255, N'es obligatorio', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (811, 255, N'se compone de dos cursos academicos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (812, 255, N'es la enseñanza a alumnos de 14 a 16 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (813, 256, N'impuestos indirectos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (814, 256, N'impuestos sobre la renta', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (815, 256, N'impuestos sobre sociedades', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (816, 257, N'El de la Seguridad Social', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (817, 257, N'El del pasaporte', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (818, 257, N'El numero de servicio', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (819, 258, N'pueden decidir su numero de plazas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (820, 258, N'pueden contratar los profesores que quieran', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (821, 258, N'son gratuitos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (822, 259, N'Tenerife', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (823, 259, N'Alicante', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (824, 259, N'Algeciras', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (825, 260, N'recibe dinero de la Administracion', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (826, 260, N'lo financian los padres de los alumnos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (827, 260, N'recibe dinero de los bancos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (828, 261, N'de HispanoAmerica', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (829, 261, N'De la Union Europea', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (830, 261, N'de Africa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (831, 262, N'Todos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (832, 262, N'Los de paro', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (833, 262, N'los niños', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (834, 263, N'Gas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (835, 263, N'Ropa', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (836, 263, N'Calzado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (837, 264, N'un Centro de Educacion de Personas Adultas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (838, 264, N'un centro de enseñanza Primaria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (839, 264, N'una universidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (840, 265, N'es para mayores de 25 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (841, 265, N'puede ser de grado medio o superior', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (842, 265, N'es obligatoria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (843, 266, N'Al hospital', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (844, 266, N'Al centro de salud', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (845, 266, N'A la farmacia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (846, 267, N'Para un año', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (847, 267, N'Para dos años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (848, 267, N'Para diez años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (849, 268, N'A las 18 h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (850, 268, N'A las 20 h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (851, 268, N'A las 21 o 22 h', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (852, 269, N'060', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (853, 269, N'112', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (854, 269, N'911', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (855, 270, N'ABC', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (856, 270, N'As.', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (857, 270, N'Cinco Dias', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (858, 271, N'En el quiosco', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (859, 271, N'En la farmacia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (860, 271, N'En el estanco', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (861, 272, N'AVE', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (862, 272, N'TGV', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (863, 272, N'Eurostar', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (864, 273, N'la ONCE', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (865, 273, N'Unicef', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (866, 273, N'Caritas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (867, 274, N'Patrimonio de la Humanidad', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (868, 274, N'una via de ferrocarril', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (869, 274, N'una ruta para excursionistas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (870, 275, N'Teledeporte', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (871, 275, N'La 1', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (872, 275, N'Canal 24 horas', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (873, 276, N'091', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (874, 276, N'112', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (875, 276, N'016', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (876, 277, N'de cercanias', 1)
GO
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (877, 277, N'rural', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (878, 277, N'transnacional', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (879, 278, N'Fumar', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (880, 278, N'Comer', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (881, 278, N'Beber alcohol', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (882, 279, N'medio kilo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (883, 279, N'un cuarto kilo', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (884, 279, N'un tercio de un kilo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (885, 280, N'tres cuartos de litro', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (886, 280, N'medio litro', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (887, 280, N'un litro', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (888, 281, N'En el hospital', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (889, 281, N'En el centro de salud', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (890, 281, N'En la farmacia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (891, 282, N'no pisar el cesped', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (892, 282, N'se recomienda pagar el billete con el dinero justo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (893, 282, N'Respetar las normas sobre el equipaje', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (894, 283, N'El garaje', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (895, 283, N'El seguro', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (896, 283, N'La alarma', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (897, 284, N'Barcelona', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (898, 284, N'Madrid', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (899, 284, N'Bilbao', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (900, 285, N'solo el asiento del conductor', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (901, 285, N'en los asientos delanteros', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (902, 285, N'en todos los asientos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (903, 286, N'90 km/h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (904, 286, N'120 km/h', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (905, 286, N'150 km/h', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (906, 287, N'el trasporte publico', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (907, 287, N'las bibliotecas', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (908, 287, N'los museos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (909, 288, N'Por un accidente grave', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (910, 288, N'Por la perdida de los puntos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (911, 288, N'Por exceso de velocidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (912, 289, N'Red Nacional de fondos Europeos', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (913, 289, N'Red Nacional de los Ferrocarriles Españoles', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (914, 289, N'Red Nacional de Fundaciones Estatales', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (915, 290, N'Italia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (916, 290, N'China', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (917, 290, N'Alemania', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (918, 291, N'16 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (919, 291, N'18 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (920, 291, N'21 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (921, 292, N'Agricultura', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (922, 292, N'Servicios', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (923, 292, N'Construccion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (924, 293, N'la ingenieria aeroespacial', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (925, 293, N'las energias renovables', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (926, 293, N'la energia nuclear', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (927, 294, N'La Constitucion', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (928, 294, N'El Estatuto de los Trabajadores', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (929, 294, N'El Servicio Publico de Empleo Estatal', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (930, 295, N'Farmacia', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (931, 295, N'Pescaderia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (932, 295, N'Libreria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (933, 296, N'es obligatoria', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (934, 296, N'tiene dos ciclos', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (935, 296, N'empieza a los 4 años', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (936, 297, N'En agosto', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (937, 297, N'En Septiembre', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (938, 297, N'En Marzo', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (939, 298, N'son centros de enseñanza privada', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (940, 298, N'son para mayores de 16 años', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (941, 298, N'dependen del instituto Cervantes', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (942, 299, N'Informe de vida laboral', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (943, 299, N'Recibo de finiquito', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (944, 299, N'Certificado de profesionalidad', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (945, 300, N'IRPF (impuesto sobre la Renta de las Personas Fisicas)', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (946, 300, N'IVA (impuesto sobre el Valor Añadido)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (947, 300, N'IS (Impuesto sobre Sociedades)', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (948, 301, N'Navarra', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (949, 301, N'Galicia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (950, 301, N'Andalucia', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (951, 302, N'Senado', 1)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (952, 302, N'Diputación permanente', 0)
INSERT [Answer] ([Id], [IdQuestion], [AnswerDescription], [Valid]) VALUES (953, 302, N'Congreso de los Diputados', 0)
SET IDENTITY_INSERT [Answer] OFF
GO
SET IDENTITY_INSERT [Dependency] ON 

INSERT [Dependency] ([Id], [Descripcion]) VALUES (1, N'TestSpainCitizen')
INSERT [Dependency] ([Id], [Descripcion]) VALUES (2, N'Test')
SET IDENTITY_INSERT [Dependency] OFF
GO
SET IDENTITY_INSERT [FinalTestMessage] ON 

INSERT [FinalTestMessage] ([Id], [IdDependency], [Cod], [answersrangemin], [answersrangemax], [FinalTestMessageDescription]) VALUES (1, 1, 1, -1, 0, N'Oye..!. no tienes ganas de hacer el examen? .. no has contestado ninguna.')
INSERT [FinalTestMessage] ([Id], [IdDependency], [Cod], [answersrangemin], [answersrangemax], [FinalTestMessageDescription]) VALUES (2, 1, 2, 1, 14, N'No has aprobado el examen.. necesitas estudiar un poquito mas.. una vez mas.. y estas...')
INSERT [FinalTestMessage] ([Id], [IdDependency], [Cod], [answersrangemin], [answersrangemax], [FinalTestMessageDescription]) VALUES (5, 1, 3, 15, 20, N'Felicitaciones!!! has aprobado el examen con exito. Aun asi te aconsejo que pruebes unas veces mas para tener todo mucho mas claro.')
INSERT [FinalTestMessage] ([Id], [IdDependency], [Cod], [answersrangemin], [answersrangemax], [FinalTestMessageDescription]) VALUES (6, 1, 4, 21, 22, N'Oye tio.!!.. te ha ido muy bien... pero no te descuides, que aun tienes errores')
INSERT [FinalTestMessage] ([Id], [IdDependency], [Cod], [answersrangemin], [answersrangemax], [FinalTestMessageDescription]) VALUES (7, 1, 5, 23, 25, N'Oye tio.!!.. tu eres mas español que el JAMON !! que haces tu aqui ?.. tienes muy buen resultado...')
SET IDENTITY_INSERT [FinalTestMessage] OFF
GO
SET IDENTITY_INSERT [FinalTestMessageQuestionLevel] ON 

INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (1, 1, 1)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (2, 1, 2)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (3, 1, 3)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (4, 1, 4)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (5, 2, 1)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (6, 2, 2)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (8, 2, 3)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (9, 2, 4)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (10, 5, 1)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (11, 5, 2)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (12, 5, 3)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (13, 5, 4)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (14, 6, 1)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (15, 6, 2)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (16, 6, 3)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (17, 6, 4)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (18, 7, 1)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (19, 7, 2)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (20, 7, 3)
INSERT [FinalTestMessageQuestionLevel] ([Id], [IdFinalTestMessage], [IdQuestionLevel]) VALUES (21, 7, 4)
SET IDENTITY_INSERT [FinalTestMessageQuestionLevel] OFF
GO
SET IDENTITY_INSERT [Question] ON 

INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (1, 1, N'España es', N'1001', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (2, 1, N'La ley fundamental de España se llama...', N'1002', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (3, 1, N'Segun la constitucion española, la soberania nacional reside en...', N'1003', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (4, 1, N'El Instituto de las Mujeres es...', N'1004', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (5, 1, N'Cuantas religiones oficiales hay en España', N'1005', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (6, 1, N'El castellano o el español es lengua oficial ...', N'1006', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (7, 1, N'Cual de estas fuerzas de seguridad es de ámbito autonomico', N'1007', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (8, 1, N'Que fuerza de seguridad esta en toda España', N'1008', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (9, 1, N'En la Constitucion se establece la separacion de poderes; Ejecutivo,legislativo y el...', N'1009', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (10, 1, N'La bandera de españa debe utilizarse ', N'1010', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (11, 1, N'El organismo que gestiona los impuestos estatales de España es...', N'1011', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (12, 1, N'La Gestion de sanidad es competencia de ...', N'1012', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (13, 1, N'Quien fue el primer presidente del Gobierno de España en democracia', N'1013', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (14, 1, N'Con respecto a los poderes del Estado, el Tribunal Constitucional es...', N'1014', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (15, 1, N'Quién modera el funcionamiento de las instituciones españolas?', N'1015', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (16, 1, N'En que año entró España en la Comunidad Economica Europea', N'1016a', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (17, 1, N'Cuantas CIUDADES autonomas hay en España', N'1017', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (18, 1, N'Como se aprobó la Constitucion', N'1018', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (19, 1, N'Como se llama la ley mas importante de cada comunidad autonoma', N'1019', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (20, 1, N'Las instalaciones culturales y deportivas publicas son competencia del ...', N'1020', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (21, 1, N'Quien dirige la administracion militar de España', N'1021', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (22, 1, N'Que hay en las islas Baleares, en vez de diputaciones', N'1022', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (23, 1, N'Que ciudad tiene mas habitantes', N'1023', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (24, 1, N'A cual de estas organizaciones internacionales pertenece España', N'1024', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (25, 1, N'El Congreso de los diputados y el Senado constituyen el poder...', N'1025', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (26, 1, N'Cuantos colores tiene la bandera española', N'1026', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (27, 1, N'Cuantas COMUNIDADES autonomas hay en España', N'1027', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (28, 1, N'Los colores de la bandera española son...', N'1028', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (29, 1, N'Donde esta la sede del Gobierno de España', N'1029', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (30, 1, N'La bandera azul con 12 estrellas amarillas en el circulo es la bandera de...', N'1030', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (31, 1, N'En España hay elecciones generales cada...', N'1031', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (32, 1, N'Que lengua es oficial en el Pais Vasco', N'1032', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (33, 1, N'Todos los españoles tienen el deber de conocer la lengua...', N'1033', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (34, 1, N'Cual de estas opciones es una lenguaa co-Oficial en alguna comunidad autonoma', N'1034', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (35, 1, N'Las instituciones de una comunidad autonoma son la asamblea legislativa, el consejo de gobierno y...', N'1035', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (36, 1, N'Cual de estas opciones es una lengua Co-Oficial en alguna comunidad autonoma', N'1036', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (37, 1, N'Que institucion tiene como fin la promocion de la enseñanza de la lengua española y la difusion de la cultura en español', N'1037', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (38, 1, N'Cual de los siguientes organismos trabaja para conseguir la normalizacion linguistica', N'1038', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (39, 1, N'Donde vive el presidente del Gobierno', N'1039', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (40, 1, N'Cual de los siguientes cuerpos forma parte de las Fuerzas Armadas de España', N'1040', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (41, 1, N'Quienes forman parte del Gobierno', N'1041', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (42, 1, N'España es un ...', N'1042', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (43, 1, N'Quien era/es presidente del Gobierno en el 2022', N'1043', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (44, 1, N'Que titulo tiene la futura reina, Hija del rey', N'1044', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (45, 1, N'Con que rey se restaura la democracia en España despues del regimen de Franco', N'1045', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (46, 1, N'En que año se aprobo la Constitucion española', N'1046', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (47, 1, N'Cuantas comunidades autonomas tienen su propia bandera', N'1047', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (48, 1, N'Cuantas veces ha presidido España el Consejo de la Union Europea', N'1048', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (49, 1, N'Cuantas veces ha reformado España su Constitucion para adaptarse a las decisiones y directivas europeas', N'1049', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (50, 1, N'A cual de estas organizaciones internacionales pertenece España', N'1050', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (51, 1, N'En la organizacion de la Administracion se distinguen tres niveles central, autonomica y...', N'1051', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (52, 1, N'El poder legislativo corresponde', N'1052', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (53, 1, N'Donde vive el rey', N'1053', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (54, 1, N'El nombre oficial del parlamento español es...', N'1054', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (55, 1, N'El Gobierno esta formado por el presidente,uno o mas vicepresidentes y los ...', N'1055', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (56, 1, N'Quien puede reinar en España', N'1056', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (57, 1, N'Al poder legislativo le corresponde...', N'1057', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (58, 1, N'Quien es la tercera autoridad del Estado despues del rey y el presidente del Gobierno', N'1058', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (59, 1, N'Que lengua co-oficial se habla en las islas Baleares', N'1059', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (60, 1, N'La Constitucion defiende valores tales como la libertad, igualdad, el pluralismo politico y ...', N'1060', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (61, 1, N'Cuantos kilometros cuadrados tiene España mas o menos', N'1061', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (62, 1, N'Cuantos millones de habitantes tiene España, hasta el ultimo censo', N'1062', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (63, 1, N'Cual de estos es un organo consultivo del Gobierno de España', N'1063', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (64, 1, N'Quien dirige la politica interior y exterior de España', N'1064', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (65, 1, N'El Defensor del pueblo depende de...', N'1065', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (66, 1, N'El instituto Etxepare tiene como mision la difusion del ...', N'1066', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (67, 1, N'La Comunidad Iberoamericana de Naciones esta formada por...', N'1067', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (68, 1, N'El instituto Ramon Llull difunde y promociona a lengua y la cultura', N'1068', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (69, 1, N'Como se llama el rey de España - 2024', N'1069', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (70, 1, N'Como se llama el organo de gobierno de los jueces y magistrados', N'1070', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (71, 1, N'Quien aprueba los presupuestos generales del Estado', N'1071', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (72, 1, N'La Constitucion Española es...', N'1072', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (73, 1, N'Las Cortes Generales estan compuestas por el Senado y...', N'1073', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (74, 1, N'Quien elabora las leyes', N'1074', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (75, 1, N'La Defensa de la integridad territorial de España corresponde a...', N'1075', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (76, 1, N'El Ejercito español participa desde 1989 en misiones de paz de la ...', N'1076', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (77, 1, N'Quien vigila puertos y aeropuertos, frontera y costas', N'1077', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (78, 1, N'Quien hace el control de pasaportes en las fronteras de España', N'1078', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (79, 1, N'Quien controla la circulacion de coches en la ciudades', N'1079', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (80, 1, N'Como se llama la policia autonomica de Cataluña', N'1080', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (81, 1, N'Como se llama la policia autonomica del Pais Vasco', N'1081', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (82, 1, N'Desde que año es rey Felipe VI', N'1082', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (83, 1, N'Jose maria Aznar fue presidente ... ', N'1083b', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (84, 1, N'El presidente del Gobierno de España entre 1982 y 1996 fue...', N'1083', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (85, 1, N'Quien puede presentar una queja al Defensor del Pueblo', N'1084', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (86, 1, N'En España el voto en las elecciones es ...', N'1085', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (87, 1, N'Quien vigila el trafico en las carreteras', N'1086', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (88, 1, N'Que organismo se encarga de recaudar los impuestos', N'1087', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (89, 1, N'Donde se publican las leyes nacionales', N'1088', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (90, 1, N'Como se llaman los organos de gobierno que solo existen en Canarias', N'1089', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (91, 1, N'Donde ofrece el Gobierno toda la informacion sobre novedades e iniciativas de la Administracion electronica', N'1090', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (92, 1, N'Cual es el numero de telefono de informacion de la Administracion General del Estado', N'1091', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (93, 1, N'España esta organizada en...', N'1092', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (94, 1, N'Cuantos partidos politicos hay en españa', N'1093', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (95, 1, N'Cuantos municipios hay en España', N'1094', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (96, 1, N'Quien tiene el mando supremo de las Fuerzas Armadas', N'1095', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (97, 1, N'Quien es el representante del Estado en una comunidad autonoma', N'1096', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (98, 1, N'Cuantas provincias hay en España', N'1097', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (99, 1, N'La enseñanza de la lengua co-oficiales es competencia ...', N'1098', 3)
GO
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (100, 1, N'El poder ejecutivo corresponde...', N'1099', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (101, 1, N'Cuantas camaras hay en el Parlamento', N'1100', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (102, 1, N'Quien tiene la competencia en un urbanismo', N'1101', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (103, 1, N'En material como nacionalidad, inmigracion, emigracion o extranjeria solo tiene competencia...', N'1102', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (104, 1, N'Cuantas mujeres han sido presidentes del Gobierno en España', N'1103', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (105, 1, N'Las relaciones internacionales son competencia de...', N'1104', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (106, 1, N'El Ayuntamiento esta formado por el alcalde y...', N'1105', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (107, 1, N'Quienes forman el gobierno de las comunidades autonomas', N'1106', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (108, 1, N'Cual es el organo de gobierno en los municipios', N'1107', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (109, 1, N'Como se llaman los organos de gobierno de las provincias españolas', N'1108', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (110, 1, N'El poder judicial corresponde...', N'1109', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (111, 1, N'El idioma español tambien se llama...', N'1110', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (112, 1, N'A quienes se elige en las elecciones al Parlamento Europeo', N'1111', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (113, 1, N'Los españoles pueden votar a partir de los ...', N'1112', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (114, 1, N'Algunos ciudadanos extranjeros pueden votar en las elecciones', N'1113', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (115, 1, N'Quien controla la gestion financiera del Estado', N'1114', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (116, 1, N'A quienes se elige en las elecciones generales', N'1115', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (117, 1, N'Cuantos miembros tiene el Congreso de los Diputados', N'1116', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (118, 1, N'Los municipios y provincias forman parte de la Administracion...', N'1117', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (119, 1, N'La COMUNIDAD AUTONOMA mas poblada de España es ...', N'1118', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (120, 1, N'Como se llama la organizacion que defiende los intereses de los trabajadores', N'1119', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (121, 1, N'Cual de las siguientes personalidades ha sido presidente del Gobierno de España', N'1120', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (122, 1, N'la mayoria de edad en España es a los 16 años.', N'2001', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (123, 1, N'Los españoles que obtienen la nacionalidad por residencia deben esperar tres años para poder votar en las elecciones.', N'2002', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (124, 1, N'Los jovenes tienen derecho a participar libremente en el desarollo politico del pais', N'2003', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (125, 1, N'El funcionamiento de los partidos politicos tiene que ser democratico', N'2004', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (126, 1, N'Se puede obligar a alquien a decir cuales son sus ideas politicas o religiosas', N'2005', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (127, 1, N'Se puede limitar a una persona el derecho a entrar y salir libremente de España por motivos ideologicos', N'2006', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (128, 1, N'La Educacion Primaria (6 a 12 años) es gratuita y obligatoria', N'2007', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (129, 1, N'La Constitucion garantiza el derecho de los españoles a una vivienda digna', N'2008', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (130, 1, N'En España la policia puede entrar en cualquier casa sin resolucion judicial en cualquier momento', N'2009', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (131, 1, N'Se garantiza el secreto de las comunicaciones de los españoles, salvo resolucion judicial', N'2010', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (132, 1, N'Todos los españoles, ya sean mayores o menores de edad, tienen derecho a votar en las elecciones', N'2011', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (133, 1, N'Los profesores pueden enseñar con libertad dentro de los limites de la Constitucion', N'2012', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (134, 1, N'La constitucion reconoce unicamente los derechos fundamentales de los españoles', N'2013', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (135, 1, N'En España existe la pena de muerte', N'2014', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (136, 1, N'La ley limita el acceso de terceras personas a datos de caracter personal', N'2015', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (137, 1, N'La libertad de prensa esta limitada por el respeto al honor de las personas', N'2016', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (138, 1, N'En España las causas de separacion y divorcio estan reguladas por la ley', N'2017', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (139, 1, N'Todos los españoles pagan la misma cantidad de impuestos', N'2018', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (140, 1, N'En España los hombres y las mujeres tienen los mismos derechos', N'2019', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (141, 1, N'La enseñanza obligatoria consta de dos etapas Educacion Primaria y Educacion Secundaria Obligatoria', N'2020', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (142, 1, N'En España hay una religion oficial', N'2021', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (143, 1, N'Todos los ciudadanos tienen derecho a la atencion sanitaria', N'2022', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (144, 1, N'Los poderes publicos deben promover la educacion fisica y el deporte', N'2023', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (145, 1, N'En España esta reconocido el derecho de asociacion', N'2024', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (146, 1, N'En caso de huelga, es obligatorio por ley mantener unos servicios minimos', N'2025', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (147, 1, N'Los trabajadores tienen derecho a hacer huelga', N'2026', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (148, 1, N'La libertad ideologica esta garantizada solo en parte del territorio nacional', N'2027', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (149, 1, N'Todos los ciudadanos tienen acceso al sistema de Seguridad Social publico, excepto si estan desempleados', N'2028', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (150, 1, N'Todos tienen derecho a disfrutar de un medio ambiente adecuado para el desarrollo de la persona, asi como el deber de conservarlo', N'2029', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (151, 1, N'Todo el mundo tiene derecho a expresar su opinion', N'2030', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (152, 1, N'La edad minima para casarse en España es de 12 años', N'2031', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (153, 1, N'La Ley prohibe la discriminacion por cualquier circunstancia personal o social', N'2032', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (154, 1, N'Los poderes publicos garantizan la defensa de los consumidores', N'2033', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (155, 1, N'En España cualquier ciudadano mayor de edad puede presentarse a las elecciones', N'2034', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (156, 1, N'Los españoles deben ayudar en los casos de catastrofe o calamidad publica', N'2035', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (157, 1, N'En España los ciudadanos pueden elegir en que ciudad quieren vivir', N'2036', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (158, 1, N'Donde estan Caceres y Badajoz', N'3001', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (159, 1, N'Cual es la capital del principado de Asturias', N'3002', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (160, 1, N'Donde estan las islas Baleares', N'3003', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (161, 1, N'Como se llama la extensa llanura situada en el centro de la peninsula iberica', N'3004', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (162, 1, N'Cual es la montaña mas alta de la peninsula iberica', N'3005', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (163, 1, N'En que comunidad autonoma estan Guadalajara y Cuenca', N'3006', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (164, 1, N'De que comunidad autonoma es capital Merida', N'1132', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (165, 1, N'Donde esta Almeria', N'3008', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (166, 1, N'La capital de la comunidad Autonoma de Galicia es...', N'3009', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (167, 1, N'Cual de estos climas es propio de España', N'3010', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (168, 1, N'Donde esta el monte Aneto', N'3011', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (169, 1, N'Tarragona esta en ...', N'3012', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (170, 1, N'España se divide en ...', N'3013', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (171, 1, N'Cual de estas comunidades autonomas tiene solo una provincia', N'3014', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (172, 1, N'En el norte de Africa estan Ceuta y ...', N'3015', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (173, 1, N'Cual de estas comunidades autonomas tienen mas de una provincia', N'3016', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (174, 1, N'Cual de estos rios desemboca en el oceano Atlantico', N'3017', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (175, 1, N'Cual de estas provincias forma parte de la Comunidad Valenciana', N'3018', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (176, 1, N'Las temperaturas suaves con abundantes lluvias son propias del clima', N'3019', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (177, 1, N'Canarias tiene un clima', N'3020', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (178, 1, N'El principal rio que desemboca en el mar Mediterraneo es el...', N'3021', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (179, 1, N'España esta entre los paises de Europa mas...', N'3022', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (180, 1, N'En que provincia esta el parque nacional de Monfrague', N'3023', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (181, 1, N'Los picos de Europa estan en...', N'3024', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (182, 1, N'Los personajes principales de la novela el Quijote son Don Quijote y ...', N'4001', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (183, 1, N'Cual de las siguientes mujeres es una cientifica española reconocida mundialmente', N'4002', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (184, 1, N'Como se llama, en literatura, a los siglos XVI y XVII', N'1152', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (185, 1, N'Maria Zambrano, Maria Teresa Leon y Rosa Chacel son...', N'4004', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (186, 1, N'Que musico compuso ''El Amor Brujo'' ', N'4005', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (187, 1, N'Que dulce es tipico de las navidades', N'4006', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (188, 1, N'Que instrumento musical es tipico del folclore español', N'4007', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (189, 1, N'Isabel Coiet es una...', N'4008', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (190, 1, N'Una de las cantantes españolas mas famosas ACTUALMENTE es...', N'4009', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (191, 1, N'En que ciudad de España hay una mezquita que es Patrimonio de la Humanidad', N'4010', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (192, 1, N'En que ciudad de España se encuentra la Alhambra, que es Patrimonio de la Humanidad', N'4011', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (193, 1, N'Donde esta la Sagrada Familia, el monumento de Gaudi', N'4012', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (194, 1, N'Pablo Picasso fue un famoso...', N'4013', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (195, 1, N'En que epoca del año es la Semana Santa', N'4014', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (196, 1, N'Paco de Lucia fue un famoso...', N'4015', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (197, 1, N'Cual de estas manifestaciones folcloricas es patrimonio cultural inmaterial de la humanidad', N'4016', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (198, 1, N'Cual es la moneda comun en muchos paises de la Union Europea', N'4017', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (199, 1, N'La fiesta de la Tomatina se celebra en...', N'4018', 4)
GO
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (200, 1, N'La Feria del Libro se celebra en toda España normalmente en...', N'4019', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (201, 1, N'La Liga y la Copa del Rey son competiciones de...', N'4020', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (202, 1, N'Quien ha recibido el premio Nobel de Literatura', N'4021', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (203, 1, N'Quien fue presidente de Gobierno durante la transicion española', N'4022', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (204, 1, N'Mireia Belmonte, Edurne Pasaban y Pau Gasol son...', N'4023', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (205, 1, N'Que comen los españoles la nochde del 31 de diciembre para celebrar año nuevo', N'4024', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (206, 1, N'Donde esta el Museo del Prado', N'4025', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (207, 1, N'Donde se celebra un famoso festival de cine', N'4026', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (208, 1, N'Que escritora española escribe en otra lengua oficial de España', N'4027', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (209, 1, N'Que tres culturas convivieron en la España medieval', N'4028', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (210, 1, N'El 6 de diciembre se celebra en España...', N'4029', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (211, 1, N'En que ciudad hay un acueducto romano que es Patrimonio de la Humanidad', N'4030', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (212, 1, N'Que regimen politico habia en España antes del rey Juan Carlos I', N'4031', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (213, 1, N'El Premio Cervantes se da a...', N'4032', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (214, 1, N'Los Premios Goya estan relacionados con...', N'4033', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (215, 1, N'Que premios promueven en España valores cientificos, culturales y humanisticos', N'4034', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (216, 1, N'Cuando fueron los Juegos Olimpicos de Barcelona', N'4035', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (217, 1, N'El escritor Miguel de Cervantes nacio en...', N'4036', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (218, 1, N'Quien hace el DNI', N'5001', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (219, 1, N'Cual es el documento que certifica el lugar de residencia del titular', N'5002', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (220, 1, N'A que edad es obligatorio tener el DNI', N'5003', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (221, 1, N'Cual es la edad minima para conducir en España', N'5004', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (222, 1, N'El Carné de conducir se hace en... ', N'5005', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (223, 1, N'Para sacar el carné de conducir hay que aprobar...', N'5006', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (224, 1, N'Donde se tramita el libro de familia', N'5007', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (225, 1, N'Cual de estos canales de television es autonomico', N'5008', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (226, 1, N'Cuanto dura el permiso de maternidad o paternidad', N'5009', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (227, 1, N'Cual es la tasa maxima de alcohol en sangre permitida a los conductores, en gramos por litro', N'5010', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (228, 1, N'Las viviendas de proteccion oficial ...', N'5011', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (229, 1, N'Que comunidad autonoma es conocida por la calidad de su aceite de oliva', N'5012', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (230, 1, N'Como se llama la revision que deben pasar obligatoriamente los coches', N'5013', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (231, 1, N'El aperitivo que acompaña a la bebida en bares y restaurantes se llama', N'5014', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (232, 1, N'Donde se tramita la tarjeta sanitaria', N'5015', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (233, 1, N'Con cuantos hijos una familia es numerosa', N'5016', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (234, 1, N'En España esta permitido el matrimonio...', N'5017', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (235, 1, N'Los propietarios de perros deben registrarlos en ...', N'5018', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (236, 1, N'Los principales ingredientes de la tortilla española son huevos y ...', N'5019', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (237, 1, N'Quien es un cocinero famoso dentro y fuera de España', N'5020', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (238, 1, N'Cual de estos canales de television es publico', N'5021', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (239, 1, N'En una comunidad de vecinos, una de las normas es...', N'5022', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (240, 1, N'La sangria es una bebida compuesta por refrescos, vino y ...', N'5023', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (241, 1, N'La sidra es una bebida tipica de ...', N'5024', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (242, 1, N'Los españoles tienen dos apellidos, el primer es...', N'5025', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (243, 1, N'La Fiesta Nacional de España es el ...', N'5026', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (244, 1, N'Cual es el horario habitual de los hipermercados y centros comerciales', N'5027', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (245, 1, N'Donde se hace el pasaporte', N'5028', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (246, 1, N'El Ministerio de igualdad es el encargado de luchar contra la violencia de genero y la...', N'5029', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (247, 1, N'Cual de estas regiones es conocida por sus vinos con denominacion de origen', N'5030', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (248, 1, N'El DNI se hace ...', N'5031', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (249, 1, N'El horario de Canarias, con respecto a la Peninsula, es de...', N'5032', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (250, 1, N'Para acceder a la universidad se debe superar una prueba de evaluacion llamada...', N'5033', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (251, 1, N'Cual de estos productos necesita IMPORTAR España de otros paises', N'5034', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (252, 1, N'Que tipo de impuestos tienen que pagar los ciudadanos en España', N'5035', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (253, 1, N'Los adultos sin Bachillerato pueden estudiar en la Universidad haciendo una prueba especial a partir de los ...', N'5036', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (254, 1, N'Donde puede encontrarse la siguiente norma ''Dejar salir antes de entrar'' ', N'5037', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (255, 1, N'El Bachilleraro en España', N'5038', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (256, 1, N'El impuesto sobre el valor añadido (IVA) forma parte de los ...', N'5039', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (257, 1, N'Que numero reciben los trabajadores al comenzar su primer empleo', N'5040', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (258, 1, N'Los colegios publicos', N'5041', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (259, 1, N'Cual de estos puertos es una de los principales de España', N'5042', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (260, 1, N'Un colegio concertado es un colegio privado que...', N'5043', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (261, 1, N'España exporta productos principalmente a paises...', N'5044', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (262, 1, N'Las bibliotecas publicas son gratuitas para...', N'5045', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (263, 1, N'Cual de estos productos EXPORTA España mas que importa', N'5046', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (264, 1, N'Una persona mayor de 18 años puede obtener el titulo de Graduado en Educacion Secundaria Obligatoria en ...', N'5047', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (265, 1, N'La formacion profesional', N'5048', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (266, 1, N'Adonde vamos para ver al medico de la familia o al pediatra', N'5049', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (267, 1, N'Para cuantos años vale la tarjeta sanitaria europea', N'5050', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (268, 1, N'A que hora se cena normalmente en España', N'5051', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (269, 1, N'Cual es el numero de telefono unico para cualquier emergencia', N'5052', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (270, 1, N'Cual es un periodico deportivo', N'5053', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (271, 1, N'Donde se venden sellos y tabaco', N'5054', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (272, 1, N'Como se llama el tren español de alta velocidad', N'5055', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (273, 1, N'La organizacion que trabaja para conseguir la integracion de las personas con discapacidad visual es...', N'5056', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (274, 1, N'El Camino de santiago es...', N'5057', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (275, 1, N'Cual es el canal de television estatal que trasmite noticias de actualidad nacional e internacional continuamente', N'5058', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (276, 1, N'El telefono gratuito para las victimas de violencia de genero es el...', N'5059', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (277, 1, N'En España la red de trenes puede ser de larga distancia, de media y...', N'5060', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (278, 1, N'Que esta prohibido hacer en la puerta de un hospital o colegio', N'5061', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (279, 1, N'Cuando compramos 250 gramos de un alimento estamos comprando', N'5062', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (280, 1, N'Si compramos una botella de agua de 750 ml, compramos una botella de...', N'5063', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (281, 1, N'Donde se compran las medicinas con receta', N'5064', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (282, 1, N'Cual de estas tres recomendaciones podemos encontrar en un parque', N'5065', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (283, 1, N'Cual de las siguientes cosas es obligatoria para el propietario de un coche en España', N'5066', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (284, 1, N'El aeropuerto Adolfo Suarez esta en...', N'5067', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (285, 1, N'En un coche es OBLIGATORIO el uso del cinturon de seguridad', N'5068', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (286, 1, N'Cual es el limite de velocidad en autopista', N'5069', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (287, 1, N'Ceder el asiento a las personas con movilidad reducida es una norma que encontramos indicada en...', N'5070', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (288, 1, N'En que caso se retira el permiso de conducir', N'5071', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (289, 1, N'Que significa Renfe', N'5072', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (290, 1, N'Los Españoles necesitan el pasaporte para viajar a...', N'5073', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (291, 1, N'Cual es la edad minima para trabajar en España', N'5074', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (292, 1, N'Cual es el sector de mayor peso en la economia española', N'5075', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (293, 1, N'España es innovadora en el sector de ...', N'5076', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (294, 1, N'Como se llama la ley LABORAL mas importante de España', N'5077', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (295, 1, N'Cual de estos establecimientos esta abierto 24 horas si es necesario', N'5078', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (296, 1, N'La educacion infantil en España...', N'5079', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (297, 1, N'Cuando empieza el calendario escolar', N'5080', 2)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (298, 1, N'Las Escuelas Oficiales de idiomas...', N'5081', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (299, 1, N'Como se llama el documento oficial que recoge las fechas de todos los contratos de trabajo de una persona', N'5082', 3)
GO
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (300, 1, N'Que impuesto pagan los residentes en España en funcion de la renta o el dinero ganado (salario, ingreso, como autonomos etc)', N'5083', 3)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (301, 1, N'Cual de estas comunidades autonomas tienen el PIB por habitante mas alto', N'5084', 4)
INSERT [Question] ([Id], [IdDependency], [QuestionDescription], [Cod], [IdQuestionLevel]) VALUES (302, 1, N'¿Cómo se llama la cámara de representación territorial en España?', N'1016b', 4)
SET IDENTITY_INSERT [Question] OFF
GO
SET IDENTITY_INSERT [QuestionLevel] ON 

INSERT [QuestionLevel] ([Id], [IdDependency], [Cod], [QuestionLevelDescription], [Class]) VALUES (1, 1, 0, N'Random', N'secondary')
INSERT [QuestionLevel] ([Id], [IdDependency], [Cod], [QuestionLevelDescription], [Class]) VALUES (2, 1, 1, N'Facil', N'success')
INSERT [QuestionLevel] ([Id], [IdDependency], [Cod], [QuestionLevelDescription], [Class]) VALUES (3, 1, 2, N'Medio', N'warning')
INSERT [QuestionLevel] ([Id], [IdDependency], [Cod], [QuestionLevelDescription], [Class]) VALUES (4, 1, 3, N'Avanzado', N'danger')
SET IDENTITY_INSERT [QuestionLevel] OFF
GO
SET IDENTITY_INSERT [Setting] ON 

INSERT [Setting] ([Id], [IdDependency], [cod], [questionperpage], [correctanswers], [tittle], [subtittle], [instruction], [downloadtittle], [downloadlink], [preinstructiontittle], [preinstruction]) VALUES (1, 1, 1, 25, 15, N'Bienvenido al examen CCSE 2024 NACIONALIDAD ESPAÑOLA version 2.0', N'Bienvenido al examen CCSE 2024', N'El examen consta de 25 preguntas totalmente aleatorias, obtenidas de unas 300 que son tomadas en el examen real, para poder aprobar el examen debe tener 15 preguntas respondidas de forma correcta.de esta forma se le tomara el examen para la nacionalidad Española. puede elegir preguntas : Random, Nivel bajo, Medio, Alto. Al final podras verificar tus respuestas. ', N'Baja el documento de Preparacion Examen Ciudadania', N'https://examenes.cervantes.es/sites/default/files/Manual%20CCSE%202024_0.pdf', N'Revisa las instrucciones antes del inicio del examen.', N'Este examen es a modo de prueba para saber sus conocimientos y poder practicar 
</br> Suerte...')
SET IDENTITY_INSERT [Setting] OFF
GO
CREATE NONCLUSTERED INDEX [Idx_CodLevel] ON [QuestionLevel]
(
	[Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([IdQuestion])
REFERENCES [Question] ([Id])
GO
ALTER TABLE [Answer] CHECK CONSTRAINT [FK_Answer_Question]
GO
ALTER TABLE [FinalTestMessage]  WITH CHECK ADD  CONSTRAINT [FK_FinalTestMessage_Dependency] FOREIGN KEY([IdDependency])
REFERENCES [Dependency] ([Id])
GO
ALTER TABLE [FinalTestMessage] CHECK CONSTRAINT [FK_FinalTestMessage_Dependency]
GO
ALTER TABLE [FinalTestMessageQuestionLevel]  WITH CHECK ADD  CONSTRAINT [FK_FinalTestMessageQuestionLevel_QuestionLevel] FOREIGN KEY([IdQuestionLevel])
REFERENCES [QuestionLevel] ([Id])
GO
ALTER TABLE [FinalTestMessageQuestionLevel] CHECK CONSTRAINT [FK_FinalTestMessageQuestionLevel_QuestionLevel]
GO
ALTER TABLE [Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Dependency] FOREIGN KEY([IdDependency])
REFERENCES [Dependency] ([Id])
GO
ALTER TABLE [Question] CHECK CONSTRAINT [FK_Question_Dependency]
GO
ALTER TABLE [Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionLevel] FOREIGN KEY([IdQuestionLevel])
REFERENCES [QuestionLevel] ([Id])
GO
ALTER TABLE [Question] CHECK CONSTRAINT [FK_Question_QuestionLevel]
GO
ALTER TABLE [QuestionLevel]  WITH CHECK ADD  CONSTRAINT [FK_QuestionLevel_Dependency] FOREIGN KEY([IdDependency])
REFERENCES [Dependency] ([Id])
GO
ALTER TABLE [QuestionLevel] CHECK CONSTRAINT [FK_QuestionLevel_Dependency]
GO
ALTER TABLE [Setting]  WITH CHECK ADD  CONSTRAINT [FK_Setting_Dependency] FOREIGN KEY([IdDependency])
REFERENCES [Dependency] ([Id])
GO
ALTER TABLE [Setting] CHECK CONSTRAINT [FK_Setting_Dependency]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

exec FinalTestMessage_Find 1

select * from questionlevel


*/
CREATE PROCEDURE [FinalTestMessage_ListByDependency]
@IdDependency int 
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS ON; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.


Select
f.Id,
f.Cod,
f.AnswersRangeMin,
f.AnswersRangeMax,
f.FinalTestMessageDescription,
STUFF((SELECT ' |' + convert(varchar,q.Cod) + '- ' + q.Class + '-'  + q.QuestionLevelDescription  from FinalTestMessageQuestionLevel l inner join QuestionLevel q on l.IdQuestionLevel = q.Id where l.IdFinalTestMessage = f.Id FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, LEN(' |'), '') as LevelDescription
From FinalTestMessage f 
where f.IdDependency = @IdDependency



END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [ImagenTest_Delete]
@Id int
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

delete from ImagenTest where Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [ImagenTest_Insert]
@ImagenTest text
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

insert into ImagenTest values (@ImagenTest)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [ImagenTest_List]
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

SELECT 
i.Id,
i.ImageText
FROM ImagenTest i

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

exec Question_Find 1,0
*/

CREATE PROCEDURE [Question_ListByDependency]
@IdDependency int,
@CodLevel int = 0
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS ON; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

declare @QuestionPerPage int 

select @QuestionPerPage = s.QuestionPerPage from Setting s where s.IdDependency = @IdDependency

select top (@QuestionPerPage)
q.Id,
q.Cod,
q.QuestionDescription,
l.Cod as CodLevel,
STUFF((SELECT ' |' + a.AnswerDescription + case when a.Valid = 1 then ' -true' else ' -false' end FROM Answer a where a.IdQuestion = q.Id FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, LEN(' |'), '') as AnswerDescription
from Question q
inner join QuestionLevel l
	on l.Id = q.IdQuestionLevel
inner join Setting s 
	on s.IdDependency = q.IdDependency
where 
(
	q.IdDependency = @IdDependency
)
and
(
	( @CodLevel = 0 ) or ( l.Cod = @CodLevel)  
)
ORDER BY NEWID()




END try



BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [QuestionLevel_ListByDependency]
@IdDependency int 
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.

Select
q.Id,
q.Cod,
q.QuestionLevelDescription,
q.Class
From QuestionLevel q (nolock)
where q.IdDependency =  @IdDependency

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Setting_GetByDependency]
	@IdDependency int
AS
BEGIN
declare @MsgError varchar(100)

BEGIN TRY
SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.
SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS 
SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada
SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...
SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.


Select top 1
s.cod,
s.questionperpage,
s.correctanswers,
s.tittle,
s.subtittle,
s.instruction,
s.downloadtittle,
s.downloadlink,
s.preinstructiontittle,
s.preinstruction
From Setting s
where 
s.IdDependency = @IdDependency


END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


GO
