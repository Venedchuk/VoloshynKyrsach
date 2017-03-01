using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace VoloshynKursach
{

    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int TotalSize { get; set; }
        public int Workers { get; set; }
        public int CountTechnick { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }

    public class Factory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Region Region { get; set; }
    }
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string  NameProduct { get; set; }
        public int Productivity { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public double SizeOrder { get; set; }
        public DateTime StartOrder { get; set; }
        public virtual Department Department { get; set; }
        public virtual Shop Shop { get; set; }
    }
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locations { get; set; }
    }




}
