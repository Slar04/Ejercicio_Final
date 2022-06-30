select * from [Order Details]
--lista
create procedure sp_ListOrdDet
as begin
select OrderID,[Order Details].ProductID,ProductName as 'ProductName',[Order Details].UnitPrice,Quantity,Discount from [Order Details] 
inner join Products on [Order Details].ProductID = Products.ProductID
end

--busqueda
create procedure sp_BusqOrdDet
@id as int
as begin
select OrderID,[Order Details].ProductID,ProductName as 'ProductName',[Order Details].UnitPrice,Quantity,Discount from [Order Details] 
inner join Products on [Order Details].ProductID = Products.ProductID where OrderID=@id
end
--insertar
CREATE PROCEDURE sp_ordersDetail
@OrderID as int,@ProductID AS INT,@UnitPrice as money,@Quantity as int,@Discount as REAL
AS BEGIN
INSERT INTO [Order Details](OrderID,ProductID,UnitPrice,Quantity,Discount) 
values( @OrderID,@ProductID,@UnitPrice,@Quantity,@Discount)
END
--actualizar
CREATE PROCEDURE sp_ActOrD
@OrderID as int,@ProductID AS INT,@UnitPrice as money,@Quantity as int,@Discount as REAL
AS BEGIN
update [Order Details] set ProductID =@ProductID,UnitPrice=@UnitPrice,Quantity=@Quantity,Discount=@Discount
where OrderID=@OrderID
END
--eliminar
create procedure sp_DelOrD
@id as int
as begin
delete from [Order Details] where OrderID=@id
end

exec sp_LisEmpl