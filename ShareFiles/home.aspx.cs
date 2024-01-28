using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ShareFiles
{
    public partial class home : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection conn;
        DataTable dttest = new DataTable();
        string cmdstr = string.Empty;
        string errstr = string.Empty;
        string gettext = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                conn = new SqlConnection(constr);
                conn.Open();

                DateTime d = DateTime.Now;
                Lblyear.Text = d.Year.ToString();
                gettext = TextBox3.Text;

                if (!IsPostBack)
                {
                    // Validate initially to force asterisks
                    // to appear before the first roundtrip.
                    Validate();
                    TextBox5.Text = "";
                    TextBox3.Text = "";

                }
                else {
                    TextBox3.Text = "";
                    
                }
                

            }
            catch (Exception ex )
            {

                showpopupmessage("Server was not reachable at a moment - "+ex.Message);
                return;
            }
           
        }

        

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                //string gettext = string.Empty;
                string newstr = string.Empty;
                //conn.Open();
                string getid = string.Empty;
                if (string.IsNullOrWhiteSpace(gettext))
                {

                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter the text')", true);
                    errstr = "Please enter the text";
                    showpopupmessage(errstr);
                    return;
                }
                else {
                    //gettext = TextBox3.Text;
                    string s1 = "'";
                    string s2 = "''";
                     newstr = gettext.Replace(s1,s2);
                    if (gettext.Length > 4500)
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter 4500 character only')", true);
                        errstr = "Please enter 4500 character only";
                        showpopupmessage(errstr);
                        return;
                    }

                    DateTime today = DateTime.Now;
                    string updatedate = "yyyy-MM-dd HH:mm:ss";
                    cmdstr = "insert into share_files_tab (TXT_FILE_NAME,TXT_DATE_TIME)  values ('" + newstr.Trim() + "','" + today.ToString(updatedate) + "')";
                    getstoredintoDB(cmdstr);

                    cmdstr = "select top 1 id from share_files_tab order by id desc";
                    SqlCommand cmd = new SqlCommand(cmdstr, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        getid = sdr["id"].ToString();
                    }
                    TextBox5.Text = getid;
                    //string err = " Error inserting the text";
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully inserted and ID generated')", true);
                    errstr = "Successfully inserted and ID generated";
                    showpopupmessage(errstr);
                    TextBox3.Text = "";
                    sdr.Close();
                    conn.Close();

                  
                }
                
                
                //DateTime today = DateTime.Now;
                //string updatedate = "yyyy-MM-dd HH:mm:ss";
                //cmdstr = "insert into share_files_tab (TXT_FILE_NAME,TXT_DATE_TIME)  values ('" + newstr.Trim() + "','" + today.ToString(updatedate) + "')";
                //getstoredintoDB(cmdstr);

                //cmdstr = "select top 1 id from share_files_tab order by id desc";
                //SqlCommand cmd = new SqlCommand(cmdstr, conn);
                //SqlDataReader sdr = cmd.ExecuteReader();

                //while (sdr.Read())
                //{
                //    getid = sdr["id"].ToString();
                //}
                //TextBox5.Text = getid;
                ////string err = " Error inserting the text";
                ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully inserted and ID generated')", true);
                //errstr = "Successfully inserted and ID generated";
                //showpopupmessage(errstr);
                //sdr.Close();
                //conn.Close();
                //TextBox3.Text = "";
            }
            catch (Exception ex)
            {
                //string err = "Error inserting the text";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+err+ "')" , true);
                errstr = "Error inserting the text " + ex.Message.ToString();
                string newerr= errstr.Replace("'","''");
                showpopupmessage(newerr);

            }
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                string gettext = string.Empty;

                if (System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "[^0-9]"))
                {

                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter numeric only')", true);
                    errstr = "Please enter numeric only";
                    showpopupmessage(errstr);
                    return;

                }
                else
                {
                    id = Convert.ToInt32(TextBox6.Text);
                }
                cmdstr = "select TXT_FILE_NAME from share_files_tab where id='" + id + "'";
                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    gettext = sdr["TXT_FILE_NAME"].ToString();
                }
                if (gettext == "")
                {
                    
                    //ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('" + err + "')", true);
                    errstr = "There is not data present at ID " + id + ", please enter the valid ID";
                    showpopupmessage(errstr);
                }
                else
                { TextBox4.Text = gettext; }

            
            }
            catch (Exception)
            {

                //ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('Unable to find the Data')", true);
                errstr = "Unable to find the Data";
                showpopupmessage(errstr);
                return;
            }
        }

        public void getstoredintoDB(string str)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
            }
            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton1.Attributes.Add("href", "www.linkedin.com/in/iwasimkhan01/");
                LinkButton1.Attributes.Add("target", "_blank");
            }
            catch (Exception ex )
            {

                showpopupmessage(ex.Message);
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox4.Text = "";
        }
        public void showpopupmessage(string geterrstr) {
            try
            {
                string err = geterrstr;
                ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('" + err + "')", true);
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}