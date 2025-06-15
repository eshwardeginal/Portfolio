-- 1. Create Database if not exists
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PortfolioDB')
BEGIN
    CREATE DATABASE PortfolioDB;
END

-- 2. Use the Database
USE PortfolioDB;

-- 3. Create Tables If Not Exists

-- UserProfile
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UserProfile')
BEGIN
    CREATE TABLE UserProfile (
        Id INT PRIMARY KEY IDENTITY,
        Name NVARCHAR(100),
        Tagline NVARCHAR(255),
        About NVARCHAR(MAX),
        LinkedIn NVARCHAR(255),
        GitHub NVARCHAR(255),
        Email NVARCHAR(100)
    );
END

-- Skills
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Skills')
BEGIN
    CREATE TABLE Skills (
        Id INT PRIMARY KEY IDENTITY,
        Category NVARCHAR(50), -- e.g., Frontend, Backend
        Name NVARCHAR(100)
    );
END

-- Projects
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Projects')
BEGIN
    CREATE TABLE Projects (
        Id INT PRIMARY KEY IDENTITY,
        Title NVARCHAR(100),
        Description NVARCHAR(MAX),
        TechStack NVARCHAR(255),
        GitHubLink NVARCHAR(255),
        LiveDemoLink NVARCHAR(255)
    );
END

-- Experience
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Experience')
BEGIN
    CREATE TABLE Experience (
        Id INT PRIMARY KEY IDENTITY,
        Company NVARCHAR(100),
        Role NVARCHAR(100),
        Description NVARCHAR(MAX),
        StartDate DATE,
        EndDate DATE
    );
END

-- Education
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Education')
BEGIN
    CREATE TABLE Education (
        Id INT PRIMARY KEY IDENTITY,
        Institute NVARCHAR(100),
        Degree NVARCHAR(100),
        StartYear INT,
        EndYear INT
    );
END

-- 4. Insert Sample Data

-- UserProfile
IF NOT EXISTS (SELECT * FROM UserProfile)
BEGIN
    INSERT INTO UserProfile (Name, Tagline, About, LinkedIn, GitHub, Email)
    VALUES (
        'Eshwara Deginal B',
        'Full Stack Developer | Angular | .NET | SQL',
        'I am a passionate full stack developer with experience in building web applications using Angular, .NET Core, and SQL Server.',
        'https://linkedin.com/in/eshwaradeginal',
        'https://github.com/eshwaradeginal',
        'eshwara@example.com'
    );
END

-- Skills
IF NOT EXISTS (SELECT * FROM Skills)
BEGIN
    INSERT INTO Skills (Category, Name)
    VALUES 
    ('Frontend', 'Angular'),
    ('Frontend', 'HTML'),
    ('Frontend', 'CSS'),
    ('Frontend', 'TypeScript'),
    ('Backend', 'C#'),
    ('Backend', '.NET Core'),
    ('Backend', 'ASP.NET Web API'),
    ('Database', 'SQL Server'),
    ('Tools', 'Git'),
    ('Tools', 'Postman');
END

-- Projects
IF NOT EXISTS (SELECT * FROM Projects)
BEGIN
    INSERT INTO Projects (Title, Description, TechStack, GitHubLink, LiveDemoLink)
    VALUES 
    (
        'Portfolio Website',
        'A personal portfolio website to showcase my projects, skills, and resume.',
        'Angular, .NET Core, SQL Server',
        'https://github.com/eshwaradeginal/portfolio',
        'https://eshwaraportfolio.com'
    ),
    (
        'E-commerce API',
        'A RESTful backend for an e-commerce application supporting products, cart, orders, and users.',
        '.NET Core, SQL Server, Swagger',
        'https://github.com/eshwaradeginal/ecommerce-api',
        NULL
    );
END

-- Experience
IF NOT EXISTS (SELECT * FROM Experience)
BEGIN
    INSERT INTO Experience (Company, Role, Description, StartDate, EndDate)
    VALUES 
    (
        'Starmark Software Pvt Ltd',
        'Software Engineer',
        'Developed and maintained enterprise applications using Angular and .NET Core. Worked on REST APIs, frontend integrations, and SQL database design.',
        '2022-05-01',
        NULL
    );
END

-- Education
IF NOT EXISTS (SELECT * FROM Education)
BEGIN
    INSERT INTO Education (Institute, Degree, StartYear, EndYear)
    VALUES 
    (
        'Visvesvaraya Technological University',
        'B.E. in Computer Science',
        2017,
        2021
    );
END
