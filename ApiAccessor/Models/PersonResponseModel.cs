using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAccessor.Models
{
    public class PersonResponseModel : PersonModel
    {
        public int TotalPeople { get; set; }
        public string CoutryId { get; set; } = null;
        public string Error { get; set; } = null;
    }
}
