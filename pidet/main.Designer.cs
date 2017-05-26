namespace Pidet
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dgv_field = new System.Windows.Forms.DataGridView();
            this.ms = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveFileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_ChangeTool = new System.Windows.Forms.ToolStripMenuItem();
            this.表示VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.イメージIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ChangeCanvasSize = new System.Windows.Forms.ToolStripMenuItem();
            this.デバッグDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_StartDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_JumpDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_StepDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ResetDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_palette = new System.Windows.Forms.DataGridView();
            this.sc_field = new System.Windows.Forms.SplitContainer();
            this.sc_buffer = new System.Windows.Forms.SplitContainer();
            this.tb_input = new System.Windows.Forms.TextBox();
            this.tb_output = new System.Windows.Forms.TextBox();
            this.tb_stack = new System.Windows.Forms.TextBox();
            this.btn_debug = new System.Windows.Forms.Button();
            this.btn_step = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.tm_pen = new System.Windows.Forms.Timer(this.components);
            this.btn_change = new System.Windows.Forms.Button();
            this.tm_status = new System.Windows.Forms.Timer(this.components);
            this.tb_stackbefore = new System.Windows.Forms.TextBox();
            this.lbl_stack_before = new System.Windows.Forms.Label();
            this.btn_jump = new System.Windows.Forms.Button();
            this.lbl_stack_after = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_field)).BeginInit();
            this.ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_palette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sc_field)).BeginInit();
            this.sc_field.Panel1.SuspendLayout();
            this.sc_field.Panel2.SuspendLayout();
            this.sc_field.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_buffer)).BeginInit();
            this.sc_buffer.Panel1.SuspendLayout();
            this.sc_buffer.Panel2.SuspendLayout();
            this.sc_buffer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_field
            // 
            this.dgv_field.AllowDrop = true;
            this.dgv_field.AllowUserToAddRows = false;
            this.dgv_field.AllowUserToDeleteRows = false;
            this.dgv_field.AllowUserToResizeColumns = false;
            this.dgv_field.AllowUserToResizeRows = false;
            this.dgv_field.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_field.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_field.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_field.ColumnHeadersVisible = false;
            this.dgv_field.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_field.Location = new System.Drawing.Point(3, 3);
            this.dgv_field.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_field.Name = "dgv_field";
            this.dgv_field.ReadOnly = true;
            this.dgv_field.RowHeadersVisible = false;
            this.dgv_field.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_field.RowTemplate.Height = 21;
            this.dgv_field.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_field.Size = new System.Drawing.Size(443, 415);
            this.dgv_field.StandardTab = true;
            this.dgv_field.TabIndex = 0;
            this.dgv_field.VirtualMode = true;
            this.dgv_field.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_field_CellMouseClick);
            this.dgv_field.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_field_CellMouseDoubleClick);
            this.dgv_field.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_field_CellMouseDown);
            this.dgv_field.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_field_CellMouseMove);
            this.dgv_field.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_field_CellPainting);
            this.dgv_field.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgv_field_ColumnAdded);
            this.dgv_field.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgv_field_DragDrop);
            this.dgv_field.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgv_field_DragEnter);
            this.dgv_field.Enter += new System.EventHandler(this.dgv_field_Enter);
            this.dgv_field.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_field_KeyDown);
            this.dgv_field.Leave += new System.EventHandler(this.dgv_field_Leave);
            this.dgv_field.MouseEnter += new System.EventHandler(this.dgv_field_MouseEnter);
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.表示VToolStripMenuItem,
            this.イメージIToolStripMenuItem,
            this.デバッグDToolStripMenuItem});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(884, 24);
            this.ms.TabIndex = 1;
            this.ms.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_CreateNew,
            this.tsmi_OpenFile,
            this.toolStripSeparator1,
            this.tsmi_SaveFile,
            this.tsmi_SaveFileAs,
            this.toolStripSeparator2,
            this.tsmi_Quit});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // tsmi_CreateNew
            // 
            this.tsmi_CreateNew.Name = "tsmi_CreateNew";
            this.tsmi_CreateNew.ShortcutKeyDisplayString = "Ctrl+N";
            this.tsmi_CreateNew.Size = new System.Drawing.Size(248, 22);
            this.tsmi_CreateNew.Text = "新規作成(&N)";
            this.tsmi_CreateNew.Click += new System.EventHandler(this.tsmi_CreateNew_Click);
            // 
            // tsmi_OpenFile
            // 
            this.tsmi_OpenFile.Name = "tsmi_OpenFile";
            this.tsmi_OpenFile.ShortcutKeyDisplayString = "Ctrl+O";
            this.tsmi_OpenFile.Size = new System.Drawing.Size(248, 22);
            this.tsmi_OpenFile.Text = "開く(&O)";
            this.tsmi_OpenFile.Click += new System.EventHandler(this.tsmi_OpenFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // tsmi_SaveFile
            // 
            this.tsmi_SaveFile.Name = "tsmi_SaveFile";
            this.tsmi_SaveFile.ShortcutKeyDisplayString = "Ctrl+S";
            this.tsmi_SaveFile.Size = new System.Drawing.Size(248, 22);
            this.tsmi_SaveFile.Text = "上書き保存(&S)";
            this.tsmi_SaveFile.Click += new System.EventHandler(this.tsmi_SaveFile_Click);
            // 
            // tsmi_SaveFileAs
            // 
            this.tsmi_SaveFileAs.Name = "tsmi_SaveFileAs";
            this.tsmi_SaveFileAs.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.tsmi_SaveFileAs.Size = new System.Drawing.Size(248, 22);
            this.tsmi_SaveFileAs.Text = "名前を付けて保存(&A)";
            this.tsmi_SaveFileAs.Click += new System.EventHandler(this.tsmi_SaveFileAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(245, 6);
            // 
            // tsmi_Quit
            // 
            this.tsmi_Quit.Name = "tsmi_Quit";
            this.tsmi_Quit.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_Quit.Size = new System.Drawing.Size(248, 22);
            this.tsmi_Quit.Text = "終了(&X)";
            this.tsmi_Quit.Click += new System.EventHandler(this.tsmi_Quit_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Undo,
            this.tsmi_Redo,
            this.toolStripSeparator4,
            this.tsmi_Cut,
            this.tsmi_Copy,
            this.tsmi_Paste,
            this.toolStripSeparator3,
            this.tsmi_ChangeTool});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.編集EToolStripMenuItem.Text = "編集(&E)";
            // 
            // tsmi_Undo
            // 
            this.tsmi_Undo.Name = "tsmi_Undo";
            this.tsmi_Undo.ShortcutKeyDisplayString = "Ctrl+Z";
            this.tsmi_Undo.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Undo.Text = "元に戻す(&U)";
            this.tsmi_Undo.Click += new System.EventHandler(this.tsmi_Undo_Click);
            // 
            // tsmi_Redo
            // 
            this.tsmi_Redo.Name = "tsmi_Redo";
            this.tsmi_Redo.ShortcutKeyDisplayString = "Ctrl+Y";
            this.tsmi_Redo.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Redo.Text = "やり直す(&R)";
            this.tsmi_Redo.Click += new System.EventHandler(this.tsmi_Redo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // tsmi_Cut
            // 
            this.tsmi_Cut.Name = "tsmi_Cut";
            this.tsmi_Cut.ShortcutKeyDisplayString = "Ctrl+X";
            this.tsmi_Cut.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Cut.Text = "切り取り(&X)";
            this.tsmi_Cut.Click += new System.EventHandler(this.tsmi_Cut_Click);
            // 
            // tsmi_Copy
            // 
            this.tsmi_Copy.Name = "tsmi_Copy";
            this.tsmi_Copy.ShortcutKeyDisplayString = "Ctrl+C";
            this.tsmi_Copy.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Copy.Text = "コピー(&C)";
            this.tsmi_Copy.Click += new System.EventHandler(this.tsmi_Copy_Click);
            // 
            // tsmi_Paste
            // 
            this.tsmi_Paste.Name = "tsmi_Paste";
            this.tsmi_Paste.ShortcutKeyDisplayString = "Ctrl+V";
            this.tsmi_Paste.Size = new System.Drawing.Size(173, 22);
            this.tsmi_Paste.Text = "貼り付け(&V)";
            this.tsmi_Paste.Click += new System.EventHandler(this.tsmi_Paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // tsmi_ChangeTool
            // 
            this.tsmi_ChangeTool.Name = "tsmi_ChangeTool";
            this.tsmi_ChangeTool.ShortcutKeyDisplayString = "T | C";
            this.tsmi_ChangeTool.Size = new System.Drawing.Size(173, 22);
            this.tsmi_ChangeTool.Text = "ツール変更(&T)";
            this.tsmi_ChangeTool.Click += new System.EventHandler(this.tsmi_ChangeTool_Click);
            // 
            // 表示VToolStripMenuItem
            // 
            this.表示VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ZoomIn,
            this.tsmi_ZoomOut});
            this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
            this.表示VToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.表示VToolStripMenuItem.Text = "表示(&V)";
            // 
            // tsmi_ZoomIn
            // 
            this.tsmi_ZoomIn.Name = "tsmi_ZoomIn";
            this.tsmi_ZoomIn.ShortcutKeyDisplayString = "Ctrl+＋";
            this.tsmi_ZoomIn.Size = new System.Drawing.Size(188, 22);
            this.tsmi_ZoomIn.Text = "ズームイン(&I)";
            this.tsmi_ZoomIn.Click += new System.EventHandler(this.tsmi_ZoomIn_Click);
            // 
            // tsmi_ZoomOut
            // 
            this.tsmi_ZoomOut.Name = "tsmi_ZoomOut";
            this.tsmi_ZoomOut.ShortcutKeyDisplayString = "Ctrl+－";
            this.tsmi_ZoomOut.Size = new System.Drawing.Size(188, 22);
            this.tsmi_ZoomOut.Text = "ズームアウト(&O)";
            this.tsmi_ZoomOut.Click += new System.EventHandler(this.tsmi_ZoomOut_Click);
            // 
            // イメージIToolStripMenuItem
            // 
            this.イメージIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ChangeCanvasSize});
            this.イメージIToolStripMenuItem.Name = "イメージIToolStripMenuItem";
            this.イメージIToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.イメージIToolStripMenuItem.Text = "イメージ(&I)";
            // 
            // tsmi_ChangeCanvasSize
            // 
            this.tsmi_ChangeCanvasSize.Name = "tsmi_ChangeCanvasSize";
            this.tsmi_ChangeCanvasSize.ShortcutKeyDisplayString = "Ctrl+R";
            this.tsmi_ChangeCanvasSize.Size = new System.Drawing.Size(226, 22);
            this.tsmi_ChangeCanvasSize.Text = "キャンバスサイズ変更(&R)";
            this.tsmi_ChangeCanvasSize.Click += new System.EventHandler(this.tsmi_ChangeCanvasSize_Click);
            // 
            // デバッグDToolStripMenuItem
            // 
            this.デバッグDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_StartDebug,
            this.tsmi_JumpDebug,
            this.tsmi_StepDebug,
            this.tsmi_ResetDebug});
            this.デバッグDToolStripMenuItem.Name = "デバッグDToolStripMenuItem";
            this.デバッグDToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.デバッグDToolStripMenuItem.Text = "デバッグ(&D)";
            // 
            // tsmi_StartDebug
            // 
            this.tsmi_StartDebug.Name = "tsmi_StartDebug";
            this.tsmi_StartDebug.ShortcutKeyDisplayString = "F5";
            this.tsmi_StartDebug.Size = new System.Drawing.Size(175, 22);
            this.tsmi_StartDebug.Text = "デバッグ開始(&D)";
            this.tsmi_StartDebug.Click += new System.EventHandler(this.tsmi_StartDebug_Click);
            // 
            // tsmi_JumpDebug
            // 
            this.tsmi_JumpDebug.Name = "tsmi_JumpDebug";
            this.tsmi_JumpDebug.ShortcutKeyDisplayString = "F10";
            this.tsmi_JumpDebug.Size = new System.Drawing.Size(175, 22);
            this.tsmi_JumpDebug.Text = "ジャンプ実行(&J)";
            this.tsmi_JumpDebug.Click += new System.EventHandler(this.tsmi_JumpDebug_Click);
            // 
            // tsmi_StepDebug
            // 
            this.tsmi_StepDebug.Name = "tsmi_StepDebug";
            this.tsmi_StepDebug.ShortcutKeyDisplayString = "F11";
            this.tsmi_StepDebug.Size = new System.Drawing.Size(175, 22);
            this.tsmi_StepDebug.Text = "ステップ実行(&S)";
            this.tsmi_StepDebug.Click += new System.EventHandler(this.tsmi_StepDebug_Click);
            // 
            // tsmi_ResetDebug
            // 
            this.tsmi_ResetDebug.Name = "tsmi_ResetDebug";
            this.tsmi_ResetDebug.ShortcutKeyDisplayString = "ESC";
            this.tsmi_ResetDebug.Size = new System.Drawing.Size(175, 22);
            this.tsmi_ResetDebug.Text = "デバッグ中止(&R)";
            this.tsmi_ResetDebug.Click += new System.EventHandler(this.tsmi_ResetDebug_Click);
            // 
            // dgv_palette
            // 
            this.dgv_palette.AllowUserToAddRows = false;
            this.dgv_palette.AllowUserToDeleteRows = false;
            this.dgv_palette.AllowUserToResizeColumns = false;
            this.dgv_palette.AllowUserToResizeRows = false;
            this.dgv_palette.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_palette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_palette.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_palette.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_palette.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_palette.Location = new System.Drawing.Point(12, 29);
            this.dgv_palette.MultiSelect = false;
            this.dgv_palette.Name = "dgv_palette";
            this.dgv_palette.ReadOnly = true;
            this.dgv_palette.RowHeadersVisible = false;
            this.dgv_palette.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_palette.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_palette.Size = new System.Drawing.Size(153, 353);
            this.dgv_palette.StandardTab = true;
            this.dgv_palette.TabIndex = 0;
            this.dgv_palette.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_palette_CellMouseClick);
            this.dgv_palette.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_palette_CellMouseDoubleClick);
            this.dgv_palette.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_palette_CellPainting);
            // 
            // sc_field
            // 
            this.sc_field.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sc_field.Location = new System.Drawing.Point(423, 29);
            this.sc_field.Name = "sc_field";
            this.sc_field.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_field.Panel1
            // 
            this.sc_field.Panel1.Controls.Add(this.dgv_field);
            // 
            // sc_field.Panel2
            // 
            this.sc_field.Panel2.Controls.Add(this.sc_buffer);
            this.sc_field.Size = new System.Drawing.Size(449, 604);
            this.sc_field.SplitterDistance = 420;
            this.sc_field.TabIndex = 10;
            // 
            // sc_buffer
            // 
            this.sc_buffer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sc_buffer.Location = new System.Drawing.Point(3, 3);
            this.sc_buffer.Name = "sc_buffer";
            // 
            // sc_buffer.Panel1
            // 
            this.sc_buffer.Panel1.Controls.Add(this.tb_input);
            // 
            // sc_buffer.Panel2
            // 
            this.sc_buffer.Panel2.Controls.Add(this.tb_output);
            this.sc_buffer.Size = new System.Drawing.Size(443, 173);
            this.sc_buffer.SplitterDistance = 189;
            this.sc_buffer.TabIndex = 0;
            // 
            // tb_input
            // 
            this.tb_input.AcceptsReturn = true;
            this.tb_input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_input.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_input.Location = new System.Drawing.Point(3, 3);
            this.tb_input.Multiline = true;
            this.tb_input.Name = "tb_input";
            this.tb_input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_input.Size = new System.Drawing.Size(183, 165);
            this.tb_input.TabIndex = 0;
            this.tb_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_input_KeyDown);
            // 
            // tb_output
            // 
            this.tb_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_output.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_output.Location = new System.Drawing.Point(3, 3);
            this.tb_output.Multiline = true;
            this.tb_output.Name = "tb_output";
            this.tb_output.ReadOnly = true;
            this.tb_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_output.Size = new System.Drawing.Size(244, 165);
            this.tb_output.TabIndex = 0;
            this.tb_output.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_output_KeyDown);
            // 
            // tb_stack
            // 
            this.tb_stack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_stack.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_stack.Location = new System.Drawing.Point(297, 50);
            this.tb_stack.Multiline = true;
            this.tb_stack.Name = "tb_stack";
            this.tb_stack.ReadOnly = true;
            this.tb_stack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_stack.Size = new System.Drawing.Size(120, 583);
            this.tb_stack.TabIndex = 9;
            this.tb_stack.WordWrap = false;
            this.tb_stack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_stack_KeyDown);
            // 
            // btn_debug
            // 
            this.btn_debug.Location = new System.Drawing.Point(12, 388);
            this.btn_debug.Name = "btn_debug";
            this.btn_debug.Size = new System.Drawing.Size(46, 23);
            this.btn_debug.TabIndex = 1;
            this.btn_debug.Text = "Debug";
            this.btn_debug.UseVisualStyleBackColor = true;
            this.btn_debug.Click += new System.EventHandler(this.btn_debug_Click);
            // 
            // btn_step
            // 
            this.btn_step.Location = new System.Drawing.Point(120, 388);
            this.btn_step.Name = "btn_step";
            this.btn_step.Size = new System.Drawing.Size(45, 23);
            this.btn_step.TabIndex = 3;
            this.btn_step.Text = "Step";
            this.btn_step.UseVisualStyleBackColor = true;
            this.btn_step.Click += new System.EventHandler(this.btn_step_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_status.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_status.Location = new System.Drawing.Point(12, 443);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(153, 190);
            this.lbl_status.TabIndex = 6;
            this.lbl_status.Text = "[Status]\r\nediting...";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(12, 417);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 4;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // tm_pen
            // 
            this.tm_pen.Interval = 10;
            this.tm_pen.Tick += new System.EventHandler(this.tm_pen_Tick);
            // 
            // btn_change
            // 
            this.btn_change.Location = new System.Drawing.Point(90, 417);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(75, 23);
            this.btn_change.TabIndex = 5;
            this.btn_change.Text = "ChangeTool";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            // 
            // tm_status
            // 
            this.tm_status.Tick += new System.EventHandler(this.tm_status_Tick);
            // 
            // tb_stackbefore
            // 
            this.tb_stackbefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_stackbefore.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tb_stackbefore.Location = new System.Drawing.Point(171, 50);
            this.tb_stackbefore.Multiline = true;
            this.tb_stackbefore.Name = "tb_stackbefore";
            this.tb_stackbefore.ReadOnly = true;
            this.tb_stackbefore.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_stackbefore.Size = new System.Drawing.Size(120, 583);
            this.tb_stackbefore.TabIndex = 8;
            this.tb_stackbefore.WordWrap = false;
            this.tb_stackbefore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_stackbefore_KeyDown);
            // 
            // lbl_stack_before
            // 
            this.lbl_stack_before.AutoSize = true;
            this.lbl_stack_before.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_stack_before.Location = new System.Drawing.Point(171, 32);
            this.lbl_stack_before.Name = "lbl_stack_before";
            this.lbl_stack_before.Size = new System.Drawing.Size(55, 15);
            this.lbl_stack_before.TabIndex = 7;
            this.lbl_stack_before.Text = "[Before]";
            // 
            // btn_jump
            // 
            this.btn_jump.Location = new System.Drawing.Point(64, 388);
            this.btn_jump.Name = "btn_jump";
            this.btn_jump.Size = new System.Drawing.Size(50, 23);
            this.btn_jump.TabIndex = 2;
            this.btn_jump.Text = "Jump";
            this.btn_jump.UseVisualStyleBackColor = true;
            this.btn_jump.Click += new System.EventHandler(this.btn_jump_Click);
            // 
            // lbl_stack_after
            // 
            this.lbl_stack_after.AutoSize = true;
            this.lbl_stack_after.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_stack_after.Location = new System.Drawing.Point(294, 32);
            this.lbl_stack_after.Name = "lbl_stack_after";
            this.lbl_stack_after.Size = new System.Drawing.Size(46, 15);
            this.lbl_stack_after.TabIndex = 11;
            this.lbl_stack_after.Text = "[After]";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 642);
            this.Controls.Add(this.lbl_stack_after);
            this.Controls.Add(this.btn_jump);
            this.Controls.Add(this.lbl_stack_before);
            this.Controls.Add(this.tb_stackbefore);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.btn_step);
            this.Controls.Add(this.btn_debug);
            this.Controls.Add(this.tb_stack);
            this.Controls.Add(this.dgv_palette);
            this.Controls.Add(this.sc_field);
            this.Controls.Add(this.ms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.ms;
            this.MinimumSize = new System.Drawing.Size(500, 680);
            this.Name = "main";
            this.Text = "Pidet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_field)).EndInit();
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_palette)).EndInit();
            this.sc_field.Panel1.ResumeLayout(false);
            this.sc_field.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sc_field)).EndInit();
            this.sc_field.ResumeLayout(false);
            this.sc_buffer.Panel1.ResumeLayout(false);
            this.sc_buffer.Panel1.PerformLayout();
            this.sc_buffer.Panel2.ResumeLayout(false);
            this.sc_buffer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sc_buffer)).EndInit();
            this.sc_buffer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_field;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CreateNew;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveFileAs;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Quit;
        private System.Windows.Forms.DataGridView dgv_palette;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Undo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Redo;
        private System.Windows.Forms.ToolStripMenuItem 表示VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ZoomOut;
        private System.Windows.Forms.ToolStripMenuItem イメージIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ChangeCanvasSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer sc_field;
        private System.Windows.Forms.SplitContainer sc_buffer;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.TextBox tb_output;
        private System.Windows.Forms.TextBox tb_stack;
        private System.Windows.Forms.Button btn_debug;
        private System.Windows.Forms.Button btn_step;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Timer tm_pen;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.ToolStripMenuItem デバッグDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_StartDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmi_StepDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ResetDebug;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ChangeTool;
        private System.Windows.Forms.Timer tm_status;
        private System.Windows.Forms.TextBox tb_stackbefore;
        private System.Windows.Forms.Label lbl_stack_before;
        private System.Windows.Forms.ToolStripMenuItem tsmi_JumpDebug;
        private System.Windows.Forms.Button btn_jump;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Cut;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Paste;
        private System.Windows.Forms.Label lbl_stack_after;
    }
}

