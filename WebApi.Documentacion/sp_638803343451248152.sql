SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Dependency_List]
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
d.[Id],d.[Descripcion]  FROM Dependency d (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Dependency_Get]
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

SELECT TOP 1
d.[Id],d.[Descripcion] FROM Dependency d
WHERE 
d.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Dependency_Insert]
@Descripcion varchar(200)
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

INSERT INTO Dependency (
Descripcion) VALUES ( 
@Descripcion ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Dependency_Update] 
@Id int,@Descripcion varchar(200)
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

UPDATE Dependency SET
Descripcion = @Descripcion
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Dependency_Delete]
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

delete from Dependency 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[QuestionLevel_List]
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
q.[Id],q.[IdDependency] ,
q.[Cod] ,
q.[QuestionLevelDescription] ,
q.[Class]  FROM QuestionLevel q (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[QuestionLevel_Get]
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

SELECT TOP 1
q.[Id],q.[IdDependency] ,
q.[Cod] ,
q.[QuestionLevelDescription] ,
q.[Class] FROM QuestionLevel q
WHERE 
q.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[QuestionLevel_Insert]
@IdDependency int,
@Cod int,
@QuestionLevelDescription varchar(50),
@Class varchar(50)
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

INSERT INTO QuestionLevel (
IdDependency,Cod,QuestionLevelDescription,
Class) VALUES ( 
@IdDependency,@Cod,@QuestionLevelDescription,
@Class ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[QuestionLevel_Update] 
@Id int,@IdDependency int,
@Cod int,
@QuestionLevelDescription varchar(50),
@Class varchar(50)
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

UPDATE QuestionLevel SET
IdDependency = @IdDependency,
Cod = @Cod,
QuestionLevelDescription = @QuestionLevelDescription,
Class = @Class
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[QuestionLevel_Delete]
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

delete from QuestionLevel 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answer_List]
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
a.[Id],a.[IdQuestion] ,
a.[AnswerDescription] ,
a.[Valid]  FROM Answer a (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answer_Get]
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

SELECT TOP 1
a.[Id],a.[IdQuestion] ,
a.[AnswerDescription] ,
a.[Valid] FROM Answer a
WHERE 
a.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answer_Insert]
@IdQuestion int,
@AnswerDescription varchar(500),
@Valid bit = 0
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

INSERT INTO Answer (
IdQuestion,AnswerDescription,Valid
) VALUES ( 
@IdQuestion,@AnswerDescription,@Valid
 ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answer_Update] 
@Id int,@IdQuestion int,
@AnswerDescription varchar(500),
@Valid bit
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

UPDATE Answer SET
IdQuestion = @IdQuestion,
AnswerDescription = @AnswerDescription,
Valid = @Valid
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Answer_Delete]
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

delete from Answer 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessage_List]
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
f.[Id],f.[IdDependency] ,
f.[Cod] ,
f.[answersrangemin] ,
f.[answersrangemax] ,
f.[FinalTestMessageDescription]  FROM FinalTestMessage f (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessage_Get]
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

SELECT TOP 1
f.[Id],f.[IdDependency] ,
f.[Cod] ,
f.[answersrangemin] ,
f.[answersrangemax] ,
f.[FinalTestMessageDescription] FROM FinalTestMessage f
WHERE 
f.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessage_Insert]
@IdDependency int,
@Cod int,
@answersrangemin smallint,
@answersrangemax smallint,
@FinalTestMessageDescription varchar(500)
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

INSERT INTO FinalTestMessage (
IdDependency,Cod,answersrangemin,
answersrangemax,FinalTestMessageDescription) VALUES ( 
@IdDependency,@Cod,@answersrangemin,
@answersrangemax,@FinalTestMessageDescription ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessage_Update] 
@Id int,@IdDependency int,
@Cod int,
@answersrangemin smallint,
@answersrangemax smallint,
@FinalTestMessageDescription varchar(500)
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

UPDATE FinalTestMessage SET
IdDependency = @IdDependency,
Cod = @Cod,
answersrangemin = @answersrangemin,
answersrangemax = @answersrangemax,
FinalTestMessageDescription = @FinalTestMessageDescription
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessage_Delete]
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

delete from FinalTestMessage 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessageQuestionLevel_List]
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
f.[Id],f.[IdFinalTestMessage] ,
f.[IdQuestionLevel]  FROM FinalTestMessageQuestionLevel f (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessageQuestionLevel_Get]
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

SELECT TOP 1
f.[Id],f.[IdFinalTestMessage] ,
f.[IdQuestionLevel] FROM FinalTestMessageQuestionLevel f
WHERE 
f.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessageQuestionLevel_Insert]
@IdFinalTestMessage int,
@IdQuestionLevel int
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

INSERT INTO FinalTestMessageQuestionLevel (
IdFinalTestMessage,IdQuestionLevel) VALUES ( 
@IdFinalTestMessage,@IdQuestionLevel ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessageQuestionLevel_Update] 
@Id int,@IdFinalTestMessage int,
@IdQuestionLevel int
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

UPDATE FinalTestMessageQuestionLevel SET
IdFinalTestMessage = @IdFinalTestMessage,
IdQuestionLevel = @IdQuestionLevel
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FinalTestMessageQuestionLevel_Delete]
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

delete from FinalTestMessageQuestionLevel 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Question_List]
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
q.[Id],q.[IdDependency] ,
q.[QuestionDescription] ,
q.[Cod] ,
q.[IdQuestionLevel]  FROM Question q (nolock)

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Question_Get]
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

SELECT TOP 1
q.[Id],q.[IdDependency] ,
q.[QuestionDescription] ,
q.[Cod] ,
q.[IdQuestionLevel] FROM Question q
WHERE 
q.Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Question_Insert]
@IdDependency int,
@QuestionDescription varchar(500),
@Cod varchar(50),
@IdQuestionLevel int
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

INSERT INTO Question (
IdDependency,QuestionDescription,Cod,
IdQuestionLevel) VALUES ( 
@IdDependency,@QuestionDescription,@Cod,
@IdQuestionLevel ) 

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Question_Update] 
@Id int,@IdDependency int,
@QuestionDescription varchar(500),
@Cod varchar(50),
@IdQuestionLevel int
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

UPDATE Question SET
IdDependency = @IdDependency,
QuestionDescription = @QuestionDescription,
Cod = @Cod,
IdQuestionLevel = @IdQuestionLevel
WHERE 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Question_Delete]
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

delete from Question 
where 
Id = @Id

END try

BEGIN CATCH
set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()
RAISERROR(@MsgError, 16, 1);
END CATCH;
END

