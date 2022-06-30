select * from Customers


----Original para hacer la busqueda
--alter PROCEDURE sp_BusCustomer  
--@CustomerID as Nvarchar(10) 
--as BEGIN
--select CustomerID as 'ID',CompanyName as 'Nombre Compañia',ContactName as'Nombre de Contacto',ContactTitle as 'Titulo de Contacto' ,Address as 'Direccion',
--City as 'Ciudad',region as 'Region',PostalCode as 'Codigo Post.',Country as'Pais',phone as 'Teléfono',Fax from Customers where CustomerID like '%'+ @CustomerID +'%'
--order by CompanyName
--   END
exec  DSAWE


--Insertar
  Alter PROCEDURE sp_custoners  
@CustomerID as NCHAR(5),@CompanyName as NVARCHAR(40),@ContactName AS NVARCHAR(30),@ContactTitle AS NVARCHAR(30),@Address as NVARCHAR(60),
@City as NVARCHAR(15),@Region as nvarchar(15),@PostalCode as NVARCHAR(10),@Country as NVARCHAR(15),@phone NVARCHAR(24),@Fax as nvaRCHAR(24)
as BEGIN
insert INTO Customers(CustomerID,CompanyName,ContactName,ContactTitle,Address,City,region,PostalCode,Country,Phone,Fax)
values(@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@phone,@Fax)
   END



   alter PROCEDURE sp_ActualizaCusto
@CustomerID as NCHAR(5),@CompanyName as NVARCHAR(40),@ContactName AS NVARCHAR(30),@ContactTitle AS NVARCHAR(30),@Address as NVARCHAR(60),
@City as NVARCHAR(15),@Region as nvarchar(10),@PostalCode as NVARCHAR(10),@Country as NVARCHAR(15),@phone NVARCHAR(24),@Fax as nvaRCHAR(24)
as BEGIN
update  Customers
set CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle,Address=@Address
,City=@City,region=@Region,PostalCode=@PostalCode,Country=@Country,phone=@phone,Fax=@Fax
where CustomerID=@CustomerID
   END

   execute sp_ActualizaCusto  'DSAWE','Hola','eqwewq','hhshshs','SDASD','ASDASD','aSDSAD','sasd','mexico','ssscx','5421' 
      
   exec sp_BusCus

   create procedure sp_EliminarCust
   @id as nvarchar(10)
   as begin
   delete from Customers where CustomerID= @id
   end


  --Para continuar haciendo los ejercicios






  --Lista
  alter procedure sp_BusCus
  as
  begin
   select CustomerID as 'ID',CompanyName as 'Nombre Compañia',ContactName as 'Nombre de Contacto',ContactTitle 'Titulo de Contacto' ,Address as 'Direccion',
City as 'Ciudad',region as 'Region',PostalCode as 'Codigo Post.',Country 'Pais',phone 'Teléfono',Fax from Customers 
order by CustomerID
end

  


  select * from Customers
