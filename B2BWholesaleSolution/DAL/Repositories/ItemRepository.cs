using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ItemRepository
    {
        private readonly B2BWholesaleDBEntities _context;

        public ItemRepository()
        {
            _context = new B2BWholesaleDBEntities();
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.ItemID == id);
        }

        public List<Item> SearchByName(string keyword)
        {
            return _context.Items
                .Where(i => i.ItemName.Contains(keyword))
                .ToList();
        }

        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Update(Item item)
        {
            var existing = _context.Items.FirstOrDefault(i => i.ItemID == item.ItemID);
            if (existing != null)
            {
                existing.ItemName = item.ItemName;
                existing.Size = item.Size;
                existing.Price = item.Price;
                existing.StockQuantity = item.StockQuantity;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemID == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
