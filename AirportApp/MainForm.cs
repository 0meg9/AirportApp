using System;
using System.Windows.Forms;

namespace AirportApp
{
    public partial class MainForm : Form
    {
        private FlightManager flightManager;

        public MainForm()
        {
            InitializeComponent();
            flightManager = new FlightManager();
        }

        private void InitializeComponent()
        {
            this.Text = "Аеропорт";
            this.Size = new System.Drawing.Size(800, 600);

            
            Label lblFlightNumber = new Label { Text = "Номер рейсу:", Location = new System.Drawing.Point(10, 10), Width = 100 };
            TextBox txtFlightNumber = new TextBox { Location = new System.Drawing.Point(120, 10), Width = 200 };

            Label lblPlaneName = new Label { Text = "Назва літака:", Location = new System.Drawing.Point(10, 40), Width = 100 };
            TextBox txtPlaneName = new TextBox { Location = new System.Drawing.Point(120, 40), Width = 200 };

            Label lblDeparture = new Label { Text = "Відправлення:", Location = new System.Drawing.Point(10, 70), Width = 100 };
            TextBox txtDeparture = new TextBox { Location = new System.Drawing.Point(120, 70), Width = 200 };

            Label lblDestination = new Label { Text = "Призначення:", Location = new System.Drawing.Point(10, 100), Width = 100 };
            TextBox txtDestination = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 200 };

            Label lblDepartureTime = new Label { Text = "Час відправлення:", Location = new System.Drawing.Point(10, 130), Width = 100 };
            TextBox txtDepartureTime = new TextBox { Location = new System.Drawing.Point(120, 130), Width = 200 };

            Label lblArrivalTime = new Label { Text = "Час прибуття:", Location = new System.Drawing.Point(10, 160), Width = 100 };
            TextBox txtArrivalTime = new TextBox { Location = new System.Drawing.Point(120, 160), Width = 200 };

            Label lblTicketPrice = new Label { Text = "Ціна квитка:", Location = new System.Drawing.Point(10, 190), Width = 100 };
            TextBox txtTicketPrice = new TextBox { Location = new System.Drawing.Point(120, 190), Width = 200 };

            Button btnAddFlight = new Button { Text = "Додати рейс", Location = new System.Drawing.Point(120, 220), Width = 100 };
            Button btnRemoveFlight = new Button { Text = "Видалити рейс", Location = new System.Drawing.Point(230, 220), Width = 100 };
            Button btnViewFlights = new Button { Text = "Переглянути рейси", Location = new System.Drawing.Point(340, 220), Width = 100 };

            ListBox lstFlights = new ListBox { Location = new System.Drawing.Point(10, 260), Size = new System.Drawing.Size(760, 300 )};

            
            btnAddFlight.Click += (s, e) =>
            {
                try
                {
                    Flight flight = new Flight(
                        txtFlightNumber.Text,
                        txtPlaneName.Text,
                        txtDeparture.Text,
                        txtDestination.Text,
                        txtDepartureTime.Text,
                        txtArrivalTime.Text,
                        decimal.Parse(txtTicketPrice.Text)
                    );
                    flightManager.AddFlight(flight);
                    MessageBox.Show("Рейс додано!");
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            };

            btnRemoveFlight.Click += (s, e) =>
            {
                if (flightManager.RemoveFlight(txtFlightNumber.Text))
                {
                    MessageBox.Show("Рейс видалено!");
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Рейс не знайдено!");
                }
            };

            btnViewFlights.Click += (s, e) =>
            {
                lstFlights.Items.Clear();
                foreach (Flight flight in flightManager.GetAllFlights())
                {
                    lstFlights.Items.Add(flight.ToString());
                }
            };

            // Додавання елементів на форму
            this.Controls.AddRange(new Control[] { lblFlightNumber, txtFlightNumber, lblPlaneName, txtPlaneName,
                lblDeparture, txtDeparture, lblDestination, txtDestination, lblDepartureTime, txtDepartureTime,
                lblArrivalTime, txtArrivalTime, lblTicketPrice, txtTicketPrice, btnAddFlight, btnRemoveFlight,
                btnViewFlights, lstFlights });

            void ClearInputs()
            {
                txtFlightNumber.Clear();
                txtPlaneName.Clear();
                txtDeparture.Clear();
                txtDestination.Clear();
                txtDepartureTime.Clear();
                txtArrivalTime.Clear();
                txtTicketPrice.Clear();
            }
        }
    }
}