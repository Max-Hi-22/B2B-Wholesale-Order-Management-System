using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using System.Data.Entity.Infrastructure;

namespace BLL.Services
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepo;

        public ItemService()
        {
            _itemRepo = new ItemRepository();
        }

        public List<Item> GetAllItems()
        {
            return _itemRepo.GetAll();
        }

        public List<Item> SearchItemsByName(String keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return _itemRepo.GetAll();
            }

            return _itemRepo.SearchByName(keyword.Trim());
        }

        public void AddItem(Item item)
        {
            ValidateItem(item);
            _itemRepo.Add(item);
        }

        public void ValidateItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            
            if (string.IsNullOrWhiteSpace(item.ItemName))
                throw new ArgumentException("Product name cannot be empty.");

            if (item.Price < 0)
                throw new ArgumentException("Product price must be greater than or equal to zero..");

            if (item.StockQuantity < 0)
                throw new ArgumentException("Product stock quantity must be greater than or equal to zero.");
        }

        public void UpdateItem(Item item)
        {
            ValidateItem(item);
            _itemRepo.Update(item);
        }

        public void DeleteItem(int id)
        {
            _itemRepo.Delete(id);
        }
    }
}
