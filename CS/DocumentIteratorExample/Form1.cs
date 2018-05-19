using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentIteratorExample {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            ribbonControl1.SelectedPage = pageIterator;                   
        }

        private void btnIteratorRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            #region #runvisitor
            MyVisitor visitor = new MyVisitor();
            DocumentIterator iterator = new DocumentIterator(richEditControl1.Document, true);
            while (iterator.MoveNext())
                iterator.Current.Accept(visitor);
            memoEdit1.Text = visitor.Text;
            #endregion #runvisitor
        }
    }
    #region #myvisitorclass
    public class MyVisitor : DocumentVisitorBase
    {
        readonly StringBuilder buffer;
        public MyVisitor() { this.buffer = new StringBuilder(); }
        protected StringBuilder Buffer { get { return buffer; } }
        public string Text { get { return Buffer.ToString(); } }

        public override void Visit(DocumentText text) {
            string prefix = (text.TextProperties.FontBold) ? "**" : "";
            Buffer.Append(prefix);
            Buffer.Append(text.Text);
            Buffer.Append(prefix);
        }
        public override void Visit(DocumentParagraphEnd paragraphEnd) {
            Buffer.AppendLine();
        }
    }
    #endregion #myvisitorclass
}
