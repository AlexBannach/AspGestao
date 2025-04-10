using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestao.Data;

namespace Gestao.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public required string LegalName { get; set; }
        public required string TradeName { get; set; }
        public required string CNPJ { get; set; }
        public required string PostalCode { get; set; }
        public required string State { get; set; }
        public required string City { get; set; }
        public required string Neighborhood { get; set; }
        public required string Address { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; } // Opcional
        public string? Phone { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public required ApplicationUser User { get; set; }
    }
}