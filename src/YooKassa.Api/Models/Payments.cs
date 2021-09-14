using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YooKassa.Api.Models
{
    public class Payments
    {
        public string Type { get; init; }

        public string NextCursor { get; init; }

        public List<Payment> Items { get; init; }
    }
}
