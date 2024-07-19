namespace AzureApi.Repositories
{
    [Serializable]
    internal class ProductNotFoundException : Exception
    {
        public readonly string message;
        public ProductNotFoundException(int key)
        {
            message = $"Product with {key} not found";
        }

        public ProductNotFoundException()
        {
            message = "Product not found";
        }
        public override string Message => message;
    }
}