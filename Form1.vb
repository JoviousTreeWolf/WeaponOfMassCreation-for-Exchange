Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class Form1
    ' Store the selected radio index for each user row
    Private selectedRadioIndex As New Dictionary(Of Integer, Integer)()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userListView.Clear()
        userListView.View = View.Details
        userListView.FullRowSelect = True
        userListView.GridLines = True
        userListView.HideSelection = False
        userListView.Font = New Font("Consolas", 11.0F)
        userListView.Scrollable = True
    End Sub

    Private Sub import_Click(sender As Object, e As EventArgs) Handles import.Click
        userListView.Items.Clear()
        userListView.Columns.Clear()
        selectedRadioIndex.Clear()

        Dim clipboardText As String = Clipboard.GetText()
        If String.IsNullOrWhiteSpace(clipboardText) Then
            MessageBox.Show("Clipboard is empty or does not contain text.")
            userCountLabel.Text = "Imported users: 0"
            Return
        End If
        Dim lines = clipboardText.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        Dim users As New List(Of String())()
        Dim maxParts As Integer = 2
        ' Sanitize and collect users
        For Each line In lines
            Dim trimmed = line.Trim()
            If String.IsNullOrWhiteSpace(trimmed) Then Continue For
            Dim cleaned = Regex.Replace(trimmed, "[^\p{L} ]", "")
            cleaned = Regex.Replace(cleaned, "\s+", " ").Trim()
            Dim parts = cleaned.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            If parts.Length < 2 Then Continue For
            users.Add(parts)
            If parts.Length > maxParts Then maxParts = parts.Length
        Next
        ' Add columns: Index, FirstName, Name2, Name3, ...
        userListView.Columns.Add("Index", 60, HorizontalAlignment.Left)
        userListView.Columns.Add("First Name", 120, HorizontalAlignment.Left)
        For i = 2 To maxParts
            userListView.Columns.Add($"Name {i}", 120, HorizontalAlignment.Left)
        Next
        ' Add rows
        For userIdx = 0 To users.Count - 1
            Dim parts = users(userIdx)
            Dim item As New ListViewItem((userIdx + 1).ToString("D2"), 0)
            item.UseItemStyleForSubItems = False
            item.SubItems.Add(parts(0))
            ' Default: select first radio for multi-name, or just show last name for two-part
            Dim defaultRadioIdx = If(parts.Length > 2, 1, -1)
            selectedRadioIndex(userIdx) = defaultRadioIdx
            For i = 1 To maxParts - 1
                Dim subItem As New ListViewItem.ListViewSubItem()
                If i < parts.Length Then
                    If parts.Length = 2 Then
                        subItem.Text = parts(i)
                        subItem.Font = New Font(userListView.Font, FontStyle.Bold)
                    Else
                        ' Simulate radio: selected = ⦿, unselected = ◯
                        Dim radioChar = If(i = defaultRadioIdx, "⦿", "◯")
                        subItem.Text = $"{radioChar} {parts(i)}"
                        If i >= defaultRadioIdx AndAlso defaultRadioIdx > 0 Then
                            subItem.Font = New Font(userListView.Font, FontStyle.Bold)
                        End If
                    End If
                Else
                    subItem.Text = ""
                End If
                item.SubItems.Add(subItem)
            Next
            userListView.Items.Add(item)
        Next
        userCountLabel.Text = $"Imported users: {users.Count}"
        ' Autosize columns to fit content and header
        For i = 0 To userListView.Columns.Count - 1
            userListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent)
            Dim contentWidth = userListView.Columns(i).Width
            userListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            Dim headerWidth = userListView.Columns(i).Width
            userListView.Columns(i).Width = Math.Max(contentWidth, headerWidth)
        Next
        ' Remove horizontal scrollbar by ensuring total width fits ListView
        Dim totalWidth As Integer = 0
        For i = 0 To userListView.Columns.Count - 1
            totalWidth += userListView.Columns(i).Width
        Next
        If totalWidth < userListView.ClientSize.Width Then
            userListView.Columns(userListView.Columns.Count - 1).Width += userListView.ClientSize.Width - totalWidth - 2
        End If
    End Sub

    ' Handle click to update radio selection and bolding
    Private Sub userListView_MouseClick(sender As Object, e As MouseEventArgs) Handles userListView.MouseClick
        Dim hit = userListView.HitTest(e.Location)
        If hit.Item Is Nothing OrElse hit.SubItem Is Nothing Then Return
        Dim rowIdx = hit.Item.Index
        Dim colIdx = hit.Item.SubItems.IndexOf(hit.SubItem)
        If colIdx < 2 Then Return ' Only allow radio selection in name columns
        Dim userParts = userListView.Items(rowIdx).SubItems.Count - 1
        If userParts < 3 Then Return ' Only for multi-name users
        ' Update selection
        selectedRadioIndex(rowIdx) = colIdx - 1
        ' Update all subitems for this row
        For i = 2 To userListView.Items(rowIdx).SubItems.Count - 1
            Dim subItem = userListView.Items(rowIdx).SubItems(i)
            If i = colIdx Then
                subItem.Text = $"⦿ {subItem.Text.Substring(2)}"
            ElseIf subItem.Text.StartsWith("⦿") Then
                subItem.Text = $"◯ {subItem.Text.Substring(2)}"
            End If
            ' Bold from selected radio onward
            If i >= colIdx Then
                subItem.Font = New Font(userListView.Font, FontStyle.Bold)
            Else
                subItem.Font = userListView.Font
            End If
        Next
    End Sub
ext.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()

    Private Sub userListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userListView.SelectedIndexChanged

    End Sub

    For Each c In normalized
    If Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> Globalization.UnicodeCategory.NonSpacingMark Then
                sb.Append(c)
            End If
    Next
    Return sb.ToString().Normalize(NormalizationForm.FormC)
    End Function
End Class
