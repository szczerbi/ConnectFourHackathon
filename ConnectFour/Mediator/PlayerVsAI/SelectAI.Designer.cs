namespace ConnectFour
{
  partial class SelectAI
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
      this.AIPlayerList = new System.Windows.Forms.ComboBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      //
      // Player1AIList
      //
      this.AIPlayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.AIPlayerList.FormattingEnabled = true;
      this.AIPlayerList.Location = new System.Drawing.Point(12, 25);
      this.AIPlayerList.MaxDropDownItems = 50;
      this.AIPlayerList.Name = "Player1AIList";
      this.AIPlayerList.Size = new System.Drawing.Size(257, 21);
      this.AIPlayerList.TabIndex = 1;
      //
      // button1
      //
      this.button1.Location = new System.Drawing.Point(151, 52);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(121, 28);
      this.button1.TabIndex = 4;
      this.button1.Text = "Let\'s Play!";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      //
      // label1
      //
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Select Artificial Player (Red):";
      //
      // SelectAI
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 92);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.AIPlayerList);
      this.Name = "SelectAI";
      this.Text = "SelectAI";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox AIPlayerList;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
  }
}