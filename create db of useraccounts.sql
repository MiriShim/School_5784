-- יצירת מסד נתונים חדש
--CREATE DATABASE UserPermissionsDB;
--GO

-- שימוש במסד הנתונים החדש
--USE UserPermissionsDB;
--GO

-- יצירת טבלה לאחסון מידע על משתמשים
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) NOT NULL UNIQUE,
    Email NVARCHAR(100),
    PasswordHash NVARCHAR(256) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- יצירת טבלה לאחסון מידע על קבוצות משתמשים
CREATE TABLE UserGroups (
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- יצירת טבלה שמקשרת בין משתמשים לקבוצות
CREATE TABLE UserGroupMemberships (
    MembershipID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    GroupID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GroupID) REFERENCES UserGroups(GroupID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- יצירת טבלה לאחסון מידע על הרשאות
CREATE TABLE Permissions (
    PermissionID INT IDENTITY(1,1) PRIMARY KEY,
    PermissionName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- יצירת טבלה שמקשרת בין קבוצות להרשאות
CREATE TABLE GroupPermissions (
    GroupPermissionID INT IDENTITY(1,1) PRIMARY KEY,
    GroupID INT NOT NULL,
    PermissionID INT NOT NULL,
    FOREIGN KEY (GroupID) REFERENCES UserGroups(GroupID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- יצירת טבלה שמקשרת בין משתמשים להרשאות ישירות (למקרה של הרשאות פרטניות)
CREATE TABLE UserPermissions (
    UserPermissionID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    PermissionID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (PermissionID) REFERENCES Permissions(PermissionID),
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- הוספת משתמשים
INSERT INTO Users (UserName, Email, PasswordHash)
VALUES 
    (N'דוד כהן', N'david.cohen@example.com', N'hashed_password_1'),
    (N'שרה לוי', N'sara.levi@example.com', N'hashed_password_2'),
    (N'מיכאל ישראלי', N'michael.israeli@example.com', N'hashed_password_3'),
    (N'יוסי ברק', N'yossi.barak@example.com', N'hashed_password_4'),
    (N'רונית גולדמן', N'ronit.goldman@example.com', N'hashed_password_5'),
    (N'איילת עוז', N'ayalet.oz@example.com', N'hashed_password_6'),
    (N'מיה בן דוד', N'mia.ben.david@example.com', N'hashed_password_7'),
    (N'שלמה רבינוביץ', N'shlomo.rabinovich@example.com', N'hashed_password_8'),
    (N'אורית שמש', N'orit.shames@example.com', N'hashed_password_9'),
    (N'איתן שפירא', N'eitan.shapira@example.com', N'hashed_password_10');
GO

-- הוספת קבוצות משתמשים
INSERT INTO UserGroups (GroupName, Description)
VALUES 
    (N'מנהלי מערכת', N'קבוצה של מנהלי מערכת עם הרשאות מלאות'),
    (N'משתמשים רגילים', N'קבוצה של משתמשים עם הרשאות רגילות'),
    (N'תומכים טכניים', N'קבוצה של תומכים טכניים עם גישה מוגבלת'),
    (N'מפתחים', N'קבוצה של מפתחים עם גישה לקוד ומסמכים'),
    (N'מחלקת משאבי אנוש', N'קבוצה של עובדי משאבי אנוש עם גישה למידע אישי');
GO

-- הוספת חברות של משתמשים בקבוצות
INSERT INTO UserGroupMemberships (UserID, GroupID)
VALUES 
    (1, 1),  -- דוד כהן שייך לקבוצה "מנהלי מערכת"
    (2, 2),  -- שרה לוי שייכת לקבוצה "משתמשים רגילים"
    (3, 3),  -- מיכאל ישראלי שייך לקבוצה "תומכים טכניים"
    (4, 4),  -- יוסי ברק שייך לקבוצה "מפתחים"
    (5, 5),  -- רונית גולדמן שייכת לקבוצה "מחלקת משאבי אנוש"
    (6, 4),  -- איילת עוז שייכת לקבוצה "מפתחים"
    (7, 2),  -- מיה בן דוד שייכת לקבוצה "משתמשים רגילים"
    (8, 1),  -- שלמה רבינוביץ שייך לקבוצה "מנהלי מערכת"
    (9, 5),  -- אורית שמש שייכת לקבוצה "מחלקת משאבי אנוש"
    (10, 2); -- איתן שפירא שייך לקבוצה "משתמשים רגילים"
GO

-- הוספת הרשאות
INSERT INTO Permissions (PermissionName, Description)
VALUES 
    (N'גישה מלאה', N'הרשאה לבצע כל פעולה במערכת'),
    (N'גישה לקריאה', N'הרשאה לקרוא מידע בלבד'),
    (N'גישה לכתיבה', N'הרשאה לכתוב או לעדכן מידע'),
    (N'גישה למערכת ניהול', N'הרשאה לנהל את המערכת'),
    (N'גישה למידע אישי', N'הרשאה לגשת למידע אישי של עובדים');
GO

-- הוספת הרשאות לקבוצות
INSERT INTO GroupPermissions (GroupID, PermissionID)
VALUES 
    (1, 1),  -- מנהלי מערכת מקבלים גישה מלאה
    (2, 2),  -- משתמשים רגילים מקבלים גישה לקריאה
    (3, 3),  -- תומכים טכניים מקבלים גישה לכתיבה
    (4, 4),  -- מפתחים מקבלים גישה למערכת ניהול
    (5, 5);  -- מחלקת משאבי אנוש מקבלת גישה למידע אישי
GO

-- הוספת הרשאות למשתמשים ספציפיים
INSERT INTO UserPermissions (UserID, PermissionID)
VALUES 
    (1, 1),  -- דוד כהן מקבל גישה מלאה
    (2, 2),  -- שרה לוי מקבלת גישה לקריאה
    (3, 3),  -- מיכאל ישראלי מקבל גישה לכתיבה
    (4, 4),  -- יוסי ברק מקבל גישה למערכת ניהול
    (5, 5),  -- רונית גולדמן מקבלת גישה למידע אישי
    (6, 4),  -- איילת עוז מקבלת גישה למערכת ניהול
    (7, 2),  -- מיה בן דוד מקבלת גישה לקריאה
    (8, 1),  -- שלמה רבינוביץ מקבל גישה מלאה
    (9, 5),  -- אורית שמש מקבלת גישה למידע אישי
    (10, 2); -- איתן שפירא מקבל גישה לקריאה
GO
