﻿using System;

namespace CarRental
{
    public class ListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
