

--1. Creating tables 

CREATE TABLE cleaner (
  employee_id int NOT NULL IDENTITY(1, 1) PRIMARY KEY ,
  first_name nvarchar(50) NOT NULL,
  last_name nvarchar(50) NOT NULL,
  mobile_phone nvarchar(50) NOT NULL,
  dob date NOT NULL,
  education_level nvarchar(50),
  salary decimal(10, 2) NOT NULL
)

GO 
CREATE TABLE manager (
  employee_id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  first_name nvarchar(50) NOT NULL,
  last_name nvarchar(50) NOT NULL,
  mobile_phone nvarchar(50) NOT NULL,
  dob date NOT NULL,
  salary decimal(10, 2) NOT NULL,
  education_level nvarchar(50),
  ranking int 
  )
GO
CREATE TABLE branch(
  branch_no varchar(10) NOT NULL PRIMARY KEY,
  branch_name nvarchar(50) NOT NULL,
  address_city nvarchar(50) NOT NULL,
  address_zip nvarchar(50) NOT NULL,
  address_street nvarchar(50) NOT NULL,
  cleaner_id int constraint fk_cleaner_id references cleaner(employee_id),
  manager_id int constraint fk_branch_manager_no references manager(employee_id) NOT NULL
)
GO 

CREATE TABLE pharmacist (
  employee_id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  first_name nvarchar(50) NOT NULL,
  last_name nvarchar(50) NOT NULL,
  mobile_phone nvarchar(50) NOT NULL,
  dob date NOT NULL,
  salary decimal(10, 2) NOT NULL,
  education_level nvarchar(50),
  manager_id int constraint fk_manager_id references manager(employee_id) NOT NULL, 
  branch_no varchar(10) constraint fk_pharmacist_branch_no references branch(branch_no) NOT NULL
  )
GO
CREATE TABLE product(
  product_id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  product_name nvarchar(50) NOT NULL,
  release_form nvarchar(50) NOT NULL,
  production_date datetime NOT NULL,
  store_condition nvarchar(50) NOT NULL,
  manufacturer nvarchar(50) NOT NULL,
  expiration_date datetime NOT NULL,
  volume decimal(10, 2) NOT NULL,
  price decimal NOT NULL  
)
GO
CREATE TABLE operation(
  operation_id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  operation_type nvarchar(50) NOT NULL,
  operation_date datetime NOT NULL,
  pharmacist_id int constraint fk_pharmacist_operation_id references pharmacist(employee_id),
  quantity int NOT NULL,
  product_id int constraint fk_medicine_operation_id references product(product_id)
  
  )
GO