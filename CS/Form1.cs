using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace SchedulerFetchCustomObjects {
    public partial class Form1 : Form {
        public static Random RandomInstance = new Random();
        // List with all data items (database imitation)
        private CustomEventList fullDataSource = new CustomEventList();
        private TimeInterval lastFetchedInterval = new TimeInterval();

        public Form1() {
            InitializeComponent();
            schedulerStorage1.Resources.ColorSaving = ColorSavingType.Color;
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitResources();
            InitAppointments();
            schedulerControl1.Start = DateTime.Today;
            UpdateOptions();
        }

        #region Resources generation
        void InitResources() {
            ResourceMappingInfo mappings = this.schedulerStorage1.Resources.Mappings;
            mappings.Id = "ResID";
            mappings.Color = "ResColor";
            mappings.Caption = "Name";

            CustomResourceCollection customResourceCollection = new CustomResourceCollection();
            customResourceCollection.Add(CreateCustomResource(1, "Max Fowler", Color.PowderBlue));
            customResourceCollection.Add(CreateCustomResource(2, "Nancy Drewmore", Color.PaleVioletRed));
            customResourceCollection.Add(CreateCustomResource(3, "Pak Jang", Color.PeachPuff));

            this.schedulerStorage1.Resources.DataSource = customResourceCollection;
        }

        CustomResource CreateCustomResource(int res_id, string caption, Color ResColor) {
            CustomResource cr = new CustomResource();
            cr.ResID = res_id;
            cr.Name = caption;
            cr.ResColor = ResColor;
            return cr;
        }
        #endregion

        #region Appointments generation
        void InitAppointments() {
            AppointmentMappingInfo mappings = this.schedulerStorage1.Appointments.Mappings;
            mappings.Start = "StartTime";
            mappings.End = "EndTime";
            mappings.Subject = "Subject";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "Label";
            mappings.Location = "Location";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "OwnerId";
            mappings.Status = "Status";
            mappings.Type = "EventType";

            // Ppulate the fullDataSource with data items
            GenerateEvents(fullDataSource);

            // Local data list that will be populated in the FetchAppointments evet handler
            CustomEventList actualDataSource = new CustomEventList();

            this.schedulerStorage1.Appointments.DataSource = actualDataSource;
        }

        void GenerateEvents(CustomEventList eventList) {
            int count = schedulerStorage1.Resources.Count;
            for (int i = 0; i < 100; i++) {
                Resource resource = schedulerStorage1.Resources[i % count];
                string subjPrefix = resource.Caption + "'s ";
                eventList.Add(CreateEvent(eventList, subjPrefix + "meeting", resource.Id, 2, 5));
                eventList.Add(CreateEvent(eventList, subjPrefix + "travel", resource.Id, 3, 6));
                eventList.Add(CreateEvent(eventList, subjPrefix + "phone call", resource.Id, 0, 10));
            }
        }

        CustomAppointment CreateEvent(CustomEventList eventList, string subject, object resourceId, int status, int label) {
            CustomAppointment apt = new CustomAppointment(eventList);
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            Random rnd = RandomInstance;
            int rangeInMinutes = 60 * 24;
            apt.StartTime = DateTime.Today + TimeSpan.FromHours(rnd.Next(0, rangeInMinutes));
            apt.EndTime = apt.StartTime + TimeSpan.FromMinutes(60);
            apt.Status = status;
            apt.Label = label;
            return apt;
        }
        #endregion

        private void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e) {
            DateTime start = e.Interval.Start;
            DateTime end = e.Interval.End;

            CustomEventList actualDataSource = this.schedulerStorage1.Appointments.DataSource as CustomEventList;

            if (actualDataSource == null)
                return;

            // Check if the requested interval is outside lastFetchedInterval
            if (start <= lastFetchedInterval.Start || end >= lastFetchedInterval.End) {
                // You can vary margin value to find the most appropriate balance between performance and detalization
                TimeSpan margin = TimeSpan.FromDays(0); // TimeSpan.FromDays(1) 
                lastFetchedInterval = new TimeInterval(start - margin, end + margin);

                // Poplate the actualDataSource using the lastFetchedInterval
                actualDataSource.Clear();
                for (int i = 0; i < fullDataSource.Count; i++) {
                    CustomAppointment customAppointment = fullDataSource[i];

                    if (customAppointment.StartTime >= lastFetchedInterval.Start.Date &&
                        customAppointment.EndTime <= lastFetchedInterval.End.Date) {

                        actualDataSource.Add(customAppointment);
                    }
                }
            }

            lblInfo.Text = string.Format("Interval: {0}, Appointments: {1}", lastFetchedInterval, actualDataSource.Count.ToString());
        }

        private void cbBoldAppointmentDates_CheckedChanged(object sender, EventArgs e) {
            UpdateOptions();
        }

        private void UpdateOptions() {
            dateNavigator1.BoldAppointmentDates = cbBoldAppointmentDates.Checked;
        }
    }
}