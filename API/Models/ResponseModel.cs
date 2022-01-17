namespace API.Models
{
    public class ResponseModel
    {
        public int Status { get; set; }
        public string Error { get; set; }
        public object Data { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(int status, string error)
        {
            Status = status;
            Error = error.Replace("'", "").Replace("\"", "");
        }

        public ResponseModel(int status, object data)
        {
            Status = status;
            Data = data;
        }

        
    }
}
