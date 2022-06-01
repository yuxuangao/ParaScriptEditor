using System.Diagnostics;

namespace ParaScriptEditor
{
    public partial class MainForm : Form
    {

        private bool isDoubleClick = false;
        private readonly List<ListViewItem> keyList = new();
        private string? openFileNameWithoutPath = null;
        private TreeNode? copyNode = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<KeyType, string> pair in Translation.keyTypeNameMap)
            {
                comboKeyType.Items.Add(new KeyTypeComboObject(pair.Key, pair.Value));
            }
            comboKeyType.SelectedIndex = 0;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            treeViewContent.Nodes.Clear();
            openFileNameWithoutPath = null;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openFileNameWithoutPath = openFileDialog.SafeFileName;
                    List<Item> itemList = FileReader.Read(openFileDialog.FileName);
                    treeViewContent.Nodes.Clear();
                    foreach (Item item in itemList)
                    {
                        treeViewContent.Nodes.Add(GenerateTreeNode(item));
                    }

                    btnExpandAll.Enabled = false;
                    btnDeleteNode.Enabled = false;
                    btnMoveUp.Enabled = false;
                    btnMoveDown.Enabled = false;
                    btnCopy.Enabled = false;
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "打开文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (openFileNameWithoutPath != null)
            {
                saveFileDialog.FileName = openFileNameWithoutPath;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFileName = saveFileDialog.FileName;
                List<Item> itemList;
                if (HasError(out itemList))
                {
                    MessageBox.Show(this, "有语法错误，保存失败", "保存", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileWriter.Save(itemList, saveFileName);
                MessageBox.Show(this, "保存成功", "保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private TreeNode GenerateTreeNode(Item item)
        {
            if (item.Value != null)
            {
                return new TreeNode(item.Key + " " + item.CompareSign + " " + item.Value) { Tag = item };
            }
            else
            {
                List<TreeNode> subNodes = new();
                foreach (Item subItem in item.ValueArray)
                {
                    TreeNode? subNode = GenerateTreeNode(subItem);
                    if (subNode != null)
                    {
                        subNodes.Add(subNode);
                    }
                }
                return new TreeNode(item.Key, subNodes.ToArray()) { Tag = item };
            }
        }

        private void TreeViewContent_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewContent.SelectedNode = e.Node;
        }

        private void TreeViewContent_MouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeViewContent.HitTest(e.X, e.Y);
            if (info.Node == null)
            {
                treeViewContent.SelectedNode = null;
                btnExpandAll.Enabled = false;
                btnDeleteNode.Enabled = false;
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnCopy.Enabled = false;
            }
            isDoubleClick = e.Clicks > 1;
        }

        private void TreeViewContent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnExpandAll.Enabled = e.Node != null;
            btnDeleteNode.Enabled = e.Node != null;
            btnMoveUp.Enabled = e.Node != null;
            btnMoveDown.Enabled = e.Node != null;
            btnCopy.Enabled = e.Node != null;
        }

        private void TreeViewContent_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.BeginEdit();
        }

        private void TreeViewContent_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick && e.Action == TreeViewAction.Collapse)
                e.Cancel = true;
        }

        private void TreeViewContent_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (isDoubleClick && e.Action == TreeViewAction.Expand)
                e.Cancel = true;
        }

        private void TreeViewContent_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void ShowKeyTypeList(KeyType keyType, bool append = false)
        {
            if (!append)
            {
                keyList.Clear();
            }

            switch (keyType)
            {
                case KeyType.logicCommand:
                    foreach (KeyValuePair<string, string> pair in Translation.logicCommandMap)
                    {
                        keyList.Add(new ListViewItem(new string[] {pair.Key, pair.Value, "", "", ""}));
                    }
                    break;
                case KeyType.trigger:
                    foreach (KeyValuePair<string, Key> pair in Translation.triggerMap)
                    {
                        keyList.Add(new ListViewItem(new string[] { pair.Key, pair.Value.Description, 
                            pair.Value.GetScopeString(), pair.Value.GetValueTypeString(), pair.Value.GetCategoryString() }));
                    }
                    break;
                case KeyType.command:
                    foreach (KeyValuePair<string, Key> pair in Translation.commandMap)
                    {
                        keyList.Add(new ListViewItem(new string[] { pair.Key, pair.Value.Description,
                            pair.Value.GetScopeString(), pair.Value.GetValueTypeString(), pair.Value.GetCategoryString() }));
                    }
                    break;
                case KeyType.all:
                    ShowKeyTypeList(KeyType.logicCommand, true);
                    ShowKeyTypeList(KeyType.trigger, true);
                    ShowKeyTypeList(KeyType.command, true);
                    break;
            }
            listKey.Items.Clear();
            listKey.Items.AddRange(keyList.ToArray());
        }

        private void ComboKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKeyType.SelectedIndex == -1)
            {
                return;
            }
            ShowKeyTypeList(((KeyTypeComboObject)comboKeyType.SelectedItem).KeyType);
        }

        private void TxtSearchKey_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearchKey.Text.ToLower();
            if (search == null || search.Length <= 0)
            {
                listKey.Items.Clear();
                listKey.Items.AddRange(keyList.ToArray());
                return;
            }
            IEnumerable<ListViewItem> searchList = keyList.Where(
                value => 
                {
                    foreach (ListViewItem.ListViewSubItem subItem in value.SubItems)
                    {
                        if (subItem.Text.ToLower().Contains(search))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            );
            listKey.Items.Clear();
            listKey.Items.AddRange(searchList.ToArray());
        }

        private void TreeViewContent_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }
            if (!e.Node.IsVisible)
            {
                return;
            }

            Item item = (Item)e.Node.Tag;

            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                TextRenderer.DrawText(e.Graphics, e.Node.Text, treeViewContent.Font, new Point(e.Bounds.X, e.Bounds.Y + 1), Color.White);
            }
            else if (item != null && item.HasError)
            {
                TextRenderer.DrawText(e.Graphics, e.Node.Text, treeViewContent.Font, new Point(e.Bounds.X, e.Bounds.Y + 1), Color.Red);
            }
            else
            {
                
                TextRenderer.DrawText(e.Graphics, e.Node.Text, treeViewContent.Font, new Point(e.Bounds.X, e.Bounds.Y + 1), ForeColor);
            }

            if (item != null)
            {
                TextRenderer.DrawText(e.Graphics, FileReader.Translate(item), treeViewContent.Font, new Point(e.Bounds.Right + 10, e.Bounds.Y + 1), Color.Gray);
            }
        }

        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            TreeNode node = new("");
            Item item = new();
            node.Tag = item;
            if (treeViewContent.SelectedNode == null)
            {
                treeViewContent.Nodes.Add(node);
            }
            else
            {
                treeViewContent.SelectedNode.Nodes.Add(node);
                ((Item)treeViewContent.SelectedNode.Tag).ValueArray.Add(item);
                item.Parent = (Item)treeViewContent.SelectedNode.Tag;
                if (!treeViewContent.SelectedNode.IsExpanded)
                {
                    treeViewContent.SelectedNode.Expand();
                }
            }
            node.EnsureVisible();
            node.BeginEdit();
        }

        private void BtnDeleteNode_Click(object sender, EventArgs e)
        {
            if (treeViewContent.SelectedNode == null)
            {
                return;
            }
            TreeNode node = treeViewContent.SelectedNode;
            Item item = (Item)node.Tag;
            node.Remove();
            if (item.Parent != null)
            {
                item.Parent.ValueArray.Remove(item);
            }
            btnExpandAll.Enabled = treeViewContent.SelectedNode != null;
            btnDeleteNode.Enabled = treeViewContent.SelectedNode != null;
            btnMoveUp.Enabled = treeViewContent.SelectedNode != null;
            btnMoveDown.Enabled = treeViewContent.SelectedNode != null;
            btnCopy.Enabled = treeViewContent.SelectedNode != null;
        }

        private void TreeViewContent_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null || e.Label.Length <= 0)
            {
                e.CancelEdit = true;
                return;
            }

            TreeNode node = (TreeNode)e.Node;
            if (!FileReader.ReadInput(e.Label, (Item)node.Tag))
            {
                e.CancelEdit = true;
                e.Node.BeginEdit();
                return;
            }

            Item item = (Item)node.Tag;
            if (item.Value != null)
            {
                node.Text = item.Key + " " + item.CompareSign + " " + item.Value;
            }
            else
            {
                node.Text = item.Key;
            }
            e.CancelEdit = true;
        }

        private void BtnExpandAll_Click(object sender, EventArgs e)
        {
            if (treeViewContent.SelectedNode == null)
            {
                return;
            }
            treeViewContent.SelectedNode.ExpandAll();
        }

        private void TreeViewContent_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            treeViewContent.SelectedNode = (TreeNode)e.Item;
            treeViewContent.Focus();
            treeViewContent.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void ListKey_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            listKey.Focus();
            listKey.DoDragDrop(((ListViewItem)e.Item).SubItems[0].Text, DragDropEffects.All);
        }

        private void TreeViewContent_DragOver(object sender, DragEventArgs e)
        {
            treeViewContent.Focus();
            TreeNode? node = treeViewContent.GetNodeAt(treeViewContent.PointToClient(new Point(e.X, e.Y)));
            treeViewContent.SelectedNode = node;

            if (e.Data == null)
            {
                e.Effect = DragDropEffects.None;
            }
            else if (!e.Data.GetDataPresent(typeof(TreeNode)) && !e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.None;
            }
            else if (node != null && e.Data.GetDataPresent(typeof(TreeNode)) && node == e.Data.GetData(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.None;
            }
            else if (node != null && e.Data.GetDataPresent(typeof(TreeNode)) && IsChildNode((TreeNode)e.Data.GetData(typeof(TreeNode)), node))
            {
                e.Effect = DragDropEffects.None;
            }
            else if (node == null && e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.None;
            }
            else if ((e.KeyState & 8) != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void TreeViewContent_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }
            else if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode? srcNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                TreeNode? node = treeViewContent.SelectedNode;
                if (srcNode == null)
                {
                    return;
                }

                if ((e.KeyState & 8) != 0)
                {
                    srcNode = GetTreeNodeClone(srcNode);
                }
                else
                {
                    srcNode.Remove();
                }

                if (node == null)
                {
                    treeViewContent.Nodes.Add(srcNode);
                }
                else
                {
                    node.Nodes.Add(srcNode);
                    ((Item)node.Tag).ValueArray.Add((Item)srcNode.Tag);
                    ((Item)srcNode.Tag).Parent = (Item)node.Tag;
                }
            }
            else if (e.Data.GetDataPresent(typeof(string)))
            {
                TreeNode? node = treeViewContent.SelectedNode;
                if (node == null)
                {
                    return;
                }
                node.Text = (string)e.Data.GetData(typeof(string));
                FileReader.ReadInput(node.Text, (Item)node.Tag);
                node.BeginEdit();
            }
        }

        private bool IsChildNode(TreeNode parentNode, TreeNode childNode)
        {
            if (childNode.Parent == parentNode)
                return true;
            else if (childNode.Parent != null)
                return IsChildNode(parentNode, childNode.Parent);
            else
                return false;
        }

        private TreeNode GetTreeNodeClone(TreeNode node, TreeNode? parent = null)
        {
            TreeNode result = (TreeNode)node.Clone();
            Item item = (Item)node.Tag;

            result.Tag = item.Clone();
            if (parent != null)
            {
                ((Item)result.Tag).Parent = (Item)parent.Tag;
            }
            result.Nodes.Clear();
            foreach(TreeNode subNode in node.Nodes)
            {
                result.Nodes.Add(GetTreeNodeClone(subNode, result));
            }

            return result;
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewContent.SelectedNode;
            TreeNode parent = node.Parent;
            if (node == null)
            {
                return;
            }
            Item item = (Item)node.Tag;
            int indexNow = node.Index;
            if (indexNow == 0)
            {
                return;
            }

            if (parent == null || item.Parent == null)
            {
                treeViewContent.Nodes.RemoveAt(indexNow);
                treeViewContent.Nodes.Insert(indexNow - 1, node);
            }
            else
            {
                parent.Nodes.RemoveAt(indexNow);
                parent.Nodes.Insert(indexNow - 1, node);
                item.Parent.ValueArray[indexNow] = item.Parent.ValueArray[indexNow - 1];
                item.Parent.ValueArray[indexNow - 1] = item;
            }
            treeViewContent.SelectedNode = node;
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewContent.SelectedNode;
            TreeNode parent = node.Parent;
            if (node == null)
            {
                return;
            }
            Item item = (Item)node.Tag;
            int indexNow = node.Index;

            if (parent != null && indexNow == parent.Nodes.Count - 1)
            {
                return;
            }
            if (parent == null && indexNow == treeViewContent.Nodes.Count - 1)
            {
                return;
            }

            if (parent == null || item.Parent == null)
            {
                treeViewContent.Nodes.RemoveAt(indexNow);
                treeViewContent.Nodes.Insert(indexNow + 1, node);
            }
            else
            {
                parent.Nodes.RemoveAt(indexNow);
                parent.Nodes.Insert(indexNow + 1, node);
                item.Parent.ValueArray[indexNow] = item.Parent.ValueArray[indexNow + 1];
                item.Parent.ValueArray[indexNow + 1] = item;
            }
            treeViewContent.SelectedNode = node;
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewContent.SelectedNode;
            if (node == null)
            {
                return;
            }
            copyNode = GetTreeNodeClone(node);
            btnPaste.Enabled = true;
        }

        private void BtnPaste_Click(object sender, EventArgs e)
        {
            if (copyNode == null)
            {
                return;
            }
            TreeNode node = treeViewContent.SelectedNode;
            if (node == null)
            {
                treeViewContent.Nodes.Add(copyNode);
            }
            else
            {
                node.Nodes.Add(copyNode);
                ((Item)node.Tag).ValueArray.Add((Item)copyNode.Tag);
                ((Item)copyNode.Tag).Parent = (Item)node.Tag;
                if (!node.IsExpanded)
                {
                    node.Expand();
                }
            }
            copyNode.EnsureVisible();
            copyNode = GetTreeNodeClone(copyNode);
        }

        private void BtnErrorCheck_Click(object sender, EventArgs e)
        {
            if (HasError(out List<Item> _))
            {
                MessageBox.Show(this, "有语法错误", "语法检查", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this, "没有错误", "语法检查", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool HasError(out List<Item> itemList)
        {
            itemList = new();
            if (treeViewContent.Nodes == null)
            {
                return false;
            }
            foreach (TreeNode ndoe in treeViewContent.Nodes)
            {
                itemList.Add((Item)ndoe.Tag);
            }
            bool result = FileWriter.HasError(itemList);
            treeViewContent.Refresh();
            return result;
        }
    }
}