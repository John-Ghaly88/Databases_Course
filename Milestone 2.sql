CREATE DATABASE GIU_DB
-----------------------------------------
USE GIU_DB

CREATE TABLE Users(
id int PRIMARY KEY IDENTITY,
firstName varchar(20),
lastName varchar(20),
password varchar(20),
gender BIT,
email varchar(50),
address varchar(10)
)

CREATE TABLE Instructor(
id int
CONSTRAINT pk_1 PRIMARY KEY(id),
CONSTRAINT fk_1 FOREIGN KEY(id) REFERENCES Users ON UPDATE CASCADE ON DELETE CASCADE,
rating decimal(2,1)
)

CREATE TABLE UserMobileNumber(
id int FOREIGN KEY REFERENCES Users ON UPDATE CASCADE ON DELETE CASCADE,
mobileNumber varchar(20),
CONSTRAINT pk PRIMARY KEY(id, mobileNumber)
)

CREATE TABLE Student(
id int
CONSTRAINT pk_2 PRIMARY KEY(id),
CONSTRAINT fk_2 FOREIGN KEY(id) REFERENCES Users ON UPDATE CASCADE ON DELETE CASCADE,
gpa decimal(3,2)
)

CREATE TABLE Admin(
id int
CONSTRAINT pk_3 PRIMARY KEY(id),
CONSTRAINT fk_3 FOREIGN KEY(id) REFERENCES Users ON UPDATE CASCADE ON DELETE CASCADE
)

CREATE TABLE Course(
id int PRIMARY KEY IDENTITY,
creditHours int,
name varchar(10),
courseDescription varchar(200),
price decimal(6,2),
content varchar(200),
adminId int FOREIGN KEY REFERENCES Admin,
instructorId int FOREIGN KEY REFERENCES Instructor,
accepted BIT
)

CREATE TABLE Assignment(
cid int FOREIGN KEY REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
number int,
type varchar(10),
fullGrade int,
weight decimal(4,1),
deadline datetime,
content varchar(200),
CONSTRAINT pk1 PRIMARY KEY(cid, number, type)
)

CREATE TABLE Feedback(
cid int FOREIGN KEY REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
number int IDENTITY,
comments varchar(100),
numberOfLikes int,
sid int FOREIGN KEY REFERENCES Student ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT pk2 PRIMARY KEY(cid, number)
)

CREATE TABLE Promocode (
code varchar(6) PRIMARY KEY,
issueDate datetime,
expiryDate datetime,
discount decimal (4,2),
adminId int FOREIGN KEY REFERENCES Admin ON UPDATE CASCADE ON DELETE CASCADE
)

CREATE TABLE StudentHasPromcode(
sid int,
code varchar(6),
CONSTRAINT PK_SHPC PRIMARY KEY (sid, code),
CONSTRAINT FK_SHPC_S FOREIGN KEY (sid) REFERENCES Student,
CONSTRAINT FK_SHPC_C FOREIGN KEY (code) REFERENCES Promocode ON UPDATE CASCADE ON DELETE CASCADE
)

CREATE TABLE CreditCard (
number varchar(15) PRIMARY KEY,
cardHolderName varchar(16),
expiryDate datetime,
cvv varchar(3)
)

CREATE TABLE StudentAddCreditCard(
sid int,
creditCardNumber varchar(15),
CONSTRAINT PK_SACC PRIMARY KEY (sid, creditCardNumber),
CONSTRAINT FK_SACC_S FOREIGN KEY (sid) REFERENCES Student,
CONSTRAINT FK_SACC_C FOREIGN KEY (creditCardNumber) REFERENCES CreditCard ON UPDATE CASCADE ON DELETE CASCADE
)

CREATE TABLE StudentTakeCourse(
sid int,
cid int,
instId int,
payedfor BIT,
grade decimal(5,2),
CONSTRAINT PK_STC PRIMARY KEY (sid, cid, instId),
CONSTRAINT FK_STC_S FOREIGN KEY (sid) REFERENCES Student,
CONSTRAINT FK_STC_C FOREIGN KEY (cid) REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
CONSTRAINT FK_STC_I FOREIGN KEY (instId) REFERENCES Instructor
)

CREATE TABLE StudentTakeAssignment(
sid int,
cid int,
assignmentNumber int,
assignmentType varchar(10),
grade decimal(5,2),
CONSTRAINT PK_STA PRIMARY KEY (sid, cid, assignmentNumber, assignmentType),
CONSTRAINT FK_STA_S FOREIGN KEY (sid) REFERENCES Student,
CONSTRAINT FK_STA_C FOREIGN KEY (cid, assignmentNumber, assignmentType) REFERENCES Assignment ON UPDATE CASCADE ON DELETE CASCADE
)

CREATE TABLE StudentRateInstructor(
sid int FOREIGN KEY REFERENCES Student,
instId int FOREIGN KEY REFERENCES Instructor,
rate decimal(2,1),
PRIMARY KEY(sid,instId)
)

CREATE TABLE StudentCertifyCourse(
sid int FOREIGN KEY REFERENCES Student,
cid int FOREIGN KEY REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
issueDate datetime,
PRIMARY KEY(sid,cid)
)

CREATE TABLE CoursePrerequisiteCourse(
cid int FOREIGN KEY REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
prerequisiteId int FOREIGN KEY REFERENCES Course,
PRIMARY KEY(cid,prerequisiteId)
)

CREATE TABLE InstructorTeachCourse(
instId int FOREIGN KEY REFERENCES Instructor,
cid int FOREIGN KEY REFERENCES Course ON UPDATE CASCADE ON DELETE CASCADE,
PRIMARY KEY(instId,cid)
)
-----------------------------------------
USE GIU_DB
--1 Unregistered User

GO
CREATE PROC studentRegister
@first_name varchar(20), @last_name varchar(20), @password varchar(20), @email varchar(50),
@gender bit, @address varchar(10), @ID int OUTPUT
AS
INSERT INTO Users(firstName, lastName, password, email, gender, address) VALUES (@first_name, @last_name, @password,
@email, @gender, @address)
SET @ID = (
SELECT id FROM Users U
WHERE U.firstName = @first_name AND U.lastName = @last_name AND U.password = @password
AND U.email = @email AND U.gender = @gender AND U.address = @address)
INSERT INTO Student VALUES (@ID, 0.00)

GO
CREATE PROC InstructorRegister
@first_name varchar(20), @last_name varchar(20), @password varchar(20), @email varchar(50),
@gender bit, @address varchar(10), @ID int OUTPUT
AS
INSERT INTO Users(firstName, lastName, password, email, gender, address) VALUES (@first_name, @last_name, @password,
@email, @gender, @address)
SET @ID = (
SELECT id FROM Users U
WHERE U.firstName = @first_name AND U.lastName = @last_name AND U.password = @password
AND U.email = @email AND U.gender = @gender AND U.address = @address)
INSERT INTO Instructor(id,rating) VALUES (@ID,0.00)



--2 Registered User

GO
CREATE PROC userLogin
@ID int, @password varchar(20), @Success BIT OUTPUT, @type INT OUTPUT
AS
IF EXISTS(SELECT id, password FROM dbo.Users WHERE id=@ID AND password=@password)
BEGIN
SET @Success = 1
IF EXISTS(SELECT * FROM dbo.Student WHERE id = @ID)
BEGIN 
SET @type = 1
END
IF EXISTS(SELECT * FROM dbo.Instructor WHERE id = @ID)
BEGIN
SET @type = 2
END
IF EXISTS(SELECT * FROM dbo.Admin WHERE id = @ID)
BEGIN
SET @type = 3
END
END
ELSE
BEGIN
SET @Success = 0
END

GO
CREATE PROC addMobile
@ID int, @mobile_number varchar(20)
AS
INSERT INTO UserMobileNumber(id, mobileNumber) VALUES (@ID, @mobile_number)



--3 Admin

GO
CREATE PROC AdminListInstr
AS
SELECT U.firstName, U.lastName FROM Instructor I INNER JOIN Users U ON I.id = U.id

GO
CREATE PROC AdminViewInstructorProfile
@instrId int
AS
SELECT U.firstName, U.lastName, U.gender, U.email, U.address, I.rating
FROM Instructor I INNER JOIN Users U ON I.id = U.id WHERE I.id = @instrId

GO
CREATE PROC AdminViewAllCourses
AS
SELECT C.name, C.creditHours, C.price, C.content, C.accepted FROM Course C

GO
CREATE PROC AdminViewNonAcceptedCourses
AS
SELECT  C.name, C.creditHours, C.price, C.content FROM Course C WHERE accepted = 0

GO
CREATE PROC AdminViewCourseDetails
@courseId int
AS
SELECT  C.name, C.creditHours, C.price, C.content, C.accepted FROM Course C WHERE id = @courseId

GO
CREATE PROC AdminAcceptRejectCourse
@adminId int, @courseId int
AS
UPDATE Course SET accepted = 1, adminId = @adminId WHERE id = @courseId

GO
CREATE PROC AdminCreatePromocode
@code varchar(6), @issueDate datetime, @expiryDate datetime, @discount decimal(4,2), @adminId
int
AS
INSERT INTO PromoCode(code, issueDate, expiryDate, discount , adminId) 
VALUES (@code, @issueDate, @expiryDate, @discount, @adminId)

GO
CREATE PROC AdminListAllStudents
AS
SELECT U.firstName, U.lastName FROM Student S INNER JOIN Users U ON U.id = S.id

GO
CREATE PROC AdminViewStudentProfile
@sid int
AS
SELECT U.firstName, U.lastName, U.gender, U.email, U.address, S.gpa 
FROM Student S INNER JOIN Users U ON U.id = S.id WHERE S.id = @sid

GO
CREATE PROC AdminIssuePromocodeToStudent
@sid int, @pid varchar(6)
AS
INSERT INTO StudentHasPromcode (sid, code) VALUES (@sid, @pid)



--4 Instructor

GO
CREATE PROC InstAddCourse
@creditHours int, @name varchar(10), @courseDescription varchar(200), @price decimal(6,2), @instructorId int
AS
DECLARE @course_id AS int
SET @course_id = (SELECT [cid] FROM InstructorTeachCourse WHERE instId = @instructorId)
INSERT INTO Course (id, creditHours, name, courseDescription, price, instructorId)
VALUES (@course_id , @creditHours, @name, @courseDescription, @price, @instructorId)

GO
CREATE PROC UpdateCourseContent
@instrId int, @courseId int, @content varchar(200)
AS
UPDATE Course
SET content = @content
WHERE id = @courseId AND instructorId = @instrId

GO
CREATE PROC UpdateCourseDescription
@instrId int, @courseId int, @description varchar(200)
AS
UPDATE Course
SET courseDescription = @description
WHERE id = @courseId AND instructorId = @instrId

GO
CREATE PROC AddAnotherInstructorToCourse
@instId int, @cid int, @adderIns int
AS
IF EXISTS (SELECT * FROM InstructorTeachCourse WHERE instId = @adderIns AND cid = @cid)
BEGIN
INSERT INTO InstructorTeachCourse VALUES (@instId, @cid)
END

GO
CREATE PROC InstructorViewAcceptedCoursesByAdmin
@instrId int
AS
SELECT id,name, creditHours FROM Course
WHERE accepted = 1 AND instructorId = @instrId


GO
CREATE PROC DefineCoursePrerequisites
@cid int, @prerequsiteId int
AS
INSERT INTO CoursePrerequisiteCourse
VALUES (@cid , @prerequsiteId)

GO
CREATE PROC DefineAssignmentOfCourseOfCertianType
@instId int, @cid int, @number int, @type varchar(10), @fullGrade int, @weight decimal(4,1), @deadline datetime, @content varchar(200)
AS
IF EXISTS (SELECT * FROM Course WHERE instructorId = @instId AND id = @cid)
BEGIN
INSERT INTO Assignment
VALUES (@cid , @number,  @type, @fullGrade, @weight, @deadline, @content)
END

GO
CREATE PROC ViewInstructorProfile
@instrId int
AS
SELECT U.firstName, U.lastName, U.gender, U.email, U.address, I.rating, M.mobileNumber
FROM Users U
INNER JOIN Instructor I ON U.id = I.id
INNER JOIN UserMobileNumber M ON U.id = M.id
WHERE I.id = @instrId

GO
CREATE PROC InstructorViewAssignmentsStudents
@instrId int, @cid int
AS
SELECT A.sid, A.cid, A.assignmentNumber, A.assignmentType
FROM StudentTakeAssignment A INNER JOIN Course C ON A.cid = C.id
WHERE A.cid = @cid AND C.instructorId = @instrId

GO
CREATE PROC InstructorgradeAssignmentOfAStudent
@instrId int, @sid int , @cid int, @assignmentNumber int, @type varchar(10), @grade decimal(5,2)
AS
IF EXISTS (SELECT * FROM Course WHERE instructorId = @instrId AND id = @cid)
BEGIN
UPDATE StudentTakeAssignment
SET grade = @grade
WHERE sid = @sid AND cid = @cid AND assignmentNumber = @assignmentNumber AND assignmentType = @type
END

GO
CREATE PROC ViewFeedbacksAddedByStudentsOnMyCourse
@instrId int, @cid int
AS
SELECT F.number, F.comments, F.numberOfLikes
FROM Feedback F
INNER JOIN Course C ON F.cid = C.id
WHERE C.instructorId = @instrId AND F.cid = @cid

GO
CREATE PROC updateInstructorRate
@instId int
AS
DECLARE @r AS decimal(2,1)
SET @r = (SELECT AVG (rate) FROM StudentRateInstructor WHERE instId = @instId)
UPDATE Instructor
SET rating = @r
WHERE id = @instId

GO
CREATE PROC InstructorIssueCertificateToStudent
@cid int , @sid int , @instId int, @issueDate datetime
AS
IF (EXISTS (SELECT * FROM StudentCertifyCourse C INNER JOIN StudentTakeCourse T ON C.sid = T.sid AND C.cid = T.cid)
AND EXISTS (SELECT * FROM Course WHERE instructorId = @instId AND id = @cid))
BEGIN
INSERT INTO StudentCertifyCourse
VALUES (@sid, @cid, @issueDate)
END



--5 Registered Student

GO
CREATE PROC viewMyProfile
@id INT
AS
SELECT *
FROM Student JOIN Users ON Users.id = Student.id
WHERE Student.id = @id

GO
CREATE PROC editMyProfile
@id int, @firstName varchar(20), @lastName varchar(20), @password VARCHAR(20), @gender BIT, @email VARCHAR(20), @address VARCHAR(20)
AS
UPDATE Users SET firstName = @firstName, lastName = @lastName, password = @password, gender = @gender, email = @email, address = @address WHERE id  = @id

 GO
 CREATE PROC availableCourses
 AS
 SELECT name, id
 FROM Course c
 WHERE c.accepted = 1

 GO
 CREATE PROC courseInformation
 @id INT
 AS
 SELECT c.id, c.creditHours, c.name, c.courseDescription, c.price, c.content, c.adminId, c.instructorId, c.accepted, u.firstName, u.lastName
 FROM Course c Join Instructor i on c.instructorId = i.id Join Users u on u.id = i.id
 WHERE c.id = @id

 GO
 CREATE PROC enrollInCourse
 @sid INT, @cid INT, @instr INT
 AS
 INSERT INTO StudentTakeCourse (sid, cid, instId)
 VALUES (@sid, @cid, @instr)

 GO
 CREATE PROC addCreditCard
 @sid int, @number varchar(15), @cardHolderName varchar(16), @expiryDate datetime, @cvv varchar(3)
 AS
 BEGIN
 INSERT INTO CreditCard(number, cardHolderName, expiryDate ,cvv)
 VALUES(@number, @cardHolderName, @expiryDate, @cvv)
 END
 INSERT INTO StudentAddCreditCard(sid, creditCardNumber)
 VALUES(@sid, @number)

 GO
 CREATE PROC viewPromoCode
 @sid INT
 AS
 SELECT p.*
 FROM PromoCode p INNER JOIN StudentHasPromcode s ON p.code = s.code 
 WHERE s.sid = @sid

GO
CREATE PROC payCourse
@sid INT, @cid INT
AS
BEGIN
Update StudentTakeCourse 
SET
payedfor = 1
WHERE
sid = @sid AND cid = @cid
END

GO
CREATE PROC enrollInCourseViewContent
@id INT, @cid INT
AS
IF(EXISTS(SELECT* FROM StudentTakeCourse s WHERE s.sid = @id AND s.cid = @cid ))
BEGIN
SELECT c.content 
FROM course c 
WHERE c.id = @cid
END

GO
CREATE PROC viewAssign
@courseId INT, @Sid VARCHAR(10)
AS
SELECT a.*
FROM Assignment a join StudentTakeAssignment s ON a.number = s.assignmentNumber
WHERE s.sid = @sid AND s.cid = @courseId

GO
CREATE PROC submitAssign
@assignType VARCHAR(10), @assignnumber int, @sid INT, @cid INT
AS
INSERT INTO StudentTakeAssignment(sid,cid,assignmentNumber,assignmentType) 
VALUES (@sid,@cid,@assignnumber,@assignType)

GO
CREATE PROC viewAssignGrades
@assignnumber int, @assignType VARCHAR(10), @cid INT, @sid INT
AS
SELECT s.grade
FROM StudentTakeAssignment s
WHERE s.assignmentNumber = @assignnumber AND s.assignmentType = @assignType AND s.cid = @cid And s.sid = @sid 

GO
CREATE PROC viewFinalGrade
@cid INT, @sid INT
AS
SELECT s.grade
FROM StudentTakeCourse s
WHERE s.cid = @cid AND s.sid = @sid

GO
CREATE PROC addFeedBack
@comment VARCHAR(100), @cid INT, @sid INT
AS
INSERT INTO FeedBack(cid, sid, comments) 
VALUES(@cid,@sid,@comment)

GO
CREATE PROC rateInstructor
@rate DECIMAL (2,1), @sid INT, @instId INT
AS 
INSERT INTO StudentRateInstructor(sid, instId, rate) 
Values(@sid,@instId,@rate)

GO
CREATE PROC viewCertificate
@cid INT, @sid INT
AS 
SELECT * 
FROM StudentCertifyCourse s
WHERE s.sid = @sid AND s.cid = @cid
-----------------------------------------
