namespace Tappit.Application.Models.Wrappers
{
    /// <summary>
    /// This help achieve uniform response object shape going out of the api.
    /// </summary>
    /// <typeparam name="T">Generic type to be wrapped by the response.</typeparam>
    public class ResponseWrapper<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


        /// <summary>
        /// Used for successful operation
        /// </summary>
        /// <param name="data">Response info to be wrapped.</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseWrapper<T> Success(string message = null)
        {
            IsSuccessful = true;
            Message = message;

            return this;
        }

        public ResponseWrapper<T> SuccessWithData(T data, string message = null)
        {
            IsSuccessful = true;
            Message = message;
            Data = data;

            return this;
        }

        /// <summary>
        /// Used for failed operation
        /// </summary>
        /// <param name="message">Failed reason</param>
        /// <returns></returns>
        public ResponseWrapper<T> Failed(string message)
        {
            IsSuccessful = false;
            Message = message;

            return this;
        }
    }
}
