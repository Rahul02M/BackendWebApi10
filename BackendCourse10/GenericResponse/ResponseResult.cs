namespace BackendCourse10.GenericResponse
{
    public class ResponseResult<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; } = false;
        //create a method
        public  static ResponseResult<T> Sucsess(T? data, string Message)
        {
            return new ResponseResult<T>
            {
                Data = data,
                Message = Message,
                Status = true
            };
        }
        public static ResponseResult<T> Failure(T? data,string Message)
        {
            return new ResponseResult<T> 
            {
                Data= data,
                Message = Message,
                Status = false
            };

        }

    }
}
