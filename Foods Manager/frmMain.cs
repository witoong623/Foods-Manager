using System;
using System.Windows.Forms;
public class frmMain : Form
{
    private void InitializeComponent()
    {

    }
    public frmMain()
    {
        InitializeComponent();
    }
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }
}