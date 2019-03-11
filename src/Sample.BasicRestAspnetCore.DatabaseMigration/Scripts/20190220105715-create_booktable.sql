use `rest_aspnet_core`;

Create table `Book`(
`Id` int(10) unsigned null default null,
`Title` varchar(250) not null,
`Author` varchar(250) not null,
`Price` decimal(10,2) not null,
`LaunchDate` datetime not null

);


alter table `Book` change `Id` `Id` int(10) auto_increment primary key;
