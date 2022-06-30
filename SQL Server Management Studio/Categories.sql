
alter PROCEDURE SP_cATEGORIES  
@CategoryName AS NVARCHAR(15),@Description as NTEXT
as BEGIN
INSERT INTO Categories (CategoryName,Description,Picture)   
values(@CategoryName,@Description,'###')	  
   END

   create procedure sp_lisCat
   as begin
   select* from Categories
   end

   exec sp_lisCat

   create procedure sp_BusCat
   @id as int
   as begin
   select * from Categories where CategoryID=@id
   end

   alter procedure sp_ActCAt
   @id as int,@CategoryName AS NVARCHAR(15),@Description as NTEXT
   as begin
   update Categories
   set CategoryName=@CategoryName, Description=@Description
   where CategoryID=@id
   end

   exec sp_ActCAt 10,'Bolis frios','Calmar el calor'


   create procedure sp_DelCat
   @id as int
   as begin
   delete from Categories where CategoryID=@id
   end


   exec sp_BusCat 3