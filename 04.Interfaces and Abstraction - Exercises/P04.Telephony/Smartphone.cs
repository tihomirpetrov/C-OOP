namespace Telephony
{
    using System;
    using System.Linq;
    using System.Text;
    public class Smartphone : ICall, IBrowse
    {
        public Smartphone(string[] phoneNumbers, string[] sites)
        {
            this.PhoneNumbers = phoneNumbers;
            this.Sites = sites;
        }

        public string[] PhoneNumbers { get; private set; }

        public string[] Sites { get; private set; }

        public string BrowseTheWeb()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Sites)
            {
                if (item.Any(char.IsDigit))
                {
                    sb.AppendLine($"Invalid URL!");
                }
                else
                {
                    sb.AppendLine($"Browsing: {item}!");
                }
            }
            return sb.ToString();
        }

        public string CallOtherNumbers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.PhoneNumbers)
            {
                if (item.Any(char.IsLetter))
                {
                    sb.AppendLine($"Invalid number!");
                }
                else
                {
                    sb.AppendLine($"Calling... {item}");
                }
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CallOtherNumbers().ToString().TrimEnd());
            sb.Append(BrowseTheWeb().ToString().TrimEnd());

            return sb.ToString();
        }
    }
}
