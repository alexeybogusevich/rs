using Newtonsoft.Json;

namespace KNU.RS.Logic.Models.Exception
{
    public class ExtendedErrorDetails
    {
        public string Message { get; set; }
        public string TargetSite { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
