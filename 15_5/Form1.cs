using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
namespace game2048
{
    public partial class Game2048 : Form
    {
      
        Random Rd = new Random();
        bool dangChoi = true;
        static ArrayList Listrong = new ArrayList();
        public Game2048()
        {
            InitializeComponent();
        }
        //Cập nhật mã màu cho lbl
        public void CapNhatMau()
        {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if(Game[i,j].Text==""){
                        Game[i, j].BackColor = System.Drawing.Color.LightGray;
                    }
                    if (Game[i, j].Text == "2")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LavenderBlush;
                        Game[i, j].ForeColor = System.Drawing.Color.DimGray;

                    }
                    if (Game[i, j].Text == "4")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LemonChiffon;
                        Game[i, j].ForeColor = System.Drawing.Color.DimGray;
                    }
                    if (Game[i, j].Text == "8")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.SandyBrown;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "16")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Salmon;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "32")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Tomato;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "64")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Red;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "128")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "256")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "512")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "1024")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "2048")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "4096")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "8192")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Maroon;
                        Game[i, j].ForeColor = System.Drawing.Color.Yellow;
                    }
                }
            }
            
        }

        public void KhoiTaoManGame() {
            ptb2.Visible = false;
            ptb3.Visible = false;
            ptb4.Visible = false;
            Listrong.Clear();

            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++)
                {
                    // tìm ô trống 
                    if(Game[i,j].Text==""){
                        Listrong.Add(i*4+j+1);
                    }
                }
            }
            // nếu có ô trống thì random ô bất kì trong list ô trống
            if(Listrong.Count>0){

                int chiSoHinh = int.Parse(Listrong[Rd.Next(0, Listrong.Count - 1)].ToString());
                int i0 = (chiSoHinh - 1) / 4;
                int j0 = (chiSoHinh - 1) - i0 *4;
                int NgauNhien = Rd.Next(1,10);
                if (NgauNhien == 1 || NgauNhien == 2 || NgauNhien == 3 || NgauNhien == 4 || NgauNhien == 5||NgauNhien==6 )
                {
                    Game[i0, j0].Text = "2"; // xác suất sô 2 là 95%
                }
                else { 
                    Game[i0,j0].Text="4"; // xác suất xuất hiện số 4 là 5%
                }

            }
            CapNhatMau();
        }
        public void LenTren() {
            
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                int oRong = 0;
                for (int j = 0; j < 4;j++ )
                {
                    //for (int k = j+1; k < 4;k++ )
                    //{
                    //    if(Game[k,i].Text!=""){
                    //        if(Game[k,i].Text==Game[j,i].Text){
                    //        }
                    //        break;
                    //    }
                    //}
                    if (Game[j, i].Text == "")
                    {
                        oRong++;
                    }
                    else {
                        for (int m = j; m >= 0;m-- )
                        {
                            if(Game[m,i].Text==""){
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;
                            
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                       
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if(oRong!=0){
                                            Game[j - oRong, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;
                                        
                                    }
                                    break;
                                }
                            }
                            if(ktra==true && oRong!=0){
                               
                                Game[j - oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else {
                            if(oRong!=0){
                               
                                Game[j - oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        
                       
                    }
                }
            }
            
            if(kTraKhoiTao==true){
                KhoiTaoManGame();
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoManGame();
            KhoiTaoManGame();
            KhoiTaoManGame();
        }
        public void XuongDuoi()
        {
           
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j = 3; j >=0; j--)
                {
                    //for (int k = j - 1; k >= 0;k-- )
                    //{
                    //    if(Game[k,i].Text!=""){
                    //        if(Game[k,i].Text==Game[j,i].Text){
                               
                    //        }
                    //        break;
                    //    }
                    //}
                    if (Game[j, i].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j+1; m <= 3; m++)
                        {
                            if (Game[m, i].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j-1>=0)
                        {
                            bool ktra = true;
                            
                            for (int k = j -1 ; k >= 0; k--)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                       
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[j + oRong, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                                
                                Game[j + oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                                
                                Game[j + oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }


                    }
                }
            }
            
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public void SangTrai()
        {
           
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j =0; j <4; j++)
                {

                    //for (int k = j + 1; k < 4;k++ )
                    //{
                    //    if(Game[i,k].Text!=""){
                    //        if(Game[i,j].Text==Game[i,k].Text){
                               
                    //        }
                    //        break;
                    //    }
                    //}
                    if (Game[i,j].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j-1; m >= 0; m--)
                        {
                            if (Game[i, m].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;
                            
                            for (int k = j + 1; k <4; k++)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[i,j - oRong].Text = Game[i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                              
                                Game[i,j - oRong].Text = Game[i,j].Text;
                                Game[i,j].Text = "";
                               
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                               
                                Game[i,j - oRong].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                                
                            }
                        }


                    }
                }
            }
            
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public void SangPhai()
        {
           
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j = 3; j >= 0; j--)
                {
                    //for (int k = j - 1; k >= 0;k-- )
                    //{
                    //    if(Game[i,k].Text!=""){
                    //        if(Game[i,k].Text==Game[i,j].Text){
                              
                    //        }
                    //        break;
                    //    }
                    //}
                    if (Game[i,j].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (Game[i,m].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool ktra = true;
                            
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[i, j+oRong].Text = Game[ i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                              
                                Game[i,j+ oRong].Text = Game[i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                              
                                Game[ i,j + oRong].Text = Game[ i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        
                    }
                }
            }
            
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public bool KetThuc() {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    if(Game[i,j].Text==""){
                        return false;
                    }
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[i,j].Text!="")
                        {
                            if(Game[i,j].Text==Game[i,k].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game[j, i].Text == "")
                    {
                        return false;
                    }
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Game[k,i].Text != "")
                        {
                            if (Game[j,i].Text == Game[k,i].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (KetThuc() == false)
            {
                if (e.KeyCode == Keys.Up)
                {
                    LenTren();

                }
                if (e.KeyCode == Keys.Down)
                {
                    XuongDuoi();
                }
                if (e.KeyCode == Keys.Left)
                {
                    SangTrai();
                }
                if (e.KeyCode == Keys.Right)
                {
                    SangPhai();
                }
                if (int.Parse(lblScore.Text) > int.Parse(lblbest.Text))
                {
                    lblbest.Text = lblScore.Text;
                }
            }
            
            else {
                continueToolStripMenuItem.Visible = false;
                lblGameOver.Text = "Thua rồi";
                dangChoi = false;
                lblGameOver.Visible = true;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
                btnsave.Visible = true;
                btnExit.Enabled = true;
                btnNewGame.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
           
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            lblScore.Text = "0";
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnsave.Visible = false;
            btnExit.Visible = false;
            dangChoi = true;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Game[i, j].Text = "";
                }
            }
            KhoiTaoManGame();
            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ptb2.Visible = false;
            ptb3.Visible = false;
            ptb4.Visible = false;
            lblkiluc.Visible = true;
            lblbest.Visible = true;
            lblname.Visible = true;
            pictureBox1.Visible = true;
            continueToolStripMenuItem.Visible = true;
            lblAbout.Visible = false;
            label2.Visible = true;
            lblScore.Visible = true;

            if(dangChoi==false){
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            dangChoi = true;
            lblScore.Text = "0";
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                    Game[i, j].Text = "";
                }
            }
            KhoiTaoManGame();
            
        }

        private void continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ptb2.Visible = false;
            ptb3.Visible = false;
            ptb4.Visible = false;
            lblname.Visible = true;
            pictureBox1.Visible = true;
            lblkiluc.Visible = true;
            lblbest.Visible = true;
                lblAbout.Visible = false;
                label2.Visible = true;
                lblScore.Visible = true;

                if (dangChoi == false)
                {
                    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
                }
                Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
                lblGameOver.Visible = false;
                btnExit.Visible = false;
                btnNewGame.Visible = false;
                btnNewGame.Enabled = false;
                btnExit.Enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Game[i, j].Visible = true;
                    }
                }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            lblname.Visible = false;
            lblGameOver.Visible = false;
            lblbest.Visible = false;
            lblkiluc.Visible = false;
            lblScore.Visible = false;
            label2.Visible = false;
            btnNewGame.Visible = false;
            btnExit.Visible = false;
            lblAbout.Visible = true;
            lblAbout.Location = new System.Drawing.Point(0, 41);
            lblAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = false;
                }
            }
            ptb2.Visible = true;
            ptb3.Visible = true;
            ptb4.Visible = true;
            const string message = "Bùi Đức Việt - Huỳnh Thị Hoa, Khoa Hệ thống thông tin - Đại Học Kinh Tế Huế";
            const string caption = "About : 2048";
            MessageBox.Show(message, caption);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cám ơn bạn đã sử dụng chương trình");
            Application.Exit();
        }

        private void btnNewGame_MouseHover(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.MediumPurple;
        }

        private void btnNewGame_MouseLeave(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.MediumPurple;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.MediumPurple;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.MediumPurple;
        }
        private void ptbImage_Click(object sender, EventArgs e)
        {

        }

        private void lblkiluc_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        
        


    }
}
