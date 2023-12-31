USE [master]
GO
/****** Object:  Database [eCommerce]    Script Date: 11/4/2023 10:34:00 PM ******/
CREATE DATABASE [eCommerce]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eCommerce', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MICROSOFTSQL2022\MSSQL\DATA\eCommerce.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eCommerce_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MICROSOFTSQL2022\MSSQL\DATA\eCommerce_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [eCommerce] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eCommerce].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eCommerce] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eCommerce] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eCommerce] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eCommerce] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eCommerce] SET ARITHABORT OFF 
GO
ALTER DATABASE [eCommerce] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eCommerce] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eCommerce] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eCommerce] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eCommerce] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eCommerce] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eCommerce] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eCommerce] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eCommerce] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eCommerce] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eCommerce] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eCommerce] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eCommerce] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eCommerce] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eCommerce] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eCommerce] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eCommerce] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eCommerce] SET RECOVERY FULL 
GO
ALTER DATABASE [eCommerce] SET  MULTI_USER 
GO
ALTER DATABASE [eCommerce] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eCommerce] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eCommerce] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eCommerce] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eCommerce] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eCommerce] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'eCommerce', N'ON'
GO
ALTER DATABASE [eCommerce] SET QUERY_STORE = ON
GO
ALTER DATABASE [eCommerce] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [eCommerce]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/4/2023 10:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [pk_dbo_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountSeller]    Script Date: 11/4/2023 10:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountSeller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [pk_dbo_Account_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountUser]    Script Date: 11/4/2023 10:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NULL,
	[Password] [varchar](100) NULL,
 CONSTRAINT [pk_dbo_Account_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[buy]    Script Date: 11/4/2023 10:34:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[buy](
	[ItemNo] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[BuyerId] [int] NULL,
	[BuyerQuantity] [int] NULL,
	[PricePerUnit] [money] NULL,
	[TotalPrice] [money] NULL,
	[OrderClear] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cart]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[ItemNo] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[BuyerId] [int] NULL,
	[BuyerQuantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemDetails]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemDetails](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ItemName] [varchar](50) NULL,
	[Price] [money] NULL,
	[Category] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[Description] [varchar](200) NULL,
	[FileName] [varchar](200) NULL,
	[FileSize] [int] NULL,
	[FileType] [varchar](20) NULL,
	[FilePath] [varchar](200) NULL,
	[UploadDate] [datetime] NULL,
 CONSTRAINT [pk_dbo_ItemDetails] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
	[Password] [varchar](200) NULL,
	[UserName] [varchar](100) NULL,
	[Seller] [int] NULL,
	[Contact] [varchar](10) NULL,
	[UserType] [int] NULL,
 CONSTRAINT [pk_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[buy]  WITH CHECK ADD  CONSTRAINT [fk_dbo_buy] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[buy] CHECK CONSTRAINT [fk_dbo_buy]
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD  CONSTRAINT [fk_dbo_cart] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemDetails] ([ItemId])
GO
ALTER TABLE [dbo].[cart] CHECK CONSTRAINT [fk_dbo_cart]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddCategories]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_AddCategories]
@CategoryName varchar(100)
as
begin
	Insert Into Categories(CategoryName)
	values(@CategoryName);
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AddToCart]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[SP_AddToCart]
	@ItemId int,
	@BuyerId int,
	@BuyerQuantity int
as 
begin
	MERGE cart AS target
			USING (
				SELECT 
					ItemId, 
					@BuyerId AS BuyerId, @BuyerQuantity AS BuyerQuantity
				FROM ItemDetails 
				WHERE ItemId = @ItemId
			) AS source
			ON target.ItemId = source.ItemId AND target.BuyerId = source.BuyerId
			WHEN MATCHED THEN
				UPDATE SET
					
					BuyerId = source.BuyerId,
					BuyerQuantity = source.BuyerQuantity+1
			WHEN NOT MATCHED THEN
				INSERT (
					ItemId,BuyerId, BuyerQuantity
				)
				VALUES (
					source.ItemId,source.BuyerId, source.BuyerQuantity
				);
	
	update ItemDetails
	set 
	Quantity = (Quantity-1) where ItemId = @ItemId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_BuyItems]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_BuyItems]
	@ItemNo int,
	@BuyerId int,
	@BuyerQuantity int,
	@ItemId int,
	@PricePerUnit money,
	@TotalPrice money
as 
begin
	
	delete from cart
	where ItemNo=@ItemNo;

	INSERT INTO Buy(ItemId,BuyerId,BuyerQuantity,PricePerUnit,TotalPrice,OrderClear)
    VALUES (@ItemId,@BuyerId,@BuyerQuantity,@PricePerUnit,@TotalPrice,0)

end
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckUserDetails]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_CheckUserDetails]
as
begin
	select * from UserDetails
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ClearItemsOrder]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_ClearItemsOrder]
@BuyerId int,
@ItemId int
as
begin
	update Buy
	set OrderClear = 1
	where BuyerId = @BuyerId and ItemId = @ItemId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCategories]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_DeleteCategories]
@CategoryId int
as
begin
	Delete  from Categories where CategoryId=@CategoryId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DisplayItem]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_DisplayItem]
as 
begin
	select * from ItemDetails;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EditCategories]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_EditCategories]
@CategoryId int,
@CategoryName varchar(100)
as
begin
	update Categories
	set CategoryName=@CategoryName where CategoryId=@CategoryId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EditEcomUser]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_EditEcomUser]
	@UserId int,
	@Name varchar(200),
	@Email varchar(200),
	@UserName varchar(100),
	@Password varchar(200),
	@Seller int
as
begin
	update UserDetails
	set Name = @Name,Email=@Email,UserName=@UserName,Password=@Password,Seller=@Seller
	where UserId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EditItem]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_EditItem]
	@ItemId INT,
	@UserId INT,
	@ItemName varchar(50),
	@Price money,
	@Category varchar(50),
	@Quantity int,
	@Description varchar(200),
    @FilePath NVARCHAR(500),
    @FileSize BIGINT,
    @FileType NVARCHAR(100),
    @FileName NVARCHAR(200),
    @UploadDate DATETIME
as
begin
	update ItemDetails
	set
	UserId=@UserId,
	ItemName=@ItemName,
	Price=@Price,
	Category=@Category,
	Quantity=@Quantity,
	Description=@Description,
    FilePath=@FilePath,
    FileSize=@FileSize,
    FileType=@FileType,
    FileName=@FileName,
    UploadDate=@UploadDate
	where ItemId=@ItemId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllUserDetails]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetAllUserDetails]
as
begin
	select * from UserDetails
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBuyItems]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetBuyItems]
@BuyerId int
as 
begin
		SELECT b.ItemNo,id.ItemId,id.ItemName,id.Category,id.Quantity,id.Description,b.BuyerId,b.BuyerQuantity,b.PricePerUnit,b.TotalPrice
FROM ItemDetails as id
INNER JOIN buy as b ON id.ItemId=b.ItemId and b.BuyerId=@BuyerId ;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBuyReports]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GetBuyReports]
@UserId int
as 
begin

SELECT b.ItemNo,id.ItemId,id.ItemName,id.Category,id.Quantity,b.BuyerQuantity,b.PricePerUnit,b.TotalPrice,b.OrderClear,b.BuyerId,
ud.Name,ud.Email,ud.Contact
FROM ItemDetails as id
Inner JOIN buy as b ON id.ItemId=b.ItemId and id.UserId=@UserId 
Inner Join UserDetails as ud on ud.UserId = b.buyerId;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCartItems]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GetCartItems]
	@BuyerId int
as 
begin
		SELECT c.ItemNo,id.ItemId,id.ItemName,id.Price,id.Category,id.Quantity,id.Description,c.BuyerId,c.BuyerQuantity
FROM ItemDetails as id
INNER JOIN cart as c ON id.ItemId=c.ItemId and c.BuyerId=@BuyerId ;
end

GO
/****** Object:  StoredProcedure [dbo].[SP_GetCartItemsForEdit]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_GetCartItemsForEdit]
	@ItemNo int,
	@BuyerQuantity int,
	@Quantity int
as 
begin
	update cart
	set
	BuyerQuantity=@BuyerQuantity where ItemNo=@ItemNo

	update ItemDetails
	set
	Quantity = @Quantity where ItemId=(select ItemId from cart where ItemNo=@ItemNo)

end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCategories]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[SP_GetCategories]
 as
 begin
	Select * from Categories
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvidualEditItem]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetInvidualEditItem]
@ItemId int
as
begin
	select * from ItemDetails where ItemId = @ItemId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetItemsForEdit]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetItemsForEdit]
@UserId int
as
begin
	select * from ItemDetails where UserId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetUserDetailsForEdit]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetUserDetailsForEdit]
@UserId int
as
begin
	Select * from UserDetails where UserId = @UserId
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RegisterUser]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SP_AddUser]    Script Date: 10/11/2023 7:39:29 AM ******/
CREATE proc [dbo].[SP_RegisterUser]
	@Name varchar(200),
	@Email varchar(200),
	@UserName varchar(100),
	@Password varchar(200),
	@Seller int,
	@Contact varchar(15),
	@UserType int
AS
BEGIN
    INSERT INTO UserDetails(UserName,Name,Email,Seller,Password,Contact,UserType)
    VALUES (@UserName,@Name,@Email,@Seller,@Password,@Contact,@UserType)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RemoveItemsFromCart]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_RemoveItemsFromCart]
	@ItemNo int,
	@Quantity int
as 
begin
	update ItemDetails
	set
	Quantity = @Quantity where ItemId=(select ItemId from cart where ItemNo=@ItemNo)

	delete  from cart 
	where ItemNo=@ItemNo

	

end
GO
/****** Object:  StoredProcedure [dbo].[SP_UploadItem]    Script Date: 11/4/2023 10:34:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_UploadItem]
	@UserId INT,
	@ItemName varchar(50),
	@Price money,
	@Category varchar(50),
	@Quantity int,
	@Description varchar(200),
    @FilePath NVARCHAR(500),
    @FileSize BIGINT,
    @FileType NVARCHAR(100),
    @FileName NVARCHAR(200),
    @UploadDate DATETIME
AS
BEGIN
    INSERT INTO ItemDetails(UserId,ItemName,Price,Category,Quantity,Description, FilePath, FileSize, FileType, FileName, UploadDate)
    VALUES (@UserId,@ItemName,@Price,@Category,@Quantity,@Description, @FilePath, @FileSize, @FileType, @FileName, @UploadDate)
END
GO
USE [master]
GO
ALTER DATABASE [eCommerce] SET  READ_WRITE 
GO
