﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.IO;
using System.Diagnostics;

namespace VoloshynKursach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Initiation();
        }

        public void Initiation()
        {
            Region reg = new Region();
            using (var db = new Context())
            {
                reg = db.Regions.SingleOrDefault(x => x.name == "Житомир");
            }

            if (reg == null)
            {
                using (var db = new Context())
                {
                    db.Regions.Add(new Region() { name = "Житомир" });
                    db.Regions.Add(new Region() { name = "Київ" });
                    db.Regions.Add(new Region() { name = "Одеса" });
                    db.SaveChanges();
                }
                using (var db = new Context())
                {
                    db.Factories.Add(new Factory() { Name = "Рошен", Description = "porohoshokolade", Region = db.Regions.Single(x => x.Id == 1), });
                    db.Factories.Add(new Factory() { Name = "ЖЛ", Description = "bla bla shokolade", Region = db.Regions.Single(x => x.Id == 1), });
                    db.SaveChanges();
                }
                using (var db = new Context())
                {
                    db.Departments.Add(new Department() { Productivity = 10, NameProduct = "Білий шоколад", Factory = db.Factories.Single(x => x.Id == 2) });
                    db.Departments.Add(new Department() { Productivity = 10, NameProduct = "Білий шоколад", Factory = db.Factories.Single(x => x.Id == 1) });
                    db.Departments.Add(new Department() { Productivity = 5, NameProduct = "Згущик", Factory = db.Factories.Single(x => x.Id == 1) });
                    db.Departments.Add(new Department() { Productivity = 10, NameProduct = "Чорний шоколад", Factory = db.Factories.Single(x => x.Id == 1) });
                    db.Departments.Add(new Department() { Productivity = 10, NameProduct = "Чорний шоколад", Factory = db.Factories.Single(x => x.Id == 2) });
                    db.SaveChanges();
                }

                using (var db = new Context())
                {
                    db.Warehouses.Add(new Warehouse() { Number = 1, TotalSize = 750, Workers = 25, CountTechnick = 5, Region = db.Regions.Single(x => x.Id == 1) });
                    db.Warehouses.Add(new Warehouse() { Number = 2, TotalSize = 550, Workers = 25, CountTechnick = 3, Region = db.Regions.Single(x => x.Id == 2) });
                    db.Warehouses.Add(new Warehouse() { Number = 1, TotalSize = 1000, Workers = 35, CountTechnick = 10, Region = db.Regions.Single(x => x.Id == 1) });
                    db.Warehouses.Add(new Warehouse() { Number = 1, TotalSize = 1000, Workers = 35, CountTechnick = 10, Region = db.Regions.Single(x => x.Id == 3) });
                    db.SaveChanges();
                }

                using (var db = new Context())
                {

                    db.Shops.Add(new Shop() { Name = "RoshShop", Locations = "Житомир" });
                    db.Shops.Add(new Shop() { Name = "Обжора", Locations = "Житомир" });
                    db.Shops.Add(new Shop() { Name = "Малютка", Locations = "Житомир" });
                    db.Shops.Add(new Shop() { Name = "Ласощі", Locations = "Київ" });
                    db.Shops.Add(new Shop() { Name = "Канхвєти", Locations = "Київ" });
                    db.SaveChanges();
                }

                using (var db = new Context())
                {

                    db.Orders.Add(new Order() { NameProduct = "Білий шоколад", SizeOrder = 10, StartOrder = DateTime.Now, Shop = db.Shops.Single(x => x.Id == 1), Department = db.Departments.Single(x => x.Id == 1) });
                    db.Orders.Add(new Order() { NameProduct = "Згущик", SizeOrder = 20, StartOrder = DateTime.Now, Shop = db.Shops.Single(x => x.Id == 2), Department = db.Departments.Single(x => x.Id == 1) });
                    db.Orders.Add(new Order() { NameProduct = "Білий шоколад", SizeOrder = 35, StartOrder = DateTime.Now, Shop = db.Shops.Single(x => x.Id == 2), Department = db.Departments.Single(x => x.Id == 2) });
                    db.Orders.Add(new Order() { NameProduct = "Згущик", SizeOrder = 20, StartOrder = DateTime.Now, Shop = db.Shops.Single(x => x.Id == 2), Department = db.Departments.Single(x => x.Id == 1) });
                    db.SaveChanges();
                }
                
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Factories' table. You can move, or remove it, as needed.
            this.factoriesTableAdapter.Fill(this.factoryOrdersDataSet1.Factories);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Warehouses' table. You can move, or remove it, as needed.
            this.warehousesTableAdapter.Fill(this.factoryOrdersDataSet1.Warehouses);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.factoryOrdersDataSet1.Orders);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Shops' table. You can move, or remove it, as needed.
            this.shopsTableAdapter.Fill(this.factoryOrdersDataSet1.Shops);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.factoryOrdersDataSet1.Departments);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Regions' table. You can move, or remove it, as needed.
            this.regionsTableAdapter.Fill(this.factoryOrdersDataSet1.Regions);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Departments' table. You can move, or remove it, as needed.
            this.departmentsTableAdapter.Fill(this.factoryOrdersDataSet1.Departments);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet1.Warehouses' table. You can move, or remove it, as needed.
                     this.regionsTableAdapter.Fill(this.factoryOrdersDataSet1.Regions);
            // TODO: This line of code loads data into the 'factoryOrdersDataSet.Orders' table. You can move, or remove it, as needed.
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Regions.Single(x => x.Id == a);
                db.Regions.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(),new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                db.Regions.Add(new Region() { name = regtxt.Text });
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Regions.Single(x => x.Id == a);
                db.Regions.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button6_Click(object sender, EventArgs e)
        {

            using (var db = new Context())
            {
                db.Shops.Add(new Shop() { Name = textBox5.Text , Locations = textBox7.Text});
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView6.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Factories.Single(x => x.Id == a);
                db.Factories.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                int regId;
                int.TryParse(textBox10.Text, out regId);
                db.Factories.Add(new Factory() { Name = textBox8.Text, Description = textBox9.Text, Region = db.Regions.Single(x => x.Id == regId)});
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Departments.Single(x => x.Id == a);
                db.Departments.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                int regId;int needInt;
                int.TryParse(textBox1.Text, out regId);
                int.TryParse(textBox3.Text, out needInt);
                db.Departments.Add(new Department() { NameProduct = textBox2.Text, Productivity = needInt, Factory = db.Factories.Single(x => x.Id == regId) });
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView5.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Warehouses.Single(x => x.Id == a);
                db.Warehouses.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                int regId, needInt, moreInt, countTechnik, regid;
                int.TryParse(textBox6.Text, out regId);
                int.TryParse(textBox11.Text, out needInt);
                int.TryParse(textBox4.Text, out moreInt);
                int.TryParse(textBox12.Text, out countTechnik);
                int.TryParse(textBox13.Text, out regid);
                db.Warehouses.Add(new Warehouse() { Number = regId, TotalSize = needInt, Workers = moreInt, CountTechnick = countTechnik, Region = db.Regions.Single(x => x.Id==regid)});
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView4.SelectedRows[0].Cells[0].Value;
            using (var db = new Context())
            {
                var forremove = db.Orders.Single(x => x.Id == a);
                db.Orders.Remove(forremove);
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                int moreInt, shopId, depId;
                double needInt;
                int.TryParse(textBox17.Text, out depId);
                double.TryParse(textBox16.Text, out needInt);
                int.TryParse(textBox4.Text, out moreInt);
                int.TryParse(textBox18.Text, out shopId);
                db.Orders.Add(new Order() { NameProduct = textBox15.Text, SizeOrder = needInt, StartOrder = DateTime.Now,
                    Department = db.Departments.Single(x => x.Id==depId), Shop = db.Shops.Single(x => x.Id == shopId) });
                db.SaveChanges();
            }
            Form1_Load(new object(), new EventArgs());
        }
    }
}
