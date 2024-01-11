An API to be used to unify the e-commerce cart experience for users:

1. An endpoint to Add items to cart, with specified quantity
  - Adding similar items (same item ID) should increase the quantity - POST
2. An endpoint to remove an item from cart - DELETE verb
3. An endpoint list all cart items (with filters => phoneNumbers, time, quantity, item - GET
4. An endpoint to get single item - GET

Cart model:
Item ID
Item name
Quantity
Unit price
