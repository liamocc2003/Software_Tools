
-- Drop foreign key constraints in OrderItems table, if they exist
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'fk_OrderItems_OrderID')
    ALTER TABLE OrderItems DROP CONSTRAINT fk_OrderItems_OrderID;
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'fk_OrderItems_ItemID')
    ALTER TABLE OrderItems DROP CONSTRAINT fk_OrderItems_ItemID;

-- Drop tables if they exist
IF OBJECT_ID('dbo.MenuItems', 'U') IS NOT NULL
    DROP TABLE dbo.MenuItems;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL
    DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.OrderItems', 'U') IS NOT NULL
    DROP TABLE dbo.OrderItems;

--MenuItems table
CREATE TABLE MenuItems(
     ItemID numeric(4) PRIMARY KEY,
     Availability char(1) NOT NULL,
     Type char(1) NOT NULL,
     Name varchar(20) NOT NULL,
     Description varchar(45) NOT NULL,
     Price numeric(5,2) NOT NULL
 );

 --Orders table
CREATE TABLE Orders (
    OrderID numeric(4) PRIMARY KEY,
    OrderDate datetime NOT NULL,
    OrderPrice numeric(5,2) NOT NULL,
    OrderStatus char(1) NOT NULL
    );

--OrderItems table
CREATE TABLE OrderItems (
    OrderID numeric(4) NOT NULL,
    ItemID numeric(4) NOT NULL,
    Quantity numeric(4) NOT NULL,

    PRIMARY KEY (OrderID, ItemID),
    CONSTRAINT fk_OrderItems_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT fk_OrderItems_ItemID FOREIGN KEY (ItemID) REFERENCES MenuItems(ItemID)
);

--Insert data into OrderItems
--Test Data

INSERT INTO MenuItems
VALUES
(1, 'A', 'F', 'Spaghetti', 'Tomato pasta dish', 14.00),
(2, 'A', 'F', 'Sushi', 'Assorted raw fish and veggie rolls', 12.50),
(3, 'U', 'B', 'Guiness', 'Dark Irish beer', 4.90),
(4, 'A', 'D', 'CheeseCake', 'Cream cheese dessert', 7.50),
(5, 'A', 'F', 'Chips', 'Fried potatoes', 6.00),
(6, 'U', 'D', 'Apple Pie', 'Apple filled dessert', 5.40),
(7, 'U', 'B', 'Bloody Mary', 'Spicy vodka tomato cocktail', 9.75),
(8, 'A', 'F', 'Vindaloo', 'Spicy Indian curry dish', 12.00),
(9, 'U', 'B', 'Mojito', 'Refreshing rum lime mint cocktail', 4.90),
(10, 'A', 'F', 'Biryani', 'Fragrant rice dish', 9.99),
(11, 'A', 'F', 'Quesadilla', 'Melted cheese between tortillas', 6.50),
(12, 'U', 'F', 'Chow Mein', 'Stir fried noodles, vegetables and meat', 10.75),
(13, 'A', 'F', 'Margherita Pizza', 'Tomato sauce and mozzarella', 10.00),
(14, 'U', 'B', 'Margarita', 'Tequila cocktail with lime', 5.00),
(15, 'A', 'F', 'Chicken Alfredo', 'Creamy pasta with chicken and Parmesan', 12.00),
(16, 'A', 'D', 'Tiramisu', 'Layered coffee dessert', 8.50),
(17, 'U', 'B', 'Cosmopolitan', 'Vodka cranberry lime cocktail', 7.00),
(18, 'A', 'F', 'Beef Stir Fry', 'Quick and flavorful Chinese dish', 11.50),
(19, 'A', 'F', 'Pad Thai', 'Thai noodle dish with tangy sweet sauce', 10.00),
(20, 'U', 'F', 'Pepperoni Pizza', 'Tomato sauce, mozzarella, and pepperoni', 10.00),
(21, 'A', 'D', 'Lemon Tart', 'Tangy dessert with whipped cream', 6.50),
(22, 'A', 'F', 'Sausage and Mash', 'Local sausages and mashed potatoes', 9.00),
(23, 'U', 'B', 'Bloody Caesar', 'Spicy cocktail with Clamato and vodka', 8.75),
(24, 'A', 'F', 'Fish and Chips', 'Classic fried fish and potatoes', 12.50),
(25, 'A', 'F', 'Peking Duck', 'Roasted duck with pancakes and sauce', 20.00),
(26, 'U', 'B', 'Whiskey Sour', 'Whiskey cocktail with lemon and sugar', 9.00),
(27, 'A', 'F', 'Lobster Bisque', 'Creamy soup made with lobster and spices', 16.00),
(28, 'A', 'D', 'Chocolate Cake', 'Rich and decadent chocolate dessert', 8.00),
(29, 'U', 'B', 'Tequila Sunrise', 'Tequila cocktail with orange and grenadine', 6.50),
(30, 'A', 'F', 'Pho', 'Vietnamese noodle soup with herbs and beef', 10.50);


--Test Data

-- Insert statements for Orders table
INSERT INTO Orders (OrderID, OrderDate, OrderPrice, OrderStatus) VALUES (1, '2023-01-01', 25.00, 'A');
INSERT INTO Orders (OrderID, OrderDate, OrderPrice, OrderStatus) VALUES (2, '2023-05-01', 24.00, 'U');
INSERT INTO Orders (OrderID, OrderDate, OrderPrice, OrderStatus) VALUES (3, '2023-02-01', 23.00, 'A');

-- Insert statements for OrderItems table
INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (1, 1, 2);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (2, 12, 1);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (2, 6, 3);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (2, 3, 3);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (2, 21, 3);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (3, 6, 8);

INSERT INTO OrderItems (OrderID, ItemID, Quantity) VALUES (3, 7, 2);

