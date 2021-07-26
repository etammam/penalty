﻿namespace Penalty.APIs.Setups.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string[] Issuers { get; set; }
        public string Audience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
    }
}
