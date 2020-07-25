using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SafeAutoCodeKata
{
    public partial class CodeKata : Form
    {
        /// <summary>
        /// Static constructor of the Drivers class
        /// </summary>
        public static List<Drivers> DriverList = new List<Drivers>();

        /// <summary>
        /// Static constructor of the Trips class
        /// </summary>
        public static List<Trips> TripList = new List<Trips>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeKata()
        {
            InitializeComponent();

            //Only allows to select text files
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };
        }

        /// <summary>
        /// Obtains and loads data for Drivers and Trips
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Clear the text box proccess
                    TxbProccess.Text = "";
                    using (StreamReader str = new StreamReader(openFileDialog1.OpenFile()))
                    {
                        while (!str.EndOfStream)
                        {
                            string line = str.ReadLine();
                            if (!String.IsNullOrEmpty(line))
                            {
                                //DRIVER
                                if (line.ToLower().StartsWith("driver"))
                                {
                                    if (line.IndexOf(" ") > 0)
                                    {
                                        //Check if exist a valid name
                                        if (Transactions.CheckNames(line.Substring(line.IndexOf(" "))))
                                        {
                                            //Add new driver in DriverList
                                            string NameDriver = Transactions.FirstLetterToUpper(line.Substring(line.IndexOf(" ")));
                                            AddDriver(NameDriver.Trim());
                                        }
                                    }
                                }
                                //TRIP
                                else if (line.ToLower().StartsWith("trip"))
                                {
                                    //save the Trip data in array
                                    string[] tripsData = line.Replace("  ", " ").Split(' ');
                                    if(tripsData.Length == 5)
                                    {
                                        //Check driver name
                                        if (Transactions.CheckNames(tripsData[1].Trim()))
                                        {
                                            //Validate departure hour
                                            if (Transactions.CheckHour(tripsData[2].Trim()))
                                            {
                                                //Validate arrival hour and hours range 
                                                if (Transactions.CheckHour(tripsData[3].Trim()) && Transactions.ValidateHoursRange(tripsData[2].Trim(), tripsData[3].Trim()))
                                                {
                                                    //Validate milles data
                                                    if (Transactions.ValidateMilles(tripsData[4].Trim()))
                                                    {
                                                        //Add new trip in TripList
                                                        AddTrip(tripsData);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //The selected document does not have the required format or is empty
                    if (TxbProccess.Text == "")
                    {
                        TxbProccess.AppendText($"The selected document does not have the required format or is empty");
                        TxbProccess.AppendText(Environment.NewLine);
                    }
                    TxbProccess.AppendText(Environment.NewLine);
                }
                catch(Exception ex)
                {
                    TxbProccess.AppendText($"Error: {ex.Message}");
                    TxbProccess.AppendText(Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Add Drivers in DriverList
        /// </summary>
        /// <param name="DriverName"></param>
        void AddDriver(string DriverName)
        {
            try
            {
                //Check if the driver exist
                int numCount =
                   (from dlCount in DriverList
                    where dlCount.Name.Trim().ToLower().Equals(DriverName.Trim().ToLower())
                    select dlCount).Count();

                if (numCount == 0)
                {
                    //Add new driver
                    DriverList.Add(new Drivers() { Id = DriverList.Count > 0 ? DriverList.Count + 1 : 1, Name = Transactions.FirstLetterToUpper(DriverName.Trim()) });
                    TxbProccess.AppendText($"Added driver {DriverName.Trim()}");
                    TxbProccess.AppendText(Environment.NewLine);
                }
                else
                {
                    //The driver exist, show message
                    TxbProccess.AppendText($"The driver {DriverName.Trim()} is already registered");
                    TxbProccess.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                TxbProccess.AppendText($"Error: {ex.Message}");
                TxbProccess.AppendText(Environment.NewLine);
            }

        }

        /// <summary>
        /// Add Trips in TripList
        /// </summary>
        /// <param name="tripsData"></param>
        void AddTrip(string[] tripsData)
        {
            try
            {
                //Check if the driver exists in the DriveList
                int numCount =
                    (from dlCount in DriverList
                     where dlCount.Name.Trim().ToLower().Equals(tripsData[1].Trim().ToLower())
                     select dlCount).Count();

                //If not exist the driver in the DriverList, is created and added to the two lists
                if (numCount == 0)
                {
                    AddDriver(Transactions.FirstLetterToUpper(tripsData[1]));
                    TripList.Add(new Trips() { Name = Transactions.FirstLetterToUpper(tripsData[1].Trim()), StartHour = tripsData[2].Trim(), EndHour = tripsData[3].Trim(), Distance = tripsData[4].Trim() });
                    TxbProccess.AppendText($"Added driver {Transactions.FirstLetterToUpper(tripsData[1].Trim())}");
                    TxbProccess.AppendText(Environment.NewLine);
                    TxbProccess.AppendText($"Added trip to {Transactions.FirstLetterToUpper(tripsData[1].Trim())}");
                    TxbProccess.AppendText(Environment.NewLine);
                }
                //Add Trip to TripList
                else
                {
                    TripList.Add(new Trips() { Name = Transactions.FirstLetterToUpper(tripsData[1].Trim()), StartHour = tripsData[2].Trim(), EndHour = tripsData[3].Trim(), Distance = tripsData[4].Trim() });
                    TxbProccess.AppendText($"Added trip to {Transactions.FirstLetterToUpper(tripsData[1].Trim())}");
                    TxbProccess.AppendText(Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                TxbProccess.AppendText($"Error: {ex.Message}");
                TxbProccess.AppendText(Environment.NewLine);
            }
        }

        /// <summary>
        /// Show the report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTrip(TripList);
            }
            catch (Exception ex)
            {
                TxbProccess.AppendText($"Error: {ex.Message}");
                TxbProccess.AppendText(Environment.NewLine);
            }
        }

        /// <summary>
        /// Method used to fill in and display the Trip information
        /// </summary>
        /// <param name="list"></param>
        public void DisplayTrip(List<Trips> list)
        {
            try
            {
                //check if the TripList have data
                if (list.Count == 0)
                {
                    //No data
                    TxbProccess.AppendText($"No loaded trips, please load the file with at least one trip");
                    TxbProccess.AppendText(Environment.NewLine);
                }
                else
                {
                    //Calculate an add the averagge velocity
                    for (int indx = 0; indx < list.Count; indx++)
                    {
                        if (!String.IsNullOrEmpty(list[indx].StartHour) && !String.IsNullOrEmpty(list[indx].EndHour) && !String.IsNullOrEmpty(list[indx].Distance))
                        {
                            double VelocityAvg = Transactions.CalculateVelocity(list[indx].StartHour, list[indx].EndHour, list[indx].Distance);
                            list[indx].Velocity = VelocityAvg.ToString();
                        }
                    }
                    //Check DriverList and add drivers from TripList when not exist
                    foreach (Drivers dri in DriverList)
                    {
                        int numCount =
                            (from count in list
                             where count.Name == dri.Name
                             select count).Count();

                        if (numCount == 0)
                            list.Add(new Trips() { Name = dri.Name });
                    }

                    //get the filtred result from TripList (excludes speeds greater than 100 and less than 5 milles)
                    var result = list.GroupBy(d => d.Name)
                                .Select(
                                    g => new
                                    {
                                        Name = g.Key,
                                        Distance = g.Sum(s => s.Distance == null ? 0 : Double.Parse(s.Distance)),
                                        Velocity = g.Average(s => s.Velocity == null ? 0 : Double.Parse(s.Velocity))
                                    })
                                .Where(x => (x.Velocity > 5 && x.Velocity < 100) || x.Velocity == 0)
                                .OrderByDescending(
                                    s => s.Distance)
                                ;

                    //Show the data in TextBox Proccess
                    foreach (var item in result)
                    {
                        TxbProccess.AppendText($"{item.Name}: {Convert.ToInt32(item.Distance)} milles @ {Convert.ToInt32(item.Velocity)} MPH");
                        TxbProccess.AppendText(Environment.NewLine);
                    }
                }
                TxbProccess.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                TxbProccess.AppendText($"Error: {ex.Message}");
                TxbProccess.AppendText(Environment.NewLine);
            }
        }
    }
}
