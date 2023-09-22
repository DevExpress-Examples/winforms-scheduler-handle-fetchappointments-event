Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler

Namespace SchedulerFetchCustomObjects

    Public Partial Class Form1
        Inherits Form

        Public Shared RandomInstance As Random = New Random()

        ' List with all data items (database imitation)
        Private fullDataSource As CustomEventList = New CustomEventList()

        Private lastFetchedInterval As TimeInterval = New TimeInterval()

        Public Sub New()
            InitializeComponent()
            schedulerStorage1.Resources.ColorSaving = ColorSavingType.Color
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            InitResources()
            InitAppointments()
            schedulerControl1.Start = Date.Today
            UpdateOptions()
        End Sub

'#Region "Resources generation"
        Private Sub InitResources()
            Dim mappings As ResourceMappingInfo = schedulerStorage1.Resources.Mappings
            mappings.Id = "ResID"
            mappings.Color = "ResColor"
            mappings.Caption = "Name"
            Dim customResourceCollection As CustomResourceCollection = New CustomResourceCollection()
            customResourceCollection.Add(CreateCustomResource(1, "Max Fowler", Color.PowderBlue))
            customResourceCollection.Add(CreateCustomResource(2, "Nancy Drewmore", Color.PaleVioletRed))
            customResourceCollection.Add(CreateCustomResource(3, "Pak Jang", Color.PeachPuff))
            schedulerStorage1.Resources.DataSource = customResourceCollection
        End Sub

        Private Function CreateCustomResource(ByVal res_id As Integer, ByVal caption As String, ByVal ResColor As Color) As CustomResource
            Dim cr As CustomResource = New CustomResource()
            cr.ResID = res_id
            cr.Name = caption
            cr.ResColor = ResColor
            Return cr
        End Function

'#End Region
'#Region "Appointments generation"
        Private Sub InitAppointments()
            Dim mappings As AppointmentMappingInfo = schedulerStorage1.Appointments.Mappings
            mappings.Start = "StartTime"
            mappings.End = "EndTime"
            mappings.Subject = "Subject"
            mappings.AllDay = "AllDay"
            mappings.Description = "Description"
            mappings.Label = "Label"
            mappings.Location = "Location"
            mappings.RecurrenceInfo = "RecurrenceInfo"
            mappings.ReminderInfo = "ReminderInfo"
            mappings.ResourceId = "OwnerId"
            mappings.Status = "Status"
            mappings.Type = "EventType"
            ' Ppulate the fullDataSource with data items
            GenerateEvents(fullDataSource)
            ' Local data list that will be populated in the FetchAppointments evet handler
            Dim actualDataSource As CustomEventList = New CustomEventList()
            schedulerStorage1.Appointments.DataSource = actualDataSource
        End Sub

        Private Sub GenerateEvents(ByVal eventList As CustomEventList)
            Dim count As Integer = schedulerStorage1.Resources.Count
            For i As Integer = 0 To 100 - 1
                Dim resource As Resource = schedulerStorage1.Resources(i Mod count)
                Dim subjPrefix As String = resource.Caption & "'s "
                eventList.Add(CreateEvent(eventList, subjPrefix & "meeting", resource.Id, 2, 5))
                eventList.Add(CreateEvent(eventList, subjPrefix & "travel", resource.Id, 3, 6))
                eventList.Add(CreateEvent(eventList, subjPrefix & "phone call", resource.Id, 0, 10))
            Next
        End Sub

        Private Function CreateEvent(ByVal eventList As CustomEventList, ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As CustomAppointment
            Dim apt As CustomAppointment = New CustomAppointment(eventList)
            apt.Subject = subject
            apt.OwnerId = resourceId
            Dim rnd As Random = RandomInstance
            Dim rangeInMinutes As Integer = 60 * 24
            apt.StartTime = Date.Today + TimeSpan.FromHours(rnd.Next(0, rangeInMinutes))
            apt.EndTime = apt.StartTime + TimeSpan.FromMinutes(60)
            apt.Status = status
            apt.Label = label
            Return apt
        End Function

'#End Region
        Private Sub schedulerStorage1_FetchAppointments(ByVal sender As Object, ByVal e As FetchAppointmentsEventArgs)
            Dim start As Date = e.Interval.Start
            Dim [end] As Date = e.Interval.End
            Dim actualDataSource As CustomEventList = TryCast(schedulerStorage1.Appointments.DataSource, CustomEventList)
            If actualDataSource Is Nothing Then Return
            ' Check if the requested interval is outside lastFetchedInterval
            If start <= lastFetchedInterval.Start OrElse [end] >= lastFetchedInterval.End Then
                ' You can vary margin value to find the most appropriate balance between performance and detalization
                Dim margin As TimeSpan = TimeSpan.FromDays(0) ' TimeSpan.FromDays(1) 
                lastFetchedInterval = New TimeInterval(start - margin, [end] + margin)
                ' Poplate the actualDataSource using the lastFetchedInterval
                actualDataSource.Clear()
                For i As Integer = 0 To fullDataSource.Count - 1
                    Dim customAppointment As CustomAppointment = fullDataSource(i)
                    If customAppointment.StartTime >= lastFetchedInterval.Start.Date AndAlso customAppointment.EndTime <= lastFetchedInterval.End.Date Then
                        actualDataSource.Add(customAppointment)
                    End If
                Next
            End If

            lblInfo.Text = String.Format("Interval: {0}, Appointments: {1}", lastFetchedInterval, actualDataSource.Count.ToString())
        End Sub

        Private Sub cbBoldAppointmentDates_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateOptions()
        End Sub

        Private Sub UpdateOptions()
            dateNavigator1.BoldAppointmentDates = cbBoldAppointmentDates.Checked
        End Sub
    End Class
End Namespace
