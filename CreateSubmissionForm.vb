Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class CreateSubmissionForm
    Private elapsedTime As TimeSpan = TimeSpan.Zero
    Private stopwatchRunning As Boolean = False

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles stopwatch_button.Click
        If stopwatchRunning Then
            Timer1.Stop()
        Else
            Timer1.Start()
        End If
        stopwatchRunning = Not stopwatchRunning
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1))
        StopwatchLabel.Text = elapsedTime.ToString("hh\:mm\:ss")
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        ' Code to submit form data
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            submitButton.PerformClick()
        End If
        If e.Control AndAlso e.KeyCode = Keys.T Then
            stopwatch_button.PerformClick()
        End If
    End Sub

    Private Async Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        Dim name As String = NameTextBox.Text
        Dim email As String = EmailTextBox.Text
        Dim phone As String = PhoneTextBox.Text
        Dim githubLink As String = GitHubLinkTextBox.Text
        Dim stopwatchTime As String = StopwatchLabel.Text

        Dim submission As New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        }

        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(submission)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission successful!")
            Else
                MessageBox.Show("Submission failed: " & response.ReasonPhrase)
            End If
        End Using
    End Sub
End Class
