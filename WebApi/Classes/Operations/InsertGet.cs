namespace WebApi.Classes.Operations
{
    public class InsertGet : InsertPut
    {
        public InsertGet(Insert insert) : base(insert)
        {
            Weight = insert.Weight;
            ProductID = insert?.Product?.ProductID;
            InsertID = insert?.InsertID;
            StoneType = insert?.StoneType?.Name;
            ProductName = insert?.Product?.Name;
        }

        public string? ProductName { get; set; }
    }
}
