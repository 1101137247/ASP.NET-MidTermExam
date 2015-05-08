
CREATE DATABASE [YoSchema]
GO


USE [YoSchema]
GO

CREATE TABLE [dbo].[Course](
	[Course_ID] [nvarchar](20) NOT NULL,
	[Course_Course_Name] [nvarchar](200) NOT NULL,
	[Course_Description] [nvarchar](1000) NOT NULL
) ON [PRIMARY]

GO


INSERT [dbo].[Course] ([Course_ID],[Course_Course_Name],[Course_Description]) VALUES('1','ASP.NET','很有技術的一門課');
INSERT [dbo].[Course] ([Course_ID],[Course_Course_Name],[Course_Description]) VALUES('2','C#','在星期五早上的一門課');
INSERT [dbo].[Course] ([Course_ID],[Course_Course_Name],[Course_Description]) VALUES('3','手機開發應用','在星期四下午的一門課');

GO
