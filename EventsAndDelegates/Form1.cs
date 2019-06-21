using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsAndDelegates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BankAccount TheBankAccount;
        private void Form1_Load(object sender, EventArgs e)
        {
            TheBankAccount = new BankAccount();
            TheBankAccount.Balance = 100m;
            txtBalance.Text = TheBankAccount.Balance.ToString("C");
            TheBankAccount.Overdrawn += Account_Overdrawn;
        }
        private void Account_Overdrawn(object sender, OverDrawnArgs e)
        {
            // Get the account.
            BankAccount account = sender as BankAccount;

            // Ask the user whether to allow this.
            if (MessageBox.Show("Insufficient funds.\n\n    Current balance: " +
                account.Balance.ToString("C") + "\n    Debit amount: " +
                e.DebitAmount.ToString("C") + "\n\n" +
                "Do you want to allow this transaction anyway?",
                "Allow?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
            {
                // Allow the transaction anyway.
                e.allow = true;
            }
        }

        private void BtnCredit_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Currency,
                CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("The amount must be a currency value.",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtAmount.Focus();
            }

            // Post the credit.
            try
            {
                TheBankAccount.Credit(amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the new balance.
            txtBalance.Text = TheBankAccount.Balance.ToString("C");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, NumberStyles.Currency,
                CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("The amount must be a currency value.",
                    "Invalid Amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtAmount.Focus();
            }

            // Post the debit.
            try
            {
                TheBankAccount.Debit(amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the new balance.
            txtBalance.Text = TheBankAccount.Balance.ToString("C");
        }
    }
}
