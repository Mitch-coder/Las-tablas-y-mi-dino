using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables
{
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }
        private void Multiply_Click(object sender, EventArgs e)
        {
            listResult.Items.Clear();
            int TableGiven = int.Parse(table.Text);
            int LimitGiven = int.Parse(limit.Text);
            int result;

            for (int i = 0; i <= LimitGiven; i++)
            {
                result = TableGiven * i;
                listResult.Items.Add(TableGiven + "x" + i + "=" + result);
            }

        }

        private void Limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar < 48) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void Table_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar < 48) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
