﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LaundryIfaNew
{
    internal class Properti
    {
        //koneksi
        public static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-18L8S2S;Initial Catalog=LaundrySyifa;Integrated Security=True");


        public static SqlConnection konek() 
        { 
            return new SqlConnection(@"Data Source=DESKTOP-18L8S2S;Initial Catalog=LaundrySyifa;Integrated Security=True"); 
        }

        //vaidasi
        public static bool validasi(Control.ControlCollection controls, TextBoxBase kosong = null)
        {
            foreach (Control c in controls)
            {
                if (c is TextBoxBase textBox && string.IsNullOrWhiteSpace(textBox.Text) && textBox != kosong)
                {
                    return true;
                }
            } return false;
        }

        //enkripsi
        public static string enkripsi(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            } 
            
            return sb.ToString();
        }
        
    }
}
