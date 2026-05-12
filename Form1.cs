using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace The_Maritime_Shipping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=MaritimeShippingDB;Integrated Security=True");

            string query = "INSERT INTO CLIENT (CLIENTID, NAME, CONTACTINFO) VALUES (@id, @name, @contact)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", txtClientID.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Client Added Successfully");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=MaritimeShippingDB;Integrated Security=True");

            string query = @"SELECT
    v.VoyageID,
    vessel.RegistrationNumber,
    departure.PortName AS DeparturePort,
    arrival.PortName AS ArrivalPort,
    v.DepartureDate,
    v.ArrivalDate,
    v.VoyageStatus
    FROM VOYAGE v
    JOIN VESSEL vessel ON v.VesselID = vessel.VesselID
    JOIN PORT departure ON v.DeparturePortCode = departure.PortCode
    JOIN PORT arrival ON v.ArrivalPortCode = arrival.PortCode";

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
