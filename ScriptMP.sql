USE [ProjectA]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 03/05/2019 9:01:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[Id] [int] NOT NULL,
	[Designation] [int] NOT NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created_On] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupEvaluation]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupEvaluation](
	[GroupId] [int] NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupEvaluation] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupProject]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupProject](
	[ProjectId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](30) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAdvisor]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAdvisor](
	[AdvisorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AdvisorRole] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectAdvisor] PRIMARY KEY CLUSTERED 
(
	[AdvisorId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[AAAA]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AAAA] AS  
SELECT FirstName + ' ' + LastName AS  name From Person
Join Advisor On Person.Id = Advisor.Id
WHERE Advisor.Id  NOT IN(SELECT Advisor.Id FROM ProjectAdvisor)
GO
/****** Object:  View [dbo].[BBB]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BBB] AS
SELECT FirstName + ' ' + LastName AS  name , Title From Person
JOIN Advisor ON Person.Id = Advisor.Id
Join ProjectAdvisor ON Advisor.Id = ProjectAdvisor.ProjectId
JOIN Project ON Project.Id = Advisor.Id
GO
/****** Object:  View [dbo].[CCC]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CCC] AS
SELECT FirstName + ' ' + LastName AS  StudentName , RegistrationNo From Person
JOIN Advisor On  Advisor.Id = Person.Id
JOIN ProjectAdvisor ON Advisor.Id = ProjectAdvisor.ProjectId
JOIN Project On ProjectAdvisor.ProjectId = Project.Id
JOIN GroupProject ON GroupProject.GroupId = Project.Id
JOIN [Group] ON GroupProject.GroupId = [Group].Id
JOIN GroupStudent ON [Group].Id = GroupStudent.StudentId
JOIN Student ON Student.Id = GroupStudent.StudentId
GO
/****** Object:  View [dbo].[DDD]    Script Date: 03/05/2019 9:01:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DDD] AS
SELECT CONCAT ( FirstName , ' ' , LastName) AS AdvisorName, COUNT (ProjectId) AS Project_COUN From ProjectAdvisor
JOIN Advisor ON ProjectAdvisor.ProjectId = Advisor.Id
JOIN Person On Person.Id  = Advisor.Id
Group BY CONCAT(FirstName , ' ' , LastName)

GO
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (70, 8, CAST(4567890 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (73, 7, CAST(454 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (74, 9, CAST(454 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (75, 7, CAST(47583485 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (76, 7, CAST(67 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (77, 8, CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (81, 7, CAST(345345 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (82, 9, CAST(34566 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1009, N'shgdashd', 78687, 76667)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1010, N'trhw', 1111, 75648)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1011, N'54543', 19384, 238924)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1012, N'rabeya', 353485, 348248)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1013, N'hamna', 1223, 37234)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1014, N'', 0, 0)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1023, N'rabeya', 789, 6786)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3, CAST(N'1998-12-11' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (4, CAST(N'2007-12-11' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (5, CAST(N'1998-06-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (6, CAST(N'1998-06-11' AS Date))
SET IDENTITY_INSERT [dbo].[Group] OFF
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3, 1009, 123, CAST(N'2008-11-12 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (4, 1009, 1345, CAST(N'1998-11-12 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (5, 1011, 123, CAST(N'1997-11-12 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (6, 5, CAST(N'1997-11-08 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (4, 56, 4, CAST(N'2010-11-04 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (1, N'Male', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (2, N'Female', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (3, N'Active', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (4, N'InActive', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (6, N'Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (7, N'Associate Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (8, N'Assisstant Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (9, N'Lecturer', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (10, N'Industry Professional', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (11, N'Main Advisor', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (12, N'Co-Advisror', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (14, N'Industry Advisor', N'ADVISOR_ROLE')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2, N'hhhh', N'hhhhj', N'8765', N'hgfd', CAST(N'2019-05-12 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (49, N'eer5', N'dfffg6', N'ssdr5', N'ee4', CAST(N'2000-01-12 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (50, N'er', N'rfrer', N'uy6', N'hyt6', CAST(N'1998-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (53, N'sdfhdfhj', N'cvcxnm', N'834834', N'sdhfdsfkh', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (54, N'jsdjfj', N'djdjd', N'234', N'chfsdhfsdjf', CAST(N'2000-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (55, N'dfgfhg', N'sfkfk', N'438568', N'djdjdj', CAST(N'2000-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (56, N'dffg', N'dsfsd', N'546', N'fgfghh', CAST(N'2003-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (57, N'aama', N'haamaa', N'3847576', N'sjdjf', CAST(N'2000-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (59, N'bd', N'bdf', N'875765', N'gfbrd', CAST(N'2009-09-09 12:12:12.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (60, N'xcdgdf', N'dfgdfgfd', N'324234', N'gdfgg', CAST(N'2000-11-12 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (63, N'gfhfghgf', N'xfgff', N'45657567', N'chgfhfgh', CAST(N'2022-01-01 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (64, N'fdgfdgjkhgj', N'rrrtrr', N'kjdh7d7', N'ndhbghd6', CAST(N'2001-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (67, N'bshs', N'hhhs', N'gg5', N'nhsgd', CAST(N'2001-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (68, N'jd', N'ndh', N'ggd5', N'nhhbfd', CAST(N'2008-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (70, N'sejkfsdjgf', N'dfjsdf', N'23434', N'nfhf6', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (71, N'kjsjhst', N'nnshsh', N'nshs6', N'hgs', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (73, N'xfgdf', N'vbcbcv', N'34432423', N'vcvcx', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (74, N'hfghf', N'fgdfgdf', N'dfgdg', N'dgdfgfdg', CAST(N'2030-01-11 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (75, N'jdfsdjfjasd', N'jsdjsdfjds', N'sfsdjfsdj', N'kjsdsjkdjsdf', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (76, N'djfdjfg', N'sdjfdsjf', N'cvcj', N'cjvcvjcj', CAST(N'2000-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (77, N'dfjdfdjg', N'jdfgjf', N'fdsfj', N'xmcxvcm', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (80, N'', N'xcdfewf', N'345345', N'zfdsdsf', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (81, N'fgdfgh', N'jvdfjvd', N'5685468', N'cvmxcv', CAST(N'2090-01-12 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (82, N'rabeya', N'hamood', N'042135', N'dfjkdfjd', CAST(N'2009-01-11 00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (4, N'you are not a good girl', N'good girl')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (6, N'Electrostatic model', N'good')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (7, N'Electrostatic model', N'good')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (10, N'light sensing machinewith fire brigade', N'light sensor')
SET IDENTITY_INSERT [dbo].[Project] OFF
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (70, 4, 14, CAST(N'1998-11-06 00:00:00.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (73, 7, 11, CAST(N'2009-12-12 00:00:00.000' AS DateTime))
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (53, N'4657')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (54, N'hhs')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (55, N'3245')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (56, N'3455')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (57, N'48586876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (59, N'yf')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (60, N'324345')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (63, N'4546')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (64, N'546546456')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (71, N'4657')
ALTER TABLE [dbo].[Advisor]  WITH CHECK ADD  CONSTRAINT [FK_Advisor_Lookup] FOREIGN KEY([Designation])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Advisor] CHECK CONSTRAINT [FK_Advisor_Lookup]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Evaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluation] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Evaluation]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Project]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudents_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudents_Lookup]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Group]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Student]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Lookup] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Lookup] FOREIGN KEY([AdvisorRole])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Project]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeachers_Teacher] FOREIGN KEY([AdvisorId])
REFERENCES [dbo].[Advisor] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectTeachers_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
/****** Object:  StoredProcedure [dbo].[EEE]    Script Date: 03/05/2019 9:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EEE] 
      @GroupID int
AS SELECT Name As [Evaluation ,Title] , TotalMarks , ObtainedMarks
From Evaluation Join GroupEvaluation On Evaluation.Id = GroupEvaluation.EvaluationId
Where GroupEvaluation.GroupId = @GroupID 
GO
/****** Object:  StoredProcedure [dbo].[FFF]    Script Date: 03/05/2019 9:01:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FFF]
    @add nvarchar(30)
AS SELECT FirstName  As StudentName , StudentId , [Group].Id From Person
JOIN Advisor On Person.Id  = Advisor.Id
JOIN ProjectAdvisor ON Advisor.Id = ProjectAdvisor.AdvisorId
JOIN Project ON ProjectAdvisor.AdvisorId = Project.Id
JOIN GroupProject On GroupProject.ProjectId = Project.Id
JOIN [Group] ON [Group].Id = GroupProject.ProjectId
JOIN GroupStudent ON [Group].Id = GroupStudent.GroupId
JOIN Student On GroupStudent.GroupId = Student.Id
--JOIN Person On Student.Id = Person.Id
WHERE FirstName = @add AND GroupStudent.Status = 3
GO
