namespace ConnectFour
{
  partial class SelectTwoAI
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
      this.Player1AIList = new System.Windows.Forms.ComboBox();
      this.Player2AIList = new System.Windows.Forms.ComboBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Player1AIList
      // 
      this.Player1AIList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Player1AIList.FormattingEnabled = true;
      this.Player1AIList.Location = new System.Drawing.Point(11, 25);
      this.Player1AIList.MaxDropDownItems = 50;
      this.Player1AIList.Name = "Player1AIList";
      this.Player1AIList.Size = new System.Drawing.Size(257, 21);
      this.Player1AIList.TabIndex = 1;
      // 
      // Player2AIList
      // 
      this.Player2AIList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.Player2AIList.FormattingEnabled = true;
      this.Player2AIList.Location = new System.Drawing.Point(11, 82);
      this.Player2AIList.MaxDropDownItems = 50;
      this.Player2AIList.Name = "Player2AIList";
      this.Player2AIList.Size = new System.Drawing.Size(257, 21);
      this.Player2AIList.TabIndex = 2;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(147, 119);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(121, 28);
      this.button1.TabIndex = 3;
      this.button1.Text = "Let\'s Play!";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(121, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Select Player 1 (Yellow):";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(110, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Select Player 2 (Red):";
      // 
      // SelectTwoAI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 160);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.Player2AIList);
      this.Controls.Add(this.Player1AIList);
      this.Name = "SelectTwoAI";
      this.Text = "SelectAI";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox Player1AIList;
    private System.Windows.Forms.ComboBox Player2AIList;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}