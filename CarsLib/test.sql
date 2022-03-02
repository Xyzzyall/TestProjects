create table Customers (Id INT, Name VARCHAR(50));
create table Orders (Id INT,  CustomerId INT);

insert into Customers values (1, 'Max'), (2, 'Pavel'), (3, 'Ivan'), (4, 'Leonid');
insert into Orders values (1, 2), (2, 4);

select c.Name from Customers c
left outer join Orders o on c.Id = o.CustomerId
group by c.Name
having COUNT(o.Id) = 0;
