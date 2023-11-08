-- Drop foreign key constraints in OrderItems table, if they exist
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'fk_OrderItems_OrderID')
    ALTER TABLE OrderItems DROP CONSTRAINT fk_OrderItems_OrderID;
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'fk_OrderItems_ItemID')
    ALTER TABLE OrderItems DROP CONSTRAINT fk_OrderItems_ItemID;


-- Drop tables if they exist
IF OBJECT_ID('dbo.MenuItems') IS NOT NULL
    DROP TABLE dbo.MenuItems;
IF OBJECT_ID('dbo.Orders') IS NOT NULL
    DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.OrderItems') IS NOT NULL
    DROP TABLE dbo.OrderItems;

--Orders table
CREATE TABLE Orders (
	OrderID numeric(4) DEFAULT 0 NOT NULL PRIMARY KEY,
	OrderTableNo float(4) NOT NULL,
	OrderDate datetime NOT NULL,
	OrderPrice numeric(6,2) NOT NULL,
	OrderStatus char(1) NOT NULL
);

--MenuItems table
CREATE TABLE MenuItems (
     ItemID numeric(4) DEFAULT 0 NOT NULL PRIMARY KEY,
     ItemType char(1) NOT NULL,
     ItemName varchar(20) NOT NULL,
     ItemDescription varchar(45) NOT NULL,
     ItemPrice numeric(5,2) NOT NULL
 );

--OrderItems table
CREATE TABLE OrderItems (
    OrderID numeric(4) NOT NULL,
    ItemID numeric(4) NOT NULL,
    OrderQuantity numeric(4) DEFAULT 1 NOT NULL,

    CONSTRAINT fk_OrderItems_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    CONSTRAINT fk_OrderItems_ItemID FOREIGN KEY (ItemID) REFERENCES MenuItems(ItemID)
);

--Test Data
--Insert test data into Orders
INSERT INTO Orders (OrderID, OrderTableNo, OrderDate, OrderPrice, OrderStatus) VALUES (1, 4, '2023-01-01', 25.00, 'A');
INSERT INTO Orders (OrderID, OrderTableNo, OrderDate, OrderPrice, OrderStatus) VALUES (2, 6, '2023-05-01', 24.00, 'U');
INSERT INTO Orders (OrderID, OrderTableNo, OrderDate, OrderPrice, OrderStatus) VALUES (3, 12, '2023-02-01', 23.00, 'A');

--Insert test data into MenuItems
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (1, 'F', 'Spaghetti', 'Tomato pasta dish', 14.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (2, 'F', 'Sushi', 'Assorted raw fish and veggie rolls', 12.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (3, 'B', 'Guiness', 'Dark Irish beer', 4.90);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (4, 'D', 'CheeseCake', 'Cream cheese dessert', 7.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (5, 'F', 'Chips', 'Fried potatoes', 6.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (6, 'D', 'Apple Pie', 'Apple filled dessert', 5.40);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (7, 'B', 'Bloody Mary', 'Spicy vodka tomato cocktail', 9.75);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (8, 'F', 'Vindaloo', 'Spicy Indian curry dish', 12.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (9, 'B', 'Mojito', 'Refreshing rum lime mint cocktail', 4.90);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (10, 'F', 'Biryani', 'Fragrant rice dish', 9.99);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (11, 'F', 'Quesadilla', 'Melted cheese between tortillas', 6.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (12, 'F', 'Chow Mein', 'Stir fried noodles, vegetables and meat', 10.75);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (13, 'F', 'Margherita Pizza', 'Tomato sauce and mozzarella', 10.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (14, 'B', 'Margarita', 'Tequila cocktail with lime', 5.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (15, 'F', 'Chicken Alfredo', 'Creamy pasta with chicken and Parmesan', 12.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (16, 'D', 'Tiramisu', 'Layered coffee dessert', 8.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (17, 'B', 'Cosmopolitan', 'Vodka cranberry lime cocktail', 7.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (18, 'F', 'Beef Stir Fry', 'Quick and flavorful Chinese dish', 11.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (19, 'F', 'Pad Thai', 'Thai noodle dish with tangy sweet sauce', 10.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (20, 'F', 'Pepperoni Pizza', 'Tomato sauce, mozzarella, and pepperoni', 10.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (21, 'D', 'Lemon Tart', 'Tangy dessert with whipped cream', 6.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (22, 'F', 'Sausage and Mash', 'Local sausages and mashed potatoes', 9.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (23, 'B', 'Bloody Caesar', 'Spicy cocktail with Clamato and vodka', 8.75);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (24, 'F', 'Fish and Chips', 'Classic fried fish and potatoes', 12.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (25, 'F', 'Peking Duck', 'Roasted duck with pancakes and sauce', 20.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (26, 'B', 'Whiskey Sour', 'Whiskey cocktail with lemon and sugar', 9.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (27, 'F', 'Lobster Bisque', 'Creamy soup made with lobster and spices', 16.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (28, 'D', 'Chocolate Cake', 'Rich and decadent chocolate dessert', 8.00);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (29, 'B', 'Tequila Sunrise', 'Tequila cocktail with orange and grenadine', 6.50);
INSERT INTO MenuItems (ItemID, ItemType, ItemName, ItemDescription, ItemPrice) VALUES (30, 'F', 'Pho', 'Vietnamese noodle soup with herbs and beef', 10.50);

--Insert test data into OrderItems
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (1, 1, 2);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (2, 12, 1);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (2, 6, 3);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (2, 3, 3);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (2, 21, 3);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (3, 6, 8);
INSERT INTO OrderItems (OrderID, ItemID, OrderQuantity) VALUES (3, 7, 2);