Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Dictionary(Of String, String))

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Function LoadSubmission(index As Integer) As Task
        Using client As New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync("http://localhost:3000/read?index=" & index)
            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Dim submission As Dictionary(Of String, String) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)
                NameTextBox.Text = submission("name")
                EmailTextBox.Text = submission("email")
                PhoneTextBox.Text = submission("phone")
                GitHubLinkTextBox.Text = submission("github_link")
                StopwatchTextBox.Text = submission("stopwatch_time")
            Else
                MessageBox.Show("Failed to load submission: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Async Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles PreviousButton.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadSubmission(currentIndex)
        End If
    End Sub

    Private Async Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        currentIndex += 1
        Await LoadSubmission(currentIndex)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles StopwatchTextBox.TextChanged

    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            PreviousButton.PerformClick()
        End If
        If e.Control AndAlso e.KeyCode = Keys.N Then
            NextButton.PerformClick()
        End If
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles deleteButton.Click
        Dim index As Integer = currentIndex
        Dim url As String = "http://localhost:3000/delete"

        Using client As New HttpClient()
            Dim request As New HttpRequestMessage(HttpMethod.Delete, url)
            Dim jsonData As String = "{""index"":" & index & "}"
            request.Content = New StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await client.SendAsync(request)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission deleted successfully!")
                If currentIndex > 0 Then
                    currentIndex -= 1
                End If
                Await LoadSubmission(currentIndex)
            Else
                MessageBox.Show("Failed to delete submission: " & response.ReasonPhrase)
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles editButton.Click
        ' Allow the user to edit the fields
        NameTextBox.ReadOnly = False
        EmailTextBox.ReadOnly = False
        PhoneTextBox.ReadOnly = False
        GitHubLinkTextBox.ReadOnly = False
        StopwatchTextBox.ReadOnly = False

        btnSaveEdit.Visible = True
    End Sub

    Private Async Sub btnSaveEdit_Click(sender As Object, e As EventArgs) Handles btnSaveEdit.Click
        ' Save the edited fields
        Dim index As Integer = currentIndex
        Dim updatedSubmission As New Dictionary(Of String, String) From {
            {"index", index.ToString()},
            {"name", NameTextBox.Text},
            {"email", EmailTextBox.Text},
            {"phone", PhoneTextBox.Text},
            {"github_link", GitHubLinkTextBox.Text},
            {"stopwatch_time", StopwatchTextBox.Text}
        }

        Dim url As String = "http://localhost:3000/update"

        Using client As New HttpClient()
            Dim jsonData As String = Newtonsoft.Json.JsonConvert.SerializeObject(updatedSubmission)
            Dim content As New StringContent(jsonData, System.Text.Encoding.UTF8, "application/json")
            Dim response As HttpResponseMessage = Await client.PutAsync(url, content)
            If response.IsSuccessStatusCode Then
                MessageBox.Show("Submission updated successfully!")
                ' Set the textboxes back to read-only
                NameTextBox.ReadOnly = True
                EmailTextBox.ReadOnly = True
                PhoneTextBox.ReadOnly = True
                GitHubLinkTextBox.ReadOnly = True
                StopwatchTextBox.ReadOnly = True

                btnSaveEdit.Visible = False
            Else
                MessageBox.Show("Failed to update submission: " & response.ReasonPhrase)
            End If
        End Using
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles editButton.Click

    End Sub
End Class
