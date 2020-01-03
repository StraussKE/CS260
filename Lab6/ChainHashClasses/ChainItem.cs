
namespace ChainHashClasses
{
    public class ChainItem
    {
        private string value;
        private ChainItem next;

        public ChainItem() { }
        public ChainItem(string value, ChainItem next = null) { this.value = value; this.next = next;}
        public string GetKey() { return value; }
        public ChainItem GetNext() { return next; }
        public void SetNext(ChainItem next) { this.next = next; }
    }
}
