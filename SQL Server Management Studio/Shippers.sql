select * from Shippers

--lista
create procedure sp_listShip
  as begin 
  select * from Shippers
   end

   --buscar
   create procedure sp_BusShip
   @id as int
  as begin 
  select * from Shippers
   end
   --agregar
   CREATE PROCEDURE sp_Shipper
@companyName AS NVARCHAR(40),@phone as NVARCHAR(24)
AS BEGIN
   	INSERT INTO Shippers VALUES(@companyName,@phone)
   END
   --actualizar
   create procedure sp_ActShip
   @id as int,@companyName AS NVARCHAR(40),@phone as NVARCHAR(24)
  as begin 
  update Shippers set CompanyName=@companyName,Phone=@phone where ShipperID=@id
   end
   --eliminar
   create procedure sp_DelShip
   @id as int
   as begin
   delete from Shippers where ShipperID =@id
   end