namespace CRUD_Project.DAL
{
    public class Response
    {
        public string Message { get; set; } = "";
        public Response(string message)
        {
            Message = message;
        }
    }
}
