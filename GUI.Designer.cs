using System.Drawing;
using System;
using System.Windows.Forms;

namespace Calculator
{
    partial class Calculator
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
        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.SkyBlue;
        }
        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Transparent;
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubstract = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonLeftBracket = new System.Windows.Forms.Button();
            this.buttonRightBracket = new System.Windows.Forms.Button();
            this.buttonPow = new System.Windows.Forms.Button();
            this.buttonSqrt = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSqrtN = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonFactorial = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPercentage = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDot = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 60);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button1.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(68, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 60);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button2.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(133, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 60);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button3.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(3, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 60);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button4.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(68, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 60);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button5.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(133, 69);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(59, 60);
            this.button6.TabIndex = 6;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button6.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button7.Location = new System.Drawing.Point(3, 135);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(59, 60);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button7.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button8.Location = new System.Drawing.Point(68, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 60);
            this.button8.TabIndex = 8;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button8.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button9.Location = new System.Drawing.Point(133, 135);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(59, 60);
            this.button9.TabIndex = 9;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button9.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button10.Location = new System.Drawing.Point(198, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(59, 60);
            this.button10.TabIndex = 10;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.button10.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.button10.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdd.BackgroundImage")));
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAdd.Location = new System.Drawing.Point(198, 135);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(59, 60);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            this.buttonAdd.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonAdd.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonSubstract
            // 
            this.buttonSubstract.BackColor = System.Drawing.Color.Transparent;
            this.buttonSubstract.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSubstract.BackgroundImage")));
            this.buttonSubstract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubstract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSubstract.FlatAppearance.BorderSize = 0;
            this.buttonSubstract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubstract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonSubstract.Location = new System.Drawing.Point(263, 135);
            this.buttonSubstract.Name = "buttonSubstract";
            this.buttonSubstract.Size = new System.Drawing.Size(62, 60);
            this.buttonSubstract.TabIndex = 12;
            this.buttonSubstract.UseVisualStyleBackColor = false;
            this.buttonSubstract.Click += new System.EventHandler(this.buttonSubstract_Click);
            this.buttonSubstract.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonSubstract.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonEqual
            // 
            this.buttonEqual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEqual.BackColor = System.Drawing.Color.Transparent;
            this.buttonEqual.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEqual.BackgroundImage")));
            this.buttonEqual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.FlatAppearance.BorderSize = 0;
            this.buttonEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonEqual.Location = new System.Drawing.Point(263, 3);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(62, 60);
            this.buttonEqual.TabIndex = 13;
            this.buttonEqual.UseVisualStyleBackColor = false;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            this.buttonEqual.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonEqual.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.Location = new System.Drawing.Point(120, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(325, 109);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMultiply.BackColor = System.Drawing.Color.Transparent;
            this.buttonMultiply.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMultiply.BackgroundImage")));
            this.buttonMultiply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiply.FlatAppearance.BorderSize = 0;
            this.buttonMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonMultiply.Location = new System.Drawing.Point(198, 201);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(59, 60);
            this.buttonMultiply.TabIndex = 15;
            this.buttonMultiply.UseVisualStyleBackColor = false;
            this.buttonMultiply.Click += new System.EventHandler(this.buttonMultiply_Click);
            this.buttonMultiply.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonMultiply.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonDivide
            // 
            this.buttonDivide.BackColor = System.Drawing.Color.Transparent;
            this.buttonDivide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDivide.BackgroundImage")));
            this.buttonDivide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDivide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivide.FlatAppearance.BorderSize = 0;
            this.buttonDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDivide.Location = new System.Drawing.Point(263, 201);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(62, 60);
            this.buttonDivide.TabIndex = 16;
            this.buttonDivide.UseVisualStyleBackColor = false;
            this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
            this.buttonDivide.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonDivide.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonLeftBracket
            // 
            this.buttonLeftBracket.BackColor = System.Drawing.Color.Transparent;
            this.buttonLeftBracket.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLeftBracket.BackgroundImage")));
            this.buttonLeftBracket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeftBracket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLeftBracket.FlatAppearance.BorderSize = 0;
            this.buttonLeftBracket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeftBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonLeftBracket.Location = new System.Drawing.Point(68, 267);
            this.buttonLeftBracket.Name = "buttonLeftBracket";
            this.buttonLeftBracket.Size = new System.Drawing.Size(59, 64);
            this.buttonLeftBracket.TabIndex = 17;
            this.buttonLeftBracket.UseVisualStyleBackColor = false;
            this.buttonLeftBracket.Click += new System.EventHandler(this.buttonLeftBracket_Click);
            this.buttonLeftBracket.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonLeftBracket.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonRightBracket
            // 
            this.buttonRightBracket.BackColor = System.Drawing.Color.Transparent;
            this.buttonRightBracket.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRightBracket.BackgroundImage")));
            this.buttonRightBracket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRightBracket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRightBracket.FlatAppearance.BorderSize = 0;
            this.buttonRightBracket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRightBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonRightBracket.Location = new System.Drawing.Point(133, 267);
            this.buttonRightBracket.Name = "buttonRightBracket";
            this.buttonRightBracket.Size = new System.Drawing.Size(59, 64);
            this.buttonRightBracket.TabIndex = 18;
            this.buttonRightBracket.UseVisualStyleBackColor = false;
            this.buttonRightBracket.Click += new System.EventHandler(this.buttonRightBracket_Click);
            this.buttonRightBracket.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonRightBracket.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonPow
            // 
            this.buttonPow.BackColor = System.Drawing.Color.Transparent;
            this.buttonPow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPow.BackgroundImage")));
            this.buttonPow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPow.FlatAppearance.BorderSize = 0;
            this.buttonPow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonPow.Location = new System.Drawing.Point(68, 201);
            this.buttonPow.Name = "buttonPow";
            this.buttonPow.Size = new System.Drawing.Size(59, 60);
            this.buttonPow.TabIndex = 19;
            this.buttonPow.UseVisualStyleBackColor = false;
            this.buttonPow.Click += new System.EventHandler(this.buttonPow_Click);
            this.buttonPow.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonPow.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonSqrt
            // 
            this.buttonSqrt.BackColor = System.Drawing.Color.Transparent;
            this.buttonSqrt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSqrt.BackgroundImage")));
            this.buttonSqrt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSqrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqrt.FlatAppearance.BorderSize = 0;
            this.buttonSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSqrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonSqrt.Location = new System.Drawing.Point(198, 267);
            this.buttonSqrt.Name = "buttonSqrt";
            this.buttonSqrt.Size = new System.Drawing.Size(59, 64);
            this.buttonSqrt.TabIndex = 20;
            this.buttonSqrt.UseVisualStyleBackColor = false;
            this.buttonSqrt.Click += new System.EventHandler(this.buttonSqrt_Click);
            this.buttonSqrt.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonSqrt.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBack.BackgroundImage")));
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonBack.Location = new System.Drawing.Point(198, 69);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(59, 60);
            this.buttonBack.TabIndex = 22;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonBack.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonBack.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonSqrtN
            // 
            this.buttonSqrtN.BackColor = System.Drawing.Color.Transparent;
            this.buttonSqrtN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSqrtN.BackgroundImage")));
            this.buttonSqrtN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSqrtN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqrtN.FlatAppearance.BorderSize = 0;
            this.buttonSqrtN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSqrtN.Location = new System.Drawing.Point(263, 267);
            this.buttonSqrtN.Name = "buttonSqrtN";
            this.buttonSqrtN.Size = new System.Drawing.Size(62, 64);
            this.buttonSqrtN.TabIndex = 23;
            this.buttonSqrtN.UseVisualStyleBackColor = false;
            this.buttonSqrtN.Click += new System.EventHandler(this.buttonSqrtN_Click);
            this.buttonSqrtN.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonSqrtN.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox2.Location = new System.Drawing.Point(359, 464);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 37);
            this.textBox2.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(318, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "n=";
            // 
            // buttonFactorial
            // 
            this.buttonFactorial.BackColor = System.Drawing.Color.Transparent;
            this.buttonFactorial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonFactorial.BackgroundImage")));
            this.buttonFactorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFactorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFactorial.FlatAppearance.BorderSize = 0;
            this.buttonFactorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFactorial.Location = new System.Drawing.Point(3, 201);
            this.buttonFactorial.Name = "buttonFactorial";
            this.buttonFactorial.Size = new System.Drawing.Size(59, 60);
            this.buttonFactorial.TabIndex = 26;
            this.buttonFactorial.UseVisualStyleBackColor = false;
            this.buttonFactorial.Click += new System.EventHandler(this.buttonFactorial_Click);
            this.buttonFactorial.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonFactorial.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 470);
            this.panel1.TabIndex = 27;
            this.panel1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 467);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox3.Location = new System.Drawing.Point(28, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 28);
            this.textBox3.TabIndex = 3;
            this.textBox3.Visible = false;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.radioButton2.Location = new System.Drawing.Point(11, 117);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(225, 28);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "At your choice(15 max)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton1.Location = new System.Drawing.Point(11, 82);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(206, 29);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Default (6 decimals)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 50);
            this.label3.TabIndex = 0;
            this.label3.Text = "⚫ Maximum number of\r\n decimals of the result:\r\n";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonPercentage, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqrtN, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonFactorial, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqrt, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonPow, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiply, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivide, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonRightBracket, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonLeftBracket, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSubstract, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBack, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelete, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.button10, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqual, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDot, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(117, 124);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 334);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // buttonPercentage
            // 
            this.buttonPercentage.BackColor = System.Drawing.Color.Transparent;
            this.buttonPercentage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPercentage.BackgroundImage")));
            this.buttonPercentage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPercentage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPercentage.FlatAppearance.BorderSize = 0;
            this.buttonPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonPercentage.Location = new System.Drawing.Point(133, 201);
            this.buttonPercentage.Name = "buttonPercentage";
            this.buttonPercentage.Size = new System.Drawing.Size(59, 60);
            this.buttonPercentage.TabIndex = 32;
            this.buttonPercentage.UseVisualStyleBackColor = false;
            this.buttonPercentage.Click += new System.EventHandler(this.buttonPercentage_Click);
            this.buttonPercentage.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonPercentage.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Location = new System.Drawing.Point(263, 69);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(62, 60);
            this.buttonDelete.TabIndex = 31;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonDelete.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonDot
            // 
            this.buttonDot.BackColor = System.Drawing.Color.Transparent;
            this.buttonDot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDot.BackgroundImage")));
            this.buttonDot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDot.FlatAppearance.BorderSize = 0;
            this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDot.Location = new System.Drawing.Point(3, 267);
            this.buttonDot.Name = "buttonDot";
            this.buttonDot.Size = new System.Drawing.Size(59, 64);
            this.buttonDot.TabIndex = 27;
            this.buttonDot.UseVisualStyleBackColor = false;
            this.buttonDot.Click += new System.EventHandler(this.buttonDot_Click);
            this.buttonDot.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonDot.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSettings.BackgroundImage")));
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Location = new System.Drawing.Point(0, 8);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(73, 66);
            this.buttonSettings.TabIndex = 28;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(451, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 90);
            this.label4.TabIndex = 29;
            this.label4.Text = "Calculation\r\nhistory\r\n";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(451, 119);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(364, 379);
            this.listBox1.TabIndex = 30;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // buttonInfo
            // 
            this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInfo.BackColor = System.Drawing.Color.Transparent;
            this.buttonInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInfo.BackgroundImage")));
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInfo.FlatAppearance.BorderSize = 0;
            this.buttonInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInfo.Location = new System.Drawing.Point(754, 8);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(75, 66);
            this.buttonInfo.TabIndex = 34;
            this.buttonInfo.UseVisualStyleBackColor = false;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            this.buttonInfo.MouseEnter += new System.EventHandler(this.OnMouseEnterButton);
            this.buttonInfo.MouseLeave += new System.EventHandler(this.OnMouseLeaveButton);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(594, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 470);
            this.panel2.TabIndex = 35;
            this.panel2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 470);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(-4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 460);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(131, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 48);
            this.label5.TabIndex = 36;
            this.label5.Text = "Please press the information button\r\n to know how calculations \r\nworks before sta" +
    "rting...";
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(830, 550);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(848, 597);
            this.Name = "Calculator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Calculator";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSubstract;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonLeftBracket;
        private System.Windows.Forms.Button buttonRightBracket;
        private System.Windows.Forms.Button buttonPow;
        private System.Windows.Forms.Button buttonSqrt;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSqrtN;
        private System.Windows.Forms.Button buttonFactorial;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonDot;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonPercentage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}

