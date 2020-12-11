namespace Application.ViewModels
{
    public class ApiGetOneBeerViewModel
    {
        public int HttpCode { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }
    }
}