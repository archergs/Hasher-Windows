using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Hasher
{
    public partial class Form1 : Form
    {

        // user input string
        public string userString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            userString = userText.Text;
            computeHashes(userString);
        }

        private void computeHashes(string text)
        {
            // hashed strings
            string md5Hash;
            string sha1Hash;
            string sha256Hash;
            string sha512Hash;

            // Create MD5 hash from string
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
                md5Hash = buildString(hash);
                md5Output.Text = md5Hash;
            }

            // Create SHA1 hash from string
            // Use input string to calculate SHA1 hash
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                sha1Hash = buildString(hash);
                sha1Output.Text = sha1Hash;
            }

            using (SHA256Managed sha256 = new SHA256Managed())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                sha256Hash = buildString(hash);
                sha256Output.Text = sha256Hash;
            }

            using (SHA512Managed sha512 = new SHA512Managed())
            {
                var hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                sha512Hash = buildString(hash);
                sha512Output.Text = sha512Hash;
            }
        }

        private string buildString(byte[] hash)
        {
            var sb = new StringBuilder(hash.Length * 2);

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        private void UserText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(this, new EventArgs());
            }
        }
    }
}
