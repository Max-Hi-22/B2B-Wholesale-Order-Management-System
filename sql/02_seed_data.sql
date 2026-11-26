USE B2BWholesaleDB;
GO

-- =============================================
-- 1. SEED DATA FOR TABLE: Item (20 rows)
-- =============================================
INSERT INTO Item (ItemName, Size, Price, StockQuantity) VALUES
(N'Lavie Natural Mineral Water', '500ml', 4500.00, 500),
(N'Lavie Natural Mineral Water', '1.5L', 9000.00, 300),
(N'Highlands Coffee Milk', '235ml', 12000.00, 8),       -- Low stock for alert testing
(N'Highlands Black Coffee', '235ml', 11000.00, 150),
(N'Coca-Cola Original', '330ml', 8500.00, 600),
(N'Pepsi Cola Can', '330ml', 8200.00, 550),
(N'Red Bull Energy Drink', '250ml', 10500.00, 400),
(N'Cosy Marie Biscuits', '300g Box', 42000.00, 120),
(N'Oreo Chocolate Sandwich Cookies', '133g Pack', 16500.00, 200),
(N'Choco-Pie Orion', '12 Packs Box', 54000.00, 180),
(N'Hao Hao Sour & Spicy Shrimp Noodles', '30 Packs Box', 115000.00, 250),
(N'Omachi Stewed Beef Noodles', '30 Packs Box', 210000.00, 140),
(N'TH True Milk Fresh Milk', '1L Carton', 32000.00, 90),
(N'Vinamilk Condensed Milk (Ong Tho)', '380g Can', 23500.00, 320),
(N'Neptune Light Cooking Oil', '2L Bottle', 118000.00, 75),
(N'Simply Soybean Cooking Oil', '5L Bottle', 265000.00, 45),
(N'Nam Ngu Fish Sauce', '750ml Bottle', 38000.00, 210),
(N'Chinsu Chili Sauce', '250g Bottle', 14000.00, 350),
(N'ST25 Premium Fragrant Rice', '5kg Bag', 165000.00, 60),
(N'OMO Matic Laundry Detergent', '3.6kg Bag', 175000.00, 5); -- Low stock for alert testing
GO

-- =============================================
-- 2. SEED DATA FOR TABLE: Agent (15 rows)
-- =============================================
INSERT INTO Agent (AgentName, Address, Phone) VALUES
(N'Minh Anh Wholesale Trading Co.', N'124 Nguyen Thi Thap, District 7, HCMC', '0901234501'),
(N'Hoang Phat Distribution Ltd.', N'45 Le Loi, District 1, HCMC', '0901234502'),
(N'Thanh Dat Consumer Goods', N'88 Vo Van Ngan, Thu Duc City, HCMC', '0901234503'),
(N'Phuong Nam Mart Supply', N'310 Cach Mang Thang 8, District 3, HCMC', '0901234504'),
(N'An Khang Retail Partner', N'19 Phan Xich Long, Phu Nhuan District, HCMC', '0901234505'),
(N'Dai Loc General Store', N'502 Kinh Duong Vuong, Binh Tan District, HCMC', '0901234506'),
(N'Kim Long Beverage Distributor', N'77 Quang Trung, Go Vap District, HCMC', '0901234507'),
(N'Truong Thinh Grocery Supply', N'215 Cong Hoa, Tan Binh District, HCMC', '0901234508'),
(N'Hoa Binh Minimart Chain', N'63 Nguyen Huu Tho, Nha Be District, HCMC', '0901234509'),
(N'Tan Tien Wholesale Hub', N'142 Hau Giang, District 6, HCMC', '0901234510'),
(N'Viet Hung FMCG Agency', N'95 Pham Van Dong, Binh Thanh District, HCMC', '0901234511'),
(N'Saigon Star Distribution', N'18 Ton Duc Thang, District 1, HCMC', '0901234512'),
(N'Binh Minh Food & Drink Co.', N'410 Le Van Viet, Thu Duc City, HCMC', '0901234513'),
(N'Dong A Commercial Enterprise', N'290 Ba Thang Hai, District 10, HCMC', '0901234514'),
(N'Nam Viet Wholesale Logistics', N'105 Truong Chinh, District 12, HCMC', '0901234515');
GO

-- =============================================
-- 3. SEED DATA FOR TABLE: Users (16 rows)
-- =============================================
INSERT INTO Users (UserName, email, password, lock, Role) VALUES
('admin_master', 'admin@b2bwholesale.com', 'Admin@123456', 0, 'Admin'),
('admin_ops', 'operations@b2bwholesale.com', 'Ops@123456', 0, 'Admin'),
('agent_minhanh', 'minhanh.agent@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_hoangphat', 'hoangphat.dist@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_thanhdat', 'thanhdat.goods@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_phuongnam', 'phuongnam.mart@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_ankhang', 'ankhang.retail@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_dailoc', 'dailoc.store@gmail.com', 'Agent@123456', 1, 'Agent'), -- Locked account for testing
('agent_kimlong', 'kimlong.bev@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_truongthinh', 'truongthinh.sup@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_hoabinh', 'hoabinh.mini@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_tantien', 'tantien.hub@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_viethung', 'viethung.fmcg@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_saigonstar', 'saigonstar.dist@gmail.com', 'Agent@123456', 0, 'Agent'),
('agent_binhminh', 'binhminh.fd@gmail.com', 'Agent@123456', 1, 'Agent'),   -- Locked account for testing
('agent_donga', 'donga.comm@gmail.com', 'Agent@123456', 0, 'Agent');
GO

-- =============================================
-- 4. SEED DATA FOR TABLE: [Order] (18 rows)
-- =============================================
INSERT INTO [Order] (OrderDate, AgentID, OrderStatus) VALUES
('2026-10-01 08:30:00', 1, 'Delivered'),
('2026-10-03 09:15:00', 2, 'Delivered'),
('2026-10-05 14:20:00', 3, 'Delivered'),
('2026-10-08 10:45:00', 4, 'Delivered'),
('2026-10-12 16:00:00', 5, 'Cancelled'),
('2026-10-15 11:10:00', 1, 'Delivered'),
('2026-10-18 13:50:00', 6, 'Delivered'),
('2026-10-22 09:05:00', 7, 'Delivered'),
('2026-10-25 15:30:00', 8, 'Delivered'),
('2026-10-28 10:00:00', 9, 'Delivered'),
('2026-11-02 08:45:00', 10, 'Shipped'),
('2026-11-05 14:15:00', 11, 'Shipped'),
('2026-11-09 11:30:00', 12, 'Shipped'),
('2026-11-12 16:40:00', 13, 'Shipped'),
('2026-11-15 09:20:00', 14, 'Pending'),
('2026-11-17 10:50:00', 15, 'Pending'),
('2026-11-18 14:10:00', 2, 'Pending'),
('2026-11-19 08:00:00', 3, 'Pending');
GO

-- =============================================
-- 5. SEED DATA FOR TABLE: OrderDetail (25 rows)
-- Note: UnitAmount = Quantity * Item.Price
-- =============================================
INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount) VALUES
(1, 1, 50, 225000.00),
(1, 5, 30, 255000.00),
(2, 11, 20, 2300000.00),
(2, 15, 10, 1180000.00),
(3, 8, 25, 1050000.00),
(3, 10, 15, 810000.00),
(4, 19, 20, 3300000.00),
(5, 7, 40, 420000.00),
(6, 2, 40, 360000.00),
(6, 17, 30, 1140000.00),
(7, 12, 15, 3150000.00),
(8, 6, 50, 410000.00),
(8, 9, 30, 495000.00),
(9, 14, 40, 940000.00),
(10, 16, 10, 2650000.00),
(11, 4, 24, 264000.00),
(11, 13, 20, 640000.00),
(12, 18, 50, 700000.00),
(13, 1, 100, 450000.00),
(14, 11, 10, 1150000.00),
(15, 3, 5, 60000.00),
(16, 20, 3, 525000.00),
(17, 5, 60, 510000.00),
(17, 8, 10, 420000.00),
(18, 19, 15, 2475000.00);
GO

SELECT 'Item' AS TableName, COUNT(*) AS Row FROM Item
UNION ALL
SELECT 'Agent', COUNT(*) FROM Agent
UNION ALL
SELECT 'Users', COUNT(*) FROM Users
UNION ALL
SELECT '[Order]', COUNT(*) FROM [Order]
UNION ALL
SELECT 'OrderDetail', COUNT(*) FROM OrderDetail;