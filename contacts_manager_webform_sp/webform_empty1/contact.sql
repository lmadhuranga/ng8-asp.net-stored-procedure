
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Mobile] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 


CREATE PROC [dbo].[ContactCreateOrUpdate]
@ContactID int,
@Name varchar(50),
@Mobile varchar(50),
@Address varchar(50)
AS
BEGIN
IF(@ContactID=0)
	BEGIN
	INSERT INTO Contact (Name, Mobile, Address)
	VALUES(@name, @mobile, @Address)
	END
ELSE
	BEGIN
	UPDATE Contact 
	SET 
		Name = @Name,
		Mobile = @Mobile,
		Address = @Address
	WHERE ContactID = @ContactID
	END
END


GO


CREATE PROC [dbo].[ContactDeleteByID]
@ContactID int
AS
	BEGIN
	DELETE FROM Contact 
	WHERE ContactID=@ContactID
	END


GO




CREATE PROC [dbo].[ContactViewAll]
AS
	BEGIN
	SELECT * FROM Contact
	END

GO


CREATE PROC [dbo].[ContactViewByID]
@ContactID int
AS
	BEGIN
	SELECT * FROM Contact
	WHERE ContactID=@ContactID
	END
GO


















