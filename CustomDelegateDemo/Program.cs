using System;

namespace CustomDelegateDemo
{
    // ============ CUSTOM DELEGATE WITHOUT DATA ============
    // Custom delegate declaration (no data)
    public delegate void SimpleEventHandler(object sender);

    // ============ CUSTOM DELEGATE WITH DATA ============
    // Custom EventArgs for data
    public class ProductEventArgs : EventArgs
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    // Custom delegate declaration (with data)
    public delegate void ProductEventHandler(object sender, ProductEventArgs e);

    // ============ EVENT PUBLISHER CLASS ============
    class Store
    {
        // Event using custom delegate WITHOUT data
        public event SimpleEventHandler StoreOpened;

        // Event using custom delegate WITH data
        public event ProductEventHandler ProductSold;

        public string StoreName { get; set; }

        public Store(string name)
        {
            StoreName = name;
        }

        // Raise event without data
        protected virtual void OnStoreOpened()
        {
            StoreOpened?.Invoke(this);
        }

        // Raise event with data
        protected virtual void OnProductSold(ProductEventArgs e)
        {
            ProductSold?.Invoke(this, e);
        }

        public void OpenStore()
        {
            Console.WriteLine($"\n{StoreName} is now opening...");
            OnStoreOpened();
        }

        public void SellProduct(string productName, decimal price, int quantity)
        {
            Console.WriteLine($"\nProcessing sale: {productName}");
            
            ProductEventArgs args = new ProductEventArgs
            {
                ProductName = productName,
                Price = price,
                Quantity = quantity
            };

            OnProductSold(args);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Custom Delegate Demo (With and Without Data) ===");

            // Create store
            Store store = new Store("Tech Store");

            // Subscribe to events
            store.StoreOpened += Store_Opened;           // Without data
            store.ProductSold += Store_ProductSold;      // With data

            // Trigger events
            store.OpenStore();
            store.SellProduct("Laptop", 999.99m, 2);
            store.SellProduct("Mouse", 29.99m, 5);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        // Event handler WITHOUT data (custom delegate)
        static void Store_Opened(object sender)
        {
            Store store = sender as Store;
            Console.WriteLine($"*** EVENT: {store.StoreName} has opened! Welcome customers! ***");
        }

        // Event handler WITH data (custom delegate)
        static void Store_ProductSold(object sender, ProductEventArgs e)
        {
            Store store = sender as Store;
            decimal total = e.Price * e.Quantity;
            Console.WriteLine($"*** EVENT: Sale completed at {store.StoreName} ***");
            Console.WriteLine($"    Product: {e.ProductName}");
            Console.WriteLine($"    Price: ${e.Price}");
            Console.WriteLine($"    Quantity: {e.Quantity}");
            Console.WriteLine($"    Total: ${total}");
        }
    }
}