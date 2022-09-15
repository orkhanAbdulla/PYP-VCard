using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_VCard.Models
{
    internal class VCard
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; }=null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("BEGIN:VCARD");
            builder.Append("FN:").Append(Firstname)
            .Append(";").AppendLine(Firstname);
            builder.Append("SORT-STRING:").AppendLine(Surname);
            builder.Append("ADR:").Append(City).Append(";")
              .AppendLine(Country);
            builder.Append("TEL:").AppendLine(Phone);
            builder.Append("EMAIL;PREF;INTERNET:").AppendLine(Email);
            builder.AppendLine("END:VCARD");
            return builder.ToString();
        }

    }
}
