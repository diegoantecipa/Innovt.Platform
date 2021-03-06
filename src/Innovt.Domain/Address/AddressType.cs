﻿using System.Collections.Generic;
using System.Linq;
using Innovt.Domain.Core.Model;

namespace Innovt.Domain.Address
{
    public sealed class AddressType : ValueObject
    {
        private static readonly List<AddressType> Types = new List<AddressType>();

        public static readonly AddressType Comercial = new AddressType(1, "Comercial");
        public static readonly AddressType Residential = new AddressType(2, "Residencial");
        public static readonly AddressType Pagamento = new AddressType(3, "Pagamento");

        public string Name { get; set; }

        public AddressType(int id, string name)
        {
            Id = id;
            Name = name;
            Types.Add(this);
        }

        public static List<AddressType> FindAll()
        {
            return Types.OrderBy(c => c.Name).ToList();
        }
        public static AddressType GetByPk(int id)
        {
            return Types.SingleOrDefault(s => s.Id == id);
        }
    }
}