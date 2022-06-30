--Insertar
create PROCEDURE sp_Products
@ProductName AS NVARCHAR(40), @SupplierID as INT ,@CategoryID AS int,@QuantityPerUnit as int,@UnitPrice as money,
@UnitsInStock as SMALLINT,@UnitsOnOrder as SMALLINT,@ReorderLevel as SMALLINT,@Discontinued as bit
AS BEGIN
   	insert INTO Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,
UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)
 values(@ProductName ,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)

 END
 --lista
 alter proc sp_ListProd
 as begin 
  select ProductID,ProductName,CompanyName,CategoryName,QuantityPerUnit,UnitPrice,UnitsInStock, UnitsOnOrder,ReorderLevel,Discontinued,Products.CategoryID as 'idCategoria',products.SupplierID as 'SuplierID' from Products inner join Categories on Products.CategoryID=Categories.CategoryID
 inner join Suppliers on Products.SupplierID=Suppliers.SupplierID
 end

 exec sp_ListProd
 --busqueda
 alter procedure sp_BuscProd
  @name as int
  as begin
   select ProductID,ProductName,CompanyName,CategoryName,QuantityPerUnit,UnitPrice,UnitsInStock, UnitsOnOrder,ReorderLevel,Discontinued,Products.CategoryID,products.SupplierID from Products inner join Categories on Products.CategoryID=Categories.CategoryID
 inner join Suppliers on Products.SupplierID=Suppliers.SupplierID
 where ProductID = @name 
 end

 exec sp_BuscProd '8'
 --actualizar
 create procedure sp_ProdUpDate
@id as int,@ProductName AS NVARCHAR(40), @SupplierID as INT ,@CategoryID AS int,@QuantityPerUnit as int,@UnitPrice as money,
@UnitsInStock as SMALLINT,@UnitsOnOrder as SMALLINT,@ReorderLevel as SMALLINT,@Discontinued as bit
 as begin
 update Products 
 set ProductName =@ProductName,SupplierID=@SupplierID,CategoryID=@CategoryID,QuantityPerUnit=@QuantityPerUnit,UnitPrice = @UnitPrice,
 UnitsInStock =@UnitsInStock, UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,Discontinued=@Discontinued
 where ProductID = @id
  end

--eliminar  
  create procedure sp_ProdDelet
  @id as int
  as begin
  delete from Products where ProductID=@id
  end

  exec sp_BusCus

  
end
