using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateModel
    {
        [JsonIgnore]
        public DateTimeOffset Created
        {
            get
            {
                return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
            }
        }

        [JsonIgnore]
        public bool Deleted
        {
            get
            {
                return false;
            }
        }

        [JsonIgnore]
        public bool Active
        {
            get
            {
                return true;
            }
        }
    }
}
