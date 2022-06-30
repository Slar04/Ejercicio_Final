select * from Employees
--insertar
ALTER   PROCEDURE InsEmployes
@LastName AS NVARCHAR(20),@FirstName AS NVARCHAR(10),@Title as NVARCHAR(30),@TitleOfCourtesy as NVARCHAR(25),@BirthDate AS DATETIME,@HireDate as DATETIME,
@Address NVARCHAR(60),@City as NVARCHAR(15),@Region as nvarchar(15),@PostalCode as NVARCHAR(10),@Country AS NVARCHAR(15),@HomePhone as NVARCHAR(24),@Extension as NVARCHAR(4),@Notes AS NTEXT
AS BEGIN
   	INSERT INTO  Employees (LastName,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,
Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath) 
VALUES(@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,
@Region,@PostalCode,@Country,@HomePhone,@Extension,NULL,@Notes,1,'//c://')
   END

   --lista
   create procedure sp_LisEmpl 
   as begin
     select * from Employees
   end

   exec sp_LisEmpl
  exec InsEmployes   'Santiago','Alberto','Master','MR','2022-06-30','2022-06-30','dsdsdsdsd','mexico','Norte','344','dddd','3541','12','asda6sd5a4s6d54as'
   --buscar
   create procedure sp_BusEmpl 
   @id as int
   as begin
     select * from Employees where EmployeeID=@id
   end
   --actualizar
   alter   PROCEDURE sp_ActEmployes
@id as int,@LastName AS NVARCHAR(20),@FirstName AS NVARCHAR(10),@Title as NVARCHAR(30),@TitleOfCourtesy as NVARCHAR(25),@BirthDate AS DATETIME,@HireDate as DATETIME,
@Address NVARCHAR(60),@City as NVARCHAR(15),@region as nvarchar(15),@PostalCode as NVARCHAR(10),@Country AS NVARCHAR(15),@HomePhone as NVARCHAR(24),@Extension as NVARCHAR(4),@Notes AS NTEXT
AS BEGIN
   	update  Employees set LastName=@LastName,FirstName=@FirstName,Title=@Title,TitleOfCourtesy=@TitleOfCourtesy,BirthDate=@BirthDate,HireDate=@HireDate,
Address=@Address,City=@City,Region=@region,PostalCode=@PostalCode,Country=@Country,HomePhone=@HomePhone,Extension=@Extension,Notes=@Notes
where EmployeeID=@id
   END


   --eliminar
   create procedure sp_DelEmpl 
   @id as int
   as begin
     delete from Employees where EmployeeID= @id
   end