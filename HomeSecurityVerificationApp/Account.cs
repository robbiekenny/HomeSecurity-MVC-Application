//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeSecurityVerificationApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public byte[] Salt { get; set; }
        public byte[] SaltedAndHashedPassword { get; set; }
        public bool Verified { get; set; }
        public byte[] Version { get; set; }
        public System.DateTimeOffset CreatedAt { get; set; }
        public Nullable<System.DateTimeOffset> UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
