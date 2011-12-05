using System;
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
        ListHolder.Usertype usertype; //Users Type
        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="hold"></param>
        public StockControl(ListHolder hold, ListHolder.Usertype value)
        {
            InitializeComponent();
            parentlistholder = hold;
            usertype = value;
        }
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockControl_Load(object sender, EventArgs e)
        {
            parentlistholder.Initialise(); //Load Stock Control
            string[] itemnames = DodgyBobStockControl.StockControl.GET_ITEMS(); //Get List of Items
            for (int i = 0; i < itemnames.Length; i++) //For Every Item
            {
                ItemsListView.Items.Add(itemnames[i].ToString()); //Add Item Name to the List
                string quan =  DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' stockcheck please"); //Check the amount of that item in stock
                //in format: we have 100 in stock
                quan = quan.Substring(8);// Gets rid of "We Have "
                string[] tempvalues = quan.Split(' '); //Splits the string at " "'s
                quan = tempvalues[0]; //Gets the values before the space
                ItemsListView.Items[i].SubItems.Add(quan); //Adds Quantity to List
                string price = DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' cost please"); //Gets the price of the item
                ItemsListView.Items[i].SubItems.Add(price); //Adds Price to List
                string expiry = DodgyBobStockControl.StockControl.ASK("'" + itemnames[i] + "' expiry please"); //Gets Expiry Date
                //In Format: it will expire on ##/##/####
                expiry = expiry.Substring(14); //Shorted to just ##/##/####
                ItemsListView.Items[i].SubItems.Add(expiry); //Shortens Expiry Date
            }
            UpdateColumnSize(); //Update Column Size
        }
        /// <summary>
        /// Updates the Column Size
        /// </summary>
        public void UpdateColumnSize()
        {
            foreach (ColumnHeader ch in this.ItemsListView.Columns) //For Every Column
            {
                ch.Width = -2; //Adjust Width
            }
        }
        /// <summary>
        /// Increase Quantity Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncreaseQuan_Click(object sender, EventArgs e)
        {
            if (ItemsListView.SelectedItems.Count > 0) //If an Item has been selected
            {
                string quantity = ItemsListView.SelectedItems[0].SubItems[1].Text; //Get Quantity
                int quantityvalue = int.Parse(quantity); //Turn into a integer
                quantityvalue++; //Increment
                ItemsListView.SelectedItems[0].SubItems[1].Text = quantityvalue.ToString(); //Write It Back
                DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' return 1 please"); //Update Stock Control
                if (DodgyBobStockControl.StockControl.SAVE() == true) //If Save Function Works
                    MessageBox.Show("Saved"); //Show Message Box
            }
            else //If no item is selected 
            {
                MessageBox.Show("Nothing Selected!");//show error message
            }
        }
        /// <summary>
        /// Decrease Quantity Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecreaseQuan_Click(object sender, EventArgs e)
        {
            if (ItemsListView.SelectedItems.Count > 0)//If an Item has been selected
            {
                string quantity = ItemsListView.SelectedItems[0].SubItems[1].Text;  //Get Quantity
                int quantityvalue = int.Parse(quantity); //Turn into a integer
                quantityvalue--; //Decrement
                ItemsListView.SelectedItems[0].SubItems[1].Text = quantityvalue.ToString(); //Write It Back
                DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' consume 1 please"); //Update Stock Control
                if (DodgyBobStockControl.StockControl.SAVE() == true) //If Save Function Works
                    MessageBox.Show("Saved"); //Show Message Box
            }
            else //If no item is selected 
            {
                MessageBox.Show("Nothing Selected!"); //Show error Message
            }

        }
        /// <summary>
        /// Restock Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restock_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text != "") //If there is a value in amount 
            {
                int QuantityInStock = 0, QuantityToAdd = 0; //Make Values
                try
                {
                    string quantitystring = ItemsListView.SelectedItems[0].SubItems[1].Text; //Get Quantity
                    QuantityInStock = int.Parse(quantitystring); //Get Quantity in Stock
                    QuantityToAdd = int.Parse(txtAmount.Text); //get Quantity to Add
                    QuantityInStock += QuantityToAdd; //Add Together
                    ItemsListView.SelectedItems[0].SubItems[1].Text = QuantityToAdd.ToString(); //update the listview with the new quantity
                    string olddate = ItemsListView.SelectedItems[0].SubItems[3].Text.Substring(0, 6); //gets the orginal day and month
                    int oldyear = int.Parse(ItemsListView.SelectedItems[0].SubItems[3].Text.Substring(6)); //get the orginal year
                    oldyear++; //increments year
                    ItemsListView.SelectedItems[0].SubItems[3].Text = olddate + oldyear.ToString(); //Updates the use by dte box date
                    DodgyBobStockControl.StockControl.DO("'" + ItemsListView.SelectedItems[0].Text + "' restock " + QuantityToAdd + " please"); //Restock Items
                    if (DodgyBobStockControl.StockControl.SAVE() == true) //If Save function works
                        MessageBox.Show("Saved"); //Show Message Box
                }
                catch //If something other than a number is typed in
                {
                    MessageBox.Show("Please Type a Number in"); //Show Error Message
                    txtAmount.Text = "0"; //Reset to 0
                }

            }
            else //If Nothing is Typed in
            {
                MessageBox.Show("Please Type a Value in Amount"); //Show Error Message
            }
        }
        /// <summary>
        /// Close Form Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Closebtn_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(usertype, parentlistholder);
            form.Show();
            this.Close();
        }

    }
}
