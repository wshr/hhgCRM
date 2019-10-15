namespace WebServer.Entities
{

    public class ApiResult
    {

        public bool Success { get; set; } = true;

        /// <summary>
        /// 结果
        /// </summary>
        public object Result { get; set; }
    }

}