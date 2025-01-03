
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangLuongNV]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangLuongNV](
	[MaLuong] [int] IDENTITY(1,1000) NOT NULL,
	[TongLuong] [decimal](10, 2) NULL,
	[MaNhanVien] [varchar](10) NULL,
	[MaQuanLy] [varchar](10) NULL,
	[ThangNam] [date] NULL,
	[MaLichLam] [varchar](10) NULL,
 CONSTRAINT [PK__BangLuon__6609A48D7B920F62] PRIMARY KEY CLUSTERED 
(
	[MaLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalamViec]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalamViec](
	[IDCalamViec] [int] IDENTITY(1,1) NOT NULL,
	[TenCa] [nvarchar](100) NULL,
	[ThoiGian] [time](7) NULL,
	[mucluong] [decimal](18, 2) NULL,
 CONSTRAINT [PK__CalamVie__CD76E12AB99D378A] PRIMARY KEY CLUSTERED 
(
	[IDCalamViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietCaLamViec]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietCaLamViec](
	[IdChiTietLichLam] [int] NOT NULL,
	[IDCaLamViec] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietLichLam]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietLichLam](
	[IdChitietLichLam] [int] IDENTITY(1,1) NOT NULL,
	[MaLichLam] [varchar](10) NULL,
	[SoCaCVK] [int] NULL,
	[GioBD] [time](7) NULL,
	[GioKT] [time](7) NULL,
	[LuongLoaiCV] [decimal](10, 2) NULL,
	[NoiLam] [nvarchar](100) NULL,
	[TongSoCaQuyDinh] [int] NULL,
	[MaLoaiCongViec] [varchar](10) NULL,
	[Songuoilam] [int] NULL,
	[SonguoilamCVk] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdChitietLichLam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangKy]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangKy](
	[MaLichLam] [varchar](10) NOT NULL,
	[MaNhanVien] [varchar](10) NOT NULL,
	[ThoiGianDKY] [datetime] NULL,
	[HoanThanh] [bit] NULL,
	[IdDangKy] [int] IDENTITY(1,1) NOT NULL,
	[IDChitietLichLam] [int] NULL,
	[LoaiDangKy] [nvarchar](10) NULL,
	[TrangThaiNhomCa] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDangKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichLam]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichLam](
	[MaLichLam] [varchar](10) NOT NULL,
	[MaQuanLy] [varchar](10) NULL,
	[ThuNgayThangNam] [date] NULL,
	[SoCaQuyDinh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLichLam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiCongViec]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiCongViec](
	[MaLoaiCongViec] [varchar](10) NOT NULL,
	[TenLoaiCongViec] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](100) NULL,
	[CMND] [varchar](12) NOT NULL,
	[SDT] [varchar](15) NOT NULL,
	[Email] [varchar](100) NULL,
	[MaTaiKhoan] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [varchar](10) NOT NULL,
	[TenTaiKhoan] [varchar](50) NOT NULL,
	[MatKhau] [varchar](100) NOT NULL,
	[MaVaiTro] [int] NULL,
	[TrangThai] [varchar](10) NOT NULL,
 CONSTRAINT [PK__TaiKhoan__AD7C6529A731C6D9] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TongLuongALLNV]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TongLuongALLNV](
	[Thang_iD] [date] NOT NULL,
	[TongLuongAllNV] [decimal](15, 2) NULL,
	[MaQuanLy] [varchar](10) NULL,
	[MaLuong] [int] IDENTITY(1,1000) NOT NULL,
 CONSTRAINT [PK__TongLuon__D122B1991FA36065] PRIMARY KEY CLUSTERED 
(
	[Thang_iD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[MaVaiTro] [int] IDENTITY(1,1) NOT NULL,
	[TenVaiTro] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro_PhanQuyen]    Script Date: 26/12/2024 14:55:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro_PhanQuyen](
	[MaVaiTro] [int] NOT NULL,
	[MaQuyen] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVaiTro] ASC,
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BangLuongNV] ON 

INSERT [dbo].[BangLuongNV] ([MaLuong], [TongLuong], [MaNhanVien], [MaQuanLy], [ThangNam], [MaLichLam]) VALUES (38001, CAST(200000.00 AS Decimal(10, 2)), N'NV003', N'NV001', CAST(N'2024-12-25' AS Date), N'LL1111111')
SET IDENTITY_INSERT [dbo].[BangLuongNV] OFF
GO
SET IDENTITY_INSERT [dbo].[CalamViec] ON 

INSERT [dbo].[CalamViec] ([IDCalamViec], [TenCa], [ThoiGian], [mucluong]) VALUES (1, N'Ca 1 Sáng', CAST(N'08:00:00' AS Time), CAST(130000.00 AS Decimal(18, 2)))
INSERT [dbo].[CalamViec] ([IDCalamViec], [TenCa], [ThoiGian], [mucluong]) VALUES (2, N'Ca 2 Sáng', CAST(N'10:00:00' AS Time), CAST(165000.00 AS Decimal(18, 2)))
INSERT [dbo].[CalamViec] ([IDCalamViec], [TenCa], [ThoiGian], [mucluong]) VALUES (3, N'Ca 1 Chiều', CAST(N'14:00:00' AS Time), CAST(130000.00 AS Decimal(18, 2)))
INSERT [dbo].[CalamViec] ([IDCalamViec], [TenCa], [ThoiGian], [mucluong]) VALUES (4, N'Ca 2 Chiều', CAST(N'16:00:00' AS Time), CAST(165000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CalamViec] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietCaLamViec] ON 

INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4206, 1, 5, 1020)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4206, 2, 10, 1027)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4212, 1, 10, 1028)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4212, 2, 20, 1029)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (3189, 1, 10, 1034)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (3189, 2, 20, 1035)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4202, 1, 100, 1036)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4202, 2, 10, 1037)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4203, 3, 10, 1038)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4203, 4, 100, 1039)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4211, 1, 50, 1040)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4211, 4, 50, 1041)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4204, 1, 10, 1042)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4204, 2, 10, 1043)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (4205, 3, 10, 1044)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (2180, 2, 20, 1055)
INSERT [dbo].[ChiTietCaLamViec] ([IdChiTietLichLam], [IDCaLamViec], [SoLuong], [Id]) VALUES (2180, 1, 200, 1056)
SET IDENTITY_INSERT [dbo].[ChiTietCaLamViec] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietLichLam] ON 

INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (2180, N'LL1111111', 100, CAST(N'14:00:00' AS Time), CAST(N'20:50:00' AS Time), CAST(200000.00 AS Decimal(10, 2)), N'sảnh 3', 2000, N'DD', 38, 39)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (3189, N'll123123', 200, CAST(N'12:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(80000.00 AS Decimal(10, 2)), N'lầu 7', 12, N'HC', 800, 13)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4196, N'LL1111111', 100, CAST(N'12:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(350000.00 AS Decimal(10, 2)), N's55', 100, NULL, 10, 100)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4202, N'LL161220', 1, CAST(N'15:00:00' AS Time), CAST(N'20:00:00' AS Time), CAST(1.00 AS Decimal(10, 2)), N's1', 10, N'HC', 10, 2)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4203, N'LL161220', 1, CAST(N'12:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(80000.00 AS Decimal(10, 2)), N's2', 4, N'MS', 35, 1)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4204, N'LL15122024', 3, CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), CAST(30000.00 AS Decimal(10, 2)), N's1', 20, N'DD', 80, 3)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4205, N'LL15122024', 4, CAST(N'15:00:00' AS Time), CAST(N'23:00:00' AS Time), CAST(350000.00 AS Decimal(10, 2)), N's3', 50, N'DD', 10, 4)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4206, N'LL17122', 10, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time), CAST(350000.00 AS Decimal(10, 2)), N's2', 20, N'DB', 12, 11)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4211, N'LL161220', 10, CAST(N'14:00:00' AS Time), CAST(N'23:00:00' AS Time), CAST(80000.00 AS Decimal(10, 2)), N's2', 10, N'DB', 10, 10)
INSERT [dbo].[ChiTietLichLam] ([IdChitietLichLam], [MaLichLam], [SoCaCVK], [GioBD], [GioKT], [LuongLoaiCV], [NoiLam], [TongSoCaQuyDinh], [MaLoaiCongViec], [Songuoilam], [SonguoilamCVk]) VALUES (4212, N'LL17122', 1000, CAST(N'10:00:00' AS Time), CAST(N'20:00:00' AS Time), CAST(40000.00 AS Decimal(10, 2)), N's4', 100, N'HC', 12, 9)
SET IDENTITY_INSERT [dbo].[ChiTietLichLam] OFF
GO
SET IDENTITY_INSERT [dbo].[DangKy] ON 

INSERT [dbo].[DangKy] ([MaLichLam], [MaNhanVien], [ThoiGianDKY], [HoanThanh], [IdDangKy], [IDChitietLichLam], [LoaiDangKy], [TrangThaiNhomCa]) VALUES (N'LL1111111', N'NV001', CAST(N'2024-12-25T21:36:19.663' AS DateTime), 0, 77, 2180, N'PV', N'Đký')
SET IDENTITY_INSERT [dbo].[DangKy] OFF
GO
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL1111111', N'NV001', CAST(N'2025-02-25' AS Date), 12)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'll123123', N'NV001', CAST(N'2024-09-12' AS Date), 30)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL14122025', N'NV001', CAST(N'2024-12-14' AS Date), 10)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL15122024', N'NV001', CAST(N'2024-12-15' AS Date), 10)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL161220', N'NV001', CAST(N'2024-12-16' AS Date), 10)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL17122', N'NV001', CAST(N'2014-02-12' AS Date), 12)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL22222222', N'NV001', CAST(N'2222-02-22' AS Date), 20)
INSERT [dbo].[LichLam] ([MaLichLam], [MaQuanLy], [ThuNgayThangNam], [SoCaQuyDinh]) VALUES (N'LL25122024', N'NV001', CAST(N'2024-12-25' AS Date), 200)
GO
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'DB', N'Dựng bàn')
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'DD', N'Dọn dẹp')
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'HC', N'Hậu cần')
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'KC', N'Khác')
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'MS', N'Mascot')
INSERT [dbo].[LoaiCongViec] ([MaLoaiCongViec], [TenLoaiCongViec]) VALUES (N'PV', N'Phục vụ')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [SDT], [Email], [MaTaiKhoan]) VALUES (N'NV001', N'Nguyễn Văn An', N'123456789', N'0987654321', N'a@gmail.com', N'TK111')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [SDT], [Email], [MaTaiKhoan]) VALUES (N'NV002', N'Tran Thi B', N'987654321', N'0912345678', N'b@gmail.com', N'TK002')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [SDT], [Email], [MaTaiKhoan]) VALUES (N'NV003', N'Le Van C', N'456789123', N'0934567890', N'c@gmail.com', N'TK003')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [SDT], [Email], [MaTaiKhoan]) VALUES (N'NV012', N'Phạm Phúc Khả', N'05120300334', N'0924993500', N'phamphuckha29@gmail.com', N'TK111')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [CMND], [SDT], [Email], [MaTaiKhoan]) VALUES (N'NVO12', N'Phạm A', N'04050450', N'0909296901', N'd@gmail.com', N'TK002')
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (5, N'QuanLyTaiKhoan')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (4, N'SuaBangLuong')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (2, N'SuaLichLam')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (3, N'XemBangLuong')
INSERT [dbo].[PhanQuyen] ([MaQuyen], [TenQuyen]) VALUES (1, N'XemLichLam')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK00000000', N'csdcsdc', N'csdsdcsd', 3, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK001', N'admin123', N'admin123', 1, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK002', N'manager1', N'manager123', 2, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK003', N'employee1', N'emp123', 3, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'Tk013', N'phckha', N'Phukha', 1, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK04', N'nguyentrankha', N'kha', 1, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK111', N'phuckha', N'123', 1, N'Active')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaVaiTro], [TrangThai]) VALUES (N'TK112', N' phamphuckha', N'123', 3, N'Active')
GO
SET IDENTITY_INSERT [dbo].[VaiTro] ON 

INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro]) VALUES (1, N'Admin')
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro]) VALUES (3, N'Employee')
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro]) VALUES (2, N'Manager')
SET IDENTITY_INSERT [dbo].[VaiTro] OFF
GO
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (1, 1)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (1, 2)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (1, 3)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (1, 4)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (1, 5)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (2, 1)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (2, 2)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (2, 3)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (3, 1)
INSERT [dbo].[VaiTro_PhanQuyen] ([MaVaiTro], [MaQuyen]) VALUES (3, 3)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PhanQuye__5637EE7975F67A45]    Script Date: 26/12/2024 14:55:14 ******/
ALTER TABLE [dbo].[PhanQuyen] ADD UNIQUE NONCLUSTERED 
(
	[TenQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TaiKhoan__B106EAF831AA2447]    Script Date: 26/12/2024 14:55:14 ******/
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [UQ__TaiKhoan__B106EAF831AA2447] UNIQUE NONCLUSTERED 
(
	[TenTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VaiTro__1DA55814EC57616D]    Script Date: 26/12/2024 14:55:14 ******/
ALTER TABLE [dbo].[VaiTro] ADD UNIQUE NONCLUSTERED 
(
	[TenVaiTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DangKy] ADD  DEFAULT (getdate()) FOR [ThoiGianDKY]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF__TaiKhoan__TrangT__4316F928]  DEFAULT ('Active') FOR [TrangThai]
GO
ALTER TABLE [dbo].[BangLuongNV]  WITH CHECK ADD  CONSTRAINT [FK__BangLuong__MaNha__59FA5E80] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BangLuongNV] CHECK CONSTRAINT [FK__BangLuong__MaNha__59FA5E80]
GO
ALTER TABLE [dbo].[BangLuongNV]  WITH CHECK ADD  CONSTRAINT [FK_BangLuongNV_LichLam] FOREIGN KEY([MaLichLam])
REFERENCES [dbo].[LichLam] ([MaLichLam])
GO
ALTER TABLE [dbo].[BangLuongNV] CHECK CONSTRAINT [FK_BangLuongNV_LichLam]
GO
ALTER TABLE [dbo].[ChiTietCaLamViec]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietCa__IDCaL__2A164134] FOREIGN KEY([IDCaLamViec])
REFERENCES [dbo].[CalamViec] ([IDCalamViec])
GO
ALTER TABLE [dbo].[ChiTietCaLamViec] CHECK CONSTRAINT [FK__ChiTietCa__IDCaL__2A164134]
GO
ALTER TABLE [dbo].[ChiTietCaLamViec]  WITH CHECK ADD FOREIGN KEY([IdChiTietLichLam])
REFERENCES [dbo].[ChiTietLichLam] ([IdChitietLichLam])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietLichLam]  WITH CHECK ADD FOREIGN KEY([MaLichLam])
REFERENCES [dbo].[LichLam] ([MaLichLam])
GO
ALTER TABLE [dbo].[ChiTietLichLam]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietLichLam_LoaiCongViec] FOREIGN KEY([MaLoaiCongViec])
REFERENCES [dbo].[LoaiCongViec] ([MaLoaiCongViec])
GO
ALTER TABLE [dbo].[ChiTietLichLam] CHECK CONSTRAINT [FK_ChiTietLichLam_LoaiCongViec]
GO
ALTER TABLE [dbo].[DangKy]  WITH CHECK ADD FOREIGN KEY([MaLichLam])
REFERENCES [dbo].[LichLam] ([MaLichLam])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DangKy]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DangKy]  WITH CHECK ADD  CONSTRAINT [FK_DangKy_ChiTietLichLam] FOREIGN KEY([IDChitietLichLam])
REFERENCES [dbo].[ChiTietLichLam] ([IdChitietLichLam])
GO
ALTER TABLE [dbo].[DangKy] CHECK CONSTRAINT [FK_DangKy_ChiTietLichLam]
GO
ALTER TABLE [dbo].[LichLam]  WITH CHECK ADD FOREIGN KEY([MaQuanLy])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__MaTaiK__46E78A0C] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__MaTaiK__46E78A0C]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_VaiTro] FOREIGN KEY([MaVaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_VaiTro]
GO
ALTER TABLE [dbo].[TongLuongALLNV]  WITH CHECK ADD  CONSTRAINT [FK_TongLuongALLNV_BangLuongNV] FOREIGN KEY([MaLuong])
REFERENCES [dbo].[BangLuongNV] ([MaLuong])
GO
ALTER TABLE [dbo].[TongLuongALLNV] CHECK CONSTRAINT [FK_TongLuongALLNV_BangLuongNV]
GO
ALTER TABLE [dbo].[TongLuongALLNV]  WITH CHECK ADD  CONSTRAINT [FK_TongLuongALLNV_NhanVien] FOREIGN KEY([MaQuanLy])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TongLuongALLNV] CHECK CONSTRAINT [FK_TongLuongALLNV_NhanVien]
GO
ALTER TABLE [dbo].[VaiTro_PhanQuyen]  WITH CHECK ADD FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[PhanQuyen] ([MaQuyen])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VaiTro_PhanQuyen]  WITH CHECK ADD FOREIGN KEY([MaVaiTro])
REFERENCES [dbo].[VaiTro] ([MaVaiTro])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [CK__TaiKhoan__TrangT__4222D4EF] CHECK  (([TrangThai]='Inactive' OR [TrangThai]='Active'))
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [CK__TaiKhoan__TrangT__4222D4EF]
GO
