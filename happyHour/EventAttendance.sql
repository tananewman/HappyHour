USE [campus]
GO

/****** Object:  Table [dbo].[EventAttendance]    Script Date: 11/30/2015 9:50:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EventAttendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[EventTitle] [varchar](255) NOT NULL,
	[SessionDesc] [varchar](255) NOT NULL,
	[AttendeeLoginTime] [datetime] NOT NULL,
	[AttendeeName] [varchar](255) NOT NULL,
	[AttendeeSID] [varchar](255) NOT NULL,
	[AttendeeCampusId] [int] NOT NULL,
 CONSTRAINT [PK_EventAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EventAttendance] UNIQUE NONCLUSTERED 
(
	[AttendeeCampusId] ASC,
	[EventTitle] ASC,
	[SessionDesc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


