using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class MemberValidation
    {
        public static BadMemberRow IsValid(this DataRow senderRow)
        {
            var memberRow = new BadMemberRow {Id = senderRow.Field<int>("id")};

            var sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(senderRow.Field<string>("FirstName")))
            {
                sb.AppendLine("First name required");
                
            }
            if (string.IsNullOrWhiteSpace(senderRow.Field<string>("LastName")))
            {
                sb.AppendLine("Last name required");
            }

            if (senderRow.IsNull("PIN"))
            {
                sb.AppendLine("Must have a PIN");
            }else if (senderRow.Field<string>("PIN").Length != 4)
            {
                sb.AppendLine("PIN must contain four digits");
            }

            memberRow.Description = sb.ToString();

            return memberRow;
        }
        public class BadMemberRow 
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public bool InValid => !string.IsNullOrWhiteSpace(Description);
            public override string ToString()
            {
                return $"{Id}: {Description}";
            }
        }
    }
}
