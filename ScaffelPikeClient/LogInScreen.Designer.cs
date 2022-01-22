namespace ScaffelPikeClient
{
  partial class LogInScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInScreen));
            this.groupBoxLogIn = new System.Windows.Forms.GroupBox();
            this.pictureBoxViewPassword = new System.Windows.Forms.PictureBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelConnections = new System.Windows.Forms.Label();
            this.groupBoxLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxLogIn
            // 
            this.groupBoxLogIn.Controls.Add(this.pictureBoxViewPassword);
            this.groupBoxLogIn.Controls.Add(this.buttonLogIn);
            this.groupBoxLogIn.Controls.Add(this.textBoxPassword);
            this.groupBoxLogIn.Controls.Add(this.textBoxUsername);
            this.groupBoxLogIn.Controls.Add(this.labelPassword);
            this.groupBoxLogIn.Controls.Add(this.labelUsername);
            this.groupBoxLogIn.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLogIn.Name = "groupBoxLogIn";
            this.groupBoxLogIn.Size = new System.Drawing.Size(231, 124);
            this.groupBoxLogIn.TabIndex = 1;
            this.groupBoxLogIn.TabStop = false;
            this.groupBoxLogIn.Text = "Log In";
            // 
            // pictureBoxViewPassword
            // 
            this.pictureBoxViewPassword.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxViewPassword.Image")));
            this.pictureBoxViewPassword.Location = new System.Drawing.Point(195, 61);
            this.pictureBoxViewPassword.Name = "pictureBoxViewPassword";
            this.pictureBoxViewPassword.Size = new System.Drawing.Size(30, 20);
            this.pictureBoxViewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxViewPassword.TabIndex = 5;
            this.pictureBoxViewPassword.TabStop = false;
            this.pictureBoxViewPassword.MouseLeave += new System.EventHandler(this.pictureBoxViewPassword_MouseLeave);
            this.pictureBoxViewPassword.MouseHover += new System.EventHandler(this.pictureBoxViewPassword_MouseHover);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(77, 87);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(115, 23);
            this.buttonLogIn.TabIndex = 4;
            this.buttonLogIn.Text = "Log In";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_ClickAsync);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(77, 61);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(115, 20);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(77, 26);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(115, 20);
            this.textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(18, 64);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(18, 29);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // labelConnections
            // 
            this.labelConnections.AutoSize = true;
            this.labelConnections.Location = new System.Drawing.Point(12, 139);
            this.labelConnections.Name = "labelConnections";
            this.labelConnections.Size = new System.Drawing.Size(118, 13);
            this.labelConnections.TabIndex = 2;
            this.labelConnections.Text = "Connections Available :";
            // 
            // LogInScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 161);
            this.Controls.Add(this.labelConnections);
            this.Controls.Add(this.groupBoxLogIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(270, 200);
            this.MinimumSize = new System.Drawing.Size(270, 200);
            this.Name = "LogInScreen";
            this.Text = "LogInScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogInScreen_FormClosed);
            this.Load += new System.EventHandler(this.LogInScreen_Load);
            this.groupBoxLogIn.ResumeLayout(false);
            this.groupBoxLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBoxLogIn;
    private System.Windows.Forms.Label labelUsername;
    private System.Windows.Forms.Button buttonLogIn;
    private System.Windows.Forms.TextBox textBoxPassword;
    private System.Windows.Forms.TextBox textBoxUsername;
    private System.Windows.Forms.Label labelPassword;
    private System.Windows.Forms.PictureBox pictureBoxViewPassword;
    private System.Windows.Forms.Label labelConnections;
  }
}