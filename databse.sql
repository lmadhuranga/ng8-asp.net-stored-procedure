

/****** Object:  Table [dbo].[Contacts]    Script Date: 8/14/2019 5:22:37 PM ******/
DROP TABLE [dbo].[Contacts]
GO
 

CREATE TABLE [dbo].[Contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[mobile] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
 

CREATE PROC [dbo].[ContactsCreateOrUpdate]
@id int,
@name varchar(50),
@mobile varchar(50),
@email varchar(250)
AS
BEGIN
IF(@id=0)
	BEGIN
	INSERT INTO Contacts(name, mobile, email)
	VALUES(@name, @mobile, @email)
	END
ELSE
	BEGIN
	UPDATE Contacts
	SET 
		name = @name,
		mobile = @mobile,
		email= @email
	WHERE id = @id
	END
END



CREATE PROC [dbo].[ContactsDeleteByID]
@id int
AS
	BEGIN
	DELETE FROM Contacts
	WHERE id=@id
	END


CREATE PROC [dbo].[ContactsViewAll]
AS
	BEGIN
	SELECT * FROM Contacts
	END

CREATE PROC [dbo].[ContactsViewByID]
@id int
AS
	BEGIN
	SELECT * FROM Contacts
	WHERE id=@id
	END

