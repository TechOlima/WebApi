namespace WebApi.Classes.Operations
{
    public class InsertPut : InsertPost
    {        
        public int? InsertID { get; set; }

        public InsertPut(Insert insert)
        {
            Weight = insert.Weight;
            ProductID = insert?.Product?.ProductID;
            InsertID = insert?.InsertID;
            StoneType = insert?.StoneType.Name;
        }
    }
}
