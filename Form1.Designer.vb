<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCreateNewSubmission = New System.Windows.Forms.Button()
        Me.btnViewSubmissions = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCreateNewSubmission
        '
        Me.btnCreateNewSubmission.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCreateNewSubmission.Location = New System.Drawing.Point(226, 228)
        Me.btnCreateNewSubmission.Name = "btnCreateNewSubmission"
        Me.btnCreateNewSubmission.Size = New System.Drawing.Size(321, 47)
        Me.btnCreateNewSubmission.TabIndex = 0
        Me.btnCreateNewSubmission.Text = "Create New Submission (Ctrl+N)"
        Me.btnCreateNewSubmission.UseVisualStyleBackColor = False
        '
        'btnViewSubmissions
        '
        Me.btnViewSubmissions.BackColor = System.Drawing.Color.Gold
        Me.btnViewSubmissions.Location = New System.Drawing.Point(226, 120)
        Me.btnViewSubmissions.Name = "btnViewSubmissions"
        Me.btnViewSubmissions.Size = New System.Drawing.Size(321, 47)
        Me.btnViewSubmissions.TabIndex = 1
        Me.btnViewSubmissions.Text = "View Submissions (Ctrl+V)"
        Me.btnViewSubmissions.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(264, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Soham Ghadge, Slidely AI Task 2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnViewSubmissions)
        Me.Controls.Add(Me.btnCreateNewSubmission)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCreateNewSubmission As Button
    Friend WithEvents btnViewSubmissions As Button
    Friend WithEvents Label1 As Label
End Class
