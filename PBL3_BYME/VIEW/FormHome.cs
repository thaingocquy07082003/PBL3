﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BYME
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            SetColor();
        }
        public void SetColor()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimPhong tim = new TimPhong();
            tim.ShowDialog();
            tim = null;
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}