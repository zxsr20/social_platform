using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DAL
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string PersonName { get; set; }
    }
}
