USE master
GO

-- Drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

-- Create Tables
CREATE TABLE family (
	family_id int IDENTITY(1,1) NOT NULL,
	family_name varchar(200) NOT NULL,
	CONSTRAINT PK_family_id PRIMARY KEY (family_id)
)

CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	family_id int NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id),
	CONSTRAINT FK_users_family_id FOREIGN KEY (family_id) REFERENCES family(family_id),
	CONSTRAINT CHK_User CHECK (user_role IN ('parent', 'child'))
)

CREATE TABLE books (
	isbn bigint NOT NULL,
	title nvarchar(200) NOT NULL,
	author nvarchar(200) NOT NULL,
	user_id int NOT NULL,
	CONSTRAINT PK_isbn_user_id PRIMARY KEY(isbn, user_id),
	CONSTRAINT FK_books_user_id FOREIGN KEY (user_id) REFERENCES users(user_id)
)

CREATE TABLE reading_log (
	log_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	minutes_read int NOT NULL DEFAULT 0,
	book_format nvarchar(200) NOT NULL,
	isbn bigint NOT NULL,
	notes nvarchar(1024),
	CONSTRAINT PK_log_id PRIMARY KEY (log_id),
	CONSTRAINT FK_user_id FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_isbn FOREIGN KEY (isbn, user_id) REFERENCES books(isbn, user_id),
	CONSTRAINT CHK_Format CHECK (book_format IN (
		'Paper', 'Digital', 'Audiobook', 'Read-Aloud (Reader)', 'Read-Aloud (Listener)', 'Other'))
)

CREATE TABLE prizes (
	prize_id int IDENTITY(1,1) NOT NULL,
	family_id int NOT NULL,
	description nvarchar(200) NOT NULL,
	prize_title nvarchar(200) NOT NULL,
	milestone int NOT NULL,
	max_prize int NOT NULL,
	start_date date NOT NULL,
	end_date date NOT NULL,
	CONSTRAINT PK_prize_id PRIMARY KEY (prize_id),
	CONSTRAINT FK_prizes_family_id FOREIGN KEY (family_id) REFERENCES family(family_id),
)

CREATE TABLE user_prizes (
	user_id int NOT NULL,
	prize_id int NOT NULL,
	CONSTRAINT FK_user_prizes_user_id FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT FK_user_prizes_prize_id FOREIGN KEY (prize_id) REFERENCES prizes(prize_id)
)

-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO family (family_name) VALUES ('test');
INSERT INTO users (username, password_hash, salt, user_role, family_id) VALUES ('child','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','child', 1);
INSERT INTO users (username, password_hash, salt, user_role, family_id) VALUES ('parent','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','parent', 1);
GO

