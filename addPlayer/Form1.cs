using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtFullName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool isVisibility = false;

                if (txtVisibility.Text == "0")
                    isVisibility = false;
                else if (txtVisibility.Text == "1")
                    isVisibility = true;

                karafzar.sqlCommand.CommandText = "sp_addPlayer";
                karafzar.sqlCommand.CommandType = CommandType.StoredProcedure;
                karafzar.sqlCommand.Parameters.Clear();
                karafzar.sqlCommand.Parameters.AddWithValue("@club_id", txtClubId.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@fullname", txtFullName.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@number", txtNumber.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@image", txtImage.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@birthday", txtBirthday.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@birthPlace", txtBirthPlace.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@nationality", txtNationality.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@height", txtHeight.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@position", txtPosition.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@position_order", txtPositionOrder.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@foot", txtFoot.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@current_value", txtCurrentValue.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@current_value_dateTime", txtCurrentValueDateTime.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@highest_value", txtHighestValue.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@highest_value_dateTime", txtHighestValueDateTime.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@ref_link", txtRefLink.Text);
                karafzar.sqlCommand.Parameters.AddWithValue("@visibility", isVisibility);
                DataTable dataTable = karafzar.SqlDataAdapter();

                if (dataTable.Rows[0]["status"].ToString() == "false")
                {
                    MessageBox.Show("Adding player was not successfully done!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dataTable.Rows[0]["status"].ToString() == "true")
                {
                    txtClubId.Text = "37";
                    txtFullName.Text = "";
                    txtNumber.Text = "";
                    txtImage.Text = "";
                    txtBirthday.Text = "";
                    txtBirthPlace.Text = "";
                    txtNationality.Text = "آلمان";
                    txtHeight.Text = "";
                    txtPosition.Text = "";
                    txtPositionOrder.Text = "";
                    txtFoot.Text = "right";
                    txtCurrentValue.Text = "";
                    txtCurrentValueDateTime.Text = "2022/01/10";
                    txtHighestValue.Text = "";
                    txtHighestValueDateTime.Text = "";
                    txtRefLink.Text = "";
                    txtVisibility.Text = "1";
                    this.ActiveControl = txtFullName;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
