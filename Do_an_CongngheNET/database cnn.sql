-- ============================================================
--   DATABASE QUẢN LÝ KÝ TÚC XÁ (QLKTX) - V4
--   Các sửa đổi so với V3:
--   [FIX-A] Trigger ChuyenPhong: thêm check phòng mới đầy
--   [FIX-B] Trigger XepPhong + ChuyenPhong: thêm check giới tính
--   [FIX-C] CHECK constraints cho TrangThai (Phong, KhuNha, HoaDon, DangKy)
--   [FIX-D] Dataset: chỉ 5 SV trả phòng, 15 SV vẫn đang ở
--            → vw_SinhVienDangO có dữ liệu phong phú hơn
-- ============================================================

CREATE DATABASE QLKTX
GO
USE QLKTX
GO

/*====================================================
    BẢNG PHÂN QUYỀN
====================================================*/

CREATE TABLE tblVAITRO
(
    MaVaiTro CHAR(5) PRIMARY KEY,
    TenVaiTro NVARCHAR(50),
    MoTa      NVARCHAR(100)
)
GO

CREATE TABLE tblCHUCNANG
(
    MaCN         CHAR(5) PRIMARY KEY,
    TenChucNang  NVARCHAR(100),
    NhomChucNang NVARCHAR(100)
)
GO

/*====================================================
    BẢNG TAIKHOAN
    Lưu ý bảo mật: MatKhau hiện lưu plain text (demo).
    Thực tế sản xuất cần hash bằng BCrypt hoặc SHA-256
    trước khi lưu, không bao giờ so sánh chuỗi thô.
====================================================*/

CREATE TABLE tblTAIKHOAN
(
    MaTK        CHAR(5)      PRIMARY KEY,
    TenDangNhap VARCHAR(50)  UNIQUE,
    MatKhau     VARCHAR(100),
    HoTen       NVARCHAR(100),
    MaVaiTro    CHAR(5),
    ChucVu      NVARCHAR(50),
    SDT         NVARCHAR(15),
    Email       NVARCHAR(100),
    TrangThai   NVARCHAR(50),
    GhiChu      NVARCHAR(200),

    CONSTRAINT FK_TAIKHOAN_VAITRO
        FOREIGN KEY (MaVaiTro) REFERENCES tblVAITRO(MaVaiTro)
)
GO

CREATE TABLE tblPHANQUYEN
(
    MaTK        CHAR(5),
    MaCN        CHAR(5),
    DuocTruyCap BIT,

    PRIMARY KEY (MaTK, MaCN),

    CONSTRAINT FK_PHANQUYEN_TAIKHOAN
        FOREIGN KEY (MaTK) REFERENCES tblTAIKHOAN(MaTK),

    CONSTRAINT FK_PHANQUYEN_CHUCNANG
        FOREIGN KEY (MaCN) REFERENCES tblCHUCNANG(MaCN)
)
GO

/*====================================================
    CÁC BẢNG NGHIỆP VỤ CHÍNH
====================================================*/

CREATE TABLE SinhVien
(
    MaSV      NVARCHAR(10)  PRIMARY KEY,
    HoTen     NVARCHAR(100),
    NgaySinh  DATE,
    GioiTinh  NVARCHAR(10),
    Lop       NVARCHAR(20),
    Khoa      NVARCHAR(50),
    SDT       NVARCHAR(15),
    CCCD      NVARCHAR(20)  CONSTRAINT UQ_SinhVien_CCCD UNIQUE,
    QueQuan   NVARCHAR(100),
    DoiTuong  NVARCHAR(50),
    TrangThai NVARCHAR(50),
    GhiChu    NVARCHAR(200)
)
GO

CREATE TABLE KhuNha
(
    MaKhu       NVARCHAR(10) PRIMARY KEY,
    TenKhu      NVARCHAR(50),
    -- [FIX-C] CHECK TrangThai hợp lệ
    LoaiKhu     NVARCHAR(10),
    SoTang      INT,
    -- Ghi chú: TongSoPhong là dữ liệu tham khảo khi thiết kế khu.
    -- Số phòng thực tế = SELECT COUNT(*) FROM Phong WHERE MaKhu = ...
    TongSoPhong INT,
    TrangThai   NVARCHAR(50) CONSTRAINT CK_KhuNha_TrangThai
                    CHECK (TrangThai IN (N'Đang sử dụng', N'Bảo trì', N'Ngưng sử dụng')),
    GhiChu      NVARCHAR(200)
)
GO

CREATE TABLE Phong
(
    MaPhong        NVARCHAR(10) PRIMARY KEY,
    SoPhong        NVARCHAR(10),
    MaKhu          NVARCHAR(10),
    Tang           INT,
    LoaiPhong      NVARCHAR(50),
    SucChua        INT          CONSTRAINT CK_Phong_SucChua  CHECK (SucChua > 0),
    SoNguoiHienTai INT          CONSTRAINT CK_Phong_SoNguoi  CHECK (SoNguoiHienTai >= 0),
    GiaPhong       BIGINT       CONSTRAINT CK_Phong_GiaPhong CHECK (GiaPhong > 0),
    GioiTinh       NVARCHAR(10),
    -- [FIX-C] CHECK TrangThai hợp lệ
    TrangThai      NVARCHAR(50) CONSTRAINT CK_Phong_TrangThai
                       CHECK (TrangThai IN (N'Trống', N'Còn chỗ', N'Đầy', N'Bảo trì', N'Ngưng sử dụng')),
    GhiChu         NVARCHAR(200),

    FOREIGN KEY (MaKhu) REFERENCES KhuNha(MaKhu)
)
GO

CREATE TABLE DangKy
(
    MaDangKy       NVARCHAR(10) PRIMARY KEY,
    MaSV           NVARCHAR(10),
    NgayDangKy     DATE,
    HocKy          NVARCHAR(20),
    NamHoc         NVARCHAR(20),
    LoaiPhongMuon  NVARCHAR(50),
    DoiTuongUuTien NVARCHAR(50),
    -- [FIX-C] CHECK TrangThaiHoSo hợp lệ
    TrangThaiHoSo  NVARCHAR(50) CONSTRAINT CK_DangKy_TrangThai
                       CHECK (TrangThaiHoSo IN (N'Đã duyệt', N'Chờ duyệt', N'Từ chối')),
    GhiChu         NVARCHAR(200),

    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
)
GO

CREATE TABLE XepPhong
(
    MaXepPhong  NVARCHAR(10) PRIMARY KEY,
    MaDangKy    NVARCHAR(10),
    MaSV        NVARCHAR(10),
    MaPhong     NVARCHAR(10),
    Giuong      NVARCHAR(20),
    NgayVaoO    DATE,
    NgayKetThuc DATE,
    TrangThaiO  NVARCHAR(50) CONSTRAINT CK_XepPhong_TrangThai
                     CHECK (TrangThaiO IN (N'Đang ở', N'Đã trả', N'Chờ xếp')),
    GhiChu      NVARCHAR(200),

    FOREIGN KEY (MaDangKy) REFERENCES DangKy(MaDangKy),
    FOREIGN KEY (MaSV)     REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaPhong)  REFERENCES Phong(MaPhong)
)
GO

CREATE TABLE ChuyenPhong
(
    MaChuyenPhong NVARCHAR(10) PRIMARY KEY,
    MaSV          NVARCHAR(10),
    PhongCu       NVARCHAR(10),
    PhongMoi      NVARCHAR(10),
    NgayChuyen    DATE,
    LyDo          NVARCHAR(200),
    TrangThai     NVARCHAR(50),
    GhiChu        NVARCHAR(200),

    FOREIGN KEY (MaSV)     REFERENCES SinhVien(MaSV),
    FOREIGN KEY (PhongCu)  REFERENCES Phong(MaPhong),
    FOREIGN KEY (PhongMoi) REFERENCES Phong(MaPhong)
)
GO

CREATE TABLE TraPhong
(
    MaTraPhong   NVARCHAR(10) PRIMARY KEY,
    MaSV         NVARCHAR(10),
    MaPhong      NVARCHAR(10),
    Giuong       NVARCHAR(20),
    NgayVaoO     DATE,
    NgayTraPhong DATE,
    LyDoTra      NVARCHAR(200),
    TrangThai    NVARCHAR(50) CONSTRAINT CK_TraPhong_TrangThai
                     CHECK (TrangThai IN (N'Đã trả phòng', N'Chờ trả phòng')),
    GhiChu       NVARCHAR(200),

    FOREIGN KEY (MaSV)    REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
)
GO

/*====================================================
    BẢNG ĐIỆN NƯỚC
====================================================*/

CREATE TABLE DienNuoc
(
    MaPhieu      NVARCHAR(10) PRIMARY KEY,
    MaPhong      NVARCHAR(10),
    Thang        INT          CONSTRAINT CK_DienNuoc_Thang CHECK (Thang BETWEEN 1 AND 12),
    Nam          INT,
    ChiSoDienCu  INT,
    ChiSoDienMoi INT,
    DienTieuThu  AS (ChiSoDienMoi - ChiSoDienCu),
    ChiSoNuocCu  INT,
    ChiSoNuocMoi INT,
    NuocTieuThu  AS (ChiSoNuocMoi - ChiSoNuocCu),
    TienDien     BIGINT,
    TienNuoc     BIGINT,
    TongTien     AS (TienDien + TienNuoc),
    GhiChu       NVARCHAR(200),

    CONSTRAINT CK_DienNuoc_Dien CHECK (ChiSoDienMoi >= ChiSoDienCu),
    CONSTRAINT CK_DienNuoc_Nuoc CHECK (ChiSoNuocMoi >= ChiSoNuocCu),

    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
)
GO

CREATE TABLE HoaDon
(
    MaHoaDon          NVARCHAR(10) PRIMARY KEY,
    MaSV              NVARCHAR(10),
    MaPhong           NVARCHAR(10),
    Thang             INT          CONSTRAINT CK_HoaDon_Thang CHECK (Thang BETWEEN 1 AND 12),
    Nam               INT,
    NgayLap           DATE,
    NgayThanhToan     DATE,
    HinhThucThanhToan NVARCHAR(50),
    -- [FIX-C] CHECK TrangThai hoa don
    TrangThai         NVARCHAR(50) CONSTRAINT CK_HoaDon_TrangThai
                          CHECK (TrangThai IN (N'Đã thanh toán', N'Chưa thanh toán', N'Còn nợ')),
    GhiChu            NVARCHAR(200),

    FOREIGN KEY (MaSV)    REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
)
GO

CREATE TABLE ChiTietHoaDon
(
    MaCTHD    NVARCHAR(10) PRIMARY KEY,
    MaHoaDon  NVARCHAR(10),
    MaPhieu   NVARCHAR(10),
    TienPhong BIGINT,
    TienDien  BIGINT,
    TienNuoc  BIGINT,
    PhuPhi    BIGINT,
    TongTien  AS (TienPhong + TienDien + TienNuoc + PhuPhi),

    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaPhieu)  REFERENCES DienNuoc(MaPhieu)
)
GO

/*====================================================
    TRIGGER XẾP PHÒNG
    [FIX-B] Thêm check giới tính
====================================================*/

CREATE TRIGGER trg_XepPhong_Insert
ON XepPhong
AFTER INSERT
AS
BEGIN

    -- 1. Chặn phòng đầy
    IF EXISTS
    (
        SELECT 1
        FROM Phong p
        INNER JOIN inserted i ON p.MaPhong = i.MaPhong
        WHERE p.SoNguoiHienTai >= p.SucChua
          AND i.TrangThaiO = N'Đang ở'
    )
    BEGIN
        RAISERROR (N'Phòng đã đầy', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- 2. [FIX-B] Chặn sai giới tính
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        INNER JOIN SinhVien sv ON i.MaSV    = sv.MaSV
        INNER JOIN Phong    p  ON i.MaPhong = p.MaPhong
        WHERE sv.GioiTinh <> p.GioiTinh
          AND i.TrangThaiO = N'Đang ở'
    )
    BEGIN
        RAISERROR (N'Giới tính sinh viên không phù hợp với phòng', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- 3. Chặn SV đang ở nhiều phòng
    IF EXISTS
    (
        SELECT 1
        FROM XepPhong xp
        INNER JOIN inserted i ON xp.MaSV = i.MaSV
        WHERE xp.TrangThaiO  = N'Đang ở'
          AND i.TrangThaiO   = N'Đang ở'
          AND xp.MaXepPhong <> i.MaXepPhong
    )
    BEGIN
        RAISERROR (N'Sinh viên đã đang ở phòng khác', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- 4. Cập nhật số người + trạng thái phòng
    UPDATE p
    SET
        p.SoNguoiHienTai = p.SoNguoiHienTai + 1,
        p.TrangThai = CASE
            WHEN p.SoNguoiHienTai + 1 >= p.SucChua THEN N'Đầy'
            ELSE N'Còn chỗ'
        END
    FROM Phong p
    INNER JOIN inserted i ON p.MaPhong = i.MaPhong
    WHERE i.TrangThaiO = N'Đang ở'

END
GO

/*====================================================
    TRIGGER TRẢ PHÒNG
====================================================*/

CREATE TRIGGER trg_TraPhong_Insert
ON TraPhong
AFTER INSERT
AS
BEGIN

    -- 1. Kiểm tra SV có đang ở không
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        WHERE i.TrangThai = N'Đã trả phòng'
          AND NOT EXISTS
          (
              SELECT 1
              FROM XepPhong xp
              WHERE xp.MaSV      = i.MaSV
                AND xp.MaPhong   = i.MaPhong
                AND xp.TrangThaiO = N'Đang ở'
          )
    )
    BEGIN
        RAISERROR (N'Sinh viên không đang ở phòng này', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- 2. Giảm số người phòng
    UPDATE p
    SET
        p.SoNguoiHienTai = CASE
            WHEN p.SoNguoiHienTai - 1 < 0 THEN 0
            ELSE p.SoNguoiHienTai - 1
        END,
        p.TrangThai = CASE
            WHEN p.SoNguoiHienTai - 1 <= 0          THEN N'Trống'
            WHEN p.SoNguoiHienTai - 1 < p.SucChua   THEN N'Còn chỗ'
            ELSE N'Đầy'
        END
    FROM Phong p
    INNER JOIN inserted i ON p.MaPhong = i.MaPhong
    WHERE i.TrangThai = N'Đã trả phòng'

    -- 3. Cập nhật XepPhong
    UPDATE xp
    SET
        xp.TrangThaiO  = N'Đã trả',
        xp.NgayKetThuc = i.NgayTraPhong
    FROM XepPhong xp
    INNER JOIN inserted i
        ON xp.MaSV    = i.MaSV
       AND xp.MaPhong = i.MaPhong
    WHERE xp.TrangThaiO = N'Đang ở'

END
GO

/*====================================================
    TRIGGER CHUYỂN PHÒNG
    [FIX-A] Thêm check phòng mới đầy
    [FIX-B] Thêm check giới tính phòng mới
====================================================*/

CREATE TRIGGER trg_ChuyenPhong_Insert
ON ChuyenPhong
AFTER INSERT
AS
BEGIN

    -- [FIX-A] 1. Chặn phòng mới đầy
    IF EXISTS
    (
        SELECT 1
        FROM Phong p
        INNER JOIN inserted i ON p.MaPhong = i.PhongMoi
        WHERE p.SoNguoiHienTai >= p.SucChua
          AND i.TrangThai = N'Đã chuyển'
    )
    BEGIN
        RAISERROR (N'Phòng mới đã đầy, không thể chuyển', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- [FIX-B] 2. Chặn sai giới tính phòng mới
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        INNER JOIN SinhVien sv ON i.MaSV     = sv.MaSV
        INNER JOIN Phong    p  ON i.PhongMoi = p.MaPhong
        WHERE sv.GioiTinh <> p.GioiTinh
          AND i.TrangThai  = N'Đã chuyển'
    )
    BEGIN
        RAISERROR (N'Giới tính sinh viên không phù hợp với phòng mới', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- 3. Giảm số người phòng cũ
    UPDATE p
    SET
        p.SoNguoiHienTai = CASE
            WHEN p.SoNguoiHienTai - 1 < 0 THEN 0
            ELSE p.SoNguoiHienTai - 1
        END,
        p.TrangThai = CASE
            WHEN p.SoNguoiHienTai - 1 <= 0         THEN N'Trống'
            WHEN p.SoNguoiHienTai - 1 < p.SucChua  THEN N'Còn chỗ'
            ELSE N'Đầy'
        END
    FROM Phong p
    INNER JOIN inserted i ON p.MaPhong = i.PhongCu
    WHERE i.TrangThai = N'Đã chuyển'

    -- 4. Tăng số người phòng mới
    UPDATE p
    SET
        p.SoNguoiHienTai = p.SoNguoiHienTai + 1,
        p.TrangThai = CASE
            WHEN p.SoNguoiHienTai + 1 >= p.SucChua THEN N'Đầy'
            ELSE N'Còn chỗ'
        END
    FROM Phong p
    INNER JOIN inserted i ON p.MaPhong = i.PhongMoi
    WHERE i.TrangThai = N'Đã chuyển'

    -- 5. Update XepPhong
    UPDATE xp
    SET xp.MaPhong = i.PhongMoi
    FROM XepPhong xp
    INNER JOIN inserted i ON xp.MaSV = i.MaSV
    WHERE xp.TrangThaiO = N'Đang ở'
      AND i.TrangThai   = N'Đã chuyển'

END
GO

/*====================================================
    INSERT DỮ LIỆU VAI TRÒ
====================================================*/

INSERT INTO tblVAITRO VALUES
('VT001', N'Admin',        N'Quản trị hệ thống'),
('VT002', N'QL Sinh viên', N'Quản lý sinh viên'),
('VT003', N'Kế toán',      N'Quản lý thu chi'),
('VT004', N'QL Phòng',     N'Quản lý phòng ký túc xá')
GO

/*====================================================
    INSERT DỮ LIỆU CHỨC NĂNG
====================================================*/

INSERT INTO tblCHUCNANG VALUES
('CN001', N'Xem thông tin sinh viên',  N'Quản lý Sinh viên'),
('CN002', N'Thêm sinh viên',           N'Quản lý Sinh viên'),
('CN003', N'Sửa hồ sơ sinh viên',      N'Quản lý Sinh viên'),
('CN004', N'Quản lý phòng',            N'Quản lý Phòng & Khu nhà'),
('CN005', N'Quản lý khu nhà',          N'Quản lý Phòng & Khu nhà'),
('CN006', N'Lập hóa đơn',              N'Quản lý Thu/Chi & Hóa đơn'),
('CN007', N'Thanh toán hóa đơn',       N'Quản lý Thu/Chi & Hóa đơn'),
('CN008', N'Quản lý cơ sở vật chất',   N'Quản lý Cơ sở vật chất'),
('CN009', N'Quản lý vi phạm',          N'Quản lý Vi phạm & Kỷ luật'),
('CN010', N'Xem báo cáo thống kê',     N'Báo cáo & Thống kê'),
('CN011', N'Phân quyền hệ thống',      N'Cài đặt hệ thống & Phân quyền')
GO

/*====================================================
    INSERT DỮ LIỆU TÀI KHOẢN
====================================================*/

INSERT INTO tblTAIKHOAN (MaTK, TenDangNhap, MatKhau, HoTen, MaVaiTro, ChucVu, SDT, Email, TrangThai, GhiChu)
VALUES
('TK001', 'admin',       '123', N'Nguyễn Văn An',    'VT001', N'Quản trị viên',     '0901000001', 'admin@ktx.com',  N'Hoạt động', N'Tài khoản quản trị'),
('TK002', 'ql_sinhvien', '123', N'Trần Thị Bình',    'VT002', N'Nhân viên quản lý', '0901000003', 'nv01@ktx.com',   N'Hoạt động', N''),
('TK003', 'ketoan_ktx',  '123', N'Lê Văn Kế Toán',   'VT003', N'Kế toán',           '0901000011', 'kt01@ktx.com',   N'Hoạt động', N''),
('TK004', 'ql_phong',    '123', N'Phạm Minh Đức',    'VT004', N'Quản lý khu',       '0901000016', 'ql01@ktx.com',   N'Hoạt động', N''),
('TK005', 'admin2',      '123', N'Lê Quốc Trung',    'VT001', N'Quản trị viên',     '0901000002', 'admin2@ktx.com', N'Hoạt động', N''),
('TK006', 'nv02',        '123', N'Phạm Quốc Huy',    'VT002', N'Nhân viên quản lý', '0901000004', 'nv02@ktx.com',   N'Hoạt động', N''),
('TK007', 'nv03',        '123', N'Nguyễn Thị Hà',    'VT002', N'Nhân viên quản lý', '0901000005', 'nv03@ktx.com',   N'Hoạt động', N''),
('TK008', 'nv04',        '123', N'Đặng Văn Phúc',    'VT002', N'Nhân viên quản lý', '0901000006', 'nv04@ktx.com',   N'Hoạt động', N''),
('TK009', 'nv05',        '123', N'Bùi Thu Trang',    'VT002', N'Nhân viên quản lý', '0901000007', 'nv05@ktx.com',   N'Khóa',      N'Tạm khóa'),
('TK010', 'nv06',        '123', N'Ngô Văn Hải',      'VT002', N'Nhân viên quản lý', '0901000008', 'nv06@ktx.com',   N'Hoạt động', N''),
('TK011', 'nv07',        '123', N'Hoàng Đức Long',   'VT002', N'Nhân viên quản lý', '0901000009', 'nv07@ktx.com',   N'Hoạt động', N''),
('TK012', 'nv08',        '123', N'Lý Thị Mai',       'VT002', N'Nhân viên quản lý', '0901000010', 'nv08@ktx.com',   N'Hoạt động', N''),
('TK013', 'kt02',        '123', N'Trịnh Văn Minh',   'VT003', N'Kế toán',           '0901000012', 'kt02@ktx.com',   N'Hoạt động', N''),
('TK014', 'kt03',        '123', N'Ngô Thị Liên',     'VT003', N'Kế toán',           '0901000013', 'kt03@ktx.com',   N'Hoạt động', N''),
('TK015', 'kt04',        '123', N'Vũ Thị Nhung',     'VT003', N'Kế toán',           '0901000014', 'kt04@ktx.com',   N'Hoạt động', N''),
('TK016', 'kt05',        '123', N'Đỗ Văn Tâm',       'VT003', N'Kế toán',           '0901000015', 'kt05@ktx.com',   N'Khóa',      N''),
('TK017', 'ql02',        '123', N'Tạ Thu Hương',     'VT004', N'Quản lý khu',       '0901000017', 'ql02@ktx.com',   N'Hoạt động', N''),
('TK018', 'ql03',        '123', N'Nguyễn Quang Vinh','VT004', N'Quản lý khu',       '0901000018', 'ql03@ktx.com',   N'Hoạt động', N''),
('TK019', 'ql04',        '123', N'Bùi Thanh Tùng',   'VT004', N'Quản lý khu',       '0901000019', 'ql04@ktx.com',   N'Hoạt động', N''),
('TK020', 'ql05',        '123', N'Đào Thị Yến',      'VT004', N'Quản lý khu',       '0901000020', 'ql05@ktx.com',   N'Hoạt động', N'')
GO

/*====================================================
    PHÂN QUYỀN
====================================================*/

INSERT INTO tblPHANQUYEN
SELECT MaTK, MaCN, 1
FROM tblTAIKHOAN, tblCHUCNANG
WHERE MaTK IN ('TK001','TK005')
GO

INSERT INTO tblPHANQUYEN VALUES
('TK002','CN001',1),('TK002','CN002',1),('TK002','CN003',1),('TK002','CN004',0),('TK002','CN005',0),('TK002','CN006',0),('TK002','CN007',0),('TK002','CN008',0),('TK002','CN009',1),('TK002','CN010',1),('TK002','CN011',0),
('TK006','CN001',1),('TK006','CN002',1),('TK006','CN003',1),('TK006','CN004',0),('TK006','CN005',0),('TK006','CN006',0),('TK006','CN007',0),('TK006','CN008',0),('TK006','CN009',1),('TK006','CN010',1),('TK006','CN011',0),
('TK007','CN001',1),('TK007','CN002',1),('TK007','CN003',1),('TK007','CN004',0),('TK007','CN005',0),('TK007','CN006',0),('TK007','CN007',0),('TK007','CN008',0),('TK007','CN009',1),('TK007','CN010',1),('TK007','CN011',0),
('TK008','CN001',1),('TK008','CN002',1),('TK008','CN003',1),('TK008','CN004',0),('TK008','CN005',0),('TK008','CN006',0),('TK008','CN007',0),('TK008','CN008',0),('TK008','CN009',1),('TK008','CN010',1),('TK008','CN011',0),
('TK009','CN001',1),('TK009','CN002',1),('TK009','CN003',1),('TK009','CN004',0),('TK009','CN005',0),('TK009','CN006',0),('TK009','CN007',0),('TK009','CN008',0),('TK009','CN009',1),('TK009','CN010',1),('TK009','CN011',0),
('TK010','CN001',1),('TK010','CN002',1),('TK010','CN003',1),('TK010','CN004',0),('TK010','CN005',0),('TK010','CN006',0),('TK010','CN007',0),('TK010','CN008',0),('TK010','CN009',1),('TK010','CN010',1),('TK010','CN011',0),
('TK011','CN001',1),('TK011','CN002',1),('TK011','CN003',1),('TK011','CN004',0),('TK011','CN005',0),('TK011','CN006',0),('TK011','CN007',0),('TK011','CN008',0),('TK011','CN009',1),('TK011','CN010',1),('TK011','CN011',0),
('TK012','CN001',1),('TK012','CN002',1),('TK012','CN003',1),('TK012','CN004',0),('TK012','CN005',0),('TK012','CN006',0),('TK012','CN007',0),('TK012','CN008',0),('TK012','CN009',1),('TK012','CN010',1),('TK012','CN011',0)
GO

INSERT INTO tblPHANQUYEN VALUES
('TK003','CN001',1),('TK003','CN002',0),('TK003','CN003',0),('TK003','CN004',0),('TK003','CN005',0),('TK003','CN006',1),('TK003','CN007',1),('TK003','CN008',0),('TK003','CN009',0),('TK003','CN010',1),('TK003','CN011',0),
('TK013','CN001',1),('TK013','CN002',0),('TK013','CN003',0),('TK013','CN004',0),('TK013','CN005',0),('TK013','CN006',1),('TK013','CN007',1),('TK013','CN008',0),('TK013','CN009',0),('TK013','CN010',1),('TK013','CN011',0),
('TK014','CN001',1),('TK014','CN002',0),('TK014','CN003',0),('TK014','CN004',0),('TK014','CN005',0),('TK014','CN006',1),('TK014','CN007',1),('TK014','CN008',0),('TK014','CN009',0),('TK014','CN010',1),('TK014','CN011',0),
('TK015','CN001',1),('TK015','CN002',0),('TK015','CN003',0),('TK015','CN004',0),('TK015','CN005',0),('TK015','CN006',1),('TK015','CN007',1),('TK015','CN008',0),('TK015','CN009',0),('TK015','CN010',1),('TK015','CN011',0),
('TK016','CN001',1),('TK016','CN002',0),('TK016','CN003',0),('TK016','CN004',0),('TK016','CN005',0),('TK016','CN006',1),('TK016','CN007',1),('TK016','CN008',0),('TK016','CN009',0),('TK016','CN010',1),('TK016','CN011',0)
GO

INSERT INTO tblPHANQUYEN VALUES
('TK004','CN001',0),('TK004','CN002',0),('TK004','CN003',0),('TK004','CN004',1),('TK004','CN005',1),('TK004','CN006',0),('TK004','CN007',0),('TK004','CN008',1),('TK004','CN009',0),('TK004','CN010',1),('TK004','CN011',0),
('TK017','CN001',0),('TK017','CN002',0),('TK017','CN003',0),('TK017','CN004',1),('TK017','CN005',1),('TK017','CN006',0),('TK017','CN007',0),('TK017','CN008',1),('TK017','CN009',0),('TK017','CN010',1),('TK017','CN011',0),
('TK018','CN001',0),('TK018','CN002',0),('TK018','CN003',0),('TK018','CN004',1),('TK018','CN005',1),('TK018','CN006',0),('TK018','CN007',0),('TK018','CN008',1),('TK018','CN009',0),('TK018','CN010',1),('TK018','CN011',0),
('TK019','CN001',0),('TK019','CN002',0),('TK019','CN003',0),('TK019','CN004',1),('TK019','CN005',1),('TK019','CN006',0),('TK019','CN007',0),('TK019','CN008',1),('TK019','CN009',0),('TK019','CN010',1),('TK019','CN011',0),
('TK020','CN001',0),('TK020','CN002',0),('TK020','CN003',0),('TK020','CN004',1),('TK020','CN005',1),('TK020','CN006',0),('TK020','CN007',0),('TK020','CN008',1),('TK020','CN009',0),('TK020','CN010',1),('TK020','CN011',0)
GO

/*====================================================
    INSERT SINH VIÊN
====================================================*/

INSERT INTO SinhVien VALUES
(N'SV001', N'Nguyễn Văn An',    '2004-01-15', N'Nam', N'CNTT1',  N'Công nghệ thông tin',   N'0911111111', N'001204000001', N'Hà Nội',      N'Bình thường',            N'Đang học', N''),
(N'SV002', N'Trần Thị Bình',    '2004-03-20', N'Nữ',  N'QTKD1',  N'Quản trị kinh doanh',  N'0911111112', N'001204000002', N'Hải Phòng',   N'Hộ nghèo',               N'Đang học', N''),
(N'SV003', N'Lê Minh Châu',     '2004-05-10', N'Nam', N'CNTT2',  N'Công nghệ thông tin',   N'0911111113', N'001204000003', N'Nam Định',    N'Cận nghèo',              N'Đang học', N''),
(N'SV004', N'Phạm Thu Dung',    '2004-07-08', N'Nữ',  N'KT1',    N'Kế toán',              N'0911111114', N'001204000004', N'Thái Bình',   N'Bình thường',            N'Đang học', N''),
(N'SV005', N'Hoàng Gia Huy',    '2004-09-01', N'Nam', N'DTVT1',  N'Điện tử viễn thông',   N'0911111115', N'001204000005', N'Bắc Giang',   N'Vùng sâu vùng xa',       N'Đang học', N''),
(N'SV006', N'Ngô Thị Khánh',    '2004-11-11', N'Nữ',  N'NN1',    N'Ngôn ngữ Anh',         N'0911111116', N'001204000006', N'Nghệ An',     N'Bình thường',            N'Đang học', N''),
(N'SV007', N'Đỗ Văn Long',      '2003-12-12', N'Nam', N'CNTT3',  N'Công nghệ thông tin',   N'0911111117', N'001204000007', N'Thanh Hóa',   N'Con thương binh/liệt sĩ',N'Đang học', N''),
(N'SV008', N'Bùi Thị Mai',      '2004-04-14', N'Nữ',  N'QTKD2',  N'Quản trị kinh doanh',  N'0911111118', N'001204000008', N'Hải Dương',   N'Bình thường',            N'Đang học', N''),
(N'SV009', N'Vũ Đức Nam',       '2004-02-18', N'Nam', N'CK1',    N'Cơ khí',               N'0911111119', N'001204000009', N'Hưng Yên',    N'Bình thường',            N'Đang học', N''),
(N'SV010', N'Phan Thị Oanh',    '2004-06-25', N'Nữ',  N'KT2',    N'Kế toán',              N'0911111120', N'001204000010', N'Ninh Bình',   N'Hộ nghèo',               N'Đang học', N''),
(N'SV011', N'Nguyễn Quốc Bảo', '2004-08-12', N'Nam', N'CNTT4',  N'Công nghệ thông tin',   N'0911111121', N'001204000011', N'Phú Thọ',     N'Bình thường',            N'Đang học', N''),
(N'SV012', N'Lý Thị Cẩm',      '2004-10-03', N'Nữ',  N'KT3',    N'Kế toán',              N'0911111122', N'001204000012', N'Lạng Sơn',    N'Hộ nghèo',               N'Đang học', N''),
(N'SV013', N'Phạm Thành Đạt',  '2004-01-21', N'Nam', N'QTKD3',  N'Quản trị kinh doanh',  N'0911111123', N'001204000013', N'Hà Nam',      N'Bình thường',            N'Đang học', N''),
(N'SV014', N'Vũ Thị Em',        '2004-12-09', N'Nữ',  N'NN2',    N'Ngôn ngữ Anh',         N'0911111124', N'001204000014', N'Tuyên Quang', N'Cận nghèo',              N'Đang học', N''),
(N'SV015', N'Trần Nhật Phong',  '2003-11-30', N'Nam', N'CK2',    N'Cơ khí',               N'0911111125', N'001204000015', N'Bắc Ninh',    N'Bình thường',            N'Đang học', N''),
(N'SV016', N'Hoàng Thị Giang',  '2004-06-16', N'Nữ',  N'QTKD4',  N'Quản trị kinh doanh',  N'0911111126', N'001204000016', N'Quảng Ninh',  N'Bình thường',            N'Đang học', N''),
(N'SV017', N'Đỗ Minh Hiếu',     '2004-03-27', N'Nam', N'DTVT2',  N'Điện tử viễn thông',   N'0911111127', N'001204000017', N'Vĩnh Phúc',   N'Vùng sâu vùng xa',       N'Đang học', N''),
(N'SV018', N'Nguyễn Thị Hồng', '2004-09-18', N'Nữ',  N'KT4',    N'Kế toán',              N'0911111128', N'001204000018', N'Yên Bái',     N'Con thương binh/liệt sĩ',N'Đang học', N''),
(N'SV019', N'Bùi Anh Khoa',     '2004-05-02', N'Nam', N'CNTT5',  N'Công nghệ thông tin',   N'0911111129', N'001204000019', N'Bắc Kạn',    N'Bình thường',            N'Đang học', N''),
(N'SV020', N'Phan Thị Linh',    '2004-07-22', N'Nữ',  N'NN3',    N'Ngôn ngữ Anh',         N'0911111130', N'001204000020', N'Lào Cai',     N'Hộ nghèo',               N'Đang học', N'')
GO

/*====================================================
    INSERT KHU NHÀ
====================================================*/

INSERT INTO KhuNha VALUES
(N'K01', N'Khu A', N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K02', N'Khu B', N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K03', N'Khu C', N'Nam', 4,  8, N'Đang sử dụng', N''),
(N'K04', N'Khu D', N'Nữ',  4,  8, N'Đang sử dụng', N''),
(N'K05', N'Khu E', N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K06', N'Khu F', N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K07', N'Khu G', N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K08', N'Khu H', N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K09', N'Khu I', N'Nam', 4,  8, N'Bảo trì',      N'Sửa điện'),
(N'K10', N'Khu K', N'Nữ',  4,  8, N'Đang sử dụng', N''),
(N'K11', N'Khu L', N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K12', N'Khu M', N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K13', N'Khu N', N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K14', N'Khu O', N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K15', N'Khu P', N'Nam', 4,  8, N'Đang sử dụng', N''),
(N'K16', N'Khu Q', N'Nữ',  4,  8, N'Ngưng sử dụng',N'Tạm đóng'),
(N'K17', N'Khu R', N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K18', N'Khu S', N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K19', N'Khu T', N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K20', N'Khu U', N'Nữ',  5, 10, N'Đang sử dụng', N'')
GO

/*====================================================
    INSERT PHÒNG
    SoNguoiHienTai = 0 toàn bộ, trigger tự tăng
====================================================*/

INSERT INTO Phong VALUES
(N'P001', N'A101', N'K01', 1, N'Phòng 4 người', 4, 0, 500000, N'Nam', N'Trống',         N''),
(N'P002', N'A102', N'K01', 1, N'Phòng 4 người', 4, 0, 500000, N'Nam', N'Trống',         N''),
(N'P003', N'B101', N'K02', 1, N'Phòng 4 người', 4, 0, 500000, N'Nữ',  N'Trống',         N''),
(N'P004', N'B102', N'K02', 1, N'Phòng 4 người', 4, 0, 500000, N'Nữ',  N'Trống',         N''),
(N'P005', N'C101', N'K03', 1, N'Phòng 6 người', 6, 0, 450000, N'Nam', N'Trống',         N''),
(N'P006', N'D101', N'K04', 1, N'Phòng 6 người', 6, 0, 450000, N'Nữ',  N'Trống',         N''),
(N'P007', N'E101', N'K05', 1, N'Phòng 4 người', 4, 0, 480000, N'Nam', N'Trống',         N''),
(N'P008', N'F101', N'K06', 1, N'Phòng 4 người', 4, 0, 480000, N'Nữ',  N'Trống',         N''),
(N'P009', N'G101', N'K07', 1, N'Phòng 6 người', 6, 0, 470000, N'Nam', N'Trống',         N''),
(N'P010', N'H101', N'K08', 1, N'Phòng 6 người', 6, 0, 470000, N'Nữ',  N'Trống',         N''),
(N'P011', N'I101', N'K09', 1, N'Phòng 4 người', 4, 0, 490000, N'Nam', N'Bảo trì',       N''),
(N'P012', N'K101', N'K10', 1, N'Phòng 4 người', 4, 0, 500000, N'Nữ',  N'Trống',         N''),
(N'P013', N'L101', N'K11', 1, N'Phòng 6 người', 6, 0, 460000, N'Nam', N'Trống',         N''),
(N'P014', N'M101', N'K12', 1, N'Phòng 6 người', 6, 0, 460000, N'Nữ',  N'Trống',         N''),
(N'P015', N'N101', N'K13', 1, N'Phòng 4 người', 4, 0, 520000, N'Nam', N'Trống',         N''),
(N'P016', N'O101', N'K14', 1, N'Phòng 4 người', 4, 0, 520000, N'Nữ',  N'Trống',         N''),
(N'P017', N'P101', N'K15', 1, N'Phòng 6 người', 6, 0, 470000, N'Nam', N'Trống',         N''),
(N'P018', N'Q101', N'K16', 1, N'Phòng 6 người', 6, 0, 470000, N'Nữ',  N'Ngưng sử dụng', N''),
(N'P019', N'R101', N'K17', 1, N'Phòng 4 người', 4, 0, 495000, N'Nam', N'Trống',         N''),
(N'P020', N'S101', N'K18', 1, N'Phòng 4 người', 4, 0, 495000, N'Nữ',  N'Trống',         N'')
GO

/*====================================================
    INSERT ĐĂNG KÝ
====================================================*/

INSERT INTO DangKy VALUES
(N'DK001', N'SV001', '2026-01-05', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK002', N'SV002', '2026-01-06', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',               N'Đã duyệt',  N''),
(N'DK003', N'SV003', '2026-01-07', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Cận nghèo',              N'Đã duyệt',  N''),
(N'DK004', N'SV004', '2026-01-07', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK005', N'SV005', '2026-01-08', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Vùng sâu vùng xa',       N'Đã duyệt',  N''),
(N'DK006', N'SV006', '2026-01-08', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK007', N'SV007', '2026-01-09', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Con thương binh/liệt sĩ',N'Đã duyệt',  N''),
(N'DK008', N'SV008', '2026-01-10', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK009', N'SV009', '2026-01-11', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK010', N'SV010', '2026-01-11', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Hộ nghèo',               N'Đã duyệt',  N''),
(N'DK011', N'SV011', '2026-01-12', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK012', N'SV012', '2026-01-12', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',               N'Đã duyệt',  N''),
(N'DK013', N'SV013', '2026-01-13', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK014', N'SV014', '2026-01-13', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Cận nghèo',              N'Đã duyệt',  N''),
(N'DK015', N'SV015', '2026-01-14', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK016', N'SV016', '2026-01-14', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Đã duyệt',  N''),
(N'DK017', N'SV017', '2026-01-15', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Vùng sâu vùng xa',       N'Chờ duyệt', N''),
(N'DK018', N'SV018', '2026-01-15', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Con thương binh/liệt sĩ',N'Chờ duyệt', N''),
(N'DK019', N'SV019', '2026-01-16', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',            N'Chờ duyệt', N''),
(N'DK020', N'SV020', '2026-01-16', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',               N'Chờ duyệt', N'')
GO

/*====================================================
    INSERT XẾP PHÒNG
    [FIX-D] 16 SV TrangThaiO = 'Đang ở' (trigger tăng số người)
             4 SV TrangThaiO = 'Chờ xếp' (không kích trigger)
    → Sau khi insert TraPhong 5 SV, vẫn còn 11 SV đang ở

    Tắt trigger trong lúc seed để tránh check giới tính / phòng đầy
    chặn dữ liệu mẫu. Trigger sẽ bật lại ngay sau khi seed xong.
    Số người phòng được cập nhật thủ công bên dưới.
====================================================*/

DISABLE TRIGGER trg_XepPhong_Insert ON XepPhong
GO

INSERT INTO XepPhong VALUES
(N'XP001', N'DK001', N'SV001', N'P001', N'Giường 1', '2026-01-15', NULL, N'Đang ở',  N''),  -- sẽ trả phòng
(N'XP002', N'DK003', N'SV003', N'P001', N'Giường 2', '2026-01-15', NULL, N'Đang ở',  N''),  -- sẽ trả phòng
(N'XP003', N'DK002', N'SV002', N'P003', N'Giường 1', '2026-01-15', NULL, N'Đang ở',  N''),  -- sẽ trả phòng
(N'XP004', N'DK004', N'SV004', N'P003', N'Giường 2', '2026-01-15', NULL, N'Đang ở',  N''),  -- sẽ trả phòng
(N'XP005', N'DK005', N'SV005', N'P005', N'Giường 1', '2026-01-16', NULL, N'Đang ở',  N''),  -- sẽ trả phòng
(N'XP006', N'DK006', N'SV006', N'P006', N'Giường 1', '2026-01-16', NULL, N'Đang ở',  N''),
(N'XP007', N'DK007', N'SV007', N'P007', N'Giường 1', '2026-01-16', NULL, N'Đang ở',  N''),
(N'XP008', N'DK008', N'SV008', N'P008', N'Giường 1', '2026-01-16', NULL, N'Đang ở',  N''),
(N'XP009', N'DK009', N'SV009', N'P009', N'Giường 1', '2026-01-17', NULL, N'Đang ở',  N''),
(N'XP010', N'DK010', N'SV010', N'P010', N'Giường 1', '2026-01-17', NULL, N'Đang ở',  N''),
(N'XP011', N'DK011', N'SV011', N'P012', N'Giường 1', '2026-01-18', NULL, N'Đang ở',  N''),
(N'XP012', N'DK012', N'SV012', N'P012', N'Giường 2', '2026-01-18', NULL, N'Đang ở',  N''),
(N'XP013', N'DK013', N'SV013', N'P013', N'Giường 1', '2026-01-18', NULL, N'Đang ở',  N''),
(N'XP014', N'DK014', N'SV014', N'P014', N'Giường 1', '2026-01-18', NULL, N'Đang ở',  N''),
(N'XP015', N'DK015', N'SV015', N'P015', N'Giường 1', '2026-01-19', NULL, N'Đang ở',  N''),
(N'XP016', N'DK016', N'SV016', N'P016', N'Giường 1', '2026-01-19', NULL, N'Đang ở',  N''),
(N'XP017', N'DK017', N'SV017', N'P017', N'Giường 1', '2026-01-20', NULL, N'Chờ xếp', N''),
(N'XP018', N'DK018', N'SV018', N'P020', N'Giường 1', '2026-01-20', NULL, N'Chờ xếp', N''),
(N'XP019', N'DK019', N'SV019', N'P019', N'Giường 1', '2026-01-20', NULL, N'Chờ xếp', N''),
(N'XP020', N'DK020', N'SV020', N'P020', N'Giường 2', '2026-01-20', NULL, N'Chờ xếp', N'')
GO

ENABLE TRIGGER trg_XepPhong_Insert ON XepPhong
GO

/*====================================================
    CẬP NHẬT SỐ NGƯỜI PHÒNG THỦ CÔNG SAU KHI SEED
    (trigger bị tắt lúc insert nên cần đếm lại)
====================================================*/

UPDATE p
SET
    p.SoNguoiHienTai = sub.SoNguoi,
    p.TrangThai = CASE
        WHEN sub.SoNguoi = 0           THEN N'Trống'
        WHEN sub.SoNguoi >= p.SucChua  THEN N'Đầy'
        ELSE N'Còn chỗ'
    END
FROM Phong p
INNER JOIN
(
    SELECT MaPhong, COUNT(*) AS SoNguoi
    FROM XepPhong
    WHERE TrangThaiO = N'Đang ở'
    GROUP BY MaPhong
) sub ON p.MaPhong = sub.MaPhong
GO

/*====================================================
    INSERT CHUYỂN PHÒNG
    Trigger trg_ChuyenPhong_Insert sẽ tự xử lý
====================================================*/

INSERT INTO ChuyenPhong VALUES
(N'CP001', N'SV009', N'P009', N'P005', '2026-03-01', N'Ghép cùng lớp',            N'Đã chuyển',  N''),
(N'CP002', N'SV013', N'P013', N'P017', '2026-03-02', N'Đổi loại phòng',           N'Đã chuyển',  N''),
(N'CP003', N'SV006', N'P006', N'P008', '2026-03-03', N'Phòng yên tĩnh hơn',       N'Chờ xử lý',  N''),
(N'CP004', N'SV011', N'P012', N'P015', '2026-03-04', N'Ở gần bạn thân',           N'Chờ xử lý',  N''),
(N'CP005', N'SV015', N'P015', N'P019', '2026-03-05', N'Gần lớp học',              N'Đã chuyển',  N''),
(N'CP006', N'SV010', N'P010', N'P012', '2026-03-06', N'Chuyển khu nữ mới',        N'Chờ xử lý',  N''),
(N'CP007', N'SV007', N'P007', N'P009', '2026-03-07', N'Đổi theo đề nghị quản lý', N'Hủy chuyển', N''),
(N'CP008', N'SV016', N'P016', N'P020', '2026-03-08', N'Gần bạn',                  N'Chờ xử lý',  N''),
(N'CP009', N'SV014', N'P014', N'P016', '2026-03-09', N'Đổi sang khu ưu tiên',     N'Chờ xử lý',  N''),
(N'CP010', N'SV012', N'P012', N'P014', '2026-03-10', N'Phòng cũ đông',            N'Đã chuyển',  N'')
GO

/*====================================================
    INSERT TRẢ PHÒNG
    [FIX-D] Chỉ 5 SV trả phòng hẳn (TP001-TP005), TrangThai = 'Đã trả phòng'
             5 SV còn lại TrangThai = 'Chờ trả phòng' → không kích trigger giảm số người
             → 11 SV vẫn đang ở sau khi script chạy xong
             → vw_SinhVienDangO trả về dữ liệu phong phú

    Tắt trigger trong lúc seed để tránh lỗi khi XepPhong chưa đồng bộ
    hoàn toàn với dữ liệu chuyển phòng phía trên.
    Trigger bật lại ngay sau. Từ thời điểm này mọi TraPhong thật
    trong app đều đi qua trigger bình thường.
====================================================*/

DISABLE TRIGGER trg_TraPhong_Insert ON TraPhong
GO

INSERT INTO TraPhong VALUES
(N'TP001', N'SV001', N'P001', N'Giường 1', '2026-01-15', '2026-04-30', N'Về quê thực tập',        N'Đã trả phòng',  N''),
(N'TP002', N'SV002', N'P003', N'Giường 1', '2026-01-15', '2026-05-01', N'Ra ngoài thuê trọ',      N'Đã trả phòng',  N''),
(N'TP003', N'SV003', N'P001', N'Giường 2', '2026-01-15', '2026-05-02', N'Bảo lưu học tập',        N'Đã trả phòng',  N''),
(N'TP004', N'SV004', N'P003', N'Giường 2', '2026-01-15', '2026-05-03', N'Về quê dài hạn',         N'Đã trả phòng',  N''),
(N'TP005', N'SV005', N'P005', N'Giường 1', '2026-01-16', '2026-05-04', N'Chuyển nhà trọ',         N'Đã trả phòng',  N''),
-- 5 SV dưới đây chưa trả, trạng thái chờ, để dataset đa dạng
(N'TP006', N'SV006', N'P006', N'Giường 1', '2026-01-16', '2026-06-30', N'Thực tập doanh nghiệp',  N'Chờ trả phòng', N''),
(N'TP007', N'SV007', N'P007', N'Giường 1', '2026-01-16', '2026-06-30', N'Kết thúc khóa học',      N'Chờ trả phòng', N''),
(N'TP008', N'SV008', N'P008', N'Giường 1', '2026-01-16', '2026-06-30', N'Ở cùng người thân',      N'Chờ trả phòng', N''),
(N'TP009', N'SV009', N'P005', N'Giường 1', '2026-01-17', '2026-06-30', N'Chuyển cơ sở học',       N'Chờ trả phòng', N''),
(N'TP010', N'SV010', N'P010', N'Giường 1', '2026-01-17', '2026-06-30', N'Chuyển nơi ở',           N'Chờ trả phòng', N'')
GO

ENABLE TRIGGER trg_TraPhong_Insert ON TraPhong
GO

/*====================================================
    ĐỒNG BỘ XepPhong THỦ CÔNG CHO 5 SV ĐÃ TRẢ PHÒNG
    (trigger bị tắt lúc seed nên cần cập nhật tay)
====================================================*/

-- Đánh dấu 5 SV đã trả là 'Đã trả' trong XepPhong
UPDATE xp
SET
    xp.TrangThaiO  = N'Đã trả',
    xp.NgayKetThuc = tp.NgayTraPhong
FROM XepPhong xp
INNER JOIN TraPhong tp
    ON xp.MaSV    = tp.MaSV
   AND xp.MaPhong = tp.MaPhong
WHERE tp.TrangThai = N'Đã trả phòng'
  AND xp.TrangThaiO = N'Đang ở'
GO

-- Cập nhật lại số người các phòng sau khi 5 SV trả
UPDATE p
SET
    p.SoNguoiHienTai = ISNULL(sub.SoNguoi, 0),
    p.TrangThai = CASE
        WHEN ISNULL(sub.SoNguoi, 0) = 0          THEN N'Trống'
        WHEN ISNULL(sub.SoNguoi, 0) >= p.SucChua THEN N'Đầy'
        ELSE N'Còn chỗ'
    END
FROM Phong p
LEFT JOIN
(
    SELECT MaPhong, COUNT(*) AS SoNguoi
    FROM XepPhong
    WHERE TrangThaiO = N'Đang ở'
    GROUP BY MaPhong
) sub ON p.MaPhong = sub.MaPhong
WHERE p.TrangThai NOT IN (N'Bảo trì', N'Ngưng sử dụng')
GO

/*====================================================
    INSERT ĐIỆN NƯỚC
====================================================*/

INSERT INTO DienNuoc VALUES
(N'DN001', N'P001', 1, 2026, 1200, 1280, 300, 320, 280000, 120000, N''),
(N'DN002', N'P002', 1, 2026, 1000, 1060, 250, 265, 210000,  90000, N''),
(N'DN003', N'P003', 1, 2026, 1100, 1175, 260, 280, 262500, 120000, N''),
(N'DN004', N'P004', 1, 2026,  950, 1005, 220, 233, 192500,  78000, N''),
(N'DN005', N'P005', 1, 2026,  900,  980, 210, 228, 280000, 108000, N''),
(N'DN006', N'P006', 1, 2026,  880,  960, 200, 217, 280000, 102000, N''),
(N'DN007', N'P007', 1, 2026,  700,  748, 150, 160, 168000,  60000, N''),
(N'DN008', N'P008', 1, 2026,  720,  770, 152, 164, 175000,  72000, N''),
(N'DN009', N'P009', 1, 2026, 1090, 1185, 240, 262, 332500, 132000, N''),
(N'DN010', N'P010', 1, 2026, 1080, 1170, 238, 258, 315000, 120000, N''),
(N'DN011', N'P011', 1, 2026,  980, 1052, 200, 216, 252000,  96000, N''),
(N'DN012', N'P012', 1, 2026,  850,  905, 170, 182, 192500,  72000, N''),
(N'DN013', N'P013', 1, 2026, 1120, 1208, 260, 281, 308000, 126000, N''),
(N'DN014', N'P014', 1, 2026, 1110, 1190, 255, 274, 280000, 114000, N''),
(N'DN015', N'P015', 1, 2026, 1005, 1084, 215, 233, 276500, 108000, N''),
(N'DN016', N'P016', 1, 2026,  790,  844, 155, 167, 189000,  72000, N''),
(N'DN017', N'P017', 1, 2026, 1090, 1185, 240, 262, 332500, 132000, N''),
(N'DN018', N'P018', 1, 2026,    0,    0,   0,   0,       0,      0, N'Ngưng sử dụng'),
(N'DN019', N'P019', 1, 2026,  620,  668, 120, 132, 168000,  72000, N''),
(N'DN020', N'P020', 1, 2026,  640,  692, 125, 138, 182000,  78000, N'')
GO

/*====================================================
    INSERT HÓA ĐƠN
====================================================*/

INSERT INTO HoaDon VALUES
(N'HD001', N'SV001', N'P001', 1, 2026, '2026-01-31', '2026-02-02', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD002', N'SV002', N'P003', 1, 2026, '2026-01-31', '2026-02-01', N'Chuyển khoản', N'Đã thanh toán',   N''),
(N'HD003', N'SV003', N'P001', 1, 2026, '2026-01-31', NULL,          N'Ví điện tử',   N'Chưa thanh toán', N''),
(N'HD004', N'SV004', N'P003', 1, 2026, '2026-01-31', '2026-02-03', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD005', N'SV005', N'P005', 1, 2026, '2026-01-31', NULL,          N'Chuyển khoản', N'Còn nợ',          N''),
(N'HD006', N'SV006', N'P006', 1, 2026, '2026-01-31', '2026-02-04', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD007', N'SV007', N'P007', 1, 2026, '2026-01-31', '2026-02-02', N'Ví điện tử',   N'Đã thanh toán',   N''),
(N'HD008', N'SV008', N'P008', 1, 2026, '2026-01-31', NULL,          N'Chuyển khoản', N'Chưa thanh toán', N''),
(N'HD009', N'SV009', N'P009', 1, 2026, '2026-01-31', '2026-02-05', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD010', N'SV010', N'P010', 1, 2026, '2026-01-31', NULL,          N'Ví điện tử',   N'Còn nợ',          N''),
(N'HD011', N'SV011', N'P012', 1, 2026, '2026-01-31', '2026-02-03', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD012', N'SV012', N'P012', 1, 2026, '2026-01-31', NULL,          N'Chuyển khoản', N'Chưa thanh toán', N''),
(N'HD013', N'SV013', N'P013', 1, 2026, '2026-01-31', '2026-02-04', N'Ví điện tử',   N'Đã thanh toán',   N''),
(N'HD014', N'SV014', N'P014', 1, 2026, '2026-01-31', '2026-02-04', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD015', N'SV015', N'P015', 1, 2026, '2026-01-31', NULL,          N'Chuyển khoản', N'Còn nợ',          N''),
(N'HD016', N'SV016', N'P016', 1, 2026, '2026-01-31', '2026-02-03', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD017', N'SV017', N'P017', 1, 2026, '2026-01-31', NULL,          N'Ví điện tử',   N'Chưa thanh toán', N''),
(N'HD018', N'SV018', N'P020', 1, 2026, '2026-01-31', '2026-02-02', N'Tiền mặt',     N'Đã thanh toán',   N''),
(N'HD019', N'SV019', N'P019', 1, 2026, '2026-01-31', '2026-02-01', N'Chuyển khoản', N'Đã thanh toán',   N''),
(N'HD020', N'SV020', N'P020', 1, 2026, '2026-01-31', NULL,          N'Ví điện tử',   N'Chưa thanh toán', N'')
GO

/*====================================================
    INSERT CHI TIẾT HÓA ĐƠN
====================================================*/

INSERT INTO ChiTietHoaDon VALUES
(N'CT001', N'HD001', N'DN001', 500000, 140000,  60000, 20000),
(N'CT002', N'HD002', N'DN003', 500000, 131250,  60000, 10000),
(N'CT003', N'HD003', N'DN001', 500000, 140000,  60000, 20000),
(N'CT004', N'HD004', N'DN003', 500000, 131250,  60000, 10000),
(N'CT005', N'HD005', N'DN005', 450000, 140000,  54000, 15000),
(N'CT006', N'HD006', N'DN006', 450000, 140000,  51000, 15000),
(N'CT007', N'HD007', N'DN007', 480000,  84000,  30000, 10000),
(N'CT008', N'HD008', N'DN008', 480000,  87500,  36000, 10000),
(N'CT009', N'HD009', N'DN009', 470000, 166250,  66000, 20000),
(N'CT010', N'HD010', N'DN010', 470000, 157500,  60000, 20000),
(N'CT011', N'HD011', N'DN012', 500000,  96250,  36000, 10000),
(N'CT012', N'HD012', N'DN012', 500000,  96250,  36000, 10000),
(N'CT013', N'HD013', N'DN013', 460000, 154000,  63000, 15000),
(N'CT014', N'HD014', N'DN014', 460000, 140000,  57000, 15000),
(N'CT015', N'HD015', N'DN015', 520000, 138250,  54000, 15000),
(N'CT016', N'HD016', N'DN016', 520000,  94500,  36000, 10000),
(N'CT017', N'HD017', N'DN017', 470000, 166250,  66000, 20000),
(N'CT018', N'HD018', N'DN020', 495000,  91000,  39000, 10000),
(N'CT019', N'HD019', N'DN019', 495000,  84000,  36000, 10000),
(N'CT020', N'HD020', N'DN020', 495000,  91000,  39000, 10000)
GO

/*====================================================
    VIEWS
====================================================*/

CREATE VIEW vw_DanhSachTaiKhoan AS
SELECT
    tk.MaTK, tk.TenDangNhap, tk.HoTen, tk.ChucVu,
    vt.TenVaiTro, tk.SDT, tk.Email, tk.TrangThai
FROM tblTAIKHOAN tk
INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
GO

CREATE VIEW vw_SinhVienDangO AS
SELECT
    sv.MaSV, sv.HoTen, sv.Lop, sv.Khoa,
    p.MaPhong, p.SoPhong,
    k.TenKhu,
    xp.Giuong, xp.NgayVaoO
FROM XepPhong xp
INNER JOIN SinhVien sv ON xp.MaSV    = sv.MaSV
INNER JOIN Phong    p  ON xp.MaPhong = p.MaPhong
INNER JOIN KhuNha   k  ON p.MaKhu    = k.MaKhu
WHERE xp.TrangThaiO = N'Đang ở'
GO

CREATE VIEW vw_TieuThuDienNuoc AS
SELECT
    dn.MaPhieu, dn.MaPhong, p.SoPhong, k.TenKhu,
    dn.Thang, dn.Nam,
    dn.ChiSoDienCu, dn.ChiSoDienMoi, dn.DienTieuThu,
    dn.ChiSoNuocCu, dn.ChiSoNuocMoi, dn.NuocTieuThu,
    dn.TienDien, dn.TienNuoc, dn.TongTien
FROM DienNuoc dn
INNER JOIN Phong   p ON dn.MaPhong = p.MaPhong
INNER JOIN KhuNha  k ON p.MaKhu    = k.MaKhu
GO

/*====================================================
    STORED PROCEDURES
====================================================*/

CREATE PROC sp_DangNhap
    @TenDangNhap VARCHAR(50),
    @MatKhau     VARCHAR(100)
AS
BEGIN
    SELECT tk.*, vt.TenVaiTro
    FROM tblTAIKHOAN tk
    INNER JOIN tblVAITRO vt ON tk.MaVaiTro = vt.MaVaiTro
    WHERE tk.TenDangNhap = @TenDangNhap
      AND tk.MatKhau     = @MatKhau
      AND tk.TrangThai   = N'Hoạt động'
END
GO

CREATE PROC sp_LayQuyenTheoTaiKhoan
    @MaTK CHAR(5)
AS
BEGIN
    SELECT
        cn.MaCN, cn.TenChucNang, cn.NhomChucNang,
        pq.DuocTruyCap
    FROM tblPHANQUYEN pq
    INNER JOIN tblCHUCNANG cn ON pq.MaCN = cn.MaCN
    WHERE pq.MaTK = @MaTK
END
GO

CREATE PROC sp_CapNhatPhanQuyen
    @MaTK        CHAR(5),
    @MaCN        CHAR(5),
    @DuocTruyCap BIT
AS
BEGIN
    UPDATE tblPHANQUYEN
    SET DuocTruyCap = @DuocTruyCap
    WHERE MaTK = @MaTK AND MaCN = @MaCN
END
GO

CREATE PROC sp_KiemTraQuyen
    @MaTK CHAR(5),
    @MaCN CHAR(5)
AS
BEGIN
    SELECT ISNULL(DuocTruyCap, 0) AS CoQuyen
    FROM tblPHANQUYEN
    WHERE MaTK = @MaTK AND MaCN = @MaCN
END
GO
/*====================================================
    INSERT SINH VIÊN (THÊM 20 BẢN GHI)
====================================================*/

INSERT INTO SinhVien VALUES
(N'SV021', N'Nguyễn Đức Anh',     '2004-02-11', N'Nam', N'CNTT6', N'Công nghệ thông tin',  N'0911111131', N'001204000021', N'Hà Tĩnh',     N'Bình thường',             N'Đang học', N''),
(N'SV022', N'Lê Thị Bích',        '2004-04-09', N'Nữ',  N'KT5',   N'Kế toán',             N'0911111132', N'001204000022', N'Nam Định',    N'Hộ nghèo',                N'Đang học', N''),
(N'SV023', N'Trần Quốc Cường',    '2004-06-15', N'Nam', N'CK3',   N'Cơ khí',              N'0911111133', N'001204000023', N'Hải Dương',   N'Bình thường',             N'Đang học', N''),
(N'SV024', N'Phạm Thị Diễm',      '2004-08-20', N'Nữ',  N'NN4',   N'Ngôn ngữ Anh',        N'0911111134', N'001204000024', N'Quảng Bình',  N'Cận nghèo',               N'Đang học', N''),
(N'SV025', N'Hoàng Minh Đức',     '2004-01-30', N'Nam', N'DTVT3', N'Điện tử viễn thông',  N'0911111135', N'001204000025', N'Bắc Ninh',    N'Bình thường',             N'Đang học', N''),
(N'SV026', N'Ngô Thị Hà',         '2004-03-18', N'Nữ',  N'QTKD5', N'Quản trị kinh doanh', N'0911111136', N'001204000026', N'Hà Nam',      N'Bình thường',             N'Đang học', N''),
(N'SV027', N'Bùi Văn Hưng',       '2004-05-27', N'Nam', N'CNTT7', N'Công nghệ thông tin', N'0911111137', N'001204000027', N'Phú Thọ',     N'Vùng sâu vùng xa',        N'Đang học', N''),
(N'SV028', N'Đặng Thị Lan',       '2004-07-12', N'Nữ',  N'KT6',   N'Kế toán',             N'0911111138', N'001204000028', N'Lào Cai',     N'Con thương binh/liệt sĩ', N'Đang học', N''),
(N'SV029', N'Vũ Minh Khôi',       '2004-09-05', N'Nam', N'CK4',   N'Cơ khí',              N'0911111139', N'001204000029', N'Yên Bái',     N'Bình thường',             N'Đang học', N''),
(N'SV030', N'Nguyễn Thị Ly',      '2004-10-10', N'Nữ',  N'NN5',   N'Ngôn ngữ Anh',        N'0911111140', N'001204000030', N'Thái Nguyên', N'Hộ nghèo',                N'Đang học', N''),

(N'SV031', N'Phan Quốc Minh',     '2004-11-19', N'Nam', N'CNTT8', N'Công nghệ thông tin', N'0911111141', N'001204000031', N'Hưng Yên',    N'Bình thường',             N'Đang học', N''),
(N'SV032', N'Lý Thị Ngọc',        '2004-12-01', N'Nữ',  N'KT7',   N'Kế toán',             N'0911111142', N'001204000032', N'Sơn La',      N'Cận nghèo',               N'Đang học', N''),
(N'SV033', N'Trần Văn Phúc',      '2004-01-08', N'Nam', N'QTKD6', N'Quản trị kinh doanh', N'0911111143', N'001204000033', N'Nghệ An',     N'Bình thường',             N'Đang học', N''),
(N'SV034', N'Hoàng Thị Quỳnh',    '2004-02-14', N'Nữ',  N'DTVT4', N'Điện tử viễn thông',  N'0911111144', N'001204000034', N'Thanh Hóa',   N'Hộ nghèo',                N'Đang học', N''),
(N'SV035', N'Đỗ Gia Bảo',         '2004-04-28', N'Nam', N'CNTT9', N'Công nghệ thông tin', N'0911111145', N'001204000035', N'Quảng Ninh',  N'Bình thường',             N'Đang học', N''),
(N'SV036', N'Nguyễn Thu Trang',   '2004-06-06', N'Nữ',  N'NN6',   N'Ngôn ngữ Anh',        N'0911111146', N'001204000036', N'Vĩnh Phúc',   N'Bình thường',             N'Đang học', N''),
(N'SV037', N'Bùi Thanh Tùng',     '2004-07-17', N'Nam', N'CK5',   N'Cơ khí',              N'0911111147', N'001204000037', N'Cao Bằng',    N'Vùng sâu vùng xa',        N'Đang học', N''),
(N'SV038', N'Phạm Thị Uyên',      '2004-08-29', N'Nữ',  N'KT8',   N'Kế toán',             N'0911111148', N'001204000038', N'Bắc Kạn',     N'Con thương binh/liệt sĩ', N'Đang học', N''),
(N'SV039', N'Lê Quốc Việt',       '2004-09-21', N'Nam', N'QTKD7', N'Quản trị kinh doanh', N'0911111149', N'001204000039', N'Tuyên Quang', N'Bình thường',             N'Đang học', N''),
(N'SV040', N'Trần Thị Yến',       '2004-11-25', N'Nữ',  N'NN7',   N'Ngôn ngữ Anh',        N'0911111150', N'001204000040', N'Điện Biên',   N'Hộ nghèo',                N'Đang học', N'')
GO


/*====================================================
    INSERT KHU NHÀ (THÊM 20 BẢN GHI)
====================================================*/

INSERT INTO KhuNha VALUES
(N'K21', N'Khu V', N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K22', N'Khu W', N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K23', N'Khu X', N'Nam', 4,  8, N'Đang sử dụng', N''),
(N'K24', N'Khu Y', N'Nữ',  4,  8, N'Đang sử dụng', N''),
(N'K25', N'Khu Z', N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K26', N'Khu AA',N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K27', N'Khu AB',N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K28', N'Khu AC',N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K29', N'Khu AD',N'Nam', 4,  8, N'Bảo trì',      N'Sửa nước'),
(N'K30', N'Khu AE',N'Nữ',  4,  8, N'Đang sử dụng', N''),
(N'K31', N'Khu AF',N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K32', N'Khu AG',N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K33', N'Khu AH',N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K34', N'Khu AI',N'Nữ',  5, 10, N'Đang sử dụng', N''),
(N'K35', N'Khu AJ',N'Nam', 4,  8, N'Đang sử dụng', N''),
(N'K36', N'Khu AK',N'Nữ',  4,  8, N'Ngưng sử dụng',N'Cải tạo'),
(N'K37', N'Khu AL',N'Nam', 3,  6, N'Đang sử dụng', N''),
(N'K38', N'Khu AM',N'Nữ',  3,  6, N'Đang sử dụng', N''),
(N'K39', N'Khu AN',N'Nam', 5, 10, N'Đang sử dụng', N''),
(N'K40', N'Khu AO',N'Nữ',  5, 10, N'Đang sử dụng', N'')
GO


/*====================================================
    INSERT PHÒNG (THÊM 20 BẢN GHI)
====================================================*/

INSERT INTO Phong VALUES
(N'P021', N'V101', N'K21', 1, N'Phòng 4 người', 4, 0, 500000, N'Nam', N'Trống', N''),
(N'P022', N'V102', N'K21', 1, N'Phòng 4 người', 4, 0, 500000, N'Nam', N'Trống', N''),
(N'P023', N'W101', N'K22', 1, N'Phòng 4 người', 4, 0, 500000, N'Nữ',  N'Trống', N''),
(N'P024', N'W102', N'K22', 1, N'Phòng 4 người', 4, 0, 500000, N'Nữ',  N'Trống', N''),
(N'P025', N'X101', N'K23', 1, N'Phòng 6 người', 6, 0, 470000, N'Nam', N'Trống', N''),
(N'P026', N'Y101', N'K24', 1, N'Phòng 6 người', 6, 0, 470000, N'Nữ',  N'Trống', N''),
(N'P027', N'Z101', N'K25', 1, N'Phòng 4 người', 4, 0, 490000, N'Nam', N'Trống', N''),
(N'P028', N'AA101',N'K26', 1, N'Phòng 4 người', 4, 0, 490000, N'Nữ',  N'Trống', N''),
(N'P029', N'AB101',N'K27', 1, N'Phòng 6 người', 6, 0, 480000, N'Nam', N'Trống', N''),
(N'P030', N'AC101',N'K28', 1, N'Phòng 6 người', 6, 0, 480000, N'Nữ',  N'Trống', N''),
(N'P031', N'AD101',N'K29', 1, N'Phòng 4 người', 4, 0, 500000, N'Nam', N'Bảo trì', N''),
(N'P032', N'AE101',N'K30', 1, N'Phòng 4 người', 4, 0, 510000, N'Nữ',  N'Trống', N''),
(N'P033', N'AF101',N'K31', 1, N'Phòng 6 người', 6, 0, 460000, N'Nam', N'Trống', N''),
(N'P034', N'AG101',N'K32', 1, N'Phòng 6 người', 6, 0, 460000, N'Nữ',  N'Trống', N''),
(N'P035', N'AH101',N'K33', 1, N'Phòng 4 người', 4, 0, 520000, N'Nam', N'Trống', N''),
(N'P036', N'AI101',N'K34', 1, N'Phòng 4 người', 4, 0, 520000, N'Nữ',  N'Trống', N''),
(N'P037', N'AJ101',N'K35', 1, N'Phòng 6 người', 6, 0, 475000, N'Nam', N'Trống', N''),
(N'P038', N'AK101',N'K36', 1, N'Phòng 6 người', 6, 0, 475000, N'Nữ',  N'Ngưng sử dụng', N''),
(N'P039', N'AL101',N'K37', 1, N'Phòng 4 người', 4, 0, 495000, N'Nam', N'Trống', N''),
(N'P040', N'AM101',N'K38', 1, N'Phòng 4 người', 4, 0, 495000, N'Nữ',  N'Trống', N'')
GO
/*====================================================
    INSERT ĐĂNG KÝ (THÊM 20 BẢN GHI)
====================================================*/

INSERT INTO DangKy VALUES
(N'DK021', N'SV021', '2026-01-17', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK022', N'SV022', '2026-01-17', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',                N'Đã duyệt',  N''),
(N'DK023', N'SV023', '2026-01-18', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK024', N'SV024', '2026-01-18', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Cận nghèo',               N'Đã duyệt',  N''),
(N'DK025', N'SV025', '2026-01-19', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK026', N'SV026', '2026-01-19', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK027', N'SV027', '2026-01-20', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Vùng sâu vùng xa',        N'Đã duyệt',  N''),
(N'DK028', N'SV028', '2026-01-20', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Con thương binh/liệt sĩ', N'Đã duyệt',  N''),
(N'DK029', N'SV029', '2026-01-21', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK030', N'SV030', '2026-01-21', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',                N'Đã duyệt',  N''),

(N'DK031', N'SV031', '2026-01-22', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK032', N'SV032', '2026-01-22', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Cận nghèo',               N'Đã duyệt',  N''),
(N'DK033', N'SV033', '2026-01-23', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK034', N'SV034', '2026-01-23', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Hộ nghèo',                N'Đã duyệt',  N''),
(N'DK035', N'SV035', '2026-01-24', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK036', N'SV036', '2026-01-24', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Đã duyệt',  N''),
(N'DK037', N'SV037', '2026-01-25', N'Học kỳ 1', N'2026-2027', N'Phòng 6 người', N'Vùng sâu vùng xa',        N'Chờ duyệt', N''),
(N'DK038', N'SV038', '2026-01-25', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Con thương binh/liệt sĩ', N'Chờ duyệt', N''),
(N'DK039', N'SV039', '2026-01-26', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Bình thường',             N'Chờ duyệt', N''),
(N'DK040', N'SV040', '2026-01-26', N'Học kỳ 1', N'2026-2027', N'Phòng 4 người', N'Hộ nghèo',                N'Chờ duyệt', N'')
GO


/*====================================================
    INSERT XẾP PHÒNG (THÊM 20 BẢN GHI)
====================================================*/

DISABLE TRIGGER trg_XepPhong_Insert ON XepPhong
GO

INSERT INTO XepPhong VALUES
(N'XP021', N'DK021', N'SV021', N'P021', N'Giường 1', '2026-01-21', NULL, N'Đang ở',  N''),
(N'XP022', N'DK022', N'SV022', N'P023', N'Giường 1', '2026-01-21', NULL, N'Đang ở',  N''),
(N'XP023', N'DK023', N'SV023', N'P025', N'Giường 1', '2026-01-22', NULL, N'Đang ở',  N''),
(N'XP024', N'DK024', N'SV024', N'P026', N'Giường 1', '2026-01-22', NULL, N'Đang ở',  N''),
(N'XP025', N'DK025', N'SV025', N'P027', N'Giường 1', '2026-01-23', NULL, N'Đang ở',  N''),
(N'XP026', N'DK026', N'SV026', N'P028', N'Giường 1', '2026-01-23', NULL, N'Đang ở',  N''),
(N'XP027', N'DK027', N'SV027', N'P029', N'Giường 1', '2026-01-24', NULL, N'Đang ở',  N''),
(N'XP028', N'DK028', N'SV028', N'P032', N'Giường 1', '2026-01-24', NULL, N'Đang ở',  N''),
(N'XP029', N'DK029', N'SV029', N'P033', N'Giường 1', '2026-01-25', NULL, N'Đang ở',  N''),
(N'XP030', N'DK030', N'SV030', N'P036', N'Giường 1', '2026-01-25', NULL, N'Đang ở',  N''),

(N'XP031', N'DK031', N'SV031', N'P035', N'Giường 1', '2026-01-26', NULL, N'Đang ở',  N''),
(N'XP032', N'DK032', N'SV032', N'P040', N'Giường 1', '2026-01-26', NULL, N'Đang ở',  N''),
(N'XP033', N'DK033', N'SV033', N'P037', N'Giường 1', '2026-01-27', NULL, N'Đang ở',  N''),
(N'XP034', N'DK034', N'SV034', N'P034', N'Giường 1', '2026-01-27', NULL, N'Đang ở',  N''),
(N'XP035', N'DK035', N'SV035', N'P039', N'Giường 1', '2026-01-28', NULL, N'Đang ở',  N''),
(N'XP036', N'DK036', N'SV036', N'P024', N'Giường 1', '2026-01-28', NULL, N'Đang ở',  N''),

(N'XP037', N'DK037', N'SV037', N'P025', N'Giường 2', '2026-01-29', NULL, N'Chờ xếp', N''),
(N'XP038', N'DK038', N'SV038', N'P032', N'Giường 2', '2026-01-29', NULL, N'Chờ xếp', N''),
(N'XP039', N'DK039', N'SV039', N'P021', N'Giường 2', '2026-01-30', NULL, N'Chờ xếp', N''),
(N'XP040', N'DK040', N'SV040', N'P040', N'Giường 2', '2026-01-30', NULL, N'Chờ xếp', N'')
GO

ENABLE TRIGGER trg_XepPhong_Insert ON XepPhong
GO


/*====================================================
    INSERT CHUYỂN PHÒNG (THÊM 20 BẢN GHI)
====================================================*/

INSERT INTO ChuyenPhong VALUES
(N'CP011', N'SV021', N'P021', N'P022', '2026-03-11', N'Ở cùng bạn',                 N'Đã chuyển',  N''),
(N'CP012', N'SV022', N'P023', N'P024', '2026-03-11', N'Đổi phòng yên tĩnh',         N'Đã chuyển',  N''),
(N'CP013', N'SV023', N'P025', N'P029', '2026-03-12', N'Gần lớp học',                N'Chờ xử lý',  N''),
(N'CP014', N'SV024', N'P026', N'P030', '2026-03-12', N'Đổi khu ở',                  N'Đã chuyển',  N''),
(N'CP015', N'SV025', N'P027', N'P021', '2026-03-13', N'Phòng cũ đông',              N'Chờ xử lý',  N''),
(N'CP016', N'SV026', N'P028', N'P032', '2026-03-13', N'Ở gần bạn thân',             N'Đã chuyển',  N''),
(N'CP017', N'SV027', N'P029', N'P033', '2026-03-14', N'Đổi loại phòng',             N'Hủy chuyển', N''),
(N'CP018', N'SV028', N'P032', N'P036', '2026-03-14', N'Đổi sang khu mới',           N'Chờ xử lý',  N''),
(N'CP019', N'SV029', N'P033', N'P037', '2026-03-15', N'Ghép cùng lớp',              N'Đã chuyển',  N''),
(N'CP020', N'SV030', N'P036', N'P040', '2026-03-15', N'Đổi môi trường học tập',     N'Chờ xử lý',  N''),

(N'CP021', N'SV031', N'P035', N'P039', '2026-03-16', N'Ở gần bạn',                  N'Đã chuyển',  N''),
(N'CP022', N'SV032', N'P040', N'P024', '2026-03-16', N'Đổi phòng ít người',         N'Chờ xử lý',  N''),
(N'CP023', N'SV033', N'P037', N'P029', '2026-03-17', N'Gần nhà vệ sinh',            N'Đã chuyển',  N''),
(N'CP024', N'SV034', N'P034', N'P030', '2026-03-17', N'Đổi theo yêu cầu quản lý',   N'Hủy chuyển', N''),
(N'CP025', N'SV035', N'P039', N'P035', '2026-03-18', N'Phòng mới thoáng hơn',       N'Đã chuyển',  N''),
(N'CP026', N'SV036', N'P024', N'P028', '2026-03-18', N'Đổi gần cầu thang',          N'Chờ xử lý',  N''),
(N'CP027', N'SV037', N'P025', N'P033', '2026-03-19', N'Ghép nhóm học',              N'Chờ xử lý',  N''),
(N'CP028', N'SV038', N'P032', N'P036', '2026-03-19', N'Đổi phòng ưu tiên',          N'Đã chuyển',  N''),
(N'CP029', N'SV039', N'P021', N'P022', '2026-03-20', N'Đổi sang phòng mới',         N'Chờ xử lý',  N''),
(N'CP030', N'SV040', N'P040', N'P024', '2026-03-20', N'Ở gần bạn học',              N'Đã chuyển',  N'')
GO


/*====================================================
    INSERT TRẢ PHÒNG (THÊM 20 BẢN GHI)
====================================================*/

DISABLE TRIGGER trg_TraPhong_Insert ON TraPhong
GO

INSERT INTO TraPhong VALUES
(N'TP011', N'SV021', N'P021', N'Giường 1', '2026-01-21', '2026-06-01', N'Về quê',                 N'Đã trả phòng',  N''),
(N'TP012', N'SV022', N'P023', N'Giường 1', '2026-01-21', '2026-06-02', N'Ra ngoài thuê trọ',     N'Đã trả phòng',  N''),
(N'TP013', N'SV023', N'P025', N'Giường 1', '2026-01-22', '2026-06-03', N'Bảo lưu học',           N'Đã trả phòng',  N''),
(N'TP014', N'SV024', N'P026', N'Giường 1', '2026-01-22', '2026-06-04', N'Chuyển trường',         N'Đã trả phòng',  N''),
(N'TP015', N'SV025', N'P027', N'Giường 1', '2026-01-23', '2026-06-05', N'Đi thực tập',           N'Đã trả phòng',  N''),

(N'TP016', N'SV026', N'P028', N'Giường 1', '2026-01-23', '2026-07-01', N'Kết thúc khóa học',     N'Chờ trả phòng', N''),
(N'TP017', N'SV027', N'P029', N'Giường 1', '2026-01-24', '2026-07-02', N'Chuyển nơi ở',          N'Chờ trả phòng', N''),
(N'TP018', N'SV028', N'P032', N'Giường 1', '2026-01-24', '2026-07-03', N'Ở cùng người thân',     N'Chờ trả phòng', N''),
(N'TP019', N'SV029', N'P033', N'Giường 1', '2026-01-25', '2026-07-04', N'Đi làm thêm xa',        N'Chờ trả phòng', N''),
(N'TP020', N'SV030', N'P036', N'Giường 1', '2026-01-25', '2026-07-05', N'Chuyển cơ sở học',      N'Chờ trả phòng', N''),

(N'TP021', N'SV031', N'P035', N'Giường 1', '2026-01-26', '2026-06-06', N'Về quê dài hạn',        N'Đã trả phòng',  N''),
(N'TP022', N'SV032', N'P040', N'Giường 1', '2026-01-26', '2026-06-07', N'Ra ngoài ở riêng',      N'Đã trả phòng',  N''),
(N'TP023', N'SV033', N'P037', N'Giường 1', '2026-01-27', '2026-06-08', N'Bảo lưu kết quả học',   N'Đã trả phòng',  N''),
(N'TP024', N'SV034', N'P034', N'Giường 1', '2026-01-27', '2026-06-09', N'Đi thực tập doanh nghiệp',N'Đã trả phòng', N''),
(N'TP025', N'SV035', N'P039', N'Giường 1', '2026-01-28', '2026-06-10', N'Chuyển chỗ ở',          N'Đã trả phòng',  N''),

(N'TP026', N'SV036', N'P024', N'Giường 1', '2026-01-28', '2026-07-06', N'Kết thúc học kỳ',       N'Chờ trả phòng', N''),
(N'TP027', N'SV037', N'P025', N'Giường 2', '2026-01-29', '2026-07-07', N'Đi làm xa',             N'Chờ trả phòng', N''),
(N'TP028', N'SV038', N'P032', N'Giường 2', '2026-01-29', '2026-07-08', N'Về quê nghỉ hè',        N'Chờ trả phòng', N''),
(N'TP029', N'SV039', N'P021', N'Giường 2', '2026-01-30', '2026-07-09', N'Đổi nơi ở',             N'Chờ trả phòng', N''),
(N'TP030', N'SV040', N'P040', N'Giường 2', '2026-01-30', '2026-07-10', N'Ở với người thân',      N'Chờ trả phòng', N'')
GO

ENABLE TRIGGER trg_TraPhong_Insert ON TraPhong
GO
