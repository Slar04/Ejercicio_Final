select * from Suppliers
--Agregar
Alter PROCEDURE sp_Supplier
@CompanyName as NVARCHAR(40),@ContactName AS NVARCHAR(30),@ContactTitle as NVARCHAR(30),@Address as NVARCHAR(60),
@City as NVARCHAR(15),@region as nvarchar(15),@PostalCode as NVARCHAR(10),@Country AS NVARCHAR(15),@Phone as NVARCHAR(24),@Fax as NVARCHAR(24)
AS BEGIN
   	insert into Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage)
    VALUES(@CompanyName,@ContactName,@ContactTitle,@Address,@City,@region,@PostalCode,@Country,@Phone,@Fax,'#')
   END

   --Buscar 
   create procedure sp_BuscaSpp
   @id as int
  as begin 
  select * from Suppliers where SupplierID=@id
   end

   --Lista 
   create procedure sp_ListSpp  
  as begin 
  select * from Suppliers
   end
   --Actualizar
   Create PROCEDURE sp_ActualizaSpp
@id as int,@CompanyName as NVARCHAR(40),@ContactName AS NVARCHAR(30),@ContactTitle as NVARCHAR(30),@Address as NVARCHAR(60),
@City as NVARCHAR(15),@Region as nvarchar(15),@PostalCode as NVARCHAR(10),@Country AS NVARCHAR(15),@Phone as NVARCHAR(24),@Fax as NVARCHAR(24)
AS BEGIN
   	update Suppliers set CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle= @ContactTitle,Address =@Address,City=@City ,Region=@Region,PostalCode=@PostalCode,
	Country=@Country,Phone=@Phone,Fax=@Fax
    where SupplierID=@id
   END

   --eliminar
   create procedure sp_DelSpp
   @id as int
   as begin
   delete from Suppliers where SupplierID= @id
   end