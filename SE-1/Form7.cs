﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mohsin
{
    public partial class Form7 : Form
    {
        private static int uid = 0;
        public Form7(int userid)
        {
            InitializeComponent();
            uid = userid;
        }

      

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(uid);
            form3.Visible = true;
            this.Visible = false;

        }
    }
}