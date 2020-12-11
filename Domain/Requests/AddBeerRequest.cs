namespace Domain.Requests
{
    public class AddBeerRequest
    {
        public string Label { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}