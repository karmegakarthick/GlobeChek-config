using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace globeChekModels
{
    [Table("organisations")]
    public class ClientModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string BusinessType { get; set; }
        public string BusinessName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Domain { get; set; }
        public short IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string OrgCode { get; set; }
        public short IsDeleted { get; set; }
        public short IsSuperOrg { get; set; }
    }
}
