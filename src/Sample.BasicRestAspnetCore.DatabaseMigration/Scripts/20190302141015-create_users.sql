use `rest_aspnet_core`;

Create table `Users`(
`Id` int(10) unsigned null default null,
`Login` varchar(50) not null,
`AccessKey` varchar(50) not null
);


alter table `Users` change `Id` `Id` int(10) auto_increment primary key;
