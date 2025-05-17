CREATE DATABASE FLEXER

--TABLE CREATION

CREATE TABLE users (
	user_id int identity(1,1) PRIMARY KEY,
	user_name varchar (50),
	user_age int,
	user_address varchar (200),
	user_contact varchar (20),
	user_email varchar (100),
	user_password varchar (50)
)



CREATE TABLE trainers (
	trainer_id int identity(1,1) PRIMARY KEY,
    user_id int FOREIGN KEY REFERENCES users(user_id)
)

CREATE TABLE trainer_info(
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	rating decimal (3,1),
	qualification varchar(50),
	experience int,
	specialty varchar(50),
	approval bit,
)

CREATE TABLE members (
    member_id int identity(1,1) PRIMARY KEY,
    user_id int FOREIGN KEY REFERENCES users(user_id)
)

CREATE TABLE gym_owners (
	gym_owner_id int identity(1,1) PRIMARY KEY,
    user_id int FOREIGN KEY REFERENCES users(user_id),
	gym_id int FOREIGN KEY REFERENCES gym(gym_id),
	approval bit
)

CREATE TABLE gym_admin (
	admin_id int identity(1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id)
)

CREATE TABLE machines (
	machine_id int identity(1,1) PRIMARY KEY,
	machine_name varchar(50)
)

CREATE TABLE exercises (
	exerccise_id int identity(1,1) PRIMARY KEY,
	exercise_name varchar(50),
	target_muscle varchar(50),
	machine_id int FOREIGN KEY REFERENCES machines(machine_id)
)

CREATE TABLE chosen_exercise(
	chosen_exercise_id int identity(1,1) PRIMARY KEY,
	exercise_id int FOREIGN KEY REFERENCES exercises(exerccise_id),
	reps int,
	sets int,
	rest_intervals varchar(50),
	workout_id int FOREIGN KEY REFERENCES workout(workout_id)
)

CREATE TABLE workout (
	workout_id int identity(1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	created_by varchar(20)
)

CREATE TABLE workout_info (
    workout_id int FOREIGN KEY REFERENCES workout(workout_id),
    experience_needed varchar(20),
    goal varchar(50),
	duration int,
    monday_flag bit,
    tuesday_flag bit,
    wednesday_flag bit,
    thursday_flag bit,
    friday_flag bit,
    saturday_flag bit
);

CREATE TABLE meal(
	meal_id int identity(1,1) PRIMARY KEY,
	meal_name varchar (50),
	fat int, 
	protein int, 
	carbs int,
	fiber int,
	portion int,
	meal_type varchar (50)
)

CREATE TABLE allergens (
	allergen_id int identity(1,1) PRIMARY KEY,
	allergen varchar(50)
)

CREATE TABLE meal_allergen (
	allergen_id int FOREIGN KEY REFERENCES allergens(allergen_id),
	meal_id int FOREIGN KEY REFERENCES meal(meal_id)
)

CREATE TABLE diet_plan (
	diet_plan_id int identity(1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	created_by varchar(20),
	goal varchar (50),
	calories int
)

CREATE TABLE diet_meal(
	diet_plan_id int FOREIGN KEY REFERENCES diet_plan(diet_plan_id),
	meal_id int FOREIGN KEY REFERENCES meal(meal_id)
)

CREATE TABLE appointment (
	app_id int identity(1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	schedule varchar(50),
	workout_id int FOREIGN KEY REFERENCES workout(workout_id),
	diet_plan_id int FOREIGN KEY REFERENCES diet_plan(diet_plan_id) ,
	approval bit,
)

CREATE TABLE user_feedback(
	feedback_id int identity(1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	feedback decimal (3,1),
	comment varchar(100)
)

CREATE TABLE trainer_rating (
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	avg_rating decimal(3,1)
)


CREATE TABLE active_wplans(
	plan_id int identity (1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	workout_id int FOREIGN KEY REFERENCES workout(workout_id),
	completion int,
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id)
)

CREATE TABLE active_dplans(
	plan_id int identity (1,1) PRIMARY KEY,
	user_id int FOREIGN KEY REFERENCES users(user_id),
	diet_plan_id int FOREIGN KEY REFERENCES diet_plan(diet_plan_id),
	completion int,
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id)
)

CREATE TABLE progress_feedback(
	user_id int FOREIGN KEY REFERENCES users(user_id),
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	comment varchar (255)
)

CREATE TABLE gym_locations(
	loc_id int identity(1,1) PRIMARY KEY,
	gym_id int FOREIGN KEY REFERENCES gym(gym_id),
	loc varchar(100)
)

CREATE TABLE gym(
	gym_id int identity(1,1) PRIMARY KEY,
	num_machines int,
	num_members int, 
	price int,
	maintenance_fee int
)

CREATE TABLE trainer_gym(
	trainer_id int FOREIGN KEY REFERENCES trainers(trainer_id),
	gym_id int FOREIGN KEY REFERENCES gym(gym_id),
)

CREATE TABLE audit_trail (
    audit_id INT IDENTITY(1,1) PRIMARY KEY,
    table_name VARCHAR(50),
    record_id INT,
    action_type CHAR(1),
    action_date DATETIME,
    source_table VARCHAR(50)
)

CREATE TABLE user_gym(
	gym_id int FOREIGN KEY REFERENCES gym(gym_id),
	user_id int FOREIGN KEY REFERENCES users(user_id)
)

BULK INSERT gym_admin
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\gym_admin.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);


select * from users
select * from members
select * from trainers
select * from gym_owners
select * from gym_admin
select * from machines
select * from exercises
select * from chosen_exercise
select * from workout
select * from workout_info
select * from meal
select * from allergens
select * from meal_allergen
select * from diet_plan
select * from diet_meal
select * from user_feedback
select * from trainer_rating
select * from appointment 
select * from active_wplans
select * from active_dplans
select * from trainer_info
select * from progress_feedback
select * from trainer_request
select * from trainer_gym

drop table gym_owners
drop table trainers
drop table members
drop table users
drop table chosen_exercise
drop table workout
drop table meal
drop table allergens
drop table meal_allergen
drop table workout_info
drop table appointment
drop table trainer_rating
drop table user_feedback
drop table active_wplans
drop table active_dplans
drop table trainer_info
drop table trainer_request


--TRIGGERS
-- Create trigger for INSERT, UPDATE, DELETE on trainers table
CREATE TRIGGER trainers_audit_trigger
ON trainers
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'trainers'
    SET @RecordId = COALESCE((SELECT trainer_id FROM inserted), (SELECT trainer_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'trainers')
END;

-- Create trigger for INSERT, UPDATE, DELETE on users table
CREATE TRIGGER users_audit_trigger
ON users
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'users'
    SET @RecordId = COALESCE((SELECT user_id FROM inserted), (SELECT user_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'users')
END;

-- Create trigger for INSERT, UPDATE, DELETE on trainer_info table
CREATE TRIGGER trainer_info_audit_trigger
ON trainer_info
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'trainer_info'
    SET @RecordId = COALESCE((SELECT trainer_id FROM inserted), (SELECT trainer_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'trainer_info')
END;

-- Create trigger for INSERT, UPDATE, DELETE on members table
CREATE TRIGGER members_audit_trigger
ON members
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'members'
    SET @RecordId = COALESCE((SELECT member_id FROM inserted), (SELECT member_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'members')
END;

CREATE TRIGGER gym_owners_audit_trigger
ON gym_owners
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'gym_owners'
    SET @RecordId = COALESCE((SELECT gym_owner_id FROM inserted), (SELECT gym_owner_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'gym_owners')
END;

CREATE TRIGGER gym_admin_audit_trigger
ON gym_admin
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'gym_admin'
    SET @RecordId = COALESCE((SELECT admin_id FROM inserted), (SELECT admin_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'gym_admin')
END;


-- Create trigger for INSERT, UPDATE, DELETE on machines table
CREATE TRIGGER machines_audit_trigger
ON machines
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'machines'
    SET @RecordId = COALESCE((SELECT machine_id FROM inserted), (SELECT machine_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'machines')
END;


-- Create trigger for INSERT, UPDATE, DELETE on exercises table
CREATE TRIGGER exercises_audit_trigger
ON exercises
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'exercises'
    SET @RecordId = COALESCE((SELECT exerccise_id FROM inserted), (SELECT exerccise_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'exercises')
END;


-- Create trigger for INSERT, UPDATE, DELETE on chosen_exercise table
CREATE TRIGGER chosen_exercise_audit_trigger
ON chosen_exercise
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'chosen_exercise'
    SET @RecordId = COALESCE((SELECT chosen_exercise_id FROM inserted), (SELECT chosen_exercise_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'chosen_exercise')
END;

-- Create trigger for INSERT, UPDATE, DELETE on workout table
CREATE TRIGGER workout_audit_trigger
ON workout
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'workout'
    SET @RecordId = COALESCE((SELECT workout_id FROM inserted), (SELECT workout_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'workout')
END;

-- Create trigger for INSERT, UPDATE, DELETE on workout_info table
CREATE TRIGGER workout_info_audit_trigger
ON workout_info
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'workout_info'
    SET @RecordId = COALESCE((SELECT workout_id FROM inserted), (SELECT workout_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'workout_info')
END;

-- Create trigger for INSERT, UPDATE, DELETE on meal table
CREATE TRIGGER meal_audit_trigger
ON meal
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'meal'
    SET @RecordId = COALESCE((SELECT meal_id FROM inserted), (SELECT meal_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'meal')
END;


-- Create trigger for INSERT, UPDATE, DELETE on allergens table
CREATE TRIGGER allergens_audit_trigger
ON allergens
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'allergens'
    SET @RecordId = COALESCE((SELECT allergen_id FROM inserted), (SELECT allergen_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'allergens')
END;

-- Create trigger for INSERT, UPDATE, DELETE on meal_allergen table
CREATE TRIGGER meal_allergen_audit_trigger
ON meal_allergen
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'meal_allergen'
    SET @RecordId = COALESCE((SELECT allergen_id FROM inserted), (SELECT allergen_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'meal_allergen')
END;


-- Create trigger for INSERT, UPDATE, DELETE on diet_plan table
CREATE TRIGGER diet_plan_audit_trigger
ON diet_plan
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'diet_plan'
    SET @RecordId = COALESCE((SELECT diet_plan_id FROM inserted), (SELECT diet_plan_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'diet_plan')
END;


-- Create trigger for INSERT, UPDATE, DELETE on diet_meal table
CREATE TRIGGER diet_meal_audit_trigger
ON diet_meal
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'diet_meal'
    SET @RecordId = COALESCE((SELECT diet_plan_id FROM inserted), (SELECT diet_plan_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'diet_meal')
END;


-- Create trigger for INSERT, UPDATE, DELETE on appointment table
CREATE TRIGGER appointment_audit_trigger
ON appointment
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'appointment'
    SET @RecordId = COALESCE((SELECT app_id FROM inserted), (SELECT app_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'appointment')
END;

CREATE TRIGGER user_feedback_audit_trigger
ON user_feedback
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'user_feedback'
    SET @RecordId = COALESCE((SELECT feedback_id FROM inserted), (SELECT feedback_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'user_feedback')
END;

CREATE TRIGGER trainer_rating_audit_trigger
ON trainer_rating
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'trainer_rating'
    SET @RecordId = COALESCE((SELECT trainer_id FROM inserted), (SELECT trainer_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'trainer_rating')
END;


-- Create trigger for INSERT, UPDATE, DELETE on active_wplans table
CREATE TRIGGER active_wplans_audit_trigger
ON active_wplans
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'active_wplans'
    SET @RecordId = COALESCE((SELECT plan_id FROM inserted), (SELECT plan_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'active_wplans')
END;

-- Create trigger for INSERT, UPDATE, DELETE on active_dplans table
CREATE TRIGGER active_dplans_audit_trigger
ON active_dplans
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'active_dplans'
    SET @RecordId = COALESCE((SELECT plan_id FROM inserted), (SELECT plan_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'active_dplans')
END;

CREATE TRIGGER progress_feedback_audit_trigger
ON progress_feedback
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'progress_feedback'
    SET @RecordId = COALESCE((SELECT TOP 1 user_id FROM inserted), (SELECT TOP 1 user_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'progress_feedback')
END;

-- Create trigger for INSERT, UPDATE, DELETE on gym_locations table
CREATE TRIGGER gym_locations_audit_trigger
ON gym_locations
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'gym_locations'
    SET @RecordId = COALESCE((SELECT loc_id FROM inserted), (SELECT loc_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'gym_locations')
END;

CREATE TRIGGER gym_audit_trigger
ON gym
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'gym'
    SET @RecordId = COALESCE((SELECT gym_id FROM inserted), (SELECT gym_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'gym')
END;

-- Create trigger for INSERT, UPDATE, DELETE on trainer_gym table
CREATE TRIGGER trainer_gym_audit_trigger
ON trainer_gym
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ActionType CHAR(1)
    DECLARE @TableName VARCHAR(50)
    DECLARE @RecordId INT

    IF EXISTS(SELECT * FROM inserted) AND EXISTS(SELECT * FROM deleted)
    BEGIN
        SET @ActionType = 'U' -- Update
    END
    ELSE IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @ActionType = 'I' -- Insert
    END
    ELSE
    BEGIN
        SET @ActionType = 'D' -- Delete
    END

    SET @TableName = 'trainer_gym'
    SET @RecordId = COALESCE((SELECT TOP 1 trainer_id FROM inserted), (SELECT TOP 1 trainer_id FROM deleted))

    INSERT INTO audit_trail (table_name, record_id, action_type, action_date, source_table)
    VALUES (@TableName, @RecordId, @ActionType, GETDATE(), 'trainer_gym')
END;


BULK INSERT users
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\user.tsv'
WITH (
    FIELDTERMINATOR = '\t',  -- Specify the field terminator (tab)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT trainers
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\trainer.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT members
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\member.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

-- BULK INSERT for gym table
BULK INSERT gym
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\gym.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT trainer_gym
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\trainer_gym.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT trainer_rating
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\trainer_rating.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

-- BULK INSERT for gym_locations table
BULK INSERT gym_locations
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\gym_locations.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

-- BULK INSERT for machines table
BULK INSERT machines
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\machines.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

-- BULK INSERT for exercises table
BULK INSERT exercises
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\exercises.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

-- BULK INSERT for meal table
BULK INSERT meal
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\meal.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

-- BULK INSERT for allergens table
BULK INSERT allergens
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\allergens.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT user_feedback FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\user_feedback.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT meal_allergen
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\meal_allergen.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT progress_feedback
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\progress_feedback.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT active_dplans
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\active_dplans.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT active_wplans
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\active_wplans.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT appointment
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\appointment.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT diet_meal
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\diet_meal.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT diet_plan
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\diet_plan.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT gym_admin
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\gym_admin.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT gym_owners
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\gym_owner.csv'
WITH (
    FIELDTERMINATOR = ',',  -- Specify the field terminator (comma)
    ROWTERMINATOR = '\n',    -- Specify the row terminator (newline)
    FIRSTROW = 2,            -- Skip the first row if it contains headers
    CODEPAGE = 'RAW'         -- Use raw data format
);

BULK INSERT 'workout\malip\Desktop\DBProject\project\project\csv\workout.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);

BULK INSERT workout_info
FROM 'C:\Users\malip\Desktop\DBProject\project\project\csv\workoui_info.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',    
    FIRSTROW = 2,            
    CODEPAGE = 'RAW'         
);


SELECT U.user_id, U.user_name, U.user_age, U.user_address, U.user_contact, U.user_email, A.trainer_id, TG.gym_id
FROM users U
JOIN appointment A ON U.user_id = A.user_id
JOIN trainers T ON A.trainer_id = T.trainer_id
JOIN trainer_gym TG ON T.trainer_id = TG.trainer_id
WHERE A.trainer_id = 1;

SELECT U.user_id, U.user_name, U.user_age, U.user_address, U.user_contact, U.user_email
FROM users U
JOIN appointment A ON U.user_id = A.user_id
JOIN trainers T ON A.trainer_id = T.trainer_id
JOIN trainer_gym TG ON T.trainer_id = TG.trainer_id
JOIN gym G ON TG.gym_id = G.gym_id
JOIN active_dplans AD ON U.user_id = AD.user_id
WHERE G.gym_id = 3 AND AD.diet_plan_id = 2;

SELECT U.user_id, U.user_name, U.user_age, U.user_address, U.user_contact, U.user_email
FROM users U
JOIN appointment A ON U.user_id = A.user_id
JOIN trainers T ON A.trainer_id = T.trainer_id
JOIN active_dplans AD ON U.user_id = AD.user_id
WHERE T.trainer_id = 3 AND AD.diet_plan_id = 2

SELECT COUNT(DISTINCT CE.exercise_id) AS member_count from chosen_exercise CE
JOIN exercises E ON CE.exercise_id = E.exerccise_id
JOIN chosen_exercise CE ON ce
WHERE CE.monday = 1;
AND E.machine_id = 4;

