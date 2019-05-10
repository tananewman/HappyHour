using Contacts.ProximityScanner;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
using EventAttendanceApp;

namespace EventAttendanceApp
{
	public partial class EventAttendanceForm : Form
    {
        private List<EmployeeModel> _employees = new List<EmployeeModel>();
	    private List<BadgeAndPicture> _badgeAndPicture = new List<BadgeAndPicture>();

        public EventAttendanceForm()
        {
            InitializeComponent();
            LoadEmployeeList();
			BuildTempDirectory();
        }

        private void LoadEmployeeList()
        {
            _employees = SqliteDataAccess.LoadEmployees();
        }

        private void EventAttendanceForm_Load(object sender, EventArgs e)
        {
            IProximityConnector ipc = new ProximityConnector();
            ipc.Connect();
            ipc.OnScan += ipc_OnScan;
            this.WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            lblWelcome.Visible = false;
            pbPicture.Visible = false;
	        acceptBtn.Visible = false;
        }

        void ipc_OnScan(object sender, ProximityConnectorEventArgs e)
        {
            if (LblScanBadge.Visible == false)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() => ipc_OnScan(sender, e)));
                return;
            }
            var t = new RestClient();
            var badgeNumber = e.BadgeNumber.ToString();

			//tmp
	        var badgeAndPicture = FindMatchingBadge(badgeNumber);
			var jsonStr = t.Get(ConfigurationManager.AppSettings["CardUrl"] + badgeAndPicture.LongId);
			var user = JsonConvert.DeserializeObject<CardUser>(jsonStr);

            if (user != null)
            {
                //Hide Scan Badge
                LblScanBadge.Visible = false;

                //Get Image
	            string filename = @ConfigurationManager.AppSettings["PictureLocation"] + badgeAndPicture.PhotoPath;
	            //string filename = @"\\ctac\service\Pictures\P1960-Darian Everett.jpg";
				pbPicture.Image = Bitmap.FromFile(filename);
                pbPicture.Visible = true;

                //Show Name
                lblWelcome.Text = "Welcome " + user.FirstName + " " + user.LastName;
                lblWelcome.Left = (ClientSize.Width - lblWelcome.Width) / 2;
                lblWelcome.Visible = true;

	            if (badgeAndPicture.Age < 21)
	            {
		            rejectBtn.Text = "Under 21!";
		            rejectBtn.Visible = true;
		            return;
	            }
				else if (badgeAndPicture.DrinkCount > 2)
	            {
		            rejectBtn.Text = "Over Drink Limit!";
		            rejectBtn.Visible = true;
		            return;
	            }

	            badgeAndPicture.DrinkCount++;

				//TODO currently this is just newing up an employee, we're going to need to check if the user has already had drinks
	            acceptBtn.Visible = true;

                // db work
                var emp = _employees.Find(x => x.EmployeeId == user.CampusId);

                if (emp == null)
                {
                    emp = new EmployeeModel
                    {
                        EmployeeId = user.CampusId,
                        EmployeeName = user.FirstName + " " + user.LastName
                    };
                }

                emp.DrinksToday++;
                emp.LastLogin = DateTime.Today;

                SqliteDataAccess.SaveEmployee(emp);
            }
        }

		//tmp
	    private BadgeAndPicture FindMatchingBadge(string shortBadgeId)
	    {
		    var recordFound = _badgeAndPicture.FirstOrDefault(b => b.ShortId.Equals(shortBadgeId));
		    return recordFound ?? _badgeAndPicture.First();
	    }

        private void EventAttendanceForm_Resize(object sender, EventArgs e)
        {
            pbLogo.Left = (this.ClientSize.Width - pbLogo.Width) / 2;
            LblScanBadge.Left = pbLogo.Left + ((pbLogo.Width - LblScanBadge.Width) / 2);
            LblScanBadge.Top = this.ClientSize.Height / 2;
            LblScanBadge.Visible = true;
            lblWelcome.Left = (this.ClientSize.Width - lblWelcome.Width) / 2;
            pbPicture.Left = (this.ClientSize.Width - pbPicture.Width) / 2;
			acceptBtn.Left = ((this.ClientSize.Width - pbPicture.Width) / 2);
	        rejectBtn.Left = ((this.ClientSize.Width - pbPicture.Width) / 2);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pbPicture.Visible = false;
			acceptBtn.Visible = false;
			rejectBtn.Visible = false;
			lblWelcome.Visible = false;
			LblScanBadge.Visible = true;
        }

	    private void button2_Click(object sender, EventArgs e)
	    {
		    pbPicture.Visible = false;
		    acceptBtn.Visible = false;
		    rejectBtn.Visible = false;
			lblWelcome.Visible = false;
		    LblScanBadge.Visible = true;
	    }

		//tmp
		private void BuildTempDirectory()
	    {
			_badgeAndPicture.Add(new BadgeAndPicture
			{
				ShortId = "49219",
				LongId = "12003164227",
				PhotoPath = @"P1960-Darian Everett.jpg",
				Age = 32
			});
			_badgeAndPicture.Add(new BadgeAndPicture
			{
				ShortId = "49607",
				LongId = "12003164075",
				PhotoPath = @"P129-Montana Newman.JPG",
				Age = 28
			});
			_badgeAndPicture.Add(new BadgeAndPicture
			{
				ShortId = "48787",
				LongId = "12003163795",
				PhotoPath = "P2208-Jenny Mahler.jpg",
				Age = 20
			});
	    }
	}
	public class RestClient
    {
        public string Get(string uri)
        {
	        string result;

            using (var webClient = new WebClient { UseDefaultCredentials = true, CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache) })
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                try
                {
                    result = webClient.DownloadString(uri);
                }
                catch
                {
                    return "";
                }
            }

            return result;
        }
    }
    public class CardUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PicturePath { get; set; }
        public int? FitnessId { get; set; }
        public int CampusId { get; set; }
        public bool IsAdmin { get; set; }
        public string AccountName { get; set; }
        public string Sid { get; set; }
    }

	class OvalPictureBox : PictureBox
	{
		public OvalPictureBox()
		{
			this.BackColor = Color.DarkGray;
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			using (var gp = new GraphicsPath())
			{
				gp.AddEllipse(0, 0, this.Width, this.Height - 3);
				Region rg = new Region(gp);
				this.Region = rg;
			}
		}
	}

	class RoundedButton : Button
	{
		GraphicsPath GetRoundPath(RectangleF Rect, int radius)
		{
			float r2 = radius / 2f;
			GraphicsPath GraphPath = new GraphicsPath();

			GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
			GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
			GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
			GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
			GraphPath.AddArc(Rect.X + Rect.Width - radius,
				Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
			GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
			GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
			GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

			GraphPath.CloseFigure();
			return GraphPath;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
			GraphicsPath GraphPath = GetRoundPath(Rect, 50);

			this.Region = new Region(GraphPath);
			using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
			{
				pen.Alignment = PenAlignment.Inset;
				e.Graphics.DrawPath(pen, GraphPath);
			}
		}
	}

	class BadgeAndPicture
	{
		public string ShortId { get; set; }
		public string LongId { get; set; }
		public string PhotoPath { get; set; }
		public int Age { get; set; }

		//TMP in case can't get db working in time
		public int DrinkCount { get; set; }

		public BadgeAndPicture()
		{
			DrinkCount = 0;
		}
	}

}
