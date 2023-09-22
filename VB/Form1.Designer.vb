Namespace SchedulerFetchCustomObjects

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler4 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.lblInfo = New System.Windows.Forms.Label()
            Me.cbBoldAppointmentDates = New System.Windows.Forms.CheckBox()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.dateNavigator1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 30)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(584, 326)
            Me.schedulerControl1.Start = New System.DateTime(2008, 10, 31, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler3)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler4)
            ' 
            ' schedulerStorage1
            ' 
            AddHandler Me.schedulerStorage1.FetchAppointments, New DevExpress.XtraScheduler.FetchAppointmentsEventHandler(AddressOf Me.schedulerStorage1_FetchAppointments)
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.BoldAppointmentDates = False
            Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
            Me.dateNavigator1.HotDate = Nothing
            Me.dateNavigator1.Location = New System.Drawing.Point(584, 30)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(179, 326)
            Me.dateNavigator1.TabIndex = 1
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Controls.Add(Me.cbBoldAppointmentDates)
            Me.panelControl1.Controls.Add(Me.lblInfo)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(763, 30)
            Me.panelControl1.TabIndex = 2
            ' 
            ' lblInfo
            ' 
            Me.lblInfo.AutoSize = True
            Me.lblInfo.Location = New System.Drawing.Point(213, 7)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(35, 13)
            Me.lblInfo.TabIndex = 0
            Me.lblInfo.Text = "lblInfo"
            ' 
            ' cbBoldAppointmentDates
            ' 
            Me.cbBoldAppointmentDates.AutoSize = True
            Me.cbBoldAppointmentDates.Location = New System.Drawing.Point(13, 6)
            Me.cbBoldAppointmentDates.Name = "cbBoldAppointmentDates"
            Me.cbBoldAppointmentDates.Size = New System.Drawing.Size(134, 17)
            Me.cbBoldAppointmentDates.TabIndex = 1
            Me.cbBoldAppointmentDates.Text = "BoldAppointmentDates"
            Me.cbBoldAppointmentDates.UseVisualStyleBackColor = True
            AddHandler Me.cbBoldAppointmentDates.CheckedChanged, New System.EventHandler(AddressOf Me.cbBoldAppointmentDates_CheckedChanged)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(763, 356)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.dateNavigator1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.panelControl1.PerformLayout()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private lblInfo As System.Windows.Forms.Label

        Private cbBoldAppointmentDates As System.Windows.Forms.CheckBox
    End Class
End Namespace
