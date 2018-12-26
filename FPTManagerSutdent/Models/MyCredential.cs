using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FPTManagerSutdent.Models
{
    public class MyCredential
    {
        public MyCredential(int OwnerId)
        {
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ExpireAt = DateTime.Now.AddDays(7);
            this.Status = MyCredentialStatus.Active;
        }

        [Key]
        public string AccessToken { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpireAt { get; set; }
        public MyCredentialStatus Status { get; set; }

        public bool isValid()
        {
            return (this.Status == MyCredentialStatus.Active && this.ExpireAt > DateTime.Now);
        }
    }

    public enum MyCredentialStatus
    {
        Active = 1,
        Deactive = 0
    }

}
