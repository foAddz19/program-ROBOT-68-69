Imports System.Threading
Imports System.Media

Public Class Form1
    Dim rnd As New Random()
    Dim group1 As Button() = {}
    Dim group2 As Button() = {}
    Dim group3 As Button() = {}
    Dim group4 As Button() = {}

    Dim selectedButtons As New List(Of Button)
    Dim tickPlayer As New SoundPlayer("tick.wav")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        group1 = {Button2, Button3, Button4, Button5}
        group2 = {Button6, Button7, Button8}
        group3 = {Button9, Button10, Button11}
        group4 = {Button12, Button13, Button14}
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearAllBorders()

        Dim targets1 = GetRandomButtons(group1, 2)
        Dim targets2 = GetRandomButtons(group2, 2)
        Dim targets3 = GetRandomButtons(group3, 2)
        Dim targets4 = GetRandomButtons(group4, 2)

        selectedButtons.Clear()
        selectedButtons.AddRange(targets1)
        selectedButtons.AddRange(targets2)
        selectedButtons.AddRange(targets3)
        selectedButtons.AddRange(targets4)

        Dim startTime = Date.Now
        Dim index1 = 0
        Dim index2 = 0
        Dim index3 = 0
        Dim index4 = 0

        Do While (Date.Now - startTime).TotalSeconds < 5
            ClearAllBorders()

            DrawBorder(group1(index1), Color.Blue, 4, Color.LightBlue)
            DrawBorder(group2(index2), Color.Blue, 4, Color.LightBlue)
            DrawBorder(group3(index3), Color.Blue, 4, Color.LightBlue)
            DrawBorder(group4(index4), Color.Blue, 4, Color.LightBlue)

            tickPlayer.Play()

            index1 = (index1 + 1) Mod group1.Length
            index2 = (index2 + 1) Mod group2.Length
            index3 = (index3 + 1) Mod group3.Length
            index4 = (index4 + 1) Mod group4.Length

            Await Task.Delay(200)
        Loop

        ClearAllBorders()

        For Each btn In selectedButtons
            DrawBorder(btn, Color.Red, 5, Color.LightCoral)
        Next
    End Sub

    Private Function GetRandomButtons(group As Button(), count As Integer) As List(Of Button)
        Dim tempList As New List(Of Button)(group)
        Dim selected As New List(Of Button)

        For i = 1 To count
            Dim idx = rnd.Next(tempList.Count)
            selected.Add(tempList(idx))
            tempList.RemoveAt(idx)
        Next

        Return selected
    End Function

    Private Sub ClearAllBorders()
        Dim targetButtons As String() = {
            "Button2", "Button3", "Button4", "Button5",
            "Button6", "Button7", "Button8",
            "Button9", "Button10", "Button11",
            "Button12", "Button13", "Button14"
        }

        For Each ctrl In Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.FlatStyle = FlatStyle.Standard

                If targetButtons.Contains(btn.Name) Then
                    btn.BackColor = Color.LightGreen
                End If
            End If
        Next
    End Sub

    Private Sub DrawBorder(btn As Button, Optional borderColor As Color = Nothing,
                           Optional borderWidth As Integer = 2,
                           Optional backColor As Color = Nothing)
        If borderColor = Nothing Then borderColor = Color.Blue
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = borderColor
        btn.FlatAppearance.BorderSize = borderWidth
        If backColor <> Nothing Then btn.BackColor = backColor
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If selectedButtons.Count = 0 Then
            MessageBox.Show("ยังไม่มีข้อมูลสุ่ม กรุณากดปุ่มสุ่มก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim saveFolder = "D:\score"
        If Not IO.Directory.Exists(saveFolder) Then
            IO.Directory.CreateDirectory(saveFolder)
        End If

        SaveGroupToFile(IO.Path.Combine(saveFolder, "group1.txt"), group1, selectedButtons)
        SaveGroupToFile(IO.Path.Combine(saveFolder, "group2.txt"), group2, selectedButtons)
        SaveGroupToFile(IO.Path.Combine(saveFolder, "group3.txt"), group3, selectedButtons)
        SaveGroupToFile(IO.Path.Combine(saveFolder, "group4.txt"), group4, selectedButtons)
    End Sub

    Private Sub SaveGroupToFile(filepath As String, group As Button(), selected As List(Of Button))
        Dim nameMap As New Dictionary(Of String, String) From {
            {"Button2", "A"}, {"Button3", "B"}, {"Button4", "C"}, {"Button5", "D"},
            {"Button6", "E"}, {"Button7", "F"}, {"Button8", "G"},
            {"Button9", "H"}, {"Button10", "I"}, {"Button11", "J"},
            {"Button12", "K"}, {"Button13", "L"}, {"Button14", "M"}
        }

        Dim groupList As New List(Of String)

        For Each btn In group
            If selected.Contains(btn) Then
                If nameMap.ContainsKey(btn.Name) Then
                    groupList.Add(nameMap(btn.Name))
                Else
                    groupList.Add(btn.Name)
                End If
            End If
        Next

        Dim line As String = String.Join(" , ", groupList)
        System.IO.File.WriteAllText(filepath, line)
    End Sub

    ' ปุ่ม Reset Button20
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim saveFolder = "D:\score"
        If Not IO.Directory.Exists(saveFolder) Then
            IO.Directory.CreateDirectory(saveFolder)
        End If

        ' เขียนไฟล์เป็นค่าว่าง
        System.IO.File.WriteAllText(IO.Path.Combine(saveFolder, "group1.txt"), "")
        System.IO.File.WriteAllText(IO.Path.Combine(saveFolder, "group2.txt"), "")
        System.IO.File.WriteAllText(IO.Path.Combine(saveFolder, "group3.txt"), "")
        System.IO.File.WriteAllText(IO.Path.Combine(saveFolder, "group4.txt"), "")

        ' ตั้งสีปุ่ม Button2 ถึง Button14 กลับเป็นสีเดิม (LightGreen)
        Dim resetButtons As Button() = {Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Button10, Button11, Button12, Button13, Button14}
        For Each btn In resetButtons
            btn.BackColor = Color.LightGreen
            btn.FlatStyle = FlatStyle.Standard
            btn.FlatAppearance.BorderSize = 0
        Next

        ' เคลียร์รายการ selectedButtons
        selectedButtons.Clear()
    End Sub

End Class
