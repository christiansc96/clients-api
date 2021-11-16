namespace TechApi.Repository.Queries
{
    public static class QueriesSQL
    {
        public const string GetClientsByLimit = @"
            SELECT * 
            FROM Clients
            ORDER BY Id ASC 
            OFFSET {0} ROWS 
            FETCH NEXT {1} ROWS ONLY";
    }
}