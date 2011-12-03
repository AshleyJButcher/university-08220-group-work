﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class StockControl : Form
    {
        ListHolder parentlistholder;
        public StockControl(ListHolder hold)
        {
            InitializeComponent();
            parentlistholder = hold;
        }

        private void StockControl_Load(object sender, EventArgs e)
        {
            parentlistholder.Initialise();
            string[] itemnames = DodgyBobStockControl.StockControl.GET_ITEMS();
            for (int i = 0; i < itemnames.Length; i++)
            {
                ItemsListView.Items.Add(itemnames[i].ToString());
                string quan =  DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' stockcheck please");
                quan = quan.Substring(8);// Gets rid of "We Have "
                string[] tempvalues = quan.Split(' '); //Splits the string at " "'s
                quan = tempvalues[0]; //Gets the values before the space
                ItemsListView.Items[i].SubItems.Add(quan);
                string price = DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' cost please");
                ItemsListView.Items[i].SubItems.Add(price);
                string expiry = DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' expiry please");
                expiry = expiry.Substring(14);
                ItemsListView.Items[i].SubItems.Add(expiry);
            }
            UpdateColumnSize();
        }
        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.ItemsListView.Columns)
            {
                ch.Width = -2;
            }
        }

        private void IncreaseQuan_Click(object sender, EventArgs e)
        {
            if (ItemsListView.SelectedItems.Count > 0)
            {
                string quantity = ItemsListView.SelectedItems[0].SubItems[1].Text;
                int quantityvalue = int.Parse(quantity);
                quantityvalue++;
                ItemsListView.SelectedItems[0].SubItems[1].Text = quantityvalue.ToString();
                DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' return 1 please");
                if (DodgyBobStockControl.StockControl.SAVE() == true)
                    MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Nothing Selected!");
            }
        }

        private void DecreaseQuan_Click(object sender, EventArgs e)
        {
            if (ItemsListView.SelectedItems.Count > 0)
            {
                string quantity = ItemsListView.SelectedItems[0].SubItems[1].Text;
                int quantityvalue = int.Parse(quantity);
                quantityvalue--;
                ItemsListView.SelectedItems[0].SubItems[1].Text = quantityvalue.ToString();
                DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' consume 1 please");
                if (DodgyBobStockControl.StockControl.SAVE() == true)
                    MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Nothing Selected!");
            }

        }

        private void Restock_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text != "")
            {
                int quantity2 = 0, quantityvalue = 0;
                try
                {
                    string quantitystring = ItemsListView.SelectedItems[0].SubItems[1].Text;
                    quantity2 = int.Parse(quantitystring);
                    quantityvalue = int.Parse(txtAmount.Text);
                    quantity2 += quantityvalue;
                    ItemsListView.SelectedItems[0].SubItems[1].Text = quantityvalue.ToString(); //update the listview with the new quantity
                    string olddate = ItemsListView.SelectedItems[0].SubItems[3].Text.Substring(0,6); //gets the orginal day and month
                    int oldyear =  int.Parse(ItemsListView.SelectedItems[0].SubItems[3].Text.Substring(6)); //get the orginal year
                    oldyear++; //increments year
                    ItemsListView.SelectedItems[0].SubItems[3].Text = olddate + oldyear.ToString(); //Updates the use by dte box date
                    DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' restock " + quantityvalue + " please");
                    if (DodgyBobStockControl.StockControl.SAVE() == true)
                        MessageBox.Show("Saved");
                }
                catch
                {
                    MessageBox.Show("Please Type a Number in");
                    txtAmount.Text = "0";
                }
 
            }
        }

    }
}