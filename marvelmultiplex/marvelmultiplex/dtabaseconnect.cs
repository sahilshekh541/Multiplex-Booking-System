﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace marvelmultiplex
{
    class databaseconnect
    {

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\mutliplexbookingsystem\\marvelmultiplex\\marvelmultiplex\\marvelmultiplexdb.mdf;Integrated Security=True";
            return con;
        }

        public DataSet GetData(string query)
        {

            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }

        public void setdata(string query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();



        }
    }
}
