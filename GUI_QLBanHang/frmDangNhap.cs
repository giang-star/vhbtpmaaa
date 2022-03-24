﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
namespace GUI_QLBanHang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        
        private bool isSuccess = false;
        public string getEmail
        {
            get
            {
                return txtEmail.Text;
            }
        }
        public bool getSuccess
        {
            get { return isSuccess; }
        } 


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           
            if (txtEmail.Text !="" && txtMatKhau.Text != "")
            {
                BUS_NhanVien nv = new BUS_NhanVien();
                if (nv.DangNhap(txtEmail.Text , txtMatKhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    isSuccess = true;
                    Properties.Settings.Default.isSave = chkGhiNho.Checked;
                    if (chkGhiNho.Checked)
                    {
                        Properties.Settings.Default.Email = txtEmail.Text;
                        Properties.Settings.Default.Password = txtMatKhau.Text;
              
                    }
                    Properties.Settings.Default.Save();
                    Close();
                    
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSuccess = false;
                    txtEmail.Text = "";
                    txtMatKhau.Text = "";
                    txtEmail.Focus();
                }
            }
        }
    

        private void llblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtEmail.Text != "")
            {
             
                // check email 
                BUS_NhanVien busNV = new BUS_NhanVien();
                if (busNV.checkEmail(txtEmail.Text))
                {
              
                    string password = busNV.getPassword();

                    if (busNV.updateMatKhau(txtEmail.Text , password))
                    {
                        SendMail load = new SendMail(txtEmail.Text, password, true);
                        load.ShowDialog();
                        MessageBox.Show(load.getResult, "Thông báo");
                    }
                   else
                        MessageBox.Show("Không thực hiện được", "Thông báo");


                }
            }
        }
        
        private void QL_Login_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isSave)
            {
                txtEmail.Text = Properties.Settings.Default.Email;
                txtMatKhau.Text = Properties.Settings.Default.Password;
                chkGhiNho.Checked = true;
                btnDangNhap.Focus();
            }
        }
    }
}
