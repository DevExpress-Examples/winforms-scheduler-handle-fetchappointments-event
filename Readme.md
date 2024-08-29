<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128635060/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3370)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Scheduler - Fetch appointments when binding to custom objects

This example demonstrates how to handle the [FetchAppointments](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.SchedulerStorageBase.FetchAppointments) event to limit the number of appointments fetched from the data source. The Scheduler Control is bound to a collection of custom objects. 

Do not set the `SchedulerStorage.Appointments` or `SchedulerStorage.Appointments.DataSource` property in the `FetchAppointments` event handler. Update the collection (add/remove items) that is assigned to the `SchedulerStorage.Appointments.DataSource` property.

Read the following help topic for additional information: [FetchAppointments Event - Handling Large Datasets](https://docs.devexpress.com/WindowsForms/8385/controls-and-libraries/scheduler/data-binding/fetchappointments-event-handling-large-datasets).


## Files to Review

* [CustomObjects.cs](./CS/CustomObjects.cs) (VB: [CustomObjects.vb](./VB/CustomObjects.vb))
* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## See Also

* [WinForms Scheduler - Bind to a collection of custom appointments](https://github.com/DevExpress-Examples/winforms-scheduler-bind-to-custom-objects)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-handle-fetchappointments-event&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-handle-fetchappointments-event&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
