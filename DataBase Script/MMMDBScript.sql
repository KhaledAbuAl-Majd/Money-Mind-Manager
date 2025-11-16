--it's mandatory to have FULL TEXT SERACH - if it isn't installed (install it from sql server installation center)

USE [master]
GO
/****** Object:  Database [MoneyMindManager]    Script Date: 12/11/2025 8:51:50 AM ******/
CREATE DATABASE [MoneyMindManager]
GO
ALTER DATABASE [MoneyMindManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoneyMindManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoneyMindManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoneyMindManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoneyMindManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoneyMindManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoneyMindManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoneyMindManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoneyMindManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoneyMindManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoneyMindManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoneyMindManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoneyMindManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoneyMindManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoneyMindManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoneyMindManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoneyMindManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoneyMindManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoneyMindManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoneyMindManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoneyMindManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoneyMindManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoneyMindManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoneyMindManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoneyMindManager] SET RECOVERY FULL 
GO
ALTER DATABASE [MoneyMindManager] SET  MULTI_USER 
GO
ALTER DATABASE [MoneyMindManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoneyMindManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoneyMindManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoneyMindManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MoneyMindManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MoneyMindManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MoneyMindManager', N'ON'
GO
ALTER DATABASE [MoneyMindManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [MoneyMindManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MoneyMindManager]
GO
/****** Object:  FullTextCatalog [ft_MoneyMindManager]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sysfulltextcatalogs ftc WHERE ftc.name = N'ft_MoneyMindManager')
CREATE FULLTEXT CATALOG [ft_MoneyMindManager] WITH ACCENT_SENSITIVITY = OFF
AS DEFAULT
GO
/****** Object:  UserDefinedFunction [dbo].[AccountTypeNameBasedOnIsCurrentAccount]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountTypeNameBasedOnIsCurrentAccount]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE   FUNCTION [dbo].[AccountTypeNameBasedOnIsCurrentAccount] (@IsCurrentAccount BIT)
RETURNS NVARCHAR(20)
AS
BEGIN
	RETURN (
		CASE 
			WHEN @IsCurrentAccount = 1 THEN  N''جاري''
			ELSE  N''إدخار''
		END
	);
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAccountOwnerUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccountOwnerUserID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[GetAccountOwnerUserID] (@AccountID SMALLINT)
RETURNS INT
AS
BEGIN
	DECLARE @UserOwner INT = NULL;

	SELECT @UserOwner = UserID FROM Users WHERE AccountID = @AccountID AND Permissions = -1;

	RETURN @UserOwner;
END;
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetBalanceForAccountAfterCalculate]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBalanceForAccountAfterCalculate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[GetBalanceForAccountAfterCalculate](@AccountID INT)
RETURNS decimal(19, 4)
AS
BEGIN
	DECLARE @Balance DECIMAL(19,4);

	SELECT @Balance = SUM(Amount) FROM MainTransactions WHERE AccountID = @AccountID

	RETURN ISNULL(@Balance,0);
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryHierarchicalString]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCategoryHierarchicalString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[GetCategoryHierarchicalString] (@CategoryID INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Hierachical NVARCHAR(MAX);

	WITH CTE AS
	(
		SELECT CategoryID,CategoryName,CAST(CategoryName AS NVARCHAR(MAX)) AS Hierarchical,ParentCategoryID FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID

		UNION ALL

		SELECT IAEC.CategoryID,IAEC.CategoryName,(IAEC.CategoryName + NCHAR(8206) + N'' ⟶ '' + NCHAR(8206) + CTE.Hierarchical),IAEC.ParentCategoryID
		FROM IncomeAndExpenseCategories IAEC INNER JOIN CTE ON IAEC.CategoryID = CTE.ParentCategoryID
		WHERE IAEC.CategoryID IS NOT NULL
	)
	SELECT @Hierachical = Hierarchical FROM CTE WHERE ParentCategoryID IS NULL;

	RETURN @Hierachical;
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetDebtRemainingAmount]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDebtRemainingAmount]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE   FUNCTION [dbo].[GetDebtRemainingAmount](@DebtID INT)
RETURNS decimal(19, 4)
AS
BEGIN
	DECLARE @RemainingAmount DECIMAL(19,4);

	WITH CTE AS 
	(
		SELECT t.Amount FROM Debts d INNER JOIN MainTransactions t ON d.DebtTransactionID = t.TransactionID WHERE d.DebtID = @DebtID

		UNION ALL

		SELECT t.Amount FROM DebtPayments d INNER JOIN MainTransactions t ON d.MainTransactionID = t.TransactionID WHERE d.DebtID = @DebtID
	)

	SELECT @RemainingAmount = ABS(SUM(Amount)) FROM CTE ;

	RETURN ISNULL(@RemainingAmount,0);
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainCategoryNameForCategoryByCategoryID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainCategoryNameForCategoryByCategoryID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetMainCategoryNameForCategoryByCategoryID] (@CategoryID INT)
RETURNS NVARCHAR(200)
AS
BEGIN
	DECLARE @MainCategoryName NVARCHAR(200);

	WITH CTE AS
	(
		SELECT CategoryID,CategoryName,ParentCategoryID FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID

		UNION ALL

		SELECT IAEC.CategoryID,IAEC.CategoryName,IAEC.ParentCategoryID
		FROM IncomeAndExpenseCategories IAEC INNER JOIN CTE ON IAEC.CategoryID = CTE.ParentCategoryID
	)
	SELECT @MainCategoryName = CategoryName FROM CTE WHERE ParentCategoryID IS NULL

	RETURN @MainCategoryName;
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMoneyPerformance]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMoneyPerformance]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
CREATE FUNCTION [dbo].[GetMoneyPerformance](@StartDate DATE,@EndDate DATE, @AccountID SMALLINT)
RETURNS DECIMAL(19,4)
As
BEGIN

	DECLARE @Performance DECIMAL(19,4);

	WITH Summary AS
		(
			SELECT
			SUM(CASE WHEN TransactionTypeID = 1 THEN Amount	ELSE 0 END) AS Income,

			SUM(CASE WHEN TransactionTypeID = 2 THEN Amount ELSE 0 END) AS Expense,
			
			SUM(CASE WHEN TransactionTypeID = 5 THEN Amount	ELSE 0 END) AS ExpenseReturn
	
			FROM MainTransactions
			WHERE TransactionDate >= @StartDate AND TransactionDate < DATEADD(Day,1,@EndDate) AND AccountID = @AccountID
		)
		SELECT @Performance = (ISNULL(Income,0) - (ISNULL(ABS(Expense),0) - ISNULL(ExpenseReturn,0))) FROM Summary

		RETURN ISNULL(@Performance,0);
END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetVoucherValue]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetVoucherValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetVoucherValue](@VoucherID INT)
RETURNS decimal(19, 4)
AS
BEGIN
	DECLARE @Balance DECIMAL(19,4);

	SELECT @Balance = SUM(Amount) FROM MainTransactions MT INNER JOIN IncomeAndExpenseTransactions IET ON MT.TransactionID = IET.MainTransactionID
	WHERE IET.VoucherID = @VoucherID

	RETURN ISNULL(@Balance,0);
END' 
END
GO
/****** Object:  Table [dbo].[IncomeAndExpenseCategories]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IncomeAndExpenseCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NOT NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
	[MonthlyBudget] [decimal](19, 4) NULL,
	[IsIncome] [bit] NOT NULL,
	[ParentCategoryID] [int] NULL,
	[AccountID] [smallint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Notes] [nvarchar](250) NULL,
	[MainCategoryID] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCategoryWithHerChildren]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCategoryWithHerChildren]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE   FUNCTION [dbo].[GetCategoryWithHerChildren] (@CategoryID INT)
RETURNS TABLE
AS
RETURN 
(	
	WITH CTE AS
	(
		SELECT CategoryID,CategoryName,ParentCategoryID FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID
	
		UNION ALL

		SELECT i.CategoryID,i.CategoryName,i.ParentCategoryID FROM IncomeAndExpenseCategories i INNER JOIN CTE ON i.ParentCategoryID = CTE.CategoryID
	)

	SELECT * FROM CTE
)' 
END
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Accounts](
	[AccountID] [smallint] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DefaultCurrencyID] [tinyint] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Balance] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Accounts_Name] UNIQUE NONCLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Currencies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Currencies](
	[CurrencyID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](50) NOT NULL,
	[CurrencySymbol] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[CurrencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Currencies] UNIQUE NONCLUSTERED 
(
	[CurrencyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Currencies_1] UNIQUE NONCLUSTERED 
(
	[CurrencySymbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[DebtPayments]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DebtPayments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DebtPayments](
	[MainTransactionID] [int] NOT NULL,
	[DebtID] [int] NOT NULL,
	[IsLending] [bit] NOT NULL,
 CONSTRAINT [PK_DebtPayments] PRIMARY KEY CLUSTERED 
(
	[MainTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Debts]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Debts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Debts](
	[DebtID] [int] IDENTITY(1,1) NOT NULL,
	[IsLending] [bit] NOT NULL,
	[PersonID] [int] NOT NULL,
	[PaymentDueDate] [date] NULL,
	[DebtTransactionID] [int] NOT NULL,
	[AccountID] [smallint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[RemainingAmount] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_Debts] PRIMARY KEY CLUSTERED 
(
	[DebtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_DebtTransactionID_Debts] UNIQUE NONCLUSTERED 
(
	[DebtTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLogs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ErrorLogs](
	[ErrorMessage] [nvarchar](500) NOT NULL,
	[ErrorNumber] [int] NOT NULL,
	[ErrorProcedure] [nvarchar](200) NOT NULL,
	[ErrorLine] [smallint] NOT NULL,
	[ErrorDate] [datetime2](0) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[IncomeAndExpenseTransactions]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IncomeAndExpenseTransactions](
	[MainTransactionID] [int] NOT NULL,
	[VoucherID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_IncomeAndExpenseTransactions_1] PRIMARY KEY CLUSTERED 
(
	[MainTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[IncomeAndExpenseVouchers]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[IncomeAndExpenseVouchers](
	[VoucherID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherName] [nvarchar](150) NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[IsLocked] [bit] NOT NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
	[VoucherDate] [date] NOT NULL,
	[AccountID] [smallint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[IsIncome] [bit] NOT NULL,
	[IsReturn] [bit] NOT NULL,
	[VoucherValue] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_IncomeAndExpenseVouchers] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MainTransactions]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MainTransactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MainTransactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
	[AccountID] [smallint] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[TransactionTypeID] [tinyint] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[Purpose] [nvarchar](150) NULL,
	[TransactionDate] [date] NOT NULL,
 CONSTRAINT [PK_AllTransactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[People]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[People](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[PersonName] [nvarchar](150) NOT NULL,
	[Address] [nvarchar](300) NULL,
	[Email] [nvarchar](255) NULL,
	[Phone] [nvarchar](20) NULL,
	[AccountID] [smallint] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SystemSettings]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SystemSettings](
	[SettingKey] [nvarchar](100) NOT NULL,
	[SettingValue] [nvarchar](255) NULL,
 CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED 
(
	[SettingKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TransactionTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TransactionTypes](
	[TransactionTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TransactionName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_TransactionTypes] UNIQUE NONCLUSTERED 
(
	[TransactionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Permissions] [int] NOT NULL,
	[Password] [varchar](64) NOT NULL,
	[Salt] [varchar](24) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Notes] [nvarchar](200) NULL,
	[AccountID] [smallint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedDate] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Index [IX_DebtID_DebtPayments]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DebtPayments]') AND name = N'IX_DebtID_DebtPayments')
CREATE NONCLUSTERED INDEX [IX_DebtID_DebtPayments] ON [dbo].[DebtPayments]
(
	[DebtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Debts_Comprehensive]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Debts]') AND name = N'IX_Debts_Comprehensive')
CREATE NONCLUSTERED INDEX [IX_Debts_Comprehensive] ON [dbo].[Debts]
(
	[AccountID] ASC,
	[IsLending] ASC,
	[PaymentDueDate] ASC,
	[RemainingAmount] ASC
)
INCLUDE([PersonID],[DebtTransactionID],[CreatedByUserID]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ErrorLogs]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLogs]') AND name = N'IX_ErrorLogs')
CREATE NONCLUSTERED INDEX [IX_ErrorLogs] ON [dbo].[ErrorLogs]
(
	[ErrorDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Account_CategoryName_Comprehensive]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]') AND name = N'UX_Account_CategoryName_Comprehensive')
CREATE UNIQUE NONCLUSTERED INDEX [UX_Account_CategoryName_Comprehensive] ON [dbo].[IncomeAndExpenseCategories]
(
	[AccountID] ASC,
	[CategoryName] ASC
)
INCLUDE([IsIncome],[IsActive],[ParentCategoryID],[MainCategoryID],[CreatedDate]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IAETransactions_CategoryID]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]') AND name = N'IX_IAETransactions_CategoryID')
CREATE NONCLUSTERED INDEX [IX_IAETransactions_CategoryID] ON [dbo].[IncomeAndExpenseTransactions]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IAETransactions_VoucherID]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]') AND name = N'IX_IAETransactions_VoucherID')
CREATE NONCLUSTERED INDEX [IX_IAETransactions_VoucherID] ON [dbo].[IncomeAndExpenseTransactions]
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vouchers_ComprehensiveSearch]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]') AND name = N'IX_Vouchers_ComprehensiveSearch')
CREATE NONCLUSTERED INDEX [IX_Vouchers_ComprehensiveSearch] ON [dbo].[IncomeAndExpenseVouchers]
(
	[AccountID] ASC,
	[IsIncome] ASC,
	[IsReturn] ASC,
	[VoucherDate] DESC
)
INCLUDE([VoucherName],[VoucherValue],[CreatedDate],[CreatedByUserID]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MainTransactions_Comprehensive]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MainTransactions]') AND name = N'IX_MainTransactions_Comprehensive')
CREATE NONCLUSTERED INDEX [IX_MainTransactions_Comprehensive] ON [dbo].[MainTransactions]
(
	[AccountID] ASC,
	[TransactionDate] DESC,
	[TransactionTypeID] ASC
)
INCLUDE([Amount],[CreatedByUserID],[Purpose],[CreatedDate]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MainTransactions_CreatedDate]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MainTransactions]') AND name = N'IX_MainTransactions_CreatedDate')
CREATE NONCLUSTERED INDEX [IX_MainTransactions_CreatedDate] ON [dbo].[MainTransactions]
(
	[CreatedDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MainTransactions_TransactionDate]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MainTransactions]') AND name = N'IX_MainTransactions_TransactionDate')
CREATE NONCLUSTERED INDEX [IX_MainTransactions_TransactionDate] ON [dbo].[MainTransactions]
(
	[TransactionDate] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_People_ComprehensiveSearch]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND name = N'IX_People_ComprehensiveSearch')
CREATE NONCLUSTERED INDEX [IX_People_ComprehensiveSearch] ON [dbo].[People]
(
	[AccountID] ASC
)
INCLUDE([PersonName],[Email],[Phone],[Address]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_People_Email]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND name = N'IX_People_Email')
CREATE NONCLUSTERED INDEX [IX_People_Email] ON [dbo].[People]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_People_Phone]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND name = N'IX_People_Phone')
CREATE NONCLUSTERED INDEX [IX_People_Phone] ON [dbo].[People]
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_AccountID_Covering]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'IX_Users_AccountID_Covering')
CREATE NONCLUSTERED INDEX [IX_Users_AccountID_Covering] ON [dbo].[Users]
(
	[AccountID] ASC,
	[IsDeleted] ASC
)
INCLUDE([IsActive]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UX_Users_PersonID_IsDeleted]    Script Date: 13/11/2025 7:33:48 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND name = N'UX_Users_PersonID_IsDeleted')
CREATE UNIQUE NONCLUSTERED INDEX [UX_Users_PersonID_IsDeleted] ON [dbo].[Users]
(
	[PersonID] ASC
)
WHERE ([IsDeleted]=(0))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  FullTextIndex     Script Date: 13/11/2025 7:33:48 PM ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
CREATE FULLTEXT INDEX ON [dbo].[IncomeAndExpenseCategories](
[CategoryName] LANGUAGE 'Arabic')
KEY INDEX [PK_Categories]ON ([ft_MoneyMindManager], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = OFF)

GO
/****** Object:  FullTextIndex     Script Date: 13/11/2025 7:33:48 PM ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
CREATE FULLTEXT INDEX ON [dbo].[IncomeAndExpenseVouchers](
[VoucherName] LANGUAGE 'Arabic')
KEY INDEX [PK_IncomeAndExpenseVouchers]ON ([ft_MoneyMindManager], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM)

GO
/****** Object:  FullTextIndex     Script Date: 13/11/2025 7:33:48 PM ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
CREATE FULLTEXT INDEX ON [dbo].[MainTransactions](
[Purpose] LANGUAGE 'Arabic')
KEY INDEX [PK_AllTransactions]ON ([ft_MoneyMindManager], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM)

GO
/****** Object:  FullTextIndex     Script Date: 13/11/2025 7:33:48 PM ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[People]'))
CREATE FULLTEXT INDEX ON [dbo].[People](
[PersonName] LANGUAGE 'Arabic')
KEY INDEX [PK_People]ON ([ft_MoneyMindManager], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = OFF)

GO
/****** Object:  FullTextIndex     Script Date: 13/11/2025 7:33:48 PM ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[Users]'))
CREATE FULLTEXT INDEX ON [dbo].[Users](
[UserName] LANGUAGE 'Arabic')
KEY INDEX [PK_Users]ON ([ft_MoneyMindManager], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = OFF)

GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Accounts_CreatedDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Accounts_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsActive]  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Accounts_Balance]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_Balance]  DEFAULT ((0)) FOR [Balance]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Debts_IsLocked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Debts] ADD  CONSTRAINT [DF_Debts_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_IncomeAndExpenseCategories_CreatedDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ADD  CONSTRAINT [DF_IncomeAndExpenseCategories_CreatedDate]  DEFAULT (sysdatetime()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_IncomeAndExpenseCategories_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ADD  CONSTRAINT [DF_IncomeAndExpenseCategories_IsActive]  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_IncomeAndExpenseVouchers_IsReturn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ADD  CONSTRAINT [DF_IncomeAndExpenseVouchers_IsReturn]  DEFAULT ((0)) FOR [IsReturn]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_IncomeAndExpenseVouchers_VoucherValue]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ADD  CONSTRAINT [DF_IncomeAndExpenseVouchers_VoucherValue]  DEFAULT ((0)) FOR [VoucherValue]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_AllTransactions_CreatedDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainTransactions] ADD  CONSTRAINT [DF_AllTransactions_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_MainTransactions_IsLocked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[MainTransactions] ADD  CONSTRAINT [DF_MainTransactions_IsLocked]  DEFAULT ((1)) FOR [IsLocked]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_People_CreatedDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[People] ADD  CONSTRAINT [DF_People_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_IsDeleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Currencies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Currencies] FOREIGN KEY([DefaultCurrencyID])
REFERENCES [dbo].[Currencies] ([CurrencyID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Currencies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Currencies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DebtPayments_Debts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DebtPayments]'))
ALTER TABLE [dbo].[DebtPayments]  WITH CHECK ADD  CONSTRAINT [FK_DebtPayments_Debts] FOREIGN KEY([DebtID])
REFERENCES [dbo].[Debts] ([DebtID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DebtPayments_Debts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DebtPayments]'))
ALTER TABLE [dbo].[DebtPayments] CHECK CONSTRAINT [FK_DebtPayments_Debts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DebtTransactions_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[DebtPayments]'))
ALTER TABLE [dbo].[DebtPayments]  WITH CHECK ADD  CONSTRAINT [FK_DebtTransactions_AllTransactions] FOREIGN KEY([MainTransactionID])
REFERENCES [dbo].[MainTransactions] ([TransactionID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DebtTransactions_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[DebtPayments]'))
ALTER TABLE [dbo].[DebtPayments] CHECK CONSTRAINT [FK_DebtTransactions_AllTransactions]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD  CONSTRAINT [FK_Debts_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts] CHECK CONSTRAINT [FK_Debts_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD  CONSTRAINT [FK_Debts_AllTransactions] FOREIGN KEY([DebtTransactionID])
REFERENCES [dbo].[MainTransactions] ([TransactionID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts] CHECK CONSTRAINT [FK_Debts_AllTransactions]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_FinancialAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD  CONSTRAINT [FK_Debts_FinancialAccounts] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_FinancialAccounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts] CHECK CONSTRAINT [FK_Debts_FinancialAccounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD  CONSTRAINT [FK_Debts_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Debts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts] CHECK CONSTRAINT [FK_Debts_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Categories_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Categories_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories] CHECK CONSTRAINT [FK_Categories_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Categories_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Categories_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories] CHECK CONSTRAINT [FK_Categories_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories] FOREIGN KEY([ParentCategoryID])
REFERENCES [dbo].[IncomeAndExpenseCategories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories] CHECK CONSTRAINT [FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories1]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories1] FOREIGN KEY([MainCategoryID])
REFERENCES [dbo].[IncomeAndExpenseCategories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories1]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseCategories]'))
ALTER TABLE [dbo].[IncomeAndExpenseCategories] CHECK CONSTRAINT [FK_IncomeAndExpenseCategories_IncomeAndExpenseCategories1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseTransactions_AllTransactions] FOREIGN KEY([MainTransactionID])
REFERENCES [dbo].[MainTransactions] ([TransactionID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_AllTransactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] CHECK CONSTRAINT [FK_IncomeAndExpenseTransactions_AllTransactions]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_IncomeAndExpenseCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseTransactions_IncomeAndExpenseCategories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[IncomeAndExpenseCategories] ([CategoryID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_IncomeAndExpenseCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] CHECK CONSTRAINT [FK_IncomeAndExpenseTransactions_IncomeAndExpenseCategories]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_IncomeAndExpenseVouchers]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseTransactions_IncomeAndExpenseVouchers] FOREIGN KEY([VoucherID])
REFERENCES [dbo].[IncomeAndExpenseVouchers] ([VoucherID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseTransactions_IncomeAndExpenseVouchers]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseTransactions]'))
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] CHECK CONSTRAINT [FK_IncomeAndExpenseTransactions_IncomeAndExpenseVouchers]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseVouchers_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseVouchers_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseVouchers_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] CHECK CONSTRAINT [FK_IncomeAndExpenseVouchers_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseVouchers_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers]  WITH CHECK ADD  CONSTRAINT [FK_IncomeAndExpenseVouchers_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_IncomeAndExpenseVouchers_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] CHECK CONSTRAINT [FK_IncomeAndExpenseVouchers_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions]  WITH CHECK ADD  CONSTRAINT [FK_AllTransactions_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions] CHECK CONSTRAINT [FK_AllTransactions_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_TransactionTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions]  WITH CHECK ADD  CONSTRAINT [FK_AllTransactions_TransactionTypes] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionTypes] ([TransactionTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_TransactionTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions] CHECK CONSTRAINT [FK_AllTransactions_TransactionTypes]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions]  WITH CHECK ADD  CONSTRAINT [FK_AllTransactions_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AllTransactions_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[MainTransactions]'))
ALTER TABLE [dbo].[MainTransactions] CHECK CONSTRAINT [FK_AllTransactions_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_People_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[People]'))
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_People_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[People]'))
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_People_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[People]'))
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_People_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[People]'))
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Accounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_People]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_People] FOREIGN KEY([PersonID])
REFERENCES [dbo].[People] ([PersonID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_People]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_People]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Users] FOREIGN KEY([CreatedByUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [CK_Accounts] CHECK  (([Balance]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Accounts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Accounts]'))
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [CK_Accounts]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Debts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts]  WITH CHECK ADD  CONSTRAINT [CK_Debts] CHECK  (([RemainingAmount]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_Debts]') AND parent_object_id = OBJECT_ID(N'[dbo].[Debts]'))
ALTER TABLE [dbo].[Debts] CHECK CONSTRAINT [CK_Debts]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_IncomeAndExpenseVouchers]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers]  WITH CHECK ADD  CONSTRAINT [CK_IncomeAndExpenseVouchers] CHECK  (([VoucherValue]>=(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_IncomeAndExpenseVouchers]') AND parent_object_id = OBJECT_ID(N'[dbo].[IncomeAndExpenseVouchers]'))
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] CHECK CONSTRAINT [CK_IncomeAndExpenseVouchers]
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_AddNew] AS' 
END
GO
 
 ALTER PROCEDURE [dbo].[SP_Account_AddNew]
	@AccountName NVARCHAR(150),
	@DefaultCurrencyID TINYINT,
	@Description NVARCHAR(200),
	@NewAccountID SMALLINT OUTPUT
AS
BEGIN
	BEGIN TRY
		INSERT INTO Accounts(AccountName,CreatedDate,IsActive,DefaultCurrencyID,Description,Balance)
		VALUES(@AccountName,SYSDATETIME(),1,@DefaultCurrencyID,@Description,0);

		SET @NewAccountID = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_Create]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_Create]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_Create] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Account_Create]
	@AccountName NVARCHAR(150),
	@DefaultCurrencyID TINYINT,
	@Description NVARCHAR(200),
	@PersonName NVARCHAR(150),
	@Address NVARCHAR(300) NULL,
	@Email NVARCHAR(255) NULL,
	@Phone NVARCHAR(20) NULL,
	@Notes NVARCHAR(200) NULL ,
	@UserName NVARCHAR(30),
	@Password VARCHAR(64),
	@Salt VARCHAR(24),
	@NewAccountID SMALLINT OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			--AddNewAccount
			EXEC SP_Account_AddNew
				@AccountName = @AccountName,
				@DefaultCurrencyID = @DefaultCurrencyID,
				@Description = @Description,
				@NewAccountID = @NewAccountID OUTPUT;

			-- add new person
			DECLARE @NewPersonID INT;

			INSERT INTO People(PersonName,Address,Email,Phone,AccountID,Notes,CreatedByUserID,CreatedDate)
			VALUES(@PersonName,@Address,@Email,@Phone,@NewAccountID,@Notes,NULL,SYSDATETIME());

			SET @NewPersonID = SCOPE_IDENTITY();

			-- add new User
			DECLARE @NewUserID INT;

			INSERT INTO Users(UserName,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted,CreatedByUserID,CreatedDate)
			VALUES (@UserName,@NewPersonID,-1,@Password,@Salt,1,@Notes,@NewAccountID,0,NULL,SYSDATETIME());

			SET @NewUserID = SCOPE_IDENTITY();

	COMMIT
		END TRY
		BEGIN CATCH
			ROLLBACK;
			EXEC SP_LogError;
			THROW;
		END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_DeleteByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_DeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_DeleteByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_Account_DeleteByID]
	@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
		BEGIN 
			DECLARE @ErrorMessage NVARCHAR(100) = N'الحساب الذي يحمل معرف  [' + CAST(@AccountID AS NVARCHAR(10)) + N'] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		BEGIN TRANSACTION
			UPDATE Accounts 
			SET IsActive = 0
			WHERE AccountID = @AccountID;

			DELETE DebtPayments 
			FROM DebtPayments dp INNER JOIN Debts d ON dp.DebtID = d.DebtID
			WHERE d.AccountID = @AccountID;

			DELETE FROM Debts WHERE AccountID = @AccountID;

			DELETE IncomeAndExpenseTransactions
			FROM IncomeAndExpenseTransactions t INNER JOIN IncomeAndExpenseVouchers v ON t.VoucherID = v.VoucherID
			WHERE v.AccountID = @AccountID;

			DELETE FROM IncomeAndExpenseCategories WHERE AccountID = @AccountID;

			DELETE FROM IncomeAndExpenseVouchers WHERE AccountID = @AccountID;

			DELETE FROM MainTransactions WHERE AccountID = @AccountID;

			UPDATE People SET CreatedByUserID = NULL WHERE AccountID = @AccountID;

			DELETE FROM Users WHERE AccountID = @AccountID;

			DELETE FROM People WHERE AccountID = @AccountID;

			DELETE FROM Accounts WHERE AccountID = @AccountID;
		COMMIT;
			
	END TRY
	BEGIN CATCH
		ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_GetByAccountID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_GetByAccountID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_GetByAccountID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Account_GetByAccountID]
	@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
		BEGIN 
			DECLARE @ErrorMessage NVARCHAR(100) = N'الحساب الذي يحمل معرف  [' + CAST(@AccountID AS NVARCHAR(10)) + N'] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN
			SET @ErrorMessage = 'المستخدم الذي أنشاء الحساب غير موجود';
			THROW 51020,@ErrorMessage,5;
		END

		SELECT Accounts.AccountID,AccountName,CreatedDate,IsActive,DefaultCurrencyID,Description,Balance,@AccountOwnerUserID AS AccountOwnerUserID
		FROM Accounts WHERE Accounts.AccountID = @AccountID;
			
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_IsExistByAccountName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_IsExistByAccountName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_IsExistByAccountName] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Account_IsExistByAccountName]
	@AccountName NVARCHAR(150)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM Accounts WHERE AccountName = @AccountName)
			RETURN 1;
		ELSE
			RETURN 0;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Account_UpdateByUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Account_UpdateByUserID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Account_UpdateByUserID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Account_UpdateByUserID]
	@AccountName NVARCHAR(150),
	@IsActive BIT,
	@Description NVARCHAR(200),
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		UPDATE Accounts
		SET AccountName = @AccountName,
			IsActive = @IsActive,
			Description = @Description
		WHERE AccountID = @AccountID;

		IF @@ROWCOUNT = 0
			THROW 51018,N'فشل تحديث الحساب',4;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Currencies_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Currencies_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Currencies_GetAll] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Currencies_GetAll]
AS
BEGIN
	BEGIN TRY
		SELECT CurrencyID,CurrencyName,CurrencySymbol FROM Currencies;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Currency_GetByCurrencyID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Currency_GetByCurrencyID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Currency_GetByCurrencyID] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_Currency_GetByCurrencyID]
	@CurrencyID TINYINT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM Currencies WHERE CurrencyID = @CurrencyID)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'العملة التي تحمل معرف [' + CAST(@CurrencyID AS NVARCHAR(5)) + N'] غير موجودة';
			THROW 51015,@ErrorMessage,3;
		END;

		SELECT CurrencyName,CurrencySymbol FROM Currencies WHERE CurrencyID = @CurrencyID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Currency_GetByCurrencyName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Currency_GetByCurrencyName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Currency_GetByCurrencyName] AS' 
END
GO
ALTER PROCEDURE [dbo].[SP_Currency_GetByCurrencyName]
	@CurrencyName NVARCHAR(50)
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM Currencies WHERE CurrencyName = @CurrencyName)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'العملة التي تحمل اسم [' + @CurrencyName + N'] غير موجودة';
			THROW 51016,@ErrorMessage,3;
		END;

		SELECT CurrencyID,CurrencySymbol FROM Currencies WHERE CurrencyName = @CurrencyName;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_AddNew] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_DebtPayment_AddNew]
	@DebtID INT,
	@Amount decimal(19, 4),
	@PaymentDate DATE ,
	@Purpose NVARCHAR(150) NULL,
	@CreatedByUserID INT,
	@NewTransactionID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @IsLocked BIT;
		DECLARE @IsLending BIT;
		SELECT @IsLending = IsLending, @IsLocked = IsLocked FROM Debts WHERE DebtID = @DebtID;

		IF (@IsLocked IS NULL)
			BEGIN 
				set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CreatedByUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

			-- سداد الإقتراض - منصرف
		IF (@IsLending = 0)
			SET @Amount = -1 * @Amount;

		DECLARE @TransactionTypeID TINYINT = 3; -- debts

	BEGIN TRANSACTION
		EXEC SP_MainTransactions_AddNew
			@Amount = @Amount,
			@AccountID = @AccountID,
			@CreatedByUserID = @CreatedByUserID,
			@TransactionTypeID = @TransactionTypeID,
			@Purpose = @Purpose,
			@IsLocked = @IsLocked,
			@TransactionDate = @PaymentDate,
			@NewTransactionID = @NewTransactionID OUTPUT;

		INSERT INTO DebtPayments(MainTransactionID,DebtID,IsLending)
			VALUES(@NewTransactionID,@DebtID,@IsLending);

	COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_DeleteByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_DeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_DeleteByID] AS' 
END
GO



ALTER   PROCEDURE [dbo].[SP_DebtPayment_DeleteByID]
	@TransactionID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @ReturnValue INT;

		EXEC @ReturnValue = SP_MainTransaction_CheckBalanceBeforeDelete
			@TransactionID  = @TransactionID,
			@CurrentUserID = @CurrentUserID;

		IF @ReturnValue <> 1
			RETURN 0;

		DELETE FROM DebtPayments WHERE MainTransactionID = @TransactionID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف معاملة السداد التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
	EXEC SP_LogError;
	THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_GetAllForDebt]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_GetAllForDebt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_GetAllForDebt] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_DebtPayment_GetAllForDebt]
	@DebtID INT,
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@RemainingAmount DECIMAL(19,4) OUTPUT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT
AS
BEGIN
	BEGIN TRY

		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM Debts WHERE DebtID = @DebtID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		SELECT dp.MainTransactionID,ABS(Mt.Amount)  AS Amount,MT.TransactionDate AS DebtDate, MT.CreatedDate ,u.UserName AS CreatedByUserName ,MT.Purpose
		FROM DebtPayments dp INNER JOIN MainTransactions MT ON dp.MainTransactionID = MT.TransactionID
		INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
		WHERE dp.DebtID = @DebtID
		ORDER BY dp.MainTransactionID ASC
		OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
		FETCH NEXT @RowsPerPage ROWS ONLY;

		SELECT @RecordsCount = COUNT(*) FROM DebtPayments WHERE DebtID = @DebtID;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS decimal(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));
		SELECT @RemainingAmount = RemainingAmount FROM Debts where DebtID = @DebtID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_GetAllForDebtWihtoutPaging]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_GetAllForDebtWihtoutPaging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_GetAllForDebtWihtoutPaging] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_DebtPayment_GetAllForDebtWihtoutPaging]
	@DebtID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM Debts WHERE DebtID = @DebtID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		SELECT dp.MainTransactionID,ABS(Mt.Amount)  AS Amount,MT.TransactionDate AS DebtDate, MT.CreatedDate ,MT.Purpose,
		Mt.CreatedByUserID,u.UserName AS CreatedByUserName,mt.AccountID
		FROM DebtPayments dp INNER JOIN MainTransactions MT ON dp.MainTransactionID = MT.TransactionID
		INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
		WHERE dp.DebtID = @DebtID
		ORDER BY dp.MainTransactionID ASC

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_GetByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_DebtPayment_GetByID] 
	@TransactionID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @AccountID SMALLINT;

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM DebtPayments WHERE MainTransactionID = @TransactionID)
		BEGIN 
			SET @ErrorMessage = N'المعامة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		SELECT MainTransactionID,DebtID FROM DebtPayments WHERE MainTransactionID = @TransactionID;
		
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DebtPayment_UpdateByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_DebtPayment_UpdateByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_DebtPayment_UpdateByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_DebtPayment_UpdateByID]
	@TransactionID INT,
	@Amount decimal(19, 4),
	@Purpose NVARCHAR(150) NULL,
	@PaymentDate DATE,
	@CurrentUserID INT
AS
BEGIN		
	BEGIN TRY
		
		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;
		
		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @DebtID INT;

		SELECT @DebtID = DebtID FROM DebtPayments WHERE MainTransactionID = @TransactionID;

		IF (@DebtID IS NULL)
		BEGIN
			set @ErrorMessage = N'المعاملة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51030,@ErrorMessage,4;
		END;

		DECLARE @IsLending BIT;
		SELECT @IsLending = IsLending FROM Debts WHERE DebtID = @DebtID;

		IF (@IsLending IS NULL)
			BEGIN 
				set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

			-- سداد الإقتراض - منصرف
		IF (@IsLending = 0)
			SET @Amount = -1 * @Amount;

			DECLARE @ReturnValue INT;

			EXEC @ReturnValue = [dbo].[SP_MainTransactions_UpdateByID]
								@TransactionID = @TransactionID,
								@Amount = @Amount,
								@Purpose = @Purpose,
								@CurrentUserID = @CurrentUserID,
								@TransactionDate = @PaymentDate,
								@LogErrors = 0;

			IF @ReturnValue <> 1
			BEGIN
				SET @ErrorMessage = N'فشل تحديث بيانات المعامة التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51024,@ErrorMessage,2;
			END;

			RETURN 1;
		END TRY
		BEGIN CATCH
			EXEC SP_LogError;
			THROW;
		END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_AddNew] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_Debts_AddNew] 
	@IsLending BIT,
	@PersonID INT,
	@PaymentDueDate Date NULL,
	@Amount decimal(19, 4),
	@Purpose NVARCHAR(150) NULL,
	@IsLocked bit,
	@DebtDate DATE,
	@CreatedByUserID INT,
	@NewDebtID INT OUTPUT,
	@NewTransactionID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

			-- إقراض - منصرف - سالب
		IF (@IsLending = 1)
			SET @Amount = -1 * @Amount;

		--IF ((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + @Amount < 0)
		--		THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;

		DECLARE @TransactionTypeID TINYINT = 3; -- debts

		BEGIN TRANSACTION

			EXEC SP_MainTransactions_AddNew
				@Amount = @Amount,
				@AccountID = @AccountID,
				@CreatedByUserID = @CreatedByUserID,
				@TransactionTypeID = @TransactionTypeID,
				@Purpose = @Purpose,
				@IsLocked = @IsLocked,
				@TransactionDate = @DebtDate,
				@NewTransactionID = @NewTransactionID OUTPUT;

			INSERT INTO Debts(IsLending,PersonID,PaymentDueDate,DebtTransactionID,AccountID,CreatedByUserID,IsLocked,RemainingAmount)
			VALUES (@IsLending,@PersonID,@PaymentDueDate,@NewTransactionID,@AccountID,@CreatedByUserID,@IsLocked,ABS(@Amount));

			SELECT @NewDebtID = SCOPE_IDENTITY();

			--EXEC SP_Debts_ReCalculateRemainingAmountForDebt
			--	@DebtID = @NewDebtID;

		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_ChangeLocking]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_ChangeLocking]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_ChangeLocking] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_Debts_ChangeLocking] 
	@DebtID INT,
	@IsLocked bit,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM Debts WHERE DebtID = @DebtID AND AccountID = @AccountID)
			BEGIN 
				set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		UPDATE Debts
		SET IsLocked = @IsLocked
		WHERE DebtID = @DebtID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل تحديث بيانات سند الدين الذي يحمل معرف  [ ' + CAST(@DebtID AS NVARCHAR(10)) +N' ] .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_DeleteByDebtID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_DeleteByDebtID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_DeleteByDebtID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Debts_DeleteByDebtID] 
	@DebtID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @TransactionID INT;

		SELECT @TransactionID = DebtTransactionID FROM Debts WHERE DebtID = @DebtID;

		IF (@TransactionID IS NULL)
			BEGIN 
				set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		DECLARE @ReturnValue INT;

		EXEC @ReturnValue = SP_MainTransaction_CheckBalanceBeforeDelete
			@TransactionID  = @TransactionID,
			@CurrentUserID = @CurrentUserID;

		IF @ReturnValue <> 1 RETURN 0;

		DELETE FROM Debts WHERE DebtID = @DebtID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف سند الدين الذي يحمل معرف  [ ' + CAST(@DebtID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		--EXEC SP_Debts_ReCalculateRemainingAmountForDebt
		--		@DebtID = @DebtID;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_GetAll] AS' 
END
GO
ALTER    PROCEDURE [dbo].[SP_Debts_GetAll]
	@DebtID INT NULL,
	@IsLending BIT NULL,
	@PersonName NVARCHAR(150) NULL,
	@UserName NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromDebtDate DATE NULL,
	@ToDebtDate DATE NULL,
	@IsPaid BIT NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT,
	@TotalDebtsValue DECIMAL(19,4) OUTPUT,
	@CurrentPageDebtsValue DECIMAL(19,4) OUTPUT,
	@TotalRemainingAmount DECIMAL(19,4) OUTPUT,
	@CurrentPageRemainingAmount DECIMAL(19,4) OUTPUT
AS
BEGIN
	BEGIN TRY

		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		DECLARE @FormatedPersonName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @PersonName IS NOT NULL
		BEGIN
			SET @FormatedPersonName = '"' +REPLACE(TRIM(@PersonName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToDebtDate = DATEADD(DAY,1,@ToDebtDate);


		DECLARE @TableOfCurrentPageResult TABLE (
			DebtID INT,
			PersonName NVARCHAR(150),
			CreatedByUserName NVARCHAR(30),
			DebtValue DECIMAL(19,4),
			RemainingAmount DECIMAL(19,4),
			DebtDate DATETIME2(0),
			CreatedDate DATETIME2(0),
			DebtType NVARCHAR(20), -- إقراض ام إقتراض
			TotalDebtsValue DECIMAL(19,4) NULL,
			TotalRemainingAmount DECIMAL(19,4) NULL,
			RecordsCount INT
		);

		WITH AllDebts AS
		(
			SELECT d.DebtID,p.PersonName,d.IsLending,ABS(mt.Amount) AS Amount,d.RemainingAmount,mt.TransactionDate AS DebtData, mt.CreatedDate,u.UserName AS CreatedByUserName
			FROM Debts d INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID INNER JOIN People p ON d.PersonID = p.PersonID
			INNER JOIN Users u ON d.CreatedByUserID = u.UserID
			WHERE d.AccountID = @AccountID AND (@DebtID IS NULL OR d.DebtID = @DebtID)
				AND (@IsLending IS NULL OR d.IsLending = @IsLending)
				AND (@UserName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
					OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
				AND (@PersonName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(p.PersonName,@FormatedPersonName))
					OR (@TextSearchMode = 2 AND p.PersonName LIKE CONCAT('%' ,@PersonName,'%')))
				AND (@FromDebtDate IS NULL OR mt.TransactionDate >= @FromDebtDate) AND (@ToDebtDate IS NULL OR mt.TransactionDate < @ToDebtDate)
				AND (@FromCreatedDate IS NULL OR mt.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR mt.CreatedDate < @ToCreatedDate)
				AND (@IsPaid IS NULL OR (@IsPaid = 1 AND d.RemainingAmount = 0) OR (@IsPaid = 0 AND d.RemainingAmount > 0))
		),
		State AS
		(
		 SELECT SUM(Amount) AS AllDebtsValue,SUM(RemainingAmount) AS TotalRemainingAmount,COUNT(DebtID) AS RecordsCount  FROM AllDebts
		),
		PagingResult AS
		(
			SELECT * FROM AllDebts
			ORDER BY DebtData DESC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)
		
		INSERT INTO @TableOfCurrentPageResult(DebtID,PersonName,CreatedByUserName,DebtValue,RemainingAmount,DebtDate,
		CreatedDate,DebtType,TotalDebtsValue,TotalRemainingAmount,RecordsCount)
		SELECT	pr.DebtID,pr.PersonName,CreatedByUserName,pr.Amount,pr.RemainingAmount,pr.DebtData,pr.CreatedDate,
		CASE WHEN (pr.IsLending = 1 ) THEN 'إقراض' ELSE 'إقتراض' END,s.AllDebtsValue,s.TotalRemainingAmount,s.RecordsCount
		FROM PagingResult pr  CROSS JOIN State s
		OPTION(RECOMPILE);

		SELECT r.DebtID,r.PersonName,r.DebtValue,r.RemainingAmount,r.DebtDate,r.CreatedDate,r.DebtType,r.CreatedByUserName FROM @TableOfCurrentPageResult r;

		SELECT @CurrentPageDebtsValue = ISNULL(SUM(DebtValue),0) FROM @TableOfCurrentPageResult
		SELECT @CurrentPageRemainingAmount = ISNULL(SUM(RemainingAmount),0) FROM @TableOfCurrentPageResult
		SELECT TOP 1 @RecordsCount = r.RecordsCount ,@TotalDebtsValue = ISNULL(r.TotalDebtsValue,0),@TotalRemainingAmount = ISNULL(r.TotalRemainingAmount,0)
		FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @NumberOfPages = ISNULL(@NumberOfPages,0);
		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @CurrentPageDebtsValue = ISNULL(@CurrentPageDebtsValue,0);
		SET @TotalDebtsValue = ISNULL(@TotalDebtsValue,0);
		SET @CurrentPageRemainingAmount = ISNULL(@CurrentPageRemainingAmount,0);
		SET @TotalRemainingAmount = ISNULL(@TotalRemainingAmount,0);
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_GetAllWithoutPaging]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_GetAllWithoutPaging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_GetAllWithoutPaging] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_Debts_GetAllWithoutPaging]
	@DebtID INT NULL,
	@IsLending BIT NULL,
	@PersonName NVARCHAR(150) NULL,
	@UserName NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromDebtDate DATE NULL,
	@ToDebtDate DATE NULL,
	@IsPaid BIT NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		DECLARE @FormatedPersonName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @PersonName IS NOT NULL
		BEGIN
			SET @FormatedPersonName = '"' +REPLACE(TRIM(@PersonName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToDebtDate = DATEADD(DAY,1,@ToDebtDate);

		WITH AllDebts AS
		(
			SELECT d.DebtID,p.PersonID,p.PersonName,d.IsLending,mt.Amount AS Amount,d.RemainingAmount,
			mt.TransactionDate AS DebtDate, mt.CreatedDate,d.AccountID,d.CreatedByUserID,u.UserName AS CreatedByUserName
			FROM Debts d INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID INNER JOIN People p ON d.PersonID = p.PersonID 
			INNER JOIN Users u ON d.CreatedByUserID = u.UserID 
			WHERE d.AccountID = @AccountID AND (@DebtID IS NULL OR d.DebtID = @DebtID)
				AND (@IsLending IS NULL OR d.IsLending = @IsLending)
				AND (@UserName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
					OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
				AND (@PersonName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(p.PersonName,@FormatedPersonName))
					OR (@TextSearchMode = 2 AND p.PersonName LIKE CONCAT('%' ,@PersonName,'%')))
				AND (@FromDebtDate IS NULL OR mt.TransactionDate >= @FromDebtDate) AND (@ToDebtDate IS NULL OR mt.TransactionDate < @ToDebtDate)
				AND (@FromCreatedDate IS NULL OR mt.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR mt.CreatedDate < @ToCreatedDate)
				AND (@IsPaid IS NULL OR (@IsPaid = 1 AND d.RemainingAmount = 0) OR (@IsPaid = 0 AND d.RemainingAmount > 0))
		)
		
		SELECT	ad.DebtID,ad.PersonID,ad.PersonName,ABS(ad.Amount) AS DebtValue,ad.RemainingAmount,ad.DebtDate,
		ad.CreatedDate,ad.AccountID,ad.CreatedByUserID,ad.CreatedByUserName,
		CASE WHEN (ad.IsLending = 1 ) THEN 'إقراض' ELSE 'إقتراض' END AS DebtType
		FROM AllDebts ad 
		ORDER BY DebtDate DESC
		OPTION(RECOMPILE);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_GetByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_Debts_GetByID] 
	@DebtID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM Debts WHERE DebtID = @DebtID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		SELECT DebtID,IsLending,PersonID,PaymentDueDate,DebtTransactionID,AccountID,CreatedByUserID,IsLocked,RemainingAmount
		FROM Debts WHERE DebtID = @DebtID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_ReCalculateRemainingAmountForDebt]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_ReCalculateRemainingAmountForDebt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_ReCalculateRemainingAmountForDebt] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Debts_ReCalculateRemainingAmountForDebt]
	@DebtID INT
AS
BEGIN
	BEGIN TRY

		UPDATE Debts
		SET RemainingAmount = ABS(dbo.GetDebtRemainingAmount(@DebtID))
		WHERE DebtID = @DebtID;

		IF @@ROWCOUNT = 0
		BEGIN
			DECLARE @CurrentAccountErrorMessage NVARCHAR(150) = N'فشل تحديث القيمة المتبقية للسداد للدين صاحب رقم [' + CAST(@DebtID AS NVARCHAR(10)) + N']';
			THROW 51012,@CurrentAccountErrorMessage,4;
		END

	END TRY
	BEGIN CATCH
		--EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Debts_UpdateByDebtID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Debts_UpdateByDebtID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Debts_UpdateByDebtID] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_Debts_UpdateByDebtID] 
	@DebtID INT,
	@PaymentDueDate Date NULL,
	@Amount decimal(19, 4),
	@Purpose NVARCHAR(150) NULL,
	@DebtDate DATE,
	@CurrentUserID INT,
	@RemainingAmount DECIMAL(19,4) OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
				@UserID = @CurrentUserID,
				@AccountID = @AccountID OUTPUT;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

		DECLARE @DebtTransactionID INT;
		DECLARE @IsLending BIT;

		SELECT @DebtTransactionID = DebtTransactionID,@IsLending = IsLending FROM Debts WHERE DebtID = @DebtID AND AccountID = @AccountID;

		IF (@DebtTransactionID IS NULL)
			BEGIN 
				set @ErrorMessage = N'سند الدين الذي يحمل معرف  [' + CAST(@DebtID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;
		
			-- إقراض - منصرف - سالب
		IF (@IsLending = 1)
			SET @Amount = -1 * @Amount;


		DECLARE @ReturnValue INT;

		BEGIN TRANSACTiON

			EXEC @ReturnValue = [dbo].[SP_MainTransactions_UpdateByID]
								@TransactionID = @DebtTransactionID,
								@Amount = @Amount,
								@Purpose = @Purpose,
								@CurrentUserID = @CurrentUserID,
								@TransactionDate = @DebtDate,
								@LogErrors = 0;
		
			UPDATE Debts
			SET PaymentDueDate = @PaymentDueDate
			WHERE DebtID = @DebtID;

			IF (@@ROWCOUNT = 0) OR (@ReturnValue <> 1)
			BEGIN
				SET @ErrorMessage = N'فشل تحديث بيانات سند الدين الذي يحمل معرف  [ ' + CAST(@DebtID AS NVARCHAR(10)) +N' ] .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51024,@ErrorMessage,2;
			END;

			--EXEC [dbo].[SP_Debts_ReCalculateRemainingAmountForDebt]
			--	@DebtID = @DebtID;

			SELECT @RemainingAmount = RemainingAmount FROM Debts WHERE DebtID = @DebtID;

		COMMIT
			RETURN 1;

	END TRY
	BEGIN CATCH
	ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Global_DatabaseRoutineMaintenance]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Global_DatabaseRoutineMaintenance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Global_DatabaseRoutineMaintenance] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Global_DatabaseRoutineMaintenance]
AS
BEGIN
	BEGIN TRY
		DECLARE @LastMaintenanceDate DATE; 
		SELECT @LastMaintenanceDate = TRY_CAST(SettingValue AS DATE) FROM SystemSettings WHERE SettingKey = 'LastMaintenanceDate';

		IF @LastMaintenanceDate IS NULL
		BEGIN
			UPDATE SystemSettings
			SET SettingValue = CONVERT(varchar, GETDATE(),23)
			WHERE SettingKey = 'LastMaintenanceDate';

			RETURN;
		END;

		DECLARE @CutOfDate DATE = DATEADD(MONTH,-6,GETDATE());

		IF (@LastMaintenanceDate < @CutOfDate)
		BEGIN
			DECLARE @BatchSize SMALLINT = 5000;	
			DECLARE @RowsDeleted SMALLINT = 1;	

			WHILE @RowsDeleted > 0
			BEGIN
				
				DELETE TOP (@BatchSize)
				FROM ErrorLogs WHERE ErrorDate < @CutOfDate;

				SET @RowsDeleted = @@ROWCOUNT;

				IF @RowsDeleted > 0
				BEGIN
				    WAITFOR DELAY '00:00:01';
				END;
			END;

			ALTER FULLTEXT CATALOG [ft_MoneyMindManager]  REORGANIZE;

			UPDATE SystemSettings
			SET SettingValue = CONVERT(varchar, GETDATE(),23)
			WHERE SettingKey = 'LastMaintenanceDate';
		END;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_AddNew] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_AddNew] 
	@CategoryName NVARCHAR(200),
	@MonthlyBudget decimal(19, 4) NULL,
	@IsIncome BIT,
	@ParentCategoryID INT NULL,
	@CreatedByUserID INT,
	@IsActive BIT,
	@Notes NVARCHAR(250),
	@NewCategoryID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @MainCategoryID INT = NULL;
		SELECT @MainCategoryID = ISNULL(MainCategoryID,CategoryID) FROM IncomeAndExpenseCategories WHERE CategoryID = @ParentCategoryID

		BEGIN TRANSACTiON

			INSERT INTO IncomeAndExpenseCategories(CategoryName,CreatedDate,MonthlyBudget,IsIncome,ParentCategoryID,AccountID,CreatedByUserID,IsActive,Notes,MainCategoryID)
				VALUES(@CategoryName,SYSDATETIME(),@MonthlyBudget,@IsIncome,@ParentCategoryID,@AccountID,@CreatedByUserID,@IsActive,@Notes,@MainCategoryID);

			SELECT @NewCategoryID = SCOPE_IDENTITY();

			IF @MainCategoryID IS NULL
			BEGIN
				UPDATE IncomeAndExpenseCategories
				SET MainCategoryID = @NewCategoryID
				WHERE CategoryID = @NewCategoryID
			END
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_DeleteByCategoryID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_DeleteByCategoryID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_DeleteByCategoryID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_DeleteByCategoryID] 
	@CategoryID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		
		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID)
			BEGIN 
				set @ErrorMessage = N'الفئة التي تحمل معرف  [' + CAST(@CategoryID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		DELETE FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف الفئة التي تحمل معرف  [ ' + CAST(@CategoryID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetAll] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetAll] 
	@CategoryID INT NULL,
	@CategoryName NVARCHAR(200) NULL,
	@ParentCategoryName NVARCHAR(200) NULL,
	@MainCategoryName NVARCHAR(200) NULL,
	@IsIncome BIT NULL,
	@IsActive BIT NULL,
	@IncludeMainCategories BIT,
	@IncludeSubCategories BIT,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT
AS
BEGIN
	BEGIN TRY

		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedCategroyName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @CategoryName IS NOT NULL
		BEGIN
			SET @FormatedCategroyName = '"' +REPLACE(TRIM(@CategoryName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedParentCategroyName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @ParentCategoryName IS NOT NULL
		BEGIN
			SET @FormatedParentCategroyName = '"' +REPLACE(TRIM(@ParentCategoryName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedMainCategroyName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @MainCategoryName IS NOT NULL
		BEGIN
			SET @FormatedMainCategroyName = '"' +REPLACE(TRIM(@MainCategoryName),' ','*" AND "') + '*"';
		END;

		DECLARE @TableOfCurrentPageResult TABLE (
			CategoryID INT,
			IsActive BIT,
			CategoryName NVARCHAR(200),
			CreatedDate DATETIME2(0),
			ParentCategoryName NVARCHAR(200),
			MainCategoryName NVARCHAR(200),
			RecordsCount INT
		);

		WITH FilterdCategories AS
		(
			SELECT c.CategoryID,c.CategoryName,c.IsActive,c.CreatedDate,c.IsIncome,c.ParentCategoryID,
			pc.CategoryName AS ParentCategoryName, mc.CategoryName AS MainCategoryName
			FROM IncomeAndExpenseCategories c LEFT JOIN IncomeAndExpenseCategories pc ON c.ParentCategoryID = pc.CategoryID 
			LEFT JOIN IncomeAndExpenseCategories mc ON c.MainCategoryID = mc.CategoryID
			WHERE  c.AccountID = @AccountID AND (@CategoryID IS NULL OR c.CategoryID = @CategoryID)
				AND (@CategoryName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(c.CategoryName,@FormatedCategroyName))
					OR (@TextSearchMode = 2 AND c.CategoryName LIKE CONCAT('%',@CategoryName,'%')))
				AND (@ParentCategoryName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(pc.CategoryName,@FormatedParentCategroyName))
					OR (@TextSearchMode = 2 AND pc.CategoryName LIKE CONCAT('%',@ParentCategoryName,'%')))
				AND (@MainCategoryName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(mc.CategoryName,@FormatedMainCategroyName))
					OR (@TextSearchMode = 2 AND mc.CategoryName LIKE CONCAT('%',@MainCategoryName,'%')))
				AND (@IsIncome IS NULL OR c.IsIncome = @IsIncome) AND (@IsActive IS NULL OR c.IsActive = @IsActive)
				AND ((@IncludeMainCategories = 1 AND c.ParentCategoryID IS NULL) OR (@IncludeSubCategories = 1 AND c.ParentCategoryID IS NOT NULL))
		),
		State AS
		(
		 SELECT COUNT(CategoryID) AS RecordsCount  FROM FilterdCategories
		),
		PagingResult AS
		(
			SELECT * FROM FilterdCategories fc
			ORDER BY fc.CategoryID ASC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)
		INSERT INTO @TableOfCurrentPageResult(CategoryID,CategoryName,IsActive,CreatedDate,ParentCategoryName,MainCategoryName,RecordsCount)
		SELECT c.CategoryID,c.CategoryName,c.IsActive,c.CreatedDate,c.ParentCategoryName,c.MainCategoryName ,s.RecordsCount
		FROM PagingResult c CROSS JOIN State s
		OPTION(RECOMPILE);

		SELECT r.CategoryID,r.CategoryName,r.ParentCategoryName,ISNULL(r.MainCategoryName,r.CategoryName) AS MainCategoryName,r.CreatedDate,r.IsActive FROM @TableOfCurrentPageResult r;

		SELECT TOP 1 @RecordsCount = r.RecordsCount FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @NumberOfPages = ISNULL(@NumberOfPages,0);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END;
		
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_GetAllForSelectOne]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_GetAllForSelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetAllForSelectOne] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetAllForSelectOne] 
	@CategoryName NVARCHAR(200) NULL,
	@IsIncome BIT NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT
AS
BEGIN
	BEGIN TRY

		IF @RowsPerPage > 100
        BEGIN;
            THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
            RETURN;
        END;	

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedCategroyName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @CategoryName IS NOT NULL
		BEGIN
			SET @FormatedCategroyName = '"' +REPLACE(TRIM(@CategoryName),' ','*" AND "') + '*"';
		END;

		
		DECLARE @TableOfCurrentPageResult TABLE (
			CategoryID INT,
			CategoryName NVARCHAR(200),
			ParentCategoryName NVARCHAR(200),
			MainCategoryName NVARCHAR(200),
			RecordsCount INT
		);

		WITH FilterdCategories AS
		(
			SELECT c.CategoryID,c.CategoryName,pc.CategoryName AS ParentCategoryName, mc.CategoryName AS MainCategoryName
			FROM IncomeAndExpenseCategories c LEFT JOIN IncomeAndExpenseCategories pc ON c.ParentCategoryID = pc.CategoryID 
			LEFT JOIN IncomeAndExpenseCategories mc ON c.MainCategoryID = mc.CategoryID
			WHERE  c.AccountID = @AccountID  AND (c.IsActive = 1)
					AND (@CategoryName IS NULL
							OR (@TextSearchMode = 1 AND CONTAINS(c.CategoryName,@FormatedCategroyName))
							OR (@TextSearchMode = 2 AND c.CategoryName LIKE CONCAT('%',@CategoryName,'%')))
					AND (@IsIncome IS NULL OR c.IsIncome = @IsIncome)				
		),
		State AS
		(
		 SELECT COUNT(CategoryID) AS RecordsCount  FROM FilterdCategories
		),
		PagingResult AS
		(
			SELECT * FROM FilterdCategories fc
			ORDER BY fc.CategoryID ASC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)
		INSERT INTO @TableOfCurrentPageResult(CategoryID,CategoryName,ParentCategoryName,MainCategoryName,RecordsCount)
		SELECT c.CategoryID,c.CategoryName,c.ParentCategoryName,c.MainCategoryName,s.RecordsCount
		FROM PagingResult c CROSS JOIN State s;

		SELECT r.CategoryID,r.CategoryName,r.ParentCategoryName,ISNULL(r.MainCategoryName,r.CategoryName) AS MainCategoryName FROM @TableOfCurrentPageResult r;

		SELECT TOP 1 @RecordsCount = r.RecordsCount FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @NumberOfPages = ISNULL(@NumberOfPages,0);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetByCategoryName] 
	@CategoryName NVARCHAR(200),
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
				@UserID = @CurrentUserID,
				@AccountID = @AccountID OUTPUT;


		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseCategories WHERE CategoryName = @CategoryName AND AccountID = @AccountID)
			BEGIN 
				set @ErrorMessage = N'الفئة التي تحمل اسم  [ ' + @CategoryName + N' ] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		SELECT iet.CategoryID,iet.CategoryName,iet.CreatedDate,iet.MonthlyBudget,iet.IsIncome,iet.ParentCategoryID,iet.AccountID,
		iet.CreatedByUserID,iet.IsActive,iet.Notes,ISNULL(iet.MainCategoryID,iet.CategoryID) AS MainCategoryID,
		dbo.GetCategoryHierarchicalString (iet.CategoryID ) AS CategoryHierarchical,
		ISNULL(mc.CategoryName,iet.CategoryName) AS MainCategoryName,pc.CategoryName AS ParentCategoryName
		FROM IncomeAndExpenseCategories iet LEFT JOIN IncomeAndExpenseCategories pc ON iet.ParentCategoryID = pc.CategoryID 
		LEFT JOIN IncomeAndExpenseCategories mc ON iet.MainCategoryID = mc.CategoryID
		WHERE iet.CategoryName = @CategoryName  AND iet.AccountID = @AccountID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_GetByID] 
	@CategoryID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID AND AccountID = @AccountID)
			BEGIN 
				set @ErrorMessage = N'الفئة التي تحمل معرف  [' + CAST(@CategoryID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		SELECT iet.CategoryID,iet.CategoryName,iet.CreatedDate,iet.MonthlyBudget,iet.IsIncome,iet.ParentCategoryID,iet.AccountID,
		iet.CreatedByUserID,iet.IsActive,iet.Notes,ISNULL(iet.MainCategoryID,iet.CategoryID) AS MainCategoryID,
		dbo.GetCategoryHierarchicalString (iet.CategoryID ) AS CategoryHierarchical,
		ISNULL(mc.CategoryName,iet.CategoryName) AS MainCategoryName,pc.CategoryName AS ParentCategoryName
		FROM IncomeAndExpenseCategories iet LEFT JOIN IncomeAndExpenseCategories pc ON iet.ParentCategoryID = pc.CategoryID 
		LEFT JOIN IncomeAndExpenseCategories mc ON iet.MainCategoryID = mc.CategoryID
		WHERE iet.CategoryID = @CategoryID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_IsExistByCategoryName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_IsExistByCategoryName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_IsExistByCategoryName] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_IsExistByCategoryName] 
	@CategoryName NVARCHAR(200),
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF  EXISTS (SELECT 1 FROM IncomeAndExpenseCategories WHERE CategoryName = @CategoryName AND AccountID = @AccountID)		
			RETURN 1;
		ELSE
			RETURN 0;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategories_UpdateByCategoryID] 
	@CategoryID INT,
	@CategoryName NVARCHAR(200),
	@MonthlyBudget decimal(19, 4) NULL,
	@IsActive BIT,
	@Notes NVARCHAR(250) NULL ,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID)
			BEGIN 
				set @ErrorMessage = N'الفئة التي تحمل معرف  [' + CAST(@CategoryID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		UPDATE IncomeAndExpenseCategories
		SET CategoryName = @CategoryName,
			MonthlyBudget = @MonthlyBudget,
			IsActive = @IsActive,
			Notes = @Notes
		WHERE CategoryID = @CategoryID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل تحديث بيانات الفئة التي تحمل معرف  [ ' + CAST(@CategoryID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseCategory_IsExceedMonthlyBudget]
@CategoryID INT,
@TransationID INT NULL,--null if add mode
@Amount DECIMAL(19,4) NULL,
@TransactionDate DATE,
@IsReturn BIT NULL,
@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		IF @Amount <= 0
		THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

		DECLARE @MainCategoryID INT;
		SELECT @MainCategoryID = MainCategoryID FROM IncomeAndExpenseCategories WHERE CategoryID = @CategoryID

		DECLARE @ErrorMessage NVARCHAR(200);

		IF(@MainCategoryID IS NULL)
		BEGIN 
				set @ErrorMessage = N'الفئة التي تحمل معرف  [' + CAST(@CategoryID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		DECLARE @Budget DECIMAL(19,4);	
		SELECT @Budget = MonthlyBudget FROM IncomeAndExpenseCategories WHERE CategoryID = @MainCategoryID;

		if(@Budget IS NULL) -- dosen't have budget - isn't exceeded
			RETURN 0;

		DECLARE @OldAmount DECIMAL(19,4);
		SELECT @OldAmount = Amount FROM MainTransactions WHERE TransactionID = @TransationID

		-- Return => (+)
		-- Expenses => (-)
		IF (@IsReturn = 0)
		BEGIN
			SET @Amount = -1 * @Amount;
		END;

		DECLARE @DifferentAmount DECIMAL(19,4) = ISNULL(@Amount,0) + (-1 * ISNULL(@OldAmount,0)); 
		
		DECLARE @NetExpense DECIMAL(19,4);	
		
		WITH ALLCategories As
		(
			SELECT c.CategoryID 
			FROM IncomeAndExpenseCategories c WHERE c.CategoryID = @MainCategoryID

			UNION ALL

			SELECT c.CategoryID
			FROM IncomeAndExpenseCategories c INNER JOIN ALLCategories ac ON c.ParentCategoryID = ac.CategoryID
		),
		Summary AS
		(
			SELECT SUM(Amount) AS NetExpnse
			FROM ALLCategories ac INNER JOIN IncomeAndExpenseTransactions iaet ON ac.CategoryID = iaet.CategoryID
			INNER JOIN MainTransactions mt ON iaet.MainTransactionID = mt.TransactionID
			WHERE (TransactionDate >= DATEFROMPARTS(YEAR(@TransactionDate),MONTH(@TransactionDate),1))
			AND (TransactionDate < DATEADD(Day,1,EOMONTH(@TransactionDate)))
		)
		SELECT @NetExpense = ISNULL(NetExpnse,0) FROM Summary;-- (+) if return > expense

		SET @NetExpense = -1 * (@NetExpense + @DifferentAmount);

		IF (@NetExpense > @Budget)
			RETURN 1; -- exceed;

		RETURN 0;-- not exceed


	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransaction_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransaction_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransaction_AddNew] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseTransaction_AddNew]
	@VoucherID INT,
	@CategoryID INT ,
	@Amount decimal(19, 4),
	@CreatedByUserID INT,
	@Purpose NVARCHAR(150) NULL,
	@NewTransactionID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @IsIncome BIT;
		DECLARE @IsReturn BIT;
		DECLARE @IsLocked BIT;
		DECLARE @VoucherDate DATE;
		SELECT @IsIncome = IsIncome, @IsReturn = IsReturn,@IsLocked = IsLocked,@VoucherDate = VoucherDate FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID;

		IF (@IsIncome IS NULL)
		BEGIN
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CreatedByUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

		-- Income OR Return => (+)
		-- Expenses => (-)
		IF (@IsIncome = 0 AND @IsReturn = 0)
		BEGIN
			SET @Amount = -1 * @Amount;
		END;

		--IF ((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + @Amount < 0)
		--		THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;

		DECLARE @TransactionTypeID TINYINT;
		IF (@IsIncome = 1)
		BEGIN
			-- واردات
			SET @TransactionTypeID = 1;
		END;
		ELSE 
		BEGIN
			IF (@IsReturn = 0)
				SET @TransactionTypeID = 2; -- مصروفات
			ELSE
				SET @TransactionTypeID = 5; -- مرتجع مصروفات			
		END

	BEGIN TRANSACTION
		EXEC SP_MainTransactions_AddNew
			@Amount = @Amount,
			@AccountID = @AccountID,
			@CreatedByUserID = @CreatedByUserID,
			@TransactionTypeID = @TransactionTypeID,
			@Purpose = @Purpose,
			@IsLocked = @IsLocked,
			@TransactionDate = @VoucherDate,
			@NewTransactionID = @NewTransactionID OUTPUT;

		INSERT INTO IncomeAndExpenseTransactions(MainTransactionID,VoucherID,CategoryID)
			VALUES(@NewTransactionID,@VoucherID,@CategoryID);

		--EXEC [dbo].[SP_ReCalculateVoucherValue]
		--	@VoucherID = @VoucherID;

	COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransaction_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransaction_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransaction_GetByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseTransaction_GetByID] 
	@TransactionID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @AccountID SMALLINT;

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseTransactions WHERE MainTransactionID = @TransactionID)
		BEGIN 
			SET @ErrorMessage = N'المعامة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		SELECT MainTransactionID,VoucherID,CategoryID FROM IncomeAndExpenseTransactions WHERE MainTransactionID = @TransactionID;
		
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucher]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucher]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucher] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucher]
	@VoucherID INT,
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@VoucherValue DECIMAL(19,4) OUTPUT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT
AS
BEGIN
	BEGIN TRY
		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		SELECT IAET.MainTransactionID,C.CategoryName,ABS(MT.Amount) AS Amount, MT.CreatedDate,u.UserName AS CreatedByUserName ,MT.Purpose
		FROM IncomeAndExpenseTransactions IAET INNER JOIN MainTransactions MT ON IAET.MainTransactionID = MT.TransactionID
		INNER JOIN IncomeAndExpenseCategories C ON IAET.CategoryID = C.CategoryID
		INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
		WHERE IAET.VoucherID = @VoucherID
		ORDER BY IAET.MainTransactionID ASC
		OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
		FETCH NEXT @RowsPerPage ROWS ONLY;

		SELECT @RecordsCount = COUNT(*) FROM IncomeAndExpenseTransactions WHERE VoucherID = @VoucherID;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));
		SELECT @VoucherValue = VoucherValue FROM IncomeAndExpenseVouchers where VoucherID = @VoucherID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucherWithoutPaging]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucherWithoutPaging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucherWithoutPaging] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseTransactionGetAllForVoucherWithoutPaging]
	@VoucherID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		SELECT IAET.MainTransactionID,C.CategoryID,C.CategoryName,ABS(MT.Amount) AS Amount,Mt.TransactionDate, MT.CreatedDate,
		mt.CreatedByUserID,u.UserName AS CreatedByUserName ,MT.Purpose,Mt.AccountID
		FROM IncomeAndExpenseTransactions IAET INNER JOIN MainTransactions MT ON IAET.MainTransactionID = MT.TransactionID
		INNER JOIN IncomeAndExpenseCategories C ON IAET.CategoryID = C.CategoryID
		INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
		WHERE IAET.VoucherID = @VoucherID
		ORDER BY IAET.MainTransactionID ASC

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransactions_DeleteByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransactions_DeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransactions_DeleteByID] AS' 
END
GO


ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseTransactions_DeleteByID]
	@TransactionID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		DECLARE @ReturnValue INT;

		EXEC @ReturnValue = SP_MainTransaction_CheckBalanceBeforeDelete
			@TransactionID  = @TransactionID,
			@CurrentUserID = @CurrentUserID;

		IF @ReturnValue <> 1 RETURN 0;

		DELETE FROM IncomeAndExpenseTransactions WHERE MainTransactionID = @TransactionID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف المعامة التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
	EXEC SP_LogError;
	THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseTransactions_UpdateByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseTransactions_UpdateByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseTransactions_UpdateByID] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseTransactions_UpdateByID]
	@TransactionID INT,
	@Amount decimal(19, 4),
	@CategoryID INT ,
	@Purpose NVARCHAR(150) NULL,
	@CurrentUserID INT
AS
BEGIN		
	BEGIN TRY
		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @VoucherID INT;

		SELECT @VoucherID = VoucherID FROM IncomeAndExpenseTransactions WHERE MainTransactionID = @TransactionID;

		IF (@VoucherID IS NULL)
		BEGIN
			set @ErrorMessage = N'المعاملة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51030,@ErrorMessage,4;
		END;

		DECLARE @IsIncome BIT;
		DECLARE @IsReturn BIT;
		DECLARE @VoucherDate DATE;

		SELECT @IsIncome = IsIncome, @IsReturn = IsReturn,@VoucherDate = VoucherDate
		FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID;

		IF (@IsIncome IS NULL)
		BEGIN
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
		END;

		IF @Amount <= 0
			THROW 51029,N'يجب أن تكون القيمة أكبر من [ 0 ] .',5;

		-- Income OR Return => (+)
		-- Expenses => (-)
		IF (@IsIncome = 0 AND @IsReturn = 0)
		BEGIN
			SET @Amount = -1 * @Amount;
		END;

	BEGIN TRANSACTION


			DECLARE @ReturnValue INT;

			EXEC @ReturnValue = [dbo].[SP_MainTransactions_UpdateByID]
								@TransactionID = @TransactionID,
								@Amount = @Amount,
								@Purpose = @Purpose,
								@CurrentUserID = @CurrentUserID,
								@TransactionDate = @VoucherDate,
								@LogErrors = 0;
		
			UPDATE IncomeAndExpenseTransactions
				SET CategoryID = @CategoryID
			WHERE MainTransactionID = @TransactionID;

			IF @@ROWCOUNT = 0 OR @ReturnValue <> 1
			BEGIN
				SET @ErrorMessage = N'فشل تحديث بيانات المعامة التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51024,@ErrorMessage,2;
			END;

			--EXEC [dbo].[SP_ReCalculateVoucherValue]
			--@VoucherID = @VoucherID;
	COMMIT;
			RETURN 1;

		END TRY
		BEGIN CATCH
	ROLLBACK;
			EXEC SP_LogError;
			THROW;
		END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_AddNew] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_AddNew] 
	@VoucherName NVARCHAR(150),
	@Notes NVARCHAR(200) NULL,
	@IsLocked bit,
	@VoucherDate date,
	@CreatedByUserID INT,
	@IsIncome BIT,
	@IsReturn BIT,
	@NewVoucherID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		INSERT INTO IncomeAndExpenseVouchers(VoucherName,Notes,IsLocked,CreatedDate,VoucherDate,AccountID,CreatedByUserID,IsIncome,IsReturn,VoucherValue)
			VALUES(@VoucherName,@Notes,@IsLocked,SYSDATETIME(),@VoucherDate,@AccountID,@CreatedByUserID,@IsIncome,@IsReturn,0);

		SELECT @NewVoucherID = SCOPE_IDENTITY();

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_ChangeLocking]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_ChangeLocking]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_ChangeLocking] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_ChangeLocking] 
	@VoucherID INT,
	@IsLocked bit,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
			BEGIN 
				set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		UPDATE IncomeAndExpenseVouchers
		SET IsLocked = @IsLocked
		WHERE VoucherID = @VoucherID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل تحديث بيانات المستند الذي يحمل معرف  [ ' + CAST(@VoucherID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_DeleteByVoucherID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_DeleteByVoucherID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_DeleteByVoucherID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_DeleteByVoucherID] 
	@VoucherID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		
		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DECLARE @ErrorMessage NVARCHAR(200);

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID)
			BEGIN 
				set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		DELETE FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف المستند الذي يحمل معرف  [ ' + CAST(@VoucherID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_GetAllBy]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_GetAllBy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetAllBy] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetAllBy]
	@VoucherID INT NULL,
	@IsIncome BIT NULL,
	@IsReturn BIT NULL,
	@VoucherName NVARCHAR(150) NULL,
	@UserName NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromVoucherDate DATE NULL,
	@ToVoucherDate DATE NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT,
	@TotalVouchersValue DECIMAL(19,4) OUTPUT,
	@CurrentPageVouchersValue DECIMAL(19,4) OUTPUT
AS
BEGIN
	BEGIN TRY
		
		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
			SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedVoucherName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @VoucherName IS NOT NULL
		BEGIN
			SET @FormatedVoucherName = '"' +REPLACE(TRIM(@VoucherName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToVoucherDate = DATEADD(DAY,1,@ToVoucherDate);


		DECLARE @TableOfCurrentPageResult TABLE (
			VoucherID INT,
			VoucherName NVARCHAR(150),
			CreatedByUserName NVARCHAR(50),
			VoucherValue DECIMAL(19,4),
			TransactionsCount INT,
			VoucherDate DATETIME2(0),
			CreatedDate DATETIME2(0),
			TotalVouchersValue DECIMAL(19,4) NULL,
			RecordsCount INT
		);

		--DECLARE @RowsPerPage TINYINT = 15;

		WITH ALLVouchers AS
		(
			SELECT v.VoucherID,v.VoucherName, VoucherValue,
			v.VoucherDate,v.CreatedDate,u.UserName AS CreatedByUserName FROM IncomeAndExpenseVouchers v
			INNER JOIN Users u ON u.UserID = v.CreatedByUserID
			WHERE (@VoucherID IS NULL OR v.VoucherID = @VoucherID) AND v.AccountID = @AccountID
			AND (@VoucherName IS NULL
				OR (@TextSearchMode = 1 AND CONTAINS(v.VoucherName,@FormatedVoucherName))
				OR (@TextSearchMode = 2 AND v.VoucherName LIKE CONCAT('%', @VoucherName,'%')))
			AND (@UserName IS NULL
				OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
				OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
			AND (@FromVoucherDate IS NULL OR v.VoucherDate >= @FromVoucherDate) AND (@ToVoucherDate IS NULL OR v.VoucherDate < @ToVoucherDate)
			AND (@FromCreatedDate IS NULL OR v.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR v.CreatedDate < @ToCreatedDate)
			AND (@IsIncome IS NULL OR v.IsIncome = @IsIncome) AND (@IsReturn IS NULL OR v.IsReturn = @IsReturn) 
		),
		State AS
		(
		 SELECT SUM(VoucherValue) AS AllVouchersValue,COUNT(VoucherID) AS RecordsCount  FROM ALLVouchers
		),
		PagingResult AS
		(
			SELECT * FROM ALLVouchers
			ORDER BY VoucherDate DESC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		),
		VoucherTransactionsCounts AS
		(
			SELECT COUNT(IET.MainTransactionID) AS TransactionsCount,pr.VoucherID
			FROM IncomeAndExpenseTransactions IET INNER JOIN PagingResult pr ON IET.VoucherID = pr.VoucherID
			GROUP BY pr.VoucherID
		)
		
		INSERT INTO @TableOfCurrentPageResult(VoucherID,VoucherName,CreatedByUserName,VoucherValue,TransactionsCount,VoucherDate,CreatedDate,TotalVouchersValue,RecordsCount)
		SELECT v.VoucherID,v.VoucherName,v.CreatedByUserName,v.VoucherValue , ISNULL(vtc.TransactionsCount,0),
		v.VoucherDate,v.CreatedDate,s.AllVouchersValue,s.RecordsCount	
		FROM PagingResult v  CROSS JOIN State s LEFT JOIN VoucherTransactionsCounts vtc ON v.VoucherID = vtc.VoucherID 
		OPTION(RECOMPILE);

		SELECT r.VoucherID,r.VoucherName,r.VoucherValue,r.TransactionsCount ,r.VoucherDate,r.CreatedDate,r.CreatedByUserName FROM @TableOfCurrentPageResult r;

		SELECT @CurrentPageVouchersValue = ISNULL(SUM(VoucherValue),0) FROM @TableOfCurrentPageResult
		SELECT TOP 1 @RecordsCount = r.RecordsCount ,@TotalVouchersValue = ISNULL(r.TotalVouchersValue,0) FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @NumberOfPages = ISNULL(@NumberOfPages,0);
		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @CurrentPageVouchersValue = ISNULL(@CurrentPageVouchersValue,0);
		SET @TotalVouchersValue = ISNULL(@TotalVouchersValue,0);
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetAllByWithoutPaging]
	@VoucherID INT NULL,
	@IsIncome BIT NULL,
	@IsReturn BIT NULL,
	@VoucherName NVARCHAR(150) NULL,
	@UserName NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromVoucherDate DATE NULL,
	@ToVoucherDate DATE NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

			IF @TextSearchMode NOT IN (1,2)
			SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedVoucherName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @VoucherName IS NOT NULL
		BEGIN
			SET @FormatedVoucherName = '"' +REPLACE(TRIM(@VoucherName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToVoucherDate = DATEADD(DAY,1,@ToVoucherDate);

		WITH ALLVouchers AS
		(
			SELECT v.VoucherID,v.VoucherName, VoucherValue,v.VoucherDate,
			v.CreatedDate,v.CreatedByUserID,u.UserName AS CreatedByUserName,v.AccountID
			FROM IncomeAndExpenseVouchers v INNER JOIN Users u ON u.UserID = v.CreatedByUserID
			WHERE (@VoucherID IS NULL OR v.VoucherID = @VoucherID) AND v.AccountID = @AccountID
			AND (@VoucherName IS NULL
				OR (@TextSearchMode = 1 AND CONTAINS(v.VoucherName,@FormatedVoucherName))
				OR (@TextSearchMode = 2 AND v.VoucherName LIKE CONCAT('%', @VoucherName,'%')))
			AND (@UserName IS NULL
				OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
				OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
			AND (@FromVoucherDate IS NULL OR v.VoucherDate >= @FromVoucherDate) AND (@ToVoucherDate IS NULL OR v.VoucherDate < @ToVoucherDate)
			AND (@FromCreatedDate IS NULL OR v.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR v.CreatedDate < @ToCreatedDate)
			AND (@IsIncome IS NULL OR v.IsIncome = @IsIncome) AND (@IsReturn IS NULL OR v.IsReturn = @IsReturn)
		),
		VoucherTransactionsCounts AS
		(
			SELECT COUNT(IET.MainTransactionID) AS TransactionsCount,pr.VoucherID
			FROM IncomeAndExpenseTransactions IET INNER JOIN ALLVouchers pr ON IET.VoucherID = pr.VoucherID
			GROUP BY pr.VoucherID
		)	

		SELECT v.VoucherID,v.VoucherName,v.VoucherValue,ISNULL(vtc.TransactionsCount,0) AS TransactionsCount,
		v.VoucherDate,v.CreatedDate,v.CreatedByUserID,v.CreatedByUserName,v.AccountID		
		FROM ALLVouchers v  LEFT JOIN VoucherTransactionsCounts vtc ON v.VoucherID = vtc.VoucherID 
		ORDER BY v.VoucherDate DESC
		OPTION(RECOMPILE);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetByID] 
	@VoucherID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		SELECT VoucherID,VoucherName,Notes,IsLocked,CreatedDate,VoucherDate,AccountID,CreatedByUserID,IsIncome,IsReturn, VoucherValue
		FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_GetVoucherValue]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_GetVoucherValue]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetVoucherValue] AS' 
END
GO


ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_GetVoucherValue] 
	@VoucherID INT,
	@CurrentUserID INT,
	@VoucherValue DECIMAL(19,4) OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
		BEGIN 
			set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		--SELECT @VoucherValue = ABS(dbo.GetVoucherValue(@VoucherID));

		SELECT @VoucherValue = VoucherValue FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_IncomeAndExpenseVouchers_UpdateByVoucherID] 
	@VoucherID INT,
	@VoucherName NVARCHAR(150),
	@Notes NVARCHAR(200) NULL,
	@VoucherDate DATE,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM IncomeAndExpenseVouchers WHERE VoucherID = @VoucherID AND AccountID = @AccountID)
			BEGIN 
				set @ErrorMessage = N'المستند الذي يحمل معرف  [' + CAST(@VoucherID AS NVARCHAR(10)) + N'] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
				THROW 51023,@ErrorMessage,4;
			END;

		UPDATE IncomeAndExpenseVouchers
		SET VoucherName = @VoucherName,
			Notes = @Notes,
			VoucherDate = @VoucherDate
		WHERE VoucherID = @VoucherID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل تحديث بيانات المستند الذي يحمل معرف  [ ' + CAST(@VoucherID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LogError]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_LogError]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_LogError] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_LogError]
AS
BEGIN
	INSERT INTO ErrorLogs(ErrorMessage,ErrorNumber,ErrorProcedure,ErrorLine,ErrorDate)
	VALUES(ERROR_MESSAGE(),ERROR_NUMBER(),ERROR_PROCEDURE(),ERROR_LINE(),SYSDATETIME());
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransaction_CheckBalanceBeforeDelete]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransaction_CheckBalanceBeforeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransaction_CheckBalanceBeforeDelete] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_MainTransaction_CheckBalanceBeforeDelete]
	@TransactionID INT,
	@CurrentUserID INT
AS
BEGIN
		BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @OldAmount DECIMAL(19,4);
		SELECT @OldAmount = Amount FROM MainTransactions WHERE TransactionID = @TransactionID AND AccountID = @AccountID

		IF (@OldAmount IS NULL)
		BEGIN
			SET @ErrorMessage = N'المعامة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

			IF (((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + (-1 * @OldAmount)) < 0)
				THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;

		RETURN 1;

	END TRY
	BEGIN CATCH
	THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_AddNew] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_MainTransactions_AddNew]
	@Amount decimal(19, 4),
	@AccountID SMALLINT,
	@CreatedByUserID INT,
	@TransactionTypeID TINYINT,
	@Purpose NVARCHAR(150) NULL,
	@IsLocked BIT,
	@TransactionDate DATE,
	@NewTransactionID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		IF ((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + @Amount < 0)
				THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;

		INSERT INTO MainTransactions(Amount,CreatedDate,AccountID,CreatedByUserID,TransactionTypeID,IsLocked,Purpose,TransactionDate)
		VALUES(@Amount,SYSDATETIME(),@AccountID,@CreatedByUserID,@TransactionTypeID,@IsLocked,@Purpose,@TransactionDate);

		SET @NewTransactionID = SCOPE_IDENTITY();

	END TRY
	BEGIN CATCH
		--EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_DeleteByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_DeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_DeleteByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_MainTransactions_DeleteByID]
	@TransactionID INT,
	@CurrentUserID INT,
	@LogErrors BIT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;
		SELECT @AccountID = AccountID FROM Users WHERE UserID = @CurrentUserID AND IsDeleted = 0;

		DECLARE @ErrorMessage NVARCHAR(200);

		IF (@AccountID IS NULL)
		BEGIN
			SET @ErrorMessage = N'المستخدم الذي يحمل معرف مستخدم [' + CAST(@CurrentUserID AS NVARCHAR(15)) + N'] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		DECLARE @OldAmount DECIMAL(19,4);
		SELECT @OldAmount = Amount FROM MainTransactions WHERE TransactionID = @TransactionID AND AccountID = @AccountID

		IF (@OldAmount IS NULL)
		BEGIN
			SET @ErrorMessage = N'المعامة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

			IF (((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + (-1 * @OldAmount)) < 0)
				THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;

		DELETE FROM MainTransactions WHERE TransactionID = @TransactionID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل حذف المعامة التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		IF @LogErrors = 1
			EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_GetAll] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_MainTransactions_GetAll]
	@TransactionID INT NULL,
	@UserName NVARCHAR(150) NULL,
	@Purpose NVARCHAR(150) NULL,
	@TransactionTypes NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromTransactionDate DATE NULL,
	@ToTransactionDate DATE NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT,
	@TotalTransactionsValue DECIMAL(19,4) OUTPUT,
	@CurrentPageTransactionsValue DECIMAL(19,4) OUTPUT
AS
BEGIN
	BEGIN TRY	

		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
			SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedPurpose NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @Purpose IS NOT NULL
		BEGIN
			DECLARE @TrimedText NVARCHAR(150) = TRIM(@Purpose);

			DECLARE @WordsCount TINYINT = LEN(@TrimedText) - LEN(REPLACE(@TrimedText,' ','')) + 1;

			IF @WordsCount > 1
				SET @FormatedPurpose = 'NEAR(("' + REPLACE(TRIM(@Purpose),' ','*" , "') + '*"), 7)';
			ELSE
				SET @FormatedPurpose = '"' + @TrimedText + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToTransactionDate = DATEADD(DAY,1,@ToTransactionDate);

		DECLARE @TableOfCurrentPageResult TABLE (
			TransactionID INT,
			Amount DECIMAL(19,4),
			CreatedDate DATETIME2(0),
			TransactionTypeName NVARCHAR(30),
			Purpose NVARCHAR(150),
			TransactionDate DATETIME2(0),
			CreatedByUserName NVARCHAR(50),
			TotalTransactionsValue DECIMAL(19,4) NULL,
			RecordsCount INT
		);

		WITH SearchedTransactionTypes AS
		(
			SELECT VALUE AS TransactionTypeID FROM string_split(TRIM(@TransactionTypes),',') AS TransactionTypeID 
		),
		 ALLTransactions AS
		(
			SELECT mt.TransactionID, mt.Amount, mt.CreatedDate,tt.TransactionName,mt.Purpose,mt.TransactionDate,u.UserName
			FROM MainTransactions mt INNER JOIN TransactionTypes tt ON mt.TransactionTypeID = tt.TransactionTypeID
			INNER JOIN SearchedTransactionTypes stt ON tt.TransactionTypeID = stt.TransactionTypeID
			INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
			WHERE (@TransactionID IS NULL OR mt.TransactionID = @TransactionID) AND mt.AccountID = @AccountID
				AND (@FromTransactionDate IS NULL OR mt.TransactionDate >= @FromTransactionDate)
				AND (@UserName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
					OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
				AND (@Purpose IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(mt.Purpose,@FormatedPurpose))
					OR (@TextSearchMode = 2 AND mt.Purpose LIKE CONCAT('%', @Purpose,'%')))
				AND (@ToTransactionDate IS NULL OR mt.TransactionDate < @ToTransactionDate)
				AND (@FromCreatedDate IS NULL OR mt.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR mt.CreatedDate < @ToCreatedDate)
		),
		State AS
		(
		 SELECT SUM(Amount) AS TransactionsValue,COUNT(TransactionID) AS RecordsCount  FROM ALLTransactions
		),
		PagingResult AS
		(
			SELECT * FROM ALLTransactions
			ORDER BY TransactionDate DESC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)
		
		INSERT INTO @TableOfCurrentPageResult(TransactionID,Amount,CreatedDate,TransactionTypeName,Purpose,
		TransactionDate,CreatedByUserName,TotalTransactionsValue,RecordsCount)
		SELECT	pr.TransactionID,pr.Amount,pr.CreatedDate,pr.TransactionName,pr.Purpose,
		pr.TransactionDate,pr.UserName, s.TransactionsValue,s.RecordsCount
		FROM PagingResult pr  CROSS JOIN State s
		OPTION(RECOMPILE);

		SELECT r.TransactionID,r.Amount,r.TransactionDate,r.CreatedDate,r.TransactionTypeName,r.CreatedByUserName,r.Purpose FROM @TableOfCurrentPageResult r;

		SELECT @CurrentPageTransactionsValue = ISNULL(SUM(Amount),0) FROM @TableOfCurrentPageResult
		SELECT TOP 1 @RecordsCount = r.RecordsCount ,@TotalTransactionsValue = ISNULL(r.TotalTransactionsValue,0) FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @NumberOfPages = ISNULL(@NumberOfPages,0);
		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @CurrentPageTransactionsValue = ISNULL(@CurrentPageTransactionsValue,0);
		SET @TotalTransactionsValue = ISNULL(@TotalTransactionsValue,0);
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_GetAllWithoutPaging]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_GetAllWithoutPaging]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_GetAllWithoutPaging] AS' 
END
GO

ALTER    PROCEDURE [dbo].[SP_MainTransactions_GetAllWithoutPaging]
	@TransactionID INT NULL,
	@UserName NVARCHAR(150) NULL,
	@Purpose NVARCHAR(150) NULL,
	@TransactionTypes NVARCHAR(150) NULL,
	@FromCreatedDate DATE NULL,
	@ToCreatedDate DATE NULL,
	@FromTransactionDate DATE NULL,
	@ToTransactionDate DATE NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedPurpose NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @Purpose IS NOT NULL
		BEGIN
			DECLARE @TrimedText NVARCHAR(150) = TRIM(@Purpose);

			DECLARE @WordsCount TINYINT = LEN(@TrimedText) - LEN(REPLACE(@TrimedText,' ','')) + 1;

			IF @WordsCount > 1
				SET @FormatedPurpose = 'NEAR(("' + REPLACE(TRIM(@Purpose),' ','*" , "') + '*"), 7)';
			ELSE
				SET @FormatedPurpose = '"' + @TrimedText + '*"';
		END;

		SET @ToCreatedDate = DATEADD(DAY,1,@ToCreatedDate);
		SET @ToTransactionDate = DATEADD(DAY,1,@ToTransactionDate);

		WITH SearchedTransactionTypes AS
		(
			SELECT VALUE AS TransactionTypeID FROM string_split(TRIM(@TransactionTypes),',') AS TransactionTypeID 
		)
		
		SELECT mt.TransactionID, mt.Amount,mt.TransactionDate, mt.CreatedDate,tt.TransactionTypeID,tt.TransactionName AS TransactionTypeName ,
		mt.CreatedByUserID,u.UserName AS CreatedByUserName,mt.Purpose,mt.AccountID
		FROM MainTransactions mt INNER JOIN TransactionTypes tt ON mt.TransactionTypeID = tt.TransactionTypeID
		INNER JOIN SearchedTransactionTypes stt ON tt.TransactionTypeID = stt.TransactionTypeID
		INNER JOIN Users u ON mt.CreatedByUserID = u.UserID
		WHERE (@TransactionID IS NULL OR mt.TransactionID = @TransactionID) AND mt.AccountID = @AccountID
			AND (@FromTransactionDate IS NULL OR mt.TransactionDate >= @FromTransactionDate)
			AND (@UserName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
					OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
				AND (@Purpose IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(mt.Purpose,@FormatedPurpose))
					OR (@TextSearchMode = 2 AND mt.Purpose LIKE CONCAT('%', @Purpose,'%')))
			AND (@ToTransactionDate IS NULL OR mt.TransactionDate < @ToTransactionDate)
			AND (@FromCreatedDate IS NULL OR mt.CreatedDate >= @FromCreatedDate) AND (@ToCreatedDate IS NULL OR mt.CreatedDate < @ToCreatedDate)
		ORDER BY mt.TransactionDate DESC
		OPTION(RECOMPILE);
		

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_GetByID] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_MainTransactions_GetByID]
	@MainTransactionID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;
		
		IF NOT EXISTS (SELECT 1 FROM MainTransactions WHERE TransactionID = @MainTransactionID)
			THROW 51010,N'المعاملة غير موجودة',2;

		SELECT TransactionID,ABS(Amount) AS Amount,CreatedDate,AccountID,CreatedByUserID,TransactionTypeID,Purpose,IsLocked,TransactionDate
		FROM MainTransactions WHERE TransactionID = @MainTransactionID;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MainTransactions_UpdateByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_MainTransactions_UpdateByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_MainTransactions_UpdateByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_MainTransactions_UpdateByID]
	@TransactionID INT,
	@Amount decimal(19, 4),
	@Purpose NVARCHAR(150) NULL,
	@CurrentUserID INT,
	@TransactionDate DATE,
	@LogErrors BIT
AS
BEGIN
	BEGIN TRY
		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @OldAmount DECIMAL(19,4);
		SELECT @OldAmount = Amount FROM MainTransactions WHERE TransactionID = @TransactionID AND AccountID = @AccountID

		IF (@OldAmount IS NULL)
		BEGIN
			SET @ErrorMessage = N'المعامة التي تحمل معرف  [' + CAST(@TransactionID AS NVARCHAR(10)) + N'] غير موجودة .'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51023,@ErrorMessage,4;
		END;

		DECLARE @DifferentAmount DECIMAL(19,4) = @Amount + (-1 * @OldAmount);

			IF ((SELECT Balance FROM Accounts WHERE AccountID = @AccountID) + @DifferentAmount < 0)
				THROW 51029, N'الرصيد غير كافي، غير مسموح أن يصبح الرصيد بالسالب', 1;
		UPDATE MainTransactions
			SET Amount = @Amount,
				Purpose = @Purpose,
				TransactionDate = @TransactionDate
		WHERE TransactionID = @TransactionID;

		IF @@ROWCOUNT = 0
		BEGIN
			SET @ErrorMessage = N'فشل تحديث بيانات المعامة التي تحمل معرف  [ ' + CAST(@TransactionID AS NVARCHAR(10)) +N' ] .'
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51024,@ErrorMessage,2;
		END;

		RETURN 1;
	END TRY
	BEGIN CATCH
		IF @LogErrors = 1
			EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_People_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_People_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_People_GetAll] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_People_GetAll]
	@PersonID INT NULL,
	@PersonName NVARCHAR(150) NULL,
	@Email NVARCHAR(255) NULL,
	@Phone NVARCHAR(20) NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT

AS
BEGIN
	BEGIN TRY
		
		IF @RowsPerPage > 100
        BEGIN;
            THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
            RETURN;
        END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
			SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedPersonName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @PersonName IS NOT NULL
		BEGIN
			SET @FormatedPersonName = '"' +REPLACE(TRIM(@PersonName),' ','*" AND "') + '*"';
		END
	
		DECLARE @TableOfCurrentPageResult TABLE (
			PersonID INT,
			PersonName NVARCHAR(150),
			Address NVARCHAR(300) NULL,
			Email NVARCHAR(255) NULL,
			Phone NVARCHAR(20) NULL,
			RecordsCount INT
		);

		--DECLARE @RowsPerPage TINYINT = 15;

		WITH AllPeople AS
		(
			SELECT p.PersonID,p.PersonName,p.Address,p.Email,p.Phone FROM People p 
			WHERE p.AccountID = @AccountID 
				AND (@PersonID IS NULL OR p.PersonID = @PersonID)AND (@PersonName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(p.PersonName,@FormatedPersonName))
					OR (@TextSearchMode = 2 AND p.PersonName LIKE CONCAT('%' ,@PersonName,'%')))
				AND (@Email IS NULL OR (@TextSearchMode = 1 AND p.Email LIKE CONCAT(@Email,'%')) OR (@TextSearchMode = 2 AND p.Email LIKE CONCAT('%' ,@Email,'%')))
				AND (@Phone IS NULL OR (@TextSearchMode = 1 AND p.Phone LIKE CONCAT(@Phone,'%')) OR (@TextSearchMode = 2 AND p.Phone LIKE CONCAT('%' ,@Phone,'%')))
		),
		State AS
		(
			SELECT COUNT(PersonID) AS RecordsCount  FROM AllPeople
		),
		PagingResult AS
		(
			SELECT * FROM AllPeople
			ORDER BY PersonID ASC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)

		INSERT INTO @TableOfCurrentPageResult(PersonID,PersonName,Address,Email,Phone,RecordsCount)
		SELECT pr.PersonID,pr.PersonName,pr.Address,pr.Email,pr.Phone,s.RecordsCount
		FROM PagingResult pr CROSS JOIN State s
		OPTION(RECOMPILE);

		SELECT r.PersonID,r.PersonName,r.Address,r.Email,r.Phone FROM @TableOfCurrentPageResult r;

		SELECT TOP 1 @RecordsCount = r.RecordsCount FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @NumberOfPages = ISNULL(@NumberOfPages,0);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;

END;
GO
/****** Object:  StoredProcedure [dbo].[SP_People_GetAllForSelectOne]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_People_GetAllForSelectOne]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_People_GetAllForSelectOne] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_People_GetAllForSelectOne]
	@PersonName NVARCHAR(150) NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT

AS
BEGIN
	BEGIN TRY

	IF @RowsPerPage > 100
        BEGIN;
            THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
            RETURN;
        END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
		SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedPersonName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @PersonName IS NOT NULL
		BEGIN
			SET @FormatedPersonName = '"' +REPLACE(TRIM(@PersonName),' ','*" AND "') + '*"';
		END
	
		DECLARE @TableOfCurrentPageResult TABLE (
			PersonID INT,
			PersonName NVARCHAR(150),
			RecordsCount INT
		);

		--DECLARE @RowsPerPage TINYINT = 15;

		WITH AllPeople AS
		(
			SELECT p.PersonID,p.PersonName FROM People p 
			WHERE p.AccountID = @AccountID 
				AND (@PersonName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(p.PersonName,@FormatedPersonName))
					OR (@TextSearchMode = 2 AND p.PersonName LIKE CONCAT('%' ,@PersonName,'%')))
		),
		State AS
		(
			SELECT COUNT(PersonID) AS RecordsCount  FROM AllPeople
		),
		PagingResult AS
		(
			SELECT * FROM AllPeople
			ORDER BY PersonID ASC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)

		INSERT INTO @TableOfCurrentPageResult(PersonID,PersonName,RecordsCount)
		SELECT pr.PersonID,pr.PersonName,s.RecordsCount
		FROM PagingResult pr CROSS JOIN State s

		SELECT r.PersonID,r.PersonName FROM @TableOfCurrentPageResult r;

		SELECT TOP 1 @RecordsCount = r.RecordsCount FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @NumberOfPages = ISNULL(@NumberOfPages,0);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;

END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Person_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Person_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Person_AddNew] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_Person_AddNew]
	@PersonName NVARCHAR(150),
	@Address NVARCHAR(300) NULL,
	@Email NVARCHAR(255) NULL,
	@Phone NVARCHAR(20) NULL,
	@Notes NVARCHAR(200) NULL ,
	@CreatedByUserID INT ,
	@NewPersonID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		INSERT INTO People(PersonName,Address,Email,Phone,AccountID,Notes,CreatedByUserID,CreatedDate)
			VALUES(@PersonName,@Address,@Email,@Phone,@AccountID,@Notes,@CreatedByUserID,SYSDATETIME());

		SET @NewPersonID = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Person_DeleteByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Person_DeleteByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Person_DeleteByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Person_DeleteByID]
	@PersonID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY
		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		DELETE FROM People WHERE PersonID = @PersonID;

		DECLARE @RowsAffected INT = @@ROWCOUNT;

		IF @RowsAffected = 0
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'الشخص الذي يحمل معرف شخص [' + CAST(@PersonID AS NVARCHAR(10)) + N'] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Person_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Person_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Person_GetByID] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_Person_GetByID]
	@PersonID INT,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID AND AccountID = @AccountID)
		BEGIN
			SET @ErrorMessage = 'الشخص الذي يحمل معرف شخص [' + CAST(@PersonID AS NVARCHAR(15)) + '] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51002,@ErrorMessage,1;
		END

		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN
			SET @ErrorMessage = N'المستخدم الذي أنشاء الحساب غير موجود.' 
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CurrentUserID AS nvarchar(10)) + N' ]';
			THROW 51020,@ErrorMessage,5;
		END

		DECLARE @Receivable DECIMAL(19,4) = 0; 
		DECLARE @Payable DECIMAL(19,4) = 0; 

		WITH PersonBalance AS
		(
			SELECT 
			SUM(CASE WHEN IsLending = 1 THEN RemainingAmount ELSE 0 END) AS Receivable,
			SUM(CASE WHEN IsLending = 0 THEN RemainingAmount ELSE 0 END) AS Payable
			FROM Debts
			WHERE RemainingAmount <> 0 AND PersonID = @PersonID AND AccountID = @AccountID
		)

		SELECT @Receivable = pb.Receivable,@Payable = pb.Payable FROM PersonBalance pb;


		SELECT PersonName,Address,Email,Phone,Notes,AccountID
		,CreatedByUserID = 
			CASE
				WHEN CreatedByUserID IS NULL THEN @AccountOwnerUserID
				ELSE CreatedByUserID
			END
		,CreatedDate,ISNULL(@Receivable,0) AS Receivable,ISNULL(@Payable,0) AS Payable
		FROM People WHERE PersonID = @PersonID
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Person_IsExistByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Person_IsExistByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Person_IsExistByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Person_IsExistByID]
	@PersonID INT
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
			RETURN 1;
		ELSE
			RETURN 0;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Person_UpdateByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Person_UpdateByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Person_UpdateByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Person_UpdateByID]
	@PersonID INT,
	@PersonName NVARCHAR(150),
	@Address NVARCHAR(300) NULL,
	@Email NVARCHAR(255) NULL,
	@Phone NVARCHAR(20) NULL,
	@Notes NVARCHAR(200) NULL,
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRY

		EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

		UPDATE People
		SET PersonName = @PersonName,
			Address = @Address,
			Email = @Email,
			Phone = @Phone,
			Notes = @Notes
		WHERE PersonID = @PersonID;

		DECLARE @RowsAffected INT = @@ROWCOUNT;

		IF @RowsAffected = 0
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'الشخص الذي يحمل معرف شخص [' + CAST(@PersonID AS NVARCHAR(10)) + N'] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		if (@RowsAffected > 0)
			RETURN 1;
		ELSE
			RETURN 0;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ReCalculateBalanceForAccount]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ReCalculateBalanceForAccount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ReCalculateBalanceForAccount] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ReCalculateBalanceForAccount]
	@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
			BEGIN 
				DECLARE @ErrorMessage NVARCHAR(100) = N'الحساب الذي يحمل معرف  [' + CAST(@AccountID AS NVARCHAR(10)) + N'] غير موجود';
				THROW 51002,@ErrorMessage,1;
			END;

		UPDATE Accounts
		SET Balance = dbo.GetBalanceForAccountAfterCalculate(@AccountID)
		WHERE AccountID = @AccountID;

		IF @@ROWCOUNT = 0
		BEGIN
			DECLARE @CurrentAccountErrorMessage NVARCHAR(150) = N'فشل تحديث رصيد الحساب رقم [' + CAST(@AccountID AS NVARCHAR(10)) + N']';
			THROW 51012,@CurrentAccountErrorMessage,4;
		END

	END TRY
	BEGIN CATCH
		--EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ReCalculateVoucherValue]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ReCalculateVoucherValue]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ReCalculateVoucherValue] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_ReCalculateVoucherValue]
	@VoucherID INT
AS
BEGIN
	BEGIN TRY

		UPDATE IncomeAndExpenseVouchers
		SET VoucherValue = ABS(dbo.GetVoucherValue(@VoucherID))
		WHERE VoucherID = @VoucherID;

		IF @@ROWCOUNT = 0
		BEGIN
			DECLARE @CurrentAccountErrorMessage NVARCHAR(150) = N'فشل تحديث رصيد المستند رقم [' + CAST(@VoucherID AS NVARCHAR(10)) + N']';
			THROW 51012,@CurrentAccountErrorMessage,4;
		END

	END TRY
	BEGIN CATCH
		--EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetCategoryMonthlyFlow]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetCategoryMonthlyFlow]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetCategoryMonthlyFlow] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_GetCategoryMonthlyFlow]
@CategoryID INT,
@StartDate Date,
@EndDate Date,
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		
		-- واردات = 1 , مصروفات = 2 , مرتجع مصروفات = 5 , ديون = 3
		
		DECLARE @BeginOfEndDate DATE = DATEFROMPARTS(YEAR(@EndDate),MONTH(@EndDate),1);

		WITH ALLCategories As
		(
			SELECT c.CategoryID ,CAST(0 AS BIT) AS IsSon
			FROM IncomeAndExpenseCategories c WHERE c.AccountID = @AccountID AND CategoryID = @CategoryID

			UNION ALL

			SELECT c.CategoryID, CAST(1 AS BIT) AS IsSon
			FROM IncomeAndExpenseCategories c INNER JOIN ALLCategories ac ON c.ParentCategoryID = ac.CategoryID
		),
		Summary AS
		(
			SELECT ac.IsSon,MONTH(mt.TransactionDate) as mon,
			YEAR(mt.TransactionDate) AS yy,
			CASE WHEN mt.TransactionTypeID IN (2,5) THEN -1 * Amount ELSE Amount END AS Amount	
			FROM ALLCategories ac INNER JOIN IncomeAndExpenseTransactions iaet ON ac.CategoryID = iaet.CategoryID
			INNER JOIN MainTransactions mt ON iaet.MainTransactionID = mt.TransactionID
			WHERE TransactionDate >= @StartDate AND TransactionDate < DATEADD(Day,1,@EndDate) AND AccountID = @AccountID
		),
		Grouped AS
		(
			SELECT yy,mon,

			SUM(CASE WHEN s.IsSon = 0 THEN Amount ELSE 0 END) AS CategorySum,

			SUM(CASE WHEN s.IsSon = 1 THEN Amount ELSE 0 END) AS CategorySonsSum

			FROM Summary s
			GROUP BY yy,mon
		),
		Months AS
		(
			SELECT DATEFROMPARTS(YEAR(@StartDate),MONTH(@StartDate),1) as d 
			
			UNION ALL

			SELECT DATEADD(MONTH,1,d) AS d2 FROM Months WHERE d < @BeginOfEndDate
		),
		AllMonths AS 
		(
			SELECT YEAR(m.d) as yy,MONTH(m.d) AS mon FROM Months m
		),
		State AS
		(
			 SELECT  m.yy, m.mon, ISNULL(ms.CategorySum,0) AS CategorySum , ISNULL(ms.CategorySonsSum,0) AS CategorySonsSum
			FROM AllMonths m LEFT JOIN Grouped ms ON m.mon = ms.mon AND m.yy = ms.yy
		)
		SELECT yy AS Year,mon,CategorySum,CategorySonsSum,(CategorySum + CategorySonsSum) AS Total FROM State

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetDebtsMonthlyFlow]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetDebtsMonthlyFlow]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetDebtsMonthlyFlow] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_Report_GetDebtsMonthlyFlow]
 @StartDate Date,
 @EndDate Date,
 @AccountID SMALLINT
AS
BEGIN
	BEGIN TRY

		DECLARE @BeginOfEndDate DATE = DATEFROMPARTS(YEAR(@EndDate),MONTH(@EndDate),1);

		WITH DebtsSummary AS
		(
			SELECT d.IsLending,mt.Amount,MONTH(TransactionDate) as mon, YEAR(TransactionDate) AS yy
	
			FROM Debts d INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID
			WHERE mt.TransactionDate >= @StartDate AND mt.TransactionDate < DATEADD(Day,1,@EndDate) AND d.AccountID = @AccountID
		),
		GroupedDebts AS
		(
			SELECT yy,mon,
			
			SUM(CASE WHEN ds.IsLending = 1 THEN Amount ELSE 0 END) AS LendingDebtsSum,

			SUM(CASE WHEN ds.IsLending = 0 THEN Amount ELSE 0 END) AS BorrowingDebtsSum

			FROM DebtsSummary ds
			GROUP BY yy,mon
		),
		DebtPaymentsSummary AS
		(
			SELECT d.IsLending,mt.Amount,MONTH(TransactionDate) as mon, YEAR(TransactionDate) AS yy
	
			FROM DebtPayments d INNER JOIN MainTransactions mt ON d.MainTransactionID = mt.TransactionID
			WHERE mt.TransactionDate >= @StartDate AND mt.TransactionDate < DATEADD(Day,1,@EndDate) AND mt.AccountID = @AccountID
		),
		GroupedDebtPayments AS
		(
			SELECT yy,mon,
			
			SUM(CASE WHEN ds.IsLending = 1 THEN Amount ELSE 0 END) AS LendingPaymentsSum,

			SUM(CASE WHEN ds.IsLending = 0 THEN Amount ELSE 0 END) AS BorrowingPaymentsSum

			FROM DebtPaymentsSummary ds
			GROUP BY yy,mon
		),
		Months AS
		(
			SELECT DATEFROMPARTS(YEAR(@StartDate),MONTH(@StartDate),1) as d 
			
			UNION ALL

			SELECT DATEADD(MONTH,1,d) AS d2 FROM Months WHERE d < @BeginOfEndDate
		),
		AllMonths AS 
		(
			SELECT YEAR(m.d) as yy,MONTH(m.d) AS mon FROM Months m
		),
		Result AS
		(
			 SELECT  m.yy, m.mon, ISNULL(ABS(gd.LendingDebtsSum),0) AS LendingDebtsSum , ISNULL(ABS(gd.BorrowingDebtsSum),0) AS BorrowingDebtsSum,
			 ISNULL(ABS(gps.LendingPaymentsSum),0) AS LendingPaymentsSum , ISNULL(ABS(gps.BorrowingPaymentsSum),0) AS BorrowingPaymentsSum
			FROM AllMonths m LEFT JOIN GroupedDebts gd ON m.mon = gd.mon AND m.yy = gd.yy
			LEFT JOIN GroupedDebtPayments gps ON m.mon = gps.mon AND m.yy = gps.yy
		)

		SELECT yy AS Year,mon,LendingDebtsSum,BorrowingDebtsSum,LendingPaymentsSum,BorrowingPaymentsSum FROM Result
		

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetDebtsRepaymentSchedule]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetDebtsRepaymentSchedule]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetDebtsRepaymentSchedule] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_GetDebtsRepaymentSchedule]
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY

		DECLARE @Today DATE = GETDATE();

		DECLARE @EndDate DATE = DATEADD(MONTH,5,@Today);
		SET @EndDate = EOMONTH(@EndDate);
		DECLARE @BeginOfEndDate DATE = DATEFROMPARTS(YEAR(@EndDate),MONTH(@EndDate),1);


		WITH AllDebts AS
		(
			SELECT RemainingAmount,PaymentDueDate,IsLending,MONTH(PaymentDueDate) as mon, YEAR(PaymentDueDate) as yy
			FROM Debts WHERE AccountID = @AccountID AND PaymentDueDate IS NOT NULL AND RemainingAmount > 0
			AND PaymentDueDate <= @EndDate
		),
		Prev AS
		(		
			SELECT

			SUM(CASE WHEN IsLending = 1 THEN RemainingAmount ELSE 0 END) AS Receivalbe,

			SUM(CASE WHEN IsLending = 0 THEN RemainingAmount ELSE 0 END) AS Payables

			FROM AllDebts WHERE PaymentDueDate < @Today
			
		),
		Grouped AS
		(
			SELECT yy,mon,

			SUM(CASE WHEN IsLending = 1 THEN RemainingAmount ELSE 0 END) AS Receivalbe,

			SUM(CASE WHEN IsLending = 0 THEN RemainingAmount ELSE 0 END) AS Payables

			FROM AllDebts WHERE PaymentDueDate >= @Today
			GrOUP BY yy,mon
		),
		Months AS
		(
			SELECT DATEFROMPARTS(YEAR(@Today),MONTH(@Today),1) as d 
			
			UNION ALL

			SELECT DATEADD(MONTH,1,d) AS d2 FROM Months WHERE d < @BeginOfEndDate
		),
		AllMonths AS 
		(
			SELECT YEAR(m.d) as yy,MONTH(m.d) AS mon FROM Months m
		),
		State AS
		(
			 SELECT  m.yy, m.mon, ISNULL(ms.Receivalbe,0) AS Receivalbe , ISNULL(ms.Payables,0) AS Payables
			FROM AllMonths m LEFT JOIN Grouped ms ON m.mon = ms.mon AND m.yy = ms.yy
		),
		Result AS
		(
			SELECT  NULL AS mon,NULL as Year ,ISNULL(Receivalbe,0) AS Receivable,ISNULL(Payables,0) AS Payables FROM Prev

			UNION ALL

			SELECT mon,yy,Receivalbe,Payables FROM State s 
		)

		SELECT mon,Year,Receivable,Payables,(Receivable - Payables) AS NetCashFlow
		FROM Result

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetMainKPIS]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetMainKPIS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetMainKPIS] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_GetMainKPIS]
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY

	DECLARE @Balance DECIMAL(19,4) ;
	DECLARE @TotalReceivables DECIMAL(19,4) ;
	DECLARE @TotalPayables DECIMAL(19,4) ;
	DECLARE @Next30DayDebtsDue DECIMAL(19,4);

	SELECT 
		@TotalReceivables = ISNULL(SUM(CASE WHEN IsLending = 1 THEN RemainingAmount ELSE 0 END),0),
		@TotalPayables = ISNULL(SUM(CASE WHEN IsLending = 0 THEN RemainingAmount ELSE 0 END),0),
		@Next30DayDebtsDue = ISNULL(SUM(CASE WHEN  IsLending = 0 AND PaymentDueDate IS NOT NULL AND PaymentDueDate < DATEADD(DAY,30,GETDATE()) THEN RemainingAmount ELSE 0 END),0)
	FROM DEBTS WHERE AccountID = @AccountID

	DECLARE @DayPerformance DECIMAL(19,4)
	
	DECLARE @MonthPerformance DECIMAL(19,4)

	DECLARE @YearPerformance DECIMAL(19,4)  

	DECLARE @YearStart DATE = DATEFROMPARTS(YEAR(GETDATE()),1,1);
	DECLARE @before6Months DATE = DATEADD(MONTH,-6,GETDATE());
	SET @before6Months = DATEFROMPARTS(YEAR(@before6Months),MONTH(@before6Months),1);

	DECLARE @StartDate DATE;

	IF @YearStart < @before6Months
		SET @StartDate = @YearStart;
	ELSE
		SET @StartDate = @before6Months;

	DECLARE @Last6MonthsNetProfitsAvg DECIMAL(19,4) ;

	WITH Summary AS
	(
		SELECT Amount,CAST(TransactionDate AS DATE) AS TransactionDay,MONTH(TransactionDate) AS mon,YEAR(TransactionDate) as yy,AccountID

		FROM MainTransactions
		WHERE TransactionDate >= @StartDate
		AND TransactionDate < DATEADD(DAY,1,GETDATE()) AND AccountID = @AccountID
		AND TransactionTypeID IN (1,2,5)
	),
	DayPerformance AS
	(
		SELECT AccountID,SUM(Amount) AS DayPerformance FROM Summary WHERE TransactionDay = CAST(GETDATE() AS DATE) GROUP BY AccountID
	),
	Grouped AS
	(
		SELECT yy,mon,SUM(Amount) as MonthSum,AccountID FROM Summary s 
		GROUP BY yy,mon,AccountID
	),
	MonthPerformance AS
	(
		SELECT MonthSum as MonthPerformance,AccountID FROM Grouped WHERE mon = MONTH(GETDATE()) AND yy = YEAR(GETDATE())
	),
	YearPerformance AS
	(
		SELECT SUM(MonthSum) as YearPerformance,AccountID FROM Grouped WHERE yy = YEAR(GETDATE()) GROUP BY AccountID
	),
	AvgNetProfitLast6Months AS
	(
		SELECT (CAST(SUM(MonthSum) AS DECIMAL(19,4)) / 6) as AvgNetProfitLast6Months,AccountID FROM Grouped
		WHERE
		DATEFROMPARTS(yy, mon, 1) >= DATEFROMPARTS(YEAR(@before6Months), MONTH(@before6Months), 1)
        AND DATEFROMPARTS(yy, mon, 1) < DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) 

		GROUP BY AccountID
	)

	SELECT @Balance = Balance,@DayPerformance = ISNULL(dp.DayPerformance,0),@MonthPerformance = ISNULL(mp.MonthPerformance,0),
	@YearPerformance = ISNULL(yp.YearPerformance,0),@Last6MonthsNetProfitsAvg = ISNULL(anp.AvgNetProfitLast6Months,0)
	FROM Accounts a LEFT JOIN
	DayPerformance dp ON a.AccountID = dp.AccountID LEFT JOIN MonthPerformance mp ON a.AccountID = mp.AccountID
	LEFT JOIN YearPerformance yp ON a.AccountID = yp.AccountID
	LEFT JOIN AvgNetProfitLast6Months anp ON a.AccountID = anp.AccountID
	WHERE a.AccountID = @AccountID

	SELECT @Balance AS Balance,@TotalReceivables AS TotalReceivables,@TotalPayables AS TotalPayables
	,@Next30DayDebtsDue AS Next30DayDebtsDue,@DayPerformance AS DayPerformance,
	@MonthPerformance AS MonthPerformance,@YearPerformance AS YearPerformance,@Last6MonthsNetProfitsAvg AS AvgNetProfitLast6Months

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetMonthlyFlow]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetMonthlyFlow]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetMonthlyFlow] AS' 
END
GO

ALTER   PROCEDURE [dbo].[SP_Report_GetMonthlyFlow]
 @StartDate Date,
 @EndDate Date,
 @AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		-- واردات = 1 , مصروفات = 2 , مرتجع مصروفات = 5 , ديون = 3

		 DECLARE @BeginOfEndDate DATE = DATEFROMPARTS(YEAR(@EndDate),MONTH(@EndDate),1);

		WITH MonthlySummary AS
		(
			SELECT TransactionTypeID,Amount,MONTH(TransactionDate) as mon,
			YEAR(TransactionDate) AS yy
	
			FROM MainTransactions
			WHERE TransactionDate >= @StartDate AND TransactionDate < DATEADD(Day,1,@EndDate) AND AccountID = @AccountID
		),
		Grouped AS
		(
			SELECT yy,mon,
			
			SUM(CASE WHEN TransactionTypeID = 1 THEN Amount	ELSE 0 END) AS Income,

			SUM(CASE WHEN TransactionTypeID = 2 THEN Amount ELSE 0 END) AS Expense,
			
			SUM(CASE WHEN TransactionTypeID = 5 THEN Amount	ELSE 0 END) AS ExpenseReturn

			FROM MonthlySummary ms
			GROUP BY yy,mon
		),
		Months AS
		(
			SELECT DATEFROMPARTS(YEAR(@StartDate),MONTH(@StartDate),1) as d 
			
			UNION ALL

			SELECT DATEADD(MONTH,1,d) AS d2 FROM Months WHERE d < @BeginOfEndDate
		),
		AllMonths AS 
		(
			SELECT YEAR(m.d) as yy,MONTH(m.d) AS mon FROM Months m
		),
		State AS
		(
			 SELECT  m.yy, m.mon, ISNULL(ms.Income,0) AS Income , (ISNULL(ABS(ms.Expense),0) - ISNULL(ms.ExpenseReturn,0)) AS NetExpense
			FROM AllMonths m LEFT JOIN Grouped ms ON m.mon = ms.mon AND m.yy = ms.yy
		),
		Result AS
		(
			SELECT yy AS Year,mon,Income,NetExpense,(Income - NetExpense) AS NetCashFlow FROM State
		)

		SELECT Year,mon,Income,NetExpense,NetCashFlow,SUM(Income) OVER() AS TotalIncome,
		SUM(NetExpense) OVER() AS TotalNetExpense,SUM(NetCashFlow) OVER() AS TotalNetCashFlow FROM Result
		
		

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_GetTopCategories]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_GetTopCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_GetTopCategories] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_GetTopCategories]
@IsIncome BIT,
@StartDate Date NULL,
@EndDate Date NULL,
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		
		-- واردات = 1 , مصروفات = 2 , مرتجع مصروفات = 5 , ديون = 3

		WITH Summary AS
		(
			SELECT ISNULL(ac.MainCategoryID,ac.CategoryID) AS MainCategoryID,
			CASE WHEN mt.TransactionTypeID IN (2,5) THEN -1 * Amount ELSE Amount END AS Amount	
			FROM IncomeAndExpenseCategories ac INNER JOIN IncomeAndExpenseTransactions iaet ON ac.CategoryID = iaet.CategoryID
			INNER JOIN MainTransactions mt ON iaet.MainTransactionID = mt.TransactionID
			WHERE IsIncome = @IsIncome AND (@StartDate IS NULL OR TransactionDate >= @StartDate)
			AND (@EndDate IS NULL OR TransactionDate < DATEADD(Day,1,@EndDate)) AND mt.AccountID = @AccountID
		),
		Grouped AS
		(
			SELECT MainCategoryID,SUM(s.Amount) AS MainCategoryValue
			FROM Summary s
			GROUP BY MainCategoryID
		),
		Ranked AS
		(
			SELECT MainCategoryID,MainCategoryValue,DENSE_RANK() OVER(ORDER BY MainCategoryValue DESC) AS Ranking
			FROM Grouped g WHERE MainCategoryValue > 0
		),
		State AS
		(
			SELECT MainCategoryID,MainCategoryValue,Ranking FROM Ranked r WHERE r.Ranking < 8
		),
		Result AS 
		(
			SELECT c.CategoryName, ISNULL(r.MainCategoryValue,0) AS Value, r.Ranking,SUM(r.MainCategoryValue) OVER() AS ResultSum
			FROM State r INNER JOIN IncomeAndExpenseCategories c ON r.MainCategoryID = c.CategoryID
		)
		SELECT r.CategoryName,r.Value, r.Ranking,(CAST(r.Value AS DECIMAL(19,4)) / r.ResultSum) AS Percentage
		FROM Result r

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_Top5DebtorsRanking]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_Top5DebtorsRanking]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_Top5DebtorsRanking] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_Top5DebtorsRanking]
@IsLending BIT,
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		WITH AllPeople AS
		(
			SELECT PersonID,SUM(RemainingAmount) AS PersonRemaining FROM Debts
			WHERE RemainingAmount > 0 AND IsLending = @IsLending AND AccountID = @AccountID
			GROUP BY PersonID
		),
		Ranked AS
		(
			SELECT *,ROW_NUMBER() OVER(ORDER BY PersonRemaining DESC) as PersonOrder FROM AllPeople ap
		)

		SELECT p.PersonID,p.PersonName,r.PersonRemaining,r.PersonOrder
		FROM Ranked r INNER JOIN People p ON r.PersonID = p.PersonID
		WHERE PersonOrder < 6
		ORDER BY PersonOrder ASC

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Report_Top5PeopleDebtsSumRanking]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Report_Top5PeopleDebtsSumRanking]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Report_Top5PeopleDebtsSumRanking] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Report_Top5PeopleDebtsSumRanking]
@IsLending BIT,
@AccountID SMALLINT
AS
BEGIN
	BEGIN TRY
		WITH AllPeople AS
		(
			SELECT PersonID,ABS(SUM(mt.Amount)) AS PersonDebtsSum
			FROM Debts d INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID
			WHERE IsLending = @IsLending AND d.AccountID = @AccountID
			GROUP BY PersonID
		),
		Ranked AS
		(
			SELECT *,ROW_NUMBER() OVER(ORDER BY PersonDebtsSum DESC) as PersonOrder FROM AllPeople ap
		)

		SELECT p.PersonID,p.PersonName,r.PersonDebtsSum,r.PersonOrder
		FROM Ranked r INNER JOIN People p ON r.PersonID = p.PersonID
		WHERE PersonOrder < 6
		ORDER BY PersonOrder ASC

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TransactionType_GetByID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TransactionType_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_TransactionType_GetByID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_TransactionType_GetByID]
	@TransactionTypeID TINYINT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'نوع المعاملة الذي يحمل معرف  [' + CAST(@TransactionTypeID AS NVARCHAR(3)) + N']  غير موجود';
			THROW 51006,@ErrorMessage,3;
		END

		SELECT TransactionName AS TransactionTypeName FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TransactionType_GetByName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TransactionType_GetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_TransactionType_GetByName] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_TransactionType_GetByName]
	@TransactionName NVARCHAR(30)
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM TransactionTypes WHERE TransactionName = @TransactionName)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = N'نوع المعاملة الذي يحمل اسم  [' + @TransactionName + N']  غير موجود';
			THROW 51006,@ErrorMessage,3;
		END

		SELECT TransactionTypeID FROM TransactionTypes WHERE TransactionName = @TransactionName;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TransactionTypes_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TransactionTypes_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_TransactionTypes_GetAll] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_TransactionTypes_GetAll]
AS
BEGIN
	BEGIN TRY
		SELECT TransactionTypeID,TransactionName AS TransactionTypeName
		FROM TransactionTypes ORDER BY TransactionTypeID;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_AddNew]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_AddNew]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_AddNew] AS' 
END
GO


ALTER   PROCEDURE [dbo].[SP_User_AddNew]
	@UserName NVARCHAR(30),
	@PersonID INT,
	@Permissions INT,
	@Password VARCHAR(64) NULL,
	@Salt VARCHAR(24),
	@IsActive BIT,
	@Notes NVARCHAR(200) ,
	@CreatedByUserID INT,
	@NewUserID INT OUTPUT
AS
BEGIN
	BEGIN TRY

		DECLARE @AccountID SMALLINT;

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CreatedByUserID,
			@AccountID = @AccountID OUTPUT;

		DECLARE @ErrorMessage NVARCHAR(200);

		IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID AND AccountID = @AccountID)
		BEGIN
			SET @ErrorMessage = 'الشخص الذي يحمل معرف شخص [' + CAST(@PersonID AS VARCHAR(15)) + '] غير موجود.'
				+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CreatedByUserID AS nvarchar(10)) + N' ]';
			THROW 51002,@ErrorMessage,1;
		END

		IF EXISTS (SELECT 1 FROM Users WHERE PersonID = @PersonID AND IsDeleted = 0)
		BEGIN
			SET @ErrorMessage  = N'الشخص الذي يحمل معرف شخص [ ' + CAST(@PersonID AS VARCHAR(15)) + N' ]  مرتبط بمستخدم بالفعل. '
			+ CHAR(13) + CHAR(10) + N'معرف المستخدم الحالي  [ ' + CAST(@CreatedByUserID AS nvarchar(10)) + N' ]';
			THROW 51002,@ErrorMessage,1;
		END;

		INSERT INTO Users(UserName,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted,CreatedByUserID,CreatedDate)
		VALUES (@UserName,@PersonID,@Permissions,@Password,@Salt,@IsActive,@Notes,@AccountID,0,@CreatedByUserID,SYSDATETIME());

		SET @NewUserID = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_ChangePassword]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_ChangePassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_ChangePassword] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_ChangePassword]
	@UserID INT,
	@OldPassword VARCHAR(64),
	@NewPassword VARCHAR(64),
	@NewSalt VARCHAR(24),
	@CurrentUserID INT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

			IF (@OldPassword COLLATE Latin1_General_CS_AS <> 
				(select Password from Users WHERE UserID = @UserID) COLLATE Latin1_General_CS_AS)
			BEGIN;
				THROW 51003,N'كلمة مرور خاطئة برجاء إدخال كلمة مرور صحيحة',3;
			END;

			UPDATE Users SET Password = @NewPassword,Salt = @NewSalt
			WHERE UserID = @UserID AND IsDeleted = 0;

			DECLARE @RowsAffected INT = @@ROWCOUNT;

			IF @RowsAffected = 0
			BEGIN
				DECLARE @FailedErrorMessage NVARCHAR(100) = N'فشل تغيير كلمة المرور';
				THROW 51012,@FailedErrorMessage,1;
			END;

	COMMIT
			RETURN 1;
		END TRY
		BEGIN CATCH
			ROLLBACK;
			EXEC SP_LogError;
			THROW;
		END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_DeleteByUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_DeleteByUserID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_DeleteByUserID] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_User_DeleteByUserID]
	@UserID INT
AS
BEGIN
	BEGIN TRY
		DELETE FROM Users WHERE UserID = @UserID AND IsDeleted = 0;

		DECLARE @RowsAffected INT = @@ROWCOUNT;

		IF @RowsAffected = 0
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف مستخدم [' + CAST(@UserID AS VARCHAR(15)) + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		RETURN 1;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetByPersonID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_GetByPersonID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_GetByPersonID] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_User_GetByPersonID]
	@PersonID INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Users WHERE PersonID = @PersonID)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف شخص [' + CAST(@PersonID AS VARCHAR(15)) + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		DECLARE @AccountID SMALLINT;	
		SELECT @AccountID =  AccountID FROM Users WHERE PersonID = @PersonID
		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN
			SET @ErrorMessage = 'المستخدم الذي أنشاء الحساب غير موجود';
			THROW 51020,@ErrorMessage,5;
		END

		SELECT UserName,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted
		,CreatedByUserID = 
			CASE
				WHEN CreatedByUserID IS NULL THEN @AccountOwnerUserID
				ELSE CreatedByUserID
			END
		,CreatedDate
		FROM Users WHERE PersonID = @PersonID;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetByUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_GetByUserID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_GetByUserID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_GetByUserID]
	@UserID INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID )
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف مستخدم [' + CAST(@UserID AS VARCHAR(15)) + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		DECLARE @AccountID SMALLINT;	
		SELECT @AccountID =  AccountID FROM Users WHERE UserID = @UserID
		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN
			SET @ErrorMessage = 'المستخدم الذي أنشاء الحساب غير موجود';
			THROW 51020,@ErrorMessage,5;
		END

		SELECT UserName,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted
		,CreatedByUserID = 
			CASE
				WHEN CreatedByUserID IS NULL THEN @AccountOwnerUserID
				ELSE CreatedByUserID
			END
		,CreatedDate
		FROM Users WHERE UserID = @UserID;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetByUserName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_GetByUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_GetByUserName] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_User_GetByUserName]
	@UserName NVARCHAR(30)
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل اسم مستخدم [' + @UserName + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		DECLARE @AccountID SMALLINT;	
		SELECT @AccountID =  AccountID FROM Users WHERE UserName = @UserName
		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN
			SET @ErrorMessage = 'المستخدم الذي أنشاء الحساب غير موجود';
			THROW 51020,@ErrorMessage,5;
		END

		SELECT UserName,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted
		,CreatedByUserID = 
			CASE
				WHEN CreatedByUserID IS NULL THEN @AccountOwnerUserID
				ELSE CreatedByUserID
			END
		,CreatedDate
		FROM Users WHERE UserName = @UserName;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetByUserNameAndPassword_Login]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_GetByUserNameAndPassword_Login]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_GetByUserNameAndPassword_Login] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_GetByUserNameAndPassword_Login]
	@UserName NVARCHAR(30),
	@Password VARCHAR(64)
AS
BEGIN
	BEGIN TRY

		IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName AND 
			(Password COLLATE Latin1_General_CS_AS) = (@Password COLLATE Latin1_General_CS_AS) AND IsDeleted = 0)
				THROW 51019,N'فشل تسجيل الدخول: اسم المستخدم أو كلمة المرور غير صحيحة',5;

		IF ((SELECT IsActive FROM Users WHERE UserName = @UserName) = 0)
			THROW 51020,N'فشل تسجيل الدخول: تم إيقاف هذا الحساب برجاء التواصل مع الأدمن',4;

		DECLARE @AccountID SMALLINT;	
		SELECT @AccountID =  AccountID FROM Users WHERE UserName = @UserName
		DECLARE @AccountOwnerUserID INT = dbo.GetAccountOwnerUserID(@AccountID);

		IF (@AccountOwnerUserID IS NULL)
		BEGIN;
			THROW 51020,N'فشل تسجيل الدخول: المستخدم الذي أنشاء الحساب غير موجود',5;
		END

		SELECT UserID,PersonID,Permissions,Password,Salt,IsActive,Notes,AccountID,IsDeleted
		,CreatedByUserID = 
			CASE
				WHEN CreatedByUserID IS NULL THEN @AccountOwnerUserID
				ELSE CreatedByUserID
			END
		,CreatedDate
		FROM Users 
		WHERE UserName = @UserName AND (Password COLLATE Latin1_General_CS_AS) = (@Password COLLATE Latin1_General_CS_AS) AND IsDeleted = 0;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_GetSaltByUserName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_GetSaltByUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_GetSaltByUserName] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_GetSaltByUserName]
	@UserName NVARCHAR(30),
	@Salt VARCHAR(24) OUTPUT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName AND IsDeleted = 0)
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل اسم مستخدم [' + @UserName + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		SELECT @Salt = Salt FROM Users WHERE UserName = @UserName;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_User_IsExistByPersonID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_IsExistByPersonID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_IsExistByPersonID] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_User_IsExistByPersonID]
	@PersonID INT,
	@IncludeDeleted BIT
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM Users WHERE PersonID = @PersonID AND IsDeleted = 0 AND (IsDeleted = 0 OR @IncludeDeleted = 1))
			RETURN 1;
		ELSE
			RETURN 0;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_User_IsExistByUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_IsExistByUserID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_IsExistByUserID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_IsExistByUserID]
	@UserID INT,
	@IncludeDeleted BIT
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID AND (IsDeleted = 0 OR @IncludeDeleted = 1))
			RETURN 1;
		ELSE
			RETURN 0;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_User_IsExistByUserName]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_IsExistByUserName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_IsExistByUserName] AS' 
END
GO


ALTER PROCEDURE [dbo].[SP_User_IsExistByUserName]
	@UserName NVARCHAR(30),
	@IncludeDeleted BIT
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM Users WHERE UserName = @UserName AND (IsDeleted = 0 OR @IncludeDeleted = 1))
			RETURN 1;
		ELSE
			RETURN 0;
	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_User_UpdateByUserID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_User_UpdateByUserID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_User_UpdateByUserID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_User_UpdateByUserID]
	@UserID INT,
	@UserName NVARCHAR(30),
	@PersonID INT,
	@Permissions INT,
	@IsActive BIT,
	@Notes NVARCHAR(200),
	@CurrentUserID INT
AS
BEGIN

	EXEC SP_Validating_CheckUserValid
				@UserID = @CurrentUserID;

	BEGIN TRY
		UPDATE Users 
		SET UserName = @UserName,
			PersonID = @PersonID,
			Permissions = @Permissions,
			IsActive = @IsActive,
			Notes = @Notes
		WHERE UserID = @UserID AND IsDeleted = 0;

		DECLARE @RowsAffected INT = @@ROWCOUNT;

		IF @RowsAffected = 0
		BEGIN
			DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف مستخدم [' + CAST(@UserID AS VARCHAR(15)) + '] غير موجود';
			THROW 51002,@ErrorMessage,1;
		END;

		RETURN 1;

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Users_GetAll]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Users_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Users_GetAll] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Users_GetAll]
	@UserID INT NULL,
	@UserName NVARCHAR(150) NULL,
	@PersonName NVARCHAR(150) NULL,
	@IsActive BIT NULL,
	@TextSearchMode TINYINT,--1 = wordsPrefix_fast, 2 = subString_slower
	@CurrentUserID INT,
	@PageNumber INT,
	@RowsPerPage TINYINT,
	@NumberOfPages INT OUTPUT,
	@RecordsCount INT OUTPUT 

AS
BEGIN
	BEGIN TRY

		IF @RowsPerPage > 100
		BEGIN;
			THROW 51040, N'لا يمكن طلب أكثر من 100 صف في المرة الواحدة.', 1;
			RETURN;
		END;

		DECLARE @AccountID SMALLINT;

		DECLARE @ErrorMessage NVARCHAR(200);

		EXEC SP_Validating_CheckUserValid_OutAccountID
			@UserID = @CurrentUserID,
			@AccountID = @AccountID OUTPUT;

		IF @TextSearchMode NOT IN (1,2)
			SET @TextSearchMode = 1;

		-- give it default value because full text index dosen't accept null value even personName is null (don't use it for filter) to sql server optimize
		DECLARE @FormatedPersonName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @PersonName IS NOT NULL
		BEGIN
			SET @FormatedPersonName = '"' +REPLACE(TRIM(@PersonName),' ','*" AND "') + '*"';
		END;

		DECLARE @FormatedUserName NVARCHAR(1000)='z'

		IF @TextSearchMode = 1 AND @UserName IS NOT NULL
		BEGIN
			SET @FormatedUserName = '"' +REPLACE(TRIM(@UserName),' ','*" AND "') + '*"';
		END
	
		DECLARE @TableOfCurrentPageResult TABLE (
			UserID INT,
			UserName NVARCHAR(50),
			PersonName NVARCHAR(150),
			Phone NVARCHAR(20) NULL,
			Email NVARCHAR(255) NULL,
			IsActive BIT ,
			RecordsCount INT
		);
		
		WITH AllUsers AS
		(
			SELECT u.UserID,u.UserName,p.PersonName,p.Phone,p.Email,IsActive FROM Users u INNER JOIN People p ON u.PersonID = p.PersonID
			WHERE u.AccountID = @AccountID AND u.IsDeleted = 0
				AND (@UserID IS NULL OR u.UserID = @UserID) AND (@IsActive IS NULL OR @IsActive = u.IsActive)
				AND (@UserName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(u.UserName,@FormatedUserName))
					OR (@TextSearchMode = 2 AND u.UserName LIKE CONCAT('%', @UserName,'%')))
				AND (@PersonName IS NULL
					OR (@TextSearchMode = 1 AND CONTAINS(p.PersonName,@FormatedPersonName))
					OR (@TextSearchMode = 2 AND p.PersonName LIKE CONCAT('%' ,@PersonName,'%')))		
		),
		State AS
		(
		 SELECT COUNT(UserID) AS RecordsCount  FROM AllUsers
		),
		PagingResult AS
		(
			SELECT * FROM AllUsers
			ORDER BY UserID ASC
			OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
			FETCH NEXT @RowsPerPage ROWS ONLY
		)
		INSERT INTO @TableOfCurrentPageResult(UserID,UserName,PersonName,Phone,Email,IsActive,RecordsCount)
		SELECT pr.UserID,pr.UserName,pr.PersonName,pr.Phone,pr.Email,pr.IsActive,s.RecordsCount
		FROM PagingResult pr CROSS JOIN State s
		OPTION(RECOMPILE);
		--

		SELECT r.UserID,r.UserName,r.PersonName,r.Phone,r.Email,r.IsActive  FROM @TableOfCurrentPageResult r;

		SELECT TOP 1 @RecordsCount = r.RecordsCount FROM @TableOfCurrentPageResult r;
		SELECT @NumberOfPages = CEILING(CAST(@RecordsCount AS DECIMAL(18,2))/CAST(@RowsPerPage AS DECIMAL(18,2)));

		SET @RecordsCount = ISNULL(@RecordsCount,0);
		SET @NumberOfPages = ISNULL(@NumberOfPages,0);

	END TRY
	BEGIN CATCH
		EXEC SP_LogError;
		THROW;
	END CATCH;

END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Validating_CheckUserValid]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Validating_CheckUserValid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Validating_CheckUserValid] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Validating_CheckUserValid]
@UserID INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID AND IsActive = 1 AND IsDeleted = 0 )
	BEGIN
		DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف مستخدم [' + CAST(@UserID AS NVARCHAR(15)) + '] غير موجود أو غير فعال حالياً.';
		THROW 51002,@ErrorMessage,1;
	END;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Validating_CheckUserValid_OutAccountID]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Validating_CheckUserValid_OutAccountID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Validating_CheckUserValid_OutAccountID] AS' 
END
GO

ALTER PROCEDURE [dbo].[SP_Validating_CheckUserValid_OutAccountID]
@UserID INT,
@AccountID SMALLINT OUTPUT
AS
BEGIN
	SELECT @AccountID = AccountID FROM Users WHERE UserID = @UserID AND IsActive = 1 AND IsDeleted = 0;

	IF (@AccountID IS NULL)
	BEGIN
		DECLARE @ErrorMessage NVARCHAR(100) = 'المستخدم الذي يحمل معرف مستخدم [' + CAST(@UserID AS NVARCHAR(15)) + '] غير موجود أو غير فعال حالياً.';
		THROW 51002,@ErrorMessage,1;
	END;
END
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeCurrency_AfterUpdate]    Script Date: 13/11/2025 7:33:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeCurrency_AfterUpdate]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventChangeCurrency_AfterUpdate] ON [dbo].[Accounts]
AFTER UPDATE
AS
BEGIN
	IF UPDATE (DefaultCurrencyID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.AccountID = d.AccountID
			WHERE i.DefaultCurrencyID <> d.DefaultCurrencyID)
		BEGIN;
			THROW 51003,N''غير مسموح بتغيير العملة'',3;
		END
	END
END
' 
GO
ALTER TABLE [dbo].[Accounts] ENABLE TRIGGER [trg_PreventChangeCurrency_AfterUpdate]
GO
/****** Object:  Trigger [dbo].[trg_DebtPayments_PreventChangeFixedData]    Script Date: 13/11/2025 7:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_DebtPayments_PreventChangeFixedData]'))
EXEC dbo.sp_executesql @statement = N'CREATE  TRIGGER [dbo].[trg_DebtPayments_PreventChangeFixedData] ON [dbo].[DebtPayments]
AFTER UPDATE
AS
BEGIN

	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.MainTransactionID = d.MainTransactionID
		WHERE (i.DebtID <> d.DebtID) OR (i.IsLending <> d.IsLending))
		THROW 51023,N''غير مسموح بتغيير سند الدين التابع له معاملة السداد / نوع الدين !'',6; 
END;
' 
GO
ALTER TABLE [dbo].[DebtPayments] ENABLE TRIGGER [trg_DebtPayments_PreventChangeFixedData]
GO
/****** Object:  Trigger [dbo].[trg_DeleteMainTransactionAfterDeleteDebtPayment]    Script Date: 13/11/2025 7:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_DeleteMainTransactionAfterDeleteDebtPayment]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_DeleteMainTransactionAfterDeleteDebtPayment] ON [dbo].[DebtPayments]
AFTER DELETE
AS
BEGIN
	DELETE MainTransactions FROM MainTransactions mt INNER JOIN deleted d ON d.MainTransactionID = mt.TransactionID;
END
' 
GO
ALTER TABLE [dbo].[DebtPayments] ENABLE TRIGGER [trg_DeleteMainTransactionAfterDeleteDebtPayment]
GO
/****** Object:  Trigger [dbo].[trg_MakeDebtRemaintAmount_AfterInsert_Delete_DebtPayment]    Script Date: 13/11/2025 7:33:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeDebtRemaintAmount_AfterInsert_Delete_DebtPayment]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_MakeDebtRemaintAmount_AfterInsert_Delete_DebtPayment] ON [dbo].[DebtPayments]
AFTER INSERT,DELETE
AS
BEGIN
	WITH ChangedDebts AS
		(
			SELECT DebtID FROM  inserted 

			UNION 

			SELECT DebtID FROM  deleted 
		),
		DebtTransactions AS
		(
			SELECT d.DebtID,SUM(ABS(mt.Amount)) as DebtValue FROM Debts d INNER JOIN ChangedDebts cd ON d.DebtID = cd.DebtID
			INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID GROUP BY d.DebtID
		),
		DebtPaymentTransactions AS
		(
			SELECT d.DebtID,(-1 * ABS((SUM(mt.Amount)))) as DebtPaidValue FROM DebtPayments d INNER JOIN ChangedDebts cd ON d.DebtID = cd.DebtID
			INNER JOIN MainTransactions mt ON d.MainTransactionID = mt.TransactionID GROUP BY d.DebtID
		),
		AllChangedDebtsWithPayment AS
		(
			SELECT d.DebtID,d.DebtValue  FROM DebtTransactions d

			UNION ALL

			SELECT d.DebtID,d.DebtPaidValue FROM DebtPaymentTransactions d
		),
		ChangedDebtsWithRemaningAmount AS
		(
			SELECT acdwp.DebtID,SUM(acdwp.DebtValue) AS RemainingAmount
			FROM AllChangedDebtsWithPayment acdwp GROUP BY acdwp.DebtID
		)
		UPDATE Debts
		SET RemainingAmount = ISNULL(cdwra.RemainingAmount,0)
		FROM ChangedDebtsWithRemaningAmount cdwra INNER JOIN Debts d ON d.DebtID = cdwra.DebtID
END
' 
GO
ALTER TABLE [dbo].[DebtPayments] ENABLE TRIGGER [trg_MakeDebtRemaintAmount_AfterInsert_Delete_DebtPayment]
GO
/****** Object:  Trigger [dbo].[trg_Debts_MakeIsLockedConsistent]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_Debts_MakeIsLockedConsistent]'))
EXEC dbo.sp_executesql @statement = N'
CREATE   TRIGGER [dbo].[trg_Debts_MakeIsLockedConsistent] ON [dbo].[Debts]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsLocked)
	BEGIN
		WITH ChangedDebts AS
		(
			SELECT i.DebtID,i.DebtTransactionID,i.IsLocked FROM inserted i INNER JOIN deleted d
			ON i.DebtID = d.DebtID AND i.IsLocked <> d.IsLocked
		),
		AffectedTransactions AS
		(
			SELECT mt.TransactionID,mt.IsLocked AS TransactionIsLocked,cd.IsLocked AS DebtIsLocked FROM ChangedDebts cd
			INNER JOIN MainTransactions mt ON cd.DebtTransactionID = mt.TransactionID AND cd.IsLocked <> mt.IsLocked

			UNION ALL

			SELECT mt.TransactionID,mt.IsLocked AS TransactionIsLocked,cd.IsLocked AS DebtIsLocked
			FROM ChangedDebts cd INNER JOIN DebtPayments dp ON cd.DebtID = dp.DebtID
			INNER JOIN  MainTransactions mt ON dp.MainTransactionID = mt.TransactionID AND cd.IsLocked <> mt.IsLocked
		)
		UPDATE MainTransactions 
		SET IsLocked = at.DebtIsLocked
		FROM AffectedTransactions at INNER JOIN MainTransactions mt ON at.TransactionID = mt.TransactionID
	END
END
' 
GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [trg_Debts_MakeIsLockedConsistent]
GO
/****** Object:  Trigger [dbo].[trg_Debts_PreventChangeFixedData]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_Debts_PreventChangeFixedData]'))
EXEC dbo.sp_executesql @statement = N'
CREATE   TRIGGER [dbo].[trg_Debts_PreventChangeFixedData] ON [dbo].[Debts]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsLending) OR UPDATE(PersonID) OR UPDATE(DebtTransactionID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.DebtID = d.DebtID
			WHERE i.IsLending <> d.IsLending OR i.PersonID <> d.PersonID OR i.DebtTransactionID <> d.DebtTransactionID)
			THROW 51023,N''غير مسموح بتغيير نوع الدين \ معرف الشخص \ معرف معاملة الدين'',6; 
	END
END;
' 
GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [trg_Debts_PreventChangeFixedData]
GO
/****** Object:  Trigger [dbo].[trg_Debts_PreventUpdateItLocked]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_Debts_PreventUpdateItLocked]'))
EXEC dbo.sp_executesql @statement = N'
CREATE   TRIGGER [dbo].[trg_Debts_PreventUpdateItLocked] ON [dbo].[Debts]
AFTER UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.DebtID = d.DebtID WHERE i.IsLocked = 1 AND d.IsLocked = 1
			AND (i.PaymentDueDate <> d.PaymentDueDate))
	BEGIN;
		THROW 51025,N''سند الدين هذا مغلق ممنوع تعديل البيانات'',3;
	END
END' 
GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [trg_Debts_PreventUpdateItLocked]
GO
/****** Object:  Trigger [dbo].[trg_DeleteDebtTransactionAfterDeleteDebt]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_DeleteDebtTransactionAfterDeleteDebt]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_DeleteDebtTransactionAfterDeleteDebt] ON [dbo].[Debts]
AFTER DELETE
AS
BEGIN
	DELETE MainTransactions FROM MainTransactions mt INNER JOIN deleted d ON d.DebtTransactionID = mt.TransactionID;
END

' 
GO
ALTER TABLE [dbo].[Debts] ENABLE TRIGGER [trg_DeleteDebtTransactionAfterDeleteDebt]
GO
/****** Object:  Trigger [dbo].[trg_CheckMonthlyBadgetIsEnabledOnlyForMainCategory]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_CheckMonthlyBadgetIsEnabledOnlyForMainCategory]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_CheckMonthlyBadgetIsEnabledOnlyForMainCategory] ON [dbo].[IncomeAndExpenseCategories]
AFTER INSERT,UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i WHERE NOT (i.ParentCategoryID IS NULL AND i.IsIncome = 0) AND i.MonthlyBudget IS NOT NULL)
		THROW 51032, N''غير مسموح إلا للفئات الرئيسية من نوع مصروفات بأن يكون لها ميزانية شهرية.'', 7;
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_CheckMonthlyBadgetIsEnabledOnlyForMainCategory]
GO
/****** Object:  Trigger [dbo].[trg_ConfirmsThatTheParentIsActiveWhenDeActive]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_ConfirmsThatTheParentIsActiveWhenDeActive]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_ConfirmsThatTheParentIsActiveWhenDeActive] ON [dbo].[IncomeAndExpenseCategories]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsActive) AND EXISTS (SELECT 1 FROM inserted i INNER JOIN IncomeAndExpenseCategories pc 
		ON i.ParentCategoryID = pc.CategoryID WHERE i.IsActive = 1 AND pc.IsActive = 0)
	BEGIN;
		THROW 51034,N''الفئة التابعة لها هذه الفئة غير فعالة ; غير مسموح بتفعيل هذه الفئة'',3;
	END
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_ConfirmsThatTheParentIsActiveWhenDeActive]
GO
/****** Object:  Trigger [dbo].[trg_DeActiveSonsCategoriesBasedOnParent]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_DeActiveSonsCategoriesBasedOnParent]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_DeActiveSonsCategoriesBasedOnParent] ON [dbo].[IncomeAndExpenseCategories]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsActive)
	BEGIN
		WITH AffectedCategories AS
		(
			SELECT i.CategoryID,i.IsActive FROM inserted i INNER JOIN deleted d ON i.CategoryID = d.CategoryID
			WHERE i.IsActive = 0 AND d.IsActive = 1

			UNION ALL

			SELECT c.CategoryID,c.IsActive FROM IncomeAndExpenseCategories c INNER JOIN AffectedCategories ac ON c.ParentCategoryID = ac.CategoryID
		)
		UPDATE IncomeAndExpenseCategories
		SET IsActive = 0
		FROM IncomeAndExpenseCategories c INNER JOIN AffectedCategories ac ON c.CategoryID = ac.CategoryID
		WHERE c.IsActive = 1;

	END
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_DeActiveSonsCategoriesBasedOnParent]
GO
/****** Object:  Trigger [dbo].[trg_EnsureParentCategoryIDConsistency]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_EnsureParentCategoryIDConsistency]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_EnsureParentCategoryIDConsistency] ON [dbo].[IncomeAndExpenseCategories]
AFTER INSERT,UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i WHERE i.CategoryID = i.ParentCategoryID)
		THROW 51030,N''غير مسموح باختيار الفئة نفسها كفئة تابعة.'',3;

	-- cycle reference
	IF EXISTS(SELECT 1 FROM inserted i INNER JOIN IncomeAndExpenseCategories IAEC ON i.CategoryID = IAEC.ParentCategoryID WHERE i.ParentCategoryID = IAEC.CategoryID)
		THROW 51031,N''غير مسموح بعمل استدعاء متكرر بين الفئة المختارة والفئة التابعة .'',3;
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_EnsureParentCategoryIDConsistency]
GO
/****** Object:  Trigger [dbo].[trg_MakeDataConsistecy]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeDataConsistecy]'))
EXEC dbo.sp_executesql @statement = N'
CREATE   TRIGGER [dbo].[trg_MakeDataConsistecy] ON [dbo].[IncomeAndExpenseCategories]
AFTER INSERT,UPDATE
AS
BEGIN
	IF UPDATE(IsIncome) OR UPDATE(AccountID)
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN IncomeAndExpenseCategories pc ON i.ParentCategoryID = pc.CategoryID
			INNER JOIN IncomeAndExpenseCategories mc ON i.MainCategoryID = mc.CategoryID
			WHERE (i.ParentCategoryID IS NOT NULL AND (i.IsIncome <> pc.IsIncome OR i.AccountID <> pc.AccountID))
			OR (i.MainCategoryID IS NOT NULL AND (i.IsIncome <> mc.IsIncome OR i.AccountID <> mc.AccountID)))
			THROW 51027,N''يجب أن تكون الفئة الرئيسة من نفس النوع [إيرادات, مصروفات] ومن نفس الحساب .'',3;
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_MakeDataConsistecy]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeIncomeAndExpenseCategory_IsIncomeColumns]    Script Date: 13/11/2025 7:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeIncomeAndExpenseCategory_IsIncomeColumns]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventChangeIncomeAndExpenseCategory_IsIncomeColumns] ON [dbo].[IncomeAndExpenseCategories]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsIncome)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.CategoryID = d.CategoryID WHERE i.IsIncome <> d.IsIncome)
			THROW 51023,N''غير مسموح بتغيير نوع الفئة'',6;
	END
END;
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_PreventChangeIncomeAndExpenseCategory_IsIncomeColumns]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeIncomeAndExpenseCategory_ParentCategoryColumn]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeIncomeAndExpenseCategory_ParentCategoryColumn]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventChangeIncomeAndExpenseCategory_ParentCategoryColumn] ON [dbo].[IncomeAndExpenseCategories]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(ParentCategoryID) OR UPDATE(MainCategoryID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.CategoryID = d.CategoryID
			WHERE (ISNULL(i.ParentCategoryID,-1) <> ISNULL(d.ParentCategoryID,-1)) 
			OR ((ISNULL(i.MainCategoryID,-1) <> ISNULL(d.MainCategoryID,-1)) AND NOT (i.MainCategoryID IS NOT NULL AND d.MainCategoryID IS NULL)))
			THROW 51023,N''غير مسموح بتغيير مستوى الفئة'',6;
	END
END;
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseCategories] ENABLE TRIGGER [trg_PreventChangeIncomeAndExpenseCategory_ParentCategoryColumn]
GO
/****** Object:  Trigger [dbo].[trg_CheckTheCategoryIsActive]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_CheckTheCategoryIsActive]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_CheckTheCategoryIsActive] ON [dbo].[IncomeAndExpenseTransactions]
AFTER INSERT,UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN IncomeAndExpenseCategories c ON i.CategoryID = c.CategoryID 
	 LEFT JOIN deleted d ON i.MainTransactionID = d.MainTransactionID WHERE c.IsActive = 0 AND i.CategoryID <> d.CategoryID)
		THROW 51028, N''الفئة المختارة موقوفة لا يمكن اختيارها, لتتمكن من اختيارها قم بتفعيلها.'',4;
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_CheckTheCategoryIsActive]
GO
/****** Object:  Trigger [dbo].[trg_CheckTheVoucherAndCategoryIsSameType_IsIncome]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_CheckTheVoucherAndCategoryIsSameType_IsIncome]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_CheckTheVoucherAndCategoryIsSameType_IsIncome] ON [dbo].[IncomeAndExpenseTransactions]
AFTER INSERT,UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN IncomeAndExpenseVouchers v ON i.VoucherID = v.VoucherID
		INNER JOIN IncomeAndExpenseCategories c ON i.CategoryID = c.CategoryID WHERE c.IsIncome <> v.IsIncome)
		THROW 51026, N''يجب أن يكون نوع الفئة للمعاملة من نفس نوع الفئة للمستند'',4;
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_CheckTheVoucherAndCategoryIsSameType_IsIncome]
GO
/****** Object:  Trigger [dbo].[trg_DeleteMaintTransactionsAfterIncomeAndExpenseTransactionDeleted]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_DeleteMaintTransactionsAfterIncomeAndExpenseTransactionDeleted]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_DeleteMaintTransactionsAfterIncomeAndExpenseTransactionDeleted] ON [dbo].[IncomeAndExpenseTransactions]
AFTER DELETE
AS
BEGIN
	DELETE mt FROM MainTransactions mt INNER JOIN deleted d ON d.MainTransactionID = mt.TransactionID;
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_DeleteMaintTransactionsAfterIncomeAndExpenseTransactionDeleted]
GO
/****** Object:  Trigger [dbo].[trg_MakeVouhcerValueConsistent_AfterDelete]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeVouhcerValueConsistent_AfterDelete]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_MakeVouhcerValueConsistent_AfterDelete] ON [dbo].[IncomeAndExpenseTransactions]
AFTER DELETE
AS
BEGIN

	WITH AffectedVouchers AS
	(
		SELECT DISTINCT VoucherID FROM deleted
	),
	 AllVouhcerTransactionsWithSum AS
	(
		SELECT d.VoucherID, SUM(mt.Amount) AS VoucherValue FROM deleted d INNER JOIN IncomeAndExpenseTransactions iet
		ON d.VoucherID = iet.VoucherID INNER JOIN MainTransactions mt ON iet.MainTransactionID = mt.TransactionID
		GROUP BY d.VoucherID 
	)
	UPDATE IncomeAndExpenseVouchers 
	SET VoucherValue = ABS(ISNULL(avtws.VoucherValue,0))
	FROM AffectedVouchers av INNER JOIN IncomeAndExpenseVouchers v ON av.VoucherID = v.VoucherID
	LEFT JOIN  AllVouhcerTransactionsWithSum avtws ON v.VoucherID = avtws.VoucherID
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_MakeVouhcerValueConsistent_AfterDelete]
GO
/****** Object:  Trigger [dbo].[trg_MakeVouhcerValueConsistent_AfterInsert]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeVouhcerValueConsistent_AfterInsert]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_MakeVouhcerValueConsistent_AfterInsert] ON [dbo].[IncomeAndExpenseTransactions]
AFTER INSERT
AS
BEGIN
	WITH ChangedVouchers AS
		(
			SELECT DISTINCT VoucherID FROM inserted 
		),
		AllVouhcerTransactionsWithSum AS
		(
			SELECT cv.VoucherID, SUM(mt.Amount) AS VoucherValue FROM ChangedVouchers cv INNER JOIN IncomeAndExpenseTransactions iet ON cv.VoucherID = iet.VoucherID
			INNER JOIN MainTransactions mt ON iet.MainTransactionID = mt.TransactionID
			GROUP BY cv.VoucherID 
		)
		UPDATE IncomeAndExpenseVouchers 
		SET VoucherValue = ABS(ISNULL(avtws.VoucherValue,0))
		FROM AllVouhcerTransactionsWithSum avtws INNER JOIN IncomeAndExpenseVouchers v ON avtws.VoucherID = v.VoucherID;
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_MakeVouhcerValueConsistent_AfterInsert]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeVoucherID]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeVoucherID]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_PreventChangeVoucherID] ON [dbo].[IncomeAndExpenseTransactions]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(VoucherID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.MainTransactionID = d.MainTransactionID WHERE i.VoucherID <> d.VoucherID)
		BEGIN;
			THROW 51025,N''غير مسموح بتغيير المستند المرتبط به المعاملة.'',3;
		END
	END
END;' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_PreventChangeVoucherID]
GO
/****** Object:  Trigger [dbo].[trg_PreventUpdateIncomeAndExpenseTransactionsIfItLocked]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventUpdateIncomeAndExpenseTransactionsIfItLocked]'))
EXEC dbo.sp_executesql @statement = N'

CREATE TRIGGER [dbo].[trg_PreventUpdateIncomeAndExpenseTransactionsIfItLocked] ON [dbo].[IncomeAndExpenseTransactions]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(CategoryID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.MainTransactionID = d.MainTransactionID  
		INNER JOIN MainTransactions MT ON i.MainTransactionID = MT.TransactionID
		WHERE MT.IsLocked = 1 AND (i.CategoryID <> d.CategoryID))
		BEGIN;
			THROW 51025,N''هذه المعاملة مغلقة, ممنوع تعديل البيانات.'',3;
		END
	END
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseTransactions] ENABLE TRIGGER [trg_PreventUpdateIncomeAndExpenseTransactionsIfItLocked]
GO
/****** Object:  Trigger [dbo].[trg_ConfirmThatIsReturnIsEnabledOnlyWithEXpense]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_ConfirmThatIsReturnIsEnabledOnlyWithEXpense]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_ConfirmThatIsReturnIsEnabledOnlyWithEXpense] ON [dbo].[IncomeAndExpenseVouchers]
AFTER UPDATE,INSERT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i WHERE i.IsIncome <> 0 AND i.IsReturn = 1)
		THROW 51023,N''غير مسموح بإنشاء مرتجع لغير المصروفات .'',6;
END;
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ENABLE TRIGGER [trg_ConfirmThatIsReturnIsEnabledOnlyWithEXpense]
GO
/****** Object:  Trigger [dbo].[trg_MakeIsLockedConsistent]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeIsLockedConsistent]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_MakeIsLockedConsistent] ON [dbo].[IncomeAndExpenseVouchers]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsLocked)
	BEGIN
		WITH CTE AS
		(
			SELECT VoucherID,IsLocked FROM inserted
		)
		UPDATE MainTransactions 
		SET IsLocked = CTE.IsLocked
		FROM IncomeAndExpenseTransactions IET INNER JOIN CTE ON IET.VoucherID = CTE.VoucherID
		INNER JOIN MainTransactions MT ON IET.MainTransactionID = MT.TransactionID
		WHERE MT.IsLocked <> CTE.IsLocked
	END
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ENABLE TRIGGER [trg_MakeIsLockedConsistent]
GO
/****** Object:  Trigger [dbo].[trg_MakeTransactionDateConsistent]    Script Date: 13/11/2025 7:33:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeTransactionDateConsistent]'))
EXEC dbo.sp_executesql @statement = N'

CREATE   TRIGGER [dbo].[trg_MakeTransactionDateConsistent] ON [dbo].[IncomeAndExpenseVouchers]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(VoucherDate)
	BEGIN
		WITH CTE AS
		(
			SELECT VoucherID,VoucherDate FROM inserted
		)
		UPDATE MainTransactions 
		SET TransactionDate = CTE.VoucherDate
		FROM IncomeAndExpenseTransactions IET INNER JOIN CTE ON IET.VoucherID = CTE.VoucherID
		INNER JOIN MainTransactions MT ON MT.TransactionID = IET.MainTransactionID
		WHERE CTE.VoucherDate <> MT.TransactionDate
	END
END' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ENABLE TRIGGER [trg_MakeTransactionDateConsistent]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeVoucher_CategoryType_IsIncomeColumns]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeVoucher_CategoryType_IsIncomeColumns]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventChangeVoucher_CategoryType_IsIncomeColumns] ON [dbo].[IncomeAndExpenseVouchers]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsIncome) OR UPDATE(IsReturn)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.VoucherID = d.VoucherID WHERE i.IsIncome <> d.IsIncome OR i.IsReturn <> d.IsReturn)
			THROW 51023,N''غير مسموح بتغيير نوع الفئة'',6;
	END
END;
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ENABLE TRIGGER [trg_PreventChangeVoucher_CategoryType_IsIncomeColumns]
GO
/****** Object:  Trigger [dbo].[trg_PreventUpdateIncomeAndExpenseVoucherIfItLocked]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventUpdateIncomeAndExpenseVoucherIfItLocked]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventUpdateIncomeAndExpenseVoucherIfItLocked] ON [dbo].[IncomeAndExpenseVouchers]
AFTER UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.VoucherID = d.VoucherID WHERE i.IsLocked = 1 AND d.IsLocked = 1
			AND (i.VoucherName <> d.VoucherName OR i.Notes <> d.Notes
			OR i.CreatedDate <> d.CreatedDate OR i.VoucherDate <> d.VoucherDate OR i.AccountID <> d.AccountID
			OR i.CreatedByUserID <> d.CreatedByUserID OR i.IsIncome <> d.IsIncome))
	BEGIN;
		THROW 51025,N''هذا المستند مغلق ممنوع تعديل البيانات'',3;
	END

	-- is locked be forever can''t open
	--IF EXISTS(SELECT 1 FROM inserted i INNER JOIN deleted d ON i.VoucherID = d.VoucherID
	--	WHERE d.IsLocked = 1 AND (i.VoucherName <> d.VoucherName OR i.Notes <> d.Notes OR i.IsLocked <> d.IsLocked
	--		OR i.CreatedDate <> d.CreatedDate OR i.VoucherDate <> d.VoucherDate OR i.AccountID <> d.AccountID
	--		OR i.CreatedByUserID <> d.CreatedByUserID OR i.IsIncome <> d.IsIncome))
	--BEGIN;
	--	THROW 51025,N''هذا المستند مغلق ممنوع تعديل البيانات'',3;
	--END
END
' 
GO
ALTER TABLE [dbo].[IncomeAndExpenseVouchers] ENABLE TRIGGER [trg_PreventUpdateIncomeAndExpenseVoucherIfItLocked]
GO
/****** Object:  Trigger [dbo].[trg_CheckAllTransactionIsCorrect_AfterInsert_Update]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_CheckAllTransactionIsCorrect_AfterInsert_Update]'))
EXEC dbo.sp_executesql @statement = N'CREATE   TRIGGER [dbo].[trg_CheckAllTransactionIsCorrect_AfterInsert_Update] ON [dbo].[MainTransactions]
AFTER INSERT, UPDATE
AS
BEGIN
	IF EXISTS(SELECT 1 FROM inserted i INNER JOIN Users U ON i.CreatedByUserID = U.UserID WHERE i.AccountID <> U.AccountID)
		THROW 51007,N''يجب أن يكون المستخدم تابع لنفس الأكونت المسجل به'',5;
END
' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_CheckAllTransactionIsCorrect_AfterInsert_Update]
GO
/****** Object:  Trigger [dbo].[trg_MakeDebtRemainingAmountConsistent_AfterUpdate]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeDebtRemainingAmountConsistent_AfterUpdate]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_MakeDebtRemainingAmountConsistent_AfterUpdate] ON [dbo].[MainTransactions]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(Amount) AND EXISTS(SELECT TOP 1 1 FROM inserted i INNER JOIN deleted d ON i.TransactionID = d.TransactionID AND i.Amount <> d.Amount)
	BEGIN
		WITH ChangedDebts AS
		(
			SELECT DebtID FROM Debts d INNER JOIN inserted i ON d.DebtTransactionID = i.TransactionID

			UNION 

			SELECT DebtID FROM DebtPayments d INNER JOIN inserted i ON d.MainTransactionID = i.TransactionID
		),
		DebtTransactions AS
		(
			SELECT d.DebtID,SUM(ABS(mt.Amount)) as DebtValue FROM Debts d INNER JOIN ChangedDebts cd ON d.DebtID = cd.DebtID
			INNER JOIN MainTransactions mt ON d.DebtTransactionID = mt.TransactionID GROUP BY d.DebtID
		),
		DebtPaymentTransactions AS
		(
			SELECT d.DebtID,(-1 * ABS((SUM(mt.Amount)))) as DebtPaidValue FROM DebtPayments d INNER JOIN ChangedDebts cd ON d.DebtID = cd.DebtID
			INNER JOIN MainTransactions mt ON d.MainTransactionID = mt.TransactionID GROUP BY d.DebtID
		),
		AllChangedDebtsWithPayment AS
		(
			SELECT d.DebtID,d.DebtValue  FROM DebtTransactions d

			UNION ALL

			SELECT d.DebtID,d.DebtPaidValue FROM DebtPaymentTransactions d
		),
		ChangedDebtsWithRemaningAmount AS
		(
			SELECT acdwp.DebtID,SUM(acdwp.DebtValue) AS RemainingAmount
			FROM AllChangedDebtsWithPayment acdwp GROUP BY acdwp.DebtID
		)
		UPDATE Debts
		SET RemainingAmount = ISNULL(cdwra.RemainingAmount,0)
		FROM ChangedDebtsWithRemaningAmount cdwra INNER JOIN Debts d ON d.DebtID = cdwra.DebtID
	END
END' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_MakeDebtRemainingAmountConsistent_AfterUpdate]
GO
/****** Object:  Trigger [dbo].[trg_MakeVoucherValuesConsistent_AfterUpdate]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_MakeVoucherValuesConsistent_AfterUpdate]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_MakeVoucherValuesConsistent_AfterUpdate] ON [dbo].[MainTransactions]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(Amount) AND EXISTS(SELECT TOP 1 1 FROM inserted i INNER JOIN deleted d ON i.TransactionID = d.TransactionID AND i.Amount <> d.Amount)
	BEGIN

		WITH ChangedVouchers AS
		(
			SELECT iet.VoucherID FROM IncomeAndExpenseTransactions iet INNER JOIN inserted i ON i.TransactionID = iet.MainTransactionID
		),
		AllVouhcerTransactionsWithSum AS
		(
			SELECT cv.VoucherID, SUM(mt.Amount) AS VoucherValue FROM ChangedVouchers cv INNER JOIN IncomeAndExpenseTransactions iet ON cv.VoucherID = iet.VoucherID
			INNER JOIN MainTransactions mt ON iet.MainTransactionID = mt.TransactionID
			GROUP BY cv.VoucherID 
		)
		UPDATE IncomeAndExpenseVouchers 
		SET VoucherValue = ABS(ISNULL(avtws.VoucherValue,0))
		FROM AllVouhcerTransactionsWithSum avtws INNER JOIN IncomeAndExpenseVouchers v ON avtws.VoucherID = v.VoucherID;
	END
END' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_MakeVoucherValuesConsistent_AfterUpdate]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangeCreatedDateForAllTransactions]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangeCreatedDateForAllTransactions]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventChangeCreatedDateForAllTransactions] ON [dbo].[MainTransactions]
AFTER UPDATE
AS
BEGIN
	IF UPDATE (CreatedDate) OR UPDATE (TransactionTypeID) OR UPDATE (AccountID)
	BEGIN
		IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d 
			ON i.TransactionID = d.TransactionID WHERE i.CreatedDate <> d.CreatedDate
			OR i.TransactionTypeID <> d.TransactionTypeID OR i.AccountID <> d.AccountID)
			 THROW 51013, N''غير مسموح بتغيير (تاريخ الإنشاء / نوع المعاملة / الحساب)'', 8;
	END
END
' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_PreventChangeCreatedDateForAllTransactions]
GO
/****** Object:  Trigger [dbo].[trg_PreventDeleteMainTransactionIfItLocked]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventDeleteMainTransactionIfItLocked]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trg_PreventDeleteMainTransactionIfItLocked] ON [dbo].[MainTransactions]
AFTER DELETE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM deleted WHERE IsLocked = 1 )
	BEGIN;
		THROW 51025,N''المعاملة مغلقة; لا يمكن حذفها !'',3;
	END
END' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_PreventDeleteMainTransactionIfItLocked]
GO
/****** Object:  Trigger [dbo].[trg_PreventUpdateMainTransactionIfItLocked]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventUpdateMainTransactionIfItLocked]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_PreventUpdateMainTransactionIfItLocked] ON [dbo].[MainTransactions]
AFTER UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.TransactionID = d.TransactionID WHERE i.IsLocked = 1 AND d.IsLocked = 1
			AND ((i.Amount <> d.Amount ) OR (i.Purpose <> d.Purpose) OR (i.TransactionDate <> d.TransactionDate)))
	BEGIN;
		THROW 51025,N''هذة المعاملة مغلقة; ممنوع تعديل البيانات'',3;
	END
END;
' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_PreventUpdateMainTransactionIfItLocked]
GO
/****** Object:  Trigger [dbo].[trg_ReCalculateBalanceAfterAnyStatement]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_ReCalculateBalanceAfterAnyStatement]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_ReCalculateBalanceAfterAnyStatement] ON [dbo].[MainTransactions]
AFTER INSERT,UPDATE,Delete
AS
BEGIN
	DECLARE @Accounts TABLE (
		AccountID SMALLINT
	);

	INSERT INTO @Accounts
		SELECT DISTINCT AccountID FROM
		(SELECT AccountID FROM inserted
		 UNION
		 SELECT AccountID FROM deleted
		) AccountsFrominsertedAndDeleted 
		WHERE AccountID IS NOT NULL;

	IF (SELECT COUNT(DISTINCT AccountID) FROM @Accounts) > 1
		THROW 51011,N''غير مسموح بإدخال معاملات لأكثر من حساب بنفس الوقت !'',3;

	DECLARE @TransactionAccountID SMALLINT

	SELECT TOP 1 @TransactionAccountID = AccountID FROM @Accounts;

	IF(@TransactionAccountID IS NOT NULL)
	BEGIN
	EXEC SP_ReCalculateBalanceForAccount
		@AccountID = @TransactionAccountID;
	END
END
' 
GO
ALTER TABLE [dbo].[MainTransactions] ENABLE TRIGGER [trg_ReCalculateBalanceAfterAnyStatement]
GO
/****** Object:  Trigger [dbo].[trg_InsteadOfDeleteUser]    Script Date: 13/11/2025 7:33:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_InsteadOfDeleteUser]'))
EXEC dbo.sp_executesql @statement = N'CREATE   TRIGGER [dbo].[trg_InsteadOfDeleteUser] On [dbo].[Users]
INSTEAD OF DELETE
AS
BEGIN
	
	IF EXISTS (SELECT 1 FROM deleted d INNER JOIN Accounts a ON d.AccountID = a.AccountID WHERE a.IsActive = 0)
	BEGIN
		DELETE Users
		FROM Users U INNER JOIN deleted d
		ON U.UserID = d.UserID
		INNER JOIN Accounts a ON d.AccountID = a.AccountID
		WHERE a.IsActive = 0;
		RETURN;
	END;

	IF EXISTS (SELECT 1 FROM deleted WHERE Permissions IN(-1))
	BEGIN;
		THROW 51000,N''غير مسموح بحذف الأدمن'',1;
	END;

	UPDATE Users SET IsDeleted = 1
	FROM Users U INNER JOIN deleted d
	ON U.UserID = d.UserID
END;
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_InsteadOfDeleteUser]
GO
/****** Object:  Trigger [dbo].[trg_OnlyOneAdminPerAccount]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_OnlyOneAdminPerAccount]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_OnlyOneAdminPerAccount] ON [dbo].[Users]
AFTER UPDATE,INSERT
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN deleted d ON i.UserID = d.UserID 
	WHERE i.Permissions = -1 AND d.Permissions <> -1)
	BEGIN
		IF EXISTS (SELECT u.AccountID FROM Users U INNER JOIN inserted i ON u.AccountID = i.AccountID
		WHERE u.Permissions = -1 GROUP BY u.AccountID HAVING COUNT(u.AccountID) > 1)
		BEGIN;
			THROW 51003,''غير مسموح بوجود أكثر من أدمن في النظام'',2;
		END
	END
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_OnlyOneAdminPerAccount]
GO
/****** Object:  Trigger [dbo].[trg_PreventAdminPermissionChange]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventAdminPermissionChange]'))
EXEC dbo.sp_executesql @statement = N'CREATE   TRIGGER [dbo].[trg_PreventAdminPermissionChange] ON [dbo].[Users]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(Permissions)
	BEGIN
		IF EXISTS (SELECT 1 FROM deleted d INNER JOIN inserted i ON d.UserID = i.UserID
		WHERE d.Permissions = -1 AND i.Permissions <> -1)
		BEGIN;
			THROW 51002,N''لا يمكن تغيير صلاحية الأدمن'',2;

		END
	END
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_PreventAdminPermissionChange]
GO
/****** Object:  Trigger [dbo].[trg_PreventChangePersonID]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventChangePersonID]'))
EXEC dbo.sp_executesql @statement = N'
CREATE     TRIGGER [dbo].[trg_PreventChangePersonID] ON [dbo].[Users]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(PersonID)
	BEGIN
		IF EXISTS (SELECT 1 FROM deleted d INNER JOIN inserted i ON d.UserID = i.UserID
		WHERE d.PersonID <> i.PersonID)
		BEGIN;
			THROW 51002,N''لا يمكن تغيير الشخص المرتبط به المستخدم!'',2;

		END
	END
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_PreventChangePersonID]
GO
/****** Object:  Trigger [dbo].[trg_PreventDeActiveAdmin]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventDeActiveAdmin]'))
EXEC dbo.sp_executesql @statement = N'CREATE   TRIGGER [dbo].[trg_PreventDeActiveAdmin] ON [dbo].[Users]
AFTER UPDATE
AS
BEGIN
	IF UPDATE(IsActive)
	BEGIN
		IF EXISTS (SELECT 1 FROM deleted d INNER JOIN inserted i ON d.UserID = i.UserID
		WHERE d.Permissions = -1 AND i.IsActive = 0)
		BEGIN;
			THROW 51002,N''لا يمكن إيقاف الأدمن'',2;

		END
	END
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_PreventDeActiveAdmin]
GO
/****** Object:  Trigger [dbo].[trg_PreventDeleteAdminUsingIsDeletedColumn]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_PreventDeleteAdminUsingIsDeletedColumn]'))
EXEC dbo.sp_executesql @statement = N'CREATE   TRIGGER [dbo].[trg_PreventDeleteAdminUsingIsDeletedColumn] ON [dbo].[Users]
AFTER Update
AS
BEGIN
	IF UPDATE(ISDeleted)
	BEGIN
		IF EXISTS (SELECT 1 FROM deleted d INNER JOIN inserted i ON d.UserID = i.UserID
		where d.Permissions = -1 AND i.IsDeleted = 1)
		BEGIN;
			THROW 51000,N''غير مسموح بحذف الأدمن'',1;
		END
	END
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_PreventDeleteAdminUsingIsDeletedColumn]
GO
/****** Object:  Trigger [dbo].[trg_VerifyThatUserAndPersonForSameAccount]    Script Date: 13/11/2025 7:33:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trg_VerifyThatUserAndPersonForSameAccount]'))
EXEC dbo.sp_executesql @statement = N'CREATE TRIGGER [dbo].[trg_VerifyThatUserAndPersonForSameAccount] ON [dbo].[Users]
AFTER INSERT,UPDATE
AS
BEGIN
	IF EXISTS (SELECT 1 FROM inserted i INNER JOIN People ON i.PersonID = People.PersonID WHERE i.AccountID <> People.AccountID)
		THROW 51014,N''يجب أن يكون الشخص والمستخدم من نفس الحساب'',4;
END
' 
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [trg_VerifyThatUserAndPersonForSameAccount]
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Debts', N'COLUMN',N'IsLending'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'إقراض ام اقتراض' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Debts', @level2type=N'COLUMN',@level2name=N'IsLending'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Debts', N'COLUMN',N'DebtTransactionID'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'عند الدين في اول مرة فقط لكل دين ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Debts', @level2type=N'COLUMN',@level2name=N'DebtTransactionID'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IncomeAndExpenseCategories', N'COLUMN',N'MonthlyBudget'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For Parent Only' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IncomeAndExpenseCategories', @level2type=N'COLUMN',@level2name=N'MonthlyBudget'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'IncomeAndExpenseCategories', N'COLUMN',N'IsIncome'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'إيرادات ام مصروفات' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IncomeAndExpenseCategories', @level2type=N'COLUMN',@level2name=N'IsIncome'
GO
USE [master]
GO
ALTER DATABASE [MoneyMindManager] SET  READ_WRITE 
GO
-- insert
USE [MoneyMindManager]
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (1, N'الدينار الكويتي', N'KWD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (2, N'الدينار البحريني', N'BHD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (3, N'ريال سعودي', N'SAR')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (4, N'دينار أردني', N'JOD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (5, N'دينار عراقي', N'IQD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (6, N'درهم إماراتي', N'AED')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (7, N'دينار تونسي', N'TND')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (8, N'ليرة سورية', N'SYP')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (9, N'جنيه مصري', N'EGP')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (10, N'دينار جزائري', N'DZD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (11, N'دينار ليبي', N'LYD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (12, N'جنيه سوداني', N'SDG')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (13, N'دولار أمريكي', N'USD')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (14, N'يورو', N'EUR')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (15, N'جنيه إسترليني', N'GBP')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (16, N'ين ياباني', N'JPY')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (17, N'فرنك سويسري', N'CHF')
GO
INSERT [dbo].[Currencies] ([CurrencyID], [CurrencyName], [CurrencySymbol]) VALUES (18, N'وون كوري', N'KRW')
GO
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
INSERT [dbo].[SystemSettings] ([SettingKey], [SettingValue]) VALUES (N'LastMaintenanceDate', NULL)
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON 
GO
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionName]) VALUES (3, N'ديون')
GO
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionName]) VALUES (5, N'مرتجع مصروفات')
GO
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionName]) VALUES (2, N'مصروفات')
GO
INSERT [dbo].[TransactionTypes] ([TransactionTypeID], [TransactionName]) VALUES (1, N'واردات')
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
GO

