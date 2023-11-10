SELECT 
    menuItem.Name, 
    menuItem.Type, 
    menuItem.Price
FROM 
    OrderItems orderItem
INNER JOIN 
    MenuItems menuItem ON orderItem.ItemID = menuItem.ItemID
WHERE 
    orderItem.ItemID = 2;
