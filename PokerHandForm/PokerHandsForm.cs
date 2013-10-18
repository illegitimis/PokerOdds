using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerOdds;
using BrightIdeasSoftware;
using H5S = PokerOdds.Hand5SerializableCollection.Hand5Serializable;
using System.Linq;

namespace PokerHandForm
{
    public partial class PokerHandsForm : Form
    {
        public PokerHandsForm()
        {
            InitializeComponent();
        }

        private BrightIdeasSoftware.OLVColumn olvcType;
        private BrightIdeasSoftware.OLVColumn olvcClassRank;
        private BrightIdeasSoftware.OLVColumn olvcsi;
        private BrightIdeasSoftware.OLVColumn olvcsa;
        private BrightIdeasSoftware.OLVColumn olvcHashCode;
        private BrightIdeasSoftware.OLVColumn olvcrc;
        private ToolStrip toolStrip;
        private ToolStripButton tsbOpen;
        private OpenFileDialog ofd;
        private ToolStripButton tsbRemoveAll;

        #region Windows Form Designer generated code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PokerHandsForm));
            this.olv = new BrightIdeasSoftware.ObjectListView();
            this.olvcType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcHashCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcClassRank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcsi = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcsa = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvcrc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tsbRemoveAll = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // olv
            // 
            this.olv.AllColumns.Add(this.olvcType);
            this.olv.AllColumns.Add(this.olvcHashCode);
            this.olv.AllColumns.Add(this.olvcClassRank);
            this.olv.AllColumns.Add(this.olvcsi);
            this.olv.AllColumns.Add(this.olvcsa);
            this.olv.AllColumns.Add(this.olvcrc);
            this.olv.AlternateRowBackColor = System.Drawing.Color.Gray;
            this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olv.BackColor = System.Drawing.Color.DimGray;
            this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcType,
            this.olvcHashCode,
            this.olvcClassRank,
            this.olvcsi,
            this.olvcsa,
            this.olvcrc});
            this.olv.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.olv.FullRowSelect = true;
            this.olv.HeaderWordWrap = true;
            this.olv.Location = new System.Drawing.Point(12, 28);
            this.olv.Name = "olv";
            this.olv.Size = new System.Drawing.Size(584, 222);
            this.olv.TabIndex = 0;
            this.olv.UseAlternatingBackColors = true;
            this.olv.UseCompatibleStateImageBehavior = false;
            this.olv.View = System.Windows.Forms.View.Details;
            // 
            // olvcType
            // 
            this.olvcType.AspectName = "Type";
            this.olvcType.IsEditable = false;
            this.olvcType.Text = "Hand type";
            this.olvcType.Width = 80;
            // 
            // olvcHashCode
            // 
            this.olvcHashCode.AspectName = "HashCode";
            this.olvcHashCode.IsEditable = false;
            this.olvcHashCode.Text = "Hash Code";
            // 
            // olvcClassRank
            // 
            this.olvcClassRank.AspectName = "ClassRank";
            this.olvcClassRank.IsEditable = false;
            this.olvcClassRank.Text = "Class Rank";
            // 
            // olvcsi
            // 
            this.olvcsi.AspectName = "StringI";
            this.olvcsi.IsEditable = false;
            this.olvcsi.Text = "Card indices";
            // 
            // olvcsa
            // 
            this.olvcsa.AspectName = "StringA";
            this.olvcsa.IsEditable = false;
            this.olvcsa.Text = "Pretty";
            // 
            // olvcrc
            // 
            this.olvcrc.AspectName = "RankCode";
            this.olvcrc.IsEditable = false;
            this.olvcrc.Text = "Rank code";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbRemoveAll});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(608, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::PokerHandForm.Properties.Resources.bin36;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(76, 22);
            this.tsbOpen.Text = "Open bin";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // tsbRemoveAll
            // 
            this.tsbRemoveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveAll.Image")));
            this.tsbRemoveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveAll.Name = "tsbRemoveAll";
            this.tsbRemoveAll.Size = new System.Drawing.Size(68, 22);
            this.tsbRemoveAll.Text = "RemoveAll";
            this.tsbRemoveAll.Click += new System.EventHandler(this.tsbRemoveAll_Click);
            // 
            // PokerHandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 262);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.olv);
            this.Name = "PokerHandsForm";
            this.Text = "Poker hands form";
            this.Load += new System.EventHandler(this.PokerHandsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olv;

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var col = Hand5SerializableCollection.DeserializeHands(ofd.FileName);
                //
                olv.SuspendLayout();
                if (olv.Objects == null || olv.Objects.Cast<H5S>().Count() == 0)
                    olv.SetObjects(col.Hands);
                else
                {
                    var u = col.Hands.Union(olv.Objects.Cast<H5S>());
                    olv.SetObjects(u);
                }
                olv.ResumeLayout(false);
                olv.PerformLayout();
            }
        }

        private void PokerHandsForm_Load(object sender, EventArgs e)
        {
            TypedObjectListView<H5S> tolv = new TypedObjectListView<H5S>(this.olv);
            tolv.GenerateAspectGetters();
        }

        private void tsbRemoveAll_Click(object sender, EventArgs e)
        {
            olv.SetObjects(null);
        }
    }
}
