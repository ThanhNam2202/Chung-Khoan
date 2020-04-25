using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CHUNGKHOAN
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable db = new DataTable();
            db.Columns.Add("1");
            db.Columns.Add("2");
            /*db.Columns.Add("3");
            db.Columns.Add("4");
            db.Columns.Add("5");
            db.Columns.Add("6");*/
            DataRow dr = null;
            for (int i = 0; i < 10; i++)
            {
                dr = db.NewRow();
                dr["1"] = i.ToString();
                dr["2"] = (i + 1).ToString();
                /*dr["3"] = (i + 2).ToString();
                dr["4"] = (i + 3).ToString();
                dr["5"] = (i + 4).ToString();
                dr["6"] = (i + 5).ToString();*/
                db.Rows.Add(dr);
            }

            gridControl1.DataSource = db;

        }

    }
}
