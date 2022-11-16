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
    public partial class Forgot_Username : Form
    {
        SqlConnection conmmc = new SqlConnection(SqlconnMain.sbpayroll);
        public Forgot_Username()
        {
            InitializeComponent();
        }

        private void btnCheckUsername_Click(object sender, EventArgs e)
        {
            if (txtEmpName.Text=="")
            {
                MessageBox.Show("Please enter your name to raise a request.","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                
            }
            
            else
            {

                try
                {
                    if (conmmc.State == ConnectionState.Closed)
                        conmmc.Open();
                    SqlCommand cmd = new SqlCommand("select count(*) from userm where usr_name=@username COLLATE SQL_Latin1_General_CP1_CS_AS", conmmc);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", txtEmpName.Text);
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("This user doesn't exists into the system,Please enter a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        int userrequest = 1;

                        if (conmmc.State == ConnectionState.Closed)
                            conmmc.Open();
                        SqlCommand cmd1 = new SqlCommand("insert into usernamerequest (username,unamerequestdate,unamerequest)values(@username,@datetime,@userrequest)", conmmc);
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Parameters.AddWithValue("@username", txtEmpName.Text);
                        cmd1.Parameters.AddWithValue("@datetime", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@userrequest", userrequest);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Dear User you have sucessfully raised a request to recover your username, You will get your username on your email shortly.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        try
                        {
                            //int u_pwd = 0;
                            myglobalvar code = new myglobalvar();
                            string pcusername = myglobalvar.strUsername.ToString().Trim();
                            string pcname = myglobalvar.strPCName.ToString().Trim();
                            string ipaddress = myglobalvar.strIPAddress.ToString().Trim();
                            //string username = myglobalvar.selecteduser.ToString().Trim();
                            //int selectedcompany = myglobalvar.selectedcompany;

                            code.Execute(@"insert into usr_log (log_date,sys_name,sys_ip,usr_name,desc1)values(GETDATE(),'" + pcname + "/" + pcusername + "','" + ipaddress + "','" + txtEmpName.Text + "','Clicked on forgot username button and sent request for recover username request for " + txtEmpName.Text + "user.')");
                        }
                        catch (InvalidCastException ee)
                        {
                            throw (ee);
                        }
                        txtEmpName.Text = "";
                    }

                   
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
        }
        
       
    }
}
