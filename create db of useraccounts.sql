-- ����� ��� ������ ���
--CREATE DATABASE UserPermissionsDB;
--GO

-- ����� ���� ������� ����
--USE UserPermissionsDB;
--GO

-- ����� ���� ������ ���� �� �������
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100),
    PasswordHash NVARCHAR(256) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� ���� ������ ���� �� ������ �������
CREATE TABLE UserGroups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� ���� ������ ��� ������� �������
CREATE TABLE UserGroupMemberships (
    MembershipID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    GroupID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GroupID) REFERENCES UserGroups(GroupID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� ���� ������ ���� �� ������
CREATE TABLE Permissions (
    PermissionID INT IDENTITY(1,1) PRIMARY KEY,
    PermissionName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� ���� ������ ��� ������ �������
CREATE TABLE GroupPermissions (
    GroupPermissionID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    PermissionID INT NOT NULL,
    FOREIGN KEY (GroupID) REFERENCES UserGroups(GroupID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� ���� ������ ��� ������� ������� ������ (����� �� ������ �������)
CREATE TABLE UserPermissions (
    UserPermissionID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    PermissionID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- ����� �������
INSERT INTO Users (UserName, Email, PasswordHash)
VALUES 
    (N'��� ���', N'david.cohen@example.com', N'hashed_password_1'),
    (N'��� ���', N'sara.levi@example.com', N'hashed_password_2'),
    (N'����� ������', N'michael.israeli@example.com', N'hashed_password_3'),
    (N'���� ���', N'yossi.barak@example.com', N'hashed_password_4'),
    (N'����� ������', N'ronit.goldman@example.com', N'hashed_password_5'),
    (N'����� ���', N'ayalet.oz@example.com', N'hashed_password_6'),
    (N'��� �� ���', N'mia.ben.david@example.com', N'hashed_password_7'),
    (N'���� ��������', N'shlomo.rabinovich@example.com', N'hashed_password_8'),
    (N'����� ���', N'orit.shames@example.com', N'hashed_password_9'),
    (N'���� �����', N'eitan.shapira@example.com', N'hashed_password_10');
GO

-- ����� ������ �������
INSERT INTO UserGroups (GroupName, Description)
VALUES 
    (N'����� �����', N'����� �� ����� ����� �� ������ �����'),
    (N'������� ������', N'����� �� ������� �� ������ ������'),
    (N'������ ������', N'����� �� ������ ������ �� ���� ������'),
    (N'������', N'����� �� ������ �� ���� ���� �������'),
    (N'����� ����� ����', N'����� �� ����� ����� ���� �� ���� ����� ����');
GO

-- ����� ����� �� ������� �������
INSERT INTO UserGroupMemberships (UserID, GroupID)
VALUES 
    (1, 1),  -- ��� ��� ���� ������ "����� �����"
    (2, 2),  -- ��� ��� ����� ������ "������� ������"
    (3, 3),  -- ����� ������ ���� ������ "������ ������"
    (4, 4),  -- ���� ��� ���� ������ "������"
    (5, 5),  -- ����� ������ ����� ������ "����� ����� ����"
    (6, 4),  -- ����� ��� ����� ������ "������"
    (7, 2),  -- ��� �� ��� ����� ������ "������� ������"
    (8, 1),  -- ���� �������� ���� ������ "����� �����"
    (9, 5),  -- ����� ��� ����� ������ "����� ����� ����"
    (10, 2); -- ���� ����� ���� ������ "������� ������"
GO

-- ����� ������
INSERT INTO Permissions (PermissionName, Description)
VALUES 
    (N'���� ����', N'����� ���� �� ����� ������'),
    (N'���� ������', N'����� ����� ���� ����'),
    (N'���� ������', N'����� ����� �� ����� ����'),
    (N'���� ������ �����', N'����� ���� �� ������'),
    (N'���� ����� ����', N'����� ���� ����� ���� �� ������');
GO

-- ����� ������ �������
INSERT INTO GroupPermissions (GroupID, PermissionID)
VALUES 
    (1, 1),  -- ����� ����� ������ ���� ����
    (2, 2),  -- ������� ������ ������ ���� ������
    (3, 3),  -- ������ ������ ������ ���� ������
    (4, 4),  -- ������ ������ ���� ������ �����
    (5, 5);  -- ����� ����� ���� ����� ���� ����� ����
GO

-- ����� ������ �������� ��������
INSERT INTO UserPermissions (UserID, PermissionID)
VALUES 
    (1, 1),  -- ��� ��� ���� ���� ����
    (2, 2),  -- ��� ��� ����� ���� ������
    (3, 3),  -- ����� ������ ���� ���� ������
    (4, 4),  -- ���� ��� ���� ���� ������ �����
    (5, 5),  -- ����� ������ ����� ���� ����� ����
    (6, 4),  -- ����� ��� ����� ���� ������ �����
    (7, 2),  -- ��� �� ��� ����� ���� ������
    (8, 1),  -- ���� �������� ���� ���� ����
    (9, 5),  -- ����� ��� ����� ���� ����� ����
    (10, 2); -- ���� ����� ���� ���� ������
GO
