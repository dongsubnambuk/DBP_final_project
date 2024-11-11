using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBP_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color firstColor = System.Drawing.ColorTranslator.FromHtml("#fbc2eb");
            Color SecontColor = System.Drawing.ColorTranslator.FromHtml("#a6c1ee");

            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, firstColor, SecontColor, 45, false);
            e.Graphics.FillRectangle(br,this.ClientRectangle);
        }
    }
}
