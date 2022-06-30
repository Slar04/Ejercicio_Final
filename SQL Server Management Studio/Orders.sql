--Lista
create procedure sp_listaOrder
as begin
select * from Orders
end

--Buscar
create procedure sp_BusOrder
@id as int
as begin
select * from Orders where OrderID = @id
end
--Crear
CREATE PROCEDURE sp_Orders
@CustomerID as nchar(5),@EmployeeID AS INT,@OrderDate as DATETIME,@RequiredDate AS DATETIME,@ShippedDate as DATETIME,
@ShipVia as INT,@Freight as money,@ShipName as NVARCHAR(40),@ShipAddress NVARCHAR(60),@ShipCity as NVARCHAR(15),
@ShipPostalCode as NVARCHAR(10),@ShipCountry as NVARCHAR(15)
as BEGIN
INSERT INTO Orders(CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,
ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry) 
VALUES(@CustomerID,@EmployeeID,@OrderDate,@RequiredDate,@ShippedDate,@ShipVia,@Freight,@ShipName,@ShipAddress,
@ShipCity,'NORTE',@ShipPostalCode,@ShipPostalCode)
END

--Editar
CREATE PROCEDURE sp_InsertOrders
@id as int,@CustomerID as nchar(5),@EmployeeID AS INT,@OrderDate as DATETIME,@RequiredDate AS DATETIME,@ShippedDate as DATETIME,
@ShipVia as INT,@Freight as money,@ShipName as NVARCHAR(40),@ShipAddress NVARCHAR(60),@ShipCity as NVARCHAR(15),@ShipRegion as nvarchar(15),
@ShipPostalCode as NVARCHAR(10),@ShipCountry as NVARCHAR(15)
as BEGIN
update Orders set CustomerID=@CustomerID,EmployeeID=@EmployeeID,OrderDate=@OrderDate,RequiredDate=@RequiredDate,ShippedDate=@ShippedDate,ShipVia=@ShipVia,Freight=@Freight,
ShipName=@ShipName,ShipAddress=@ShipAddress,ShipCity=@ShipCity,ShipRegion=@ShipRegion,ShipPostalCode=@ShipPostalCode,ShipCountry=@ShipCountry where OrderID=@id

END


--eliminar
create procedure sp_DelOrders
@id as int
as begin
delete from Orders where OrderID=@id
end
