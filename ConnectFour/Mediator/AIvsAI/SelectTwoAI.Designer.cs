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
      this.SuspendLayout();
      // 
      // Player1AIList
      // 
      this.Player1AIList.FormattingEnabled = true;
      this.Player1AIList.Location = new System.Drawing.Point(12, 108);
      this.Player1AIList.MaxDropDownItems = 50;
      this.Player1AIList.Name = "Player1AIList";
      this.Player1AIList.Size = new System.Drawing.Size(257, 21);
      this.Player1AIList.TabIndex = 1;
      // 
      // Player2AIList
      // 
      this.Player2AIList.FormattingEnabled = true;
      this.Player2AIList.Location = new System.Drawing.Point(12, 169);
      this.Player2AIList.MaxDropDownItems = 50;
      this.Player2AIList.Name = "Player2AIList";
      this.Player2AIList.Size = new System.Drawing.Size(257, 21);
      this.Player2AIList.TabIndex = 2;
      // 
      // SelectAI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.Player2AIList);
      this.Controls.Add(this.Player1AIList);
      this.Name = "SelectAI";
      this.Text = "SelectAI";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox Player1AIList;
    private System.Windows.Forms.ComboBox Player2AIList;
  }
}