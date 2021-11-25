using System.Data;
using System.Text;

namespace WindowsFormsApp1.Classes
{
    public static class MemberValidation
    {
        public static BadMemberRow IsValid(this DataRow senderRow)
        {
            var memberRow = new BadMemberRow {Id = senderRow.Field<int>("id")};

            var builder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(senderRow.Field<string>("FirstName")))
            {
                builder.AppendLine("First name required");
                
            }
            if (string.IsNullOrWhiteSpace(senderRow.Field<string>("LastName")))
            {
                builder.AppendLine("Last name required");
            }

            if (senderRow.IsNull("PIN"))
            {
                builder.AppendLine("Must have a PIN");
            }else if (senderRow.Field<string>("PIN").Length != 4)
            {
                builder.AppendLine("PIN must contain four digits");
            }

            memberRow.Description = builder.ToString();

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
