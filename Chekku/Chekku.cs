﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chekku
{
    public partial class Chekku : Form
    {
        public Chekku()
        {
            InitializeComponent();
        }

        private void BtnExams_Click(object sender, EventArgs e)
        {

        }

        private void BtnSubjects_Click(object sender, EventArgs e)
        {
            Form frm = new Subjects();
            frm.Show();
            this.Hide();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            Form frm = new Students();
            frm.Show();
            this.Hide();
        }

        private void BtnSection_Click(object sender, EventArgs e)
        {
            Form frm = new Section();
            frm.Show();
            this.Hide();
        }

        private void BtnQuestions_Click(object sender, EventArgs e)
        {
            Form frm = new Questions();
            frm.Show();
            this.Hide();
        }
    }
}