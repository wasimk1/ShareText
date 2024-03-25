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
using System.Web.DynamicData;
using System.Reflection.Emit;

namespace ShareFiles
{
    public partial class home : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection conn;
        DataTable dttest = new DataTable();
        DataTable dtusers = new DataTable();
        string cmdstr = string.Empty;
        string errstr = string.Empty;
        string gettext = string.Empty;
        string getvaluefromdrplist = "";
        private string takevalue = string.Empty;
        DataTable dtgridview = new DataTable();
        DataTable dtdrpfetchusername = new DataTable();
        public static string statownerid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                conn = new SqlConnection(constr);
                conn.Open();
                string takevalue = string.Empty;

                DateTime d = DateTime.Now;
                Lblyear.Text = d.Year.ToString();
                gettext = TextBox3.Text;
                    

                //cmdstr = "select username,id from users";
                //SqlCommand cmd1 = new SqlCommand(cmdstr, conn);
                //SqlDataAdapter sda2 = new SqlDataAdapter(cmd1);
                //sda2.Fill(dtdrpfetchusername);
                //sda2.Dispose();

                //DropDownList2.DataSource = dtdrpfetchusername;
                //DropDownList2.DataBind();
                //DropDownList2.DataTextField = "USERNAME";
                //DropDownList2.DataValueField = "ID";
                //DropDownList2.DataBind();
                //DropDownList2.Items.Insert(0, "Select..");

                if (!IsPostBack)
                {
                    // Validate initially to force asterisks
                    // to appear before the first roundtrip.
                    //tableview.Visible = false;
                    Validate();
                    TextBox5.Text = "";
                    TextBox3.Text = "";

                }
                else
                {
                    // TextBox3.Text = "";

                }




            }
            catch (Exception ex)
            {

                showpopupmessage("Server was not reachable at a moment - " + ex.Message);
                return;
            }



        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string getvaluefromdrplist1 = DropDownList1.SelectedValue.ToString();
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
                else
                {
                    //gettext = TextBox3.Text;
                    string s1 = "'";
                    string s2 = "''";
                    newstr = gettext.Replace(s1, s2);
                    if (gettext.Length > 4500)
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter 4500 character only')", true);
                        errstr = "Please enter 4500 character only";
                        showpopupmessage(errstr);
                        return;
                    }

                    if (DropDownList1.SelectedValue.ToString() == "")
                    {
                        errstr = "Please select the person";
                        showpopupmessage(errstr);
                        return;

                    }
                    if (DropDownList1.SelectedValue.ToString() == "Select..")
                    {
                        errstr = "Please select the valid person";
                        showpopupmessage(errstr);
                        return;
                    }

                    DateTime today = DateTime.Now;
                    string updatedate = "yyyy-MM-dd HH:mm:ss";
                    cmdstr = "insert into SHARE_FILES_TEXT_TAB (TXT_FILE_NAME,DATE_TIME,NUM_USER_UNIQUE_NO,TEXT_OWNER)  values ('" + newstr.Trim() + "','" + today.ToString(updatedate) + "'," + DropDownList1.SelectedValue.ToString() + ","+ statownerid + ")";
                    getstoredintoDB(cmdstr);

                    cmdstr = "select top 1 id from SHARE_FILES_TEXT_TAB order by id desc";
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
                    Label3.Visible=true;
                    TextBox5.Visible=true;
                    TextBox3.Text = "";
                    sdr.Close();
                    conn.Close();


                }


                //DateTime today = DateTime.Now;
                //string updatedate = "yyyy-MM-dd HH:mm:ss";
                //cmdstr = "insert into share_files_tab (TXT_FILE_NAME,DATE_TIME)  values ('" + newstr.Trim() + "','" + today.ToString(updatedate) + "')";
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
                string newerr = errstr.Replace("'", "''");
                showpopupmessage(newerr);

            }


        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int id = 0;
        //        string gettext = string.Empty;

        //        if (System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "[^0-9]"))
        //        {

        //            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please enter numeric only')", true);
        //            errstr = "Please enter numeric only";
        //            showpopupmessage(errstr);
        //            return;

        //        }
        //        else
        //        {
        //            id = Convert.ToInt32(TextBox6.Text);
        //        }
        //        cmdstr = "select TXT_FILE_NAME from SHARE_FILES_TEXT_TAB where id='" + id + "'";
        //        SqlCommand cmd = new SqlCommand(cmdstr, conn);
        //        SqlDataReader sdr = cmd.ExecuteReader();

        //        while (sdr.Read())
        //        {
        //            gettext = sdr["TXT_FILE_NAME"].ToString();
        //        }
        //        if (gettext == "")
        //        {

        //            //ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('" + err + "')", true);
        //            errstr = "There is not data present at ID " + id + ", please enter the valid ID";
        //            showpopupmessage(errstr);
        //        }
        //        else
        //        { TextBox4.Text = gettext; }


        //    }
        //    catch (Exception)
        //    {

        //        //ClientScript.RegisterStartupScript(this.GetType(), "alertMessage", "alert('Unable to find the Data')", true);
        //        errstr = "Unable to find the Data";
        //        showpopupmessage(errstr);
        //        return;
        //    }
        //}

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
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox3.Text = "";
                TextBox5.Text = "";
                //TextBox6.Text = "";
                //TextBox4.Text = "";
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
                return;
            }
            
        }
        public void showpopupmessage(string geterrstr)
        {
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

        protected void btnusersubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string getusername = txtusername.Text.ToUpper();
                //statownerid = getusername;
                cmdstr = "select Username from users where Username='" + getusername + "' ";

                //cmdstr = "SELECT id, username FROM USERS";

                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtusers);
                sda.Dispose();
                if (dtusers.Rows.Count > 0)
                {
                    //DataRow[] myresult = dtusers.Select("[Username] = '"+ getusername + "'");

                    if (getusername == dtusers.Rows[0]["Username"].ToString())
                    {
                        dtusers.Clear();
                        //Label1.Visible = true;
                        //TextBox3.Visible = true;
                        // Button2.Visible = true;
                        //TextBox5.Visible = true;
                        //Label3.Visible = true;
                        //Label4.Visible = true;
                        // DropDownList1.Visible = true;
                        //Button4.Visible = true;

                        cmdstr = "select id,username from users";
                        SqlCommand cmd1 = new SqlCommand(cmdstr, conn);
                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                        sda1.Fill(dtusers);
                        sda1.Dispose();


                        DropDownList1.DataSource = dtusers;
                        DropDownList1.DataBind();
                        DropDownList1.DataTextField = "Username";
                        DropDownList1.DataValueField = "ID";
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, "Select..");

                        //rdbtnreceive.Visible = true;
                        //rdsendbtn.Visible = true;

                        txtusername.ReadOnly = true;
                        btnusersubmit.Enabled = false;
                        LinkButton3.Visible = true;

                        DataTable dtid = new DataTable();
                        cmdstr = "select id from users where Username='" + txtusername.Text.ToUpper() + "'";
                        SqlCommand cmd2 = new SqlCommand(cmdstr, conn);
                        SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                        sda2.Fill(dtid);
                        sda2.Dispose();
                        statownerid = dtid.Rows[0]["ID"].ToString();
                        //tableview.Visible = true;
                        setSendElementToVisible();
                    }

                    else
                    {
                        string err = "There is no data present for the selected username";
                        showpopupmessage(err);
                        return;
                    }



                }
                else
                {
                    string err = "User not found";
                    showpopupmessage(err);
                    //dtusers.Clear();
                    Label1.Visible = false;
                    TextBox3.Visible = false;
                    Button2.Visible = false;
                    TextBox5.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    DropDownList1.Visible = false;
                    Button4.Visible = false;
                    //rdbtnreceive.Visible = false;
                    //rdsendbtn.Visible = false;

                    return;
                }
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
                return;
            }



        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            
            //if (DropDownList2.SelectedValue.ToString() == "Select..")
            //{
            //    string err = "Please select proper user";
            //    showpopupmessage(err);
            //    btnref.Visible = false;
            //    return;

            //}
            //cmdstr = "select st.ID,st.txt_file_name[TEXT],u.ID[USER ID]   from SHARE_FILES_TEXT_TAB st inner join users u on st.NUM_USER_UNIQUE_NO=u.id  where u.id='" + DropDownList1.SelectedValue.ToString() + "'  order by st.id desc  ";
            //SqlCommand cmd = new SqlCommand(cmdstr, conn);
            //SqlDataAdapter sd = new SqlDataAdapter(cmd);

            //sd.Fill(dtgridview);
            //GridView1.DataSource = dtgridview;
            //GridView1.DataBind();
            //sd.Dispose();

            //if (dtgridview.Rows.Count <= 0)
            //{
            //    showpopupmessage("There is no data present at selected User");

            //    return;

            //}

            //if (DropDownList2.SelectedItem.ToString() == "Select..")
            //{
            //    btnref.Visible = false;
            //}
            //else
            //{

            //    btnref.Visible = true;
            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                //string setvalueid = DropDownList2.SelectedValue.ToString();
                cmdstr = "select st.ID,st.txt_file_name[TEXT] from SHARE_FILES_TEXT_TAB st inner join users u on st.NUM_USER_UNIQUE_NO=u.id  order by st.id desc  ";
                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);

                sd.Fill(dtgridview);
                GridView1.DataSource = dtgridview;
                GridView1.DataBind();
                sd.Dispose();


                cmdstr = "select id,username from users";
                SqlCommand cmd1 = new SqlCommand(cmdstr, conn);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                sda1.Fill(dtusers);
                sda1.Dispose();


                DropDownList2.DataSource = dtusers;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "Username";
                DropDownList2.DataValueField = "ID";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "Select..");
                GridView1.Visible = true;

                DropDownList2.Visible = true;
                btnref.Visible = true;
                Label5.Visible = true;

                if (DropDownList2.SelectedValue.ToString() == "Select..")
                {
                    btnref.Visible = false;
                }
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
                return;
            }
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList2.SelectedValue.ToString() == "Select..")
                {
                    string err = "Please select proper user";
                    showpopupmessage(err);
                    btnref.Visible = false;
                    return;

                }
                cmdstr = "select st.ID,st.txt_file_name[TEXT]   from SHARE_FILES_TEXT_TAB st inner join users u on st.NUM_USER_UNIQUE_NO=u.id   where u.id='"+ statownerid + "' order by st.id desc  ";
                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);

                sd.Fill(dtgridview);
                GridView1.DataSource = dtgridview;
                GridView1.DataBind();
                sd.Dispose();

                if (dtgridview.Rows.Count <= 0)
                {
                    showpopupmessage("There is no data present at selected User");

                    return;

                }

                if (DropDownList2.SelectedItem.ToString() == "Select..")
                {
                    btnref.Visible = false;
                }
                else
                {

                    btnref.Visible = true;
                }
            }
            catch (Exception ex) 
            {

                showpopupmessage(ex.Message);
                return;
            }
            
            //dtdrpfetchusername.Clear();
            //cmdstr = "select username,id from users";
            //SqlCommand cmd1 = new SqlCommand(cmdstr, conn);
            //SqlDataAdapter sda2 = new SqlDataAdapter(cmd1);
            //sda2.Fill(dtdrpfetchusername);
            //sda2.Dispose();

            //DropDownList2.DataSource = dtdrpfetchusername;
            //DropDownList2.DataBind();
            //DropDownList2.DataTextField = "Username";
            //DropDownList2.DataValueField = "ID";
            //DropDownList2.DataBind();
            //DropDownList2.Items.Insert(0, "Select..");

            //     foreach (Row as datarow in dtdrpfetchusername.Rows){
            //         if row.Items["ID"] = 10 Then
            ////do something
            //end if


            //     }


            //string rowid = DropDownList2.SelectedValue;
            //if (dtdrpfetchusername.Rows.Count > 0)
            //{
            //    DataRow[] dr = dtdrpfetchusername.Select("[Username]='" + DropDownList2.SelectedItem.ToString() + "'");
            //    if (dr.Length > 0)
            //    {
            //        var get = dr[0]["ID"].ToString();
            //    }

            //}

            //string setvalueid = DropDownList2.SelectedIndex.ToString();
            //cmdstr = "select st.id[ID],st.TXT_FILE_NAME   from SHARE_FILES_TEXT_TAB st inner join users u on st.NUM_USER_UNIQUE_NO=u.id where u.id=" + DropDownList1.SelectedValue.ToString() + "  order by st.id desc  ";
            //SqlCommand cmd = new SqlCommand(cmdstr, conn);
            //SqlDataAdapter sd = new SqlDataAdapter(cmd);

            //sd.Fill(dtgridview);
            //GridView1.DataSource = dtgridview;
            //GridView1.DataBind();
            //sd.Dispose();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList2.SelectedValue.ToString() == "Select..")
                {
                    string err = "Please select proper user";
                    showpopupmessage(err);
                    return;
                }
                cmdstr = "select st.ID,st.txt_file_name[TEXT]   from SHARE_FILES_TEXT_TAB st inner join users u on st.NUM_USER_UNIQUE_NO=u.id  where ='"+ statownerid + "'  order by st.id desc ";
                SqlCommand cmd = new SqlCommand(cmdstr, conn);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);

                sd.Fill(dtgridview);
                GridView1.DataSource = dtgridview;
                GridView1.DataBind();
                sd.Dispose();
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
                return;
            }
            
        }

        protected void rdsendbtn_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Label1.Visible = true;
            //    TextBox3.Visible = true;
            //    Button4.Visible = true;
            //    Label4.Visible = true;
            //    DropDownList1.Visible = true;
            //    Button2.Visible = true;

            //    //TextBox5.Visible = true;
            //    //Label3.Visible = true;
            //    GridView1.Visible = false;

            //    Button5.Visible = false;
            //    DropDownList2.Visible = false;
            //    btnref.Visible = false;
            //    Label5.Visible = false;
            //}
            //catch (Exception ex)
            //{

            //    showpopupmessage(ex.Message);
            //    return;
            //}
           
        }

        protected void rdbtnreceive_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    Button5.Visible = true;
            //    //    DropDownList2.Visible = true;
            //    //    btnref.Visible      = true;
            //    //Label5.Visible = true;


            //    Label1.Visible = false;
            //    TextBox3.Visible = false;
            //    Button4.Visible = false;
            //    Label4.Visible = false;
            //    DropDownList1.Visible = false;
            //    Button2.Visible = false;
            //    TextBox5.Visible = false;
            //    Label3.Visible = false;
            //}
            //catch (Exception ex)
            //{

            //    showpopupmessage(ex.Message); 
            //    return;
            //}
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                txtusername.ReadOnly = false;
                btnusersubmit.Enabled = true;
            }
            catch (Exception ex)
            {

                showpopupmessage(ex.Message);
                return;
            }
            
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                txtusername.Text = "";
                txtusername.ReadOnly = false;
                btnusersubmit.Enabled = true;
                //rdsendbtn.Visible = false;
                //rdsendbtn.Checked= false;
                //rdbtnreceive.Visible = false;
                //rdbtnreceive.Checked= false;
                Label1.Visible = false;
                TextBox3.Visible = false;
                Button4.Visible = false;
                Label4.Visible = false;
                DropDownList1.Visible = false;
                Button2.Visible = false;
                Label3.Visible = false;
                TextBox5.Visible = false;
                Button5.Visible = false;
                Label5.Visible = false;
                DropDownList2.Visible = false;
                btnref.Visible = false;
                GridView1.Visible = false;
                LinkButton3.Visible = false;
                statownerid = "";
                Label6.Visible = false;
                Label8.Visible = false;
                Label7.Visible = false;
                CheckBox1.Visible   = false;
                CheckBox1.Checked=false;
                ////tableview.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string getusername = txtusername.Text.ToUpper();
            //    cmdstr = "select Username from users where Username='" + getusername + "' ";

            //    //cmdstr = "SELECT id, username FROM USERS";

            //    SqlCommand cmd = new SqlCommand(cmdstr, conn);
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dtusers);
            //    sda.Dispose();
            //    if (dtusers.Rows.Count > 0)
            //    {
            //        //DataRow[] myresult = dtusers.Select("[Username] = '"+ getusername + "'");

            //        if (getusername == dtusers.Rows[0]["Username"].ToString())
            //        {
            //            dtusers.Clear();
            //            //Label1.Visible = true;
            //            //TextBox3.Visible = true;
            //            // Button2.Visible = true;
            //            //TextBox5.Visible = true;
            //            //Label3.Visible = true;
            //            //Label4.Visible = true;
            //            // DropDownList1.Visible = true;
            //            //Button4.Visible = true;

            //            cmdstr = "select id,username from users";
            //            SqlCommand cmd1 = new SqlCommand(cmdstr, conn);
            //            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            //            sda1.Fill(dtusers);
            //            sda1.Dispose();


            //            DropDownList1.DataSource = dtusers;
            //            DropDownList1.DataBind();
            //            DropDownList1.DataTextField = "Username";
            //            DropDownList1.DataValueField = "ID";
            //            DropDownList1.DataBind();
            //            DropDownList1.Items.Insert(0, "Select..");

            //            rdbtnreceive.Visible = true;
            //            rdsendbtn.Visible = true;

            //            txtusername.ReadOnly = true;
            //            btnusersubmit.Enabled = false;
            //            LinkButton3.Visible = true;

            //        }

            //        else
            //        {
            //            string err = "There is no data present for the selected username";
            //            showpopupmessage(err);
            //            return;
            //        }



            //    }
            //    else
            //    {
            //        string err = "User not found";
            //        showpopupmessage(err);
            //        //dtusers.Clear();
            //        Label1.Visible = false;
            //        TextBox3.Visible = false;
            //        Button2.Visible = false;
            //        TextBox5.Visible = false;
            //        Label3.Visible = false;
            //        Label4.Visible = false;
            //        DropDownList1.Visible = false;
            //        Button4.Visible = false;
            //        rdbtnreceive.Visible = false;
            //        rdsendbtn.Visible = false;

            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{

            //    showpopupmessage(ex.Message);
            //    return;
            //}
        }

        protected void txtusername_TextChanged(object sender, EventArgs e)
        {

        }


        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string temp = DropDownList2.SelectedValue.ToString();
        //}
        public void setSendElementToVisible() {
            Label6.Visible= true;
            Label1.Visible = true;
            TextBox3.Visible = true;
            Button4.Visible = true;
            Label4.Visible = true;
            DropDownList1.Visible = true;
            Button2.Visible = true;
            Label3.Visible = true;
            TextBox5.Visible = true;
            CheckBox1.Visible=true;
            Label8.Visible = true;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox1.Checked==true)
            {
                Label7.Visible= true;
                Button5.Visible= true;
                Label5.Visible= true;   
                    DropDownList2.Visible = true;
                    btnref.Visible = true;
                //GridView1
                Label8.Visible = false;
            }
            else
            {
                Label7.Visible = false;
                //Label7.Visible = true;
                Button5.Visible = false;
                Label5.Visible = false;
                DropDownList2.Visible = false;
                btnref.Visible = false;
                GridView1.Visible = false;
                Label8.Visible = true;
            }
        }
    }
}