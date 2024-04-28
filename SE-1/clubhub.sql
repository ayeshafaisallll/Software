--DROP DATABASE IF EXISTS Clubhub;
--CREATE DATABASE Clubhub;


---- Users table
--CREATE TABLE Users (
--    user_id INT PRIMARY KEY IDENTITY,
--    username VARCHAR(255) NOT NULL,
--    password VARCHAR(255) NOT NULL,
--    email VARCHAR(255),
--    usertype int
--);
--select* from Users
---- Societies table
--CREATE TABLE Societies (
--    society_id INT PRIMARY KEY IDENTITY,
--    society_name VARCHAR(255) NOT NULL,
--    description varchar(1000),
--	Society_event varchar(255)
--);

---- Positions table
--CREATE TABLE Positions (
--    position_id INT PRIMARY KEY IDENTITY,
--    society_id INT,
--	team_id INT,
--    position_name VARCHAR(255) NOT NULL,
--    description TEXT,
--    FOREIGN KEY (society_id) REFERENCES Societies(society_id),
--	FOREIGN KEY (team_id) REFERENCES Teams(team_id)
--);

--CREATE TABLE Teams (
--    team_id INT PRIMARY KEY IDENTITY,
--    society_id INT,
--    team_name VARCHAR(255) NOT NULL,
--    team_description TEXT,
--    FOREIGN KEY (society_id) REFERENCES Societies(society_id)
--);

------ Applications table
----CREATE TABLE Applications (
----    application_id INT PRIMARY KEY IDENTITY,
----    user_id INT,
----    position_id INT,
----	team_id INT,
----    application_date DATETIME DEFAULT CURRENT_TIMESTAMP,
----    application_status VARCHAR(50) DEFAULT 'pending',
----    FOREIGN KEY (user_id) REFERENCES Users(user_id),
----    FOREIGN KEY (position_id) REFERENCES Positions(position_id),
----	FOREIGN KEY (team_id) REFERENCES Teams(team_id)
----);

---- Teams table


---- Team Members table
--CREATE TABLE Team_Members (
--    team_member_id INT PRIMARY KEY IDENTITY,
--    team_id INT,
--    user_id INT,
--	position_id INT,
--    role VARCHAR(255),
--    FOREIGN KEY (team_id) REFERENCES Teams(team_id),
--    FOREIGN KEY (user_id) REFERENCES Users(user_id),
--	FOREIGN KEY (position_id) REFERENCES Positions(position_id),

--);

--select* from Societies

--INSERT INTO Societies (society_name, description, Society_event) 
--VALUES 
--    ('Fast Computing Society', NULL, NULL),
--    ('Fast Adventure Society', NULL, NULL),
--    ('Fast Production Society', NULL, NULL),
--    ('Fast Quran and Sunnah Society', NULL, NULL),
--    ('Fast Film Society', NULL, NULL),
--    ('Fast Takhleeq Society', NULL, NULL);

--	UPDATE Societies
--SET description = 
--    CASE 
--        WHEN society_name = 'Fast Computing Society' THEN 'A society focused on advancing computing technologies.'
--        WHEN society_name = 'Fast Adventure Society' THEN 'A society dedicated to promoting adventurous activities and exploration.'
--        WHEN society_name = 'Fast Production Society' THEN 'A society aimed at enhancing production techniques and practices.'
--        WHEN society_name = 'Fast Quran and Sunnah Society' THEN 'A society committed to studying and understanding Quran and Sunnah.'
--        WHEN society_name = 'Fast Film Society' THEN 'A society passionate about filmmaking and cinematic arts.'
--        WHEN society_name = 'Fast Takhleeq Society' THEN 'A society focused on fostering creativity and innovation.'
 
-- CREATE TABLE Applications (
--    application_id INT PRIMARY KEY IDENTITY,
--	username varchar(50),
--    user_id INT,
--	email varchar(50),
--	experience varchar(500),
--	selection varchar(500),
--    position varchar(50),
--	team varchar(50),
--	society varchar(50),
--    application_date DATETIME DEFAULT CURRENT_TIMESTAMP,
--    application_status VARCHAR(50) DEFAULT 'pending',
--    FOREIGN KEY (user_id) REFERENCES Users(user_id),
--);

--drop table Applications


-- Teams
--INSERT INTO Teams (society_id, team_name, team_description) 
--VALUES 
--(1, 'Operations', 'Team 1A Description'),
--(1, 'Logistics', 'Team 1B Description');

---- Users
--INSERT INTO Users (username, password, email, usertype) 
--VALUES 
--('user1', 'password1', 'user1@example.com', 1),
--('user2', 'password2', 'user2@example.com', 1),
--('user3', 'password3', 'user3@example.com', 1);

---- Positions
--INSERT INTO Positions (society_id, team_id, position_name, description) 
--VALUES 
--(1, 1, 'Head', 'President description'),
--(1, 1, 'Vice Head', 'Vice President description');

---- Team_Members
--INSERT INTO Team_Members (team_id, user_id, position_id, role) 
--VALUES 
--(1, 1, 1, 'Head'),
--(1, 2, 2, 'Vice Head');


--select* from Positions
--select* from Team_Members
--select* from Teams
--select* from Users




----------mali job----------------------------------------------




--CREATE TABLE EventRequests (
--    request_id INT PRIMARY KEY IDENTITY,
--    event_name VARCHAR(255),
--    description TEXT,
--    event_date DATETIME,
--    location VARCHAR(255),
--    request_type VARCHAR(20),
--    request_status VARCHAR(20),
--    requested_by INT,
--    requested_at DATETIME DEFAULT GETDATE(),
--    FOREIGN KEY (requested_by) REFERENCES Users(user_id)
--);


--CREATE SEQUENCE SequenceNameEvents
--    START WITH 1
--    INCREMENT BY 1;

--CREATE TABLE Events (
--    event_id INT PRIMARY KEY IDENTITY,
--    request_id INT DEFAULT (NEXT VALUE FOR SequenceNameEvents),
--    event_name VARCHAR(255) NOT NULL,
--    description TEXT,
--    event_date DATETIME,
--    location VARCHAR(255),
--    status VARCHAR(50) DEFAULT 'pending',
--    FOREIGN KEY (request_id) REFERENCES EventRequests(request_id)
--);







--INSERT INTO Events (event_name, description, event_date, location) 
--VALUES 
--    ('Event 1', 'Description for Event 1', '2024-04-01 09:00:00', 'Location 1'),
--    ('Event 2', 'Description for Event 2', '2024-04-15 14:00:00', 'Location 2');


 






--ALTER TABLE Societies
--ADD president_id INT,
--    mentor_id INT,
--    FOREIGN KEY (president_id) REFERENCES Users(user_id),
--    FOREIGN KEY (mentor_id) REFERENCES Users(user_id);


--ALTER TABLE Events
--ADD society_id INT,
--    FOREIGN KEY (society_id) REFERENCES Societies(society_id);


--ALTER TABLE EventRequests
--ADD society_id INT,
--    FOREIGN KEY (society_id) REFERENCES Societies(society_id);


--ALTER TABLE EventRequests
--ADD target_event VARCHAR(255);



--UPDATE Societies
--SET president_id = 
--    CASE 
--        WHEN society_name = 'Fast Computing Society' THEN 52  
--        WHEN society_name = 'Fast Adventure Society' THEN 53  
--        WHEN society_name = 'Fast Production Society' THEN 54 
--        WHEN society_name = 'Fast Quran and Sunnah Society' THEN 55  
--        WHEN society_name = 'Fast Film Society' THEN 56  
--        WHEN society_name = 'Fast Takhleeq Society' THEN 57 
--        ELSE NULL  
--    END,
--    mentor_id = 
--    CASE 
--        WHEN society_name = 'Fast Computing Society' THEN 46  
--        WHEN society_name = 'Fast Adventure Society' THEN 47 
--        WHEN society_name = 'Fast Production Society' THEN 48  
--        WHEN society_name = 'Fast Quran and Sunnah Society' THEN 49  
--        WHEN society_name = 'Fast Film Society' THEN 50  
--        WHEN society_name = 'Fast Takhleeq Society' THEN 51  
--        ELSE NULL  
--    END;


	
--INSERT INTO Users (username, password, email, usertype) 
--VALUES
--    ('mentor1', 'password1', 'mentor1@example.com', 1),
--	('mentor2', 'password2', 'mentor2@example.com', 2),
--	('mentor3', 'password3', 'mentor3@example.com', 3),
--	('mentor4', 'password4', 'mentor4@example.com', 4),
--	('mentor5', 'password5', 'mentor5@example.com', 5),
--	('mentor6', 'password6', 'mentor6@example.com', 6),
--    ('president1', 'password1', 'head1@example.com', 1),
--	('president2', 'password2', 'head2@example.com', 2),
--	('president3', 'password3', 'head3@example.com', 3),
--	('president4', 'password4', 'head4@example.com', 4),
--	('president5', 'password5', 'head5@example.com', 5),
--	('president6', 'password6', 'head6@example.com', 6);



--UPDATE Users
--SET usertype = 
--    CASE 
--        WHEN username = 'mentor1' THEN 16  
--        WHEN username = 'mentor2' THEN 16  
--        WHEN username = 'mentor3' THEN 16 
--        WHEN username = 'mentor4' THEN 16  
--        WHEN username = 'mentor5' THEN 16  
--        WHEN username = 'mentor6' THEN 16 
--        WHEN username = 'president1' THEN 7 
--        WHEN username = 'president2' THEN 7  
--        WHEN username = 'president3' THEN 7 
--        WHEN username = 'president4' THEN 7  
--        WHEN username = 'president5' THEN 7  
--        WHEN username = 'president6' THEN 7   

--        WHEN user_id = '1' THEN 1  
--        WHEN user_id = '2' THEN 1  
--        WHEN user_id = '3' THEN 1  
--        WHEN user_id = '4' THEN 1  
--        WHEN user_id = '5' THEN 1    
--        ELSE NULL  

--    END;

--INSERT INTO EventRequests (event_name, description, event_date, location, request_type, request_status, requested_by,requested_at, society_id) 
--VALUES 
--    ('Updated Event 1', 'Updated Description for Event 1', '2024-04-01 09:00:00', 'Updated Location 1', 'update', 'pending', 1,'2024-04-01 09:00:00', 1);
   
--select* from Users
select* from Events
select* from EventRequests
--select* from Societies
--select* from Positions
--select* from Teams
--select* from Applications
--select* from Team_Members





