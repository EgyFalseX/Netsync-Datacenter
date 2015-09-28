namespace DataCenter.Forms.Data
{
    partial class SearchItemFrm
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlFiles = new DevExpress.XtraGrid.GridControl();
            this.LSMSData = new DevExpress.Data.Linq.LinqServerModeSource();
            this.gridViewFiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTypeIconData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.colCreateIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEditDMY = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifyIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserInName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocker = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCanInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCanWrite = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCanDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManagerMain = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip();
            this.viewCatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSMSData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDMY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDMY.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).BeginInit();
            this.contextMenuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlFiles);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 20);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 371);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlFiles
            // 
            this.gridControlFiles.AllowDrop = true;
            this.gridControlFiles.ContextMenuStrip = this.contextMenuStripFile;
            this.gridControlFiles.DataSource = this.LSMSData;
            this.gridControlFiles.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridControlFiles.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControlFiles.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControlFiles.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControlFiles.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridControlFiles.Location = new System.Drawing.Point(12, 12);
            this.gridControlFiles.MainView = this.gridViewFiles;
            this.gridControlFiles.Name = "gridControlFiles";
            this.gridControlFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemDateEditDMY,
            this.repositoryItemPictureEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControlFiles.Size = new System.Drawing.Size(860, 347);
            this.gridControlFiles.TabIndex = 4;
            this.gridControlFiles.UseEmbeddedNavigator = true;
            this.gridControlFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFiles});
            // 
            // LSMSData
            // 
            this.LSMSData.ElementType = typeof(DataCenter.DataSources.Linq.GetUserItemResult);
            this.LSMSData.KeyExpression = "ItemId";
            // 
            // gridViewFiles
            // 
            this.gridViewFiles.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridViewFiles.Appearance.FooterPanel.Options.UseFont = true;
            this.gridViewFiles.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewFiles.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewFiles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridViewFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTypeIconData,
            this.colItemName,
            this.colInfo,
            this.colCreateIn,
            this.colOwnerName,
            this.colModifyIn,
            this.colUserInName,
            this.colLocker,
            this.colCategoryName,
            this.colTypeName,
            this.colCanInsert,
            this.colCanWrite,
            this.colCanDelete});
            this.gridViewFiles.GridControl = this.gridControlFiles;
            this.gridViewFiles.Name = "gridViewFiles";
            this.gridViewFiles.OptionsBehavior.Editable = false;
            this.gridViewFiles.OptionsCustomization.AllowRowSizing = true;
            this.gridViewFiles.OptionsView.ColumnAutoWidth = false;
            this.gridViewFiles.OptionsView.ShowAutoFilterRow = true;
            this.gridViewFiles.OptionsView.ShowDetailButtons = false;
            this.gridViewFiles.OptionsView.ShowFooter = true;
            this.gridViewFiles.OptionsView.ShowGroupPanel = false;
            this.gridViewFiles.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFiles.OptionsView.ShowIndicator = false;
            this.gridViewFiles.OptionsView.ShowPreview = true;
            this.gridViewFiles.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewFiles.RowHeight = 30;
            // 
            // colTypeIconData
            // 
            this.colTypeIconData.AppearanceCell.Options.UseTextOptions = true;
            this.colTypeIconData.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeIconData.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeIconData.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeIconData.Caption = ".";
            this.colTypeIconData.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colTypeIconData.Name = "colTypeIconData";
            this.colTypeIconData.Visible = true;
            this.colTypeIconData.VisibleIndex = 0;
            this.colTypeIconData.Width = 24;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = " ";
            // 
            // colItemName
            // 
            this.colItemName.AppearanceCell.Options.UseTextOptions = true;
            this.colItemName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemName.Caption = "اسم الملف";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 1;
            this.colItemName.Width = 166;
            // 
            // colInfo
            // 
            this.colInfo.AppearanceCell.Options.UseTextOptions = true;
            this.colInfo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInfo.AppearanceHeader.Options.UseTextOptions = true;
            this.colInfo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInfo.Caption = "معلومات";
            this.colInfo.ColumnEdit = this.repositoryItemMemoExEdit1;
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 4;
            this.colInfo.Width = 64;
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // colCreateIn
            // 
            this.colCreateIn.AppearanceCell.Options.UseTextOptions = true;
            this.colCreateIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateIn.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreateIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateIn.Caption = "تاريخ الانشاء";
            this.colCreateIn.ColumnEdit = this.repositoryItemDateEditDMY;
            this.colCreateIn.FieldName = "CreateIn";
            this.colCreateIn.Name = "colCreateIn";
            this.colCreateIn.Visible = true;
            this.colCreateIn.VisibleIndex = 5;
            this.colCreateIn.Width = 77;
            // 
            // repositoryItemDateEditDMY
            // 
            this.repositoryItemDateEditDMY.AutoHeight = false;
            this.repositoryItemDateEditDMY.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEditDMY.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEditDMY.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEditDMY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEditDMY.EditFormat.FormatString = "dd/MM/yyyy";
            this.repositoryItemDateEditDMY.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEditDMY.Mask.EditMask = "dd/MM/yyyy";
            this.repositoryItemDateEditDMY.Name = "repositoryItemDateEditDMY";
            // 
            // colOwnerName
            // 
            this.colOwnerName.AppearanceCell.Options.UseTextOptions = true;
            this.colOwnerName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOwnerName.Caption = "مسئول الانشاء";
            this.colOwnerName.FieldName = "OwnerName";
            this.colOwnerName.Name = "colOwnerName";
            this.colOwnerName.Visible = true;
            this.colOwnerName.VisibleIndex = 6;
            this.colOwnerName.Width = 105;
            // 
            // colModifyIn
            // 
            this.colModifyIn.AppearanceCell.Options.UseTextOptions = true;
            this.colModifyIn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifyIn.AppearanceHeader.Options.UseTextOptions = true;
            this.colModifyIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModifyIn.Caption = "تاريخ اخر تعديل";
            this.colModifyIn.ColumnEdit = this.repositoryItemDateEditDMY;
            this.colModifyIn.FieldName = "ModifyIn";
            this.colModifyIn.Name = "colModifyIn";
            this.colModifyIn.Visible = true;
            this.colModifyIn.VisibleIndex = 7;
            this.colModifyIn.Width = 87;
            // 
            // colUserInName
            // 
            this.colUserInName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserInName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserInName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserInName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserInName.Caption = "مسئول اخر تعديل";
            this.colUserInName.FieldName = "UserInName";
            this.colUserInName.Name = "colUserInName";
            this.colUserInName.Visible = true;
            this.colUserInName.VisibleIndex = 8;
            this.colUserInName.Width = 100;
            // 
            // colLocker
            // 
            this.colLocker.AppearanceCell.Options.UseTextOptions = true;
            this.colLocker.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocker.AppearanceHeader.Options.UseTextOptions = true;
            this.colLocker.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLocker.Caption = "مغلق";
            this.colLocker.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colLocker.FieldName = "Locker";
            this.colLocker.Name = "colLocker";
            this.colLocker.Visible = true;
            this.colLocker.VisibleIndex = 9;
            this.colLocker.Width = 45;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colCategoryName
            // 
            this.colCategoryName.AppearanceCell.Options.UseTextOptions = true;
            this.colCategoryName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCategoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCategoryName.Caption = "المجلد";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 3;
            this.colCategoryName.Width = 96;
            // 
            // colTypeName
            // 
            this.colTypeName.AppearanceCell.Options.UseTextOptions = true;
            this.colTypeName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeName.Caption = "نوع الملف";
            this.colTypeName.FieldName = "TypeName";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.Visible = true;
            this.colTypeName.VisibleIndex = 2;
            this.colTypeName.Width = 108;
            // 
            // colCanInsert
            // 
            this.colCanInsert.Caption = "سماحية الاضافة";
            this.colCanInsert.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCanInsert.FieldName = "CanInsert";
            this.colCanInsert.Name = "colCanInsert";
            this.colCanInsert.Visible = true;
            this.colCanInsert.VisibleIndex = 10;
            this.colCanInsert.Width = 93;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // colCanWrite
            // 
            this.colCanWrite.AppearanceCell.Options.UseTextOptions = true;
            this.colCanWrite.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCanWrite.AppearanceHeader.Options.UseTextOptions = true;
            this.colCanWrite.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCanWrite.Caption = "سماحية التعديل";
            this.colCanWrite.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCanWrite.FieldName = "CanWrite";
            this.colCanWrite.Name = "colCanWrite";
            this.colCanWrite.Visible = true;
            this.colCanWrite.VisibleIndex = 11;
            this.colCanWrite.Width = 93;
            // 
            // colCanDelete
            // 
            this.colCanDelete.AppearanceCell.Options.UseTextOptions = true;
            this.colCanDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCanDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colCanDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCanDelete.Caption = "سماحية الحذف";
            this.colCanDelete.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCanDelete.FieldName = "CanDelete";
            this.colCanDelete.Name = "colCanDelete";
            this.colCanDelete.Visible = true;
            this.colCanDelete.VisibleIndex = 12;
            this.colCanDelete.Width = 89;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 371);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlFiles;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(864, 351);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // barManagerMain
            // 
            this.barManagerMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManagerMain.DockControls.Add(this.barDockControlTop);
            this.barManagerMain.DockControls.Add(this.barDockControlBottom);
            this.barManagerMain.DockControls.Add(this.barDockControlLeft);
            this.barManagerMain.DockControls.Add(this.barDockControlRight);
            this.barManagerMain.Form = this;
            this.barManagerMain.MainMenu = this.bar2;
            this.barManagerMain.MaxItemId = 0;
            this.barManagerMain.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(884, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 391);
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 371);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 20);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 371);
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCatToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFolder";
            this.contextMenuStripFile.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStripFile.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripFile_Opening);
            // 
            // viewCatToolStripMenuItem
            // 
            this.viewCatToolStripMenuItem.Image = global::DataCenter.Properties.Resources.view;
            this.viewCatToolStripMenuItem.Name = "viewCatToolStripMenuItem";
            this.viewCatToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewCatToolStripMenuItem.Text = "عرض المجلد";
            this.viewCatToolStripMenuItem.Click += new System.EventHandler(this.viewCatToolStripMenuItem_Click);
            // 
            // SearchItemFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 414);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SearchItemFrm";
            this.Text = "بحث";
            this.Load += new System.EventHandler(this.SearchItemFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSMSData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDMY.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEditDMY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMain)).EndInit();
            this.contextMenuStripFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControlFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFiles;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeIconData;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditDMY;
        private DevExpress.XtraGrid.Columns.GridColumn colOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn colModifyIn;
        private DevExpress.XtraGrid.Columns.GridColumn colUserInName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocker;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCanInsert;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCanWrite;
        private DevExpress.XtraGrid.Columns.GridColumn colCanDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarManager barManagerMain;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Data.Linq.LinqServerModeSource LSMSData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem viewCatToolStripMenuItem;
    }
}