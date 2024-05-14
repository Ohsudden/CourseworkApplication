using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkApplication
{
    public partial class Form2 : Form
    {
        public Form2(DataTable dataTable)
        {
            InitializeComponent();
            dataGridViewResults.DataSource = dataTable;
  
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            int totalWidth = dataGridViewResults.ClientSize.Width;
            int totalHeight = dataGridViewResults.ClientSize.Height;

            int countColumns = dataGridViewResults.Columns.Count;
            int countRows = dataGridViewResults.Rows.Count;

            int columnWidth = totalWidth / countColumns;
            int rowHeight = totalHeight / countRows;

            foreach (DataGridViewColumn column in dataGridViewResults.Columns)
            {
                column.Width = columnWidth;
            }

            foreach (DataGridViewRow row in dataGridViewResults.Rows)
            {
                row.Height = rowHeight;
            }
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
