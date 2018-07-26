namespace CoreFramework.Models
{
    public class MessageData
    {
        public string To { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }

        public override bool Equals(object obj)
        {
            var ob1 = (MessageData) obj;
            var t =  this.To == ob1.To && this.Topic == ob1.Topic && this.Message == ob1.Message;
            return t;
        }
    }
}
