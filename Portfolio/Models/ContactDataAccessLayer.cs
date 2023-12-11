using Microsoft.Data.SqlClient;
using System.Data;

namespace Portfolio.Models
{
    public class ContactDataAccessLayer
    {
        string connectionString = "Server = sql.bsite.net\\MSSQL2016;Database =kshitij_;User ID = kshitij_; Password=Jain1530@.com;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security = false;";

        // to view all conacts details 
        public IEnumerable<Contact> GetAllContacts()
        {
            List<Contact> contact = new List<Contact>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GETALLCONTACTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Contact cont = new Contact();
                    cont.ID = Convert.ToInt32(reader["ID"]);
                    cont.Name = reader["NAME"].ToString();
                    cont.Email = reader["EMAIL"].ToString();
                    cont.Phone = reader["PHONE"].ToString(); 
                    cont.Message = reader["MESSAGE"].ToString();

                    contact.Add(cont);


                }
                con.Close();
            }
            return contact;
        }



        // to create new contact
        public void AddContact(Contact contact)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addcontact", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NAME", contact.Name);
                cmd.Parameters.AddWithValue("@EMAIL", contact.Email);
                cmd.Parameters.AddWithValue("@PHONE", contact.Phone);
                cmd.Parameters.AddWithValue("@MESSAGE", contact.Message);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        // get details of a particular contact
        public Contact GetContactData(int? id)
        {
            Contact contact = new Contact();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "Select * FROM Contact WHERE ID=" + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    contact.ID = Convert.ToInt32(rdr["ID"]);
                    contact.Name = rdr["NAME"].ToString();
                    contact.Email = rdr["EMAIL"].ToString();
                    contact.Phone = rdr["PHONE"].ToString();
                    contact.Message = rdr["MESSAGE"].ToString();
                }
            }
            return contact;
        }


        //To Delete the record on a particular employee  
        public void DeleteContact(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETECONTACT", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
