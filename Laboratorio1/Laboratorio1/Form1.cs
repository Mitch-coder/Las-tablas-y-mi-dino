using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Laboratorio1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExercise2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Exercise2 from = new Exercise2();
            from.MdiParent = this;
            from.Show();
        }

        private void BtnExercise1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            //Mandamos a llamar al otro formulario desde el principal especificandole que es un hijo del contenedor 
            IsMdiContainer = true;
            Exercise1 frm = new Exercise1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void BtnPresentation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsMdiContainer = true;
            Presentation frm = new Presentation();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
