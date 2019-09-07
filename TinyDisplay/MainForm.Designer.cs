namespace TinyDisplay
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lv_plugins = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btn_device_open = new System.Windows.Forms.Button();
            this.cb_device = new System.Windows.Forms.ComboBox();
            this.tbc_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_fps = new System.Windows.Forms.Label();
            this.pb_preview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_plugin_url = new System.Windows.Forms.Button();
            this.lb_plugin_enabled = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_plugin_setting = new System.Windows.Forms.Button();
            this.tb_plugin_desc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lb_plugin_path = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_plugin_version = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_plugin_author = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_plugin_name = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_plugin_down = new System.Windows.Forms.Button();
            this.btn_plugin_up = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_plugin_add = new System.Windows.Forms.Button();
            this.btn_plugin_remove = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_setting_brightness_preview = new System.Windows.Forms.CheckBox();
            this.btn_setting_backcolor = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_brightness = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbr_setting_brightness = new System.Windows.Forms.TrackBar();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbc_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbr_setting_brightness)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_plugins
            // 
            this.lv_plugins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lv_plugins.AutoArrange = false;
            this.lv_plugins.CheckBoxes = true;
            this.lv_plugins.FullRowSelect = true;
            this.lv_plugins.GridLines = true;
            this.lv_plugins.HideSelection = false;
            this.lv_plugins.LabelWrap = false;
            this.lv_plugins.LargeImageList = this.imageList1;
            this.lv_plugins.Location = new System.Drawing.Point(6, 18);
            this.lv_plugins.MultiSelect = false;
            this.lv_plugins.Name = "lv_plugins";
            this.lv_plugins.ShowGroups = false;
            this.lv_plugins.Size = new System.Drawing.Size(136, 286);
            this.lv_plugins.SmallImageList = this.imageList1;
            this.lv_plugins.TabIndex = 1;
            this.lv_plugins.UseCompatibleStateImageBehavior = false;
            this.lv_plugins.View = System.Windows.Forms.View.List;
            this.lv_plugins.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lv_plugins_ItemChecked);
            this.lv_plugins.SelectedIndexChanged += new System.EventHandler(this.lv_plugins_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add_thin_10x_16x");
            this.imageList1.Images.SetKeyName(1, "DownloadFile_16x");
            this.imageList1.Images.SetKeyName(2, "GlyphDown_16x");
            this.imageList1.Images.SetKeyName(3, "GlyphUp_16x");
            this.imageList1.Images.SetKeyName(4, "Module_16x");
            this.imageList1.Images.SetKeyName(5, "Remove_thin_10x_16x");
            this.imageList1.Images.SetKeyName(6, "Save_16x");
            this.imageList1.Images.SetKeyName(7, "TransparentMask_16x");
            this.imageList1.Images.SetKeyName(8, "Upload_16x");
            this.imageList1.Images.SetKeyName(9, "ModuleError_16x");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "设备列表:";
            // 
            // btn_device_open
            // 
            this.btn_device_open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_device_open.Location = new System.Drawing.Point(391, 4);
            this.btn_device_open.Name = "btn_device_open";
            this.btn_device_open.Size = new System.Drawing.Size(75, 23);
            this.btn_device_open.TabIndex = 9;
            this.btn_device_open.Text = "打开设备";
            this.btn_device_open.UseVisualStyleBackColor = true;
            this.btn_device_open.Click += new System.EventHandler(this.btn_device_open_Click);
            // 
            // cb_device
            // 
            this.cb_device.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_device.FormattingEnabled = true;
            this.cb_device.Location = new System.Drawing.Point(77, 6);
            this.cb_device.Name = "cb_device";
            this.cb_device.Size = new System.Drawing.Size(307, 20);
            this.cb_device.TabIndex = 8;
            // 
            // tbc_control
            // 
            this.tbc_control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_control.Controls.Add(this.tabPage1);
            this.tbc_control.Controls.Add(this.tabPage2);
            this.tbc_control.Location = new System.Drawing.Point(12, 32);
            this.tbc_control.Name = "tbc_control";
            this.tbc_control.SelectedIndex = 0;
            this.tbc_control.Size = new System.Drawing.Size(453, 366);
            this.tbc_control.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.btn_plugin_down);
            this.tabPage1.Controls.Add(this.btn_plugin_up);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_plugin_add);
            this.tabPage1.Controls.Add(this.btn_plugin_remove);
            this.tabPage1.Controls.Add(this.lv_plugins);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(445, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "插件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(148, 6);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(172, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(291, 298);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lb_fps);
            this.groupBox2.Controls.Add(this.pb_preview);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.MinimumSize = new System.Drawing.Size(172, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 126);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时预览";
            // 
            // lb_fps
            // 
            this.lb_fps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_fps.AutoSize = true;
            this.lb_fps.Location = new System.Drawing.Point(61, 15);
            this.lb_fps.Name = "lb_fps";
            this.lb_fps.Size = new System.Drawing.Size(35, 12);
            this.lb_fps.TabIndex = 7;
            this.lb_fps.Text = "0 FPS";
            // 
            // pb_preview
            // 
            this.pb_preview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_preview.BackgroundImage = global::TinyDisplay.Properties.Resources.TransparentMask_16x;
            this.pb_preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_preview.Location = new System.Drawing.Point(63, 30);
            this.pb_preview.Name = "pb_preview";
            this.pb_preview.Size = new System.Drawing.Size(160, 80);
            this.pb_preview.TabIndex = 6;
            this.pb_preview.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_plugin_url);
            this.groupBox1.Controls.Add(this.lb_plugin_enabled);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_plugin_setting);
            this.groupBox1.Controls.Add(this.tb_plugin_desc);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lb_plugin_path);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lb_plugin_version);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lb_plugin_author);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lb_plugin_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(3, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 160);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "插件信息";
            // 
            // btn_plugin_url
            // 
            this.btn_plugin_url.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_plugin_url.Image = global::TinyDisplay.Properties.Resources.Home_16x;
            this.btn_plugin_url.Location = new System.Drawing.Point(227, 20);
            this.btn_plugin_url.Name = "btn_plugin_url";
            this.btn_plugin_url.Size = new System.Drawing.Size(23, 23);
            this.btn_plugin_url.TabIndex = 15;
            this.btn_plugin_url.UseVisualStyleBackColor = true;
            this.btn_plugin_url.Click += new System.EventHandler(this.Btn_plugin_url_Click);
            // 
            // lb_plugin_enabled
            // 
            this.lb_plugin_enabled.AutoSize = true;
            this.lb_plugin_enabled.Location = new System.Drawing.Point(59, 17);
            this.lb_plugin_enabled.Name = "lb_plugin_enabled";
            this.lb_plugin_enabled.Size = new System.Drawing.Size(17, 12);
            this.lb_plugin_enabled.TabIndex = 12;
            this.lb_plugin_enabled.Text = "否";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "已启用:";
            // 
            // btn_plugin_setting
            // 
            this.btn_plugin_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_plugin_setting.Image = global::TinyDisplay.Properties.Resources.Settings_16x;
            this.btn_plugin_setting.Location = new System.Drawing.Point(256, 20);
            this.btn_plugin_setting.Name = "btn_plugin_setting";
            this.btn_plugin_setting.Size = new System.Drawing.Size(23, 23);
            this.btn_plugin_setting.TabIndex = 10;
            this.btn_plugin_setting.UseVisualStyleBackColor = true;
            this.btn_plugin_setting.Click += new System.EventHandler(this.Btn_plugin_setting_Click);
            // 
            // tb_plugin_desc
            // 
            this.tb_plugin_desc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_plugin_desc.Location = new System.Drawing.Point(8, 92);
            this.tb_plugin_desc.Multiline = true;
            this.tb_plugin_desc.Name = "tb_plugin_desc";
            this.tb_plugin_desc.Size = new System.Drawing.Size(271, 63);
            this.tb_plugin_desc.TabIndex = 9;
            this.tb_plugin_desc.Text = "none";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "描述:";
            // 
            // lb_plugin_path
            // 
            this.lb_plugin_path.AutoSize = true;
            this.lb_plugin_path.Location = new System.Drawing.Point(59, 65);
            this.lb_plugin_path.Name = "lb_plugin_path";
            this.lb_plugin_path.Size = new System.Drawing.Size(29, 12);
            this.lb_plugin_path.TabIndex = 7;
            this.lb_plugin_path.Text = "none";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "路径:";
            // 
            // lb_plugin_version
            // 
            this.lb_plugin_version.AutoSize = true;
            this.lb_plugin_version.Location = new System.Drawing.Point(59, 53);
            this.lb_plugin_version.Name = "lb_plugin_version";
            this.lb_plugin_version.Size = new System.Drawing.Size(47, 12);
            this.lb_plugin_version.TabIndex = 5;
            this.lb_plugin_version.Text = "0.0.0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "版本:";
            // 
            // lb_plugin_author
            // 
            this.lb_plugin_author.AutoSize = true;
            this.lb_plugin_author.Location = new System.Drawing.Point(59, 41);
            this.lb_plugin_author.Name = "lb_plugin_author";
            this.lb_plugin_author.Size = new System.Drawing.Size(29, 12);
            this.lb_plugin_author.TabIndex = 3;
            this.lb_plugin_author.Text = "none";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "作者:";
            // 
            // lb_plugin_name
            // 
            this.lb_plugin_name.AutoSize = true;
            this.lb_plugin_name.Location = new System.Drawing.Point(59, 29);
            this.lb_plugin_name.Name = "lb_plugin_name";
            this.lb_plugin_name.Size = new System.Drawing.Size(29, 12);
            this.lb_plugin_name.TabIndex = 1;
            this.lb_plugin_name.Text = "none";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "插件名:";
            // 
            // btn_plugin_down
            // 
            this.btn_plugin_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_plugin_down.Image = global::TinyDisplay.Properties.Resources.GlyphDown_16x;
            this.btn_plugin_down.Location = new System.Drawing.Point(118, 310);
            this.btn_plugin_down.Name = "btn_plugin_down";
            this.btn_plugin_down.Size = new System.Drawing.Size(24, 24);
            this.btn_plugin_down.TabIndex = 9;
            this.btn_plugin_down.UseVisualStyleBackColor = true;
            this.btn_plugin_down.Click += new System.EventHandler(this.Btn_plugin_down_Click);
            // 
            // btn_plugin_up
            // 
            this.btn_plugin_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_plugin_up.Image = global::TinyDisplay.Properties.Resources.GlyphUp_16x;
            this.btn_plugin_up.Location = new System.Drawing.Point(88, 310);
            this.btn_plugin_up.Name = "btn_plugin_up";
            this.btn_plugin_up.Size = new System.Drawing.Size(24, 24);
            this.btn_plugin_up.TabIndex = 8;
            this.btn_plugin_up.UseVisualStyleBackColor = true;
            this.btn_plugin_up.Click += new System.EventHandler(this.Btn_plugin_up_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "插件列表(勾选启用)";
            // 
            // btn_plugin_add
            // 
            this.btn_plugin_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_plugin_add.Image = global::TinyDisplay.Properties.Resources.Add_thin_10x_16x;
            this.btn_plugin_add.Location = new System.Drawing.Point(6, 310);
            this.btn_plugin_add.Name = "btn_plugin_add";
            this.btn_plugin_add.Size = new System.Drawing.Size(24, 24);
            this.btn_plugin_add.TabIndex = 3;
            this.btn_plugin_add.UseVisualStyleBackColor = true;
            this.btn_plugin_add.Click += new System.EventHandler(this.btn_addPlugin_Click);
            // 
            // btn_plugin_remove
            // 
            this.btn_plugin_remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_plugin_remove.Image = global::TinyDisplay.Properties.Resources.Remove_thin_10x_16x;
            this.btn_plugin_remove.Location = new System.Drawing.Point(36, 310);
            this.btn_plugin_remove.Name = "btn_plugin_remove";
            this.btn_plugin_remove.Size = new System.Drawing.Size(24, 24);
            this.btn_plugin_remove.TabIndex = 4;
            this.btn_plugin_remove.UseVisualStyleBackColor = true;
            this.btn_plugin_remove.Click += new System.EventHandler(this.btn_plugin_remove_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cb_setting_brightness_preview);
            this.tabPage2.Controls.Add(this.btn_setting_backcolor);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lv_brightness);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbr_setting_brightness);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(432, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "固件设定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cb_setting_brightness_preview
            // 
            this.cb_setting_brightness_preview.AutoSize = true;
            this.cb_setting_brightness_preview.Checked = true;
            this.cb_setting_brightness_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_setting_brightness_preview.Location = new System.Drawing.Point(214, 41);
            this.cb_setting_brightness_preview.Name = "cb_setting_brightness_preview";
            this.cb_setting_brightness_preview.Size = new System.Drawing.Size(72, 16);
            this.cb_setting_brightness_preview.TabIndex = 8;
            this.cb_setting_brightness_preview.Text = "实时预览";
            this.cb_setting_brightness_preview.UseVisualStyleBackColor = true;
            // 
            // btn_setting_backcolor
            // 
            this.btn_setting_backcolor.BackColor = System.Drawing.Color.Black;
            this.btn_setting_backcolor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_setting_backcolor.Location = new System.Drawing.Point(71, 6);
            this.btn_setting_backcolor.Name = "btn_setting_backcolor";
            this.btn_setting_backcolor.Size = new System.Drawing.Size(21, 21);
            this.btn_setting_backcolor.TabIndex = 4;
            this.btn_setting_backcolor.UseVisualStyleBackColor = false;
            this.btn_setting_backcolor.Click += new System.EventHandler(this.btn_setting_backcolor_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "背景颜色:";
            // 
            // lv_brightness
            // 
            this.lv_brightness.AutoSize = true;
            this.lv_brightness.Location = new System.Drawing.Point(71, 42);
            this.lv_brightness.Name = "lv_brightness";
            this.lv_brightness.Size = new System.Drawing.Size(11, 12);
            this.lv_brightness.TabIndex = 2;
            this.lv_brightness.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "背光亮度:";
            // 
            // tbr_setting_brightness
            // 
            this.tbr_setting_brightness.BackColor = System.Drawing.Color.White;
            this.tbr_setting_brightness.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbr_setting_brightness.Location = new System.Drawing.Point(88, 33);
            this.tbr_setting_brightness.Maximum = 100;
            this.tbr_setting_brightness.Minimum = 10;
            this.tbr_setting_brightness.Name = "tbr_setting_brightness";
            this.tbr_setting_brightness.Size = new System.Drawing.Size(120, 45);
            this.tbr_setting_brightness.SmallChange = 5;
            this.tbr_setting_brightness.TabIndex = 0;
            this.tbr_setting_brightness.TickFrequency = 10;
            this.tbr_setting_brightness.Value = 55;
            this.tbr_setting_brightness.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Image = global::TinyDisplay.Properties.Resources.Save_16x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(184, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "保存设定";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::TinyDisplay.Properties.Resources.DownloadFile_16x;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(265, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "读取设定";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 410);
            this.Controls.Add(this.tbc_control);
            this.Controls.Add(this.btn_device_open);
            this.Controls.Add(this.cb_device);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(480, 449);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TinyDisplay";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tbc_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbr_setting_brightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lv_plugins;
        private System.Windows.Forms.Button btn_plugin_add;
        private System.Windows.Forms.Button btn_plugin_remove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_device_open;
        private System.Windows.Forms.ComboBox cb_device;
        private System.Windows.Forms.TabControl tbc_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbr_setting_brightness;
        private System.Windows.Forms.Label lv_brightness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_setting_backcolor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pb_preview;
        private System.Windows.Forms.Button btn_plugin_down;
        private System.Windows.Forms.Button btn_plugin_up;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_plugin_version;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_plugin_author;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_plugin_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_plugin_path;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_plugin_desc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_plugin_setting;
        private System.Windows.Forms.Label lb_plugin_enabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cb_setting_brightness_preview;
        private System.Windows.Forms.Button btn_plugin_url;
        private System.Windows.Forms.Label lb_fps;
    }
}

