using QuanliquancfM.DAO;
using QuanliquancfM.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanliquancfM
{
    public partial class fAccountProfile : Form
    {


        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount (Account acc)
        {
            txbUser.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccount()
        {
            string displayName = txbDisplayName.Text;
            string passWord = txbPassWord.Text;
            string newPass = txbNewPass.Text;
            string reenterPass = txbReEnterPassWord.Text;
            string userName = txbUser.Text;

            if (!newPass.Equals(reenterPass))
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
                {
                    MessageBox.Show("Cap nhat thanh cong");
                }
                else
                {
                    MessageBox.Show("Vui long nhap dung mat khau");
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
