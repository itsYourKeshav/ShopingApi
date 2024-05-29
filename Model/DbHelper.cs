using ShopingApi.EFCore;

namespace ShopingApi.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context) { 
            _context = context; 
        }
        public List<ProductModel> GetProducts() {
            List<ProductModel> response = new List<ProductModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new ProductModel() { 
                brand=row.brand, 
                name=row.name, 
                price=row.price,
                size=row.size,
                id=row.id
            }));
            return response;
        }

        public ProductModel GetProductById(int id)
        {
            ProductModel response = new ProductModel();
            var row = _context.Products.Where(d=>d.id.Equals(id)).FirstOrDefault();
            return new ProductModel()
            {
                brand = row.brand,
                name = row.name,
                price = row.price,
                size = row.size,
                id = row.id
            };         
        }

        public void SaveOrder(OrderModel orderModel) {
            Order dbTable = new Order();
            if(orderModel.id > 0)
            {   //PUT
                    dbTable = _context.Orders.Where(d => d.Equals(orderModel.id)).FirstOrDefault();
                    if (dbTable != null)
                    {
                        dbTable.phone = orderModel.phone;
                        dbTable.address = orderModel.address;
                    }
                //POST
                else {
                    dbTable.phone  =orderModel.phone;
                    dbTable.address = orderModel.address;   
                    dbTable.name = orderModel.name;
                    dbTable.Product = _context.Products.Where(f => f.id.Equals(orderModel.product_id)).FirstOrDefault();
                    _context.Orders.Add(dbTable);   
                }
                    _context.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {   //DELETE
            var order = _context.Orders.Where(d=>d.id.Equals(id)).FirstOrDefault(); 
            if(order != null )
            {
                _context.Orders.Remove(order);  
                _context.SaveChanges(); 
            }
        }

    }
}
