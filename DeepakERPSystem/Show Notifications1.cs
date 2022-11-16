﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeepakERPSystem
{
    public partial class Show_Notifications1 : Form
    {
        SqlConnection connmmc = new SqlConnection(SqlconnMain.sbpayroll);
        public Show_Notifications1()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Show_Notifications1_Load(object sender, EventArgs e)
        {
            try
            {
                if (connmmc.State == ConnectionState.Closed)
                    connmmc.Open();
                SqlCommand cmd = new SqlCommand("select username,desc1 from notifications order by datetime1 desc ", connmmc);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
    }
}
