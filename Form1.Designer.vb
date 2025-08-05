<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        import = New Button()
        userCountLabel = New Label()
        userListView = New ListView()
        SuspendLayout()
        ' 
        ' import
        ' 
        import.Location = New Point(25, 23)
        import.Name = "import"
        import.Size = New Size(171, 61)
        import.TabIndex = 0
        import.Text = "Import Users From Clipboard"
        import.UseVisualStyleBackColor = True
        ' 
        ' userCountLabel
        ' 
        userCountLabel.Font = New Font("Segoe UI", 12F)
        userCountLabel.Location = New Point(25, 98)
        userCountLabel.Name = "userCountLabel"
        userCountLabel.Size = New Size(183, 37)
        userCountLabel.TabIndex = 2
        userCountLabel.Text = "Imported users: 0"
        ' 
        ' userListView
        ' 
        userListView.Font = New Font("Consolas", 11F)
        userListView.FullRowSelect = True
        userListView.GridLines = True
        userListView.Location = New Point(25, 155)
        userListView.Name = "userListView"
        userListView.Size = New Size(376, 484)
        userListView.TabIndex = 3
        userListView.UseCompatibleStateImageBehavior = False
        userListView.View = View.Details
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1478, 675)
        Controls.Add(import)
        Controls.Add(userListView)
        Controls.Add(userCountLabel)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Friend WithEvents import As Button
    Friend WithEvents userCountLabel As Label
    Friend WithEvents userListView As ListView

End Class
