namespace ParaScriptEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewContent = new System.Windows.Forms.TreeView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listKey = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colScope = new System.Windows.Forms.ColumnHeader();
            this.colValueType = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.comboKeyType = new System.Windows.Forms.ComboBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.btnAddNode = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteNode = new System.Windows.Forms.ToolStripButton();
            this.btnMoveUp = new System.Windows.Forms.ToolStripButton();
            this.btnMoveDown = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnErrorCheck = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewContent
            // 
            this.treeViewContent.AllowDrop = true;
            this.treeViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewContent.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewContent.ItemHeight = 18;
            this.treeViewContent.LabelEdit = true;
            this.treeViewContent.Location = new System.Drawing.Point(0, 0);
            this.treeViewContent.Name = "treeViewContent";
            this.treeViewContent.Size = new System.Drawing.Size(495, 505);
            this.treeViewContent.TabIndex = 1;
            this.treeViewContent.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeViewContent_AfterLabelEdit);
            this.treeViewContent.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewContent_BeforeCollapse);
            this.treeViewContent.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewContent_BeforeExpand);
            this.treeViewContent.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TreeViewContent_DrawNode);
            this.treeViewContent.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeViewContent_ItemDrag);
            this.treeViewContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewContent_AfterSelect);
            this.treeViewContent.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewContent_NodeMouseClick);
            this.treeViewContent.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewContent_NodeMouseDoubleClick);
            this.treeViewContent.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeViewContent_DragDrop);
            this.treeViewContent.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeViewContent_DragOver);
            this.treeViewContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewContent_MouseDown);
            this.treeViewContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TreeViewContent_MouseMove);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.Filter = "文本文档|*.txt";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewContent);
            this.splitContainer.Panel1.Margin = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.listKey);
            this.splitContainer.Panel2.Controls.Add(this.panel2);
            this.splitContainer.Size = new System.Drawing.Size(1059, 505);
            this.splitContainer.SplitterDistance = 495;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 2;
            // 
            // listKey
            // 
            this.listKey.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDescription,
            this.colScope,
            this.colValueType,
            this.colCategory});
            this.listKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKey.Location = new System.Drawing.Point(0, 29);
            this.listKey.MultiSelect = false;
            this.listKey.Name = "listKey";
            this.listKey.ShowItemToolTips = true;
            this.listKey.Size = new System.Drawing.Size(556, 476);
            this.listKey.TabIndex = 1;
            this.listKey.UseCompatibleStateImageBehavior = false;
            this.listKey.View = System.Windows.Forms.View.Details;
            this.listKey.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ListKey_ItemDrag);
            // 
            // colName
            // 
            this.colName.Text = "条件/指令";
            this.colName.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.Text = "说明";
            this.colDescription.Width = 160;
            // 
            // colScope
            // 
            this.colScope.Text = "作用域";
            this.colScope.Width = 80;
            // 
            // colValueType
            // 
            this.colValueType.Text = "值类型";
            this.colValueType.Width = 80;
            // 
            // colCategory
            // 
            this.colCategory.Text = "类别";
            this.colCategory.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearchKey);
            this.panel2.Controls.Add(this.comboKeyType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(556, 29);
            this.panel2.TabIndex = 0;
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchKey.Location = new System.Drawing.Point(127, 0);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(429, 23);
            this.txtSearchKey.TabIndex = 1;
            this.txtSearchKey.TextChanged += new System.EventHandler(this.TxtSearchKey_TextChanged);
            // 
            // comboKeyType
            // 
            this.comboKeyType.FormattingEnabled = true;
            this.comboKeyType.Location = new System.Drawing.Point(0, 0);
            this.comboKeyType.Name = "comboKeyType";
            this.comboKeyType.Size = new System.Drawing.Size(121, 23);
            this.comboKeyType.TabIndex = 0;
            this.comboKeyType.SelectedIndexChanged += new System.EventHandler(this.ComboKeyType_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnExpandAll,
            this.btnAddNode,
            this.btnDeleteNode,
            this.btnMoveUp,
            this.btnMoveDown,
            this.btnCopy,
            this.btnPaste,
            this.btnErrorCheck});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1059, 27);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::ParaScriptEditor.Properties.Resources.icon_new;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(24, 24);
            this.btnNew.Text = "新建";
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::ParaScriptEditor.Properties.Resources.icon_open;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(24, 24);
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::ParaScriptEditor.Properties.Resources.icon_save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExpandAll.Enabled = false;
            this.btnExpandAll.Image = global::ParaScriptEditor.Properties.Resources.icon_expand_all;
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.Text = "展开";
            this.btnExpandAll.Click += new System.EventHandler(this.BtnExpandAll_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNode.Image = global::ParaScriptEditor.Properties.Resources.icon_add_node;
            this.btnAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(24, 24);
            this.btnAddNode.Text = "添加节点";
            this.btnAddNode.Click += new System.EventHandler(this.BtnAddNode_Click);
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteNode.Enabled = false;
            this.btnDeleteNode.Image = global::ParaScriptEditor.Properties.Resources.icon_delete_node;
            this.btnDeleteNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteNode.Text = "删除节点";
            this.btnDeleteNode.Click += new System.EventHandler(this.BtnDeleteNode_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Image = global::ParaScriptEditor.Properties.Resources.icon_up;
            this.btnMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnMoveUp.Text = "向上移动";
            this.btnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Image = global::ParaScriptEditor.Properties.Resources.icon_down;
            this.btnMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnMoveDown.Text = "向下移动";
            this.btnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Enabled = false;
            this.btnCopy.Image = global::ParaScriptEditor.Properties.Resources.icon_copy;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(24, 24);
            this.btnCopy.Text = "复制节点";
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Enabled = false;
            this.btnPaste.Image = global::ParaScriptEditor.Properties.Resources.icon_paste;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(24, 24);
            this.btnPaste.Text = "粘贴节点";
            this.btnPaste.Click += new System.EventHandler(this.BtnPaste_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(3, 535);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1059, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 505);
            this.panel1.TabIndex = 5;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.Filter = "文本文档|*.txt";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // btnErrorCheck
            // 
            this.btnErrorCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnErrorCheck.Image = global::ParaScriptEditor.Properties.Resources.icon_check;
            this.btnErrorCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnErrorCheck.Name = "btnErrorCheck";
            this.btnErrorCheck.Size = new System.Drawing.Size(24, 24);
            this.btnErrorCheck.Text = "语法检查";
            this.btnErrorCheck.Click += new System.EventHandler(this.BtnErrorCheck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "ParaScriptEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TreeView treeViewContent;
        private OpenFileDialog openFileDialog;
        private SplitContainer splitContainer;
        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private Panel panel1;
        private ToolStripButton btnNew;
        private ToolStripButton btnOpen;
        private ToolStripButton btnSave;
        private Panel panel2;
        private ListView listKey;
        private ColumnHeader colName;
        private ColumnHeader colDescription;
        private ColumnHeader colScope;
        private ColumnHeader colValueType;
        private ColumnHeader colCategory;
        private ComboBox comboKeyType;
        private TextBox txtSearchKey;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnAddNode;
        private ToolStripButton btnDeleteNode;
        private ToolStripButton btnExpandAll;
        private SaveFileDialog saveFileDialog;
        private ToolStripButton btnMoveUp;
        private ToolStripButton btnMoveDown;
        private ToolStripButton btnCopy;
        private ToolStripButton btnPaste;
        private ToolStripButton btnErrorCheck;
    }
}